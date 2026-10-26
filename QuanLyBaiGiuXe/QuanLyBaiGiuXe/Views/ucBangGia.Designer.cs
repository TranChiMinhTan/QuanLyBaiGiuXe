namespace QuanLyBaiGiuXe.Views
{
    partial class ucBangGia
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
            this.lblLoaiXe = new System.Windows.Forms.Label();
            this.lblGiaMoiGio = new System.Windows.Forms.Label();
            this.lblPhuThuQuaDem = new System.Windows.Forms.Label();
            this.lblMienPhi = new System.Windows.Forms.Label();
            this.lblSoGio = new System.Windows.Forms.Label();
            this.grbBangGia = new System.Windows.Forms.GroupBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnCapNhap = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.lblGiaVeThang = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numPhuThuQuaDem = new System.Windows.Forms.NumericUpDown();
            this.numSoGio = new System.Windows.Forms.NumericUpDown();
            this.numGiaGio = new System.Windows.Forms.NumericUpDown();
            this.numMienPhiPhut = new System.Windows.Forms.NumericUpDown();
            this.txtLoaiXe = new System.Windows.Forms.TextBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.dgvBangGia = new System.Windows.Forms.DataGridView();
            this.grbBangGia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPhuThuQuaDem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoGio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGiaGio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMienPhiPhut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangGia)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLoaiXe
            // 
            this.lblLoaiXe.AutoSize = true;
            this.lblLoaiXe.Location = new System.Drawing.Point(14, 29);
            this.lblLoaiXe.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLoaiXe.Name = "lblLoaiXe";
            this.lblLoaiXe.Size = new System.Drawing.Size(55, 18);
            this.lblLoaiXe.TabIndex = 0;
            this.lblLoaiXe.Text = "Loại xe";
            // 
            // lblGiaMoiGio
            // 
            this.lblGiaMoiGio.AutoSize = true;
            this.lblGiaMoiGio.Location = new System.Drawing.Point(374, 29);
            this.lblGiaMoiGio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGiaMoiGio.Name = "lblGiaMoiGio";
            this.lblGiaMoiGio.Size = new System.Drawing.Size(84, 18);
            this.lblGiaMoiGio.TabIndex = 1;
            this.lblGiaMoiGio.Text = "Giá mỗi giờ";
            // 
            // lblPhuThuQuaDem
            // 
            this.lblPhuThuQuaDem.AutoSize = true;
            this.lblPhuThuQuaDem.Location = new System.Drawing.Point(690, 29);
            this.lblPhuThuQuaDem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPhuThuQuaDem.Name = "lblPhuThuQuaDem";
            this.lblPhuThuQuaDem.Size = new System.Drawing.Size(119, 18);
            this.lblPhuThuQuaDem.TabIndex = 2;
            this.lblPhuThuQuaDem.Text = "Phụ thu qua đêm";
            // 
            // lblMienPhi
            // 
            this.lblMienPhi.AutoSize = true;
            this.lblMienPhi.Location = new System.Drawing.Point(216, 29);
            this.lblMienPhi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMienPhi.Name = "lblMienPhi";
            this.lblMienPhi.Size = new System.Drawing.Size(105, 18);
            this.lblMienPhi.TabIndex = 3;
            this.lblMienPhi.Text = "Miễn phí (phút)";
            // 
            // lblSoGio
            // 
            this.lblSoGio.AutoSize = true;
            this.lblSoGio.Location = new System.Drawing.Point(532, 29);
            this.lblSoGio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSoGio.Name = "lblSoGio";
            this.lblSoGio.Size = new System.Drawing.Size(51, 18);
            this.lblSoGio.TabIndex = 4;
            this.lblSoGio.Text = "Số giờ";
            // 
            // grbBangGia
            // 
            this.grbBangGia.Controls.Add(this.btnXoa);
            this.grbBangGia.Controls.Add(this.btnCapNhap);
            this.grbBangGia.Controls.Add(this.btnThem);
            this.grbBangGia.Controls.Add(this.lblGiaVeThang);
            this.grbBangGia.Controls.Add(this.numericUpDown1);
            this.grbBangGia.Controls.Add(this.numPhuThuQuaDem);
            this.grbBangGia.Controls.Add(this.numSoGio);
            this.grbBangGia.Controls.Add(this.numGiaGio);
            this.grbBangGia.Controls.Add(this.numMienPhiPhut);
            this.grbBangGia.Controls.Add(this.txtLoaiXe);
            this.grbBangGia.Controls.Add(this.lblLoaiXe);
            this.grbBangGia.Controls.Add(this.lblPhuThuQuaDem);
            this.grbBangGia.Controls.Add(this.lblSoGio);
            this.grbBangGia.Controls.Add(this.lblMienPhi);
            this.grbBangGia.Controls.Add(this.lblGiaMoiGio);
            this.grbBangGia.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbBangGia.Location = new System.Drawing.Point(0, 0);
            this.grbBangGia.Name = "grbBangGia";
            this.grbBangGia.Size = new System.Drawing.Size(1000, 151);
            this.grbBangGia.TabIndex = 5;
            this.grbBangGia.TabStop = false;
            this.grbBangGia.Text = "Bảng giá theo loại xe";
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(311, 96);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(104, 29);
            this.btnXoa.TabIndex = 14;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnCapNhap
            // 
            this.btnCapNhap.Location = new System.Drawing.Point(165, 96);
            this.btnCapNhap.Name = "btnCapNhap";
            this.btnCapNhap.Size = new System.Drawing.Size(104, 29);
            this.btnCapNhap.TabIndex = 13;
            this.btnCapNhap.Text = "Cập nhật";
            this.btnCapNhap.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(19, 96);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(104, 29);
            this.btnThem.TabIndex = 12;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            // 
            // lblGiaVeThang
            // 
            this.lblGiaVeThang.AutoSize = true;
            this.lblGiaVeThang.Location = new System.Drawing.Point(848, 29);
            this.lblGiaVeThang.Name = "lblGiaVeThang";
            this.lblGiaVeThang.Size = new System.Drawing.Size(90, 18);
            this.lblGiaVeThang.TabIndex = 11;
            this.lblGiaVeThang.Text = "Giá vé tháng";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Increment = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(851, 50);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 24);
            this.numericUpDown1.TabIndex = 10;
            // 
            // numPhuThuQuaDem
            // 
            this.numPhuThuQuaDem.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numPhuThuQuaDem.Location = new System.Drawing.Point(693, 50);
            this.numPhuThuQuaDem.Name = "numPhuThuQuaDem";
            this.numPhuThuQuaDem.Size = new System.Drawing.Size(120, 24);
            this.numPhuThuQuaDem.TabIndex = 9;
            // 
            // numSoGio
            // 
            this.numSoGio.Location = new System.Drawing.Point(535, 50);
            this.numSoGio.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numSoGio.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSoGio.Name = "numSoGio";
            this.numSoGio.Size = new System.Drawing.Size(120, 24);
            this.numSoGio.TabIndex = 8;
            this.numSoGio.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numGiaGio
            // 
            this.numGiaGio.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numGiaGio.Location = new System.Drawing.Point(377, 50);
            this.numGiaGio.Name = "numGiaGio";
            this.numGiaGio.Size = new System.Drawing.Size(120, 24);
            this.numGiaGio.TabIndex = 7;
            // 
            // numMienPhiPhut
            // 
            this.numMienPhiPhut.Location = new System.Drawing.Point(219, 50);
            this.numMienPhiPhut.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.numMienPhiPhut.Name = "numMienPhiPhut";
            this.numMienPhiPhut.Size = new System.Drawing.Size(120, 24);
            this.numMienPhiPhut.TabIndex = 6;
            // 
            // txtLoaiXe
            // 
            this.txtLoaiXe.Location = new System.Drawing.Point(17, 50);
            this.txtLoaiXe.Name = "txtLoaiXe";
            this.txtLoaiXe.Size = new System.Drawing.Size(164, 24);
            this.txtLoaiXe.TabIndex = 5;
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblGhiChu.Location = new System.Drawing.Point(0, 542);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(305, 18);
            this.lblGhiChu.TabIndex = 6;
            this.lblGhiChu.Text = "Chỉ tài khoản Quản lý mới sửa được bảng giá.";
            // 
            // dgvBangGia
            // 
            this.dgvBangGia.AllowUserToAddRows = false;
            this.dgvBangGia.AllowUserToDeleteRows = false;
            this.dgvBangGia.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvBangGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBangGia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBangGia.Location = new System.Drawing.Point(0, 151);
            this.dgvBangGia.Name = "dgvBangGia";
            this.dgvBangGia.RowHeadersVisible = false;
            this.dgvBangGia.Size = new System.Drawing.Size(1000, 391);
            this.dgvBangGia.TabIndex = 7;
            // 
            // ucBangGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvBangGia);
            this.Controls.Add(this.lblGhiChu);
            this.Controls.Add(this.grbBangGia);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucBangGia";
            this.Size = new System.Drawing.Size(1000, 560);
            this.grbBangGia.ResumeLayout(false);
            this.grbBangGia.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPhuThuQuaDem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoGio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGiaGio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMienPhiPhut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangGia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLoaiXe;
        private System.Windows.Forms.Label lblGiaMoiGio;
        private System.Windows.Forms.Label lblPhuThuQuaDem;
        private System.Windows.Forms.Label lblMienPhi;
        private System.Windows.Forms.Label lblSoGio;
        private System.Windows.Forms.GroupBox grbBangGia;
        private System.Windows.Forms.NumericUpDown numPhuThuQuaDem;
        private System.Windows.Forms.NumericUpDown numSoGio;
        private System.Windows.Forms.NumericUpDown numGiaGio;
        private System.Windows.Forms.NumericUpDown numMienPhiPhut;
        private System.Windows.Forms.TextBox txtLoaiXe;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnCapNhap;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label lblGiaVeThang;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.DataGridView dgvBangGia;
    }
}
