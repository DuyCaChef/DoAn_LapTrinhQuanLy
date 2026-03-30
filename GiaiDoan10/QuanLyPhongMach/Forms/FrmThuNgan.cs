using Microsoft.Data.SqlClient;
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
    public partial class FrmThuNgan : Form
    {

        private string connectionString = @"Data Source=.;Initial Catalog=QuanLyPhongMach;User ID=sa;Password=duylun2005;TrustServerCertificate=True;";

        // Biến lưu mã phiếu khám đang được chọn
        private string maPhieuKhamDuocChon = "";
        private decimal tongTienHienTai = 0;

        public FrmThuNgan()
        {
            InitializeComponent();
        }

        private void FrmThuNgan_Load(object sender, EventArgs e)
        {
            // 1. Thêm các mục vào ComboBox nếu danh sách đang trống
            if (cboHinhThuc.Items.Count == 0)
            {
                cboHinhThuc.Items.Add("Tiền mặt");
                cboHinhThuc.Items.Add("Chuyển khoản");
                cboHinhThuc.Items.Add("Thẻ tín dụng/Ghi nợ");
            }

            // 2. Set up mặc định cho Cbo hình thức thanh toán (chỉ chọn khi đã có item)
            if (cboHinhThuc.Items.Count > 0)
            {
                cboHinhThuc.SelectedIndex = 0; // Chọn mục đầu tiên ("Tiền mặt") làm mặc định
            }

            // Tắt auto generate columns nếu bạn đã tạo cột sẵn trong giao diện
            dgvChiTietPhieuKham.AutoGenerateColumns = false;
            dgvChiTietDichVu.AutoGenerateColumns = false;

            LoadDanhSachPhieuKhamChuaThanhToan("");
        }

        // 1. HÀM LOAD DANH SÁCH PHIẾU KHÁM LÊN BẢNG TRÁI
        private void LoadDanhSachPhieuKhamChuaThanhToan(string tuKhoa)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Đã thêm JOIN qua LICHKHAM và đổi tên cột theo các class KhachHang, BacSi, PhieuKham
                    // Dùng NOT EXISTS HOADON để xác định phiếu nào chưa được thanh toán
                    string query = @"
                        SELECT 
                            ISNULL(pk.MaHienThi, 'MPK' + CAST(pk.MaPK AS NVARCHAR)) AS MaPhieuKham,    
                            kh.TenKH AS TenBenhNhan,        
                            bs.TenBS AS TenBacSiKham        
                        FROM PHIEUKHAM pk
                        JOIN LICHKHAM lk ON pk.MaLichKham = lk.MaLichKham
                        JOIN KHACHHANG kh ON lk.MaKH = kh.MaKH
                        JOIN BACSI bs ON lk.MaBS = bs.MaBS
                        WHERE NOT EXISTS (SELECT 1 FROM HOADON hd WHERE hd.MaPK = pk.MaPK)
                        AND (ISNULL(pk.MaHienThi, 'MPK' + CAST(pk.MaPK AS NVARCHAR)) LIKE @tuKhoa OR kh.TenKH LIKE @tuKhoa)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@tuKhoa", "%" + tuKhoa + "%");
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvChiTietPhieuKham.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng mở file PhieuKham.cs, KhachHang.cs để xem lại tên cột và sửa vào SQL!\nChi tiết: " + ex.Message, "Sai tên cột Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 2. SỰ KIỆN TÌM KIẾM
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadDanhSachPhieuKhamChuaThanhToan(txtTimKiem.Text.Trim());
        }

        // 3. SỰ KIỆN CLICK VÀO 1 PHIẾU KHÁM ĐỂ XEM CHI TIẾT
        private void dgvChiTietPhieuKham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvChiTietPhieuKham.Rows[e.RowIndex];

                // Lấy mã hiển thị (Ví dụ: "MPK15")
                string maHienThi = row.Cells["MaPhieuKham"].Value.ToString();

                // Phải cắt bỏ chữ MPK để lấy lại số nguyên gốc truyền vào SQL
                maPhieuKhamDuocChon = maHienThi.Replace("MPK", "");

                txtBenhNhan.Text = row.Cells["TenBenhNhan"].Value.ToString();

                // Truyền con số (VD: "15") vào hàm Load chi tiết
                LoadChiTietDichVuVaThuoc(maPhieuKhamDuocChon);
            }
        }

        // 4. HÀM LOAD CHI TIẾT VÀO BẢNG PHẢI (Gộp cả dịch vụ và thuốc)
        private void LoadChiTietDichVuVaThuoc(string maPhieuKham)
        {
            dgvChiTietDichVu.Rows.Clear();
            tongTienHienTai = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // --- BƯỚC A: LẤY DANH SÁCH DỊCH VỤ ---
                    // Đã lấy thêm cột SoLuong từ bảng ChiTietDichVu để tính đúng tổng tiền
                    string queryDichVu = @"
                        SELECT dv.TenDichVu, ctdv.SoLuong, dv.DonGia 
                        FROM CHITIET_DICHVU ctdv
                        JOIN DICHVU dv ON ctdv.MaDV = dv.MaDV
                        WHERE ctdv.MaPK = @MaPK";

                    using (SqlCommand cmd = new SqlCommand(queryDichVu, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaPK", maPhieuKham);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string tenDV = reader["TenDichVu"].ToString();
                                int soLuongDV = Convert.ToInt32(reader["SoLuong"]);
                                decimal donGia = Convert.ToDecimal(reader["DonGia"]);

                                // Đã map đúng vị trí: Dịch vụ (0), Đơn giá (1)
                                dgvChiTietDichVu.Rows.Add(tenDV, donGia.ToString("N0"), "", "", "");
                                tongTienHienTai += (soLuongDV * donGia);
                            }
                        }
                    }

                    // --- BƯỚC B: LẤY DANH SÁCH ĐƠN THUỐC ---
                    string queryThuoc = @"
                        SELECT t.TenThuoc, ctt.SoLuong, t.DonGia 
                        FROM CHITIET_DONTHUOC ctt
                        JOIN THUOC t ON ctt.MaThuoc = t.MaThuoc
                        WHERE ctt.MaPK = @MaPK";

                    using (SqlCommand cmd = new SqlCommand(queryThuoc, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaPK", maPhieuKham);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string tenThuoc = reader["TenThuoc"].ToString();
                                int soLuong = Convert.ToInt32(reader["SoLuong"]);
                                decimal donGiaThuoc = Convert.ToDecimal(reader["DonGia"]);

                                // Đã map đúng vị trí: Thuốc (2), SL (3), Đơn giá (4)
                                dgvChiTietDichVu.Rows.Add("", "", tenThuoc, soLuong, donGiaThuoc.ToString("N0"));
                                tongTienHienTai += (soLuong * donGiaThuoc);
                            }
                        }
                    }

                    lblTongTien.Text = tongTienHienTai.ToString("N0") + " VNĐ";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải chi tiết: " + ex.Message);
            }
        }

        // 5. XỬ LÝ NÚT XÁC NHẬN THANH TOÁN
        private void btnXacNhanThanhToan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maPhieuKhamDuocChon))
            {
                MessageBox.Show("Vui lòng chọn một phiếu khám để thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show($"Xác nhận thu tiền bệnh nhân {txtBenhNhan.Text}\nTổng tiền: {lblTongTien.Text}?",
                                               "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        // Xóa UPDATE PhieuKham vì bảng này không có cột TrangThai.
                        // Sửa lại INSERT HOADON chuẩn xác với thuộc tính trong HoaDon.cs (loại bỏ GhiChu)
                        string insertHoaDon = @"INSERT INTO HOADON (MaPK, TongTien, PhuongThucThanhToan, TrangThaiThanhToan, NgayThanhToan) 
                                                VALUES (@MaPK, @TongTien, @HinhThuc, N'Đã thanh toán', GETDATE())";
                        using (SqlCommand cmdInsert = new SqlCommand(insertHoaDon, conn))
                        {
                            cmdInsert.Parameters.AddWithValue("@MaPK", maPhieuKhamDuocChon);
                            cmdInsert.Parameters.AddWithValue("@TongTien", tongTienHienTai);
                            cmdInsert.Parameters.AddWithValue("@HinhThuc", cboHinhThuc.SelectedItem?.ToString() ?? "Tiền mặt");
                            cmdInsert.ExecuteNonQuery();
                        }

                        // =========================================================================
                        //Thay thế MessageBox thông báo đơn thuần bằng DialogResult hỏi In hoá đơn
                        // =========================================================================
                        DialogResult printDialog = MessageBox.Show("Thanh toán thành công!\nBạn có muốn in hoá đơn cho bệnh nhân này không?",
                                                                   "In hoá đơn",
                                                                   MessageBoxButtons.YesNo,
                                                                   MessageBoxIcon.Question);
                        if (printDialog == DialogResult.Yes)
                        {
                            // Sau này nếu muốn làm in thật bằng PrintDocument, bạn viết code in ở đây
                            MessageBox.Show("In hoá đơn thành công!", "Hệ thống máy in", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        // Dọn dẹp màn hình sau khi thanh toán
                        maPhieuKhamDuocChon = "";
                        txtBenhNhan.Text = "";
                        txtGhiChu.Text = "";
                        lblTongTien.Text = "0 VNĐ";
                        dgvChiTietDichVu.Rows.Clear();

                        // Load lại danh sách (phiếu vừa thanh toán sẽ tự động biến mất)
                        LoadDanhSachPhieuKhamChuaThanhToan(txtTimKiem.Text);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thanh toán: " + ex.Message);
                }
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đóng và quay về trang chủ?",
                                                  "Xác nhận thoát",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
