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
    public partial class FrmQuanLyThuoc : Form
    {
        //Biến lưu mã thuốc đang được chọn trên lưới
        private int _maThuocHienTai = 0;

        // Biến lưu tài khoản đang mở form
        private TaiKhoan _taiKhoanDangNhap;

        public FrmQuanLyThuoc(TaiKhoan tk)
        {
            InitializeComponent();
            _taiKhoanDangNhap = tk; // Lưu lại
        }

        private void FrmQuanLyThuoc_Load(object sender, EventArgs e)
        {
            if (cboDonViTinh != null && cboDonViTinh.Items.Count > 0)
            {
                cboDonViTinh.SelectedIndex = 0;
            }

            // ========================================================
            // PHÂN QUYỀN GIAO DIỆN: KHOÁ CHỨC NĂNG VỚI NON-ADMIN
            // ========================================================
            if (_taiKhoanDangNhap != null && _taiKhoanDangNhap.VaiTro != "ADMIN")
            {
                // Ẩn (hoặc làm mờ) các nút thao tác
                btnThemThuoc.Enabled = false;
                btnSuaThuoc.Enabled = false;
                btnXoaThuoc.Enabled = false;
            }

                LoadDanhSachThuoc();
        }

        //Tải danh sách thuốc lên datagridview
        private void LoadDanhSachThuoc(string keyword = "")
        {
            try
            {
                using (var db = new PhongMachDbContext())
                {
                    var query = db.Thuocs.AsQueryable();

                    // Nếu có tìm kiếm
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        keyword = keyword.Trim();
                        string keywordUpper = keyword.ToUpper();

                        // Kiểm tra xem người dùng gõ có chữ "MTC" ở đầu không
                        if (keywordUpper.StartsWith("MTC"))
                        {
                            // Cắt bỏ chữ MTC đi, chỉ lấy phần số để tìm kiếm
                            string numPart = keywordUpper.Replace("MTC", "");
                            if (int.TryParse(numPart, out int maThuocSearch))
                            {
                                query = query.Where(t => t.MaThuoc == maThuocSearch);
                            }
                        }
                        // Kiểm tra xem từ khoá nhập vào có phải là con số trơn không
                        else if (int.TryParse(keyword, out int maThuocSearch))
                        {
                            query = query.Where(t => t.MaThuoc == maThuocSearch || t.TenThuoc.Contains(keyword));
                        }
                        else
                        {
                            // Nếu chỉ nhập chữ -> Tìm theo Tên Thuốc
                            query = query.Where(t => t.TenThuoc.Contains(keyword));
                        }
                    }

                    // Ép kiểu về List trước để có thể dùng hàm .ToString("D3") của C#
                    var danhSachGoc = query.ToList();

                    // Tạo danh sách hiển thị với Mã được format thêm "MTC"
                    var danhSachHienThi = danhSachGoc.Select(t => new
                    {
                        MaThuoc = t.MaThuoc, // Cột này sẽ bị ẩn đi, chỉ dùng để lấy ID thật thao tác
                        MaThuocHienThi = "MTC" + t.MaThuoc.ToString("D3"), // Format thành MTC001, MTC002...
                        TenThuoc = t.TenThuoc,
                        DonViTinh = t.DonViTinh,
                        DonGia = t.DonGia
                    }).ToList();

                    dgvThuoc.DataSource = danhSachHienThi;

                    // Định dạng cột
                    if (dgvThuoc.Columns.Count > 0)
                    {
                        dgvThuoc.Columns["MaThuoc"].Visible = false; // Ẩn cột ID số nguyên đi

                        dgvThuoc.Columns["MaThuocHienThi"].HeaderText = "Mã Thuốc";
                        dgvThuoc.Columns["MaThuocHienThi"].DisplayIndex = 0; // Luôn đảm bảo nó nằm ở cột đầu tiên

                        dgvThuoc.Columns["TenThuoc"].HeaderText = "Tên Thuốc (Biệt dược)";
                        dgvThuoc.Columns["DonViTinh"].HeaderText = "Đơn vị tính";
                        dgvThuoc.Columns["DonGia"].HeaderText = "Đơn giá (VNĐ)";

                        dgvThuoc.Columns["TenThuoc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dgvThuoc.Columns["DonGia"].DefaultCellStyle.Format = "N0"; // Format tiền tệ có dấu phẩy
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách thuốc: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Thêm thuốc mới
        private void btnThemThuoc_Click(object sender, EventArgs e)
        {
            string tenThuoc = txtTenThuoc.Text.Trim();
            // Lấy từ ComboBox nếu xài ComboBox, hoặc TextBox nếu xài TextBox
            string donViTinh = cboDonViTinh != null ? cboDonViTinh.Text.Trim() : "";

            // Validate dữ liệu trống
            if (string.IsNullOrEmpty(tenThuoc) || string.IsNullOrEmpty(txtDonGia.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tên thuốc và Đơn giá!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate Đơn giá phải là số
            if (!decimal.TryParse(txtDonGia.Text.Trim(), out decimal donGia) || donGia < 0)
            {
                MessageBox.Show("Đơn giá không hợp lệ! Vui lòng chỉ nhập số và không được âm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new PhongMachDbContext())
                {
                    // Kiểm tra trùng tên thuốc
                    if (db.Thuocs.Any(t => t.TenThuoc.ToLower() == tenThuoc.ToLower()))
                    {
                        MessageBox.Show("Tên thuốc này đã tồn tại trong kho!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var thuocMoi = new Thuoc
                    {
                        TenThuoc = tenThuoc,
                        DonViTinh = donViTinh,
                        DonGia = donGia
                    };

                    db.Thuocs.Add(thuocMoi);
                    db.SaveChanges();

                    MessageBox.Show("Đã thêm thuốc mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnLamMoi_Click(sender, e); // Reset form và load lại lưới
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm thuốc: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Click vào lưới dgv để hiển thị dữ liệu
        private void dgvThuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvThuoc.Rows[e.RowIndex];
                if (row.Cells["MaThuoc"].Value != null)
                {
                    _maThuocHienTai = Convert.ToInt32(row.Cells["MaThuoc"].Value);
                    txtTenThuoc.Text = row.Cells["TenThuoc"].Value?.ToString();

                    if (cboDonViTinh != null)
                    {
                        cboDonViTinh.Text = row.Cells["DonViTinh"].Value?.ToString();
                    }

                    // Chuyển kiểu decimal về string để hiện lên Textbox (bỏ đi các số .000 dư thừa nếu có)
                    if (decimal.TryParse(row.Cells["DonGia"].Value?.ToString(), out decimal donGia))
                    {
                        txtDonGia.Text = donGia.ToString("0.##");
                    }
                }
            }
        }

        //Cập nhật - Sửa thuốc
        private void btnSuaThuoc_Click(object sender, EventArgs e)
        {
            if (_maThuocHienTai == 0)
            {
                MessageBox.Show("Vui lòng click chọn một loại thuốc dưới lưới để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenThuoc = txtTenThuoc.Text.Trim();
            string donViTinh = cboDonViTinh != null ? cboDonViTinh.Text.Trim() : "";

            if (string.IsNullOrEmpty(tenThuoc) || string.IsNullOrEmpty(txtDonGia.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tên thuốc và Đơn giá!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtDonGia.Text.Trim(), out decimal donGia) || donGia < 0)
            {
                MessageBox.Show("Đơn giá không hợp lệ! Vui lòng chỉ nhập số và không được âm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new PhongMachDbContext())
                {
                    var thuocUpdate = db.Thuocs.FirstOrDefault(t => t.MaThuoc == _maThuocHienTai);
                    if (thuocUpdate != null)
                    {
                        thuocUpdate.TenThuoc = tenThuoc;
                        thuocUpdate.DonViTinh = donViTinh;
                        thuocUpdate.DonGia = donGia;

                        db.SaveChanges();
                        MessageBox.Show("Cập nhật thông tin thuốc thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnLamMoi_Click(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                // Lấy lỗi thực sự ẩn bên trong (Inner Exception)
                string loiThatSu = ex.Message;
                if (ex.InnerException != null)
                {
                    loiThatSu = ex.InnerException.Message; // Đây chính là câu trả lời từ SQL Server!
                }

                MessageBox.Show("Nguyên nhân gốc rễ gây lỗi là:\n\n" + loiThatSu, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Xoá thuốc
        private void btnXoaThuoc_Click(object sender, EventArgs e)
        {
            if (_maThuocHienTai == 0)
            {
                MessageBox.Show("Vui lòng click chọn một loại thuốc dưới lưới để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa thuốc '{txtTenThuoc.Text}' không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    using (var db = new PhongMachDbContext())
                    {
                        var thuocXoa = db.Thuocs.FirstOrDefault(t => t.MaThuoc == _maThuocHienTai);
                        if (thuocXoa != null)
                        {
                            db.Thuocs.Remove(thuocXoa);
                            db.SaveChanges();

                            MessageBox.Show("Đã xóa thuốc thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnLamMoi_Click(sender, e);
                        }
                    }
                }
                catch (Microsoft.EntityFrameworkCore.DbUpdateException)
                {
                    // Lỗi này xảy ra khi Thuốc này đã từng được Bác sĩ kê cho bệnh nhân (nằm trong ChiTietDonThuoc)
                    MessageBox.Show("KHÔNG THỂ XÓA!\nLoại thuốc này đã được sử dụng trong các Đơn thuốc của bệnh nhân. Việc xóa sẽ làm hỏng lịch sử bệnh án.", "Cảnh báo toàn vẹn dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa thuốc: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        //Làm mới các ô nhập
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            _maThuocHienTai = 0;
            txtTenThuoc.Clear();

            if (cboDonViTinh != null && cboDonViTinh.Items.Count > 0)
            {
                cboDonViTinh.SelectedIndex = 0;
            }

            txtDonGia.Clear();
            txtTimKiemThuoc.Clear(); // Xoá rỗng cả ô tìm kiếm
            txtTenThuoc.Focus();

            LoadDanhSachThuoc(); // Tải lại lưới
        }

        //Chức năng tìm kiếm thươc theo tên hoặc mã thuốc
        private void btnTimKiemThuoc_Click(object sender, EventArgs e)
        {
            // Lấy từ khoá từ ô TextBox
            string keyword = txtTimKiemThuoc.Text.Trim();
            LoadDanhSachThuoc(keyword);
        }

        // Gắn vào TextChanged của ô TextBox tìm kiếm để tự Reset danh sách khi xoá rỗng ô tìm kiếm
        private void txtTimKiemThuoc_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTimKiemThuoc.Text.Trim()))
            {
                LoadDanhSachThuoc();
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn đóng form Quản lý thuốc không?", "Xác nhận đóng Form", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
