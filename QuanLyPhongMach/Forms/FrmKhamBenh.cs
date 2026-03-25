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

        //Cờ theo dõi sự thay đổi trên lưới Thuốc và Dịch vụ
        private bool _isGridChanged = false;

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
                    // Kiểm tra xem có phải Admin đang đăng nhập không
                    if (_taiKhoanBS != null && !string.IsNullOrEmpty(_taiKhoanBS.VaiTro) && _taiKhoanBS.VaiTro.ToUpper().Contains("ADMIN"))
                    {
                        // Nếu là Admin -> Cho phép truy cập chế độ "Giám sát"
                        _maBacSi = 0; // Đặt bằng 0 làm dấu hiệu là Admin
                        lblBacSiPhuTrach.Text = "Bác Sĩ phụ trách: Quản Trị Viên (Chế độ giám sát)";
                    }
                    else
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
                }

                //Khởi tạo các Grid và ComboBox trước khi tải danh sách
                SetupGrids();
                LoadComboBoxes();

                //Tải danh sách Bệnh Nhân chờ khám
                LoadDanhSachCho();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi tạo Form: " + ex.Message);
            }
        }

        //Thiết lập thuộc tính cho DataGridView Thuốc và Dịch vụ
        private void SetupGrids()
        {
            dgvChiDinhDichVu.AllowUserToAddRows = false;
            dgvKeDonThuoc.AllowUserToAddRows = false;

            // Thêm các cột ẩn chứa ID để sau này lưu vào CSDL
            if (!dgvChiDinhDichVu.Columns.Contains("MaDV"))
                dgvChiDinhDichVu.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaDV", Visible = false });

            if (!dgvKeDonThuoc.Columns.Contains("MaThuoc"))
                dgvKeDonThuoc.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaThuoc", Visible = false });
        }

        //Tải dữ liệu lên ComboBox Thuốc và Dịch vụ
        private void LoadComboBoxes()
        {
            try
            {
                using (var db = new PhongMachDbContext())
                {
                    cboChiDinhDichVu.DataSource = db.DichVus.ToList();
                    cboChiDinhDichVu.DisplayMember = "TenDichVu";
                    cboChiDinhDichVu.ValueMember = "MaDV";
                    cboChiDinhDichVu.SelectedIndex = -1;

                    cboKeDonThuoc.DataSource = db.Thuocs.ToList();
                    cboKeDonThuoc.DisplayMember = "TenThuoc";
                    cboKeDonThuoc.ValueMember = "MaThuoc";
                    cboKeDonThuoc.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục Thuốc/Dịch vụ: " + ex.Message);
            }
        }

        //Tải danh sách Bệnh Nhân chờ khám
        private void LoadDanhSachCho()
        {
            try
            {
                using (var db = new PhongMachDbContext())
                {
                    DateTime ngayChon = dtpNgayKham.Value.Date;

                    // Khởi tạo câu truy vấn: Lọc theo ngày được chọn và trạng thái "Chờ khám"
                    var query = db.LichKhams.Where(lk => lk.NgayKham.Date == ngayChon && lk.TrangThai == "Chờ khám");

                    // Nếu là Bác sĩ thật (_maBacSi > 0) thì mới lọc bệnh nhân của riêng Bác sĩ đó.
                    // Nếu là Admin (_maBacSi == 0) thì bỏ qua lệnh này để Admin thấy TẤT CẢ.
                    if (_maBacSi > 0)
                    {
                        query = query.Where(lk => lk.MaBS == _maBacSi);
                    }

                    // Tiến hành Select và đổ dữ liệu
                    var danhSach = query
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
            if (e.RowIndex >= 0)
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
                        // Thêm lệnh .Include(l => l.KhachHang) để nạp kèm Hồ sơ Bệnh nhân
                        var lk = db.LichKhams
                                   .Include(l => l.KhachHang)
                                   .FirstOrDefault(l => l.MaLichKham == _maLichKhamHienTai);

                        if (lk != null)
                        {
                            // Tính tuổi (nếu Ngày Sinh có giá trị)
                            int tuoi = 0;
                            if (lk.KhachHang.NgaySinh.HasValue)
                            {
                                tuoi = DateTime.Now.Year - lk.KhachHang.NgaySinh.Value.Year;
                            }

                            // Hiển thị dải băng xanh thông tin
                            lblDangKhamBenhNhan.Text = $"Đang khám: {lk.KhachHang.TenKH} - {lk.KhachHang.GioiTinh} - {tuoi} Tuổi - SĐT: {lk.KhachHang.SoDienThoai}";

                            // [XÓA SẠCH GRID CŨ MỖI LẦN CLICK BỆNH NHÂN MỚI]
                            dgvChiDinhDichVu.Rows.Clear();
                            dgvKeDonThuoc.Rows.Clear();

                            // TẢI BỆNH ÁN CŨ LÊN (NẾU BỆNH NHÂN NÀY ĐÃ TỪNG ĐƯỢC LƯU NHƯNG BÁC SĨ MUỐN CHỈNH SỬA)
                            var phieuKham = db.PhieuKhams.FirstOrDefault(pk => pk.MaLichKham == _maLichKhamHienTai);
                            if (phieuKham != null)
                            {
                                txtTrieuChung.Text = phieuKham.TrieuChung;
                                txtChanDoan.Text = phieuKham.ChanDoan;
                                txtLoiDan.Text = phieuKham.LoiDan;

                                // [THÊM MỚI] Tải danh sách Dịch Vụ đã chỉ định
                                var chiTietDV = db.Set<ChiTietDichVu>().Include(c => c.DichVu).Where(c => c.MaPK == phieuKham.MaPK).ToList();
                                foreach (var cd in chiTietDV)
                                {
                                    int idx = dgvChiDinhDichVu.Rows.Add();
                                    dgvChiDinhDichVu.Rows[idx].Cells["MaDV"].Value = cd.MaDV;
                                    dgvChiDinhDichVu.Rows[idx].Cells["TenDichVu"].Value = cd.DichVu.TenDichVu;
                                    dgvChiDinhDichVu.Rows[idx].Cells["DonGia"].Value = cd.DichVu.DonGia;
                                }

                                // [THÊM MỚI] Tải danh sách Thuốc đã kê
                                var chiTietThuoc = db.Set<ChiTietDonThuoc>().Include(c => c.Thuoc).Where(c => c.MaPK == phieuKham.MaPK).ToList();
                                foreach (var ct in chiTietThuoc)
                                {
                                    int idx = dgvKeDonThuoc.Rows.Add();
                                    dgvKeDonThuoc.Rows[idx].Cells["MaThuoc"].Value = ct.MaThuoc;
                                    dgvKeDonThuoc.Rows[idx].Cells["TenThuoc"].Value = ct.Thuoc.TenThuoc;
                                    dgvKeDonThuoc.Rows[idx].Cells["DonViTinh"].Value = ct.Thuoc.DonViTinh;
                                    dgvKeDonThuoc.Rows[idx].Cells["SoLuong"].Value = ct.SoLuong;

                                    // Tương thích với việc bạn đặt tên cột là DonGia hoặc DonGiaThuoc
                                    if (dgvKeDonThuoc.Columns.Contains("DonGiaThuoc"))
                                        dgvKeDonThuoc.Rows[idx].Cells["DonGiaThuoc"].Value = ct.Thuoc.DonGia;
                                    else if (dgvKeDonThuoc.Columns.Contains("DonGia"))
                                        dgvKeDonThuoc.Rows[idx].Cells["DonGia"].Value = ct.Thuoc.DonGia;
                                }
                            }
                            else
                            {
                                // Bệnh nhân mới chưa có phiếu khám, xóa trắng form nhập
                                txtTrieuChung.Clear();
                                txtChanDoan.Clear();
                                txtLoiDan.Clear();
                            }

                            // Lưu lại trạng thái dữ liệu gốc ngay sau khi tải lên Form
                            _originalTrieuChung = txtTrieuChung.Text.Trim();
                            _originalChanDoan = txtChanDoan.Text.Trim();
                            _originalLoiDan = txtLoiDan.Text.Trim();

                            // [ĐÃ SỬA LỖI ĐỂ TRÁNH CẢNH BÁO GIẢ] Đặt lại cờ lưới khi vừa load xong bệnh án
                            _isGridChanged = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi lấy thông tin bệnh án: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // =========================================================================
        //  CÁC SỰ KIỆN NÚT THÊM / XÓA TRÊN LƯỚI
        // =========================================================================
        private void btnThemDichVu_Click(object sender, EventArgs e)
        {
            if (cboChiDinhDichVu.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn một Dịch vụ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dv = (DichVu)cboChiDinhDichVu.SelectedItem;

            // Kiểm tra xem dịch vụ này đã có trong lưới chưa
            foreach (DataGridViewRow row in dgvChiDinhDichVu.Rows)
            {
                if (row.Cells["MaDV"].Value != null && (int)row.Cells["MaDV"].Value == dv.MaDV)
                {
                    MessageBox.Show("Dịch vụ này đã được thêm rồi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            // Thêm vào lưới
            int idx = dgvChiDinhDichVu.Rows.Add();
            dgvChiDinhDichVu.Rows[idx].Cells["MaDV"].Value = dv.MaDV;
            dgvChiDinhDichVu.Rows[idx].Cells["TenDichVu"].Value = dv.TenDichVu;
            dgvChiDinhDichVu.Rows[idx].Cells["DonGia"].Value = dv.DonGia;

            _isGridChanged = true;
        }

        private void btnBoDichVu_Click(object sender, EventArgs e)
        {
            if (dgvChiDinhDichVu.CurrentRow != null && !dgvChiDinhDichVu.CurrentRow.IsNewRow)
            {
                dgvChiDinhDichVu.Rows.Remove(dgvChiDinhDichVu.CurrentRow);
                _isGridChanged = true;
            }
        }

        private void btnThemThuoc_Click(object sender, EventArgs e)
        {
            if (cboKeDonThuoc.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn một loại Thuốc!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtSoLuong.Text.Trim(), out int sl) || sl <= 0)
            {
                MessageBox.Show("Vui lòng nhập số lượng hợp lệ (lớn hơn 0)!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuong.Focus();
                return;
            }

            var thuoc = (Thuoc)cboKeDonThuoc.SelectedItem;

            // Kiểm tra nếu thuốc đã có thì cộng dồn số lượng
            foreach (DataGridViewRow row in dgvKeDonThuoc.Rows)
            {
                if (row.Cells["MaThuoc"].Value != null && (int)row.Cells["MaThuoc"].Value == thuoc.MaThuoc)
                {
                    int slCu = Convert.ToInt32(row.Cells["SoLuong"].Value);
                    row.Cells["SoLuong"].Value = slCu + sl;
                    txtSoLuong.Clear();
                    return;
                }
            }

            // Thêm mới vào lưới
            int idx = dgvKeDonThuoc.Rows.Add();
            dgvKeDonThuoc.Rows[idx].Cells["MaThuoc"].Value = thuoc.MaThuoc;
            dgvKeDonThuoc.Rows[idx].Cells["TenThuoc"].Value = thuoc.TenThuoc;
            dgvKeDonThuoc.Rows[idx].Cells["DonViTinh"].Value = thuoc.DonViTinh;
            dgvKeDonThuoc.Rows[idx].Cells["SoLuong"].Value = sl;

            if (dgvKeDonThuoc.Columns.Contains("DonGiaThuoc"))
                dgvKeDonThuoc.Rows[idx].Cells["DonGiaThuoc"].Value = thuoc.DonGia;
            else if (dgvKeDonThuoc.Columns.Contains("DonGia"))
                dgvKeDonThuoc.Rows[idx].Cells["DonGia"].Value = thuoc.DonGia;

            txtSoLuong.Clear();
            _isGridChanged = true;
        }

        private void btnBoThuoc_Click(object sender, EventArgs e)
        {
            if (dgvKeDonThuoc.CurrentRow != null && !dgvKeDonThuoc.CurrentRow.IsNewRow)
            {
                dgvKeDonThuoc.Rows.Remove(dgvKeDonThuoc.CurrentRow);
                _isGridChanged = true;
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

            // =========================================================================
            // VALIDATE 1: Bắt buộc nhập đủ Triệu chứng, Chẩn đoán, Lời dặn
            // =========================================================================
            if (string.IsNullOrEmpty(trieuChung) || string.IsNullOrEmpty(chanDoan) || string.IsNullOrEmpty(loiDan))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Triệu chứng lâm sàng, Chẩn đoán và Lời dặn của Bác sĩ!", "Cảnh báo thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // =========================================================================
            // VALIDATE 2: Bắt buộc chỉ định Dịch vụ (Lưới dgvChiDinhDichVu không được trống)
            // =========================================================================
            if (dgvChiDinhDichVu.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng chỉ định ít nhất 1 Dịch vụ (Cận lâm sàng) cho bệnh nhân!", "Cảnh báo thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // =========================================================================
            // VALIDATE 3: Bắt buộc Kê đơn Thuốc (Lưới dgvKeDonThuoc không được trống)
            // =========================================================================
            if (dgvKeDonThuoc.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng kê ít nhất 1 loại Thuốc cho bệnh nhân!", "Cảnh báo thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new PhongMachDbContext())
                {
                    // [BỌC TRONG TRANSACTION ĐỂ ĐẢM BẢO LƯU ĐỒNG THỜI PHIẾU KHÁM, THUỐC VÀ DỊCH VỤ]
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            // 1. Lưu thông tin Khám Bệnh vào Bảng Phiếu Khám
                            var phieuKham = db.PhieuKhams.FirstOrDefault(pk => pk.MaLichKham == _maLichKhamHienTai);
                            if (phieuKham == null)
                            {
                                phieuKham = new PhieuKham
                                {
                                    MaLichKham = _maLichKhamHienTai,
                                    TrieuChung = trieuChung,
                                    ChanDoan = chanDoan,
                                    LoiDan = loiDan,
                                    NgayLap = DateTime.Now
                                };
                                db.PhieuKhams.Add(phieuKham);
                                db.SaveChanges(); // Lấy ID Phiếu khám
                            }
                            else
                            {
                                phieuKham.TrieuChung = trieuChung;
                                phieuKham.ChanDoan = chanDoan;
                                phieuKham.LoiDan = loiDan;
                                db.SaveChanges();
                            }

                            // 2. Cập nhật Dịch vụ (Xóa cũ, Thêm mới từ Lưới)
                            var oldDichVus = db.Set<ChiTietDichVu>().Where(c => c.MaPK == phieuKham.MaPK);
                            db.Set<ChiTietDichVu>().RemoveRange(oldDichVus);

                            foreach (DataGridViewRow row in dgvChiDinhDichVu.Rows)
                            {
                                if (row.Cells["MaDV"].Value != null)
                                {
                                    var ct = new ChiTietDichVu
                                    {
                                        MaPK = phieuKham.MaPK,
                                        MaDV = (int)row.Cells["MaDV"].Value,
                                        SoLuong = 1
                                    };
                                    db.Set<ChiTietDichVu>().Add(ct);
                                }
                            }

                            // 3. Cập nhật Thuốc (Xóa cũ, Thêm mới từ Lưới)
                            var oldThuocs = db.Set<ChiTietDonThuoc>().Where(c => c.MaPK == phieuKham.MaPK);
                            db.Set<ChiTietDonThuoc>().RemoveRange(oldThuocs);

                            foreach (DataGridViewRow row in dgvKeDonThuoc.Rows)
                            {
                                if (row.Cells["MaThuoc"].Value != null)
                                {
                                    var ct = new ChiTietDonThuoc
                                    {
                                        MaPK = phieuKham.MaPK,
                                        MaThuoc = (int)row.Cells["MaThuoc"].Value,
                                        SoLuong = Convert.ToInt32(row.Cells["SoLuong"].Value),
                                        CachDung = "" // Bỏ trống do giao diện không còn cột này
                                    };
                                    db.Set<ChiTietDonThuoc>().Add(ct);
                                }
                            }

                            // 4. Cập nhật trạng thái lịch khám
                            var lichKham = db.LichKhams.FirstOrDefault(lk => lk.MaLichKham == _maLichKhamHienTai);
                            if (lichKham != null)
                                lichKham.TrangThai = "Đã khám";

                            // Lưu và Commit
                            db.SaveChanges();
                            transaction.Commit();

                            MessageBox.Show("Đã lưu Phiếu khám, Chỉ định Dịch vụ và Đơn thuốc thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Làm mới giao diện
                            LoadDanhSachCho();
                            ResetFormKham();
                        }
                        catch (Exception exTransaction)
                        {
                            transaction.Rollback();
                            throw exTransaction; // Đẩy ra catch bên ngoài
                        }
                    }
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
            lblDangKhamBenhNhan.Text = "Đang khám: Chưa chọn Bệnh Nhân nào...";
            txtTrieuChung.Clear();
            txtChanDoan.Clear();
            txtLoiDan.Clear();

            //Làm sạch lưới Dịch Vụ và Thuốc
            dgvChiDinhDichVu.Rows.Clear();
            dgvKeDonThuoc.Rows.Clear();
            cboChiDinhDichVu.SelectedIndex = -1;
            cboKeDonThuoc.SelectedIndex = -1;
            txtSoLuong.Clear();

            // Cần phải xóa cả các biến lưu trạng thái gốc, 
            // nếu không hệ thống sẽ lầm tưởng bạn vẫn đang nhập dở dữ liệu cũ
            _originalTrieuChung = "";
            _originalChanDoan = "";
            _originalLoiDan = "";

            //Đặt lại cờ lưới
            _isGridChanged = false;
        }

        //Hàm kiểm tra có thay đổi nào chưa được lưu hay không
        private bool HasUnsavedChanges()
        {
            if (_maLichKhamHienTai == 0) return false; // Không chọn bệnh nhân thì không có gì để lưu

            // 1. Kiểm tra lưới có bị thêm/xóa gì không
            if (_isGridChanged)
                return true;

            // 2. Nếu lưới không đổi, kiểm tra dữ liệu trên TextBox hiện tại có khác với dữ liệu gốc không
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
