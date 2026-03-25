namespace QuanLyPhongMach.Forms
{
    partial class FrmKhamBenh
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
            lblBacSiPhuTrach = new Label();
            btnDong = new Button();
            splitContainer1 = new SplitContainer();
            dgvDanhSachCho = new DataGridView();
            TenBenhNhan = new DataGridViewTextBoxColumn();
            GioKham = new DataGridViewTextBoxColumn();
            TrangThai = new DataGridViewTextBoxColumn();
            dtpNgayKham = new DateTimePicker();
            label1 = new Label();
            btnThemThuoc = new Button();
            btnBoThuoc = new Button();
            btnThemDichVu = new Button();
            btnBoDichVu = new Button();
            txtSoLuong = new TextBox();
            dgvKeDonThuoc = new DataGridView();
            TenThuoc = new DataGridViewTextBoxColumn();
            DonViTinh = new DataGridViewTextBoxColumn();
            SoLuong = new DataGridViewTextBoxColumn();
            DonGiaThuoc = new DataGridViewTextBoxColumn();
            cboKeDonThuoc = new ComboBox();
            label7 = new Label();
            label6 = new Label();
            dgvChiDinhDichVu = new DataGridView();
            TenDichVu = new DataGridViewTextBoxColumn();
            DonGia = new DataGridViewTextBoxColumn();
            cboChiDinhDichVu = new ComboBox();
            btnHoanThanh = new Button();
            btnHuyKham = new Button();
            txtLoiDan = new RichTextBox();
            txtChanDoan = new RichTextBox();
            label5 = new Label();
            label4 = new Label();
            txtTrieuChung = new TextBox();
            label3 = new Label();
            label2 = new Label();
            panel1 = new Panel();
            lblDangKhamBenhNhan = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachCho).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvKeDonThuoc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvChiDinhDichVu).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblBacSiPhuTrach
            // 
            lblBacSiPhuTrach.AutoSize = true;
            lblBacSiPhuTrach.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBacSiPhuTrach.ForeColor = SystemColors.MenuHighlight;
            lblBacSiPhuTrach.Location = new Point(26, 30);
            lblBacSiPhuTrach.Name = "lblBacSiPhuTrach";
            lblBacSiPhuTrach.Size = new Size(502, 38);
            lblBacSiPhuTrach.TabIndex = 0;
            lblBacSiPhuTrach.Text = "Bác sĩ phụ trách: BS.Phan Khánh Duy";
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
            // splitContainer1
            // 
            splitContainer1.Location = new Point(2, 74);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = SystemColors.ControlLight;
            splitContainer1.Panel1.Controls.Add(dgvDanhSachCho);
            splitContainer1.Panel1.Controls.Add(dtpNgayKham);
            splitContainer1.Panel1.Controls.Add(label1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.AutoScroll = true;
            splitContainer1.Panel2.Controls.Add(btnThemThuoc);
            splitContainer1.Panel2.Controls.Add(btnBoThuoc);
            splitContainer1.Panel2.Controls.Add(btnThemDichVu);
            splitContainer1.Panel2.Controls.Add(btnBoDichVu);
            splitContainer1.Panel2.Controls.Add(txtSoLuong);
            splitContainer1.Panel2.Controls.Add(dgvKeDonThuoc);
            splitContainer1.Panel2.Controls.Add(cboKeDonThuoc);
            splitContainer1.Panel2.Controls.Add(label7);
            splitContainer1.Panel2.Controls.Add(label6);
            splitContainer1.Panel2.Controls.Add(dgvChiDinhDichVu);
            splitContainer1.Panel2.Controls.Add(cboChiDinhDichVu);
            splitContainer1.Panel2.Controls.Add(btnHoanThanh);
            splitContainer1.Panel2.Controls.Add(btnHuyKham);
            splitContainer1.Panel2.Controls.Add(txtLoiDan);
            splitContainer1.Panel2.Controls.Add(txtChanDoan);
            splitContainer1.Panel2.Controls.Add(label5);
            splitContainer1.Panel2.Controls.Add(label4);
            splitContainer1.Panel2.Controls.Add(txtTrieuChung);
            splitContainer1.Panel2.Controls.Add(label3);
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Panel2.Controls.Add(panel1);
            splitContainer1.Size = new Size(1898, 950);
            splitContainer1.SplitterDistance = 765;
            splitContainer1.TabIndex = 2;
            // 
            // dgvDanhSachCho
            // 
            dgvDanhSachCho.AllowUserToAddRows = false;
            dgvDanhSachCho.AllowUserToDeleteRows = false;
            dgvDanhSachCho.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDanhSachCho.BackgroundColor = SystemColors.Control;
            dgvDanhSachCho.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDanhSachCho.Columns.AddRange(new DataGridViewColumn[] { TenBenhNhan, GioKham, TrangThai });
            dgvDanhSachCho.GridColor = SystemColors.Window;
            dgvDanhSachCho.Location = new Point(25, 146);
            dgvDanhSachCho.Name = "dgvDanhSachCho";
            dgvDanhSachCho.ReadOnly = true;
            dgvDanhSachCho.RowHeadersWidth = 62;
            dgvDanhSachCho.Size = new Size(714, 596);
            dgvDanhSachCho.TabIndex = 2;
            dgvDanhSachCho.CellClick += dgvDanhSachCho_CellClick;
            // 
            // TenBenhNhan
            // 
            TenBenhNhan.DataPropertyName = "TenBenhNhan";
            TenBenhNhan.FillWeight = 130F;
            TenBenhNhan.HeaderText = "Tên Bệnh Nhân";
            TenBenhNhan.MinimumWidth = 8;
            TenBenhNhan.Name = "TenBenhNhan";
            TenBenhNhan.ReadOnly = true;
            // 
            // GioKham
            // 
            GioKham.DataPropertyName = "GioKham";
            GioKham.HeaderText = "Giờ Khám";
            GioKham.MinimumWidth = 8;
            GioKham.Name = "GioKham";
            GioKham.ReadOnly = true;
            // 
            // TrangThai
            // 
            TrangThai.DataPropertyName = "TrangThai";
            TrangThai.FillWeight = 70F;
            TrangThai.HeaderText = "Trạng Thái";
            TrangThai.MinimumWidth = 8;
            TrangThai.Name = "TrangThai";
            TrangThai.ReadOnly = true;
            // 
            // dtpNgayKham
            // 
            dtpNgayKham.Format = DateTimePickerFormat.Short;
            dtpNgayKham.Location = new Point(24, 80);
            dtpNgayKham.Name = "dtpNgayKham";
            dtpNgayKham.Size = new Size(502, 31);
            dtpNgayKham.TabIndex = 1;
            dtpNgayKham.ValueChanged += dtpNgayKham_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.IndianRed;
            label1.Location = new Point(24, 33);
            label1.Name = "label1";
            label1.Size = new Size(193, 30);
            label1.TabIndex = 0;
            label1.Text = "DANH SÁCH CHỜ";
            // 
            // btnThemThuoc
            // 
            btnThemThuoc.BackColor = Color.ForestGreen;
            btnThemThuoc.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThemThuoc.ForeColor = SystemColors.ButtonHighlight;
            btnThemThuoc.Location = new Point(944, 509);
            btnThemThuoc.Name = "btnThemThuoc";
            btnThemThuoc.Size = new Size(77, 56);
            btnThemThuoc.TabIndex = 18;
            btnThemThuoc.Text = "Thêm";
            btnThemThuoc.UseVisualStyleBackColor = false;
            btnThemThuoc.Click += btnThemThuoc_Click;
            // 
            // btnBoThuoc
            // 
            btnBoThuoc.BackColor = Color.IndianRed;
            btnBoThuoc.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBoThuoc.ForeColor = SystemColors.ButtonHighlight;
            btnBoThuoc.Location = new Point(1027, 509);
            btnBoThuoc.Name = "btnBoThuoc";
            btnBoThuoc.Size = new Size(77, 56);
            btnBoThuoc.TabIndex = 17;
            btnBoThuoc.Text = "Bỏ";
            btnBoThuoc.UseVisualStyleBackColor = false;
            btnBoThuoc.Click += btnBoThuoc_Click;
            // 
            // btnThemDichVu
            // 
            btnThemDichVu.BackColor = Color.ForestGreen;
            btnThemDichVu.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThemDichVu.ForeColor = SystemColors.ButtonHighlight;
            btnThemDichVu.Location = new Point(380, 509);
            btnThemDichVu.Name = "btnThemDichVu";
            btnThemDichVu.Size = new Size(77, 56);
            btnThemDichVu.TabIndex = 16;
            btnThemDichVu.Text = "Thêm";
            btnThemDichVu.UseVisualStyleBackColor = false;
            btnThemDichVu.Click += btnThemDichVu_Click;
            // 
            // btnBoDichVu
            // 
            btnBoDichVu.BackColor = Color.IndianRed;
            btnBoDichVu.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBoDichVu.ForeColor = SystemColors.ButtonHighlight;
            btnBoDichVu.Location = new Point(463, 509);
            btnBoDichVu.Name = "btnBoDichVu";
            btnBoDichVu.Size = new Size(77, 56);
            btnBoDichVu.TabIndex = 15;
            btnBoDichVu.Text = "Bỏ";
            btnBoDichVu.UseVisualStyleBackColor = false;
            btnBoDichVu.Click += btnBoDichVu_Click;
            // 
            // txtSoLuong
            // 
            txtSoLuong.Location = new Point(804, 524);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(114, 31);
            txtSoLuong.TabIndex = 14;
            // 
            // dgvKeDonThuoc
            // 
            dgvKeDonThuoc.AllowUserToAddRows = false;
            dgvKeDonThuoc.AllowUserToDeleteRows = false;
            dgvKeDonThuoc.AllowUserToResizeColumns = false;
            dgvKeDonThuoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKeDonThuoc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKeDonThuoc.Columns.AddRange(new DataGridViewColumn[] { TenThuoc, DonViTinh, SoLuong, DonGiaThuoc });
            dgvKeDonThuoc.Location = new Point(573, 576);
            dgvKeDonThuoc.MultiSelect = false;
            dgvKeDonThuoc.Name = "dgvKeDonThuoc";
            dgvKeDonThuoc.ReadOnly = true;
            dgvKeDonThuoc.RowHeadersWidth = 62;
            dgvKeDonThuoc.Size = new Size(542, 283);
            dgvKeDonThuoc.TabIndex = 13;
            // 
            // TenThuoc
            // 
            TenThuoc.DataPropertyName = "TenThuoc";
            TenThuoc.HeaderText = "Tên Thuốc";
            TenThuoc.MinimumWidth = 8;
            TenThuoc.Name = "TenThuoc";
            TenThuoc.ReadOnly = true;
            // 
            // DonViTinh
            // 
            DonViTinh.DataPropertyName = "DonViTinh";
            DonViTinh.HeaderText = "ĐVT";
            DonViTinh.MinimumWidth = 8;
            DonViTinh.Name = "DonViTinh";
            DonViTinh.ReadOnly = true;
            // 
            // SoLuong
            // 
            SoLuong.DataPropertyName = "SoLuong";
            SoLuong.HeaderText = "SL";
            SoLuong.MinimumWidth = 8;
            SoLuong.Name = "SoLuong";
            SoLuong.ReadOnly = true;
            // 
            // DonGiaThuoc
            // 
            DonGiaThuoc.DataPropertyName = "DonGiaThuoc";
            DonGiaThuoc.HeaderText = "Đơn Giá";
            DonGiaThuoc.MinimumWidth = 8;
            DonGiaThuoc.Name = "DonGiaThuoc";
            DonGiaThuoc.ReadOnly = true;
            // 
            // cboKeDonThuoc
            // 
            cboKeDonThuoc.FormattingEnabled = true;
            cboKeDonThuoc.Location = new Point(573, 522);
            cboKeDonThuoc.Name = "cboKeDonThuoc";
            cboKeDonThuoc.Size = new Size(208, 33);
            cboKeDonThuoc.TabIndex = 12;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(804, 494);
            label7.Name = "label7";
            label7.Size = new Size(91, 25);
            label7.TabIndex = 11;
            label7.Text = "Số lượng:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(573, 494);
            label6.Name = "label6";
            label6.Size = new Size(127, 25);
            label6.TabIndex = 11;
            label6.Text = "Kê đơn thuốc:";
            // 
            // dgvChiDinhDichVu
            // 
            dgvChiDinhDichVu.AllowUserToAddRows = false;
            dgvChiDinhDichVu.AllowUserToDeleteRows = false;
            dgvChiDinhDichVu.AllowUserToResizeColumns = false;
            dgvChiDinhDichVu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiDinhDichVu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiDinhDichVu.Columns.AddRange(new DataGridViewColumn[] { TenDichVu, DonGia });
            dgvChiDinhDichVu.Location = new Point(21, 576);
            dgvChiDinhDichVu.MultiSelect = false;
            dgvChiDinhDichVu.Name = "dgvChiDinhDichVu";
            dgvChiDinhDichVu.ReadOnly = true;
            dgvChiDinhDichVu.RowHeadersWidth = 62;
            dgvChiDinhDichVu.Size = new Size(542, 283);
            dgvChiDinhDichVu.TabIndex = 10;
            // 
            // TenDichVu
            // 
            TenDichVu.DataPropertyName = "TenDichVu";
            TenDichVu.HeaderText = "Tên Dịch Vụ";
            TenDichVu.MinimumWidth = 8;
            TenDichVu.Name = "TenDichVu";
            TenDichVu.ReadOnly = true;
            // 
            // DonGia
            // 
            DonGia.DataPropertyName = "DonGia";
            DonGia.HeaderText = "Đơn Giá";
            DonGia.MinimumWidth = 8;
            DonGia.Name = "DonGia";
            DonGia.ReadOnly = true;
            // 
            // cboChiDinhDichVu
            // 
            cboChiDinhDichVu.FormattingEnabled = true;
            cboChiDinhDichVu.Location = new Point(21, 522);
            cboChiDinhDichVu.Name = "cboChiDinhDichVu";
            cboChiDinhDichVu.Size = new Size(315, 33);
            cboChiDinhDichVu.TabIndex = 9;
            // 
            // btnHoanThanh
            // 
            btnHoanThanh.BackColor = Color.ForestGreen;
            btnHoanThanh.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHoanThanh.ForeColor = SystemColors.ButtonHighlight;
            btnHoanThanh.Location = new Point(783, 881);
            btnHoanThanh.Name = "btnHoanThanh";
            btnHoanThanh.Size = new Size(332, 54);
            btnHoanThanh.TabIndex = 8;
            btnHoanThanh.Text = "Hoàn Thành/Lưu";
            btnHoanThanh.UseVisualStyleBackColor = false;
            btnHoanThanh.Click += btnHoanThanh_Click;
            // 
            // btnHuyKham
            // 
            btnHuyKham.BackColor = Color.IndianRed;
            btnHuyKham.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHuyKham.ForeColor = SystemColors.ButtonHighlight;
            btnHuyKham.Location = new Point(21, 881);
            btnHuyKham.Name = "btnHuyKham";
            btnHuyKham.Size = new Size(278, 54);
            btnHuyKham.TabIndex = 7;
            btnHuyKham.Text = "Huỷ Khám";
            btnHuyKham.UseVisualStyleBackColor = false;
            btnHuyKham.Click += btnHuyKham_Click;
            // 
            // txtLoiDan
            // 
            txtLoiDan.Location = new Point(21, 378);
            txtLoiDan.Name = "txtLoiDan";
            txtLoiDan.Size = new Size(1079, 93);
            txtLoiDan.TabIndex = 3;
            txtLoiDan.Text = "";
            // 
            // txtChanDoan
            // 
            txtChanDoan.Location = new Point(21, 223);
            txtChanDoan.Name = "txtChanDoan";
            txtChanDoan.Size = new Size(1079, 111);
            txtChanDoan.TabIndex = 3;
            txtChanDoan.Text = "";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(21, 494);
            label5.Name = "label5";
            label5.Size = new Size(153, 25);
            label5.TabIndex = 1;
            label5.Text = "Chỉ định Dịch Vụ:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(21, 350);
            label4.Name = "label4";
            label4.Size = new Size(171, 25);
            label4.TabIndex = 1;
            label4.Text = "Lời dặn/Đơn thuốc:";
            // 
            // txtTrieuChung
            // 
            txtTrieuChung.Location = new Point(21, 111);
            txtTrieuChung.Multiline = true;
            txtTrieuChung.Name = "txtTrieuChung";
            txtTrieuChung.Size = new Size(1079, 67);
            txtTrieuChung.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(21, 195);
            label3.Name = "label3";
            label3.Size = new Size(201, 25);
            label3.TabIndex = 1;
            label3.Text = "Chuẩn đoán - Kết luận:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(21, 83);
            label2.Name = "label2";
            label2.Size = new Size(193, 25);
            label2.TabIndex = 1;
            label2.Text = "Triệu chứng lâm sàng:";
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightBlue;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lblDangKhamBenhNhan);
            panel1.Location = new Point(73, 13);
            panel1.Name = "panel1";
            panel1.Size = new Size(1006, 69);
            panel1.TabIndex = 0;
            // 
            // lblDangKhamBenhNhan
            // 
            lblDangKhamBenhNhan.AutoSize = true;
            lblDangKhamBenhNhan.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblDangKhamBenhNhan.ForeColor = SystemColors.MenuHighlight;
            lblDangKhamBenhNhan.Location = new Point(12, 0);
            lblDangKhamBenhNhan.Name = "lblDangKhamBenhNhan";
            lblDangKhamBenhNhan.Size = new Size(562, 32);
            lblDangKhamBenhNhan.TabIndex = 0;
            lblDangKhamBenhNhan.Text = "Đang khám: Nguyễn Văn A - Nam - 0987654321";
            // 
            // FrmKhamBenh
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1898, 1050);
            Controls.Add(splitContainer1);
            Controls.Add(btnDong);
            Controls.Add(lblBacSiPhuTrach);
            Name = "FrmKhamBenh";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmKhamBenh";
            Load += FrmKhamBenh_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDanhSachCho).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvKeDonThuoc).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvChiDinhDichVu).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBacSiPhuTrach;
        private Button btnDong;
        private SplitContainer splitContainer1;
        private Label label1;
        private DataGridView dgvDanhSachCho;
        private DateTimePicker dtpNgayKham;
        private Panel panel1;
        private RichTextBox txtChanDoan;
        private TextBox txtTrieuChung;
        private Label label3;
        private Label label2;
        private Label lblDangKhamBenhNhan;
        private RichTextBox txtLoiDan;
        private Label label4;
        private Button btnHoanThanh;
        private Button btnHuyKham;
        private DataGridViewTextBoxColumn TenBenhNhan;
        private DataGridViewTextBoxColumn GioKham;
        private DataGridViewTextBoxColumn TrangThai;
        private Label label5;
        private DataGridView dgvChiDinhDichVu;
        private ComboBox cboChiDinhDichVu;
        private TextBox txtSoLuong;
        private DataGridView dgvKeDonThuoc;
        private ComboBox cboKeDonThuoc;
        private Label label7;
        private Label label6;
        private DataGridViewTextBoxColumn TenDichVu;
        private DataGridViewTextBoxColumn DonGia;
        private DataGridViewTextBoxColumn TenThuoc;
        private DataGridViewTextBoxColumn DonViTinh;
        private DataGridViewTextBoxColumn SoLuong;
        private DataGridViewTextBoxColumn DonGiaThuoc;
        private Button btnThemDichVu;
        private Button btnBoDichVu;
        private Button btnThemThuoc;
        private Button btnBoThuoc;
    }
}