// File Designer sinh tự động cho ucTraCuu. Dán đè toàn bộ nội dung file ucTraCuu.Designer.cs.
namespace QuanLyBaiGiuXe.Views
{
    partial class ucTraCuu
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
            this.dgvKetQua = new System.Windows.Forms.DataGridView();
            this.pbAnh = new System.Windows.Forms.PictureBox();
            this.lblTong = new System.Windows.Forms.Label();
            this.grpLoc = new System.Windows.Forms.GroupBox();
            this.lblC54 = new System.Windows.Forms.Label();
            this.txtBienSo = new System.Windows.Forms.TextBox();
            this.lblC55 = new System.Windows.Forms.Label();
            this.txtMaThe = new System.Windows.Forms.TextBox();
            this.lblC56 = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.lblC57 = new System.Windows.Forms.Label();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.lblC58 = new System.Windows.Forms.Label();
            this.cboLoaiXe = new System.Windows.Forms.ComboBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnInBienNhan = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAnh)).BeginInit();
            this.grpLoc.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvKetQua
            // 
            this.dgvKetQua.Name = "dgvKetQua";
            this.dgvKetQua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKetQua.Size = new System.Drawing.Size(1000, 300);
            this.dgvKetQua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKetQua.TabIndex = 0;
            // 
            // pbAnh
            // 
            this.pbAnh.Name = "pbAnh";
            this.pbAnh.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbAnh.Size = new System.Drawing.Size(240, 300);
            this.pbAnh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbAnh.BackColor = System.Drawing.Color.Gainsboro;
            this.pbAnh.TabStop = false;
            this.pbAnh.TabIndex = 1;
            // 
            // lblTong
            // 
            this.lblTong.Name = "lblTong";
            this.lblTong.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTong.Size = new System.Drawing.Size(1000, 32);
            this.lblTong.Text = "";
            this.lblTong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTong.TabIndex = 2;
            // 
            // grpLoc
            // 
            this.grpLoc.Name = "grpLoc";
            this.grpLoc.Text = "Bộ lọc";
            this.grpLoc.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpLoc.Size = new System.Drawing.Size(1000, 100);
            this.grpLoc.TabIndex = 3;
            // 
            // lblC54
            // 
            this.lblC54.Name = "lblC54";
            this.lblC54.Text = "Biển số";
            this.lblC54.Location = new System.Drawing.Point(15, 28);
            this.lblC54.AutoSize = true;
            this.lblC54.TabIndex = 0;
            // 
            // txtBienSo
            // 
            this.txtBienSo.Name = "txtBienSo";
            this.txtBienSo.Location = new System.Drawing.Point(15, 50);
            this.txtBienSo.Size = new System.Drawing.Size(140, 20);
            this.txtBienSo.TabIndex = 1;
            // 
            // lblC55
            // 
            this.lblC55.Name = "lblC55";
            this.lblC55.Text = "Mã thẻ";
            this.lblC55.Location = new System.Drawing.Point(175, 28);
            this.lblC55.AutoSize = true;
            this.lblC55.TabIndex = 2;
            // 
            // txtMaThe
            // 
            this.txtMaThe.Name = "txtMaThe";
            this.txtMaThe.Location = new System.Drawing.Point(175, 50);
            this.txtMaThe.Size = new System.Drawing.Size(100, 20);
            this.txtMaThe.TabIndex = 3;
            // 
            // lblC56
            // 
            this.lblC56.Name = "lblC56";
            this.lblC56.Text = "Từ ngày";
            this.lblC56.Location = new System.Drawing.Point(295, 28);
            this.lblC56.AutoSize = true;
            this.lblC56.TabIndex = 4;
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Location = new System.Drawing.Point(295, 50);
            this.dtpTuNgay.Size = new System.Drawing.Size(120, 20);
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.TabIndex = 5;
            // 
            // lblC57
            // 
            this.lblC57.Name = "lblC57";
            this.lblC57.Text = "Đến ngày";
            this.lblC57.Location = new System.Drawing.Point(435, 28);
            this.lblC57.AutoSize = true;
            this.lblC57.TabIndex = 6;
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Location = new System.Drawing.Point(435, 50);
            this.dtpDenNgay.Size = new System.Drawing.Size(120, 20);
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.TabIndex = 7;
            // 
            // lblC58
            // 
            this.lblC58.Name = "lblC58";
            this.lblC58.Text = "Loại xe";
            this.lblC58.Location = new System.Drawing.Point(575, 28);
            this.lblC58.AutoSize = true;
            this.lblC58.TabIndex = 8;
            // 
            // cboLoaiXe
            // 
            this.cboLoaiXe.Name = "cboLoaiXe";
            this.cboLoaiXe.Location = new System.Drawing.Point(575, 50);
            this.cboLoaiXe.Size = new System.Drawing.Size(120, 21);
            this.cboLoaiXe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiXe.FormattingEnabled = true;
            this.cboLoaiXe.TabIndex = 9;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.Location = new System.Drawing.Point(715, 44);
            this.btnTimKiem.Size = new System.Drawing.Size(100, 32);
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.TabIndex = 10;
            // 
            // btnInBienNhan
            // 
            this.btnInBienNhan.Name = "btnInBienNhan";
            this.btnInBienNhan.Text = "In biên nhận";
            this.btnInBienNhan.Location = new System.Drawing.Point(825, 44);
            this.btnInBienNhan.Size = new System.Drawing.Size(120, 32);
            this.btnInBienNhan.UseVisualStyleBackColor = true;
            this.btnInBienNhan.TabIndex = 11;
            // 
            // ucTraCuu
            // 
            this.Controls.Add(this.dgvKetQua);
            this.Controls.Add(this.pbAnh);
            this.Controls.Add(this.lblTong);
            this.Controls.Add(this.grpLoc);
            this.grpLoc.Controls.Add(this.lblC54);
            this.grpLoc.Controls.Add(this.txtBienSo);
            this.grpLoc.Controls.Add(this.lblC55);
            this.grpLoc.Controls.Add(this.txtMaThe);
            this.grpLoc.Controls.Add(this.lblC56);
            this.grpLoc.Controls.Add(this.dtpTuNgay);
            this.grpLoc.Controls.Add(this.lblC57);
            this.grpLoc.Controls.Add(this.dtpDenNgay);
            this.grpLoc.Controls.Add(this.lblC58);
            this.grpLoc.Controls.Add(this.cboLoaiXe);
            this.grpLoc.Controls.Add(this.btnTimKiem);
            this.grpLoc.Controls.Add(this.btnInBienNhan);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ucTraCuu";
            this.Size = new System.Drawing.Size(1000, 560);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAnh)).EndInit();
            this.grpLoc.ResumeLayout(false);
            this.grpLoc.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvKetQua;
        private System.Windows.Forms.PictureBox pbAnh;
        private System.Windows.Forms.Label lblTong;
        private System.Windows.Forms.GroupBox grpLoc;
        private System.Windows.Forms.Label lblC54;
        private System.Windows.Forms.TextBox txtBienSo;
        private System.Windows.Forms.Label lblC55;
        private System.Windows.Forms.TextBox txtMaThe;
        private System.Windows.Forms.Label lblC56;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label lblC57;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Label lblC58;
        private System.Windows.Forms.ComboBox cboLoaiXe;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnInBienNhan;
    }
}