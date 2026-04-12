using Microsoft.EntityFrameworkCore;
using Microsoft.Reporting.WinForms;
using QuanLyPhongMach.Data;
using QuanLyPhongMach.Data.Entities;
using QuanLyPhongMach.Reports;
using QuanLyPhongMach.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyPhongMach.Forms
{
    public partial class FrmInHoaDon : Form
    {
        private int _maHoaDon;

        // Nhận Mã Phiếu Khám từ form Thu Ngân truyền sang
        public FrmInHoaDon(int maHoaDon)
        {
            InitializeComponent();
            _maHoaDon = maHoaDon;

            // Khởi tạo và ép ReportViewer nằm đầy form
            reportViewer1 = new ReportViewer();
            reportViewer1.Dock = DockStyle.Fill;
            this.Controls.Add(reportViewer1);

            //  Gắn sự kiện Load bằng code để đảm bảo nó chạy 100%
            this.Load += FrmInHoaDon_Load;
        }

        private void FrmInHoaDon_Load(object sender, EventArgs e)
        {
            LoadReport();
        }   

        private void LoadReport()
        {
            try
            {
                using (var db = new PhongMachDbContext())
                {
                    // 1. Tìm Hóa Đơn dựa theo MÃ PHIẾU KHÁM
                    var hoaDon = db.HoaDons
                        .Include(hd => hd.PhieuKham)
                        .ThenInclude(pk => pk.LichKham)
                        .ThenInclude(lk => lk.KhachHang)
                        .FirstOrDefault(hd => hd.MaHD == _maHoaDon);

                    if (hoaDon == null)
                    {
                        MessageBox.Show("Không tìm thấy dữ liệu Hóa Đơn cho Phiếu Khám này!", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 2. Gom dữ liệu Dịch Vụ và Thuốc vào chung 1 List DTO
                    List<ChiTietHoaDonDTO> listChiTiet = new List<ChiTietHoaDonDTO>();

                    var dichVus = db.ChiTietDichVus
                        .Include(ct => ct.DichVu)
                        .Where(ct => ct.MaPK == hoaDon.MaPK)
                        .Select(ct => new ChiTietHoaDonDTO
                        {
                            TenHang = ct.DichVu.TenDichVu,
                            SoLuong = ct.SoLuong,
                            DonGia = ct.DichVu.DonGia,
                            ThanhTien = ct.SoLuong * ct.DichVu.DonGia
                        }).ToList();
                    listChiTiet.AddRange(dichVus);

                    var thuocs = db.ChiTietDonThuocs
                        .Include(ct => ct.Thuoc)
                        .Where(ct => ct.MaPK == hoaDon.MaPK)
                        .Select(ct => new ChiTietHoaDonDTO
                        {
                            TenHang = ct.Thuoc.TenThuoc,
                            SoLuong = ct.SoLuong,
                            DonGia = ct.Thuoc.DonGia,
                            ThanhTien = ct.SoLuong * ct.Thuoc.DonGia
                        }).ToList();
                    listChiTiet.AddRange(thuocs);

                    // 3. XỬ LÝ ĐƯỜNG DẪN FILE BÁO CÁO (Tránh lỗi ngầm tàng hình)
                    string reportPath = System.IO.Path.Combine(Application.StartupPath, "Reports", "rptInHoaDon.rdlc");
                    if (!System.IO.File.Exists(reportPath))
                    {
                        // Thử tìm ở thư mục gốc nếu không có trong thư mục Reports
                        reportPath = System.IO.Path.Combine(Application.StartupPath, "rptInHoaDon.rdlc");
                        if (!System.IO.File.Exists(reportPath))
                        {
                            MessageBox.Show("Không tìm thấy file rptInHoaDon.rdlc!\n\nHãy vào Solution Explorer, chuột phải file rptInHoaDon.rdlc -> Properties -> Chuyển 'Copy to Output Directory' thành 'Copy if newer'.", "Thiếu file thiết kế", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    reportViewer1.LocalReport.ReportPath = reportPath;
                    reportViewer1.LocalReport.DataSources.Clear();

                    // Đưa danh sách vào Dataset (Tên "dsChiTietHoaDon" phải khớp với tên trong file rdlc)
                    ReportDataSource rds = new ReportDataSource("dsChiTietHoaDon", listChiTiet);
                    reportViewer1.LocalReport.DataSources.Add(rds);

                    // 4. Truyền các tham số (Parameters)
                    ReportParameter[] p = new ReportParameter[]
                    {
                        new ReportParameter("pTenBenhNhan", hoaDon.PhieuKham.LichKham.KhachHang.TenKH),
                        new ReportParameter("pDiaChi", hoaDon.PhieuKham.LichKham.KhachHang.DiaChi ?? "Không có địa chỉ"),
                        new ReportParameter("pNgayIn", $"Ngày {System.DateTime.Now.Day} tháng {System.DateTime.Now.Month} năm {System.DateTime.Now.Year}"),
                        
                        // Nếu bạn đã đổi tên Parameter thành pTongTienSo ở bước trước thì sửa lại chuỗi ở dưới đây:
                        new ReportParameter("pTongTienChu", $"Tổng tiền: {hoaDon.TongTien.ToString("N0")} VNĐ")
                    };
                    reportViewer1.LocalReport.SetParameters(p);

                    // Làm mới Report để nó vẽ ra màn hình
                    reportViewer1.RefreshReport();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị báo cáo: " + ex.Message, "Lỗi Code", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    
    }
}