namespace QuanLyPhongMach.Forms
{
    partial class FrmQuanLyThuoc
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
            btnDong = new Button();
            splitContainer1 = new SplitContainer();
            btnLamMoi = new Button();
            btnXoaThuoc = new Button();
            btnSuaThuoc = new Button();
            btnThemThuoc = new Button();
            txtDonGia = new TextBox();
            label3 = new Label();
            cboDonViTinh = new ComboBox();
            label4 = new Label();
            txtTenThuoc = new TextBox();
            label2 = new Label();
            dgvThuoc = new DataGridView();
            btnTimKiemThuoc = new Button();
            txtTimKiemThuoc = new TextBox();
            label7 = new Label();
            label5 = new Label();
            MaThuoc = new DataGridViewTextBoxColumn();
            TenThuoc = new DataGridViewTextBoxColumn();
            DonViTinh = new DataGridViewTextBoxColumn();
            DonGia = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvThuoc).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.HotTrack;
            label1.Location = new Point(32, 48);
            label1.Name = "label1";
            label1.Size = new Size(337, 38);
            label1.TabIndex = 0;
            label1.Text = "Thông tin các loại thuốc";
            // 
            // btnDong
            // 
            btnDong.BackColor = SystemColors.ButtonFace;
            btnDong.FlatAppearance.BorderSize = 2;
            btnDong.FlatStyle = FlatStyle.Flat;
            btnDong.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDong.ForeColor = Color.Red;
            btnDong.Location = new Point(1587, 11);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(299, 56);
            btnDong.TabIndex = 5;
            btnDong.Text = "Đóng và Quay về Trang chủ";
            btnDong.UseVisualStyleBackColor = false;
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new Point(1, 114);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = SystemColors.InactiveBorder;
            splitContainer1.Panel1.Controls.Add(btnLamMoi);
            splitContainer1.Panel1.Controls.Add(btnXoaThuoc);
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(btnSuaThuoc);
            splitContainer1.Panel1.Controls.Add(btnThemThuoc);
            splitContainer1.Panel1.Controls.Add(txtDonGia);
            splitContainer1.Panel1.Controls.Add(label3);
            splitContainer1.Panel1.Controls.Add(cboDonViTinh);
            splitContainer1.Panel1.Controls.Add(label4);
            splitContainer1.Panel1.Controls.Add(txtTenThuoc);
            splitContainer1.Panel1.Controls.Add(label2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = SystemColors.ControlLight;
            splitContainer1.Panel2.Controls.Add(dgvThuoc);
            splitContainer1.Panel2.Controls.Add(btnTimKiemThuoc);
            splitContainer1.Panel2.Controls.Add(txtTimKiemThuoc);
            splitContainer1.Panel2.Controls.Add(label7);
            splitContainer1.Panel2.Controls.Add(label5);
            splitContainer1.Size = new Size(1898, 912);
            splitContainer1.SplitterDistance = 714;
            splitContainer1.TabIndex = 6;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = SystemColors.ControlDarkDark;
            btnLamMoi.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLamMoi.ForeColor = SystemColors.ButtonHighlight;
            btnLamMoi.Location = new Point(32, 596);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(641, 54);
            btnLamMoi.TabIndex = 7;
            btnLamMoi.Text = "Làm mới các ô nhập";
            btnLamMoi.UseVisualStyleBackColor = false;
            // 
            // btnXoaThuoc
            // 
            btnXoaThuoc.BackColor = Color.IndianRed;
            btnXoaThuoc.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXoaThuoc.ForeColor = SystemColors.ButtonHighlight;
            btnXoaThuoc.Location = new Point(482, 517);
            btnXoaThuoc.Name = "btnXoaThuoc";
            btnXoaThuoc.Size = new Size(191, 54);
            btnXoaThuoc.TabIndex = 6;
            btnXoaThuoc.Text = "Xoá";
            btnXoaThuoc.UseVisualStyleBackColor = false;
            // 
            // btnSuaThuoc
            // 
            btnSuaThuoc.BackColor = Color.FromArgb(192, 192, 0);
            btnSuaThuoc.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSuaThuoc.ForeColor = SystemColors.ButtonHighlight;
            btnSuaThuoc.Location = new Point(256, 517);
            btnSuaThuoc.Name = "btnSuaThuoc";
            btnSuaThuoc.Size = new Size(191, 54);
            btnSuaThuoc.TabIndex = 5;
            btnSuaThuoc.Text = "Sửa";
            btnSuaThuoc.UseVisualStyleBackColor = false;
            // 
            // btnThemThuoc
            // 
            btnThemThuoc.BackColor = Color.RoyalBlue;
            btnThemThuoc.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThemThuoc.ForeColor = SystemColors.ButtonHighlight;
            btnThemThuoc.Location = new Point(32, 517);
            btnThemThuoc.Name = "btnThemThuoc";
            btnThemThuoc.Size = new Size(191, 54);
            btnThemThuoc.TabIndex = 4;
            btnThemThuoc.Text = "Thêm";
            btnThemThuoc.UseVisualStyleBackColor = false;
            // 
            // txtDonGia
            // 
            txtDonGia.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDonGia.Location = new Point(32, 437);
            txtDonGia.Name = "txtDonGia";
            txtDonGia.PlaceholderText = "Nhập đơn giá";
            txtDonGia.Size = new Size(641, 34);
            txtDonGia.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(32, 392);
            label3.Name = "label3";
            label3.Size = new Size(150, 28);
            label3.TabIndex = 7;
            label3.Text = "Đơn giá (VNĐ):";
            // 
            // cboDonViTinh
            // 
            cboDonViTinh.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboDonViTinh.FormattingEnabled = true;
            cboDonViTinh.Items.AddRange(new object[] { "Viên", "Vỉ ", "Hộp ", "Chai", "Lọ", "Tuýp ", "Ống ", "Gói", "Bơm" });
            cboDonViTinh.Location = new Point(32, 325);
            cboDonViTinh.Name = "cboDonViTinh";
            cboDonViTinh.Size = new Size(641, 36);
            cboDonViTinh.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(32, 283);
            label4.Name = "label4";
            label4.Size = new Size(118, 28);
            label4.TabIndex = 5;
            label4.Text = "Đơn vị tính:";
            // 
            // txtTenThuoc
            // 
            txtTenThuoc.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTenThuoc.Location = new Point(32, 217);
            txtTenThuoc.Name = "txtTenThuoc";
            txtTenThuoc.PlaceholderText = "Nhập tên thuốc";
            txtTenThuoc.Size = new Size(641, 34);
            txtTenThuoc.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(32, 172);
            label2.Name = "label2";
            label2.Size = new Size(213, 28);
            label2.TabIndex = 3;
            label2.Text = "Tên thuốc (Biệt dược):";
            // 
            // dgvThuoc
            // 
            dgvThuoc.AllowUserToAddRows = false;
            dgvThuoc.AllowUserToDeleteRows = false;
            dgvThuoc.AllowUserToResizeColumns = false;
            dgvThuoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvThuoc.BackgroundColor = SystemColors.ButtonHighlight;
            dgvThuoc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvThuoc.Columns.AddRange(new DataGridViewColumn[] { MaThuoc, TenThuoc, DonViTinh, DonGia });
            dgvThuoc.Location = new Point(34, 217);
            dgvThuoc.MultiSelect = false;
            dgvThuoc.Name = "dgvThuoc";
            dgvThuoc.ReadOnly = true;
            dgvThuoc.RowHeadersWidth = 62;
            dgvThuoc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvThuoc.Size = new Size(1114, 599);
            dgvThuoc.TabIndex = 17;
            // 
            // btnTimKiemThuoc
            // 
            btnTimKiemThuoc.BackColor = Color.DeepSkyBlue;
            btnTimKiemThuoc.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTimKiemThuoc.ForeColor = SystemColors.ButtonHighlight;
            btnTimKiemThuoc.Location = new Point(861, 143);
            btnTimKiemThuoc.Name = "btnTimKiemThuoc";
            btnTimKiemThuoc.Size = new Size(194, 54);
            btnTimKiemThuoc.TabIndex = 16;
            btnTimKiemThuoc.Text = "Tìm Kiếm";
            btnTimKiemThuoc.UseVisualStyleBackColor = false;
            // 
            // txtTimKiemThuoc
            // 
            txtTimKiemThuoc.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTimKiemThuoc.Location = new Point(80, 151);
            txtTimKiemThuoc.Name = "txtTimKiemThuoc";
            txtTimKiemThuoc.PlaceholderText = "Tìm kiếm theo tên hoặc mã thuốc..";
            txtTimKiemThuoc.Size = new Size(758, 37);
            txtTimKiemThuoc.TabIndex = 14;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(80, 109);
            label7.Name = "label7";
            label7.Size = new Size(160, 28);
            label7.TabIndex = 15;
            label7.Text = "Tìm kiếm thuốc:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.ForestGreen;
            label5.Location = new Point(54, 48);
            label5.Name = "label5";
            label5.Size = new Size(246, 38);
            label5.TabIndex = 13;
            label5.Text = "Danh sách thuốc:";
            // 
            // MaThuoc
            // 
            MaThuoc.DataPropertyName = "MaThuoc";
            MaThuoc.HeaderText = "Mã Thuốc";
            MaThuoc.MinimumWidth = 8;
            MaThuoc.Name = "MaThuoc";
            MaThuoc.ReadOnly = true;
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
            DonViTinh.HeaderText = "Đơn vị tính";
            DonViTinh.MinimumWidth = 8;
            DonViTinh.Name = "DonViTinh";
            DonViTinh.ReadOnly = true;
            // 
            // DonGia
            // 
            DonGia.DataPropertyName = "DonGia";
            DonGia.HeaderText = "Đơn giá (VNĐ)";
            DonGia.MinimumWidth = 8;
            DonGia.Name = "DonGia";
            DonGia.ReadOnly = true;
            // 
            // FrmQuanLyThuoc
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1898, 1024);
            Controls.Add(splitContainer1);
            Controls.Add(btnDong);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FrmQuanLyThuoc";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmQuanLyThuoc";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvThuoc).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Button btnDong;
        private SplitContainer splitContainer1;
        private TextBox txtTenThuoc;
        private Label label2;
        private TextBox txtDonGia;
        private Label label3;
        private ComboBox cboDonViTinh;
        private Label label4;
        private Button btnXoaThuoc;
        private Button btnSuaThuoc;
        private Button btnThemThuoc;
        private Button btnLamMoi;
        private Label label5;
        private DataGridView dgvThuoc;
        private Button btnTimKiemThuoc;
        private TextBox txtTimKiemThuoc;
        private Label label7;
        private DataGridViewTextBoxColumn MaThuoc;
        private DataGridViewTextBoxColumn TenThuoc;
        private DataGridViewTextBoxColumn DonViTinh;
        private DataGridViewTextBoxColumn DonGia;
    }
}