using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using QuanLyPhongMach.Data;
using QuanLyPhongMach.Data.Entities;
using System.Security.Cryptography;


namespace QuanLyPhongMach.Forms
{
    public partial class FrmDangKi : Form
    {
        public FrmDangKi()
        {
            InitializeComponent();
        }

        private void FrmDangKi_Load(object sender, EventArgs e)
        {
            //Đảm bảo mật khẩu luôn ẩn khi bắt đầu
            ckbHienMatKhau.Checked = false;

            // Giới hạn ngày sinh lớn nhất có thể chọn chính là ngày hôm nay
            dtpNgaySinh.MaxDate = DateTime.Now;
        }

        //Hàm mã hoá mật khẩu 
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

        //Sự kiện bấm nút đăng kí
        private void btnDangKi_Click(object sender, EventArgs e)
        {
            //Lấy dữ liệu từ giao diện
            string username = txtTenDangNhap.Text.Trim();
            string password = txtMatKhau.Text.Trim();
            string confirmPassword = txtXacNhanMatKhau.Text.Trim();

            string hoTen = txtHoTen.Text.Trim();
            DateTime ngaySinh = dtpNgaySinh.Value;
            string gioiTinh = rdoNam.Checked ? "Nam" : "Nữ";
            string sdt = txtSoDienThoai.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();

            //Kiểm tra dữ liệu đầu vào
            //Kiểm tra rỗng các trường bắt buộc
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword) || string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(sdt))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ các thông tin bắt buộc (*).Bao gồm: \n Tên đăng nhập \n Mật khẩu \n Xác nhận mật khẩu \n Số điện thoại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Kiểm tra mật khẩu khớp nhau
            if (password != confirmPassword)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp! Vui lòng kiểm tra lại.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtXacNhanMatKhau.Focus();
                return;
            }

            //Kiểm tra địng dạng email
            if (!username.EndsWith("@gmail.com"))
            {
                MessageBox.Show("Tên đăng nhập bắt buộc phải có đuôi @gmail.com!\n\nVí dụ: abc@gmail.com", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDangNhap.Focus();
                return;
            }

            //Kiểm tra định dạng số điện thoại
            if (!Regex.IsMatch(sdt, @"^\d{9,10}$"))
            {
                MessageBox.Show("Số điện thoại không hợp lệ!\nVui lòng nhập từ 9 đến 10 chữ số.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDienThoai.Focus();
                return;
            }

            //lưu vào DB với Transaction (đảm bảo toàn vẹn dữ liệu)
            try
            {
                using (var db = new PhongMachDbContext())
                {
                    //Kiểm tra username đã tồn tại hay chưa
                    if (db.TaiKhoans.Any(tk => tk.TenDangNhap == username))
                    {
                        MessageBox.Show("Tên đăng nhập này đã được sử dụng. Vui lòng chọn tên khác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtTenDangNhap.Focus();
                        return;
                    }

                    //Mở Transaction (Giao dịch): Bắt buộc lưu thành công cả 2 bảng mới được tính
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            //Thao tác 1: Lưu tài khoản (vỏ đăng nhập)
                            var newAccount = new TaiKhoan
                            {
                                TenDangNhap = username,
                                MatKhauHash = HashPassword(password),
                                VaiTro = "KHACHHANG", //cứng quyền khách hàng
                                TrangThai = true,
                                NgayTao = DateTime.Now
                            };
                            db.TaiKhoans.Add(newAccount);
                            db.SaveChanges(); // Lưu lần một để hệ thống sinh ra MaTK

                            //Thao tác 2: Lưu hồ sơ khách hàng

                            var newKhachHang = new KhachHang
                            {
                                MaTK = newAccount.MaTK, // Lấy ID vừa được tạo ghép vào khóa ngoại
                                TenKH = hoTen,
                                NgaySinh = ngaySinh,
                                GioiTinh = gioiTinh,
                                SoDienThoai = sdt,
                                DiaChi = diaChi
                            };
                            db.khachHangs.Add(newKhachHang);
                            db.SaveChanges(); // Lưu lần 2

                            //HOÀN TẤT GIAO DỊCH
                            transaction.Commit();

                            MessageBox.Show("Đăng ký thành công! Bạn có thể dùng tài khoản này để đăng nhập ngay bây giờ.", "Chúc mừng", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Đóng form đăng ký, mở lại form Đăng nhập
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            // Nếu Lỗi ở bất kỳ khâu nào (Lưu TaiKhoan hoặc KhachHang) -> Hủy bỏ toàn bộ
                            transaction.Rollback();
                            MessageBox.Show("Có lỗi xảy ra trong quá trình lưu dữ liệu: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể kết nối CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ckbHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbHienMatKhau.Checked)
            {
                txtMatKhau.UseSystemPasswordChar = false;
                txtXacNhanMatKhau.UseSystemPasswordChar = false;
            }
            else
            {
                txtMatKhau.UseSystemPasswordChar = true;
                txtXacNhanMatKhau.UseSystemPasswordChar = true;
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            //Quay lại trang đăng nhập 
            this.Close();
        }

       
    }
}
