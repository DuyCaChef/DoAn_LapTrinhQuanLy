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

namespace QuanLyPhongMach.Forms
{
    public partial class FrmTrangChu : Form
    {

        //Bien toan cuc luu nguoi dung dang dang nhap
        private TaiKhoan currentUser;



        public FrmTrangChu()
        {
            InitializeComponent();
        }

        public FrmTrangChu(TaiKhoan userLogined)
        {
            InitializeComponent();
            //Luu lai thong tin nguoi dung duoc truyen sang
            this.currentUser = userLogined;
        }

        private void FrmTrangChu_Load(object sender, EventArgs e)
        {
            lblCurrentUser.Text = $"Xin chào: {currentUser.TenDangNhap} | Server: SQL 2019";

            PhanQuyen();
        }

        //Ham phan quyen
        private void PhanQuyen()
        {
            // 1.Đã vào được Main thì ẩn nút Đăng Nhập, hiện Đăng Xuất/Thoát
            if (mnuDangNhap != null) mnuDangNhap.Visible = false;
            if (mnuDangXuat != null) mnuDangXuat.Visible = true;
            if (mnuThoat != null) mnuThoat.Visible = true;

            // 2.PHÂN QUYỀN THEO VAI TRÒ
            // Kiểm tra an toàn phòng trường hợp biến rỗng
            if (currentUser == null || string.IsNullOrEmpty(currentUser.VaiTro))
                return;

            string vaiTro = currentUser.VaiTro.Trim().ToUpper();

            // Đổi thành Contains("ADMIN") cho đồng bộ và chống lỗi khoảng trắng ngầm
            if (vaiTro.Contains("ADMIN"))
            {
                mnuQuanLyBacSi.Visible = true;
                mnuQuanLyNhanVien.Visible = true;
                mnuQuanLyKhachHang.Visible = true;

                mnuTiepNhan.Visible = true;
                mnuKhamBenh.Visible = true;
                mnuThanhToan.Visible = true;
                mnuThongTinKhachHang.Visible = true;

                mnuAdmin.Visible = true;

                // Mở Menu cha
                mnuQuanLy.Visible = true;

                //Menu Thuốc & Dịch vụ
                if (mnuQuanLyThuoc != null) mnuQuanLyThuoc.Visible = true;
                if (mnuQuanLyDichVu != null) mnuQuanLyDichVu.Visible = true;

                //Các nút icon to
                tsbTiepNhan.Visible = true;
                tsbDatLich.Visible = true;
                tsbKhamBenh.Visible = true;
                tsbThanhToan.Visible = true;

                // Toolstrip Thuốc & Dịch vụ
                if (tsbThuoc != null) tsbThuoc.Visible = true;
                if (tsbDichVu != null) tsbDichVu.Visible = true;
            }
            else if (vaiTro.Contains("BAC") || vaiTro.Contains("BÁC"))
            {
                mnuQuanLyBacSi.Visible = false;
                mnuQuanLyNhanVien.Visible = false;
                mnuQuanLyKhachHang.Visible = false;

                mnuKhamBenh.Visible = true;
                mnuTiepNhan.Visible = false;
                mnuThanhToan.Visible = false;
                mnuThongTinKhachHang.Visible = false;

                mnuAdmin.Visible = false;

                //Ẩn Menu cha Quản lý vì Bác sĩ không xài gì trong này
                mnuQuanLy.Visible = false;

                //Menu Thuốc & Dịch vụ (Bác sĩ được quyền truy cập)
                if (mnuQuanLyThuoc != null) mnuQuanLyThuoc.Visible = true;
                if (mnuQuanLyDichVu != null) mnuQuanLyDichVu.Visible = true;

                //Các nút icon to
                tsbTiepNhan.Visible = false;
                tsbDatLich.Visible = false;
                tsbKhamBenh.Visible = true;
                tsbThanhToan.Visible = false;

                //Toolstrip Thuốc & Dịch vụ
                if (tsbThuoc != null) tsbThuoc.Visible = true;
                if (tsbDichVu != null) tsbDichVu.Visible = true;
            }
            else if (vaiTro.Contains("NHAN") || vaiTro.Contains("NHÂN"))
            {
                mnuQuanLyBacSi.Visible = false;
                mnuQuanLyNhanVien.Visible = false;
                mnuQuanLyKhachHang.Visible = false;

                mnuKhamBenh.Visible = false;
                mnuTiepNhan.Visible = true;
                mnuThanhToan.Visible = true;
                mnuThongTinKhachHang.Visible = false;

                mnuAdmin.Visible = false;

                // Ẩn Menu cha Quản lý
                mnuQuanLy.Visible = false;

                //Menu Thuốc & Dịch vụ (Lễ tân được quyền truy cập)
                if (mnuQuanLyThuoc != null) mnuQuanLyThuoc.Visible = true;
                if (mnuQuanLyDichVu != null) mnuQuanLyDichVu.Visible = true;

                //Các nút icon to
                tsbTiepNhan.Visible = true;
                tsbDatLich.Visible = false;
                tsbKhamBenh.Visible = false;
                tsbThanhToan.Visible = true;

                //Toolstrip Thuốc & Dịch vụ
                if (tsbThuoc != null) tsbThuoc.Visible = true;
                if (tsbDichVu != null) tsbDichVu.Visible = true;
            }
            else if (vaiTro.Contains("KHACH") || vaiTro.Contains("KHÁCH"))
            {
                mnuQuanLyBacSi.Visible = false;
                mnuQuanLyNhanVien.Visible = false;
                mnuQuanLyKhachHang.Visible = false;

                mnuKhamBenh.Visible = false;
                mnuTiepNhan.Visible = false;
                mnuThanhToan.Visible = false;
                mnuThongTinKhachHang.Visible = true;

                mnuAdmin.Visible = false;

                // Ẩn Menu cha Quản lý
                mnuQuanLy.Visible = false;

                //Menu Thuốc & Dịch vụ (Khách hàng KHÔNG được truy cập)
                if (mnuQuanLyThuoc != null) mnuQuanLyThuoc.Visible = false;
                if (mnuQuanLyDichVu != null) mnuQuanLyDichVu.Visible = false;

                //Các nút icon to
                tsbTiepNhan.Visible = false;
                tsbDatLich.Visible = true;
                tsbKhamBenh.Visible = false;
                tsbThanhToan.Visible = false;

                //Toolstrip Thuốc & Dịch vụ
                if (tsbThuoc != null) tsbThuoc.Visible = false;
                if (tsbDichVu != null) tsbDichVu.Visible = false;
            }
        }

