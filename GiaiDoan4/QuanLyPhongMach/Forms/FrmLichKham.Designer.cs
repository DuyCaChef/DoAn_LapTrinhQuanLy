namespace QuanLyPhongMach.Forms
{
    partial class FrmLichKham
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
            gbxBenhNhan = new GroupBox();
            btnLuuBenhNhan = new Button();
            rdbNu = new RadioButton();
            rdbNam = new RadioButton();
            dtbNgaySinh = new DateTimePicker();
            txtDiaChi = new TextBox();
            txtSDT = new TextBox();
            txtHoTen = new TextBox();
            label4 = new Label();
            label2 = new Label();
            label5 = new Label();
            label3 = new Label();
            label1 = new Label();
            gbxLichKham = new GroupBox();
            btnDatLich = new Button();
            cboGioKham = new ComboBox();
            cboBacSi = new ComboBox();
            cboChuyenKhoa = new ComboBox();
            label6 = new Label();
            dtbNgayKham = new DateTimePicker();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            dgvLichKham = new DataGridView();
            MaLich = new DataGridViewTextBoxColumn();
            TenBenhNhan = new DataGridViewTextBoxColumn();
            SDT = new DataGridViewTextBoxColumn();
            BacSi = new DataGridViewTextBoxColumn();
            NgayKham = new DataGridViewTextBoxColumn();
            GioKham = new DataGridViewTextBoxColumn();
            TrangThai = new DataGridViewTextBoxColumn();
            label11 = new Label();
            txtTimKiemLich = new TextBox();
            btnXoaLich = new Button();
            btnSuaLich = new Button();
            label12 = new Label();
            btnLamMoi = new Button();
            gbxBenhNhan.SuspendLayout();
            gbxLichKham.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLichKham).BeginInit();
            SuspendLayout();
            // 
            // btnDong
            // 
            btnDong.BackColor = SystemColors.ButtonFace;
            btnDong.FlatAppearance.BorderSize = 2;
            btnDong.FlatStyle = FlatStyle.Flat;
            btnDong.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDong.ForeColor = Color.Red;
            btnDong.Location = new Point(1587, 15);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(299, 56);
            btnDong.TabIndex = 0;
            btnDong.Text = "Đóng và Quay về Trang chủ";
            btnDong.UseVisualStyleBackColor = false;
            btnDong.Click += btnDong_Click;
            // 
            // gbxBenhNhan
            // 
            gbxBenhNhan.Controls.Add(btnLuuBenhNhan);
            gbxBenhNhan.Controls.Add(rdbNu);
            gbxBenhNhan.Controls.Add(rdbNam);
            gbxBenhNhan.Controls.Add(dtbNgaySinh);
            gbxBenhNhan.Controls.Add(txtDiaChi);
            gbxBenhNhan.Controls.Add(txtSDT);
            gbxBenhNhan.Controls.Add(txtHoTen);
            gbxBenhNhan.Controls.Add(label4);
            gbxBenhNhan.Controls.Add(label2);
            gbxBenhNhan.Controls.Add(label5);
            gbxBenhNhan.Controls.Add(label3);
            gbxBenhNhan.Controls.Add(label1);
            gbxBenhNhan.Location = new Point(19, 77);
            gbxBenhNhan.Name = "gbxBenhNhan";
            gbxBenhNhan.Size = new Size(918, 310);
            gbxBenhNhan.TabIndex = 1;
            gbxBenhNhan.TabStop = false;
            gbxBenhNhan.Text = "Thông tin Bệnh Nhân";
            // 
            // btnLuuBenhNhan
            // 
            btnLuuBenhNhan.BackColor = Color.Green;
            btnLuuBenhNhan.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLuuBenhNhan.ForeColor = SystemColors.ButtonHighlight;
            btnLuuBenhNhan.Location = new Point(604, 227);
            btnLuuBenhNhan.Name = "btnLuuBenhNhan";
            btnLuuBenhNhan.Size = new Size(278, 54);
            btnLuuBenhNhan.TabIndex = 4;
            btnLuuBenhNhan.Text = "Lưu Bệnh Nhân";
            btnLuuBenhNhan.UseVisualStyleBackColor = false;
            btnLuuBenhNhan.Click += btnLuuBenhNhan_Click;
            // 
            // rdbNu
            // 
            rdbNu.AutoSize = true;
            rdbNu.Location = new Point(128, 241);
            rdbNu.Name = "rdbNu";
            rdbNu.Size = new Size(61, 29);
            rdbNu.TabIndex = 3;
            rdbNu.TabStop = true;
            rdbNu.Text = "Nữ";
            rdbNu.UseVisualStyleBackColor = true;
            // 
            // rdbNam
            // 
            rdbNam.AutoSize = true;
            rdbNam.Location = new Point(19, 241);
            rdbNam.Name = "rdbNam";
            rdbNam.Size = new Size(75, 29);
            rdbNam.TabIndex = 3;
            rdbNam.TabStop = true;
            rdbNam.Text = "Nam";
            rdbNam.UseVisualStyleBackColor = true;
            // 
            // dtbNgaySinh
            // 
            dtbNgaySinh.Format = DateTimePickerFormat.Short;
            dtbNgaySinh.Location = new Point(479, 72);
            dtbNgaySinh.Name = "dtbNgaySinh";
            dtbNgaySinh.Size = new Size(403, 31);
            dtbNgaySinh.TabIndex = 2;
            // 
            // txtDiaChi
            // 
            txtDiaChi.Location = new Point(478, 156);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(404, 31);
            txtDiaChi.TabIndex = 4;
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(19, 72);
            txtSDT.Name = "txtSDT";
            txtSDT.PlaceholderText = "Nhập SĐT để xem thông tin Bệnh Nhân";
            txtSDT.Size = new Size(404, 31);
            txtSDT.TabIndex = 1;
            txtSDT.KeyDown += txtSDT_KeyDown;
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(19, 156);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(404, 31);
            txtHoTen.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(478, 128);
            label4.Name = "label4";
            label4.Size = new Size(69, 25);
            label4.TabIndex = 0;
            label4.Text = "Địa chỉ:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(478, 44);
            label2.Name = "label2";
            label2.Size = new Size(95, 25);
            label2.TabIndex = 0;
            label2.Text = "Ngày sinh:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(19, 213);
            label5.Name = "label5";
            label5.Size = new Size(82, 25);
            label5.TabIndex = 0;
            label5.Text = "Giới tính:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 44);
            label3.Name = "label3";
            label3.Size = new Size(121, 25);
            label3.TabIndex = 0;
            label3.Text = "Số điện thoại:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 128);
            label1.Name = "label1";
            label1.Size = new Size(94, 25);
            label1.TabIndex = 0;
            label1.Text = "Họ và Tên:";
            // 
            // gbxLichKham
            // 
            gbxLichKham.Controls.Add(btnDatLich);
            gbxLichKham.Controls.Add(cboGioKham);
            gbxLichKham.Controls.Add(cboBacSi);
            gbxLichKham.Controls.Add(cboChuyenKhoa);
            gbxLichKham.Controls.Add(label6);
            gbxLichKham.Controls.Add(dtbNgayKham);
            gbxLichKham.Controls.Add(label7);
            gbxLichKham.Controls.Add(label8);
            gbxLichKham.Controls.Add(label9);
            gbxLichKham.Location = new Point(953, 77);
            gbxLichKham.Name = "gbxLichKham";
            gbxLichKham.Size = new Size(926, 310);
            gbxLichKham.TabIndex = 2;
            gbxLichKham.TabStop = false;
            gbxLichKham.Text = "Thông tin Lịch Khám";
            // 
            // btnDatLich
            // 
            btnDatLich.BackColor = Color.RoyalBlue;
            btnDatLich.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDatLich.ForeColor = SystemColors.ButtonHighlight;
            btnDatLich.Location = new Point(618, 227);
            btnDatLich.Name = "btnDatLich";
            btnDatLich.Size = new Size(278, 54);
            btnDatLich.TabIndex = 5;
            btnDatLich.Text = "Đặt Lịch";
            btnDatLich.UseVisualStyleBackColor = false;
            btnDatLich.Click += btnDatLich_Click;
            // 
            // cboGioKham
            // 
            cboGioKham.FormattingEnabled = true;
            cboGioKham.Location = new Point(492, 154);
            cboGioKham.Name = "cboGioKham";
            cboGioKham.Size = new Size(404, 33);
            cboGioKham.TabIndex = 8;
            // 
            // cboBacSi
            // 
            cboBacSi.FormattingEnabled = true;
            cboBacSi.Location = new Point(492, 76);
            cboBacSi.Name = "cboBacSi";
            cboBacSi.Size = new Size(404, 33);
            cboBacSi.TabIndex = 6;
            // 
            // cboChuyenKhoa
            // 
            cboChuyenKhoa.FormattingEnabled = true;
            cboChuyenKhoa.Location = new Point(33, 76);
            cboChuyenKhoa.Name = "cboChuyenKhoa";
            cboChuyenKhoa.Size = new Size(404, 33);
            cboChuyenKhoa.TabIndex = 5;
            cboChuyenKhoa.SelectedIndexChanged += cboChuyenKhoa_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(33, 44);
            label6.Name = "label6";
            label6.Size = new Size(119, 25);
            label6.TabIndex = 0;
            label6.Text = "Chuyên khoa:";
            // 
            // dtbNgayKham
            // 
            dtbNgayKham.Format = DateTimePickerFormat.Short;
            dtbNgayKham.Location = new Point(33, 154);
            dtbNgayKham.Name = "dtbNgayKham";
            dtbNgayKham.Size = new Size(404, 31);
            dtbNgayKham.TabIndex = 7;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(33, 128);
            label7.Name = "label7";
            label7.Size = new Size(107, 25);
            label7.TabIndex = 0;
            label7.Text = "Ngày khám:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(492, 44);
            label8.Name = "label8";
            label8.Size = new Size(60, 25);
            label8.TabIndex = 0;
            label8.Text = "Bác sĩ:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(492, 128);
            label9.Name = "label9";
            label9.Size = new Size(92, 25);
            label9.TabIndex = 0;
            label9.Text = "Giờ khám:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = SystemColors.Control;
            label10.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = SystemColors.MenuHighlight;
            label10.Location = new Point(19, 405);
            label10.Name = "label10";
            label10.Size = new Size(295, 32);
            label10.TabIndex = 3;
            label10.Text = "DANH SÁCH LỊCH KHÁM:";
            // 
            // dgvLichKham
            // 
            dgvLichKham.AllowUserToAddRows = false;
            dgvLichKham.AllowUserToDeleteRows = false;
            dgvLichKham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLichKham.BackgroundColor = SystemColors.ControlLight;
            dgvLichKham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLichKham.Columns.AddRange(new DataGridViewColumn[] { MaLich, TenBenhNhan, SDT, BacSi, NgayKham, GioKham, TrangThai });
            dgvLichKham.Location = new Point(19, 503);
            dgvLichKham.Name = "dgvLichKham";
            dgvLichKham.ReadOnly = true;
            dgvLichKham.RowHeadersWidth = 62;
            dgvLichKham.Size = new Size(1860, 441);
            dgvLichKham.TabIndex = 4;
            dgvLichKham.CellClick += dgvLichKham_CellClick;
            // 
            // MaLich
            // 
            MaLich.DataPropertyName = "MaLich";
            MaLich.FillWeight = 50F;
            MaLich.HeaderText = "Mã Lịch";
            MaLich.MinimumWidth = 8;
            MaLich.Name = "MaLich";
            MaLich.ReadOnly = true;
            // 
            // TenBenhNhan
            // 
            TenBenhNhan.DataPropertyName = "TenBenhNhan";
            TenBenhNhan.FillWeight = 150F;
            TenBenhNhan.HeaderText = "Tên Bệnh Nhân";
            TenBenhNhan.MinimumWidth = 8;
            TenBenhNhan.Name = "TenBenhNhan";
            TenBenhNhan.ReadOnly = true;
            // 
            // SDT
            // 
            SDT.DataPropertyName = "SDT";
            SDT.FillWeight = 80F;
            SDT.HeaderText = "SĐT";
            SDT.MinimumWidth = 8;
            SDT.Name = "SDT";
            SDT.ReadOnly = true;
            // 
            // BacSi
            // 
            BacSi.DataPropertyName = "BacSi";
            BacSi.FillWeight = 150F;
            BacSi.HeaderText = "Bác Sĩ";
            BacSi.MinimumWidth = 8;
            BacSi.Name = "BacSi";
            BacSi.ReadOnly = true;
            // 
            // NgayKham
            // 
            NgayKham.DataPropertyName = "NgayKham";
            NgayKham.HeaderText = "Ngày Khám";
            NgayKham.MinimumWidth = 8;
            NgayKham.Name = "NgayKham";
            NgayKham.ReadOnly = true;
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
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(23, 458);
            label11.Name = "label11";
            label11.Size = new Size(97, 25);
            label11.TabIndex = 5;
            label11.Text = "Lọc nhanh:";
            // 
            // txtTimKiemLich
            // 
            txtTimKiemLich.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTimKiemLich.Location = new Point(121, 452);
            txtTimKiemLich.Name = "txtTimKiemLich";
            txtTimKiemLich.PlaceholderText = "Nhập tên hoặc SĐT...";
            txtTimKiemLich.Size = new Size(445, 34);
            txtTimKiemLich.TabIndex = 6;
            txtTimKiemLich.TextChanged += txtTimKiemLich_TextChanged;
            // 
            // btnXoaLich
            // 
            btnXoaLich.BackColor = Color.IndianRed;
            btnXoaLich.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXoaLich.ForeColor = SystemColors.ButtonHighlight;
            btnXoaLich.Location = new Point(1571, 418);
            btnXoaLich.Name = "btnXoaLich";
            btnXoaLich.Size = new Size(278, 54);
            btnXoaLich.TabIndex = 6;
            btnXoaLich.Text = "Huỷ Lịch (Xoá)";
            btnXoaLich.UseVisualStyleBackColor = false;
            btnXoaLich.Click += btnXoaLich_Click;
            // 
            // btnSuaLich
            // 
            btnSuaLich.BackColor = Color.LightSkyBlue;
            btnSuaLich.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSuaLich.ForeColor = SystemColors.ButtonHighlight;
            btnSuaLich.Location = new Point(1259, 418);
            btnSuaLich.Name = "btnSuaLich";
            btnSuaLich.Size = new Size(278, 54);
            btnSuaLich.TabIndex = 7;
            btnSuaLich.Text = "Cập Nhật (Sửa)";
            btnSuaLich.UseVisualStyleBackColor = false;
            btnSuaLich.Click += btnSuaLich_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label12.Location = new Point(23, 969);
            label12.Name = "label12";
            label12.Size = new Size(763, 25);
            label12.TabIndex = 8;
            label12.Text = "*Mẹo: Click chọn một dòng trong bảng để xem thông tin chi tiết và thực hiện thao tác Sửa/Xoá.\r\n";
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.FromArgb(192, 192, 0);
            btnLamMoi.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLamMoi.ForeColor = SystemColors.ButtonHighlight;
            btnLamMoi.Location = new Point(19, 15);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(278, 54);
            btnLamMoi.TabIndex = 5;
            btnLamMoi.Text = "Làm Mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // FrmLichKham
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1898, 1024);
            Controls.Add(btnLamMoi);
            Controls.Add(label12);
            Controls.Add(btnSuaLich);
            Controls.Add(btnXoaLich);
            Controls.Add(txtTimKiemLich);
            Controls.Add(label11);
            Controls.Add(dgvLichKham);
            Controls.Add(label10);
            Controls.Add(gbxLichKham);
            Controls.Add(gbxBenhNhan);
            Controls.Add(btnDong);
            Name = "FrmLichKham";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmLichKham";
            Load += FrmLichKham_Load;
            gbxBenhNhan.ResumeLayout(false);
            gbxBenhNhan.PerformLayout();
            gbxLichKham.ResumeLayout(false);
            gbxLichKham.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLichKham).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnDong;
        private GroupBox gbxBenhNhan;
        private GroupBox gbxLichKham;
        private TextBox txtHoTen;
        private Label label1;
        private TextBox txtDiaChi;
        private TextBox txtSDT;
        private Label label4;
        private Label label2;
        private Label label3;
        private DateTimePicker dtbNgaySinh;
        private Button btnLuuBenhNhan;
        private RadioButton rdbNu;
        private RadioButton rdbNam;
        private Label label5;
        private ComboBox cboBacSi;
        private ComboBox cboChuyenKhoa;
        private Label label6;
        private DateTimePicker dtbNgayKham;
        private Label label7;
        private Label label8;
        private Label label9;
        private ComboBox cboGioKham;
        private Label label10;
        private DataGridView dgvLichKham;
        private Button btnDatLich;
        private DataGridViewTextBoxColumn MaLich;
        private DataGridViewTextBoxColumn TenBenhNhan;
        private DataGridViewTextBoxColumn SDT;
        private DataGridViewTextBoxColumn BacSi;
        private DataGridViewTextBoxColumn NgayKham;
        private DataGridViewTextBoxColumn GioKham;
        private DataGridViewTextBoxColumn TrangThai;
        private Label label11;
        private TextBox txtTimKiemLich;
        private Button btnXoaLich;
        private Button btnSuaLich;
        private Label label12;
        private Button btnLamMoi;
    }
}