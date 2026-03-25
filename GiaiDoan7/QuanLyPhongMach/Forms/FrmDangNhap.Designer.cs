namespace QuanLyPhongMach.Forms
{
    partial class FrmDangNhap
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
            label1 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            label4 = new Label();
            txtTenDangNhap = new TextBox();
            txtMatKhau = new TextBox();
            btnDangNhap = new Button();
            lblDangKiTaiKhoan = new LinkLabel();
            ckbHienMatKhau = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            label1.ForeColor = Color.DarkCyan;
            label1.Location = new Point(112, 140);
            label1.Name = "label1";
            label1.Size = new Size(471, 46);
            label1.TabIndex = 0;
            label1.Text = "PHÒNG MẠCH HẠNH PHÚC";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label2.ForeColor = Color.DarkCyan;
            label2.Location = new Point(260, 186);
            label2.Name = "label2";
            label2.Size = new Size(178, 41);
            label2.TabIndex = 0;
            label2.Text = "Đăng Nhập";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.hospital;
            pictureBox1.Location = new Point(296, 44);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(95, 84);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F);
            label3.Location = new Point(112, 262);
            label3.Name = "label3";
            label3.Size = new Size(167, 30);
            label3.TabIndex = 2;
            label3.Text = "Tên Đăng Nhập:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F);
            label4.Location = new Point(112, 371);
            label4.Name = "label4";
            label4.Size = new Size(110, 30);
            label4.TabIndex = 2;
            label4.Text = "Mật Khẩu:";
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Font = new Font("Segoe UI", 11F);
            txtTenDangNhap.Location = new Point(112, 295);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.PlaceholderText = "Nhập tên đăng nhập (SĐT)";
            txtTenDangNhap.Size = new Size(471, 37);
            txtTenDangNhap.TabIndex = 1;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Font = new Font("Segoe UI", 11F);
            txtMatKhau.Location = new Point(112, 404);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.PlaceholderText = "Nhập mật khẩu";
            txtMatKhau.Size = new Size(471, 37);
            txtMatKhau.TabIndex = 2;
            txtMatKhau.UseSystemPasswordChar = true;
            // 
            // btnDangNhap
            // 
            btnDangNhap.BackColor = Color.DarkCyan;
            btnDangNhap.Font = new Font("Segoe UI", 13F);
            btnDangNhap.ForeColor = SystemColors.ButtonFace;
            btnDangNhap.Location = new Point(182, 519);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(315, 55);
            btnDangNhap.TabIndex = 4;
            btnDangNhap.Text = "Đăng nhập";
            btnDangNhap.UseVisualStyleBackColor = false;
            btnDangNhap.Click += btnDangNhap_Click;
            // 
            // lblDangKiTaiKhoan
            // 
            lblDangKiTaiKhoan.AutoSize = true;
            lblDangKiTaiKhoan.Font = new Font("Segoe UI", 11F);
            lblDangKiTaiKhoan.Location = new Point(220, 612);
            lblDangKiTaiKhoan.Name = "lblDangKiTaiKhoan";
            lblDangKiTaiKhoan.Size = new Size(223, 30);
            lblDangKiTaiKhoan.TabIndex = 5;
            lblDangKiTaiKhoan.TabStop = true;
            lblDangKiTaiKhoan.Text = "Đăng kí tài khoản mới";
            lblDangKiTaiKhoan.LinkClicked += lblDangKiTaiKhoan_LinkClicked;
            // 
            // ckbHienMatKhau
            // 
            ckbHienMatKhau.AutoSize = true;
            ckbHienMatKhau.Location = new Point(112, 467);
            ckbHienMatKhau.Name = "ckbHienMatKhau";
            ckbHienMatKhau.Size = new Size(153, 29);
            ckbHienMatKhau.TabIndex = 6;
            ckbHienMatKhau.Text = "Hiện mật khẩu";
            ckbHienMatKhau.UseVisualStyleBackColor = true;
            ckbHienMatKhau.CheckedChanged += ckbHienMatKhau_CheckedChanged;
            // 
            // FrmDangNhap
            // 
            AcceptButton = btnDangNhap;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(697, 678);
            Controls.Add(ckbHienMatKhau);
            Controls.Add(lblDangKiTaiKhoan);
            Controls.Add(btnDangNhap);
            Controls.Add(txtMatKhau);
            Controls.Add(txtTenDangNhap);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(pictureBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmDangNhap";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmDangNhap";
            FormClosed += FrmDangNhap_FormClosed;
            Load += FrmDangNhap_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private PictureBox pictureBox1;
        private Label label3;
        private Label label4;
        private TextBox txtTenDangNhap;
        private TextBox txtMatKhau;
        private Button btnDangNhap;
        private LinkLabel lblDangKiTaiKhoan;
        private CheckBox ckbHienMatKhau;
    }
}