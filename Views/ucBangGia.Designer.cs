// File Designer sinh tự động cho ucBangGia. Dán đè toàn bộ nội dung file ucBangGia.Designer.cs.
namespace QuanLyBaiGiuXe.Views
{
    partial class ucBangGia
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.dgvBangGia = new System.Windows.Forms.DataGridView();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.pnlNut = new System.Windows.Forms.Panel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.lblC35 = new System.Windows.Forms.Label();
            this.cboLoaiXe = new System.Windows.Forms.ComboBox();
            this.lblC36 = new System.Windows.Forms.Label();
            this.numMienPhiPhut = new System.Windows.Forms.NumericUpDown();
            this.lblC37 = new System.Windows.Forms.Label();
            this.numGiaKhoi = new System.Windows.Forms.NumericUpDown();
            this.lblC38 = new System.Windows.Forms.Label();
            this.numSoGioKhoi = new System.Windows.Forms.NumericUpDown();
            this.lblC39 = new System.Windows.Forms.Label();
            this.numPhuThuQuaDem = new System.Windows.Forms.NumericUpDown();
            this.lblC40 = new System.Windows.Forms.Label();
            this.numGiaVeThang = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMienPhiPhut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGiaKhoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoGioKhoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPhuThuQuaDem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGiaVeThang)).BeginInit();
            this.pnlNut.SuspendLayout();
            this.grpThongTin.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvBangGia
            // 
            this.dgvBangGia.Name = "dgvBangGia";
            this.dgvBangGia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBangGia.Size = new System.Drawing.Size(1000, 300);
            this.dgvBangGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBangGia.TabIndex = 0;
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblGhiChu.Size = new System.Drawing.Size(1000, 28);
            this.lblGhiChu.Text = "Chỉ tài khoản Quản lý mới sửa được bảng giá.";
            this.lblGhiChu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGhiChu.ForeColor = System.Drawing.Color.DimGray;
            this.lblGhiChu.TabIndex = 1;
            // 
            // pnlNut
            // 
            this.pnlNut.Name = "pnlNut";
            this.pnlNut.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNut.Size = new System.Drawing.Size(1000, 48);
            this.pnlNut.TabIndex = 2;
            // 
            // btnThem
            // 
            this.btnThem.Name = "btnThem";
            this.btnThem.Text = "Thêm";
            this.btnThem.Location = new System.Drawing.Point(10, 8);
            this.btnThem.Size = new System.Drawing.Size(90, 32);
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.TabIndex = 0;
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.Location = new System.Drawing.Point(110, 8);
            this.btnCapNhat.Size = new System.Drawing.Size(90, 32);
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.TabIndex = 1;
            // 
            // btnXoa
            // 
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Location = new System.Drawing.Point(210, 8);
            this.btnXoa.Size = new System.Drawing.Size(90, 32);
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.TabIndex = 2;
            // 
            // grpThongTin
            // 
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Text = "Bảng giá theo loại xe";
            this.grpThongTin.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpThongTin.Size = new System.Drawing.Size(1000, 110);
            this.grpThongTin.TabIndex = 3;
            // 
            // lblC35
            // 
            this.lblC35.Name = "lblC35";
            this.lblC35.Text = "Loại xe";
            this.lblC35.Location = new System.Drawing.Point(15, 30);
            this.lblC35.AutoSize = true;
            this.lblC35.TabIndex = 0;
            // 
            // cboLoaiXe
            // 
            this.cboLoaiXe.Name = "cboLoaiXe";
            this.cboLoaiXe.Location = new System.Drawing.Point(15, 50);
            this.cboLoaiXe.Size = new System.Drawing.Size(150, 21);
            this.cboLoaiXe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiXe.FormattingEnabled = true;
            this.cboLoaiXe.TabIndex = 1;
            // 
            // lblC36
            // 
            this.lblC36.Name = "lblC36";
            this.lblC36.Text = "Miễn phí (phút)";
            this.lblC36.Location = new System.Drawing.Point(185, 30);
            this.lblC36.AutoSize = true;
            this.lblC36.TabIndex = 2;
            // 
            // numMienPhiPhut
            // 
            this.numMienPhiPhut.Name = "numMienPhiPhut";
            this.numMienPhiPhut.Location = new System.Drawing.Point(185, 50);
            this.numMienPhiPhut.Size = new System.Drawing.Size(110, 20);
            this.numMienPhiPhut.Maximum = new decimal(new int[] { 240, 0, 0, 0 });
            this.numMienPhiPhut.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.numMienPhiPhut.Increment = new decimal(new int[] { 1, 0, 0, 0 });
            this.numMienPhiPhut.Value = new decimal(new int[] { 15, 0, 0, 0 });
            this.numMienPhiPhut.TabIndex = 3;
            // 
            // lblC37
            // 
            this.lblC37.Name = "lblC37";
            this.lblC37.Text = "Giá mỗi khối (đ)";
            this.lblC37.Location = new System.Drawing.Point(315, 30);
            this.lblC37.AutoSize = true;
            this.lblC37.TabIndex = 4;
            // 
            // numGiaKhoi
            // 
            this.numGiaKhoi.Name = "numGiaKhoi";
            this.numGiaKhoi.Location = new System.Drawing.Point(315, 50);
            this.numGiaKhoi.Size = new System.Drawing.Size(120, 20);
            this.numGiaKhoi.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            this.numGiaKhoi.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.numGiaKhoi.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            this.numGiaKhoi.Value = new decimal(new int[] { 3000, 0, 0, 0 });
            this.numGiaKhoi.ThousandsSeparator = true;
            this.numGiaKhoi.TabIndex = 5;
            // 
            // lblC38
            // 
            this.lblC38.Name = "lblC38";
            this.lblC38.Text = "Số giờ/khối";
            this.lblC38.Location = new System.Drawing.Point(455, 30);
            this.lblC38.AutoSize = true;
            this.lblC38.TabIndex = 6;
            // 
            // numSoGioKhoi
            // 
            this.numSoGioKhoi.Name = "numSoGioKhoi";
            this.numSoGioKhoi.Location = new System.Drawing.Point(455, 50);
            this.numSoGioKhoi.Size = new System.Drawing.Size(90, 20);
            this.numSoGioKhoi.Maximum = new decimal(new int[] { 24, 0, 0, 0 });
            this.numSoGioKhoi.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numSoGioKhoi.Increment = new decimal(new int[] { 1, 0, 0, 0 });
            this.numSoGioKhoi.Value = new decimal(new int[] { 4, 0, 0, 0 });
            this.numSoGioKhoi.TabIndex = 7;
            // 
            // lblC39
            // 
            this.lblC39.Name = "lblC39";
            this.lblC39.Text = "Phụ thu qua đêm (đ)";
            this.lblC39.Location = new System.Drawing.Point(565, 30);
            this.lblC39.AutoSize = true;
            this.lblC39.TabIndex = 8;
            // 
            // numPhuThuQuaDem
            // 
            this.numPhuThuQuaDem.Name = "numPhuThuQuaDem";
            this.numPhuThuQuaDem.Location = new System.Drawing.Point(565, 50);
            this.numPhuThuQuaDem.Size = new System.Drawing.Size(130, 20);
            this.numPhuThuQuaDem.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            this.numPhuThuQuaDem.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.numPhuThuQuaDem.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            this.numPhuThuQuaDem.Value = new decimal(new int[] { 5000, 0, 0, 0 });
            this.numPhuThuQuaDem.ThousandsSeparator = true;
            this.numPhuThuQuaDem.TabIndex = 9;
            // 
            // lblC40
            // 
            this.lblC40.Name = "lblC40";
            this.lblC40.Text = "Giá vé tháng (đ)";
            this.lblC40.Location = new System.Drawing.Point(715, 30);
            this.lblC40.AutoSize = true;
            this.lblC40.TabIndex = 10;
            // 
            // numGiaVeThang
            // 
            this.numGiaVeThang.Name = "numGiaVeThang";
            this.numGiaVeThang.Location = new System.Drawing.Point(715, 50);
            this.numGiaVeThang.Size = new System.Drawing.Size(140, 20);
            this.numGiaVeThang.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            this.numGiaVeThang.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.numGiaVeThang.Increment = new decimal(new int[] { 10000, 0, 0, 0 });
            this.numGiaVeThang.Value = new decimal(new int[] { 300000, 0, 0, 0 });
            this.numGiaVeThang.ThousandsSeparator = true;
            this.numGiaVeThang.TabIndex = 11;
            // 
            // ucBangGia
            // 
            this.Controls.Add(this.dgvBangGia);
            this.Controls.Add(this.lblGhiChu);
            this.Controls.Add(this.pnlNut);
            this.pnlNut.Controls.Add(this.btnThem);
            this.pnlNut.Controls.Add(this.btnCapNhat);
            this.pnlNut.Controls.Add(this.btnXoa);
            this.Controls.Add(this.grpThongTin);
            this.grpThongTin.Controls.Add(this.lblC35);
            this.grpThongTin.Controls.Add(this.cboLoaiXe);
            this.grpThongTin.Controls.Add(this.lblC36);
            this.grpThongTin.Controls.Add(this.numMienPhiPhut);
            this.grpThongTin.Controls.Add(this.lblC37);
            this.grpThongTin.Controls.Add(this.numGiaKhoi);
            this.grpThongTin.Controls.Add(this.lblC38);
            this.grpThongTin.Controls.Add(this.numSoGioKhoi);
            this.grpThongTin.Controls.Add(this.lblC39);
            this.grpThongTin.Controls.Add(this.numPhuThuQuaDem);
            this.grpThongTin.Controls.Add(this.lblC40);
            this.grpThongTin.Controls.Add(this.numGiaVeThang);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ucBangGia";
            this.Size = new System.Drawing.Size(1000, 560);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMienPhiPhut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGiaKhoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoGioKhoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPhuThuQuaDem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGiaVeThang)).EndInit();
            this.pnlNut.ResumeLayout(false);
            this.pnlNut.PerformLayout();
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBangGia;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.Panel pnlNut;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label lblC35;
        private System.Windows.Forms.ComboBox cboLoaiXe;
        private System.Windows.Forms.Label lblC36;
        private System.Windows.Forms.NumericUpDown numMienPhiPhut;
        private System.Windows.Forms.Label lblC37;
        private System.Windows.Forms.NumericUpDown numGiaKhoi;
        private System.Windows.Forms.Label lblC38;
        private System.Windows.Forms.NumericUpDown numSoGioKhoi;
        private System.Windows.Forms.Label lblC39;
        private System.Windows.Forms.NumericUpDown numPhuThuQuaDem;
        private System.Windows.Forms.Label lblC40;
        private System.Windows.Forms.NumericUpDown numGiaVeThang;
    }
}