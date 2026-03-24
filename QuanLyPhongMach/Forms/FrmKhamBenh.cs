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

namespace QuanLyPhongMach.Forms
{
    public partial class FrmKhamBenh : Form
    {
        //Biến lưu tài khoản Bác Sĩ
        private TaiKhoan _taiKhoanBS;
        private int _maBacSi = 0;
        private int _maLichKhamHienTai = 0;

        // Các biến lưu trạng thái gốc của Phiếu khám để so sánh thay đổi (dùng để xác nhận đóng form)
        private string _originalTrieuChung = "";
        private string _originalChanDoan = "";
        private string _originalLoiDan = "";

        public FrmKhamBenh()
        {
            InitializeComponent();
        }

        //Hàm đón dữ liệu từ FrmTrangChu truyền sang để biết BacSi nào đang khám 
        public FrmKhamBenh(TaiKhoan tk)
        {
            InitializeComponent();
            _taiKhoanBS = tk; // Lưu lại tài khoản bác sĩ đang đăng nhập
        }

        private void FrmKhamBenh_Load(object sender, EventArgs e)
        {
            //Mắc định label thông tin bệnh nhân rỗng
            lblDangKhamBenhNhan.Text = "Đang khám: Chưa chọn Bệnh Nhân nào...";

            //Đặt ngày khám mặc định là hôm nay
            dtpNgayKham.Value = DateTime.Now;

            try
            {
                using (var db = new PhongMachDbContext())
                {
                    //Lấy thông tin BacSi dựa vào Mã Tài Khoản
                    var bacSi = db.BacSis.FirstOrDefault(b => b.MaTK == _taiKhoanBS.MaTK);
                    if (bacSi != null)
                    {
                        _maBacSi = bacSi.MaBS;
                        lblBacSiPhuTrach.Text = $"Bác Sĩ phụ trách: BS. {bacSi.TenBS}";
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản này chưa được liên kết với Hồ sơ Bác sĩ nào!\nVui lòng liên hệ Admin để cấu hình trong tab Nhân Sự.", "Lỗi Phân Quyền", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                        return;
                    }
                }

                //Tải danh sách Bệnh Nhân chờ khám
                LoadDanhSachCho();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi tạo Form: " + ex.Message);
            }
        }

