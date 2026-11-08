// File Designer sinh tự động cho ucVeThang. Dán đè toàn bộ nội dung file ucVeThang.Designer.cs.
namespace QuanLyBaiGiuXe.Views
{
    partial class ucVeThang
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
            this.dgvVeThang = new System.Windows.Forms.DataGridView();
            this.lblCanhBaoVe = new System.Windows.Forms.Label();
            this.pnlNut = new System.Windows.Forms.Panel();
            this.btnDangKy = new System.Windows.Forms.Button();
            this.btnGiaHan = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.lblC47 = new System.Windows.Forms.Label();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.lblC48 = new System.Windows.Forms.Label();
            this.txtBienSo = new System.Windows.Forms.TextBox();
            this.lblC49 = new System.Windows.Forms.Label();
            this.cboKhachHang = new System.Windows.Forms.ComboBox();
            this.lblC50 = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.lblC51 = new System.Windows.Forms.Label();
            this.cboLoaiXe = new System.Windows.Forms.ComboBox();
            this.lblC52 = new System.Windows.Forms.Label();
            this.dtpNgayDangKy = new System.Windows.Forms.DateTimePicker();
            this.lblC53 = new System.Windows.Forms.Label();
            this.numSoThang = new System.Windows.Forms.NumericUpDown();
            this.lblNgayHetHan = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVeThang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoThang)).BeginInit();
            this.pnlNut.SuspendLayout();
            this.grpThongTin.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvVeThang
            // 
            this.dgvVeThang.Name = "dgvVeThang";
            this.dgvVeThang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVeThang.Size = new System.Drawing.Size(1000, 300);
            this.dgvVeThang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVeThang.TabIndex = 0;
            // 
            // lblCanhBaoVe
            // 
            this.lblCanhBaoVe.Name = "lblCanhBaoVe";
            this.lblCanhBaoVe.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblCanhBaoVe.Size = new System.Drawing.Size(1000, 30);
            this.lblCanhBaoVe.Text = "";
            this.lblCanhBaoVe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCanhBaoVe.TabIndex = 1;
            // 
            // pnlNut
            // 
            this.pnlNut.Name = "pnlNut";
            this.pnlNut.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNut.Size = new System.Drawing.Size(1000, 48);
            this.pnlNut.TabIndex = 2;
            // 
            // btnDangKy
            // 
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Text = "Đăng ký";
            this.btnDangKy.Location = new System.Drawing.Point(10, 8);
            this.btnDangKy.Size = new System.Drawing.Size(90, 32);
            this.btnDangKy.UseVisualStyleBackColor = true;
            this.btnDangKy.TabIndex = 0;
            // 
            // btnGiaHan
            // 
            this.btnGiaHan.Name = "btnGiaHan";
            this.btnGiaHan.Text = "Gia hạn";
            this.btnGiaHan.Location = new System.Drawing.Point(110, 8);
            this.btnGiaHan.Size = new System.Drawing.Size(90, 32);
            this.btnGiaHan.UseVisualStyleBackColor = true;
            this.btnGiaHan.TabIndex = 1;
            // 
            // btnSua
            // 
            this.btnSua.Name = "btnSua";
            this.btnSua.Text = "Sửa";
            this.btnSua.Location = new System.Drawing.Point(210, 8);
            this.btnSua.Size = new System.Drawing.Size(90, 32);
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.TabIndex = 2;
            // 
            // btnXoa
            // 
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Text = "Hủy vé";
            this.btnXoa.Location = new System.Drawing.Point(310, 8);
            this.btnXoa.Size = new System.Drawing.Size(90, 32);
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.TabIndex = 3;
            // 
            // lblC47
            // 
            this.lblC47.Name = "lblC47";
            this.lblC47.Text = "Tìm:";
            this.lblC47.Location = new System.Drawing.Point(690, 16);
            this.lblC47.AutoSize = true;
            this.lblC47.TabIndex = 4;
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
            this.grpThongTin.Text = "Thông tin vé tháng";
            this.grpThongTin.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpThongTin.Size = new System.Drawing.Size(1000, 150);
            this.grpThongTin.TabIndex = 3;
            // 
            // lblC48
            // 
            this.lblC48.Name = "lblC48";
            this.lblC48.Text = "Biển số";
            this.lblC48.Location = new System.Drawing.Point(15, 30);
            this.lblC48.AutoSize = true;
            this.lblC48.TabIndex = 0;
            // 
            // txtBienSo
            // 
            this.txtBienSo.Name = "txtBienSo";
            this.txtBienSo.Location = new System.Drawing.Point(15, 50);
            this.txtBienSo.Size = new System.Drawing.Size(150, 20);
            this.txtBienSo.MaxLength = 15;
            this.txtBienSo.TabIndex = 1;
            // 
            // lblC49
            // 
            this.lblC49.Name = "lblC49";
            this.lblC49.Text = "Khách hàng";
            this.lblC49.Location = new System.Drawing.Point(185, 30);
            this.lblC49.AutoSize = true;
            this.lblC49.TabIndex = 2;
            // 
            // cboKhachHang
            // 
            this.cboKhachHang.Name = "cboKhachHang";
            this.cboKhachHang.Location = new System.Drawing.Point(185, 50);
            this.cboKhachHang.Size = new System.Drawing.Size(230, 21);
            this.cboKhachHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhachHang.FormattingEnabled = true;
            this.cboKhachHang.TabIndex = 3;
            // 
            // lblC50
            // 
            this.lblC50.Name = "lblC50";
            this.lblC50.Text = "SĐT";
            this.lblC50.Location = new System.Drawing.Point(435, 30);
            this.lblC50.AutoSize = true;
            this.lblC50.TabIndex = 4;
            // 
            // txtSDT
            // 
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Location = new System.Drawing.Point(435, 50);
            this.txtSDT.Size = new System.Drawing.Size(140, 20);
            this.txtSDT.ReadOnly = true;
            this.txtSDT.TabIndex = 5;
            // 
            // lblC51
            // 
            this.lblC51.Name = "lblC51";
            this.lblC51.Text = "Loại xe";
            this.lblC51.Location = new System.Drawing.Point(595, 30);
            this.lblC51.AutoSize = true;
            this.lblC51.TabIndex = 6;
            // 
            // cboLoaiXe
            // 
            this.cboLoaiXe.Name = "cboLoaiXe";
            this.cboLoaiXe.Location = new System.Drawing.Point(595, 50);
            this.cboLoaiXe.Size = new System.Drawing.Size(130, 21);
            this.cboLoaiXe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiXe.FormattingEnabled = true;
            this.cboLoaiXe.TabIndex = 7;
            // 
            // lblC52
            // 
            this.lblC52.Name = "lblC52";
            this.lblC52.Text = "Ngày đăng ký";
            this.lblC52.Location = new System.Drawing.Point(15, 85);
            this.lblC52.AutoSize = true;
            this.lblC52.TabIndex = 8;
            // 
            // dtpNgayDangKy
            // 
            this.dtpNgayDangKy.Name = "dtpNgayDangKy";
            this.dtpNgayDangKy.Location = new System.Drawing.Point(15, 105);
            this.dtpNgayDangKy.Size = new System.Drawing.Size(150, 20);
            this.dtpNgayDangKy.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayDangKy.TabIndex = 9;
            // 
            // lblC53
            // 
            this.lblC53.Name = "lblC53";
            this.lblC53.Text = "Số tháng";
            this.lblC53.Location = new System.Drawing.Point(185, 85);
            this.lblC53.AutoSize = true;
            this.lblC53.TabIndex = 10;
            // 
            // numSoThang
            // 
            this.numSoThang.Name = "numSoThang";
            this.numSoThang.Location = new System.Drawing.Point(185, 105);
            this.numSoThang.Size = new System.Drawing.Size(90, 20);
            this.numSoThang.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            this.numSoThang.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numSoThang.Increment = new decimal(new int[] { 1, 0, 0, 0 });
            this.numSoThang.Value = new decimal(new int[] { 1, 0, 0, 0 });
            this.numSoThang.TabIndex = 11;
            // 
            // lblNgayHetHan
            // 
            this.lblNgayHetHan.Name = "lblNgayHetHan";
            this.lblNgayHetHan.Text = "Hết hạn: --/--/----";
            this.lblNgayHetHan.Location = new System.Drawing.Point(300, 109);
            this.lblNgayHetHan.AutoSize = true;
            this.lblNgayHetHan.TabIndex = 12;
            // 
            // ucVeThang
            // 
            this.Controls.Add(this.dgvVeThang);
            this.Controls.Add(this.lblCanhBaoVe);
            this.Controls.Add(this.pnlNut);
            this.pnlNut.Controls.Add(this.btnDangKy);
            this.pnlNut.Controls.Add(this.btnGiaHan);
            this.pnlNut.Controls.Add(this.btnSua);
            this.pnlNut.Controls.Add(this.btnXoa);
            this.pnlNut.Controls.Add(this.lblC47);
            this.pnlNut.Controls.Add(this.txtTim);
            this.Controls.Add(this.grpThongTin);
            this.grpThongTin.Controls.Add(this.lblC48);
            this.grpThongTin.Controls.Add(this.txtBienSo);
            this.grpThongTin.Controls.Add(this.lblC49);
            this.grpThongTin.Controls.Add(this.cboKhachHang);
            this.grpThongTin.Controls.Add(this.lblC50);
            this.grpThongTin.Controls.Add(this.txtSDT);
            this.grpThongTin.Controls.Add(this.lblC51);
            this.grpThongTin.Controls.Add(this.cboLoaiXe);
            this.grpThongTin.Controls.Add(this.lblC52);
            this.grpThongTin.Controls.Add(this.dtpNgayDangKy);
            this.grpThongTin.Controls.Add(this.lblC53);
            this.grpThongTin.Controls.Add(this.numSoThang);
            this.grpThongTin.Controls.Add(this.lblNgayHetHan);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ucVeThang";
            this.Size = new System.Drawing.Size(1000, 600);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVeThang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoThang)).EndInit();
            this.pnlNut.ResumeLayout(false);
            this.pnlNut.PerformLayout();
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVeThang;
        private System.Windows.Forms.Label lblCanhBaoVe;
        private System.Windows.Forms.Panel pnlNut;
        private System.Windows.Forms.Button btnDangKy;
        private System.Windows.Forms.Button btnGiaHan;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Label lblC47;
        private System.Windows.Forms.TextBox txtTim;
        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label lblC48;
        private System.Windows.Forms.TextBox txtBienSo;
        private System.Windows.Forms.Label lblC49;
        private System.Windows.Forms.ComboBox cboKhachHang;
        private System.Windows.Forms.Label lblC50;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label lblC51;
        private System.Windows.Forms.ComboBox cboLoaiXe;
        private System.Windows.Forms.Label lblC52;
        private System.Windows.Forms.DateTimePicker dtpNgayDangKy;
        private System.Windows.Forms.Label lblC53;
        private System.Windows.Forms.NumericUpDown numSoThang;
        private System.Windows.Forms.Label lblNgayHetHan;
    }
}