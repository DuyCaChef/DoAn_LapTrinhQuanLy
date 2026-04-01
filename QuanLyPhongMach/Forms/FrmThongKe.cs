using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using QuanLyPhongMach.Data;
using System.Windows.Forms.DataVisualization.Charting;
using System.Globalization; // Để định dạng tiền tệ

namespace QuanLyPhongMach.Forms
{
    public partial class FrmThongKe : Form
    {
        public FrmThongKe()
        {
            InitializeComponent();
        }

        private void FrmThongKe_Load(object sender, EventArgs e)
        {
            // Mặc định lọc từ đầu tháng đến hiện tại
            dtpStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpEnd.Value = DateTime.Now;

            // Chạy thống kê lần đầu khi mở form
            LoadThongKeTongQuan();
            VeBieuDoDoanhThu7Ngay();
        }

        // Sự kiện khi nhấn nút "Xem Thống Kê"
        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (dtpStart.Value.Date > dtpEnd.Value.Date)
            {
                MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LoadThongKeTongQuan();
        }

        private void LoadThongKeTongQuan()
        {
            try
            {
                using (var db = new PhongMachDbContext())
                {
                    DateTime start = dtpStart.Value.Date;
                    DateTime end = dtpEnd.Value.Date.AddDays(1).AddTicks(-1);

                    // 1. Doanh thu tạm tính (Sửa thành NgayThanhToan)
                    // Vì NgayThanhToan là DateTime? (nullable) nên ta kiểm tra .HasValue
                    var doanhThu = db.HoaDons
                        .Where(h => h.NgayThanhToan.HasValue &&
                                    h.NgayThanhToan.Value >= start &&
                                    h.NgayThanhToan.Value <= end)
                        .Sum(h => (decimal?)h.TongTien) ?? 0;

                    lblRevenueValue.Text = doanhThu.ToString("N0") + " đ";

                    // 2. Phiếu đã hoàn thành (Sửa thành NgayLap)
                    var soPhieu = db.PhieuKhams
                        .Count(p => p.NgayLap >= start && p.NgayLap <= end);
                    lblDaKham.Text = soPhieu.ToString();

                    // 3. Bệnh nhân đang chờ (Sửa thành NgayKham)
                    var choKham = db.LichKhams
                        .Count(lk => lk.NgayKham.Date == DateTime.Today && lk.TrangThai == "Chờ khám");
                    lblChoKham.Text = choKham.ToString();

                    // 4. Lịch hẹn đã hủy (Sửa thành NgayKham)
                    var daHuy = db.LichKhams
                        .Count(lk => lk.NgayKham >= start && lk.NgayKham <= end && lk.TrangThai == "Đã hủy");
                    lblDaHuy.Text = daHuy.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu thống kê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void VeBieuDoDoanhThu7Ngay()
        {
            try
            {
                using (var db = new PhongMachDbContext())
                {
                    // 1. Lấy dữ liệu 7 ngày gần nhất (tính cả hôm nay)
                    DateTime ngayBatDau = DateTime.Today.AddDays(-6);

                    var data = db.HoaDons
                        .Where(h => h.NgayThanhToan.HasValue && h.NgayThanhToan.Value.Date >= ngayBatDau)
                        .GroupBy(h => h.NgayThanhToan.Value.Date)
                        .Select(g => new
                        {
                            Ngay = g.Key,
                            // Ép kiểu decimal sang double vì Chart WinForms làm việc tốt nhất với double
                            TongTien = (double)g.Sum(h => h.TongTien)
                        })
                        .OrderBy(item => item.Ngay)
                        .ToList();

                    // 2. Làm sạch biểu đồ trước khi vẽ
                    chartRevenue.Series.Clear();
                    chartRevenue.ChartAreas[0].AxisX.Interval = 1; // Đảm bảo hiện đủ các ngày trên trục X

                    // 3. Khởi tạo Series (Cột dữ liệu)
                    Series series = new Series("Doanh Thu")
                    {
                        ChartType = SeriesChartType.Column,
                        Color = Color.FromArgb(0, 120, 215), // Màu xanh dương chuyên nghiệp
                        IsValueShownAsLabel = true,         // Hiện số tiền trên đỉnh cột
                        Font = new Font("Segoe UI", 9f, FontStyle.Bold)
                    };

                    // 4. Nạp dữ liệu vào các cột
                    foreach (var item in data)
                    {
                        series.Points.AddXY(item.Ngay.ToString("dd/MM"), item.TongTien);
                    }

                    // 5. Đưa Series vào biểu đồ và định dạng thẩm mỹ
                    chartRevenue.Series.Add(series);

                    // Ẩn lưới dọc (X) cho thoáng, giữ lưới ngang (Y) để dễ nhìn mức tiền
                    chartRevenue.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                    chartRevenue.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;

                    // Định dạng trục Y hiển thị phân cách hàng nghìn (ví dụ: 1.000.000)
                    chartRevenue.ChartAreas[0].AxisY.LabelStyle.Format = "N0";
                }
            }
            catch (Exception ex)
            {
                // Ghi lỗi ra Console để bạn dễ debug khi đang code
                Console.WriteLine("Lỗi chi tiết khi vẽ biểu đồ: " + ex.Message);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đóng và quay về trang chủ?",
                                                 "Xác nhận thoát",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
