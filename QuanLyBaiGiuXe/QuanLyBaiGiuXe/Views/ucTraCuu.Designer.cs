namespace QuanLyBaiGiuXe.Views
{
    partial class ucTraCuu
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTong = new System.Windows.Forms.Label();
            this.grbLoc = new System.Windows.Forms.GroupBox();
            this.LblLoaiXe = new System.Windows.Forms.Label();
            this.lblNgayKetThuc = new System.Windows.Forms.Label();
            this.lblNgayBatDau = new System.Windows.Forms.Label();
            this.lblMaThe = new System.Windows.Forms.Label();
            this.txtMaThe = new System.Windows.Forms.TextBox();
            this.txtBienSo = new System.Windows.Forms.TextBox();
            this.lblBienSo = new System.Windows.Forms.Label();
            this.cboLoaiXe = new System.Windows.Forms.ComboBox();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnInBienNhan = new System.Windows.Forms.Button();
            this.dgvKetQua = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.grbLoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTong);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 520);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 40);
            this.panel1.TabIndex = 0;
            // 
            // lblTong
            // 
            this.lblTong.AutoSize = true;
            this.lblTong.Location = new System.Drawing.Point(18, 12);
            this.lblTong.Name = "lblTong";
            this.lblTong.Size = new System.Drawing.Size(245, 18);
            this.lblTong.TabIndex = 0;
            this.lblTong.Text = "Tìm thấy 4 lượt · Tổng phí: 229.000 đ";
            // 
            // grbLoc
            // 
            this.grbLoc.Controls.Add(this.btnInBienNhan);
            this.grbLoc.Controls.Add(this.btnTimKiem);
            this.grbLoc.Controls.Add(this.dtpDenNgay);
            this.grbLoc.Controls.Add(this.dtpTuNgay);
            this.grbLoc.Controls.Add(this.cboLoaiXe);
            this.grbLoc.Controls.Add(this.LblLoaiXe);
            this.grbLoc.Controls.Add(this.lblNgayKetThuc);
            this.grbLoc.Controls.Add(this.lblNgayBatDau);
            this.grbLoc.Controls.Add(this.lblMaThe);
            this.grbLoc.Controls.Add(this.txtMaThe);
            this.grbLoc.Controls.Add(this.txtBienSo);
            this.grbLoc.Controls.Add(this.lblBienSo);
            this.grbLoc.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbLoc.Location = new System.Drawing.Point(0, 0);
            this.grbLoc.Name = "grbLoc";
            this.grbLoc.Size = new System.Drawing.Size(1000, 144);
            this.grbLoc.TabIndex = 1;
            this.grbLoc.TabStop = false;
            this.grbLoc.Text = "Bộ lọc";
            // 
            // LblLoaiXe
            // 
            this.LblLoaiXe.AutoSize = true;
            this.LblLoaiXe.Location = new System.Drawing.Point(661, 31);
            this.LblLoaiXe.Name = "LblLoaiXe";
            this.LblLoaiXe.Size = new System.Drawing.Size(55, 18);
            this.LblLoaiXe.TabIndex = 6;
            this.LblLoaiXe.Text = "Loại xe";
            // 
            // lblNgayKetThuc
            // 
            this.lblNgayKetThuc.AutoSize = true;
            this.lblNgayKetThuc.Location = new System.Drawing.Point(511, 31);
            this.lblNgayKetThuc.Name = "lblNgayKetThuc";
            this.lblNgayKetThuc.Size = new System.Drawing.Size(70, 18);
            this.lblNgayKetThuc.TabIndex = 5;
            this.lblNgayKetThuc.Text = "Đến ngày";
            // 
            // lblNgayBatDau
            // 
            this.lblNgayBatDau.AutoSize = true;
            this.lblNgayBatDau.Location = new System.Drawing.Point(361, 31);
            this.lblNgayBatDau.Name = "lblNgayBatDau";
            this.lblNgayBatDau.Size = new System.Drawing.Size(60, 18);
            this.lblNgayBatDau.TabIndex = 4;
            this.lblNgayBatDau.Text = "Từ ngày";
            // 
            // lblMaThe
            // 
            this.lblMaThe.AutoSize = true;
            this.lblMaThe.Location = new System.Drawing.Point(198, 31);
            this.lblMaThe.Name = "lblMaThe";
            this.lblMaThe.Size = new System.Drawing.Size(53, 18);
            this.lblMaThe.TabIndex = 3;
            this.lblMaThe.Text = "Mã thẻ";
            // 
            // txtMaThe
            // 
            this.txtMaThe.Location = new System.Drawing.Point(201, 52);
            this.txtMaThe.Name = "txtMaThe";
            this.txtMaThe.Size = new System.Drawing.Size(136, 24);
            this.txtMaThe.TabIndex = 2;
            // 
            // txtBienSo
            // 
            this.txtBienSo.Location = new System.Drawing.Point(21, 52);
            this.txtBienSo.Name = "txtBienSo";
            this.txtBienSo.Size = new System.Drawing.Size(153, 24);
            this.txtBienSo.TabIndex = 1;
            // 
            // lblBienSo
            // 
            this.lblBienSo.AutoSize = true;
            this.lblBienSo.Location = new System.Drawing.Point(18, 31);
            this.lblBienSo.Name = "lblBienSo";
            this.lblBienSo.Size = new System.Drawing.Size(58, 18);
            this.lblBienSo.TabIndex = 0;
            this.lblBienSo.Text = "Biển số";
            // 
            // cboLoaiXe
            // 
            this.cboLoaiXe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiXe.FormattingEnabled = true;
            this.cboLoaiXe.Location = new System.Drawing.Point(664, 48);
            this.cboLoaiXe.Name = "cboLoaiXe";
            this.cboLoaiXe.Size = new System.Drawing.Size(121, 26);
            this.cboLoaiXe.TabIndex = 7;
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(364, 50);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(123, 24);
            this.dtpTuNgay.TabIndex = 8;
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new System.Drawing.Point(514, 50);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(123, 24);
            this.dtpDenNgay.TabIndex = 9;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(23, 94);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(91, 33);
            this.btnTimKiem.TabIndex = 10;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // btnInBienNhan
            // 
            this.btnInBienNhan.Location = new System.Drawing.Point(142, 94);
            this.btnInBienNhan.Name = "btnInBienNhan";
            this.btnInBienNhan.Size = new System.Drawing.Size(109, 33);
            this.btnInBienNhan.TabIndex = 11;
            this.btnInBienNhan.Text = "In biên nhận";
            this.btnInBienNhan.UseVisualStyleBackColor = true;
            // 
            // dgvKetQua
            // 
            this.dgvKetQua.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvKetQua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKetQua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKetQua.Location = new System.Drawing.Point(0, 144);
            this.dgvKetQua.Name = "dgvKetQua";
            this.dgvKetQua.Size = new System.Drawing.Size(1000, 376);
            this.dgvKetQua.TabIndex = 2;
            // 
            // ucTraCuu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvKetQua);
            this.Controls.Add(this.grbLoc);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucTraCuu";
            this.Size = new System.Drawing.Size(1000, 560);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grbLoc.ResumeLayout(false);
            this.grbLoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTong;
        private System.Windows.Forms.GroupBox grbLoc;
        private System.Windows.Forms.Label LblLoaiXe;
        private System.Windows.Forms.Label lblNgayKetThuc;
        private System.Windows.Forms.Label lblNgayBatDau;
        private System.Windows.Forms.Label lblMaThe;
        private System.Windows.Forms.TextBox txtMaThe;
        private System.Windows.Forms.TextBox txtBienSo;
        private System.Windows.Forms.Label lblBienSo;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.ComboBox cboLoaiXe;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Button btnInBienNhan;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridView dgvKetQua;
    }
}
