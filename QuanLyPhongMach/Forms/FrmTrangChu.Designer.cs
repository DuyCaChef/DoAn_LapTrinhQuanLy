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
            pnlDoanhThu = new Panel();
            label8 = new Label();
            label9 = new Label();
            pnlLichHenHuy = new Panel();
            label6 = new Label();
            label7 = new Label();
            pnlDaKhamXong = new Panel();
            label4 = new Label();
            label5 = new Label();
            pnlBenhNhanCho = new Panel();
            label2 = new Label();
            label3 = new Label();
            label1 = new Label();
            menuStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            pnlDashboard.SuspendLayout();
            pnlDoanhThu.SuspendLayout();
            pnlLichHenHuy.SuspendLayout();
            pnlDaKhamXong.SuspendLayout();
            pnlBenhNhanCho.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { mnuHeThong, mnuQuanLy, mnuNghiepVu, mnuAdmin });
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
            pnlDashboard.Controls.Add(pnlDoanhThu);
            pnlDashboard.Controls.Add(pnlLichHenHuy);
            pnlDashboard.Controls.Add(pnlDaKhamXong);
            pnlDashboard.Controls.Add(pnlBenhNhanCho);
            pnlDashboard.Controls.Add(label1);
            pnlDashboard.Dock = DockStyle.Fill;
            pnlDashboard.Location = new Point(0, 116);
            pnlDashboard.Name = "pnlDashboard";
            pnlDashboard.Size = new Size(1898, 876);
            pnlDashboard.TabIndex = 5;
            // 
            // pnlDoanhThu
            // 
            pnlDoanhThu.BackColor = Color.Orange;
            pnlDoanhThu.Controls.Add(label8);
            pnlDoanhThu.Controls.Add(label9);
            pnlDoanhThu.Location = new Point(42, 587);
            pnlDoanhThu.Name = "pnlDoanhThu";
            pnlDoanhThu.Size = new Size(1811, 128);
            pnlDoanhThu.TabIndex = 4;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = SystemColors.ButtonHighlight;
            label8.Location = new Point(37, 0);
            label8.Name = "label8";
            label8.Size = new Size(241, 65);
            label8.TabIndex = 2;
            label8.Text = "8.500.000";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = SystemColors.ButtonHighlight;
            label9.Location = new Point(37, 65);
            label9.Name = "label9";
            label9.Size = new Size(324, 38);
            label9.TabIndex = 1;
            label9.Text = "DOANH THU TẠM TÍNH";
            // 
            // pnlLichHenHuy
            // 
            pnlLichHenHuy.BackColor = Color.Maroon;
            pnlLichHenHuy.Controls.Add(label6);
            pnlLichHenHuy.Controls.Add(label7);
            pnlLichHenHuy.Location = new Point(42, 432);
            pnlLichHenHuy.Name = "pnlLichHenHuy";
            pnlLichHenHuy.Size = new Size(1811, 128);
            pnlLichHenHuy.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.ButtonHighlight;
            label6.Location = new Point(37, 0);
            label6.Name = "label6";
            label6.Size = new Size(55, 65);
            label6.TabIndex = 2;
            label6.Text = "5";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = SystemColors.ButtonHighlight;
            label7.Location = new Point(37, 65);
            label7.Name = "label7";
            label7.Size = new Size(207, 38);
            label7.TabIndex = 1;
            label7.Text = "LỊCH HẸN HUỶ";
            // 
            // pnlDaKhamXong
            // 
            pnlDaKhamXong.BackColor = Color.ForestGreen;
            pnlDaKhamXong.Controls.Add(label4);
            pnlDaKhamXong.Controls.Add(label5);
            pnlDaKhamXong.Location = new Point(41, 274);
            pnlDaKhamXong.Name = "pnlDaKhamXong";
            pnlDaKhamXong.Size = new Size(1812, 128);
            pnlDaKhamXong.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(38, 10);
            label4.Name = "label4";
            label4.Size = new Size(83, 65);
            label4.TabIndex = 2;
            label4.Text = "45";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ButtonHighlight;
            label5.Location = new Point(38, 75);
            label5.Name = "label5";
            label5.Size = new Size(234, 38);
            label5.TabIndex = 1;
            label5.Text = "ĐÃ KHÁM XONG";
            // 
            // pnlBenhNhanCho
            // 
            pnlBenhNhanCho.BackColor = Color.DeepSkyBlue;
            pnlBenhNhanCho.Controls.Add(label2);
            pnlBenhNhanCho.Controls.Add(label3);
            pnlBenhNhanCho.Location = new Point(40, 120);
            pnlBenhNhanCho.Name = "pnlBenhNhanCho";
            pnlBenhNhanCho.Size = new Size(1813, 128);
            pnlBenhNhanCho.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(39, 9);
            label2.Name = "label2";
            label2.Size = new Size(74, 65);
            label2.TabIndex = 2;
            label2.Text = "12";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(39, 74);
            label3.Name = "label3";
            label3.Size = new Size(337, 38);
            label3.TabIndex = 1;
            label3.Text = "BỆNH NHÂN ĐANG CHỜ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.GrayText;
            label1.Location = new Point(42, 51);
            label1.Name = "label1";
            label1.Size = new Size(399, 54);
            label1.TabIndex = 0;
            label1.Text = "Tổng quan hôm nay";
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
            pnlDashboard.PerformLayout();
            pnlDoanhThu.ResumeLayout(false);
            pnlDoanhThu.PerformLayout();
            pnlLichHenHuy.ResumeLayout(false);
            pnlLichHenHuy.PerformLayout();
            pnlDaKhamXong.ResumeLayout(false);
            pnlDaKhamXong.PerformLayout();
            pnlBenhNhanCho.ResumeLayout(false);
            pnlBenhNhanCho.PerformLayout();
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
        private Label label1;
        private Panel pnlBenhNhanCho;
        private Panel pnlDoanhThu;
        private Panel pnlLichHenHuy;
        private Panel pnlDaKhamXong;
        private Label label2;
        private Label label3;
        private Label label6;
        private Label label7;
        private Label label4;
        private Label label5;
        private Label label8;
        private Label label9;
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
    }
}