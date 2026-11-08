// File Designer sinh tự động cho ucLoaiXe. Dán đè toàn bộ nội dung file ucLoaiXe.Designer.cs.
namespace QuanLyBaiGiuXe.Views
{
    partial class ucLoaiXe
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
            this.dgvLoaiXe = new System.Windows.Forms.DataGridView();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.pnlNut = new System.Windows.Forms.Panel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.lblC25 = new System.Windows.Forms.Label();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.lblC26 = new System.Windows.Forms.Label();
            this.txtMaLoai = new System.Windows.Forms.TextBox();
            this.lblC27 = new System.Windows.Forms.Label();
            this.txtTenLoai = new System.Windows.Forms.TextBox();
            this.lblC28 = new System.Windows.Forms.Label();
            this.numSucChua = new System.Windows.Forms.NumericUpDown();
            this.lblC29 = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiXe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSucChua)).BeginInit();
            this.pnlNut.SuspendLayout();
            this.grpThongTin.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvLoaiXe
            // 
            this.dgvLoaiXe.Name = "dgvLoaiXe";
            this.dgvLoaiXe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLoaiXe.Size = new System.Drawing.Size(1000, 300);
            this.dgvLoaiXe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoaiXe.TabIndex = 0;
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblGhiChu.Size = new System.Drawing.Size(1000, 28);
            this.lblGhiChu.Text = "Không cho xóa loại xe đã có thẻ, lượt gửi hoặc vé tháng.";
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
            // btnSua
            // 
            this.btnSua.Name = "btnSua";
            this.btnSua.Text = "Sửa";
            this.btnSua.Location = new System.Drawing.Point(110, 8);
            this.btnSua.Size = new System.Drawing.Size(90, 32);
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.TabIndex = 1;
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
            // btnLamMoi
            // 
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.Location = new System.Drawing.Point(310, 8);
            this.btnLamMoi.Size = new System.Drawing.Size(90, 32);
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.TabIndex = 3;
            // 
            // lblC25
            // 
            this.lblC25.Name = "lblC25";
            this.lblC25.Text = "Tìm:";
            this.lblC25.Location = new System.Drawing.Point(690, 16);
            this.lblC25.AutoSize = true;
            this.lblC25.TabIndex = 4;
            // 
            // txtTim
            // 
            this.txtTim.Name = "txtTim";
            this.txtTim.Location = new System.Drawing.Point(730, 13);
            this.txtTim.Size = new System.Drawing.Size(240, 20);
            this.txtTim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTim.TabIndex = 5;
            // 
            // grpThongTin
            // 
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Text = "Thông tin loại xe";
            this.grpThongTin.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpThongTin.Size = new System.Drawing.Size(1000, 110);
            this.grpThongTin.TabIndex = 3;
            // 
            // lblC26
            // 
            this.lblC26.Name = "lblC26";
            this.lblC26.Text = "Mã loại";
            this.lblC26.Location = new System.Drawing.Point(15, 30);
            this.lblC26.AutoSize = true;
            this.lblC26.TabIndex = 0;
            // 
            // txtMaLoai
            // 
            this.txtMaLoai.Name = "txtMaLoai";
            this.txtMaLoai.Location = new System.Drawing.Point(15, 50);
            this.txtMaLoai.Size = new System.Drawing.Size(90, 20);
            this.txtMaLoai.ReadOnly = true;
            this.txtMaLoai.TabIndex = 1;
            // 
            // lblC27
            // 
            this.lblC27.Name = "lblC27";
            this.lblC27.Text = "Tên loại";
            this.lblC27.Location = new System.Drawing.Point(125, 30);
            this.lblC27.AutoSize = true;
            this.lblC27.TabIndex = 2;
            // 
            // txtTenLoai
            // 
            this.txtTenLoai.Name = "txtTenLoai";
            this.txtTenLoai.Location = new System.Drawing.Point(125, 50);
            this.txtTenLoai.Size = new System.Drawing.Size(200, 20);
            this.txtTenLoai.MaxLength = 50;
            this.txtTenLoai.TabIndex = 3;
            // 
            // lblC28
            // 
            this.lblC28.Name = "lblC28";
            this.lblC28.Text = "Sức chứa (chỗ)";
            this.lblC28.Location = new System.Drawing.Point(345, 30);
            this.lblC28.AutoSize = true;
            this.lblC28.TabIndex = 4;
            // 
            // numSucChua
            // 
            this.numSucChua.Name = "numSucChua";
            this.numSucChua.Location = new System.Drawing.Point(345, 50);
            this.numSucChua.Size = new System.Drawing.Size(110, 20);
            this.numSucChua.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            this.numSucChua.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numSucChua.Increment = new decimal(new int[] { 1, 0, 0, 0 });
            this.numSucChua.Value = new decimal(new int[] { 1, 0, 0, 0 });
            this.numSucChua.TabIndex = 5;
            // 
            // lblC29
            // 
            this.lblC29.Name = "lblC29";
            this.lblC29.Text = "Mô tả";
            this.lblC29.Location = new System.Drawing.Point(475, 30);
            this.lblC29.AutoSize = true;
            this.lblC29.TabIndex = 6;
            // 
            // txtMoTa
            // 
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Location = new System.Drawing.Point(475, 50);
            this.txtMoTa.Size = new System.Drawing.Size(380, 20);
            this.txtMoTa.MaxLength = 200;
            this.txtMoTa.TabIndex = 7;
            // 
            // ucLoaiXe
            // 
            this.Controls.Add(this.dgvLoaiXe);
            this.Controls.Add(this.lblGhiChu);
            this.Controls.Add(this.pnlNut);
            this.pnlNut.Controls.Add(this.btnThem);
            this.pnlNut.Controls.Add(this.btnSua);
            this.pnlNut.Controls.Add(this.btnXoa);
            this.pnlNut.Controls.Add(this.btnLamMoi);
            this.pnlNut.Controls.Add(this.lblC25);
            this.pnlNut.Controls.Add(this.txtTim);
            this.Controls.Add(this.grpThongTin);
            this.grpThongTin.Controls.Add(this.lblC26);
            this.grpThongTin.Controls.Add(this.txtMaLoai);
            this.grpThongTin.Controls.Add(this.lblC27);
            this.grpThongTin.Controls.Add(this.txtTenLoai);
            this.grpThongTin.Controls.Add(this.lblC28);
            this.grpThongTin.Controls.Add(this.numSucChua);
            this.grpThongTin.Controls.Add(this.lblC29);
            this.grpThongTin.Controls.Add(this.txtMoTa);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ucLoaiXe";
            this.Size = new System.Drawing.Size(1000, 560);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiXe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSucChua)).EndInit();
            this.pnlNut.ResumeLayout(false);
            this.pnlNut.PerformLayout();
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLoaiXe;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.Panel pnlNut;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Label lblC25;
        private System.Windows.Forms.TextBox txtTim;
        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label lblC26;
        private System.Windows.Forms.TextBox txtMaLoai;
        private System.Windows.Forms.Label lblC27;
        private System.Windows.Forms.TextBox txtTenLoai;
        private System.Windows.Forms.Label lblC28;
        private System.Windows.Forms.NumericUpDown numSucChua;
        private System.Windows.Forms.Label lblC29;
        private System.Windows.Forms.TextBox txtMoTa;
    }
}