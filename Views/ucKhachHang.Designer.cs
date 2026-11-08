// File Designer sinh tự động cho ucKhachHang. Dán đè toàn bộ nội dung file ucKhachHang.Designer.cs.
namespace QuanLyBaiGiuXe.Views
{
    partial class ucKhachHang
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
            this.dgvKhachHang = new System.Windows.Forms.DataGridView();
            this.pnlNut = new System.Windows.Forms.Panel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.lblC41 = new System.Windows.Forms.Label();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.lblC42 = new System.Windows.Forms.Label();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.lblC43 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblC44 = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.lblC45 = new System.Windows.Forms.Label();
            this.txtCCCD = new System.Windows.Forms.TextBox();
            this.lblC46 = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).BeginInit();
            this.pnlNut.SuspendLayout();
            this.grpThongTin.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvKhachHang
            // 
            this.dgvKhachHang.Name = "dgvKhachHang";
            this.dgvKhachHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKhachHang.Size = new System.Drawing.Size(1000, 300);
            this.dgvKhachHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhachHang.TabIndex = 0;
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
            // lblC41
            // 
            this.lblC41.Name = "lblC41";
            this.lblC41.Text = "Tìm:";
            this.lblC41.Location = new System.Drawing.Point(690, 16);
            this.lblC41.AutoSize = true;
            this.lblC41.TabIndex = 4;
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
            this.grpThongTin.Text = "Thông tin khách hàng";
            this.grpThongTin.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpThongTin.Size = new System.Drawing.Size(1000, 150);
            this.grpThongTin.TabIndex = 2;
            // 
            // lblC42
            // 
            this.lblC42.Name = "lblC42";
            this.lblC42.Text = "Mã KH";
            this.lblC42.Location = new System.Drawing.Point(15, 30);
            this.lblC42.AutoSize = true;
            this.lblC42.TabIndex = 0;
            // 
            // txtMaKH
            // 
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.Location = new System.Drawing.Point(15, 50);
            this.txtMaKH.Size = new System.Drawing.Size(90, 20);
            this.txtMaKH.ReadOnly = true;
            this.txtMaKH.TabIndex = 1;
            // 
            // lblC43
            // 
            this.lblC43.Name = "lblC43";
            this.lblC43.Text = "Họ tên";
            this.lblC43.Location = new System.Drawing.Point(125, 30);
            this.lblC43.AutoSize = true;
            this.lblC43.TabIndex = 2;
            // 
            // txtHoTen
            // 
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Location = new System.Drawing.Point(125, 50);
            this.txtHoTen.Size = new System.Drawing.Size(220, 20);
            this.txtHoTen.MaxLength = 100;
            this.txtHoTen.TabIndex = 3;
            // 
            // lblC44
            // 
            this.lblC44.Name = "lblC44";
            this.lblC44.Text = "SĐT";
            this.lblC44.Location = new System.Drawing.Point(365, 30);
            this.lblC44.AutoSize = true;
            this.lblC44.TabIndex = 4;
            // 
            // txtSDT
            // 
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Location = new System.Drawing.Point(365, 50);
            this.txtSDT.Size = new System.Drawing.Size(130, 20);
            this.txtSDT.MaxLength = 11;
            this.txtSDT.TabIndex = 5;
            // 
            // lblC45
            // 
            this.lblC45.Name = "lblC45";
            this.lblC45.Text = "CCCD";
            this.lblC45.Location = new System.Drawing.Point(515, 30);
            this.lblC45.AutoSize = true;
            this.lblC45.TabIndex = 6;
            // 
            // txtCCCD
            // 
            this.txtCCCD.Name = "txtCCCD";
            this.txtCCCD.Location = new System.Drawing.Point(515, 50);
            this.txtCCCD.Size = new System.Drawing.Size(150, 20);
            this.txtCCCD.MaxLength = 12;
            this.txtCCCD.TabIndex = 7;
            // 
            // lblC46
            // 
            this.lblC46.Name = "lblC46";
            this.lblC46.Text = "Địa chỉ";
            this.lblC46.Location = new System.Drawing.Point(15, 85);
            this.lblC46.AutoSize = true;
            this.lblC46.TabIndex = 8;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Location = new System.Drawing.Point(15, 105);
            this.txtDiaChi.Size = new System.Drawing.Size(650, 20);
            this.txtDiaChi.MaxLength = 200;
            this.txtDiaChi.TabIndex = 9;
            // 
            // ucKhachHang
            // 
            this.Controls.Add(this.dgvKhachHang);
            this.Controls.Add(this.pnlNut);
            this.pnlNut.Controls.Add(this.btnThem);
            this.pnlNut.Controls.Add(this.btnSua);
            this.pnlNut.Controls.Add(this.btnXoa);
            this.pnlNut.Controls.Add(this.btnLamMoi);
            this.pnlNut.Controls.Add(this.lblC41);
            this.pnlNut.Controls.Add(this.txtTim);
            this.Controls.Add(this.grpThongTin);
            this.grpThongTin.Controls.Add(this.lblC42);
            this.grpThongTin.Controls.Add(this.txtMaKH);
            this.grpThongTin.Controls.Add(this.lblC43);
            this.grpThongTin.Controls.Add(this.txtHoTen);
            this.grpThongTin.Controls.Add(this.lblC44);
            this.grpThongTin.Controls.Add(this.txtSDT);
            this.grpThongTin.Controls.Add(this.lblC45);
            this.grpThongTin.Controls.Add(this.txtCCCD);
            this.grpThongTin.Controls.Add(this.lblC46);
            this.grpThongTin.Controls.Add(this.txtDiaChi);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ucKhachHang";
            this.Size = new System.Drawing.Size(1000, 560);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).EndInit();
            this.pnlNut.ResumeLayout(false);
            this.pnlNut.PerformLayout();
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvKhachHang;
        private System.Windows.Forms.Panel pnlNut;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Label lblC41;
        private System.Windows.Forms.TextBox txtTim;
        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label lblC42;
        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.Label lblC43;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblC44;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label lblC45;
        private System.Windows.Forms.TextBox txtCCCD;
        private System.Windows.Forms.Label lblC46;
        private System.Windows.Forms.TextBox txtDiaChi;
    }
}