namespace QuanLyBaiGiuXe.Views
{
    partial class ucBaoCao
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.grbBaoCaoDoanhThu = new System.Windows.Forms.GroupBox();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.rdoTheoNgay = new System.Windows.Forms.RadioButton();
            this.rdoTheoThang = new System.Windows.Forms.RadioButton();
            this.btnXem = new System.Windows.Forms.Button();
            this.btnXuatCsv = new System.Windows.Forms.Button();
            this.dgvBaoCao = new System.Windows.Forms.DataGridView();
            this.pnlDuoi = new System.Windows.Forms.Panel();
            this.lblTong = new System.Windows.Forms.Label();
            this.chartDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grbBaoCaoDoanhThu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).BeginInit();
            this.pnlDuoi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).BeginInit();
            this.SuspendLayout();
            // 
            // grbBaoCaoDoanhThu
            // 
            this.grbBaoCaoDoanhThu.Controls.Add(this.btnXuatCsv);
            this.grbBaoCaoDoanhThu.Controls.Add(this.btnXem);
            this.grbBaoCaoDoanhThu.Controls.Add(this.rdoTheoThang);
            this.grbBaoCaoDoanhThu.Controls.Add(this.rdoTheoNgay);
            this.grbBaoCaoDoanhThu.Controls.Add(this.dtpDenNgay);
            this.grbBaoCaoDoanhThu.Controls.Add(this.dtpTuNgay);
            this.grbBaoCaoDoanhThu.Controls.Add(this.lblDenNgay);
            this.grbBaoCaoDoanhThu.Controls.Add(this.lblTuNgay);
            this.grbBaoCaoDoanhThu.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbBaoCaoDoanhThu.Location = new System.Drawing.Point(0, 0);
            this.grbBaoCaoDoanhThu.Name = "grbBaoCaoDoanhThu";
            this.grbBaoCaoDoanhThu.Size = new System.Drawing.Size(1300, 124);
            this.grbBaoCaoDoanhThu.TabIndex = 0;
            this.grbBaoCaoDoanhThu.TabStop = false;
            this.grbBaoCaoDoanhThu.Text = "Bộ lọc";
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Location = new System.Drawing.Point(23, 33);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(76, 22);
            this.lblTuNgay.TabIndex = 0;
            this.lblTuNgay.Text = "Từ ngày";
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Location = new System.Drawing.Point(217, 33);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(87, 22);
            this.lblDenNgay.TabIndex = 1;
            this.lblDenNgay.Text = "Đến ngày";
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(27, 59);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(156, 28);
            this.dtpTuNgay.TabIndex = 2;
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new System.Drawing.Point(221, 59);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(156, 28);
            this.dtpDenNgay.TabIndex = 3;
            // 
            // rdoTheoNgay
            // 
            this.rdoTheoNgay.AutoSize = true;
            this.rdoTheoNgay.Location = new System.Drawing.Point(415, 60);
            this.rdoTheoNgay.Name = "rdoTheoNgay";
            this.rdoTheoNgay.Size = new System.Drawing.Size(117, 26);
            this.rdoTheoNgay.TabIndex = 4;
            this.rdoTheoNgay.TabStop = true;
            this.rdoTheoNgay.Text = "Theo ngày";
            this.rdoTheoNgay.UseVisualStyleBackColor = true;
            // 
            // rdoTheoThang
            // 
            this.rdoTheoThang.AutoSize = true;
            this.rdoTheoThang.Location = new System.Drawing.Point(570, 60);
            this.rdoTheoThang.Name = "rdoTheoThang";
            this.rdoTheoThang.Size = new System.Drawing.Size(123, 26);
            this.rdoTheoThang.TabIndex = 5;
            this.rdoTheoThang.TabStop = true;
            this.rdoTheoThang.Text = "Theo tháng";
            this.rdoTheoThang.UseVisualStyleBackColor = true;
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(731, 51);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(112, 44);
            this.btnXem.TabIndex = 6;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            // 
            // btnXuatCsv
            // 
            this.btnXuatCsv.Location = new System.Drawing.Point(881, 51);
            this.btnXuatCsv.Name = "btnXuatCsv";
            this.btnXuatCsv.Size = new System.Drawing.Size(112, 44);
            this.btnXuatCsv.TabIndex = 7;
            this.btnXuatCsv.Text = "Xuất CSV";
            this.btnXuatCsv.UseVisualStyleBackColor = true;
            // 
            // dgvBaoCao
            // 
            this.dgvBaoCao.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvBaoCao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBaoCao.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvBaoCao.Location = new System.Drawing.Point(0, 124);
            this.dgvBaoCao.Name = "dgvBaoCao";
            this.dgvBaoCao.RowHeadersWidth = 51;
            this.dgvBaoCao.RowTemplate.Height = 24;
            this.dgvBaoCao.Size = new System.Drawing.Size(434, 531);
            this.dgvBaoCao.TabIndex = 1;
            // 
            // pnlDuoi
            // 
            this.pnlDuoi.Controls.Add(this.lblTong);
            this.pnlDuoi.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDuoi.Location = new System.Drawing.Point(0, 655);
            this.pnlDuoi.Name = "pnlDuoi";
            this.pnlDuoi.Size = new System.Drawing.Size(1300, 45);
            this.pnlDuoi.TabIndex = 2;
            // 
            // lblTong
            // 
            this.lblTong.AutoSize = true;
            this.lblTong.Location = new System.Drawing.Point(23, 13);
            this.lblTong.Name = "lblTong";
            this.lblTong.Size = new System.Drawing.Size(502, 22);
            this.lblTong.TabIndex = 0;
            this.lblTong.Text = "Tổng: 10.735.000 đ (lượt gửi 9.535.000 + vé tháng 1.200.000)";
            // 
            // chartDoanhThu
            // 
            chartArea1.Name = "ChartArea1";
            this.chartDoanhThu.ChartAreas.Add(chartArea1);
            this.chartDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartDoanhThu.Legends.Add(legend1);
            this.chartDoanhThu.Location = new System.Drawing.Point(434, 124);
            this.chartDoanhThu.Name = "chartDoanhThu";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartDoanhThu.Series.Add(series1);
            this.chartDoanhThu.Size = new System.Drawing.Size(866, 531);
            this.chartDoanhThu.TabIndex = 3;
            this.chartDoanhThu.Text = "chart1";
            // 
            // ucBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.chartDoanhThu);
            this.Controls.Add(this.dgvBaoCao);
            this.Controls.Add(this.pnlDuoi);
            this.Controls.Add(this.grbBaoCaoDoanhThu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ucBaoCao";
            this.Size = new System.Drawing.Size(1300, 700);
            this.grbBaoCaoDoanhThu.ResumeLayout(false);
            this.grbBaoCaoDoanhThu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).EndInit();
            this.pnlDuoi.ResumeLayout(false);
            this.pnlDuoi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbBaoCaoDoanhThu;
        private System.Windows.Forms.Button btnXuatCsv;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.RadioButton rdoTheoThang;
        private System.Windows.Forms.RadioButton rdoTheoNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.DataGridView dgvBaoCao;
        private System.Windows.Forms.Panel pnlDuoi;
        private System.Windows.Forms.Label lblTong;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu;
    }
}
