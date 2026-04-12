using QuanLyPhongMach.Data;
using QuanLyPhongMach.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhongMach.Forms
{
    public partial class FrmThuNgan : Form
    {

        // private string connectionString = @"Data Source=.;Initial Catalog=QuanLyPhongMach;User ID=sa;Password=duylun2005;TrustServerCertificate=True;";

        // Biến lưu mã phiếu khám đang được chọn
        private int maPhieuKhamDuocChon = 0; // Sửa thành int để khớp với khóa chính
        private decimal tongTienHienTai = 0;

        public FrmThuNgan()
        {
            InitializeComponent();
        }

        private void FrmThuNgan_Load(object sender, EventArgs e)
        {
            // 1. Thêm các mục vào ComboBox nếu danh sách đang trống
            if (cboHinhThuc.Items.Count == 0)
            {
                cboHinhThuc.Items.Add("Tiền mặt");
                cboHinhThuc.Items.Add("Chuyển khoản");
                cboHinhThuc.Items.Add("Thẻ tín dụng/Ghi nợ");
            }

            // 2. Set up mặc định cho Cbo hình thức thanh toán (chỉ chọn khi đã có item)
            if (cboHinhThuc.Items.Count > 0)
            {
                cboHinhThuc.SelectedIndex = 0; // Chọn mục đầu tiên ("Tiền mặt") làm mặc định
            }

            // Tắt auto generate columns nếu bạn đã tạo cột sẵn trong giao diện
            dgvChiTietPhieuKham.AutoGenerateColumns = false;
            dgvChiTietDichVu.AutoGenerateColumns = false;

            LoadDanhSachPhieuKhamChuaThanhToan("");
        }

        // 1. HÀM LOAD DANH SÁCH PHIẾU KHÁM LÊN BẢNG TRÁI
        private void LoadDanhSachPhieuKhamChuaThanhToan(string tuKhoa)
        {
            try
            {
                using (var db = new PhongMachDbContext())
                {
                    var query = db.PhieuKhams
                                  .Include(pk => pk.LichKham)
                                  .ThenInclude(lk => lk.KhachHang)
                                  .Include(pk => pk.LichKham)
                                  .ThenInclude(lk => lk.BacSi)
                                  .Where(pk => !db.HoaDons.Any(hd => hd.MaPK == pk.MaPK));

                    if (!string.IsNullOrEmpty(tuKhoa))
                    {
                        query = query.Where(pk => pk.MaHienThi.Contains(tuKhoa) || pk.LichKham.KhachHang.TenKH.Contains(tuKhoa));
                    }

                    var danhSach = query.Select(pk => new
                    {
                        MaPK = pk.MaPK, // ID thật để xử lý
                        MaPhieuKham = pk.MaHienThi,
                        TenBenhNhan = pk.LichKham.KhachHang.TenKH,
                        TenBacSiKham = pk.LichKham.BacSi.TenBS
                    }).ToList();

                    // Tắt AutoGenerateColumns để đảm bảo các cột thiết kế được sử dụng
                    dgvChiTietPhieuKham.AutoGenerateColumns = false;
                    dgvChiTietPhieuKham.DataSource = danhSach;

                    // Ánh xạ dữ liệu vào các cột đã thiết kế
                    // Giả sử tên các cột trong Designer là: colMaPhieuKham, colTenBenhNhan, colTenBacSi
                    // Nếu tên khác, bạn cần đổi lại cho đúng
                    dgvChiTietPhieuKham.Columns["MaPhieuKham"].DataPropertyName = "MaPhieuKham";
                    dgvChiTietPhieuKham.Columns["TenBenhNhan"].DataPropertyName = "TenBenhNhan";
                    dgvChiTietPhieuKham.Columns["TenBacSiKham"].DataPropertyName = "TenBacSiKham";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách phiếu khám: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 2. SỰ KIỆN TÌM KIẾM
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadDanhSachPhieuKhamChuaThanhToan(txtTimKiem.Text.Trim());
        }

        // 3. SỰ KIỆN CLICK VÀO 1 PHIẾU KHÁM ĐỂ XEM CHI TIẾT
        private void dgvChiTietPhieuKham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy toàn bộ đối tượng dữ liệu của dòng được chọn
                var selectedRowData = dgvChiTietPhieuKham.Rows[e.RowIndex].DataBoundItem;
                if (selectedRowData != null)
                {
                    // Lấy giá trị MaPK và TenBenhNhan một cách an toàn bằng reflection
                    int maPK = (int)selectedRowData.GetType().GetProperty("MaPK").GetValue(selectedRowData, null);
                    string tenBN = selectedRowData.GetType().GetProperty("TenBenhNhan").GetValue(selectedRowData, null)?.ToString();

                    maPhieuKhamDuocChon = maPK;
                    txtBenhNhan.Text = tenBN;
                    LoadChiTietDichVuVaThuoc(maPhieuKhamDuocChon);
                }
            }
        }

        // 4. HÀM LOAD CHI TIẾT VÀO BẢNG PHẢI (Gộp cả dịch vụ và thuốc)
        private void LoadChiTietDichVuVaThuoc(int maPhieuKham)
        {
            dgvChiTietDichVu.Rows.Clear();
            tongTienHienTai = 0;

            try
            {
                using (var db = new PhongMachDbContext())
                {
                    // --- BƯỚC A: LẤY DANH SÁCH DỊCH VỤ ---
                    var chiTietDV = db.ChiTietDichVus
                                      .Include(ct => ct.DichVu)
                                      .Where(ct => ct.MaPK == maPhieuKham)
                                      .ToList();

                    foreach (var item in chiTietDV)
                    {
                        dgvChiTietDichVu.Rows.Add(item.DichVu.TenDichVu, item.DichVu.DonGia.ToString("N0"), "", "", "");
                        tongTienHienTai += (item.SoLuong * item.DichVu.DonGia);
                    }

                    // --- BƯỚC B: LẤY DANH SÁCH ĐƠN THUỐC ---
                    var chiTietThuoc = db.ChiTietDonThuocs
                                         .Include(ct => ct.Thuoc)
                                         .Where(ct => ct.MaPK == maPhieuKham)
                                         .ToList();

                    foreach (var item in chiTietThuoc)
                    {
                        dgvChiTietDichVu.Rows.Add("", "", item.Thuoc.TenThuoc, item.SoLuong, item.Thuoc.DonGia.ToString("N0"));
                        tongTienHienTai += (item.SoLuong * item.Thuoc.DonGia);
                    }

                    lblTongTien.Text = tongTienHienTai.ToString("N0") + " VNĐ";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải chi tiết: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 5. XỬ LÝ NÚT XÁC NHẬN THANH TOÁN
        private void btnXacNhanThanhToan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maPhieuKhamDuocChon.ToString()) || maPhieuKhamDuocChon == 0)
            {
                MessageBox.Show("Vui lòng chọn một phiếu khám để thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show($"Xác nhận thu tiền bệnh nhân {txtBenhNhan.Text}\nTổng tiền: {lblTongTien.Text}?",
                                               "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    using (var db = new PhongMachDbContext())
                    {
                        var hoaDonMoi = new HoaDon
                        {
                            MaPK = maPhieuKhamDuocChon,
                            TongTien = tongTienHienTai,
                            PhuongThucThanhToan = cboHinhThuc.SelectedItem?.ToString() ?? "Tiền mặt",
                            TrangThaiThanhToan = "Đã thanh toán",
                            NgayThanhToan = DateTime.Now
                        };

                        db.HoaDons.Add(hoaDonMoi);
                        db.SaveChanges();

                        // =========================================================================
                        //Thay thế MessageBox thông báo đơn thuần bằng DialogResult hỏi In hoá đơn
                        // =========================================================================
                        DialogResult printDialog = MessageBox.Show("Thanh toán thành công!\nBạn có muốn in hoá đơn cho bệnh nhân này không?",
                                                                   "In hoá đơn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (printDialog == DialogResult.Yes)
                        {
                            // Lấy chính xác Mã Hóa Đơn (MaHD) vừa được EF Core tự tạo
                            int maHoaDonVuaTao = hoaDonMoi.MaHD;

                            // Truyền sang Form In
                            FrmInHoaDon frmIn = new FrmInHoaDon(maHoaDonVuaTao);
                            frmIn.ShowDialog();
                        }

                        // Dọn dẹp màn hình sau khi thanh toán
                        maPhieuKhamDuocChon = 0;
                        txtBenhNhan.Text = "";
                        txtGhiChu.Text = "";
                        lblTongTien.Text = "0 VNĐ";
                        dgvChiTietDichVu.Rows.Clear();

                        // Load lại danh sách (phiếu vừa thanh toán sẽ tự động biến mất)
                        LoadDanhSachPhieuKhamChuaThanhToan(txtTimKiem.Text);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thanh toán: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