        //Sự kiện Đăng Xuất
        private void DangXuat()
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất khỏi hệ thống?", "Xác nhận Đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Mở lại màn hình Đăng nhập
                FrmDangNhap frmDangNhap = new FrmDangNhap();
                frmDangNhap.Show();

                // Gỡ sự kiện FormClosed để tránh gọi lệnh Application.Exit() làm tắt toàn bộ chương trình
                this.FormClosed -= FrmTrangChu_FormClosed;

                // Đóng màn hình Main hiện tại
                this.Close();
            }
        }
        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            DangXuat();
        }

        private void tsbDangXuat_Click(object sender, EventArgs e)
        {
            DangXuat();
        }


        private void FrmTrangChu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        /// CÁC SỰ KIỆN MỞ FORM (CHUYỂN HƯỚNG)///
        // Sự kiện mở FrmKhamBenh (dành cho Bác Sĩ)
        private void MoFormKhamBenh()
        {
            // Truyền currentUser (Tài khoản đang đăng nhập) sang FrmKhamBenh
            QuanLyPhongMach.Forms.FrmKhamBenh frmKhamBenh = new QuanLyPhongMach.Forms.FrmKhamBenh(this.currentUser);
            frmKhamBenh.ShowDialog();
        }
        private void mnuKhamBenh_Click(object sender, EventArgs e)
        {
            MoFormKhamBenh();
        }

        private void tsbKhamBenh_Click(object sender, EventArgs e)
        {
            MoFormKhamBenh();
        }

        // Sự kiện mở FrmLichKham (dành cho nhân viên lễ tân)
        private void MoFormLichKham()
        {
            //Mở form bình thường vì FrmLichKham không yêu cầu tham số truyền vào
            QuanLyPhongMach.Forms.FrmLichKham frmLichKham = new QuanLyPhongMach.Forms.FrmLichKham();
            frmLichKham.ShowDialog();
        }
        private void mnuTiepNhan_Click(object sender, EventArgs e)
        {
            MoFormLichKham();
        }
        private void tsbTiepNhan_Click(object sender, EventArgs e)
        {
            MoFormLichKham();
        }


        //Sự kiện mở FrmThuoc và FrmDichVu (BacSi va NhanVien)
        private void MoFormThuoc()
        {
            QuanLyPhongMach.Forms.FrmQuanLyThuoc frmThuoc = new QuanLyPhongMach.Forms.FrmQuanLyThuoc();
            frmThuoc.ShowDialog();
        }
        private void tsbThuoc_Click(object sender, EventArgs e)
        {
            MoFormThuoc();
        }

        private void MoFormDichVu()
        {
            QuanLyPhongMach.Forms.FrmDichVu frmDichVu = new QuanLyPhongMach.Forms.FrmDichVu();
            frmDichVu.ShowDialog();
        }
        private void tsbDichVu_Click(object sender, EventArgs e)
        {
            MoFormDichVu();
        }

        //Sự kiện mở FrmThuNgan (quyền NhanVien và Admin)
        private void MoFromThuNgan()
        {
            QuanLyPhongMach.Forms.FrmThuNgan frmThuNgan = new QuanLyPhongMach.Forms.FrmThuNgan();
            frmThuNgan.ShowDialog();
        }
        private void mnuThanhToan_Click(object sender, EventArgs e)
        {
            MoFromThuNgan();
        }

        private void tsbThanhToan_Click(object sender, EventArgs e)
        {
            MoFromThuNgan();
        }


        private void MoFromKhachHang()
        {
            QuanLyPhongMach.Forms.FrmKhachHang frmKhachHang = new QuanLyPhongMach.Forms.FrmKhachHang(this.currentUser);
            frmKhachHang.ShowDialog();
        }
        private void mnuThongTinKhachHang_Click(object sender, EventArgs e)
        {
            MoFromKhachHang();
        }

        private void tsbDatLich_Click(object sender, EventArgs e)
        {
            MoFromKhachHang();
        }
    }
}
