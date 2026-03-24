namespace QuanLyPhongMach.Forms
{
    partial class FrmDangKi
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
            panel1 = new Panel();
            btnQuayLai = new Button();
            btnDangKi = new Button();
            groupBox2 = new GroupBox();
            dtpNgaySinh = new DateTimePicker();
            rdoNu = new RadioButton();
            rdoNam = new RadioButton();
            txtDiaChi = new TextBox();
            label9 = new Label();
            label8 = new Label();
            label10 = new Label();
            label7 = new Label();
            txtSoDienThoai = new TextBox();
            txtHoTen = new TextBox();
            label6 = new Label();
            groupBox1 = new GroupBox();
            ckbHienMatKhau = new CheckBox();
            txtXacNhanMatKhau = new TextBox();
            txtMatKhau = new TextBox();
            label5 = new Label();
            txtTenDangNhap = new TextBox();
            label4 = new Label();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(btnQuayLai);
            panel1.Controls.Add(btnDangKi);
            panel1.Controls.Add(groupBox2);
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-1, -2);
            panel1.Name = "panel1";
            panel1.Size = new Size(699, 1128);
            panel1.TabIndex = 0;
            // 
            // btnQuayLai
            // 
            btnQuayLai.BackColor = Color.SlateGray;
            btnQuayLai.Font = new Font("Segoe UI", 13F);
            btnQuayLai.ForeColor = SystemColors.ButtonFace;
            btnQuayLai.Location = new Point(171, 1061);
            btnQuayLai.Name = "btnQuayLai";
            btnQuayLai.Size = new Size(315, 55);
            btnQuayLai.TabIndex = 8;
            btnQuayLai.Text = "Quay lại Đăng nhập";
            btnQuayLai.UseVisualStyleBackColor = false;
            btnQuayLai.Click += btnQuayLai_Click;
            // 
            // btnDangKi
            // 
            btnDangKi.BackColor = Color.DarkCyan;
            btnDangKi.Font = new Font("Segoe UI", 13F);
            btnDangKi.ForeColor = SystemColors.ButtonFace;
            btnDangKi.Location = new Point(171, 1000);
            btnDangKi.Name = "btnDangKi";
            btnDangKi.Size = new Size(315, 55);
            btnDangKi.TabIndex = 7;
            btnDangKi.Text = "Đăng kí";
            btnDangKi.UseVisualStyleBackColor = false;
            btnDangKi.Click += btnDangKi_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dtpNgaySinh);
            groupBox2.Controls.Add(rdoNu);
            groupBox2.Controls.Add(rdoNam);
            groupBox2.Controls.Add(txtDiaChi);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(txtSoDienThoai);
            groupBox2.Controls.Add(txtHoTen);
            groupBox2.Controls.Add(label6);
            groupBox2.Location = new Point(68, 583);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(572, 411);
            groupBox2.TabIndex = 11;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông tin cá nhân";
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpNgaySinh.Format = DateTimePickerFormat.Short;
            dtpNgaySinh.Location = new Point(43, 175);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(207, 37);
            dtpNgaySinh.TabIndex = 11;
            // 
            // rdoNu
            // 
            rdoNu.AutoSize = true;
            rdoNu.Location = new Point(149, 267);
            rdoNu.Name = "rdoNu";
            rdoNu.Size = new Size(61, 29);
            rdoNu.TabIndex = 10;
            rdoNu.TabStop = true;
            rdoNu.Text = "Nữ";
            rdoNu.UseVisualStyleBackColor = true;
            // 
            // rdoNam
            // 
            rdoNam.AutoSize = true;
            rdoNam.Location = new Point(43, 267);
            rdoNam.Name = "rdoNam";
            rdoNam.Size = new Size(75, 29);
            rdoNam.TabIndex = 10;
            rdoNam.TabStop = true;
            rdoNam.Text = "Nam";
            rdoNam.UseVisualStyleBackColor = true;
            // 
            // txtDiaChi
            // 
            txtDiaChi.Font = new Font("Segoe UI", 11F);
            txtDiaChi.Location = new Point(43, 343);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.PlaceholderText = "Số nhà, Phường, Thành phố";
            txtDiaChi.Size = new Size(487, 37);
            txtDiaChi.TabIndex = 6;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 11F);
            label9.Location = new Point(43, 310);
            label9.Name = "label9";
            label9.Size = new Size(86, 30);
            label9.TabIndex = 9;
            label9.Text = "Địa Chỉ:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 11F);
            label8.Location = new Point(43, 223);
            label8.Name = "label8";
            label8.Size = new Size(103, 30);
            label8.TabIndex = 9;
            label8.Text = "Giới Tính:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 11F);
            label10.Location = new Point(272, 131);
            label10.Name = "label10";
            label10.Size = new Size(147, 30);
            label10.TabIndex = 9;
            label10.Text = "Số Điện Thoại";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11F);
            label7.Location = new Point(43, 131);
            label7.Name = "label7";
            label7.Size = new Size(116, 30);
            label7.TabIndex = 9;
            label7.Text = "Ngày Sinh:";
            // 
            // txtSoDienThoai
            // 
            txtSoDienThoai.Font = new Font("Segoe UI", 11F);
            txtSoDienThoai.Location = new Point(272, 175);
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.PlaceholderText = "VD: 0907020343";
            txtSoDienThoai.Size = new Size(258, 37);
            txtSoDienThoai.TabIndex = 4;
            // 
            // txtHoTen
            // 
            txtHoTen.Font = new Font("Segoe UI", 11F);
            txtHoTen.Location = new Point(43, 74);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.PlaceholderText = "VD: Nguyễn Văn A";
            txtHoTen.Size = new Size(487, 37);
            txtHoTen.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11F);
            label6.Location = new Point(43, 41);
            label6.Name = "label6";
            label6.Size = new Size(115, 30);
            label6.TabIndex = 9;
            label6.Text = "Họ và Tên:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(ckbHienMatKhau);
            groupBox1.Controls.Add(txtXacNhanMatKhau);
            groupBox1.Controls.Add(txtMatKhau);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtTenDangNhap);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new Point(68, 237);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(572, 340);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin tài khoản";
            // 
            // ckbHienMatKhau
            // 
            ckbHienMatKhau.AutoSize = true;
            ckbHienMatKhau.Location = new Point(43, 305);
            ckbHienMatKhau.Name = "ckbHienMatKhau";
            ckbHienMatKhau.Size = new Size(153, 29);
            ckbHienMatKhau.TabIndex = 10;
            ckbHienMatKhau.Text = "Hiện mật khẩu";
            ckbHienMatKhau.UseVisualStyleBackColor = true;
            ckbHienMatKhau.CheckedChanged += ckbHienMatKhau_CheckedChanged;
            // 
            // txtXacNhanMatKhau
            // 
            txtXacNhanMatKhau.Font = new Font("Segoe UI", 11F);
            txtXacNhanMatKhau.Location = new Point(43, 246);
            txtXacNhanMatKhau.Name = "txtXacNhanMatKhau";
            txtXacNhanMatKhau.PlaceholderText = "Nhập lại mật khẩu";
            txtXacNhanMatKhau.Size = new Size(487, 37);
            txtXacNhanMatKhau.TabIndex = 3;
            txtXacNhanMatKhau.UseSystemPasswordChar = true;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Font = new Font("Segoe UI", 11F);
            txtMatKhau.Location = new Point(43, 154);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.PlaceholderText = "Nhập mật khẩu";
            txtMatKhau.Size = new Size(487, 37);
            txtMatKhau.TabIndex = 2;
            txtMatKhau.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F);
            label5.Location = new Point(43, 213);
            label5.Name = "label5";
            label5.Size = new Size(207, 30);
            label5.TabIndex = 8;
            label5.Text = "Xác Nhận Mật Khẩu:";
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Font = new Font("Segoe UI", 11F);
            txtTenDangNhap.Location = new Point(43, 64);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.PlaceholderText = "VD: abc@gmail.com";
            txtTenDangNhap.Size = new Size(487, 37);
            txtTenDangNhap.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F);
            label4.Location = new Point(43, 121);
            label4.Name = "label4";
            label4.Size = new Size(110, 30);
            label4.TabIndex = 8;
            label4.Text = "Mật Khẩu:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F);
            label3.Location = new Point(43, 31);
            label3.Name = "label3";
            label3.Size = new Size(167, 30);
            label3.TabIndex = 9;
            label3.Text = "Tên Đăng Nhập:";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.hospital;
            pictureBox1.Location = new Point(295, 35);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(95, 84);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label2.ForeColor = Color.DarkCyan;
            label2.Location = new Point(191, 177);
            label2.Name = "label2";
            label2.Size = new Size(295, 41);
            label2.TabIndex = 3;
            label2.Text = "Đăng Kí Thành Viên";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            label1.ForeColor = Color.DarkCyan;
            label1.Location = new Point(111, 131);
            label1.Name = "label1";
            label1.Size = new Size(471, 46);
            label1.TabIndex = 4;
            label1.Text = "PHÒNG MẠCH HẠNH PHÚC";
            // 
            // FrmDangKi
            // 
            AcceptButton = btnDangKi;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(697, 1050);
            Controls.Add(panel1);
            Name = "FrmDangKi";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmDangKi";
            Load += FrmDangKi_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox txtMatKhau;
        private TextBox txtTenDangNhap;
        private Label label4;
        private Label label3;
        private PictureBox pictureBox1;
        private Label label2;
        private Label label1;
        private TextBox txtXacNhanMatKhau;
        private Label label5;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label7;
        private TextBox txtHoTen;
        private Label label6;
        private RadioButton rdoNu;
        private RadioButton rdoNam;
        private Label label9;
        private Label label8;
        private TextBox txtDiaChi;
        private Button btnDangKi;
        private Button btnQuayLai;
        private DateTimePicker dtpNgaySinh;
        private CheckBox ckbHienMatKhau;
        private TextBox txtSoDienThoai;
        private Label label10;
    }
}