        //Tải danh sách Bệnh Nhân chờ khám
        private void LoadDanhSachCho()
        {
            if (_maBacSi == 0)
                return;

            try
            {
                using (var db = new PhongMachDbContext())
                {
                    DateTime ngayChon = dtpNgayKham.Value.Date;

                    // Chỉ lấy lịch khám của Bác sĩ này và đúng ngày được chọn trên DateTimePicker
                    var danhSach = db.LichKhams
                        .Where(lk => lk.MaBS == _maBacSi && lk.NgayKham.Date == ngayChon)
                        .Select(lk => new
                        {
                            MaLich = lk.MaLichKham, //Ẩn cột này đi, chỉ dùng để lấy ID ngầm
                            TenBenhNhan = lk.KhachHang.TenKH,
                            GioKham = lk.GioKham,
                            TrangThai = lk.TrangThai,
                        })
                        .OrderBy(lk => lk.GioKham) //Sắp xếp theo theo giờ từ sáng tới chiều
                        .ToList();

                    // Đổ dữ liệu lên lưới
                    dgvDanhSachCho.DataSource = danhSach;

                    // Định dạng cột
                    if (dgvDanhSachCho.Columns.Count > 0)
                    {
                        dgvDanhSachCho.Columns["MaLich"].Visible = false; // Ẩn cột ID
                        dgvDanhSachCho.Columns["TenBenhNhan"].HeaderText = "Tên Bệnh Nhân";
                        dgvDanhSachCho.Columns["GioKham"].HeaderText = "Giờ Khám";
                        dgvDanhSachCho.Columns["TrangThai"].HeaderText = "Trạng Thái";

                        dgvDanhSachCho.Columns["TenBenhNhan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách chờ: " + ex.Message);
            }
        }

        // Sự kiện: Khi Bác sĩ đổi ngày trên DateTimePicker thì load lại danh sách chờ theo ngày đó
        private void dtpNgayKham_ValueChanged(object sender, EventArgs e)
        {
            LoadDanhSachCho();
            ResetFormKham(); //Xoá rỗng màn hình khám bên phải
        }

        //Sự liện click chọn Bệnh Nhân để khám
        private void dgvDanhSachCho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == 0)
            {
                DataGridViewRow row = dgvDanhSachCho.Rows[e.RowIndex];
                if (row.Cells["MaLich"].Value != null)
                {
                    _maLichKhamHienTai = Convert.ToInt32(row.Cells["MaLich"].Value);
                }

                try
                {
                    using (var db = new PhongMachDbContext())
                    {
                        // Lấy thông tin chi tiết Khách hàng
                        var lk = db.LichKhams.Include(l => l.KhachHang).FirstOrDefault(l => l.MaLichKham == _maLichKhamHienTai);
                        if (lk != null)
                        {
                            // Tính tuổi (nếu Ngày Sinh có giá trị)
                            int tuoi = 0;
                            if (lk.KhachHang.NgaySinh.HasValue)
                                tuoi = DateTime.Now.Year - lk.KhachHang.NgaySinh.Value.Year;

                            // Hiển thị dải băng xanh thông tin Bệnh Nhân đang khám
                            lblDangKhamBenhNhan.Text = $"Đang khám: {lk.KhachHang.TenKH} - {lk.KhachHang.GioiTinh} - {tuoi} tuổi - SĐT: {lk.KhachHang.SoDienThoai}";

                            //Tải Bệnh Án cũ lên (nếu Bệnh Nhân này đã từng được lưu nhưng Bác Sĩ muốn chỉnh sửa)
                            var phieuKham = db.PhieuKhams.FirstOrDefault(pk => pk.MaLichKham == _maLichKhamHienTai);
                            if (phieuKham != null)
                            {
                                txtTrieuChung.Text = phieuKham.TrieuChung;
                                txtChanDoan.Text = phieuKham.ChanDoan;
                                txtLoiDan.Text = phieuKham.LoiDan;
                            }
                            else
                            {
                                // Bệnh nhân mới chưa có phiếu khám, xóa trắng form nhập
                                txtTrieuChung.Clear();
                                txtChanDoan.Clear();
                                txtLoiDan.Clear();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi lấy thông tin bệnh án: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Lưu Bệnh Án (hoàn thành khám) 
        private void btnHoanThanh_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã click chọn bệnh nhân bên lưới chưa
            if (_maLichKhamHienTai == 0)
            {
                MessageBox.Show("Vui lòng chọn một bệnh nhân từ danh sách chờ để khám!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string trieuChung = txtTrieuChung.Text.Trim();
            string chanDoan = txtChanDoan.Text.Trim();
            string loiDan = txtLoiDan.Text.Trim();

            //Kiểm tra nhập liệu tối thiểu
            if (string.IsNullOrEmpty(trieuChung) || string.IsNullOrEmpty(chanDoan))
            {
                MessageBox.Show("Vui lòng mô tả đầy đủ Triệu chứng và Chẩn đoán!", "Cảnh báo thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new PhongMachDbContext())
                {
                    //Lưu thông tin Khám Bệnh vào Bảng Phiếu Khám
                    var phieuKham = db.PhieuKhams.FirstOrDefault(pk => pk.MaLichKham == _maLichKhamHienTai);
                    if (phieuKham == null)
                    {
                        //Tạo phiếu khám mới
                        phieuKham = new PhieuKham
                        {
                            MaLichKham = _maLichKhamHienTai,
                            TrieuChung = trieuChung,
                            ChanDoan = chanDoan,
                            LoiDan = loiDan,
                            NgayLap = DateTime.Now
                        };
                        db.PhieuKhams.Add(phieuKham);
                    }
                    else
                    {
                        //Cập nhật phiếu khám cũ (Nếu Bác sĩ bấm vào người đã khám để sửa lại lời dặn)
                        phieuKham.TrieuChung = trieuChung;
                        phieuKham.ChanDoan = chanDoan;
                        phieuKham.LoiDan = loiDan;
                    }

                    //Cập nhật trạn thái lịch khám thành "Đã khám"
                    var lichKham = db.LichKhams.FirstOrDefault(lk => lk.MaLichKham == _maLichKhamHienTai);
                    if (lichKham != null)
                        lichKham.TrangThai = "Đã khám";

                    //Lưu toàn bộ xuống DB
                    db.SaveChanges();
                    MessageBox.Show("Đã lưu Phiếu khám và hoàn tất quá trình khám bệnh!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Làm mới giao diện
                    LoadDanhSachCho();
                    ResetFormKham();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu bệnh án: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Nút huỷ khám
        private void btnHuyKham_Click(object sender, EventArgs e)
        {
            // Nếu chưa chọn bệnh nhân nào thì không cần hỏi, cứ việc làm sạch form
            if (_maLichKhamHienTai == 0)
            {
                ResetFormKham();
                return;
            }

            // Bật thông báo xác nhận nếu đang khám dở dang
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn hủy phiên khám này không?\nCác thông tin vừa nhập sẽ không được lưu lại.", "Xác nhận Hủy Khám", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                ResetFormKham();
            }
        }

        //Hàm hỗ trợ dọn dẹp các textBox
        private void ResetFormKham()
        {
            _maLichKhamHienTai = 0;
            lblDangKhamBenhNhan.Text = "Chưa chọn bệnh nhân nào...";
            txtTrieuChung.Clear();
            txtChanDoan.Clear();
            txtLoiDan.Clear();
        }

        //Hàm kiểm tra có thay đổi nào chưa được lưu hay không
        private bool HasUnsavedChanges()
        {
            if (_maLichKhamHienTai == 0) return false; // Không chọn bệnh nhân thì không có gì để lưu

            // Nếu dữ liệu trên TextBox hiện tại khác với dữ liệu gốc lúc mới click chọn -> Có thay đổi
            if (txtTrieuChung.Text.Trim() != _originalTrieuChung ||
                txtChanDoan.Text.Trim() != _originalChanDoan ||
                txtLoiDan.Text.Trim() != _originalLoiDan)
            {
                return true;
            }

            return false;
        }

        //Nút đóng form, quay về trang chủ
        private void btnDong_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem có dữ liệu nào đang nhập dở mà chưa Lưu không
            if (HasUnsavedChanges())
            {
                // Nếu có thay đổi chưa lưu, bật cảnh báo OK / Cancel
                DialogResult unsavedResult = MessageBox.Show(
                    "Bạn có các thay đổi chưa được lưu trên phiếu khám này.\nBạn có chắc chắn muốn đóng form và HỦY BỎ các thay đổi này không?",
                    "Cảnh báo dữ liệu chưa lưu",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);

                if (unsavedResult == DialogResult.Cancel)
                {
                    return; // Hủy lệnh đóng, giữ Bác sĩ ở lại form
                }
            }
            else
            {
                // 2. Nếu không có thay đổi gì, hiện thông báo xác nhận đóng bình thường (Yes / No)
                DialogResult normalResult = MessageBox.Show(
                    "Bạn có chắc chắn muốn đóng form và quay về Trang chủ không?",
                    "Xác nhận đóng Form",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (normalResult == DialogResult.No)
                {
                    return; // Hủy lệnh đóng, giữ Bác sĩ ở lại form
                }
            }

            // 3. Nếu qua được các xác nhận trên -> Đóng form (Trở về frmMain)
            this.Close();
        }
    }
}
