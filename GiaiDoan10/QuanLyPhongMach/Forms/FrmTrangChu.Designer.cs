namespace QuanLyPhongMach.Forms
{
    partial class FrmTrangChu
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
            menuStrip1 = new MenuStrip();
            mnuHeThong = new ToolStripMenuItem();
            mnuDangNhap = new ToolStripMenuItem();
            mnuDangXuat = new ToolStripMenuItem();
            mnuQuanLy = new ToolStripMenuItem();
            mnuQuanLyKhachHang = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            mnuQuanLyThuoc = new ToolStripMenuItem();
            mnuQuanLyDichVu = new ToolStripMenuItem();
            mnuNghiepVu = new ToolStripMenuItem();
            mnuTiepNhan = new ToolStripMenuItem();
            mnuKhamBenh = new ToolStripMenuItem();
            mnuThanhToan = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            mnuThongTinKhachHang = new ToolStripMenuItem();
            mnuAdmin = new ToolStripMenuItem();
            mnuThongKe = new ToolStripMenuItem();
            toolStrip1 = new ToolStrip();
            tsbTiepNhan = new ToolStripButton();
            tsbDatLich = new ToolStripButton();
            tsbKhamBenh = new ToolStripButton();
            tsbThanhToan = new ToolStripButton();
            tsbThuoc = new ToolStripButton();
            tsbDichVu = new ToolStripButton();
            tsbDangXuat = new ToolStripButton();
            statusStrip1 = new StatusStrip();
            lblCurrentUser = new ToolStripStatusLabel();
            lblStatus = new ToolStripStatusLabel();
            pnlDashboard = new Panel();
            panel3 = new Panel();
            label2 = new Label();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            panel2 = new Panel();
            label5 = new Label();
            label3 = new Label();
            label4 = new Label();
            pictureBox3 = new PictureBox();
            panel1 = new Panel();
            label6 = new Label();
            pictureBox4 = new PictureBox();
            label7 = new Label();
            label8 = new Label();
            pictureBox1 = new PictureBox();
            menuStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            pnlDashboard.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { mnuHeThong, mnuQuanLy, mnuNghiepVu, mnuAdmin, mnuThongKe });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1898, 36);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // mnuHeThong
            // 
            mnuHeThong.DropDownItems.AddRange(new ToolStripItem[] { mnuDangNhap, mnuDangXuat });
            mnuHeThong.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            mnuHeThong.Name = "mnuHeThong";
            mnuHeThong.Size = new Size(110, 32);
            mnuHeThong.Text = "Hệ thống";
            // 
            // mnuDangNhap
            // 
            mnuDangNhap.Name = "mnuDangNhap";
            mnuDangNhap.Size = new Size(210, 36);
            mnuDangNhap.Text = "Đăng nhập";
            // 
            // mnuDangXuat
            // 
            mnuDangXuat.Name = "mnuDangXuat";
            mnuDangXuat.Size = new Size(210, 36);
            mnuDangXuat.Text = "Đăng xuất";
            mnuDangXuat.Click += mnuDangXuat_Click;
            // 
            // mnuQuanLy
            // 
            mnuQuanLy.DropDownItems.AddRange(new ToolStripItem[] { mnuQuanLyKhachHang, toolStripSeparator2, mnuQuanLyThuoc, mnuQuanLyDichVu });
            mnuQuanLy.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            mnuQuanLy.Name = "mnuQuanLy";
            mnuQuanLy.Size = new Size(95, 32);
            mnuQuanLy.Text = "Quản lý";
            // 
            // mnuQuanLyKhachHang
            // 
            mnuQuanLyKhachHang.Name = "mnuQuanLyKhachHang";
            mnuQuanLyKhachHang.Size = new Size(286, 36);
            mnuQuanLyKhachHang.Text = "Quản lý khách hàng";
            mnuQuanLyKhachHang.Click += mnuQuanLyKhachHang_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(283, 6);
            // 
            // mnuQuanLyThuoc
            // 
            mnuQuanLyThuoc.Name = "mnuQuanLyThuoc";
            mnuQuanLyThuoc.Size = new Size(286, 36);
            mnuQuanLyThuoc.Text = "Quản lý thuốc";
            mnuQuanLyThuoc.Click += mnuQuanLyThuoc_Click;
            // 
            // mnuQuanLyDichVu
            // 
            mnuQuanLyDichVu.Name = "mnuQuanLyDichVu";
            mnuQuanLyDichVu.Size = new Size(286, 36);
            mnuQuanLyDichVu.Text = "Quản lý dịch vụ";
            mnuQuanLyDichVu.Click += mnuQuanLyDichVu_Click;
            // 
            // mnuNghiepVu
            // 
            mnuNghiepVu.DropDownItems.AddRange(new ToolStripItem[] { mnuTiepNhan, mnuKhamBenh, mnuThanhToan, toolStripSeparator1, mnuThongTinKhachHang });
            mnuNghiepVu.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            mnuNghiepVu.Name = "mnuNghiepVu";
            mnuNghiepVu.Size = new Size(119, 32);
            mnuNghiepVu.Text = "Nghiệp vụ";
            // 
            // mnuTiepNhan
            // 
            mnuTiepNhan.Name = "mnuTiepNhan";
            mnuTiepNhan.Size = new Size(303, 36);
            mnuTiepNhan.Text = "Tiếp nhận ";
            mnuTiepNhan.Click += mnuTiepNhan_Click;
            // 
            // mnuKhamBenh
            // 
            mnuKhamBenh.Name = "mnuKhamBenh";
            mnuKhamBenh.Size = new Size(303, 36);
            mnuKhamBenh.Text = "Khám bệnh";
            mnuKhamBenh.Click += mnuKhamBenh_Click;
            // 
            // mnuThanhToan
            // 
            mnuThanhToan.Name = "mnuThanhToan";
            mnuThanhToan.Size = new Size(303, 36);
            mnuThanhToan.Text = "Thanh toán";
            mnuThanhToan.Click += mnuThanhToan_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(300, 6);
            // 
            // mnuThongTinKhachHang
            // 
            mnuThongTinKhachHang.Name = "mnuThongTinKhachHang";
            mnuThongTinKhachHang.Size = new Size(303, 36);
            mnuThongTinKhachHang.Text = "Thông tin khách hàng";
            mnuThongTinKhachHang.Click += mnuThongTinKhachHang_Click;
            // 
            // mnuAdmin
            // 
            mnuAdmin.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            mnuAdmin.Name = "mnuAdmin";
            mnuAdmin.Size = new Size(86, 32);
            mnuAdmin.Text = "Admin";
            mnuAdmin.Click += mnuAdmin_Click;
            // 
            // mnuThongKe
            // 
            mnuThongKe.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            mnuThongKe.Name = "mnuThongKe";
            mnuThongKe.Size = new Size(197, 32);
            mnuThongKe.Text = "Thống kê - báo cáo";
            mnuThongKe.Click += mnuThongKe_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.AutoSize = false;
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[] { tsbTiepNhan, tsbDatLich, tsbKhamBenh, tsbThanhToan, tsbThuoc, tsbDichVu, tsbDangXuat });
            toolStrip1.Location = new Point(0, 36);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1898, 80);
            toolStrip1.TabIndex = 2;
            // 
            // tsbTiepNhan
            // 
            tsbTiepNhan.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tsbTiepNhan.Image = Properties.Resources.add;
            tsbTiepNhan.ImageTransparentColor = Color.Magenta;
            tsbTiepNhan.Name = "tsbTiepNhan";
            tsbTiepNhan.Size = new Size(105, 75);
            tsbTiepNhan.Text = "Tiếp Nhận";
            tsbTiepNhan.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbTiepNhan.Click += tsbTiepNhan_Click;
            // 
            // tsbDatLich
            // 
            tsbDatLich.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tsbDatLich.Image = Properties.Resources.calendar;
            tsbDatLich.ImageTransparentColor = Color.Magenta;
            tsbDatLich.Name = "tsbDatLich";
            tsbDatLich.Size = new Size(86, 75);
            tsbDatLich.Text = "Đặt Lịch";
            tsbDatLich.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbDatLich.Click += tsbDatLich_Click;
            // 
            // tsbKhamBenh
            // 
            tsbKhamBenh.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tsbKhamBenh.Image = Properties.Resources.patient;
            tsbKhamBenh.ImageTransparentColor = Color.Magenta;
            tsbKhamBenh.Name = "tsbKhamBenh";
            tsbKhamBenh.Size = new Size(115, 75);
            tsbKhamBenh.Text = "Khám bệnh";
            tsbKhamBenh.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbKhamBenh.Click += tsbKhamBenh_Click;
            // 
            // tsbThanhToan
            // 
            tsbThanhToan.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tsbThanhToan.Image = Properties.Resources.pay;
            tsbThanhToan.ImageTransparentColor = Color.Magenta;
            tsbThanhToan.Name = "tsbThanhToan";
            tsbThanhToan.Size = new Size(114, 75);
            tsbThanhToan.Text = "Thanh toán";
            tsbThanhToan.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbThanhToan.Click += tsbThanhToan_Click;
            // 
            // tsbThuoc
            // 
            tsbThuoc.AutoSize = false;
            tsbThuoc.Image = Properties.Resources.medicine;
            tsbThuoc.ImageTransparentColor = Color.Magenta;
            tsbThuoc.Name = "tsbThuoc";
            tsbThuoc.Size = new Size(114, 75);
            tsbThuoc.Text = "Thuốc";
            tsbThuoc.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbThuoc.Click += tsbThuoc_Click;
            // 
            // tsbDichVu
            // 
            tsbDichVu.AutoSize = false;
            tsbDichVu.Image = Properties.Resources.service;
            tsbDichVu.ImageTransparentColor = Color.Magenta;
            tsbDichVu.Name = "tsbDichVu";
            tsbDichVu.Size = new Size(114, 75);
            tsbDichVu.Text = "Dịch Vụ";
            tsbDichVu.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbDichVu.Click += tsbDichVu_Click;
            // 
            // tsbDangXuat
            // 
            tsbDangXuat.Alignment = ToolStripItemAlignment.Right;
            tsbDangXuat.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tsbDangXuat.ForeColor = Color.IndianRed;
            tsbDangXuat.Image = Properties.Resources.logout;
            tsbDangXuat.ImageTransparentColor = Color.Magenta;
            tsbDangXuat.Name = "tsbDangXuat";
            tsbDangXuat.Size = new Size(105, 75);
            tsbDangXuat.Text = "Đăng xuất";
            tsbDangXuat.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbDangXuat.Click += tsbDangXuat_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = Color.SkyBlue;
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblCurrentUser, lblStatus });
            statusStrip1.Location = new Point(0, 992);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1898, 32);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblCurrentUser
            // 
            lblCurrentUser.ForeColor = SystemColors.ButtonHighlight;
            lblCurrentUser.Name = "lblCurrentUser";
            lblCurrentUser.Size = new Size(207, 25);
            lblCurrentUser.Text = "Admin/Server: SQL 2019";
            // 
            // lblStatus
            // 
            lblStatus.ForeColor = SystemColors.ButtonHighlight;
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(1676, 25);
            lblStatus.Spring = true;
            lblStatus.Text = "Ready";
            lblStatus.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pnlDashboard
            // 
            pnlDashboard.BackColor = SystemColors.ControlLight;
            pnlDashboard.Controls.Add(panel3);
            pnlDashboard.Controls.Add(panel2);
            pnlDashboard.Controls.Add(panel1);
            pnlDashboard.Controls.Add(pictureBox1);
            pnlDashboard.Dock = DockStyle.Fill;
            pnlDashboard.Location = new Point(0, 116);
            pnlDashboard.Name = "pnlDashboard";
            pnlDashboard.Size = new Size(1898, 876);
            pnlDashboard.TabIndex = 5;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ButtonHighlight;
            panel3.Controls.Add(label2);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(pictureBox2);
            panel3.Location = new Point(12, 468);
            panel3.Name = "panel3";
            panel3.Size = new Size(900, 392);
            panel3.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(64, 64, 64);
            label2.Location = new Point(272, 221);
            label2.Name = "label2";
            label2.Size = new Size(373, 96);
            label2.TabIndex = 2;
            label2.Text = "Số 21/12A, đường Hùng Vương,\r\n phường Mỹ Long, \r\nTp. Long Xuyên - tỉnh An Giang";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.SteelBlue;
            label1.Location = new Point(372, 151);
            label1.Name = "label1";
            label1.Size = new Size(154, 48);
            label1.TabIndex = 1;
            label1.Text = "ĐỊA CHỈ";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.location;
            pictureBox2.Location = new Point(406, 41);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(90, 90);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ButtonHighlight;
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(pictureBox3);
            panel2.Location = new Point(935, 468);
            panel2.Name = "panel2";
            panel2.Size = new Size(951, 392);
            panel2.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(64, 64, 64);
            label5.Location = new Point(334, 199);
            label5.Name = "label5";
            label5.Size = new Size(293, 28);
            label5.TabIndex = 5;
            label5.Text = "Tổng đài tư vấn và đặt lịch 24/7";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(64, 64, 64);
            label3.Location = new Point(379, 269);
            label3.Name = "label3";
            label3.Size = new Size(198, 48);
            label3.TabIndex = 4;
            label3.Text = "1900 8888";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.LimeGreen;
            label4.Location = new Point(315, 151);
            label4.Name = "label4";
            label4.Size = new Size(336, 48);
            label4.TabIndex = 3;
            label4.Text = "HOTLINE CẤP CỨU";
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.phone_call;
            pictureBox3.Location = new Point(431, 41);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(90, 90);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 3;
            pictureBox3.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonHighlight;
            panel1.Controls.Add(label6);
            panel1.Controls.Add(pictureBox4);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label8);
            panel1.Location = new Point(935, 49);
            panel1.Name = "panel1";
            panel1.Size = new Size(951, 392);
            panel1.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(64, 64, 64);
            label6.Location = new Point(375, 215);
            label6.Name = "label6";
            label6.Size = new Size(202, 56);
            label6.TabIndex = 8;
            label6.Text = "Sáng: 7h30 - 11h30\r\nChiều: 13h30 - 17h00\r\n";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.time;
            pictureBox4.Location = new Point(431, 39);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(90, 90);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 6;
            pictureBox4.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(255, 128, 128);
            label7.Location = new Point(275, 296);
            label7.Name = "label7";
            label7.Size = new Size(410, 38);
            label7.TabIndex = 7;
            label7.Text = "Mở cửa cả Thứ 7 và Chủ Nhật";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.DodgerBlue;
            label8.Location = new Point(285, 153);
            label8.Name = "label8";
            label8.Size = new Size(381, 48);
            label8.TabIndex = 6;
            label8.Text = "THỜI GIAN LÀM VIỆC";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.background_homepage;
            pictureBox1.Location = new Point(12, 49);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(900, 392);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // FrmTrangChu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1898, 1024);
            Controls.Add(pnlDashboard);
            Controls.Add(statusStrip1);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "FrmTrangChu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmTrangChu - Quản Lý Phòng Mạch";
            FormClosed += FrmTrangChu_FormClosed;
            Load += FrmTrangChu_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            pnlDashboard.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem mnuHeThong;
        private ToolStripMenuItem mnuDangXuat;
        private ToolStripMenuItem mnuQuanLy;
        private ToolStripMenuItem mnuNghiepVu;
        private ToolStripMenuItem mnuTiepNhan;
        private ToolStripMenuItem mnuKhamBenh;
        private ToolStripMenuItem mnuThanhToan;
        private ToolStrip toolStrip1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblCurrentUser;
        private ToolStripStatusLabel lblStatus;
        private ToolStripButton tsbTiepNhan;
        private ToolStripButton tsbDatLich;
        private ToolStripButton tsbKhamBenh;
        private ToolStripButton tsbThanhToan;
        private ToolStripButton tsbDangXuat;
        private Panel pnlDashboard;
        private ToolStripMenuItem mnuDangNhap;
        private ToolStripMenuItem mnuQuanLyKhachHang;
        private ToolStripMenuItem mnuAdmin;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem mnuThongTinKhachHang;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem mnuQuanLyThuoc;
        private ToolStripMenuItem mnuQuanLyDichVu;
        private ToolStripButton tsbThuoc;
        private ToolStripButton tsbDichVu;
        private PictureBox pictureBox1;
        private Panel panel1;
        private Panel panel3;
        private Panel panel2;
        private PictureBox pictureBox2;
        private Label label2;
        private Label label1;
        private Label label5;
        private Label label3;
        private Label label4;
        private PictureBox pictureBox3;
        private Label label6;
        private PictureBox pictureBox4;
        private Label label7;
        private Label label8;
        private ToolStripMenuItem mnuThongKe;
    }
}