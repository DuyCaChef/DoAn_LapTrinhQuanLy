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
using QuanLyPhongMach.Data.Entities;
using Microsoft.EntityFrameworkCore.Update.Internal;
using QuanLyPhongMach.Data;
using System.Drawing.Design;
using System.Text.RegularExpressions;

namespace QuanLyPhongMach.Forms
{
    public partial class FrmAdmin : Form
    {
        public FrmAdmin()
        {
            InitializeComponent();
        }

        //Ma hoa mat khau
        private string HashPassword(string rawPassword)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawPassword));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        //Tai du lieu len datagridview khi vua mo form
        private void FrmAdmin_Load(object sender, EventArgs e)
        {
            //Mac dinh chon vai tro dau tien trong comboBox
            if (cboVaiTro.Items.Count > 0)
                cboVaiTro.SelectedIndex = 0;

            //Đảm bảo mật khẩu luôn ẩn khi bắt đầu
            ckbHienMatKhau.Checked = false;

            LoadDanhSachTaiKhoan();
            //Tải dữ liệu cho tab Quản lý nhân sự
            LoadDataTabNhanSu();
            //Tải danh sách hồ sơ cho dgvHoSo
            LoadDanhSachHoSo();

        }

        private void LoadDanhSachTaiKhoan(string keyword = "")
        {
            try
            {
                using (var db = new PhongMachDbContext())
                {
                    //Tạo câu truy vấn ban đầu (chưa chạy ngay xuống DB)
                    var query = db.TaiKhoans.AsQueryable();

                    // Nếu người dùng có nhập từ khóa -> Thêm lệnh lọc (WHERE)
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        // Dùng Contains để tìm kiếm gần đúng (nhập "abc" ra "abc@gmail.com")
                        query = query.Where(tk => tk.TenDangNhap.Contains(keyword));
                    }

                    //Thực thi truy vấn và đẩy lên DataGridView
                    var dsTaiKhoan = query.Select(tk => new
                    {
                        tk.MaTK,
                        tk.TenDangNhap,
                        tk.VaiTro,
                        TrangThai = tk.TrangThai ? "Đang hoạt động" : "Đã khoá"
                    }).ToList();

                    dgvTaiKhoan.DataSource = dsTaiKhoan;


                    //Đổi tiêu đề cho các cột tự sinh ra
                    if (dgvTaiKhoan.Columns.Count > 0)
                    {
                        dgvTaiKhoan.Columns["MaTK"].HeaderText = "Mã TK";
                        dgvTaiKhoan.Columns["TenDangNhap"].HeaderText = "Username";
                        dgvTaiKhoan.Columns["VaiTro"].HeaderText = "Vai Trò";
                        dgvTaiKhoan.Columns["TrangThai"].HeaderText = "Trạng Thái";

                        //Chỉnh cho cột Username tự động dãn rộng lấp đầy khoảng trống
                        dgvTaiKhoan.Columns["TenDangNhap"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Them moi tai khoan
        private void btnThemTaiKhoan_Click(object sender, EventArgs e)
        {
            string username = txtTenDangNhap.Text.Trim();
            string password = txtMatKhau.Text.Trim();
            string vaiTro = cboVaiTro.SelectedItem?.ToString();
            bool trangThai = ckbTrangThai.Checked;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tên đăng nhập và Mật khẩu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Validate 1: Bắt buộc tài khoản phải có đuôi @gmail.com
            if (!username.EndsWith("@gmail.com"))
            {
                MessageBox.Show("Tên đăng nhập bắt buộc phải có định dạng @gmail.com!\n\nVí dụ: abc@gmail.com", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDangNhap.Focus();
                return;
            }

            try
            {
                using (var db = new PhongMachDbContext())
                {
                    //Kiem tra username da ton tai hay chua
                    bool isExist = db.TaiKhoans.Any(tk => tk.TenDangNhap == username);
                    if (isExist)
                    {
                        MessageBox.Show("Tên đăng nhập này đã tồn tại, vui lòng chọn tên khác", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //Tao tai khoan moi
                    var newAccount = new TaiKhoan
                    {
                        TenDangNhap = username,
                        //Bat buoc bam mat khau truoc khi luu
                        MatKhauHash = HashPassword(password),
                        VaiTro = vaiTro,
                        TrangThai = trangThai
                    };

                    db.TaiKhoans.Add(newAccount);
                    //Luu xuong SQLServer
                    db.SaveChanges();

                    MessageBox.Show("Thêm tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Xoa rong o nhap lieu va tai lai luoi
                    txtTenDangNhap.Clear();
                    txtMatKhau.Clear();
                    LoadDanhSachTaiKhoan();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm tài khoản " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ckbHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbHienMatKhau.Checked)
                txtMatKhau.UseSystemPasswordChar = false;
            else
                txtMatKhau.UseSystemPasswordChar = true;
        }

        //Su kien click vao luoi de hien thi du lieu tren textbox
        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Kiem tra neu dong click vao la hop le
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTaiKhoan.Rows[e.RowIndex];

                //Lay du lieu len cac control
                txtTenDangNhap.Text = row.Cells["TenDangNhap"].Value?.ToString();
                cboVaiTro.SelectedItem = row.Cells["VaiTro"].Value?.ToString();

                //Lay an toan chuoi trag thai, neu NULL thi gan ang chuoi rong ""
                string trangThai = row.Cells["TrangThai"].Value?.ToString() ?? "";
                ckbTrangThai.Checked = (trangThai == "Đang hoạt động");

                //Mat khau da ma hoa nen ta khong the hien thi len, chi de trong cho Admin nhap moi neu muon doi
                txtMatKhau.Clear();
            }

        }

        //Chuc nang sua tai khoan (Sua vai tro, trang thai hoac mat khau)
        private void btnSuaTaiKhoan_Click(object sender, EventArgs e)
        {
            string username = txtTenDangNhap.Text.Trim();

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Vui lòng chọn một tài khoản trong danh sách để sửa !", "Cảnh bảo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new PhongMachDbContext())
                {
                    //Tim tai khoan can sua dua tren username
                    var tkUpdate = db.TaiKhoans.FirstOrDefault(tk => tk.TenDangNhap == username);

                    if (tkUpdate != null)
                    {
                        //Cap nhat thong tin
                        tkUpdate.VaiTro = cboVaiTro.SelectedItem?.ToString();
                        tkUpdate.TrangThai = ckbTrangThai.Checked;

                        //Neu Admin co nhap mat khau moi vao o textbox thi tien hah doi mat khau
                        string newPassword = txtMatKhau.Text.Trim();
                        if (!string.IsNullOrEmpty(newPassword))
                        {
                            tkUpdate.MatKhauHash = HashPassword(newPassword);
                        }

                        db.SaveChanges();
                        MessageBox.Show("Cập nhật thông tin tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadDanhSachTaiKhoan();
                        txtMatKhau.Clear();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //Chuc nang khoa tai khoan (Thay vi xoa han de giu lich su)
        private void btnKhoaTaiKhoan_Click(object sender, EventArgs e)
        {
            string username = txtTenDangNhap.Text.Trim();

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Vui lòng chọn một tài khoản từ danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var db = new PhongMachDbContext())
            {
                var tk = db.TaiKhoans.FirstOrDefault(t => t.TenDangNhap == username);
                if (tk != null)
                {
                    // Kiểm tra trạng thái hiện tại của tài khoản
                    bool isCurrentlyActive = tk.TrangThai;

                    // Nếu đang hoạt động thì tên hành động là KHÓA, ngược lại là MỞ KHÓA
                    string actionName = isCurrentlyActive ? "KHÓA" : "MỞ KHÓA";

                    DialogResult dialogResult = MessageBox.Show($"Bạn có chắc chắn muốn {actionName} tài khoản '{username}' không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.Yes)
                    {
                        // Đảo ngược trạng thái (Đang true thành false, đang false thành true)
                        tk.TrangThai = !isCurrentlyActive;
                        db.SaveChanges();

                        MessageBox.Show($"Đã {actionName.ToLower()} tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Tải lại dữ liệu lên lưới và cập nhật trạng thái CheckBox
                        LoadDanhSachTaiKhoan();
                        ckbTrangThai.Checked = tk.TrangThai;
                    }
                }
            }
        }

        //Chuc nang xoa tai khoan (chi duoc phep su dung khi tao tai khoan nham, chua co du lieu)
        private void btnXoaTaiKhoan_Click(object sender, EventArgs e)
        {
            string username = txtTenDangNhap.Text.Trim();

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Vui lòng chọn một tài khoản từ danh sách để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Canh bao nghiem trong truoc khi xoa cung
            DialogResult dialogResult = MessageBox.Show($"CẢNH BÁO: Bạn có chắc chắn muốn XÓA VĨNH VIỄN tài khoản '{username}' không?\n\nLưu ý: Chỉ có thể xóa những tài khoản chưa từng phát sinh dữ liệu (chưa lập hóa đơn, chưa khám bệnh...).",
                "Xác nhận Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    using (var db = new PhongMachDbContext())
                    {
                        var tkXoa = db.TaiKhoans.FirstOrDefault(tk => tk.TenDangNhap == username);
                        if (tkXoa != null)
                        {
                            db.TaiKhoans.Remove(tkXoa);
                            db.SaveChanges(); //Lenh nay se vang Exception neu tai khoan dinh khoa ngoai

                            MessageBox.Show("Đã xóa tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //Reset lai form
                            LoadDanhSachTaiKhoan();
                            txtTenDangNhap.Clear();
                            txtMatKhau.Clear();
                        }
                    }
                }
                catch (Microsoft.EntityFrameworkCore.DbUpdateException)
                {
                    //Loi DbUpdateException thuong xay ra khi vi pham khoa ngoai 
                    MessageBox.Show("KHÔNG THỂ XÓA!\n\nTài khoản này đã có lịch sử hoạt động trong hệ thống (đã từng đặt lịch, lập phiếu khám hoặc hóa đơn). \n\nĐể bảo toàn tính toàn vẹn của dữ liệu phòng khám, vui lòng sử dụng chức năng KHÓA thay vì Xóa.", "Từ chối Xóa Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    //Cac loi khac
                    MessageBox.Show("Lỗi hệ thống khi xóa tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Chức năng tìm kiếm tài khoản
        private void btnTimKiemTaiKhoan_Click(object sender, EventArgs e)
        {
            // Lấy từ khóa từ ô Textbox (Lưu ý đổi tên txtTimKiem cho khớp giao diện của bạn)
            string keyword = txtTimKiemTaiKhoan.Text.Trim();

            // Gọi lại hàm load danh sách và truyền từ khóa vào
            LoadDanhSachTaiKhoan(keyword);
        }

        //Khi ô tìm kiếm bị xóa rỗng -> Tự động load lại toàn bộS
        private void txtTimKiemTaiKhoan_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTimKiemTaiKhoan.Text.Trim()))
            {
                LoadDanhSachTaiKhoan();
            }
        }

        // =========================================================================
        // ======================== TAB 2: QUẢN LÝ NHÂN SỰ =========================
        // =========================================================================

        //Tai du lieu tai khoan vao combobox tab 2
        private void LoadDataTabNhanSu()
        {
            try
            {
                using (var db = new PhongMachDbContext())
                {
                    //Lay danh sach Tai Khoan (Chi lay BacSi va NhanVien)
                    var dsTaiKhoan = db.TaiKhoans
                         .Where(tk => tk.VaiTro.Contains("BAC") || tk.VaiTro.Contains("Bác") ||
                                      tk.VaiTro.Contains("NHAN") || tk.VaiTro.Contains("Nhân"))
                         .Select(tk => new
                         {
                             tk.MaTK,
                             //Noi chuoi de de nhin. Vi du: Bacsi_hung (BACSI)
                             DisplayInfo = tk.TenDangNhap + " (" + tk.VaiTro + ")"
                         }).ToList();

                    //Do du lieu vao combobox
                    cboLienKetTaiKoan.DataSource = dsTaiKhoan;
                    cboLienKetTaiKoan.DisplayMember = "DisplayInfo"; //Phan chu hien thi cho nguoi dung xem
                    cboLienKetTaiKoan.ValueMember = "MaTK"; //Gia tri ngam ben duoi dung de luu DB
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu Tab Nhân sự: " + ex.Message);
            }
        }

        //Su kien khi admin chon mot tai khoan trong combobox
        private void cboLienKetTaiKoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Neu chon dung dong chu "BACSI" thi cho phep nhap Chuyen Khoa, nguoc lai khoa o do lai
            if (cboLienKetTaiKoan.Text.Contains("BAC") || cboLienKetTaiKoan.Text.Contains("Bác"))
            {
                cboChuyenKhoa.Enabled = true;
            }
            else
            {
                cboChuyenKhoa.Enabled = false;
                cboChuyenKhoa.SelectedIndex = -1;
            }
        }

        //Nut luu thong tin nhan su
        private void btnCapNhatThongTin_Click(object sender, EventArgs e)
        {
            //Kiem tra da chon tai khoan chua
            if (cboLienKetTaiKoan.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn một tài khoản để liên kết!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Lay cac du lieu tren form
            int maTk = (int)cboLienKetTaiKoan.SelectedValue;
            string hoTen = txtHoTen.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string chuyenKhoa = cboChuyenKhoa.Text.Trim();

            if (string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(sdt))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Họ tên và Số điện thoại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Validate 2: Bắt buộc số điện thoại từ 9 đến 10 chữ số
            if (!Regex.IsMatch(sdt, @"^\d{9,10}$"))
            {
                MessageBox.Show("Số điện thoại không hợp lệ!\nVui lòng nhập từ 9 đến 10 chữ số (không chứa chữ cái hay ký tự đặc biệt).", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return;
            }

            try
            {
                using (var db = new PhongMachDbContext())
                {
                    //Lay lai thong tin de kiem tra Vai tro la BACSI hay NHANVIEN
                    var tk = db.TaiKhoans.FirstOrDefault(t => t.MaTK == maTk);
                    if (tk == null || tk.VaiTro == null)
                        return;

                    string vaiTro = tk.VaiTro.ToUpper();

                    if (vaiTro.Contains("BAC") || vaiTro.Contains("BÁC"))
                    {
                        if (string.IsNullOrEmpty(chuyenKhoa))
                        {
                            MessageBox.Show("Vui lòng nhập Chuyên khoa cho Bác sĩ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        //Tim xem BACSI co ho so chua (Dua vao khoa ngoai Matk)
                        var bacSi = db.BacSis.FirstOrDefault(b => b.MaTK == maTk);
                        if (bacSi == null)
                        {
                            //Chua co -> Them moi
                            bacSi = new BacSi
                            {
                                MaTK = maTk,
                                TenBS = hoTen,
                                SoDienThoai = sdt,
                                ChuyenKhoa = chuyenKhoa,
                            };
                            db.BacSis.Add(bacSi);
                        }
                        else
                        {
                            //Da co -> Cap nhat lai thong tin
                            bacSi.TenBS = hoTen;
                            bacSi.SoDienThoai = sdt;
                            bacSi.ChuyenKhoa = chuyenKhoa;
                        }

                        db.SaveChanges();
                        MessageBox.Show($"Đã lưu hồ sơ Bác sĩ: {hoTen}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (vaiTro.Contains("NHAN") || vaiTro.Contains("NHÂN"))
                    {
                        //Tim xem NHANVIEN da co ho so hay chua
                        var nhanVien = db.NhanViens.FirstOrDefault(nv => nv.MaTK == maTk);
                        if (nhanVien == null)
                        {
                            //Chua co -> Them moi
                            nhanVien = new NhanVien
                            {
                                MaTK = maTk,
                                TenNV = hoTen,
                                SoDienThoai = sdt,
                            };
                            db.NhanViens.Add(nhanVien);
                        }
                        else
                        {
                            //Da co -> Cap nhat lai thong tin
                            nhanVien.TenNV = hoTen;
                            nhanVien.SoDienThoai = sdt;
                        }

                        db.SaveChanges(); // Đã mở khóa dòng lưu DB
                        MessageBox.Show($"Đã lưu hồ sơ Nhân viên: {hoTen}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    //Lam sach sau khi luu thanh cong
                    txtHoTen.Clear();
                    txtSDT.Clear();
                    cboChuyenKhoa.SelectedIndex = -1;

                    //Load lai dgvHoSo
                    LoadDanhSachHoSo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu nhân sự: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDanhSachHoSo()
        {
            try
            {
                using (var db = new PhongMachDbContext())
                {
                    //Ép kiểu về class HoSoNhanSuView để ép WinForms vẽ cột ngay cả khi DataBase chưa có ai!

                    //Lấy danh sách Bác sĩ
                    var listBacSi = db.BacSis.Select(b => new HoSoNhanSuView
                    {
                        IdNhanSu = "BS" + b.MaBS,
                        Username = b.TaiKhoan != null ? b.TaiKhoan.TenDangNhap : "N/A",
                        HoTen = b.TenBS,
                        SDT = b.SoDienThoai,
                        ChucDanh = "Bác sĩ - " + b.ChuyenKhoa
                    }).ToList();

                    //Lấy danh sách Nhân viên
                    var listNhanVien = db.NhanViens.Select(nv => new HoSoNhanSuView
                    {
                        IdNhanSu = "NV" + nv.MaNV,
                        Username = nv.TaiKhoan != null ? nv.TaiKhoan.TenDangNhap : "N/A",
                        HoTen = nv.TenNV,
                        SDT = nv.SoDienThoai,
                        ChucDanh = "Nhân viên (Lễ tân)"
                    }).ToList();

                    // Gộp 2 danh sách lại với nhau
                    var allHoSo = listBacSi.Concat(listNhanVien).ToList();

                    //Gán null để ép DataGridView Refresh
                    dgvHoSo.DataSource = null;
                    dgvHoSo.DataSource = allHoSo;

                    //LÀM ĐẸP TIÊU ĐỀ CỘT CHO dgvHoSo
                    if (dgvHoSo.Columns.Count > 0)
                    {
                        dgvHoSo.Columns["IdNhanSu"].HeaderText = "Mã NS";
                        dgvHoSo.Columns["Username"].HeaderText = "Tài Khoản";
                        dgvHoSo.Columns["HoTen"].HeaderText = "Họ và Tên";
                        dgvHoSo.Columns["SDT"].HeaderText = "Số điện thoại";
                        dgvHoSo.Columns["ChucDanh"].HeaderText = "Chức danh / Chuyên khoa";

                        dgvHoSo.Columns["ChucDanh"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách hồ sơ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Class bổ trợ: khắc phục lỗi dgv không tải được dữ liệu
        public class HoSoNhanSuView
        {
            public string IdNhanSu { get; set; }
            public string Username { get; set; }
            public string HoTen { get; set; }
            public string SDT { get; set; }
            public string ChucDanh { get; set; }
        }

        //Click vào lưới dgvHoSo hiển thị dữ liệu lên textbox
        private void dgvHoSo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu click vào dòng hợp lệ
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvHoSo.Rows[e.RowIndex];

                // Bỏ qua nếu click vào dòng trống
                if (row.Cells["Username"].Value == null) return;

                // 1. Lấy dữ liệu từ dòng được click
                string username = row.Cells["Username"].Value.ToString();
                string hoTen = row.Cells["HoTen"].Value?.ToString() ?? "";
                string sdt = row.Cells["SDT"].Value?.ToString() ?? "";
                string chucDanh = row.Cells["ChucDanh"].Value?.ToString() ?? "";

                // 2. Tìm và tự động chọn tài khoản tương ứng trong ComboBox
                // (Vì Item trong ComboBox có dạng "username (VAITRO)" nên ta dùng FindString để tìm đoạn đầu)
                int index = cboLienKetTaiKoan.FindString(username + " (");
                if (index != -1)
                {
                    cboLienKetTaiKoan.SelectedIndex = index;
                }

                // 3. Đổ dữ liệu Họ Tên và SĐT lên Textbox
                txtHoTen.Text = hoTen;
                txtSDT.Text = sdt;

                // 4. Xử lý cắt chuỗi để lấy Chuyên Khoa (nếu là Bác sĩ)
                if (chucDanh.StartsWith("Bác sĩ - "))
                {
                    // Cắt bỏ chữ "Bác sĩ - " để lấy đúng tên chuyên khoa (VD: Tim mạch)
                    cboChuyenKhoa.Text = chucDanh.Replace("Bác sĩ - ", "").Trim();
                    cboChuyenKhoa.Enabled = true;
                }
                else
                {
                    // Nếu là Nhân viên thì xóa trống ô Chuyên khoa
                    cboChuyenKhoa.SelectedIndex = -1;
                    cboChuyenKhoa.Enabled = false;
                }
            }
        }

        //Sự kiện chuyển TAB (refesh lại dữ liệu tức thì khi sang TAB Nhân Sự)
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl tabCtrl = sender as TabControl;

            //TAB Quản lý nhân sự là TAB số 2 (Index = 1 đêm từ 0)
            if (tabCtrl != null && tabCtrl.SelectedIndex == 1)
            {
                // Khi vừa bấm sang Tab Nhân sự, ngay lập tức refesh lại dữ liệu 
                LoadDataTabNhanSu();
                LoadDanhSachHoSo();
            }
        }

        
    }
}


