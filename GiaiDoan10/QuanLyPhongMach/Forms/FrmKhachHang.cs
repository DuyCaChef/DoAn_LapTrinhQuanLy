using Microsoft.EntityFrameworkCore;
using QuanLyPhongMach.Data;
using QuanLyPhongMach.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace QuanLyPhongMach.Forms
{
    public partial class FrmKhachHang : Form
    {

        private TaiKhoan _taiKhoanDangNhap;
        private KhachHang _khachHangHienTai;

        // Constructor nhận tài khoản từ màn hình Đăng Nhập truyền sang
        public FrmKhachHang()
        {
            InitializeComponent();
        }

        public FrmKhachHang(TaiKhoan tk) : this()
        {
            _taiKhoanDangNhap = tk;
        }

        private void FrmKhachHang_Load(object sender, EventArgs e)
        {
            // Thiết lập ẩn mật khẩu mặc định
            txtMatKhauCu.UseSystemPasswordChar = true;
            txtMatKhauMoi.UseSystemPasswordChar = true;

            // Tắt auto generate column cho DataGridView
            dgvLichKham.AutoGenerateColumns = false;
            dgvLichSuKham.AutoGenerateColumns = false;

            // Không cho chọn ngày trong quá khứ khi đặt lịch
            dtpNgayKham.MinDate = new DateTime(1900, 1, 1); // Nới lỏng tạm thời để tránh lỗi văng app
            dtpNgayKham.Value = DateTime.Today;
            dtpNgayKham.MinDate = DateTime.Today;

            // Tự động gắn sự kiện để mỗi khi đổi Ngày, hệ thống sẽ tính toán lại các khung Giờ
            dtpNgayKham.ValueChanged -= new EventHandler(dtpNgayKham_ValueChanged);
            dtpNgayKham.ValueChanged += new EventHandler(dtpNgayKham_ValueChanged);

            LoadDuLieuKhachHang();
        }

        // =========================================================================================
        // 0. HÀM TẢI DỮ LIỆU GỐC CỦA KHÁCH HÀNG
        // =========================================================================================
        private void LoadDuLieuKhachHang()
        {
            // [BỔ SUNG CHỐNG LỖI LINQ EXCEPTION]: Kiểm tra xem tài khoản có bị null không
            // Nếu bạn đang chạy trực tiếp Form này từ Program.cs, nó sẽ báo lỗi này
            if (_taiKhoanDangNhap == null)
            {
                MessageBox.Show("Lỗi: Không nhận được dữ liệu Tài khoản đăng nhập!\nVui lòng mở form này thông qua màn hình Đăng Nhập (truyền biến TaiKhoan vào).", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            try
            {
                using (var db = new PhongMachDbContext())
                {
                    // [TỐI ƯU]: Tách ID ra một biến rời trước khi đưa vào LINQ để tránh lỗi "evaluate a LINQ query parameter"
                    int maTaiKhoan = _taiKhoanDangNhap.MaTK;

                    // Tìm hồ sơ khách hàng khớp với Mã Tài Khoản
                    _khachHangHienTai = db.khachHangs.FirstOrDefault(k => k.MaTK == maTaiKhoan);

                    // =====================================================================
                    // [BỔ SUNG LOGIC CHO ADMIN]
                    // =====================================================================
                    if (_khachHangHienTai == null)
                    {
                        // Kiểm tra xem người đăng nhập có phải là ADMIN không
                        if (!string.IsNullOrEmpty(_taiKhoanDangNhap.VaiTro) && _taiKhoanDangNhap.VaiTro.ToUpper().Contains("ADMIN"))
                        {
                            // Tự động tạo hồ sơ Bệnh nhân ảo để Admin test chức năng
                            _khachHangHienTai = new KhachHang
                            {
                                MaTK = maTaiKhoan,
                                TenKH = "Quản Trị Viên (Test)",
                                SoDienThoai = _taiKhoanDangNhap.TenDangNhap ?? "0000000000",
                                DiaChi = "Hệ thống Admin",
                                GioiTinh = "Khác",
                                NgaySinh = DateTime.Today
                            };
                            db.khachHangs.Add(_khachHangHienTai);
                            db.SaveChanges();

                            MessageBox.Show("Hệ thống đã tự tạo Hồ sơ Bệnh nhân ảo cho Admin để trải nghiệm tính năng Đặt lịch!", "Chế độ Admin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            // Nếu là Khách hàng thật nhưng bị lỗi mất Data
                            MessageBox.Show("Không tìm thấy hồ sơ bệnh nhân liên kết với tài khoản này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                            return;
                        }
                    }
                    // =====================================================================

                    // Tiếp tục hiển thị dữ liệu bình thường sau khi chắc chắn đã có _khachHangHienTai
                    // 1. Hiển thị thông tin Header
                    lblTenBenhNhan.Text = $"Bệnh Nhân: {_khachHangHienTai.TenKH}";
                    lblMaBenhNhan.Text = $"Mã BN: KH{_khachHangHienTai.MaKH:D4}";

                    // 2. Tải dữ liệu cho Tab Đặt Lịch
                    LoadComboBoxChuyenKhoa();
                    LoadComboBoxGioKham(); // Tải khung giờ khám khả dụng
                    LoadLichKhamSapToi();

                    // 3. Tải dữ liệu cho Tab Lịch Sử Khám
                    LoadLichSuKhamBenh();

                    // 4. Tải dữ liệu cho Tab Hồ Sơ Cá Nhân
                    HienThiThongTinCaNhan();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu khách hàng: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================================================================
        // 1. TAB ĐẶT LỊCH KHÁM
        // =========================================================================================
        private void LoadComboBoxChuyenKhoa()
        {
            // Bỏ truy vấn Entity Framework vì không có bảng ChuyenKhoa
            cboChuyenKhoa.Items.Clear();
            cboChuyenKhoa.Items.Add("--- Chọn chuyên khoa ---");
            cboChuyenKhoa.Items.AddRange(new string[] {
                "Nội khoa", "Ngoại khoa", "Nhi khoa", "Sản - Phụ khoa", "Tai - Mũi - Họng"
            });
            cboChuyenKhoa.SelectedIndex = 0; // Mặc định chọn dòng đầu tiên nhắc nhở
        }

        // Sự kiện khi Khách hàng chọn Chuyên Khoa thì đổ danh sách Bác sĩ tương ứng
        private void cboChuyenKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboChuyenKhoa.SelectedIndex > 0)
            {
                string chuyenKhoa = cboChuyenKhoa.SelectedItem.ToString();
                using (var db = new PhongMachDbContext())
                {
                    // Tìm Bác sĩ bằng chuỗi Tên Chuyên Khoa
                    var dsBacSi = db.BacSis.Where(b => b.ChuyenKhoa == chuyenKhoa).ToList();

                    // Thêm lựa chọn nhắc nhở (Bắt buộc phải chọn bác sĩ thật)
                    dsBacSi.Insert(0, new BacSi { MaBS = 0, TenBS = "--- Chọn bác sĩ ---" });

                    cboChonBacSi.DataSource = dsBacSi;
                    cboChonBacSi.DisplayMember = "TenBS";
                    cboChonBacSi.ValueMember = "MaBS";
                }
            }
            else
            {
                cboChonBacSi.DataSource = null;
            }
        }

        // Hàm xử lý lọc Giờ khám (Không lấy giờ trong quá khứ)
        private void LoadComboBoxGioKham()
        {
            cboGioKham.DataSource = null; // Gỡ bỏ DataSource cũ
            cboGioKham.Items.Clear();

            string[] cacKhungGio = new string[] {
                "08:00 - 08:30", "08:30 - 09:00", "09:00 - 09:30", "09:30 - 10:00",
                "10:00 - 10:30", "10:30 - 11:00", "13:30 - 14:00", "14:00 - 14:30",
                "14:30 - 15:00", "15:00 - 15:30", "15:30 - 16:00", "16:00 - 16:30"
            };

            DateTime ngayChon = dtpNgayKham.Value.Date;
            DateTime homNay = DateTime.Today;
            TimeSpan gioHienTai = DateTime.Now.TimeOfDay;

            foreach (string khung in cacKhungGio)
            {
                // Cắt lấy giờ bắt đầu. Ví dụ: "08:00 - 08:30" -> lấy "08:00"
                TimeSpan gioBatDau = TimeSpan.Parse(khung.Split('-')[0].Trim());

                // Nếu ngày chọn là ngày mai trở đi, HOẶC là hôm nay nhưng giờ chưa trôi qua thì mới cho phép đặt
                if (ngayChon > homNay || (ngayChon == homNay && gioBatDau > gioHienTai))
                {
                    cboGioKham.Items.Add(khung);
                }
            }
        }

        private void dtpNgayKham_ValueChanged(object sender, EventArgs e)
        {
            LoadComboBoxGioKham();
        }

        private void LoadLichKhamSapToi()
        {
            using (var db = new PhongMachDbContext())
            {
                var lichSapToi = db.LichKhams
                                   .Include(l => l.BacSi)
                                   .Where(l => l.MaKH == _khachHangHienTai.MaKH && l.TrangThai == "Chờ khám" && l.NgayKham >= DateTime.Today)
                                   .Select(l => new
                                   {
                                       NgayKham = l.NgayKham.ToString("dd/MM/yyyy") + " " + l.GioKham.ToString(@"hh\:mm"),
                                       TenBS = l.BacSi != null ? l.BacSi.TenBS : "Chưa rõ",
                                       TrangThai = l.TrangThai
                                   })
                                   .ToList();

                dgvLichKham.DataSource = lichSapToi;

                if (dgvLichKham.Columns.Count > 0)
                {
                    dgvLichKham.Columns[0].DataPropertyName = "NgayKham";
                    dgvLichKham.Columns[1].DataPropertyName = "TenBS";
                    dgvLichKham.Columns[2].DataPropertyName = "TrangThai";
                }
            }
        }

        private void btnXacNhanDatLich_Click(object sender, EventArgs e)
        {
            // Kiểm tra validate (Bắt buộc chọn Chuyên khoa, Bác sĩ và Giờ khám)
            if (cboChuyenKhoa.SelectedIndex <= 0)
            {
                MessageBox.Show("Vui lòng chọn chuyên khoa bạn muốn khám!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboChonBacSi.SelectedIndex <= 0)
            {
                MessageBox.Show("Vui lòng chọn Bác sĩ phụ trách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboGioKham.SelectedIndex == -1) // Đã sửa lại điều kiện kiểm tra rỗng
            {
                MessageBox.Show("Vui lòng chọn Giờ khám!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // XỬ LÝ ÉP KIỂU TIMESPAN
                string chuoiGio = cboGioKham.SelectedItem.ToString(); // VD: "08:00 - 08:30"
                string gioBatDau = chuoiGio.Split('-')[0].Trim();     // Lấy "08:00"
                TimeSpan gioKhamSave = TimeSpan.Parse(gioBatDau);     // Ép kiểu

                using (var db = new PhongMachDbContext())
                {
                    int maBSSave = (int)cboChonBacSi.SelectedValue;

                    // --- BỔ SUNG: KIỂM TRA TRÙNG LỊCH KHÁM ---
                    bool daCoNguoiDat = db.LichKhams.Any(lk =>
                        lk.MaBS == maBSSave &&
                        lk.NgayKham == dtpNgayKham.Value.Date &&
                        lk.GioKham == gioKhamSave &&
                        lk.TrangThai == "Chờ khám" // Chỉ kiểm tra những lịch chưa bị hủy/khám xong
                    );

                    if (daCoNguoiDat)
                    {
                        MessageBox.Show("Khung giờ này của Bác sĩ đã có người đặt.\nVui lòng chọn Bác sĩ hoặc khung giờ khác!", "Trùng lịch khám", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Dừng lại, không cho lưu
                    }
                    // -----------------------------------------

                    var lichKhamMoi = new LichKham
                    {
                        MaKH = _khachHangHienTai.MaKH,
                        MaBS = maBSSave,
                        NgayKham = dtpNgayKham.Value.Date,
                        GioKham = gioKhamSave, // Đã bổ sung lưu Giờ Khám chính xác
                        TrangThai = "Chờ khám"
                        // GhiChu / TrieuChung đã được loại bỏ hoàn toàn khỏi code
                    };

                    db.LichKhams.Add(lichKhamMoi);
                    db.SaveChanges();

                    MessageBox.Show($"Đặt lịch khám thành công!\nVui lòng đến phòng mạch lúc {gioKhamSave.ToString(@"hh\:mm")} ngày {dtpNgayKham.Value:dd/MM/yyyy}.",
                                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Đặt lại các Form Input về mặc định
                    cboChuyenKhoa.SelectedIndex = 0;
                    cboChonBacSi.DataSource = null;

                    // Nới lỏng Max/Min trước khi reset Value để tránh lỗi ArgumentOutOfRange
                    dtpNgayKham.MinDate = new DateTime(1900, 1, 1);
                    dtpNgayKham.Value = DateTime.Today;
                    dtpNgayKham.MinDate = DateTime.Today;

                    LoadComboBoxGioKham();
                    LoadLichKhamSapToi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đặt lịch: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // =========================================================================================
        // 2. TAB LỊCH SỬ KHÁM BỆNH
        // =========================================================================================
        private void LoadLichSuKhamBenh()
        {
            using (var db = new PhongMachDbContext())
            {
                var lichSu = db.LichKhams
                               .Include(l => l.BacSi)
                               // Đã xóa .ThenInclude(b => b.ChuyenKhoa) vì không còn bảng Chuyên Khoa
                               .Where(l => l.MaKH == _khachHangHienTai.MaKH && l.TrangThai == "Đã khám")
                               .OrderByDescending(l => l.NgayKham)
                               .ToList();

                var dataGrip = lichSu.Select(l => new
                {
                    NgayKham = l.NgayKham.ToString("dd/MM/yyyy") + " " + l.GioKham.ToString(@"hh\:mm"),
                    BacSiPhuTrach = l.BacSi != null ? l.BacSi.TenBS : "",
                    // Lấy trực tiếp thuộc tính ChuyenKhoa (string) từ bảng BacSi
                    ChuyenKhoa = l.BacSi != null ? l.BacSi.ChuyenKhoa : "",
                    KetLuan = db.PhieuKhams.FirstOrDefault(pk => pk.MaLichKham == l.MaLichKham)?.ChanDoan ?? "Đang chờ kết luận"
                }).ToList();

                dgvLichSuKham.DataSource = dataGrip;

                if (dgvLichSuKham.Columns.Count > 0)
                {
                    dgvLichSuKham.Columns[0].DataPropertyName = "NgayKham";
                    dgvLichSuKham.Columns[1].DataPropertyName = "BacSiPhuTrach";
                    dgvLichSuKham.Columns[2].DataPropertyName = "ChuyenKhoa";
                    dgvLichSuKham.Columns[3].DataPropertyName = "KetLuan";
                    dgvLichSuKham.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
        }


        // =========================================================================================
        // 3. TAB HỒ SƠ CÁNH NHÂN
        // =========================================================================================
        private void HienThiThongTinCaNhan()
        {
            if (cboGioiTinh.Items.Count == 0)
            {
                cboGioiTinh.Items.AddRange(new string[] { "Nam", "Nữ", "Khác" });
            }

            txtHoTen.Text = _khachHangHienTai.TenKH;
            if (_khachHangHienTai.NgaySinh.HasValue) dtpNgaySinh.Value = _khachHangHienTai.NgaySinh.Value;
            txtSDT.Text = _khachHangHienTai.SoDienThoai;
            txtSDT.ReadOnly = true;
            cboGioiTinh.SelectedItem = _khachHangHienTai.GioiTinh;
            txtDiaChi.Text = _khachHangHienTai.DiaChi;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Họ tên không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // BỔ SUNG: Chặn lỗi khách hàng chọn ngày sinh ở tương lai
            if (dtpNgaySinh.Value.Date > DateTime.Today)
            {
                MessageBox.Show("Ngày sinh không hợp lệ!\nKhông thể chọn ngày sinh ở tương lai.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgaySinh.Focus();
                return;
            }

            try
            {
                using (var db = new PhongMachDbContext())
                {
                    // Đã sửa thành db.KhachHangs
                    var khToUpdate = db.khachHangs.Find(_khachHangHienTai.MaKH);
                    if (khToUpdate != null)
                    {
                        khToUpdate.TenKH = txtHoTen.Text.Trim();
                        khToUpdate.NgaySinh = dtpNgaySinh.Value.Date;
                        khToUpdate.GioiTinh = cboGioiTinh.SelectedItem?.ToString();
                        khToUpdate.DiaChi = txtDiaChi.Text.Trim();

                        db.SaveChanges();
                        _khachHangHienTai = khToUpdate;
                        lblTenBenhNhan.Text = $"Bệnh Nhân: {_khachHangHienTai.TenKH}";

                        MessageBox.Show("Cập nhật thông tin cá nhân thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ckbHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            bool hien = ckbHienMatKhau.Checked;
            txtMatKhauCu.UseSystemPasswordChar = !hien;
            txtMatKhauMoi.UseSystemPasswordChar = !hien;
        }

        private string HashPassword(string rawPassword)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                //Chuyen doi mat khau thanh mang byte
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawPassword));

                //Chuyen mang byte ve dang chuoi Hexadecimal de luu/so sanh coi DB
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            string mkCu = txtMatKhauCu.Text.Trim();
            string mkMoi = txtMatKhauMoi.Text.Trim();

            if (string.IsNullOrEmpty(mkCu) || string.IsNullOrEmpty(mkMoi))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mật khẩu cũ và Mật khẩu mới!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new PhongMachDbContext())
                {
                    var tkToUpdate = db.TaiKhoans.Find(_taiKhoanDangNhap.MaTK);
                    if (tkToUpdate != null)
                    {
                        // Gọi hàm mã hóa trước khi so sánh và lưu
                        string hashMkCu = HashPassword(mkCu);
                        string hashMkMoi = HashPassword(mkMoi);

                        if (tkToUpdate.MatKhauHash != hashMkCu)
                        {
                            MessageBox.Show("Mật khẩu cũ không chính xác!", "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        tkToUpdate.MatKhauHash = hashMkMoi;
                        db.SaveChanges();
                        _taiKhoanDangNhap.MatKhauHash = hashMkMoi;

                        MessageBox.Show("Đổi mật khẩu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMatKhauCu.Clear();
                        txtMatKhauMoi.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đổi mật khẩu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // =========================================================================================
        // 4. CÁC NÚT ĐIỀU HƯỚNG
        // =========================================================================================
        private void btnDong_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn đóng form và quay về Trang chủ?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
