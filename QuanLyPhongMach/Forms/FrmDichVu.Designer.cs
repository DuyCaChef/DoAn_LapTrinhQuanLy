namespace QuanLyPhongMach.Forms
{
    partial class FrmDichVu
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
            splitContainer1 = new SplitContainer();
            btnLamMoi = new Button();
            btnXoaDichVu = new Button();
            label1 = new Label();
            btnSuaDichVu = new Button();
            btnThemDichVu = new Button();
            txtDonGia = new TextBox();
            label3 = new Label();
            txtTenDichVu = new TextBox();
            label2 = new Label();
            dgvDichVu = new DataGridView();
            btnTimKiemDichVu = new Button();
            txtTimKiemDichVu = new TextBox();
            label7 = new Label();
            label5 = new Label();
            MaDichVu = new DataGridViewTextBoxColumn();
            TenDichVu = new DataGridViewTextBoxColumn();
            DonGia = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDichVu).BeginInit();
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
            btnDong.TabIndex = 6;
            btnDong.Text = "Đóng và Quay về Trang chủ";
            btnDong.UseVisualStyleBackColor = false;
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new Point(0, 100);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = SystemColors.InactiveBorder;
            splitContainer1.Panel1.Controls.Add(btnLamMoi);
            splitContainer1.Panel1.Controls.Add(btnXoaDichVu);
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(btnSuaDichVu);
            splitContainer1.Panel1.Controls.Add(btnThemDichVu);
            splitContainer1.Panel1.Controls.Add(txtDonGia);
            splitContainer1.Panel1.Controls.Add(label3);
            splitContainer1.Panel1.Controls.Add(txtTenDichVu);
            splitContainer1.Panel1.Controls.Add(label2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = SystemColors.ControlLight;
            splitContainer1.Panel2.Controls.Add(dgvDichVu);
            splitContainer1.Panel2.Controls.Add(btnTimKiemDichVu);
            splitContainer1.Panel2.Controls.Add(txtTimKiemDichVu);
            splitContainer1.Panel2.Controls.Add(label7);
            splitContainer1.Panel2.Controls.Add(label5);
            splitContainer1.Size = new Size(1898, 924);
            splitContainer1.SplitterDistance = 714;
            splitContainer1.TabIndex = 7;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = SystemColors.ControlDarkDark;
            btnLamMoi.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLamMoi.ForeColor = SystemColors.ButtonHighlight;
            btnLamMoi.Location = new Point(29, 531);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(641, 66);
            btnLamMoi.TabIndex = 6;
            btnLamMoi.Text = "Làm mới các ô nhập";
            btnLamMoi.UseVisualStyleBackColor = false;
            // 
            // btnXoaDichVu
            // 
            btnXoaDichVu.BackColor = Color.IndianRed;
            btnXoaDichVu.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXoaDichVu.ForeColor = SystemColors.ButtonHighlight;
            btnXoaDichVu.Location = new Point(479, 452);
            btnXoaDichVu.Name = "btnXoaDichVu";
            btnXoaDichVu.Size = new Size(191, 66);
            btnXoaDichVu.TabIndex = 5;
            btnXoaDichVu.Text = "Xoá";
            btnXoaDichVu.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.HotTrack;
            label1.Location = new Point(32, 48);
            label1.Name = "label1";
            label1.Size = new Size(257, 38);
            label1.TabIndex = 0;
            label1.Text = "Thông tin Dịch Vụ";
            // 
            // btnSuaDichVu
            // 
            btnSuaDichVu.BackColor = Color.FromArgb(192, 192, 0);
            btnSuaDichVu.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSuaDichVu.ForeColor = SystemColors.ButtonHighlight;
            btnSuaDichVu.Location = new Point(253, 452);
            btnSuaDichVu.Name = "btnSuaDichVu";
            btnSuaDichVu.Size = new Size(191, 66);
            btnSuaDichVu.TabIndex = 4;
            btnSuaDichVu.Text = "Sửa";
            btnSuaDichVu.UseVisualStyleBackColor = false;
            // 
            // btnThemDichVu
            // 
            btnThemDichVu.BackColor = Color.RoyalBlue;
            btnThemDichVu.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThemDichVu.ForeColor = SystemColors.ButtonHighlight;
            btnThemDichVu.Location = new Point(29, 452);
            btnThemDichVu.Name = "btnThemDichVu";
            btnThemDichVu.Size = new Size(191, 66);
            btnThemDichVu.TabIndex = 3;
            btnThemDichVu.Text = "Thêm";
            btnThemDichVu.UseVisualStyleBackColor = false;
            // 
            // txtDonGia
            // 
            txtDonGia.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDonGia.Location = new Point(32, 330);
            txtDonGia.Name = "txtDonGia";
            txtDonGia.PlaceholderText = "Nhập đơn giá của dịch vụ";
            txtDonGia.Size = new Size(641, 34);
            txtDonGia.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(32, 285);
            label3.Name = "label3";
            label3.Size = new Size(150, 28);
            label3.TabIndex = 7;
            label3.Text = "Đơn giá (VNĐ):";
            // 
            // txtTenDichVu
            // 
            txtTenDichVu.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTenDichVu.Location = new Point(32, 217);
            txtTenDichVu.Name = "txtTenDichVu";
            txtTenDichVu.PlaceholderText = "Nhập tên dịch vụ";
            txtTenDichVu.Size = new Size(641, 34);
            txtTenDichVu.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(32, 172);
            label2.Name = "label2";
            label2.Size = new Size(235, 28);
            label2.TabIndex = 3;
            label2.Text = "Tên dịch vụ/Xét nghiệm:";
            // 
            // dgvDichVu
            // 
            dgvDichVu.AllowUserToAddRows = false;
            dgvDichVu.AllowUserToDeleteRows = false;
            dgvDichVu.AllowUserToResizeColumns = false;
            dgvDichVu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDichVu.BackgroundColor = SystemColors.ButtonHighlight;
            dgvDichVu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDichVu.Columns.AddRange(new DataGridViewColumn[] { MaDichVu, TenDichVu, DonGia });
            dgvDichVu.Location = new Point(34, 217);
            dgvDichVu.MultiSelect = false;
            dgvDichVu.Name = "dgvDichVu";
            dgvDichVu.ReadOnly = true;
            dgvDichVu.RowHeadersWidth = 62;
            dgvDichVu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDichVu.Size = new Size(1114, 611);
            dgvDichVu.TabIndex = 17;
            // 
            // btnTimKiemDichVu
            // 
            btnTimKiemDichVu.BackColor = Color.DeepSkyBlue;
            btnTimKiemDichVu.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTimKiemDichVu.ForeColor = SystemColors.ButtonHighlight;
            btnTimKiemDichVu.Location = new Point(861, 143);
            btnTimKiemDichVu.Name = "btnTimKiemDichVu";
            btnTimKiemDichVu.Size = new Size(194, 66);
            btnTimKiemDichVu.TabIndex = 16;
            btnTimKiemDichVu.Text = "Tìm Kiếm";
            btnTimKiemDichVu.UseVisualStyleBackColor = false;
            // 
            // txtTimKiemDichVu
            // 
            txtTimKiemDichVu.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTimKiemDichVu.Location = new Point(80, 151);
            txtTimKiemDichVu.Name = "txtTimKiemDichVu";
            txtTimKiemDichVu.PlaceholderText = "Tìm kiếm theo tên hoặc mã dịch vụ...";
            txtTimKiemDichVu.Size = new Size(758, 37);
            txtTimKiemDichVu.TabIndex = 14;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(80, 109);
            label7.Name = "label7";
            label7.Size = new Size(178, 28);
            label7.TabIndex = 15;
            label7.Text = "Tìm kiếm Dịch Vu:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.SlateBlue;
            label5.Location = new Point(54, 48);
            label5.Name = "label5";
            label5.Size = new Size(367, 38);
            label5.TabIndex = 13;
            label5.Text = "Danh sách Dịch vụ hiện có";
            // 
            // MaDichVu
            // 
            MaDichVu.DataPropertyName = "MaDichVu";
            MaDichVu.HeaderText = "Mã Dịch Vụ";
            MaDichVu.MinimumWidth = 8;
            MaDichVu.Name = "MaDichVu";
            MaDichVu.ReadOnly = true;
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
            DonGia.HeaderText = "Đơn Giá (VNĐ)";
            DonGia.MinimumWidth = 8;
            DonGia.Name = "DonGia";
            DonGia.ReadOnly = true;
            // 
            // FrmDichVu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1898, 1024);
            Controls.Add(splitContainer1);
            Controls.Add(btnDong);
            MaximizeBox = false;
            Name = "FrmDichVu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmDichVu";
            Load += FrmDichVu_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDichVu).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnDong;
        private SplitContainer splitContainer1;
        private Button btnLamMoi;
        private Button btnXoaDichVu;
        private Label label1;
        private Button btnSuaDichVu;
        private Button btnThemDichVu;
        private TextBox txtDonGia;
        private Label label3;
        private TextBox txtTenDichVu;
        private Label label2;
        private DataGridView dgvDichVu;
        private Button btnTimKiemDichVu;
        private TextBox txtTimKiemDichVu;
        private Label label7;
        private Label label5;
        private DataGridViewTextBoxColumn MaDichVu;
        private DataGridViewTextBoxColumn TenDichVu;
        private DataGridViewTextBoxColumn DonGia;
    }
}