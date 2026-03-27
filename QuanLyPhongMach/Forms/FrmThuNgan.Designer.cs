namespace QuanLyPhongMach.Forms
{
    partial class FrmThuNgan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnDong = new Button();
            groupBox1 = new GroupBox();
            btnTimKiem = new Button();
            txtTimKiem = new TextBox();
            label1 = new Label();
            label2 = new Label();
            dgvChiTietPhieuKham = new DataGridView();
            MaPhieuKham = new DataGridViewTextBoxColumn();
            TenBenhNhan = new DataGridViewTextBoxColumn();
            TenBacSiKham = new DataGridViewTextBoxColumn();
            pnlTongTien = new Panel();
            lblTongTien = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtBenhNhan = new TextBox();
            label6 = new Label();
            cboHinhThuc = new ComboBox();
            label7 = new Label();
            txtGhiChu = new RichTextBox();
            btnXacNhanThanhToan = new Button();
            btnInHoaDon = new Button();
            dgvChiTietDichVu = new DataGridView();
            TenDichVu = new DataGridViewTextBoxColumn();
            DonGiaDichVu = new DataGridViewTextBoxColumn();
            TenThuoc = new DataGridViewTextBoxColumn();
            SoLuong = new DataGridViewTextBoxColumn();
            DonGiaThuoc = new DataGridViewTextBoxColumn();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietPhieuKham).BeginInit();
            pnlTongTien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietDichVu).BeginInit();
            SuspendLayout();
            // 
            // btnDong
            // 
            btnDong.BackColor = SystemColors.ButtonFace;
            btnDong.FlatAppearance.BorderSize = 2;
            btnDong.FlatStyle = FlatStyle.Flat;
            btnDong.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDong.ForeColor = Color.Red;
            btnDong.Location = new Point(1587, 12);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(299, 56);
            btnDong.TabIndex = 1;
            btnDong.Text = "Đóng và Quay về Trang chủ";
            btnDong.UseVisualStyleBackColor = false;
            btnDong.Click += btnDong_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnTimKiem);
            groupBox1.Controls.Add(txtTimKiem);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(219, 74);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1446, 96);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Bộ lọc tìm kiếm";
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = Color.RoyalBlue;
            btnTimKiem.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTimKiem.ForeColor = SystemColors.ButtonHighlight;
            btnTimKiem.Location = new Point(1141, 26);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(237, 60);
            btnTimKiem.TabIndex = 6;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTimKiem.Location = new Point(279, 37);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Nhập mã phiếu hoặc tên bệnh nhân";
            txtTimKiem.Size = new Size(820, 37);
            txtTimKiem.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(39, 40);
            label1.Name = "label1";
            label1.Size = new Size(234, 30);
            label1.TabIndex = 0;
            label1.Text = "Tìm kiếm phiếu khám:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.MenuHighlight;
            label2.Location = new Point(92, 184);
            label2.Name = "label2";
            label2.Size = new Size(215, 30);
            label2.TabIndex = 0;
            label2.Text = "Chi tiết Phiếu khám:";
            // 
            // dgvChiTietPhieuKham
            // 
            dgvChiTietPhieuKham.AllowUserToAddRows = false;
            dgvChiTietPhieuKham.AllowUserToDeleteRows = false;
            dgvChiTietPhieuKham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTietPhieuKham.BackgroundColor = SystemColors.ControlLight;
            dgvChiTietPhieuKham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTietPhieuKham.Columns.AddRange(new DataGridViewColumn[] { MaPhieuKham, TenBenhNhan, TenBacSiKham });
            dgvChiTietPhieuKham.Location = new Point(12, 217);
            dgvChiTietPhieuKham.Name = "dgvChiTietPhieuKham";
            dgvChiTietPhieuKham.ReadOnly = true;
            dgvChiTietPhieuKham.RowHeadersWidth = 62;
            dgvChiTietPhieuKham.Size = new Size(935, 276);
            dgvChiTietPhieuKham.TabIndex = 3;
            dgvChiTietPhieuKham.CellClick += dgvChiTietPhieuKham_CellClick;
            // 
            // MaPhieuKham
            // 
            MaPhieuKham.DataPropertyName = "MaPhieuKham";
            MaPhieuKham.FillWeight = 50F;
            MaPhieuKham.HeaderText = "Mã Phiếu Khám";
            MaPhieuKham.MinimumWidth = 8;
            MaPhieuKham.Name = "MaPhieuKham";
            MaPhieuKham.ReadOnly = true;
            // 
            // TenBenhNhan
            // 
            TenBenhNhan.DataPropertyName = "TenBenhNhan";
            TenBenhNhan.HeaderText = "Tên Bệnh Nhân";
            TenBenhNhan.MinimumWidth = 8;
            TenBenhNhan.Name = "TenBenhNhan";
            TenBenhNhan.ReadOnly = true;
            // 
            // TenBacSiKham
            // 
            TenBacSiKham.DataPropertyName = "TenBacSiKham";
            TenBacSiKham.HeaderText = "Tên Bác Sĩ Khám";
            TenBacSiKham.MinimumWidth = 8;
            TenBacSiKham.Name = "TenBacSiKham";
            TenBacSiKham.ReadOnly = true;
            // 
            // pnlTongTien
            // 
            pnlTongTien.Controls.Add(lblTongTien);
            pnlTongTien.Controls.Add(label3);
            pnlTongTien.Location = new Point(12, 499);
            pnlTongTien.Name = "pnlTongTien";
            pnlTongTien.Size = new Size(1865, 62);
            pnlTongTien.TabIndex = 4;
            // 
            // lblTongTien
            // 
            lblTongTien.AutoSize = true;
            lblTongTien.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTongTien.ForeColor = Color.IndianRed;
            lblTongTien.Location = new Point(1625, 13);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(103, 38);
            lblTongTien.TabIndex = 1;
            lblTongTien.Text = "0 VNĐ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(1440, 13);
            label3.Name = "label3";
            label3.Size = new Size(168, 38);
            label3.TabIndex = 0;
            label3.Text = "Tổng Cộng:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Green;
            label4.Location = new Point(92, 564);
            label4.Name = "label4";
            label4.Size = new Size(224, 30);
            label4.TabIndex = 0;
            label4.Text = "Xác nhận thanh toán:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(167, 622);
            label5.Name = "label5";
            label5.Size = new Size(111, 28);
            label5.TabIndex = 5;
            label5.Text = "Bệnh Nhân:";
            // 
            // txtBenhNhan
            // 
            txtBenhNhan.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBenhNhan.Location = new Point(284, 616);
            txtBenhNhan.Name = "txtBenhNhan";
            txtBenhNhan.Size = new Size(1348, 34);
            txtBenhNhan.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(167, 682);
            label6.Name = "label6";
            label6.Size = new Size(104, 28);
            label6.TabIndex = 5;
            label6.Text = "Hình Thức:";
            // 
            // cboHinhThuc
            // 
            cboHinhThuc.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboHinhThuc.FormattingEnabled = true;
            cboHinhThuc.Items.AddRange(new object[] { "Tiền mặt", "Chuyển khoản", "Thẻ tín dụng/Ghi nợ" });
            cboHinhThuc.Location = new Point(284, 674);
            cboHinhThuc.Name = "cboHinhThuc";
            cboHinhThuc.Size = new Size(1348, 36);
            cboHinhThuc.TabIndex = 7;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(167, 729);
            label7.Name = "label7";
            label7.Size = new Size(85, 28);
            label7.TabIndex = 5;
            label7.Text = "Ghi Chú:";
            // 
            // txtGhiChu
            // 
            txtGhiChu.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtGhiChu.Location = new Point(167, 769);
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new Size(1465, 111);
            txtGhiChu.TabIndex = 8;
            txtGhiChu.Text = "";
            // 
            // btnXacNhanThanhToan
            // 
            btnXacNhanThanhToan.BackColor = Color.Green;
            btnXacNhanThanhToan.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXacNhanThanhToan.ForeColor = SystemColors.ButtonHighlight;
            btnXacNhanThanhToan.Location = new Point(542, 886);
            btnXacNhanThanhToan.Name = "btnXacNhanThanhToan";
            btnXacNhanThanhToan.Size = new Size(723, 60);
            btnXacNhanThanhToan.TabIndex = 9;
            btnXacNhanThanhToan.Text = "Xác nhận thanh toán";
            btnXacNhanThanhToan.UseVisualStyleBackColor = false;
            btnXacNhanThanhToan.Click += btnXacNhanThanhToan_Click;
            // 
            // btnInHoaDon
            // 
            btnInHoaDon.BackColor = Color.SlateGray;
            btnInHoaDon.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnInHoaDon.ForeColor = SystemColors.ButtonHighlight;
            btnInHoaDon.Location = new Point(542, 952);
            btnInHoaDon.Name = "btnInHoaDon";
            btnInHoaDon.Size = new Size(723, 60);
            btnInHoaDon.TabIndex = 9;
            btnInHoaDon.Text = "In hoá đơn";
            btnInHoaDon.UseVisualStyleBackColor = false;
            // 
            // dgvChiTietDichVu
            // 
            dgvChiTietDichVu.AllowUserToAddRows = false;
            dgvChiTietDichVu.AllowUserToDeleteRows = false;
            dgvChiTietDichVu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTietDichVu.BackgroundColor = SystemColors.ControlLight;
            dgvChiTietDichVu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTietDichVu.Columns.AddRange(new DataGridViewColumn[] { TenDichVu, DonGiaDichVu, TenThuoc, SoLuong, DonGiaThuoc });
            dgvChiTietDichVu.Location = new Point(953, 217);
            dgvChiTietDichVu.Name = "dgvChiTietDichVu";
            dgvChiTietDichVu.ReadOnly = true;
            dgvChiTietDichVu.RowHeadersWidth = 62;
            dgvChiTietDichVu.Size = new Size(924, 276);
            dgvChiTietDichVu.TabIndex = 10;
            // 
            // TenDichVu
            // 
            TenDichVu.DataPropertyName = "TenDichVu";
            TenDichVu.HeaderText = "Tên Dịch Vụ";
            TenDichVu.MinimumWidth = 8;
            TenDichVu.Name = "TenDichVu";
            TenDichVu.ReadOnly = true;
            // 
            // DonGiaDichVu
            // 
            DonGiaDichVu.DataPropertyName = "DonGiaDichVu";
            DonGiaDichVu.FillWeight = 70F;
            DonGiaDichVu.HeaderText = "Đơn Giá DV";
            DonGiaDichVu.MinimumWidth = 8;
            DonGiaDichVu.Name = "DonGiaDichVu";
            DonGiaDichVu.ReadOnly = true;
            // 
            // TenThuoc
            // 
            TenThuoc.DataPropertyName = "TenThuoc";
            TenThuoc.HeaderText = "Tên Thuốc";
            TenThuoc.MinimumWidth = 8;
            TenThuoc.Name = "TenThuoc";
            TenThuoc.ReadOnly = true;
            // 
            // SoLuong
            // 
            SoLuong.DataPropertyName = "SoLuong";
            SoLuong.FillWeight = 30F;
            SoLuong.HeaderText = "Số Lượng";
            SoLuong.MinimumWidth = 8;
            SoLuong.Name = "SoLuong";
            SoLuong.ReadOnly = true;
            // 
            // DonGiaThuoc
            // 
            DonGiaThuoc.DataPropertyName = "DonGiaThuoc";
            DonGiaThuoc.FillWeight = 70F;
            DonGiaThuoc.HeaderText = "Đơn Giá Thuốc";
            DonGiaThuoc.MinimumWidth = 8;
            DonGiaThuoc.Name = "DonGiaThuoc";
            DonGiaThuoc.ReadOnly = true;
            // 
            // FrmThuNgan
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1898, 1024);
            Controls.Add(dgvChiTietDichVu);
            Controls.Add(btnInHoaDon);
            Controls.Add(btnXacNhanThanhToan);
            Controls.Add(txtGhiChu);
            Controls.Add(cboHinhThuc);
            Controls.Add(txtBenhNhan);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(pnlTongTien);
            Controls.Add(dgvChiTietPhieuKham);
            Controls.Add(groupBox1);
            Controls.Add(btnDong);
            Controls.Add(label4);
            Controls.Add(label2);
            Name = "FrmThuNgan";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmThuNgan";
            Load += FrmThuNgan_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietPhieuKham).EndInit();
            pnlTongTien.ResumeLayout(false);
            pnlTongTien.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietDichVu).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnDong;
        private GroupBox groupBox1;
        private TextBox txtTimKiem;
        private Label label1;
        private Button btnTimKiem;
        private Label label2;
        private DataGridView dgvChiTietPhieuKham;
        private Panel pnlTongTien;
        private Label lblTongTien;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtBenhNhan;
        private Label label6;
        private ComboBox cboHinhThuc;
        private Label label7;
        private RichTextBox txtGhiChu;
        private Button btnXacNhanThanhToan;
        private Button btnInHoaDon;
        private DataGridView dgvChiTietDichVu;
        private DataGridViewTextBoxColumn TenDichVu;
        private DataGridViewTextBoxColumn DonGiaDichVu;
        private DataGridViewTextBoxColumn TenThuoc;
        private DataGridViewTextBoxColumn SoLuong;
        private DataGridViewTextBoxColumn DonGiaThuoc;
        private DataGridViewTextBoxColumn MaPhieuKham;
        private DataGridViewTextBoxColumn TenBenhNhan;
        private DataGridViewTextBoxColumn TenBacSiKham;
    }
}