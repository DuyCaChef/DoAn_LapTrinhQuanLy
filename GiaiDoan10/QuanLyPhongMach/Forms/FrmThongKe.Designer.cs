namespace QuanLyPhongMach.Forms
{
    partial class FrmThongKe
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            pnlHeader = new Panel();
            btnDong = new Button();
            btnFilter = new Button();
            dtpEnd = new DateTimePicker();
            label2 = new Label();
            dtpStart = new DateTimePicker();
            label1 = new Label();
            lblTitle = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            pnlCardRevenue = new Panel();
            lblRevenueValue = new Label();
            label4 = new Label();
            panel2 = new Panel();
            lblDaKham = new Label();
            label6 = new Label();
            panel3 = new Panel();
            lblChoKham = new Label();
            label8 = new Label();
            panel4 = new Panel();
            lblDaHuy = new Label();
            label10 = new Label();
            panel5 = new Panel();
            chartRevenue = new System.Windows.Forms.DataVisualization.Charting.Chart();
            label3 = new Label();
            pnlHeader.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            pnlCardRevenue.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartRevenue).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.White;
            pnlHeader.Controls.Add(btnDong);
            pnlHeader.Controls.Add(btnFilter);
            pnlHeader.Controls.Add(dtpEnd);
            pnlHeader.Controls.Add(label2);
            pnlHeader.Controls.Add(dtpStart);
            pnlHeader.Controls.Add(label1);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(20);
            pnlHeader.Size = new Size(1898, 80);
            pnlHeader.TabIndex = 0;
            // 
            // btnDong
            // 
            btnDong.BackColor = SystemColors.ButtonFace;
            btnDong.FlatAppearance.BorderSize = 2;
            btnDong.FlatStyle = FlatStyle.Flat;
            btnDong.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDong.ForeColor = Color.Red;
            btnDong.Location = new Point(1576, 14);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(299, 56);
            btnDong.TabIndex = 6;
            btnDong.Text = "Đóng và Quay về Trang chủ";
            btnDong.UseVisualStyleBackColor = false;
            btnDong.Click += btnDong_Click;
            // 
            // btnFilter
            // 
            btnFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFilter.BackColor = Color.FromArgb(0, 122, 204);
            btnFilter.FlatAppearance.BorderSize = 0;
            btnFilter.FlatStyle = FlatStyle.Flat;
            btnFilter.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnFilter.ForeColor = Color.White;
            btnFilter.Location = new Point(1251, 20);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(172, 42);
            btnFilter.TabIndex = 5;
            btnFilter.Text = "Xem Thống Kê";
            btnFilter.UseVisualStyleBackColor = false;
            btnFilter.Click += btnFilter_Click;
            // 
            // dtpEnd
            // 
            dtpEnd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpEnd.Format = DateTimePickerFormat.Short;
            dtpEnd.Location = new Point(1050, 26);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(174, 31);
            dtpEnd.TabIndex = 4;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(946, 28);
            label2.Name = "label2";
            label2.Size = new Size(99, 28);
            label2.TabIndex = 3;
            label2.Text = "Đến ngày:";
            // 
            // dtpStart
            // 
            dtpStart.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpStart.Format = DateTimePickerFormat.Short;
            dtpStart.Location = new Point(743, 26);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(174, 31);
            dtpStart.TabIndex = 2;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(652, 28);
            label1.Name = "label1";
            label1.Size = new Size(86, 28);
            label1.TabIndex = 1;
            label1.Text = "Từ ngày:";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.Location = new Point(23, 19);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(440, 48);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "BÁO CÁO PHÒNG KHÁM";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(pnlCardRevenue, 0, 0);
            tableLayoutPanel1.Controls.Add(panel2, 1, 0);
            tableLayoutPanel1.Controls.Add(panel3, 2, 0);
            tableLayoutPanel1.Controls.Add(panel4, 3, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 80);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(10);
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1898, 200);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // pnlCardRevenue
            // 
            pnlCardRevenue.BackColor = Color.DodgerBlue;
            pnlCardRevenue.Controls.Add(lblRevenueValue);
            pnlCardRevenue.Controls.Add(label4);
            pnlCardRevenue.Dock = DockStyle.Fill;
            pnlCardRevenue.Location = new Point(20, 20);
            pnlCardRevenue.Margin = new Padding(10);
            pnlCardRevenue.Name = "pnlCardRevenue";
            pnlCardRevenue.Padding = new Padding(15);
            pnlCardRevenue.Size = new Size(449, 160);
            pnlCardRevenue.TabIndex = 0;
            // 
            // lblRevenueValue
            // 
            lblRevenueValue.AutoSize = true;
            lblRevenueValue.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblRevenueValue.ForeColor = Color.White;
            lblRevenueValue.Location = new Point(18, 69);
            lblRevenueValue.Name = "lblRevenueValue";
            lblRevenueValue.Size = new Size(249, 60);
            lblRevenueValue.TabIndex = 2;
            lblRevenueValue.Text = "15.000.000";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.Location = new Point(18, 15);
            label4.Name = "label4";
            label4.Size = new Size(237, 32);
            label4.TabIndex = 1;
            label4.Text = "Doanh thu tạm tính";
            // 
            // panel2
            // 
            panel2.BackColor = Color.ForestGreen;
            panel2.Controls.Add(lblDaKham);
            panel2.Controls.Add(label6);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(489, 20);
            panel2.Margin = new Padding(10);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(15);
            panel2.Size = new Size(449, 160);
            panel2.TabIndex = 1;
            // 
            // lblDaKham
            // 
            lblDaKham.AutoSize = true;
            lblDaKham.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblDaKham.ForeColor = Color.White;
            lblDaKham.Location = new Point(18, 69);
            lblDaKham.Name = "lblDaKham";
            lblDaKham.Size = new Size(100, 60);
            lblDaKham.TabIndex = 2;
            lblDaKham.Text = "120";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label6.Location = new Point(18, 15);
            label6.Name = "label6";
            label6.Size = new Size(249, 32);
            label6.TabIndex = 1;
            label6.Text = "Phiếu đã hoàn thành";
            // 
            // panel3
            // 
            panel3.BackColor = Color.Goldenrod;
            panel3.Controls.Add(lblChoKham);
            panel3.Controls.Add(label8);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(958, 20);
            panel3.Margin = new Padding(10);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(15);
            panel3.Size = new Size(449, 160);
            panel3.TabIndex = 2;
            // 
            // lblChoKham
            // 
            lblChoKham.AutoSize = true;
            lblChoKham.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblChoKham.ForeColor = Color.White;
            lblChoKham.Location = new Point(18, 69);
            lblChoKham.Name = "lblChoKham";
            lblChoKham.Size = new Size(75, 60);
            lblChoKham.TabIndex = 2;
            lblChoKham.Text = "15";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label8.Location = new Point(18, 15);
            label8.Name = "label8";
            label8.Size = new Size(248, 32);
            label8.TabIndex = 1;
            label8.Text = "Bệnh nhân đang chờ";
            // 
            // panel4
            // 
            panel4.BackColor = Color.IndianRed;
            panel4.Controls.Add(lblDaHuy);
            panel4.Controls.Add(label10);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(1427, 20);
            panel4.Margin = new Padding(10);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(15);
            panel4.Size = new Size(451, 160);
            panel4.TabIndex = 3;
            // 
            // lblDaHuy
            // 
            lblDaHuy.AutoSize = true;
            lblDaHuy.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblDaHuy.ForeColor = Color.White;
            lblDaHuy.Location = new Point(18, 69);
            lblDaHuy.Name = "lblDaHuy";
            lblDaHuy.Size = new Size(50, 60);
            lblDaHuy.TabIndex = 2;
            lblDaHuy.Text = "5";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label10.Location = new Point(18, 15);
            label10.Name = "label10";
            label10.Size = new Size(192, 32);
            label10.TabIndex = 1;
            label10.Text = "Lịch hẹn đã hủy";
            // 
            // panel5
            // 
            panel5.BackColor = Color.White;
            panel5.Controls.Add(chartRevenue);
            panel5.Controls.Add(label3);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(0, 280);
            panel5.Margin = new Padding(10);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(20);
            panel5.Size = new Size(1898, 744);
            panel5.TabIndex = 2;
            // 
            // chartRevenue
            // 
            chartArea1.Name = "ChartArea1";
            chartRevenue.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chartRevenue.Legends.Add(legend1);
            chartRevenue.Location = new Point(294, 91);
            chartRevenue.Name = "chartRevenue";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chartRevenue.Series.Add(series1);
            chartRevenue.Size = new Size(1283, 611);
            chartRevenue.TabIndex = 1;
            chartRevenue.Text = "chartAnalysis";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.Location = new Point(20, 20);
            label3.Name = "label3";
            label3.Padding = new Padding(0, 0, 0, 16);
            label3.Size = new Size(492, 48);
            label3.TabIndex = 0;
            label3.Text = "BIỂU ĐỒ DOANH THU 7 NGÀY GẦN NHẤT";
            // 
            // FrmThongKe
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 245, 250);
            ClientSize = new Size(1898, 1024);
            Controls.Add(panel5);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9F);
            Name = "FrmThongKe";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thống kê & Báo cáo Tổng quan";
            Load += FrmThongKe_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            pnlCardRevenue.ResumeLayout(false);
            pnlCardRevenue.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chartRevenue).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitle;
        private Button btnFilter;
        private DateTimePicker dtpEnd;
        private Label label2;
        private DateTimePicker dtpStart;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel pnlCardRevenue;
        private Panel panel2;
        private Label lblDaKham;
        private Label label6;
        private Panel panel3;
        private Label lblChoKham;
        private Label label8;
        private Panel panel4;
        private Label lblDaHuy;
        private Label label10;
        private Label lblRevenueValue;
        private Label label4;
        private Panel panel5;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRevenue;
        private Label label3;
        private Button btnDong;
    }
}