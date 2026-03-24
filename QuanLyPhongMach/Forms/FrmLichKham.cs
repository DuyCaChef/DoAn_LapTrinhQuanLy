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
using System.Text.RegularExpressions;


namespace QuanLyPhongMach.Forms
{
    public partial class FrmLichKham : Form
    {

        //Biến lưu mã khách hàng hiện tại đang thao tác
        private int maKhachHangHienTai = 0;
        private int maLichKhamHienTai = 0;

        //Các biến lưu trạng thái gốc để kiểm tra thay đổi chưa lưu khi Cập Nhật (dùng để kiểm tra dữ liệu thay đổi trước khi đóng form)
        private string _originalHoTen = "";
        private string _originalSDT = "";
        private string _originalDiaChi = "";
        private string _originalGioiTinh = "Nam";
        private DateTime _originalNgaySinh;
        private DateTime _originalNgayKham;
        private string _originalChuyenKhoa = "";
        private int _originalMaBS = 0;
        private int _originalIndexGioKham = -1;

        public FrmLichKham()
        {
            InitializeComponent();
        }

        private void FrmLichKham_Load(object sender, EventArgs e)
        {
            //Thiết lập combobox giờ khám
            LoadDanhSachGioKham();

            //Thiết lập combobox Chuyên Khoa
            if (cboChuyenKhoa.Items.Count == 0)
            {
                cboChuyenKhoa.Items.AddRange(new string[] {
                "Nội khoa", "Ngoại khoa", "Nhi khoa", "Sản - Phụ khoa", "Tai - Mũi - Họng"
                });

            }

            //Mặc định chọn Nam, ngày sinh lớn nhất là hôm nay
            rdbNam.Checked = true;
            dtbNgaySinh.MaxDate = DateTime.Now;
            //Đặt lịch khám từ hôm nay trở đi
            dtbNgayKham.MinDate = DateTime.Now.AddDays(-1);

            //Load danh sách lên DataView
            LoadDanhSachLichKham();
        }

        private void LoadDanhSachGioKham()
        {
            cboGioKham.Items.Clear();
            cboGioKham.Items.AddRange(new string[] {
                "08:00 - 08:30", "08:30 - 09:00", "09:00 - 09:30", "09:30 - 10:00",
                "10:00 - 10:30", "10:30 - 11:00", "13:30 - 14:00", "14:00 - 14:30",
                "14:30 - 15:00", "15:00 - 15:30", "15:30 - 16:00", "16:00 - 16:30"
            });
        }

        //ComboBox Chuyên Khoa phụ thuộc
        private void cboChuyenKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboChuyenKhoa.SelectedItem == null)
                return;
            string chuyenKhoa = cboChuyenKhoa.SelectedItem.ToString();

            try
            {
                using (var db = new PhongMachDbContext())
                {
                    //Tìm Bác sĩ thuộc chuyên khoa được chọn
                    var danhSachBS = db.BacSis
                        .Where(bs => bs.ChuyenKhoa == chuyenKhoa)
                        .Select(bs => new { bs.MaBS, bs.TenBS })
                        .ToList();

                    cboBacSi.DataSource = null;
                    cboBacSi.DataSource = danhSachBS;
                    cboBacSi.DisplayMember = "TenBS"; //Tên hiển thị
                    cboBacSi.ValueMember = "MaBS"; //Giá trị ngầm (ID) lưu xuống DB
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách Bác sĩ: " + ex.Message);
            }
        }

        //Tự động điền Bệnh Nhân (Khi gõ xong SĐT và nhấn Enter)
        private void txtSDT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string sdt = txtSDT.Text.Trim();
                if (string.IsNullOrEmpty(sdt))
                    return;

