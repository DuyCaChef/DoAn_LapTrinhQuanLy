namespace QuanLyPhongMach.Forms
{
    partial class FrmKhachHang
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
            tabControl1 = new TabControl();
            tpgDatLichMoi = new TabPage();
            splitContainer1 = new SplitContainer();
            btnXacNhanDatLich = new Button();
            txtMoTaTrieuChung = new TextBox();
            dtpNgayKham = new DateTimePicker();
            cboChonBacSi = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            cboChuyenKhoa = new ComboBox();
            label2 = new Label();
            label7 = new Label();
            label1 = new Label();
            btnDangXuat = new Button();
            lblMaBenhNhan = new Label();
            lblTenBenhNhan = new Label();
            dgvLichKham = new DataGridView();
            NgayKham = new DataGridViewTextBoxColumn();
            BacSi = new DataGridViewTextBoxColumn();
            TrangThai = new DataGridViewTextBoxColumn();
            label5 = new Label();
            tpgLichSuKham = new TabPage();
            dgvLichSuKham = new DataGridView();
            NgayKhamLichSu = new DataGridViewTextBoxColumn();
            BacSiPhuTrach = new DataGridViewTextBoxColumn();
            ChuyenKhoa = new DataGridViewTextBoxColumn();
            KetLuan = new DataGridViewTextBoxColumn();
            label6 = new Label();
            tpgHoSoCaNhan = new TabPage();
            splitContainer2 = new SplitContainer();
            btnCapNhat = new Button();
            dtpNgaySinh = new DateTimePicker();
            txtDiaChi = new TextBox();
            txtSDT = new TextBox();
            cboGioiTinh = new ComboBox();
            txtHoTen = new TextBox();
            label12 = new Label();
            label13 = new Label();
            label10 = new Label();
            label11 = new Label();
            label8 = new Label();
            label9 = new Label();
            btnDoiMatKhau = new Button();
            label14 = new Label();
            txtMatKhauMoi = new TextBox();
            label16 = new Label();
            btnMatKhauCu = new TextBox();
            label15 = new Label();
            btnDong = new Button();
            ckbHienMatKhau = new CheckBox();
            tabControl1.SuspendLayout();
            tpgDatLichMoi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLichKham).BeginInit();
            tpgLichSuKham.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLichSuKham).BeginInit();
            tpgHoSoCaNhan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tpgDatLichMoi);
            tabControl1.Controls.Add(tpgLichSuKham);
            tabControl1.Controls.Add(tpgHoSoCaNhan);
            tabControl1.Dock = DockStyle.Bottom;
            tabControl1.Location = new Point(0, 84);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1898, 940);
            tabControl1.TabIndex = 0;
            // 
            // tpgDatLichMoi
            // 
            tpgDatLichMoi.Controls.Add(splitContainer1);
            tpgDatLichMoi.Location = new Point(4, 34);
            tpgDatLichMoi.Name = "tpgDatLichMoi";
            tpgDatLichMoi.Padding = new Padding(3);
            tpgDatLichMoi.Size = new Size(1890, 902);
            tpgDatLichMoi.TabIndex = 0;
            tpgDatLichMoi.Text = "Đặt lịch mới";
            tpgDatLichMoi.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(3, 3);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(btnXacNhanDatLich);
            splitContainer1.Panel1.Controls.Add(txtMoTaTrieuChung);
            splitContainer1.Panel1.Controls.Add(dtpNgayKham);
            splitContainer1.Panel1.Controls.Add(cboChonBacSi);
            splitContainer1.Panel1.Controls.Add(label4);
            splitContainer1.Panel1.Controls.Add(label3);
            splitContainer1.Panel1.Controls.Add(cboChuyenKhoa);
            splitContainer1.Panel1.Controls.Add(label2);
            splitContainer1.Panel1.Controls.Add(label7);
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(btnDangXuat);
            splitContainer1.Panel1.Controls.Add(lblMaBenhNhan);
            splitContainer1.Panel1.Controls.Add(lblTenBenhNhan);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dgvLichKham);
            splitContainer1.Panel2.Controls.Add(label5);
            splitContainer1.Size = new Size(1884, 896);
            splitContainer1.SplitterDistance = 734;
            splitContainer1.TabIndex = 0;
            // 
            // btnXacNhanDatLich
            // 
            btnXacNhanDatLich.BackColor = Color.DarkGreen;
            btnXacNhanDatLich.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXacNhanDatLich.ForeColor = SystemColors.ButtonHighlight;
            btnXacNhanDatLich.Location = new Point(197, 816);
            btnXacNhanDatLich.Name = "btnXacNhanDatLich";
            btnXacNhanDatLich.Size = new Size(281, 58);
            btnXacNhanDatLich.TabIndex = 15;
            btnXacNhanDatLich.Text = "Xác nhận đặt lịch";
            btnXacNhanDatLich.UseVisualStyleBackColor = false;
            // 
            // txtMoTaTrieuChung
            // 
            txtMoTaTrieuChung.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMoTaTrieuChung.Location = new Point(44, 654);
            txtMoTaTrieuChung.Multiline = true;
            txtMoTaTrieuChung.Name = "txtMoTaTrieuChung";
            txtMoTaTrieuChung.Size = new Size(641, 138);
            txtMoTaTrieuChung.TabIndex = 14;
            // 
            // dtpNgayKham
            // 
            dtpNgayKham.CalendarFont = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpNgayKham.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpNgayKham.Format = DateTimePickerFormat.Short;
            dtpNgayKham.Location = new Point(44, 533);
            dtpNgayKham.Name = "dtpNgayKham";
            dtpNgayKham.Size = new Size(641, 34);
            dtpNgayKham.TabIndex = 13;
            // 
            // cboChonBacSi
            // 
            cboChonBacSi.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboChonBacSi.FormattingEnabled = true;
            cboChonBacSi.Location = new Point(44, 420);
            cboChonBacSi.Name = "cboChonBacSi";
            cboChonBacSi.Size = new Size(641, 36);
            cboChonBacSi.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(44, 606);
            label4.Name = "label4";
            label4.Size = new Size(263, 28);
            label4.TabIndex = 11;
            label4.Text = "Mô tả triệu chứng (nếu có):";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(44, 489);
            label3.Name = "label3";
            label3.Size = new Size(172, 28);
            label3.TabIndex = 11;
            label3.Text = "Chọn ngày khám:";
            // 
            // cboChuyenKhoa
            // 
            cboChuyenKhoa.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboChuyenKhoa.FormattingEnabled = true;
            cboChuyenKhoa.Location = new Point(44, 303);
            cboChuyenKhoa.Name = "cboChuyenKhoa";
            cboChuyenKhoa.Size = new Size(641, 36);
            cboChuyenKhoa.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(44, 371);
            label2.Name = "label2";
            label2.Size = new Size(287, 28);
            label2.TabIndex = 11;
            label2.Text = "Chọn bác sĩ (không bắt buộc):";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(44, 254);
            label7.Name = "label7";
            label7.Size = new Size(188, 28);
            label7.TabIndex = 11;
            label7.Text = "Chọn chuyên khoa:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DarkGreen;
            label1.Location = new Point(44, 204);
            label1.Name = "label1";
            label1.Size = new Size(234, 32);
            label1.TabIndex = 10;
            label1.Text = "Đăng ký khám bệnh";
            // 
            // btnDangXuat
            // 
            btnDangXuat.BackColor = Color.IndianRed;
            btnDangXuat.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDangXuat.ForeColor = SystemColors.ButtonHighlight;
            btnDangXuat.Location = new Point(197, 132);
            btnDangXuat.Name = "btnDangXuat";
            btnDangXuat.Size = new Size(281, 46);
            btnDangXuat.TabIndex = 9;
            btnDangXuat.Text = "Đăng xuất";
            btnDangXuat.UseVisualStyleBackColor = false;
            // 
            // lblMaBenhNhan
            // 
            lblMaBenhNhan.AutoSize = true;
            lblMaBenhNhan.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblMaBenhNhan.ForeColor = SystemColors.HotTrack;
            lblMaBenhNhan.Location = new Point(241, 86);
            lblMaBenhNhan.Name = "lblMaBenhNhan";
            lblMaBenhNhan.Size = new Size(185, 32);
            lblMaBenhNhan.TabIndex = 1;
            lblMaBenhNhan.Text = "Mã BN: KH0012";
            // 
            // lblTenBenhNhan
            // 
            lblTenBenhNhan.AutoSize = true;
            lblTenBenhNhan.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblTenBenhNhan.ForeColor = SystemColors.HotTrack;
            lblTenBenhNhan.Location = new Point(150, 37);
            lblTenBenhNhan.Name = "lblTenBenhNhan";
            lblTenBenhNhan.Size = new Size(396, 38);
            lblTenBenhNhan.TabIndex = 0;
            lblTenBenhNhan.Text = "Bệnh Nhân: Nguyễn Tuấn Hải";
            // 
            // dgvLichKham
            // 
            dgvLichKham.AllowUserToAddRows = false;
            dgvLichKham.AllowUserToDeleteRows = false;
            dgvLichKham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLichKham.BackgroundColor = SystemColors.ButtonFace;
            dgvLichKham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLichKham.Columns.AddRange(new DataGridViewColumn[] { NgayKham, BacSi, TrangThai });
            dgvLichKham.Location = new Point(39, 141);
            dgvLichKham.Name = "dgvLichKham";
            dgvLichKham.ReadOnly = true;
            dgvLichKham.RowHeadersWidth = 62;
            dgvLichKham.Size = new Size(1075, 561);
            dgvLichKham.TabIndex = 11;
            // 
            // NgayKham
            // 
            NgayKham.DataPropertyName = "NgayKham";
            NgayKham.FillWeight = 120F;
            NgayKham.HeaderText = "Ngày khám";
            NgayKham.MinimumWidth = 8;
            NgayKham.Name = "NgayKham";
            NgayKham.ReadOnly = true;
            // 
            // BacSi
            // 
            BacSi.DataPropertyName = "BacSi";
            BacSi.FillWeight = 130F;
            BacSi.HeaderText = "Bác sĩ";
            BacSi.MinimumWidth = 8;
            BacSi.Name = "BacSi";
            BacSi.ReadOnly = true;
            // 
            // TrangThai
            // 
            TrangThai.DataPropertyName = "TrangThai";
            TrangThai.FillWeight = 50F;
            TrangThai.HeaderText = "Trạng Thái";
            TrangThai.MinimumWidth = 8;
            TrangThai.Name = "TrangThai";
            TrangThai.ReadOnly = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.RoyalBlue;
            label5.Location = new Point(54, 86);
            label5.Name = "label5";
            label5.Size = new Size(299, 32);
            label5.TabIndex = 10;
            label5.Text = "Lịch khám sắp tới của bạn";
            // 
            // tpgLichSuKham
            // 
            tpgLichSuKham.Controls.Add(dgvLichSuKham);
            tpgLichSuKham.Controls.Add(label6);
            tpgLichSuKham.Location = new Point(4, 34);
            tpgLichSuKham.Name = "tpgLichSuKham";
            tpgLichSuKham.Padding = new Padding(3);
            tpgLichSuKham.Size = new Size(1890, 902);
            tpgLichSuKham.TabIndex = 1;
            tpgLichSuKham.Text = "Lịch sử khám";
            tpgLichSuKham.UseVisualStyleBackColor = true;
            // 
            // dgvLichSuKham
            // 
            dgvLichSuKham.AllowUserToAddRows = false;
            dgvLichSuKham.AllowUserToDeleteRows = false;
            dgvLichSuKham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLichSuKham.BackgroundColor = SystemColors.ButtonFace;
            dgvLichSuKham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLichSuKham.Columns.AddRange(new DataGridViewColumn[] { NgayKhamLichSu, BacSiPhuTrach, ChuyenKhoa, KetLuan });
            dgvLichSuKham.Location = new Point(130, 137);
            dgvLichSuKham.Name = "dgvLichSuKham";
            dgvLichSuKham.ReadOnly = true;
            dgvLichSuKham.RowHeadersWidth = 62;
            dgvLichSuKham.Size = new Size(1646, 553);
            dgvLichSuKham.TabIndex = 11;
            // 
            // NgayKhamLichSu
            // 
            NgayKhamLichSu.DataPropertyName = "NgayKhamLichSu";
            NgayKhamLichSu.FillWeight = 70F;
            NgayKhamLichSu.HeaderText = "Ngày Khám";
            NgayKhamLichSu.MinimumWidth = 8;
            NgayKhamLichSu.Name = "NgayKhamLichSu";
            NgayKhamLichSu.ReadOnly = true;
            // 
            // BacSiPhuTrach
            // 
            BacSiPhuTrach.DataPropertyName = "BacSiPhuTrach";
            BacSiPhuTrach.FillWeight = 80F;
            BacSiPhuTrach.HeaderText = "Bác Sĩ Phụ Trách";
            BacSiPhuTrach.MinimumWidth = 8;
            BacSiPhuTrach.Name = "BacSiPhuTrach";
            BacSiPhuTrach.ReadOnly = true;
            // 
            // ChuyenKhoa
            // 
            ChuyenKhoa.DataPropertyName = "ChuyenKhoa";
            ChuyenKhoa.FillWeight = 80F;
            ChuyenKhoa.HeaderText = "Chuyên Khoa";
            ChuyenKhoa.MinimumWidth = 8;
            ChuyenKhoa.Name = "ChuyenKhoa";
            ChuyenKhoa.ReadOnly = true;
            // 
            // KetLuan
            // 
            KetLuan.DataPropertyName = "KetLuan";
            KetLuan.FillWeight = 200F;
            KetLuan.HeaderText = "Kết luận/Chuẩn đoán";
            KetLuan.MinimumWidth = 8;
            KetLuan.Name = "KetLuan";
            KetLuan.ReadOnly = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.RoyalBlue;
            label6.Location = new Point(747, 75);
            label6.Name = "label6";
            label6.Size = new Size(385, 48);
            label6.TabIndex = 10;
            label6.Text = "LỊCH SỬ KHÁM BỆNH";
            // 
            // tpgHoSoCaNhan
            // 
            tpgHoSoCaNhan.Controls.Add(splitContainer2);
            tpgHoSoCaNhan.Location = new Point(4, 34);
            tpgHoSoCaNhan.Name = "tpgHoSoCaNhan";
            tpgHoSoCaNhan.Size = new Size(1890, 902);
            tpgHoSoCaNhan.TabIndex = 2;
            tpgHoSoCaNhan.Text = "Hồ sơ cá nhân";
            tpgHoSoCaNhan.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(btnCapNhat);
            splitContainer2.Panel1.Controls.Add(dtpNgaySinh);
            splitContainer2.Panel1.Controls.Add(txtDiaChi);
            splitContainer2.Panel1.Controls.Add(txtSDT);
            splitContainer2.Panel1.Controls.Add(cboGioiTinh);
            splitContainer2.Panel1.Controls.Add(txtHoTen);
            splitContainer2.Panel1.Controls.Add(label12);
            splitContainer2.Panel1.Controls.Add(label13);
            splitContainer2.Panel1.Controls.Add(label10);
            splitContainer2.Panel1.Controls.Add(label11);
            splitContainer2.Panel1.Controls.Add(label8);
            splitContainer2.Panel1.Controls.Add(label9);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(ckbHienMatKhau);
            splitContainer2.Panel2.Controls.Add(btnDoiMatKhau);
            splitContainer2.Panel2.Controls.Add(label14);
            splitContainer2.Panel2.Controls.Add(txtMatKhauMoi);
            splitContainer2.Panel2.Controls.Add(label16);
            splitContainer2.Panel2.Controls.Add(btnMatKhauCu);
            splitContainer2.Panel2.Controls.Add(label15);
            splitContainer2.Size = new Size(1890, 902);
            splitContainer2.SplitterDistance = 688;
            splitContainer2.TabIndex = 0;
            // 
            // btnCapNhat
            // 
            btnCapNhat.BackColor = Color.MediumBlue;
            btnCapNhat.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCapNhat.ForeColor = SystemColors.ButtonHighlight;
            btnCapNhat.Location = new Point(184, 712);
            btnCapNhat.Name = "btnCapNhat";
            btnCapNhat.Size = new Size(281, 58);
            btnCapNhat.TabIndex = 15;
            btnCapNhat.Text = "Cập nhật thông tin";
            btnCapNhat.UseVisualStyleBackColor = false;
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.CalendarFont = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpNgaySinh.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpNgaySinh.Format = DateTimePickerFormat.Short;
            dtpNgaySinh.Location = new Point(47, 263);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(585, 34);
            dtpNgaySinh.TabIndex = 16;
            // 
            // txtDiaChi
            // 
            txtDiaChi.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDiaChi.Location = new Point(47, 630);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(585, 34);
            txtDiaChi.TabIndex = 12;
            // 
            // txtSDT
            // 
            txtSDT.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSDT.Location = new Point(47, 385);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(585, 34);
            txtSDT.TabIndex = 12;
            // 
            // cboGioiTinh
            // 
            cboGioiTinh.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboGioiTinh.FormattingEnabled = true;
            cboGioiTinh.Location = new Point(47, 507);
            cboGioiTinh.Name = "cboGioiTinh";
            cboGioiTinh.Size = new Size(585, 36);
            cboGioiTinh.TabIndex = 12;
            // 
            // txtHoTen
            // 
            txtHoTen.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtHoTen.Location = new Point(47, 154);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(585, 34);
            txtHoTen.TabIndex = 12;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(47, 455);
            label12.Name = "label12";
            label12.Size = new Size(99, 28);
            label12.TabIndex = 11;
            label12.Text = "Giới Tính:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.Location = new Point(47, 583);
            label13.Name = "label13";
            label13.Size = new Size(152, 28);
            label13.TabIndex = 11;
            label13.Text = "Địa chỉ hiện tại:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(47, 218);
            label10.Name = "label10";
            label10.Size = new Size(110, 28);
            label10.TabIndex = 11;
            label10.Text = "Ngày Sinh:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(47, 338);
            label11.Name = "label11";
            label11.Size = new Size(339, 28);
            label11.TabIndex = 11;
            label11.Text = "Số điện thoại (dùng để đăng nhập):";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.DarkGreen;
            label8.Location = new Point(47, 51);
            label8.Name = "label8";
            label8.Size = new Size(212, 32);
            label8.TabIndex = 10;
            label8.Text = "Thông tin cá nhân";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(47, 107);
            label9.Name = "label9";
            label9.Size = new Size(108, 28);
            label9.TabIndex = 11;
            label9.Text = "Họ và Tên:";
            // 
            // btnDoiMatKhau
            // 
            btnDoiMatKhau.BackColor = Color.IndianRed;
            btnDoiMatKhau.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDoiMatKhau.ForeColor = SystemColors.ButtonHighlight;
            btnDoiMatKhau.Location = new Point(481, 374);
            btnDoiMatKhau.Name = "btnDoiMatKhau";
            btnDoiMatKhau.Size = new Size(281, 58);
            btnDoiMatKhau.TabIndex = 15;
            btnDoiMatKhau.Text = "Xác nhận đổi";
            btnDoiMatKhau.UseVisualStyleBackColor = false;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.ForeColor = Color.IndianRed;
            label14.Location = new Point(490, 51);
            label14.Name = "label14";
            label14.Size = new Size(272, 32);
            label14.TabIndex = 10;
            label14.Text = "Đổi mật khẩu tài khoản";
            // 
            // txtMatKhauMoi
            // 
            txtMatKhauMoi.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMatKhauMoi.Location = new Point(334, 263);
            txtMatKhauMoi.Name = "txtMatKhauMoi";
            txtMatKhauMoi.PasswordChar = '*';
            txtMatKhauMoi.PlaceholderText = "Nhập mật khẩu mới";
            txtMatKhauMoi.Size = new Size(585, 34);
            txtMatKhauMoi.TabIndex = 12;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label16.Location = new Point(334, 216);
            label16.Name = "label16";
            label16.Size = new Size(199, 28);
            label16.TabIndex = 11;
            label16.Text = "Nhập mật khẩu mới:";
            // 
            // btnMatKhauCu
            // 
            btnMatKhauCu.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnMatKhauCu.Location = new Point(334, 154);
            btnMatKhauCu.Name = "btnMatKhauCu";
            btnMatKhauCu.PasswordChar = '*';
            btnMatKhauCu.PlaceholderText = "Nhập mật khẩu cũ";
            btnMatKhauCu.Size = new Size(585, 34);
            btnMatKhauCu.TabIndex = 12;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label15.Location = new Point(334, 107);
            label15.Name = "label15";
            label15.Size = new Size(185, 28);
            label15.TabIndex = 11;
            label15.Text = "Nhập mật khẩu cũ:";
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
            btnDong.TabIndex = 2;
            btnDong.Text = "Đóng và Quay về Trang chủ";
            btnDong.UseVisualStyleBackColor = false;
            // 
            // ckbHienMatKhau
            // 
            ckbHienMatKhau.AutoSize = true;
            ckbHienMatKhau.Location = new Point(334, 321);
            ckbHienMatKhau.Name = "ckbHienMatKhau";
            ckbHienMatKhau.Size = new Size(153, 29);
            ckbHienMatKhau.TabIndex = 16;
            ckbHienMatKhau.Text = "Hiện mật khẩu";
            ckbHienMatKhau.UseVisualStyleBackColor = true;
            // 
            // FrmKhachHang
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1898, 1024);
            Controls.Add(btnDong);
            Controls.Add(tabControl1);
            Name = "FrmKhachHang";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmKhachHang";
            tabControl1.ResumeLayout(false);
            tpgDatLichMoi.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvLichKham).EndInit();
            tpgLichSuKham.ResumeLayout(false);
            tpgLichSuKham.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLichSuKham).EndInit();
            tpgHoSoCaNhan.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel1.PerformLayout();
            splitContainer2.Panel2.ResumeLayout(false);
            splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tpgDatLichMoi;
        private TabPage tpgLichSuKham;
        private Button btnDong;
        private TabPage tpgHoSoCaNhan;
        private SplitContainer splitContainer1;
        private Label lblTenBenhNhan;
        private Label lblMaBenhNhan;
        private Label label1;
        private Button btnDangXuat;
        private Label label7;
        private DateTimePicker dtpNgayKham;
        private ComboBox cboChonBacSi;
        private Label label3;
        private ComboBox cboChuyenKhoa;
        private Label label2;
        private Label label4;
        private TextBox txtMoTaTrieuChung;
        private Button btnXacNhanDatLich;
        private DataGridView dgvLichKham;
        private Label label5;
        private DataGridViewTextBoxColumn NgayKham;
        private DataGridViewTextBoxColumn BacSi;
        private DataGridViewTextBoxColumn TrangThai;
        private Label label6;
        private DataGridView dgvLichSuKham;
        private DataGridViewTextBoxColumn NgayKhamLichSu;
        private DataGridViewTextBoxColumn BacSiPhuTrach;
        private DataGridViewTextBoxColumn ChuyenKhoa;
        private DataGridViewTextBoxColumn KetLuan;
        private SplitContainer splitContainer2;
        private Label label8;
        private DateTimePicker dtpNgaySinh;
        private TextBox txtHoTen;
        private Label label10;
        private Label label9;
        private TextBox txtSDT;
        private Label label12;
        private Label label11;
        private TextBox txtDiaChi;
        private ComboBox cboGioiTinh;
        private Label label13;
        private Button btnCapNhat;
        private Label label14;
        private TextBox btnMatKhauCu;
        private Label label15;
        private Button btnDoiMatKhau;
        private TextBox txtMatKhauMoi;
        private Label label16;
        private CheckBox ckbHienMatKhau;
    }
}