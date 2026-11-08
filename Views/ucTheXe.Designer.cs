// File Designer sinh tự động cho ucTheXe. Dán đè toàn bộ nội dung file ucTheXe.Designer.cs.
namespace QuanLyBaiGiuXe.Views
{
    partial class ucTheXe
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
            this.dgvTheXe = new System.Windows.Forms.DataGridView();
            this.pnlNut = new System.Windows.Forms.Panel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.lblC30 = new System.Windows.Forms.Label();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.lblC31 = new System.Windows.Forms.Label();
            this.txtMaThe = new System.Windows.Forms.TextBox();
            this.lblC32 = new System.Windows.Forms.Label();
            this.cboLoaiThe = new System.Windows.Forms.ComboBox();
            this.lblC33 = new System.Windows.Forms.Label();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.lblC34 = new System.Windows.Forms.Label();
            this.dtpNgayCap = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTheXe)).BeginInit();
            this.pnlNut.SuspendLayout();
            this.grpThongTin.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTheXe
            // 
            this.dgvTheXe.Name = "dgvTheXe";
            this.dgvTheXe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTheXe.Size = new System.Drawing.Size(1000, 300);
            this.dgvTheXe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTheXe.TabIndex = 0;
            // 
            // pnlNut
            // 
            this.pnlNut.Name = "pnlNut";
            this.pnlNut.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNut.Size = new System.Drawing.Size(1000, 48);
            this.pnlNut.TabIndex = 1;
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
            // lblC30
            // 
            this.lblC30.Name = "lblC30";
            this.lblC30.Text = "Tìm:";
            this.lblC30.Location = new System.Drawing.Point(690, 16);
            this.lblC30.AutoSize = true;
            this.lblC30.TabIndex = 4;
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
            this.grpThongTin.Text = "Thông tin thẻ xe";
            this.grpThongTin.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpThongTin.Size = new System.Drawing.Size(1000, 110);
            this.grpThongTin.TabIndex = 2;
            // 
            // lblC31
            // 
            this.lblC31.Name = "lblC31";
            this.lblC31.Text = "Mã thẻ";
            this.lblC31.Location = new System.Drawing.Point(15, 30);
            this.lblC31.AutoSize = true;
            this.lblC31.TabIndex = 0;
            // 
            // txtMaThe
            // 
            this.txtMaThe.Name = "txtMaThe";
            this.txtMaThe.Location = new System.Drawing.Point(15, 50);
            this.txtMaThe.Size = new System.Drawing.Size(110, 20);
            this.txtMaThe.MaxLength = 10;
            this.txtMaThe.TabIndex = 1;
            // 
            // lblC32
            // 
            this.lblC32.Name = "lblC32";
            this.lblC32.Text = "Loại thẻ";
            this.lblC32.Location = new System.Drawing.Point(145, 30);
            this.lblC32.AutoSize = true;
            this.lblC32.TabIndex = 2;
            // 
            // cboLoaiThe
            // 
            this.cboLoaiThe.Name = "cboLoaiThe";
            this.cboLoaiThe.Location = new System.Drawing.Point(145, 50);
            this.cboLoaiThe.Size = new System.Drawing.Size(160, 21);
            this.cboLoaiThe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiThe.FormattingEnabled = true;
            this.cboLoaiThe.TabIndex = 3;
            // 
            // lblC33
            // 
            this.lblC33.Name = "lblC33";
            this.lblC33.Text = "Trạng thái";
            this.lblC33.Location = new System.Drawing.Point(325, 30);
            this.lblC33.AutoSize = true;
            this.lblC33.TabIndex = 4;
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Location = new System.Drawing.Point(325, 50);
            this.cboTrangThai.Size = new System.Drawing.Size(160, 21);
            this.cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThai.FormattingEnabled = true;
            this.cboTrangThai.TabIndex = 5;
            // 
            // lblC34
            // 
            this.lblC34.Name = "lblC34";
            this.lblC34.Text = "Ngày cấp";
            this.lblC34.Location = new System.Drawing.Point(505, 30);
            this.lblC34.AutoSize = true;
            this.lblC34.TabIndex = 6;
            // 
            // dtpNgayCap
            // 
            this.dtpNgayCap.Name = "dtpNgayCap";
            this.dtpNgayCap.Location = new System.Drawing.Point(505, 50);
            this.dtpNgayCap.Size = new System.Drawing.Size(140, 20);
            this.dtpNgayCap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayCap.TabIndex = 7;
            // 
            // ucTheXe
            // 
            this.Controls.Add(this.dgvTheXe);
            this.Controls.Add(this.pnlNut);
            this.pnlNut.Controls.Add(this.btnThem);
            this.pnlNut.Controls.Add(this.btnSua);
            this.pnlNut.Controls.Add(this.btnXoa);
            this.pnlNut.Controls.Add(this.btnLamMoi);
            this.pnlNut.Controls.Add(this.lblC30);
            this.pnlNut.Controls.Add(this.txtTim);
            this.Controls.Add(this.grpThongTin);
            this.grpThongTin.Controls.Add(this.lblC31);
            this.grpThongTin.Controls.Add(this.txtMaThe);
            this.grpThongTin.Controls.Add(this.lblC32);
            this.grpThongTin.Controls.Add(this.cboLoaiThe);
            this.grpThongTin.Controls.Add(this.lblC33);
            this.grpThongTin.Controls.Add(this.cboTrangThai);
            this.grpThongTin.Controls.Add(this.lblC34);
            this.grpThongTin.Controls.Add(this.dtpNgayCap);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ucTheXe";
            this.Size = new System.Drawing.Size(1000, 560);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTheXe)).EndInit();
            this.pnlNut.ResumeLayout(false);
            this.pnlNut.PerformLayout();
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTheXe;
        private System.Windows.Forms.Panel pnlNut;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Label lblC30;
        private System.Windows.Forms.TextBox txtTim;
        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label lblC31;
        private System.Windows.Forms.TextBox txtMaThe;
        private System.Windows.Forms.Label lblC32;
        private System.Windows.Forms.ComboBox cboLoaiThe;
        private System.Windows.Forms.Label lblC33;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.Label lblC34;
        private System.Windows.Forms.DateTimePicker dtpNgayCap;
    }
}