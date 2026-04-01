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
    public partial class FrmDichVu : Form
    {

        // Biến lưu mã dịch vụ đang được chọn trên lưới
        private int _maDichVuHienTai = 0;

        // Biến lưu người dùng đang truy cập vào 
        private TaiKhoan _taiKhoanDangNhap;

        public FrmDichVu(TaiKhoan tk)
        {
            InitializeComponent();
            _taiKhoanDangNhap = tk;
        }

        private void FrmDichVu_Load(object sender, EventArgs e)
        {
            // ========================================================
            // PHÂN QUYỀN GIAO DIỆN: KHOÁ CHỨC NĂNG VỚI NON-ADMIN
            // ========================================================
            if (_taiKhoanDangNhap != null && _taiKhoanDangNhap.VaiTro != "ADMIN")
            {
                // Ẩn (hoặc làm mờ) các nút thao tác
                btnThemDichVu.Enabled = false;
                btnSuaDichVu.Enabled = false;
                btnXoaDichVu.Enabled = false;
            }

            LoadDanhSachDichVu();
        }

        //Tải danh sách dịch vụ lên datagridview
        private void LoadDanhSachDichVu(string keyword = "")
        {
            try
            {
                using (var db = new PhongMachDbContext())
                {
                    var query = db.DichVus.AsQueryable();

                    // Nếu có tìm kiếm
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        keyword = keyword.Trim();
                        string keywordUpper = keyword.ToUpper();

                        // Kiểm tra xem người dùng gõ có chữ "MDV" ở đầu không
                        if (keywordUpper.StartsWith("MDV"))
                        {
                            // Cắt bỏ chữ MDV đi, chỉ lấy phần số để tìm kiếm
                            string numPart = keywordUpper.Replace("MDV", "");
                            if (int.TryParse(numPart, out int maDVSearch))
                            {
                                query = query.Where(dv => dv.MaDV == maDVSearch);
                            }
                        }
                        // Kiểm tra xem từ khoá nhập vào có phải là con số trơn không
                        else if (int.TryParse(keyword, out int maDVSearch))
                        {
                            query = query.Where(dv => dv.MaDV == maDVSearch || dv.TenDichVu.Contains(keyword));
                        }
                        else
                        {
                            // Tìm theo Tên
                            query = query.Where(dv => dv.TenDichVu.Contains(keyword));
                        }
                    }

                    // Ép kiểu về List trước để có thể dùng hàm .ToString("D3") của C#
                    var danhSachGoc = query.ToList();

                    // Tạo danh sách hiển thị với Mã được format thêm "MDV"
                    var danhSachHienThi = danhSachGoc.Select(dv => new
                    {
                        MaDV = dv.MaDV, // Cột này sẽ bị ẩn đi, chỉ dùng để lấy ID thật
                        MaDichVuHienThi = "MDV" + dv.MaDV.ToString("D3"), // Format thành MDV001, MDV002...
                        TenDichVu = dv.TenDichVu,
                        DonGia = dv.DonGia
                    }).ToList();

                    dgvDichVu.DataSource = danhSachHienThi;

                    // Định dạng cột
                    if (dgvDichVu.Columns.Count > 0)
                    {
                        dgvDichVu.Columns["MaDV"].Visible = false; // Ẩn cột ID số nguyên đi

                        dgvDichVu.Columns["MaDichVuHienThi"].HeaderText = "Mã Dịch Vụ";
                        dgvDichVu.Columns["MaDichVuHienThi"].DisplayIndex = 0; // Luôn đảm bảo nó nằm ở cột đầu tiên

                        dgvDichVu.Columns["TenDichVu"].HeaderText = "Tên Dịch Vụ (Cận Lâm Sàng)";
                        dgvDichVu.Columns["DonGia"].HeaderText = "Đơn giá (VNĐ)";

                        dgvDichVu.Columns["TenDichVu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        dgvDichVu.Columns["DonGia"].DefaultCellStyle.Format = "N0"; // Format tiền tệ có dấu phẩy
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách dịch vụ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Nút thêm dịch vụ mới
        private void btnThemDichVu_Click(object sender, EventArgs e)
        {
            string tenDichVu = txtTenDichVu.Text.Trim();

            // Validate dữ liệu trống
            if (string.IsNullOrEmpty(tenDichVu) || string.IsNullOrEmpty(txtDonGia.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tên dịch vụ và Đơn giá!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    // Kiểm tra trùng tên dịch vụ
                    if (db.DichVus.Any(dv => dv.TenDichVu.ToLower() == tenDichVu.ToLower()))
                    {
                        MessageBox.Show("Tên dịch vụ này đã tồn tại trong hệ thống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var dichVuMoi = new DichVu
                    {
                        TenDichVu = tenDichVu,
                        DonGia = donGia
                    };

                    db.DichVus.Add(dichVuMoi);
                    db.SaveChanges();

                    MessageBox.Show("Đã thêm dịch vụ mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnLamMoi_Click(sender, e); // Reset form và load lại lưới
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm dịch vụ: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Click vào lưới để hiển thị dữ liệu
        private void dgvDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDichVu.Rows[e.RowIndex];
                if (row.Cells["MaDV"].Value != null)
                {
                    _maDichVuHienTai = Convert.ToInt32(row.Cells["MaDV"].Value);
                    txtTenDichVu.Text = row.Cells["TenDichVu"].Value?.ToString();

                    // Chuyển kiểu decimal về string để hiện lên Textbox (bỏ đi các số .000 dư thừa nếu có)
                    if (decimal.TryParse(row.Cells["DonGia"].Value?.ToString(), out decimal donGia))
                    {
                        txtDonGia.Text = donGia.ToString("0.##");
                    }
                }
            }
        }

        //Cập nhật - sửa dịch vụ
        private void btnSuaDichVu_Click(object sender, EventArgs e)
        {
            if (_maDichVuHienTai == 0)
            {
                MessageBox.Show("Vui lòng click chọn một dịch vụ dưới lưới để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenDichVu = txtTenDichVu.Text.Trim();

            if (string.IsNullOrEmpty(tenDichVu) || string.IsNullOrEmpty(txtDonGia.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tên dịch vụ và Đơn giá!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    var dvUpdate = db.DichVus.FirstOrDefault(dv => dv.MaDV == _maDichVuHienTai);
                    if (dvUpdate != null)
                    {
                        dvUpdate.TenDichVu = tenDichVu;
                        dvUpdate.DonGia = donGia;

                        db.SaveChanges();
                        MessageBox.Show("Cập nhật thông tin dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnLamMoi_Click(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa dịch vụ: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Xoá dịch vụ
        private void btnXoaDichVu_Click(object sender, EventArgs e)
        {
            if (_maDichVuHienTai == 0)
            {
                MessageBox.Show("Vui lòng click chọn một dịch vụ dưới lưới để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa dịch vụ '{txtTenDichVu.Text}' không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    using (var db = new PhongMachDbContext())
                    {
                        var dvXoa = db.DichVus.FirstOrDefault(dv => dv.MaDV == _maDichVuHienTai);
                        if (dvXoa != null)
                        {
                            db.DichVus.Remove(dvXoa);
                            db.SaveChanges();

                            MessageBox.Show("Đã xóa dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnLamMoi_Click(sender, e);
                        }
                    }
                }
                catch (Microsoft.EntityFrameworkCore.DbUpdateException)
                {
                    // Lỗi này xảy ra khi Dịch vụ này đã được Bác sĩ chỉ định cho bệnh nhân
                    MessageBox.Show("KHÔNG THỂ XÓA!\nDịch vụ này đã được sử dụng trong hồ sơ khám bệnh của bệnh nhân. Việc xóa sẽ làm hỏng dữ liệu lịch sử.", "Cảnh báo toàn vẹn dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa dịch vụ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Làm mới form và tìm kiếm
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            _maDichVuHienTai = 0;
            txtTenDichVu.Clear();
            txtDonGia.Clear();
            txtTimKiemDichVu.Clear();
            txtTenDichVu.Focus();

            LoadDanhSachDichVu(); // Tải lại lưới
        }

        //Sự kiện click nút tìm kiếm   
        private void btnTimKiemDichVu_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiemDichVu.Text.Trim();
            LoadDanhSachDichVu(keyword);
        }

        private void txtTimKiemDichVu_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTimKiemDichVu.Text.Trim()))
            {
                LoadDanhSachDichVu();
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn đóng form Quản lý dịch vụ không?", "Xác nhận đóng Form", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
