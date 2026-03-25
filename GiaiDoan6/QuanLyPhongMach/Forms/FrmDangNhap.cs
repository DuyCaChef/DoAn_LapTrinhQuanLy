using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyPhongMach.Data;
using QuanLyPhongMach.Data.Entities;
using System.Security.Cryptography; //thu vien dung de ma hoa mat khau
using System.Linq;

namespace QuanLyPhongMach.Forms
{
    public partial class FrmDangNhap : Form
    {
        public FrmDangNhap()
        {
            InitializeComponent();
        }

        private void FrmDangNhap_Load(object sender, EventArgs e)
        {
            //Đảm bảo mật khẩu luôn ẩn khi bắt đầu
            ckbHienMatKhau.Checked = false;
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

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtTenDangNhap.Text.Trim();
            string rawPassword = txtMatKhau.Text.Trim();

            //Kiem tra nhap lieu trong
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(rawPassword))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin Tài khoản và Mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDangNhap.Focus();
                return;
            }
            //Tai khoan ADMIN co dinh
            if (username == "admin@gmail.com" && rawPassword == "admin@123")
            {
                TaiKhoan adminUser = new TaiKhoan
                {
                    TenDangNhap = "admin@gmail.com",
                    VaiTro = "ADMIN",
                    TrangThai = true
                };

                MessageBox.Show("Đăng nhập thành công với quyền Quản Trị Viên (Admin)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                FrmTrangChu mainForAdmin = new FrmTrangChu(adminUser);
                mainForAdmin.Show();
                this.Hide();
                return; //Thoat ham o day, khong chay xuong check db nữa
            }

            //Bam mat khau nguoi dung vua nhap
            string hashedPassord = HashPassword(rawPassword);

            try
            {
                //Ket noi DB bang EF Core
                using (var db = new PhongMachDbContext())
                {
                    //Tim tai khoan khop userName va password da bam
                    var user = db.TaiKhoans.FirstOrDefault(tk => tk.TenDangNhap == username && tk.MatKhauHash == hashedPassord);
                    if (user != null)
                    {
                        //Kiem tra trang thai tai khoan 
                        if (user.TrangThai == false)
                        {
                            MessageBox.Show("Tài khoản đã bị khóa. Vui lòng liên hệ Quản Trị Viên!", "Tài khoản bị khoá", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        //Dang nhap thanh cong
                        //Khoi tao FrmTrangChu va truyen doi tuong user de phan quyen
                        FrmTrangChu frmTrangChu = new FrmTrangChu(user);
                        frmTrangChu.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác!", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtMatKhau.Clear();
                        txtMatKhau.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                //Bat loi neu SQLServer chua bat hoac cau hinh chuoi ket noi sai
                MessageBox.Show("Lỗi kết nối Cơ sở dữ liệu:\n" + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangNhap_Click(sender, e);
                //Ngan tieng "beep" mac dinh cua Windows khi an Enter
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void ckbHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbHienMatKhau.Checked)
                txtMatKhau.UseSystemPasswordChar = false;
            else
                txtMatKhau.UseSystemPasswordChar = true;
        }

        private void FrmDangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void lblDangKiTaiKhoan_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmDangKi frmDangKi = new FrmDangKi();
            frmDangKi.ShowDialog(); // Mở hộp thoại Đăng ký lên
        }
    }
}
