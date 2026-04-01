namespace QuanLyPhongMach.Forms
{
    partial class FrmAdmin
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
            tpgQuanLyTaiKhoan = new TabPage();
            splitContainer1 = new SplitContainer();
            ckbHienMatKhau = new CheckBox();
            btnXoaTaiKhoan = new Button();
            btnKhoaTaiKhoan = new Button();
            btnSuaTaiKhoan = new Button();
            btnThemTaiKhoan = new Button();
            ckbTrangThai = new CheckBox();
            cboVaiTro = new ComboBox();
            txtMatKhau = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            txtTenDangNhap = new TextBox();
            label2 = new Label();
            label1 = new Label();
            dgvTaiKhoan = new DataGridView();
            btnTimKiemTaiKhoan = new Button();
            txtTimKiemTaiKhoan = new TextBox();
            label6 = new Label();
            label7 = new Label();
            tpgQuanLyNhanSu = new TabPage();
            splitContainer2 = new SplitContainer();
            cboChuyenKhoa = new ComboBox();
            btnCapNhatThongTin = new Button();
            label8 = new Label();
            label12 = new Label();
            label11 = new Label();
            txtSDT = new TextBox();
            label10 = new Label();
            txtHoTen = new TextBox();
            label9 = new Label();
            cboLienKetTaiKoan = new ComboBox();
            dgvHoSo = new DataGridView();
            label13 = new Label();
            tpgNhatKyHeThong = new TabPage();
            splitContainer3 = new SplitContainer();
            btnLocLog = new Button();
            dtbNgayKetThuc = new DateTimePicker();
            dtbNgayBatDau = new DateTimePicker();
            txtTimKiemLog = new TextBox();
            label17 = new Label();
            label16 = new Label();
            label14 = new Label();
            label15 = new Label();
            dgvLichSuLog = new DataGridView();
            LogID = new DataGridViewTextBoxColumn();
            ThoiGian = new DataGridViewTextBoxColumn();
            User = new DataGridViewTextBoxColumn();
            HanhDong = new DataGridViewTextBoxColumn();
            BangTacDong = new DataGridViewTextBoxColumn();
            MoTaChiTiet = new DataGridViewTextBoxColumn();
            btnXuatExcel = new Button();
            label18 = new Label();
            btnDong = new Button();
            tabControl1.SuspendLayout();
            tpgQuanLyTaiKhoan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTaiKhoan).BeginInit();
            tpgQuanLyNhanSu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoSo).BeginInit();
            tpgNhatKyHeThong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel1.SuspendLayout();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLichSuLog).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tpgQuanLyTaiKhoan);
            tabControl1.Controls.Add(tpgQuanLyNhanSu);
            tabControl1.Controls.Add(tpgNhatKyHeThong);
            tabControl1.Dock = DockStyle.Bottom;
            tabControl1.Location = new Point(0, 80);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1898, 944);
            tabControl1.TabIndex = 1;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tpgQuanLyTaiKhoan
            // 
            tpgQuanLyTaiKhoan.Controls.Add(splitContainer1);
            tpgQuanLyTaiKhoan.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tpgQuanLyTaiKhoan.ForeColor = SystemColors.ControlText;
            tpgQuanLyTaiKhoan.Location = new Point(4, 34);
            tpgQuanLyTaiKhoan.Name = "tpgQuanLyTaiKhoan";
            tpgQuanLyTaiKhoan.Size = new Size(1890, 906);
            tpgQuanLyTaiKhoan.TabIndex = 2;
            tpgQuanLyTaiKhoan.Text = "Quản lý Tài Khoản";
            tpgQuanLyTaiKhoan.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(ckbHienMatKhau);
            splitContainer1.Panel1.Controls.Add(btnXoaTaiKhoan);
            splitContainer1.Panel1.Controls.Add(btnKhoaTaiKhoan);
            splitContainer1.Panel1.Controls.Add(btnSuaTaiKhoan);
            splitContainer1.Panel1.Controls.Add(btnThemTaiKhoan);
            splitContainer1.Panel1.Controls.Add(ckbTrangThai);
            splitContainer1.Panel1.Controls.Add(cboVaiTro);
            splitContainer1.Panel1.Controls.Add(txtMatKhau);
            splitContainer1.Panel1.Controls.Add(label5);
            splitContainer1.Panel1.Controls.Add(label4);
            splitContainer1.Panel1.Controls.Add(label3);
            splitContainer1.Panel1.Controls.Add(txtTenDangNhap);
            splitContainer1.Panel1.Controls.Add(label2);
            splitContainer1.Panel1.Controls.Add(label1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = SystemColors.Control;
            splitContainer1.Panel2.Controls.Add(dgvTaiKhoan);
            splitContainer1.Panel2.Controls.Add(btnTimKiemTaiKhoan);
            splitContainer1.Panel2.Controls.Add(txtTimKiemTaiKhoan);
            splitContainer1.Panel2.Controls.Add(label6);
            splitContainer1.Panel2.Controls.Add(label7);
            splitContainer1.Size = new Size(1890, 906);
            splitContainer1.SplitterDistance = 788;
            splitContainer1.TabIndex = 0;
            // 
            // ckbHienMatKhau
            // 
            ckbHienMatKhau.AutoSize = true;
            ckbHienMatKhau.Location = new Point(32, 282);
            ckbHienMatKhau.Name = "ckbHienMatKhau";
            ckbHienMatKhau.Size = new Size(153, 29);
            ckbHienMatKhau.TabIndex = 10;
            ckbHienMatKhau.Text = "Hiện mật khẩu";
            ckbHienMatKhau.UseVisualStyleBackColor = true;
            ckbHienMatKhau.CheckedChanged += ckbHienMatKhau_CheckedChanged;
            // 
            // btnXoaTaiKhoan
            // 
            btnXoaTaiKhoan.BackColor = SystemColors.ControlDarkDark;
            btnXoaTaiKhoan.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXoaTaiKhoan.ForeColor = SystemColors.ButtonHighlight;
            btnXoaTaiKhoan.Location = new Point(32, 626);
            btnXoaTaiKhoan.Name = "btnXoaTaiKhoan";
            btnXoaTaiKhoan.Size = new Size(641, 54);
            btnXoaTaiKhoan.TabIndex = 9;
            btnXoaTaiKhoan.Text = "Xoá Tài Khoản ";
            btnXoaTaiKhoan.UseVisualStyleBackColor = false;
            btnXoaTaiKhoan.Click += btnXoaTaiKhoan_Click;
            // 
            // btnKhoaTaiKhoan
            // 
            btnKhoaTaiKhoan.BackColor = Color.IndianRed;
            btnKhoaTaiKhoan.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnKhoaTaiKhoan.ForeColor = SystemColors.ButtonHighlight;
            btnKhoaTaiKhoan.Location = new Point(482, 549);
            btnKhoaTaiKhoan.Name = "btnKhoaTaiKhoan";
            btnKhoaTaiKhoan.Size = new Size(191, 54);
            btnKhoaTaiKhoan.TabIndex = 8;
            btnKhoaTaiKhoan.Text = "Khoá tài khoản";
            btnKhoaTaiKhoan.UseVisualStyleBackColor = false;
            btnKhoaTaiKhoan.Click += btnKhoaTaiKhoan_Click;
            // 
            // btnSuaTaiKhoan
            // 
            btnSuaTaiKhoan.BackColor = Color.FromArgb(192, 192, 0);
            btnSuaTaiKhoan.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSuaTaiKhoan.ForeColor = SystemColors.ButtonHighlight;
            btnSuaTaiKhoan.Location = new Point(256, 549);
            btnSuaTaiKhoan.Name = "btnSuaTaiKhoan";
            btnSuaTaiKhoan.Size = new Size(191, 54);
            btnSuaTaiKhoan.TabIndex = 7;
            btnSuaTaiKhoan.Text = "Sửa";
            btnSuaTaiKhoan.UseVisualStyleBackColor = false;
            btnSuaTaiKhoan.Click += btnSuaTaiKhoan_Click;
            // 
            // btnThemTaiKhoan
            // 
            btnThemTaiKhoan.BackColor = Color.RoyalBlue;
            btnThemTaiKhoan.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThemTaiKhoan.ForeColor = SystemColors.ButtonHighlight;
            btnThemTaiKhoan.Location = new Point(32, 549);
            btnThemTaiKhoan.Name = "btnThemTaiKhoan";
            btnThemTaiKhoan.Size = new Size(191, 54);
            btnThemTaiKhoan.TabIndex = 6;
            btnThemTaiKhoan.Text = "Thêm";
            btnThemTaiKhoan.UseVisualStyleBackColor = false;
            btnThemTaiKhoan.Click += btnThemTaiKhoan_Click;
            // 
            // ckbTrangThai
            // 
            ckbTrangThai.AutoSize = true;
            ckbTrangThai.Location = new Point(32, 486);
            ckbTrangThai.Name = "ckbTrangThai";
            ckbTrangThai.Size = new Size(170, 29);
            ckbTrangThai.TabIndex = 4;
            ckbTrangThai.Text = "Đang hoạt động";
            ckbTrangThai.UseVisualStyleBackColor = true;
            // 
            // cboVaiTro
            // 
            cboVaiTro.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboVaiTro.FormattingEnabled = true;
            cboVaiTro.Items.AddRange(new object[] { "Bác Sĩ", "Nhân Viên ", "Khách Hàng", "Admin" });
            cboVaiTro.Location = new Point(32, 389);
            cboVaiTro.Name = "cboVaiTro";
            cboVaiTro.Size = new Size(641, 36);
            cboVaiTro.TabIndex = 4;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMatKhau.Location = new Point(32, 228);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.PlaceholderText = "(Đã mã hoá ẩn)";
            txtMatKhau.Size = new Size(641, 34);
            txtMatKhau.TabIndex = 3;
            txtMatKhau.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(32, 446);
            label5.Name = "label5";
            label5.Size = new Size(107, 28);
            label5.TabIndex = 1;
            label5.Text = "Trạng thái:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(32, 347);
            label4.Name = "label4";
            label4.Size = new Size(191, 28);
            label4.TabIndex = 1;
            label4.Text = "Vai trò phân quyền:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(32, 183);
            label3.Name = "label3";
            label3.Size = new Size(103, 28);
            label3.TabIndex = 1;
            label3.Text = "Mật khẩu:";
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTenDangNhap.Location = new Point(32, 123);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.PlaceholderText = "Nhập username";
            txtTenDangNhap.Size = new Size(641, 34);
            txtTenDangNhap.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(32, 78);
            label2.Name = "label2";
            label2.Size = new Size(153, 28);
            label2.TabIndex = 1;
            label2.Text = "Tên đăng nhập:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DodgerBlue;
            label1.Location = new Point(32, 21);
            label1.Name = "label1";
            label1.Size = new Size(294, 38);
            label1.TabIndex = 0;
            label1.Text = "Thông tin đăng nhập";
            // 
            // dgvTaiKhoan
            // 
            dgvTaiKhoan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTaiKhoan.BackgroundColor = SystemColors.ButtonFace;
            dgvTaiKhoan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTaiKhoan.Location = new Point(30, 197);
            dgvTaiKhoan.Name = "dgvTaiKhoan";
            dgvTaiKhoan.ReadOnly = true;
            dgvTaiKhoan.RowHeadersWidth = 62;
            dgvTaiKhoan.Size = new Size(1042, 604);
            dgvTaiKhoan.TabIndex = 11;
            dgvTaiKhoan.CellClick += dgvTaiKhoan_CellClick;
            // 
            // btnTimKiemTaiKhoan
            // 
            btnTimKiemTaiKhoan.BackColor = Color.DeepSkyBlue;
            btnTimKiemTaiKhoan.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTimKiemTaiKhoan.ForeColor = SystemColors.ButtonHighlight;
            btnTimKiemTaiKhoan.Location = new Point(835, 112);
            btnTimKiemTaiKhoan.Name = "btnTimKiemTaiKhoan";
            btnTimKiemTaiKhoan.Size = new Size(194, 54);
            btnTimKiemTaiKhoan.TabIndex = 10;
            btnTimKiemTaiKhoan.Text = "Tìm Kiếm";
            btnTimKiemTaiKhoan.UseVisualStyleBackColor = false;
            btnTimKiemTaiKhoan.Click += btnTimKiemTaiKhoan_Click;
            // 
            // txtTimKiemTaiKhoan
            // 
            txtTimKiemTaiKhoan.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTimKiemTaiKhoan.Location = new Point(54, 120);
            txtTimKiemTaiKhoan.Name = "txtTimKiemTaiKhoan";
            txtTimKiemTaiKhoan.PlaceholderText = "Nhập Username";
            txtTimKiemTaiKhoan.Size = new Size(758, 37);
            txtTimKiemTaiKhoan.TabIndex = 1;
            txtTimKiemTaiKhoan.TextChanged += txtTimKiemTaiKhoan_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.SeaGreen;
            label6.Location = new Point(54, 21);
            label6.Name = "label6";
            label6.Size = new Size(411, 38);
            label6.TabIndex = 0;
            label6.Text = "Danh sách tài khoản hệ thống";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(54, 78);
            label7.Name = "label7";
            label7.Size = new Size(193, 28);
            label7.TabIndex = 1;
            label7.Text = "Tìm kiếm tài khoản:";
            // 
            // tpgQuanLyNhanSu
            // 
            tpgQuanLyNhanSu.Controls.Add(splitContainer2);
            tpgQuanLyNhanSu.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tpgQuanLyNhanSu.ForeColor = SystemColors.ControlText;
            tpgQuanLyNhanSu.Location = new Point(4, 34);
            tpgQuanLyNhanSu.Name = "tpgQuanLyNhanSu";
            tpgQuanLyNhanSu.Padding = new Padding(3);
            tpgQuanLyNhanSu.Size = new Size(1890, 906);
            tpgQuanLyNhanSu.TabIndex = 1;
            tpgQuanLyNhanSu.Text = "Quản lý Nhân Sự";
            tpgQuanLyNhanSu.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(3, 3);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(cboChuyenKhoa);
            splitContainer2.Panel1.Controls.Add(btnCapNhatThongTin);
            splitContainer2.Panel1.Controls.Add(label8);
            splitContainer2.Panel1.Controls.Add(label12);
            splitContainer2.Panel1.Controls.Add(label11);
            splitContainer2.Panel1.Controls.Add(txtSDT);
            splitContainer2.Panel1.Controls.Add(label10);
            splitContainer2.Panel1.Controls.Add(txtHoTen);
            splitContainer2.Panel1.Controls.Add(label9);
            splitContainer2.Panel1.Controls.Add(cboLienKetTaiKoan);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.BackColor = SystemColors.Control;
            splitContainer2.Panel2.Controls.Add(dgvHoSo);
            splitContainer2.Panel2.Controls.Add(label13);
            splitContainer2.Size = new Size(1884, 900);
            splitContainer2.SplitterDistance = 757;
            splitContainer2.TabIndex = 0;
            // 
            // cboChuyenKhoa
            // 
            cboChuyenKhoa.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboChuyenKhoa.FormattingEnabled = true;
            cboChuyenKhoa.Items.AddRange(new object[] { "Nội khoa", "Ngoại khoa", "Sản - Phụ khoa", "Nhi khoa", "Tai - Mũi - Họng" });
            cboChuyenKhoa.Location = new Point(30, 446);
            cboChuyenKhoa.Name = "cboChuyenKhoa";
            cboChuyenKhoa.Size = new Size(641, 36);
            cboChuyenKhoa.TabIndex = 10;
            // 
            // btnCapNhatThongTin
            // 
            btnCapNhatThongTin.BackColor = Color.SeaGreen;
            btnCapNhatThongTin.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCapNhatThongTin.ForeColor = SystemColors.ButtonHighlight;
            btnCapNhatThongTin.Location = new Point(30, 523);
            btnCapNhatThongTin.Name = "btnCapNhatThongTin";
            btnCapNhatThongTin.Size = new Size(641, 54);
            btnCapNhatThongTin.TabIndex = 9;
            btnCapNhatThongTin.Text = "Cập nhật (Sửa)";
            btnCapNhatThongTin.UseVisualStyleBackColor = false;
            btnCapNhatThongTin.Click += btnCapNhatThongTin_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.SeaGreen;
            label8.Location = new Point(30, 30);
            label8.Name = "label8";
            label8.Size = new Size(255, 38);
            label8.TabIndex = 0;
            label8.Text = "Thông tin cá nhân";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(30, 399);
            label12.Name = "label12";
            label12.Size = new Size(299, 28);
            label12.TabIndex = 1;
            label12.Text = "Chuyên khoa (dành cho Bác sĩ):";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(30, 289);
            label11.Name = "label11";
            label11.Size = new Size(138, 28);
            label11.TabIndex = 1;
            label11.Text = "Số điện thoại:";
            // 
            // txtSDT
            // 
            txtSDT.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSDT.Location = new Point(30, 331);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(641, 34);
            txtSDT.TabIndex = 2;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(30, 187);
            label10.Name = "label10";
            label10.Size = new Size(108, 28);
            label10.TabIndex = 1;
            label10.Text = "Họ và Tên:";
            // 
            // txtHoTen
            // 
            txtHoTen.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtHoTen.Location = new Point(30, 229);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(641, 34);
            txtHoTen.TabIndex = 2;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(30, 81);
            label9.Name = "label9";
            label9.Size = new Size(181, 28);
            label9.TabIndex = 1;
            label9.Text = "Liên kết tài khoản:";
            // 
            // cboLienKetTaiKoan
            // 
            cboLienKetTaiKoan.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboLienKetTaiKoan.FormattingEnabled = true;
            cboLienKetTaiKoan.Location = new Point(30, 122);
            cboLienKetTaiKoan.Name = "cboLienKetTaiKoan";
            cboLienKetTaiKoan.Size = new Size(641, 36);
            cboLienKetTaiKoan.TabIndex = 3;
            cboLienKetTaiKoan.SelectedIndexChanged += cboLienKetTaiKoan_SelectedIndexChanged;
            // 
            // dgvHoSo
            // 
            dgvHoSo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHoSo.BackgroundColor = SystemColors.ButtonFace;
            dgvHoSo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoSo.Location = new Point(34, 99);
            dgvHoSo.Name = "dgvHoSo";
            dgvHoSo.ReadOnly = true;
            dgvHoSo.RowHeadersWidth = 62;
            dgvHoSo.Size = new Size(1057, 556);
            dgvHoSo.TabIndex = 1;
            dgvHoSo.CellClick += dgvHoSo_CellClick;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.DodgerBlue;
            label13.Location = new Point(48, 30);
            label13.Name = "label13";
            label13.Size = new Size(355, 38);
            label13.TabIndex = 0;
            label13.Text = "Hồ sơ Nhân viên và Bác sĩ";
            // 
            // tpgNhatKyHeThong
            // 
            tpgNhatKyHeThong.Controls.Add(splitContainer3);
            tpgNhatKyHeThong.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tpgNhatKyHeThong.ForeColor = SystemColors.ControlText;
            tpgNhatKyHeThong.Location = new Point(4, 34);
            tpgNhatKyHeThong.Name = "tpgNhatKyHeThong";
            tpgNhatKyHeThong.Size = new Size(1890, 906);
            tpgNhatKyHeThong.TabIndex = 3;
            tpgNhatKyHeThong.Text = "Nhật ký hệ thống (Log)";
            tpgNhatKyHeThong.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            splitContainer3.Dock = DockStyle.Fill;
            splitContainer3.Location = new Point(0, 0);
            splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            splitContainer3.Panel1.BackColor = Color.Linen;
            splitContainer3.Panel1.Controls.Add(btnLocLog);
            splitContainer3.Panel1.Controls.Add(dtbNgayKetThuc);
            splitContainer3.Panel1.Controls.Add(dtbNgayBatDau);
            splitContainer3.Panel1.Controls.Add(txtTimKiemLog);
            splitContainer3.Panel1.Controls.Add(label17);
            splitContainer3.Panel1.Controls.Add(label16);
            splitContainer3.Panel1.Controls.Add(label14);
            splitContainer3.Panel1.Controls.Add(label15);
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.BackColor = Color.Gainsboro;
            splitContainer3.Panel2.Controls.Add(dgvLichSuLog);
            splitContainer3.Panel2.Controls.Add(btnXuatExcel);
            splitContainer3.Panel2.Controls.Add(label18);
            splitContainer3.Size = new Size(1890, 906);
            splitContainer3.SplitterDistance = 709;
            splitContainer3.TabIndex = 0;
            // 
            // btnLocLog
            // 
            btnLocLog.BackColor = SystemColors.ControlDarkDark;
            btnLocLog.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLocLog.ForeColor = SystemColors.ButtonHighlight;
            btnLocLog.Location = new Point(33, 441);
            btnLocLog.Name = "btnLocLog";
            btnLocLog.Size = new Size(641, 54);
            btnLocLog.TabIndex = 9;
            btnLocLog.Text = "Tìm kiếm (Lọc Log)";
            btnLocLog.UseVisualStyleBackColor = false;
            btnLocLog.Click += btnLocLog_Click;
            // 
            // dtbNgayKetThuc
            // 
            dtbNgayKetThuc.CalendarFont = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtbNgayKetThuc.Format = DateTimePickerFormat.Short;
            dtbNgayKetThuc.Location = new Point(33, 246);
            dtbNgayKetThuc.Name = "dtbNgayKetThuc";
            dtbNgayKetThuc.Size = new Size(641, 31);
            dtbNgayKetThuc.TabIndex = 2;
            // 
            // dtbNgayBatDau
            // 
            dtbNgayBatDau.CalendarFont = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtbNgayBatDau.Format = DateTimePickerFormat.Short;
            dtbNgayBatDau.Location = new Point(33, 147);
            dtbNgayBatDau.Name = "dtbNgayBatDau";
            dtbNgayBatDau.Size = new Size(641, 31);
            dtbNgayBatDau.TabIndex = 2;
            // 
            // txtTimKiemLog
            // 
            txtTimKiemLog.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTimKiemLog.Location = new Point(33, 353);
            txtTimKiemLog.Name = "txtTimKiemLog";
            txtTimKiemLog.PlaceholderText = "Nhập từ khoá...";
            txtTimKiemLog.Size = new Size(641, 34);
            txtTimKiemLog.TabIndex = 2;
            txtTimKiemLog.KeyDown += txtTimKiemLog_KeyDown;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label17.Location = new Point(33, 307);
            label17.Name = "label17";
            label17.Size = new Size(257, 28);
            label17.TabIndex = 1;
            label17.Text = "Tìm theo User/Hành động:";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label16.Location = new Point(33, 203);
            label16.Name = "label16";
            label16.Size = new Size(104, 28);
            label16.TabIndex = 1;
            label16.Text = "Đến ngày:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.ForeColor = Color.IndianRed;
            label14.Location = new Point(33, 34);
            label14.Name = "label14";
            label14.Size = new Size(374, 38);
            label14.TabIndex = 0;
            label14.Text = "Tìm kiếm nhật ký hệ thống";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label15.Location = new Point(33, 104);
            label15.Name = "label15";
            label15.Size = new Size(90, 28);
            label15.TabIndex = 1;
            label15.Text = "Từ ngày:";
            // 
            // dgvLichSuLog
            // 
            dgvLichSuLog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLichSuLog.BackgroundColor = SystemColors.ButtonHighlight;
            dgvLichSuLog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLichSuLog.Columns.AddRange(new DataGridViewColumn[] { LogID, ThoiGian, User, HanhDong, BangTacDong, MoTaChiTiet });
            dgvLichSuLog.Location = new Point(22, 102);
            dgvLichSuLog.Name = "dgvLichSuLog";
            dgvLichSuLog.ReadOnly = true;
            dgvLichSuLog.RowHeadersWidth = 62;
            dgvLichSuLog.Size = new Size(1131, 689);
            dgvLichSuLog.TabIndex = 1;
            // 
            // LogID
            // 
            LogID.DataPropertyName = "LogID";
            LogID.FillWeight = 50F;
            LogID.HeaderText = "Log ID";
            LogID.MinimumWidth = 8;
            LogID.Name = "LogID";
            LogID.ReadOnly = true;
            // 
            // ThoiGian
            // 
            ThoiGian.DataPropertyName = "ThoiGian";
            ThoiGian.FillWeight = 80F;
            ThoiGian.HeaderText = "Thời Gian";
            ThoiGian.MinimumWidth = 8;
            ThoiGian.Name = "ThoiGian";
            ThoiGian.ReadOnly = true;
            // 
            // User
            // 
            User.DataPropertyName = "User";
            User.FillWeight = 70F;
            User.HeaderText = "User (Mã TK)";
            User.MinimumWidth = 8;
            User.Name = "User";
            User.ReadOnly = true;
            // 
            // HanhDong
            // 
            HanhDong.DataPropertyName = "HanhDong";
            HanhDong.FillWeight = 70F;
            HanhDong.HeaderText = "Hành Động";
            HanhDong.MinimumWidth = 8;
            HanhDong.Name = "HanhDong";
            HanhDong.ReadOnly = true;
            // 
            // BangTacDong
            // 
            BangTacDong.DataPropertyName = "BangTacDong";
            BangTacDong.FillWeight = 80F;
            BangTacDong.HeaderText = "Bảng tác động";
            BangTacDong.MinimumWidth = 8;
            BangTacDong.Name = "BangTacDong";
            BangTacDong.ReadOnly = true;
            // 
            // MoTaChiTiet
            // 
            MoTaChiTiet.DataPropertyName = "MoTaChiTiet";
            MoTaChiTiet.HeaderText = "Mô tả chi tiết";
            MoTaChiTiet.MinimumWidth = 150;
            MoTaChiTiet.Name = "MoTaChiTiet";
            MoTaChiTiet.ReadOnly = true;
            // 
            // btnXuatExcel
            // 
            btnXuatExcel.BackColor = Color.DarkGreen;
            btnXuatExcel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXuatExcel.ForeColor = SystemColors.ButtonHighlight;
            btnXuatExcel.Location = new Point(857, 807);
            btnXuatExcel.Name = "btnXuatExcel";
            btnXuatExcel.Size = new Size(296, 54);
            btnXuatExcel.TabIndex = 8;
            btnXuatExcel.Text = "Xuất file Excel (Báo cáo)";
            btnXuatExcel.UseVisualStyleBackColor = false;
            btnXuatExcel.Click += btnXuatExcel_Click;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label18.ForeColor = Color.DarkOrange;
            label18.Location = new Point(47, 34);
            label18.Name = "label18";
            label18.Size = new Size(380, 38);
            label18.TabIndex = 0;
            label18.Text = "Lịch sử hoạt động hệ thống";
            // 
            // btnDong
            // 
            btnDong.BackColor = SystemColors.ButtonFace;
            btnDong.FlatAppearance.BorderSize = 2;
            btnDong.FlatStyle = FlatStyle.Flat;
            btnDong.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDong.ForeColor = Color.Red;
            btnDong.Location = new Point(1595, 12);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(299, 56);
            btnDong.TabIndex = 1;
            btnDong.Text = "Đóng và Quay về Trang chủ";
            btnDong.UseVisualStyleBackColor = false;
            btnDong.Click += btnDong_Click;
            // 
            // FrmAdmin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1898, 1024);
            Controls.Add(btnDong);
            Controls.Add(tabControl1);
            Name = "FrmAdmin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmAdmin";
            Load += FrmAdmin_Load;
            tabControl1.ResumeLayout(false);
            tpgQuanLyTaiKhoan.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTaiKhoan).EndInit();
            tpgQuanLyNhanSu.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel1.PerformLayout();
            splitContainer2.Panel2.ResumeLayout(false);
            splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHoSo).EndInit();
            tpgNhatKyHeThong.ResumeLayout(false);
            splitContainer3.Panel1.ResumeLayout(false);
            splitContainer3.Panel1.PerformLayout();
            splitContainer3.Panel2.ResumeLayout(false);
            splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvLichSuLog).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tpgQuanLyNhanSu;
        private TabPage tpgQuanLyTaiKhoan;
        private TabPage tpgNhatKyHeThong;
        private Button btnDong;
        private Label label1;
        private SplitContainer splitContainer1;
        private TextBox txtTenDangNhap;
        private Label label2;
        private CheckBox ckbTrangThai;
        private ComboBox cboVaiTro;
        private TextBox txtMatKhau;
        private Label label5;
        private Label label4;
        private Label label3;
        private Button btnThemTaiKhoan;
        private Button btnKhoaTaiKhoan;
        private Button btnSuaTaiKhoan;
        private Button btnCapNhatThongTin;
        private TextBox txtTimKiemTaiKhoan;
        private Label label6;
        private Label label7;
        private Button btnTimKiemTaiKhoan;
        private DataGridView dgvTaiKhoan;
        private SplitContainer splitContainer2;
        private Label label8;
        private Label label9;
        private ComboBox cboLienKetTaiKoan;
        private Label label12;
        private Label label11;
        private TextBox txtSDT;
        private Label label10;
        private TextBox txtHoTen;
        private Label label13;
        private DataGridView dgvHoSo;
        private SplitContainer splitContainer3;
        private Label label14;
        private Label label15;
        private DateTimePicker dtbNgayKetThuc;
        private DateTimePicker dtbNgayBatDau;
        private TextBox txtTimKiemLog;
        private Label label17;
        private Label label16;
        private Button btnXoaTaiKhoan;
        private Button btnLocLog;
        private Label label18;
        private DataGridView dgvLichSuLog;
        private DataGridViewTextBoxColumn LogID;
        private DataGridViewTextBoxColumn ThoiGian;
        private DataGridViewTextBoxColumn User;
        private DataGridViewTextBoxColumn HanhDong;
        private DataGridViewTextBoxColumn BangTacDong;
        private DataGridViewTextBoxColumn MoTaChiTiet;
        private Button btnXuatExcel;
        private CheckBox ckbHienMatKhau;
        private ComboBox cboChuyenKhoa;
    }
}