                //Kiểm tra validate số điện thoại
                if (!Regex.IsMatch(sdt, @"^\d{9,10}$"))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ!\nVui lòng nhập từ 9 đến 10 chữ số (không chứa chữ cái).", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    using (var db = new PhongMachDbContext())
                    {
                        var kh = db.khachHangs.FirstOrDefault(k => k.SoDienThoai == sdt);
                        if (kh != null)
                        {
                            // Tìm thấy -> Auto Fill
                            txtHoTen.Text = kh.TenKH;
                            txtDiaChi.Text = kh.DiaChi;
                            dtbNgaySinh.Value = kh.NgaySinh ?? DateTime.Now;

                            if (kh.GioiTinh == "Nam")
                                rdbNam.Checked = true;
                            else
                                rdbNu.Checked = true;

                            maKhachHangHienTai = kh.MaKH; //Lưu lại ID
                            MessageBox.Show($"Đã tìm thấy bệnh nhân cũ: {kh.TenKH}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            // Không tìm thấy -> Cho phép tạo mới
                            maKhachHangHienTai = 0;
                            MessageBox.Show("Không tìm thấy bệnh nhân với SĐT này.\nVui lòng nhập thông tin để Lưu Mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtHoTen.Focus();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
                }
            }
        }

        //Lưu thông tin Bệnh Nhân nhanh tại quầy
        private void btnLuuBenhNhan_Click(object sender, EventArgs e)
        {
            string hoTen = txtHoTen.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            string gioiTinh = rdbNam.Checked ? "Nam" : "Nữ";
            DateTime ngaySinh = dtbNgaySinh.Value;

            if (string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(sdt))
            {
                MessageBox.Show("Vui lòng nhập Họ Tên và Số Điện Thoại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Kiểm tra validate số điện thoại trước khi lưu
            if (!Regex.IsMatch(sdt, @"^\d{9,10}$"))
            {
                MessageBox.Show("Số điện thoại không hợp lệ!\nVui lòng nhập từ 9 đến 10 chữ số (không chứa chữ cái).", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return;
            }

            //Bắt lỗi Ngày Sinh: Không được lớn hơn ngày hiện tại (Tương lai)
            if (ngaySinh.Date > DateTime.Now.Date)
            {
                MessageBox.Show("Ngày sinh không hợp lệ!\nKhông thể chọn ngày sinh ở tương lai.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtbNgaySinh.Focus();
                return;
            }

            try
            {
                using (var db = new PhongMachDbContext())
                {
                    // Lễ tân tự thêm BN -> Tạo 1 Tài Khoản ẩn (Mật khẩu mặc định là SĐT) cho BN đó
                    var taiKhoanTonTai = db.TaiKhoans.FirstOrDefault(tk => tk.TenDangNhap == sdt);
                    int maTaiKhoan = 0;

                    if (taiKhoanTonTai == null)
                    {
                        var tkMoi = new TaiKhoan
                        {
                            TenDangNhap = sdt,
                            MatKhauHash = sdt,
                            VaiTro = "KHACHHANG",
                            TrangThai = true
                        };
                        db.TaiKhoans.Add(tkMoi);
                        db.SaveChanges();
                        maTaiKhoan = tkMoi.MaTK;
                    }
                    else
                    {
                        maTaiKhoan = taiKhoanTonTai.MaTK;
                    }

                    //Lưu hồ sơ Khách Hàng
                    if (maKhachHangHienTai == 0) //Tạo mới
                    {
                        var khMoi = new KhachHang
                        {
                            MaTK = maTaiKhoan,
                            TenKH = hoTen,
                            SoDienThoai = sdt,
                            DiaChi = diaChi,
                            GioiTinh = gioiTinh,
                            NgaySinh = ngaySinh,
                        };
                        db.khachHangs.Add(khMoi);
                        db.SaveChanges();
                        maKhachHangHienTai = khMoi.MaKH; //Lưu ID hiện tại dùng để đặt lịch
                        MessageBox.Show("Đã lưu mới Bệnh Nhân thành công!", "Thông báo");
                    }
                    else //Cập nhật Bệnh Nhân cũ
                    {
                        var khCu = db.khachHangs.Find(maKhachHangHienTai);
                        if (khCu != null)
                        {
                            khCu.TenKH = hoTen;
                            khCu.DiaChi = diaChi;
                            khCu.GioiTinh = gioiTinh;
                            khCu.NgaySinh = ngaySinh;
                            db.SaveChanges();
                            MessageBox.Show("Cập nhật thông tin Bệnh Nhân thành công!", "Thông báo");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu bệnh nhân: " + ex.Message);
            }
        }

        //Đặt lịch khám (thêm mới lịch)
        private void btnDatLich_Click(object sender, EventArgs e)
        {
            if (maKhachHangHienTai == 0)
            {
                MessageBox.Show("Vui lòng chọn hoặc lưu Bệnh Nhân trước khi Đặt lịch!", "Cảnh báo");
                return;
            }

            //Chọn đầy đủ thông tin lịch khám
            if (cboChuyenKhoa.SelectedIndex == -1 || cboBacSi.SelectedValue == null || cboGioKham.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin Lịch Khám:\n- Chuyên khoa\n- Bác sĩ\n- Ngày khám\n- Giờ khám", "Thông tin thiếu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Bắt lỗi Ngày Khám không được nhỏ hơn ngày hôm nay
            if (dtbNgayKham.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Ngày khám không hợp lệ!\nKhông thể đặt lịch cho một ngày trong quá khứ.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtbNgayKham.Focus();
                return;
            }


            try
            {
                // XỬ LÝ ÉP KIỂU TIMESPAN
                string chuoiGio = cboGioKham.SelectedItem.ToString(); // VD: "08:00 - 08:30"
                string gioBatDau = chuoiGio.Split('-')[0].Trim();     // Lấy "08:00"
                TimeSpan gioKhamTimeSpan = TimeSpan.Parse(gioBatDau); // Ép kiểu

                using (var db = new PhongMachDbContext())
                {
                    var lichKhamMoi = new LichKham
                    {
                        MaKH = maKhachHangHienTai,
                        MaBS = (int)cboBacSi.SelectedValue,
                        NgayKham = dtbNgayKham.Value.Date,
                        GioKham = gioKhamTimeSpan,
                        TrangThai = "Chờ khám"
                    };

                    db.LichKhams.Add(lichKhamMoi);
                    db.SaveChanges();

                    MessageBox.Show("Đặt lịch khám thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachLichKham();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đặt lịch: " + ex.Message);
            }
        }

        //Cập nhật thông tin
        private void btnSuaLich_Click(object sender, EventArgs e)
        {
            // 1. Bắt lỗi: Chưa chọn Lịch khám từ lưới
            if (maLichKhamHienTai == 0 || maKhachHangHienTai == 0)
            {
                MessageBox.Show("Vui lòng click chọn một Lịch khám dưới danh sách để Cập nhật (Sửa)!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Lấy dữ liệu từ giao diện
            string hoTen = txtHoTen.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            string gioiTinh = rdbNam.Checked ? "Nam" : "Nữ";
            DateTime ngaySinh = dtbNgaySinh.Value;

            // 3. Bắt lỗi Validate (Trống dữ liệu và format SĐT)
            if (string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(sdt))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Họ Tên và Số Điện Thoại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(sdt, @"^\d{9,10}$"))
            {
                MessageBox.Show("Số điện thoại không hợp lệ!\nVui lòng nhập từ 9 đến 10 chữ số (không chứa chữ cái).", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return;
            }

            if (cboChuyenKhoa.SelectedIndex == -1 || cboBacSi.SelectedValue == null || cboGioKham.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin Lịch Khám:\n- Chuyên khoa\n- Bác sĩ\n- Ngày khám\n- Giờ khám", "Thông tin thiếu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Bắt lỗi Ngày Sinh và Ngày Khám khi Cập nhật
            if (ngaySinh.Date > DateTime.Now.Date)
            {
                MessageBox.Show("Ngày sinh không hợp lệ!\nKhông thể đổi ngày sinh sang tương lai.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtbNgaySinh.Focus();
                return;
            }

            if (dtbNgayKham.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Ngày khám không hợp lệ!\nKhông thể dời lịch khám về một ngày trong quá khứ.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtbNgayKham.Focus();
                return;
            }

            // 4. Xử lý lưu CSDL
            try
            {
                string chuoiGio = cboGioKham.SelectedItem.ToString();
                string gioBatDau = chuoiGio.Split('-')[0].Trim();
                TimeSpan gioKhamTimeSpan = TimeSpan.Parse(gioBatDau);

                using (var db = new PhongMachDbContext())
                {
                    // 4.1 Cập nhật bảng Khách Hàng
                    var khUpdate = db.khachHangs.Find(maKhachHangHienTai);
                    if (khUpdate != null)
                    {
                        khUpdate.TenKH = hoTen;
                        khUpdate.SoDienThoai = sdt;
                        khUpdate.DiaChi = diaChi;
                        khUpdate.GioiTinh = gioiTinh;
                        khUpdate.NgaySinh = ngaySinh;
                    }

                    // 4.2 Cập nhật bảng Lịch Khám
                    var lkUpdate = db.LichKhams.FirstOrDefault(lk => lk.MaLichKham == maLichKhamHienTai);
                    if (lkUpdate != null)
                    {
                        lkUpdate.MaBS = (int)cboBacSi.SelectedValue;
                        lkUpdate.NgayKham = dtbNgayKham.Value.Date;
                        lkUpdate.GioKham = gioKhamTimeSpan;
                        // Ghi chú: Trạng thái khám giữ nguyên, Lễ tân thường chỉ sửa thời gian/bác sĩ
                    }

                    db.SaveChanges();

                    MessageBox.Show("Cập nhật thông tin Lịch khám thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Tải lại lưới và làm mới form
                    LoadDanhSachLichKham();
                    btnLamMoi_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi cập nhật lịch: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //Sự liện click vào lưới để chọn lịch cần huỷ
        private void dgvLichKham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem user có click đúng vào dòng chứa dữ liệu không
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLichKham.Rows[e.RowIndex];

                if (row.Cells["MaLich"].Value != null)
                {
                    // Lấy ID Lịch khám và lưu vào biến toàn cục
                    maLichKhamHienTai = Convert.ToInt32(row.Cells["MaLich"].Value);

                    try
                    {
                        using (var db = new PhongMachDbContext())
                        {
                            // Truy vấn toàn bộ thông tin Bệnh Nhân và Lịch Khám dựa vào MaLichKham
                            var chiTiet = db.LichKhams
                                .Where(lk => lk.MaLichKham == maLichKhamHienTai)
                                .Select(lk => new
                                {
                                    MaKH = lk.MaKH,
                                    TenKH = lk.KhachHang.TenKH,
                                    SDT = lk.KhachHang.SoDienThoai,
                                    DiaChi = lk.KhachHang.DiaChi,
                                    NgaySinh = lk.KhachHang.NgaySinh,
                                    GioiTinh = lk.KhachHang.GioiTinh,
                                    NgayKham = lk.NgayKham,
                                    GioKham = lk.GioKham,
                                    ChuyenKhoa = lk.BacSi.ChuyenKhoa,
                                    MaBS = lk.MaBS
                                }).FirstOrDefault();

                            if (chiTiet != null)
                            {
                                // --- 1. ĐỔ DỮ LIỆU BỆNH NHÂN LÊN TEXTBOX ---
                                maKhachHangHienTai = chiTiet.MaKH;
                                txtHoTen.Text = chiTiet.TenKH;
                                txtSDT.Text = chiTiet.SDT;
                                txtDiaChi.Text = chiTiet.DiaChi;

                                DateTime ns = chiTiet.NgaySinh ?? DateTime.Now;
                                if (ns > dtbNgaySinh.MaxDate) dtbNgaySinh.MaxDate = ns; // Tránh lỗi vượt rào
                                dtbNgaySinh.Value = ns;

                                if (chiTiet.GioiTinh == "Nam") rdbNam.Checked = true;
                                else rdbNu.Checked = true;


                                // --- 2. ĐỔ DỮ LIỆU LỊCH KHÁM ---
                                // Tránh lỗi vượt quá MinDate nếu click vào xem lịch hẹn ở quá khứ
                                if (chiTiet.NgayKham < dtbNgayKham.MinDate)
                                {
                                    dtbNgayKham.MinDate = chiTiet.NgayKham;
                                }
                                dtbNgayKham.Value = chiTiet.NgayKham;

                                // Chọn Chuyên khoa trước để CBO Bác sĩ tự động lấy danh sách theo khoa
                                cboChuyenKhoa.SelectedItem = chiTiet.ChuyenKhoa;

                                // Sau đó gán chọn đúng Bác sĩ
                                cboBacSi.SelectedValue = chiTiet.MaBS;

                                // Xử lý Giờ khám (từ TimeSpan "08:00:00" -> chọn dòng "08:00 - 08:30" trong combobox)
                                string gioKhamStr = chiTiet.GioKham.ToString(@"hh\:mm");
                                int indexGio = -1;
                                for (int i = 0; i < cboGioKham.Items.Count; i++)
                                {
                                    if (cboGioKham.Items[i].ToString().StartsWith(gioKhamStr))
                                    {
                                        indexGio = i;
                                        break;
                                    }
                                }
                                cboGioKham.SelectedIndex = indexGio;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi tải thông tin chi tiết: " + ex.Message);
                    }
                }
            }
        }

        //Huỷ lịch Khám 
        private void btnXoaLich_Click(object sender, EventArgs e)
        {
            //Kiểm tra xem đã click chọn lịch nào phía dưới chưa
            if (maLichKhamHienTai == 0 && dgvLichKham.CurrentRow != null && dgvLichKham.CurrentRow.Index >= 0)
            {
                if (dgvLichKham.CurrentRow.Cells["MaLich"].Value != null)
                {
                    maLichKhamHienTai = Convert.ToInt32(dgvLichKham.CurrentRow.Cells["MaLich"].Value);
                    txtHoTen.Text = dgvLichKham.CurrentRow.Cells["TenBenhNhan"].Value?.ToString() ?? "";
                }
            }

            //Bật thông báo hỏi để xác nhận
            string tenBN = txtHoTen.Text.Trim();
            DialogResult dialogResult = MessageBox.Show($"Bạn có chắc chắn muốn HỦY (Xóa) lịch khám của bệnh nhân '{tenBN}' không?", "Xác nhận Hủy Lịch", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    using (var db = new PhongMachDbContext())
                    {
                        // Tìm lịch khám dựa theo ID
                        var lichKhamCanHuy = db.LichKhams.FirstOrDefault(lk => lk.MaLichKham == maLichKhamHienTai);

                        if (lichKhamCanHuy != null)
                        {
                            //Thực hiện xoá dòng dữ liệu khỏi bảng LICHKHAM
                            db.LichKhams.Remove(lichKhamCanHuy);
                            db.SaveChanges();

                            MessageBox.Show("Đã hủy (xóa) lịch khám thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Tải lại lưới và làm mới (reset) các ô nhập liệu
                            LoadDanhSachLichKham();
                            btnLamMoi_Click(sender, e);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra khi hủy lịch: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Tải danh sách lịch khám lên Grid
        private void LoadDanhSachLichKham(string keyword = "")
        {
            try
            {
                using (var db = new PhongMachDbContext())
                {
                    var query = db.LichKhams.AsQueryable();

                    //Mặc định chỉ load lịch từ hôm nay trở về sau 
                    DateTime today = DateTime.Today;
                    query = query.Where(lk => lk.NgayKham >= today);

                    if (!string.IsNullOrEmpty(keyword))
                    {
                        query = query.Where(lk => lk.KhachHang.TenKH.Contains(keyword) || lk.KhachHang.SoDienThoai.Contains(keyword));
                    }

                    //Kết bảng lấy tên BN và tên BS
                    var danhSach = query.Select(lk => new
                    {
                        MaLich = lk.MaLichKham,
                        TenBenhNhan = lk.KhachHang.TenKH,
                        SDT = lk.KhachHang.SoDienThoai,
                        BacSi = lk.BacSi.TenBS,
                        NgayKham = lk.NgayKham,
                        GioKham = lk.GioKham,
                        TrangThai = lk.TrangThai
                    }).OrderBy(lk => lk.NgayKham).ThenBy(lk => lk.GioKham).ToList();

                    dgvLichKham.DataSource = danhSach;

                    //Định dạng tiêu đề cột
                    if (dgvLichKham.Columns.Count > 0)
                    {
                        dgvLichKham.Columns["NgayKham"].DefaultCellStyle.Format = "dd/MM/yyyy";
                        dgvLichKham.Columns["TenBenhNhan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chưa tải được danh sách do lỗi: " + ex.Message);
            }
        }

        //Lọc nhanh trên TextBox
        private void txtTimKiemLich_TextChanged(object sender, EventArgs e)
        {
            LoadDanhSachLichKham(txtTimKiemLich.Text.Trim());
        }

        //Nút làm mới và đóng form
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtHoTen.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            maKhachHangHienTai = 0;
            maLichKhamHienTai = 0; // Đặt lại ID lịch khám = 0 để tránh bấm nhầm nút Xóa

            //Lấy thời gian hiện tại lưu vào biến để tránh bị lệch mili-giây
            DateTime thoiGianHienTai = DateTime.Now;

            dtbNgaySinh.MaxDate = thoiGianHienTai;
            dtbNgaySinh.Value = thoiGianHienTai;

            dtbNgayKham.MinDate = thoiGianHienTai.AddDays(-1);
            dtbNgayKham.Value = thoiGianHienTai;

            cboChuyenKhoa.SelectedIndex = -1;
            cboBacSi.DataSource = null;
            cboGioKham.SelectedIndex = -1;
            txtSDT.Focus();
        }

        //Hàm kiểm tra thay đổi chưa lưu
        private bool HasUnsavedChanges()
        {
            string currentHoTen = txtHoTen.Text.Trim();
            string currentSDT = txtSDT.Text.Trim();

            // Trường hợp 1: Đang Tạo Mới (Chưa click chọn lịch nào dưới lưới)
            if (maLichKhamHienTai == 0)
            {
                // Chỉ cần người dùng lỡ gõ Tên hoặc SĐT mà chưa bấm nút Đặt Lịch/Lưu thì cảnh báo
                if (!string.IsNullOrEmpty(currentHoTen) || !string.IsNullOrEmpty(currentSDT))
                {
                    return true;
                }
            }
            // Trường hợp 2: Đang Cập Nhật/Sửa (Đã click chọn 1 lịch dưới lưới)
            else
            {
                string currentDiaChi = txtDiaChi.Text.Trim();
                string currentGioiTinh = rdbNam.Checked ? "Nam" : "Nữ";
                string currentChuyenKhoa = cboChuyenKhoa.SelectedItem?.ToString() ?? "";
                int currentMaBS = cboBacSi.SelectedValue != null ? (int)cboBacSi.SelectedValue : 0;

                // So sánh tất cả các ô hiện tại với giá trị gốc ban đầu
                if (currentHoTen != _originalHoTen ||
                    currentSDT != _originalSDT ||
                    currentDiaChi != _originalDiaChi ||
                    currentGioiTinh != _originalGioiTinh ||
                    dtbNgaySinh.Value.Date != _originalNgaySinh ||
                    dtbNgayKham.Value.Date != _originalNgayKham ||
                    currentChuyenKhoa != _originalChuyenKhoa ||
                    currentMaBS != _originalMaBS ||
                    cboGioKham.SelectedIndex != _originalIndexGioKham)
                {
                    return true;
                }
            }

            return false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem có dữ liệu nào đang nhập dở mà chưa Lưu/Đặt lịch không
            if (HasUnsavedChanges())
            {
                // Nếu có thay đổi chưa lưu, bật cảnh báo OK / Cancel
                DialogResult unsavedResult = MessageBox.Show(
                    "Bạn đang có các thông tin hoặc lịch khám chưa được lưu lại.\nBạn có chắc chắn muốn đóng form và HỦY BỎ các thay đổi này không?",
                    "Cảnh báo dữ liệu chưa lưu",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);

                if (unsavedResult == DialogResult.Cancel)
                {
                    return; // Hủy lệnh đóng, giữ Lễ tân ở lại form
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
                    return; // Hủy lệnh đóng, giữ Lễ tân ở lại form
                }
            }

            // 3. Nếu qua được các xác nhận trên -> Đóng form (Trở về frmMain)
            this.Close();
        }
    }
}
