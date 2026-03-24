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
            btnHoanThanh = new Button();
            btnHuyKham = new Button();
            txtLoiDan = new RichTextBox();
            txtChanDoan = new RichTextBox();
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
            splitContainer1.Location = new Point(2, 101);
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
            splitContainer1.Panel2.Controls.Add(btnHoanThanh);
            splitContainer1.Panel2.Controls.Add(btnHuyKham);
            splitContainer1.Panel2.Controls.Add(txtLoiDan);
            splitContainer1.Panel2.Controls.Add(txtChanDoan);
            splitContainer1.Panel2.Controls.Add(label4);
            splitContainer1.Panel2.Controls.Add(txtTrieuChung);
            splitContainer1.Panel2.Controls.Add(label3);
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Panel2.Controls.Add(panel1);
            splitContainer1.Size = new Size(1898, 923);
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
            // btnHoanThanh
            // 
            btnHoanThanh.BackColor = Color.ForestGreen;
            btnHoanThanh.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHoanThanh.ForeColor = SystemColors.ButtonHighlight;
            btnHoanThanh.Location = new Point(747, 846);
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
            btnHuyKham.Location = new Point(73, 846);
            btnHuyKham.Name = "btnHuyKham";
            btnHuyKham.Size = new Size(278, 54);
            btnHuyKham.TabIndex = 7;
            btnHuyKham.Text = "Huỷ Khám";
            btnHuyKham.UseVisualStyleBackColor = false;
            btnHuyKham.Click += btnHuyKham_Click;
            // 
            // txtLoiDan
            // 
            txtLoiDan.Location = new Point(73, 652);
            txtLoiDan.Name = "txtLoiDan";
            txtLoiDan.Size = new Size(1006, 175);
            txtLoiDan.TabIndex = 3;
            txtLoiDan.Text = "";
            // 
            // txtChanDoan
            // 
            txtChanDoan.Location = new Point(73, 415);
            txtChanDoan.Name = "txtChanDoan";
            txtChanDoan.Size = new Size(1006, 175);
            txtChanDoan.TabIndex = 3;
            txtChanDoan.Text = "";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(73, 611);
            label4.Name = "label4";
            label4.Size = new Size(171, 25);
            label4.TabIndex = 1;
            label4.Text = "Lời dặn/Đơn thuốc:";
            // 
            // txtTrieuChung
            // 
            txtTrieuChung.Location = new Point(73, 211);
            txtTrieuChung.Multiline = true;
            txtTrieuChung.Name = "txtTrieuChung";
            txtTrieuChung.Size = new Size(1006, 129);
            txtTrieuChung.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(73, 374);
            label3.Name = "label3";
            label3.Size = new Size(201, 25);
            label3.TabIndex = 1;
            label3.Text = "Chuẩn đoán - Kết luận:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(73, 174);
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
            panel1.Location = new Point(73, 33);
            panel1.Name = "panel1";
            panel1.Size = new Size(1006, 89);
            panel1.TabIndex = 0;
            // 
            // lblDangKhamBenhNhan
            // 
            lblDangKhamBenhNhan.AutoSize = true;
            lblDangKhamBenhNhan.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblDangKhamBenhNhan.ForeColor = SystemColors.MenuHighlight;
            lblDangKhamBenhNhan.Location = new Point(19, 24);
            lblDangKhamBenhNhan.Name = "lblDangKhamBenhNhan";
            lblDangKhamBenhNhan.Size = new Size(627, 38);
            lblDangKhamBenhNhan.TabIndex = 0;
            lblDangKhamBenhNhan.Text = "Đang khám: Nguyễn Văn A - Nam - 0987654321";
            // 
            // FrmKhamBenh
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1898, 1024);
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
    }
}