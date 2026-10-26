namespace QuanLyBaiGiuXe.Views
{
    partial class ucTheXe
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
            this.grbThongTintheXe = new System.Windows.Forms.GroupBox();
            this.lblMaThe = new System.Windows.Forms.Label();
            this.txtMaThe = new System.Windows.Forms.TextBox();
            this.lblLoaiThe = new System.Windows.Forms.Label();
            this.cboLoaiThe = new System.Windows.Forms.ComboBox();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.lblNgayCap = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.dgvTheXe = new System.Windows.Forms.DataGridView();
            this.grbThongTintheXe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTheXe)).BeginInit();
            this.SuspendLayout();
            // 
            // grbThongTintheXe
            // 
            this.grbThongTintheXe.Controls.Add(this.txtTimKiem);
            this.grbThongTintheXe.Controls.Add(this.btnLamMoi);
            this.grbThongTintheXe.Controls.Add(this.btnXoa);
            this.grbThongTintheXe.Controls.Add(this.btnSua);
            this.grbThongTintheXe.Controls.Add(this.btnThem);
            this.grbThongTintheXe.Controls.Add(this.dateTimePicker1);
            this.grbThongTintheXe.Controls.Add(this.lblNgayCap);
            this.grbThongTintheXe.Controls.Add(this.lblTrangThai);
            this.grbThongTintheXe.Controls.Add(this.cboTrangThai);
            this.grbThongTintheXe.Controls.Add(this.cboLoaiThe);
            this.grbThongTintheXe.Controls.Add(this.lblLoaiThe);
            this.grbThongTintheXe.Controls.Add(this.txtMaThe);
            this.grbThongTintheXe.Controls.Add(this.lblMaThe);
            this.grbThongTintheXe.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbThongTintheXe.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbThongTintheXe.Location = new System.Drawing.Point(0, 0);
            this.grbThongTintheXe.Name = "grbThongTintheXe";
            this.grbThongTintheXe.Size = new System.Drawing.Size(1000, 156);
            this.grbThongTintheXe.TabIndex = 0;
            this.grbThongTintheXe.TabStop = false;
            this.grbThongTintheXe.Text = "Thông tin thẻ xe";
            // 
            // lblMaThe
            // 
            this.lblMaThe.AutoSize = true;
            this.lblMaThe.Location = new System.Drawing.Point(21, 31);
            this.lblMaThe.Name = "lblMaThe";
            this.lblMaThe.Size = new System.Drawing.Size(58, 18);
            this.lblMaThe.TabIndex = 0;
            this.lblMaThe.Text = "Mã Thẻ";
            // 
            // txtMaThe
            // 
            this.txtMaThe.Location = new System.Drawing.Point(24, 52);
            this.txtMaThe.Name = "txtMaThe";
            this.txtMaThe.Size = new System.Drawing.Size(143, 24);
            this.txtMaThe.TabIndex = 1;
            // 
            // lblLoaiThe
            // 
            this.lblLoaiThe.AutoSize = true;
            this.lblLoaiThe.Location = new System.Drawing.Point(192, 31);
            this.lblLoaiThe.Name = "lblLoaiThe";
            this.lblLoaiThe.Size = new System.Drawing.Size(60, 18);
            this.lblLoaiThe.TabIndex = 2;
            this.lblLoaiThe.Text = "Loại thẻ";
            // 
            // cboLoaiThe
            // 
            this.cboLoaiThe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiThe.FormattingEnabled = true;
            this.cboLoaiThe.Location = new System.Drawing.Point(195, 51);
            this.cboLoaiThe.Name = "cboLoaiThe";
            this.cboLoaiThe.Size = new System.Drawing.Size(181, 26);
            this.cboLoaiThe.TabIndex = 3;
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThai.FormattingEnabled = true;
            this.cboTrangThai.Location = new System.Drawing.Point(404, 51);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(181, 26);
            this.cboTrangThai.TabIndex = 4;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Location = new System.Drawing.Point(401, 31);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(73, 18);
            this.lblTrangThai.TabIndex = 5;
            this.lblTrangThai.Text = "Trạng thái";
            // 
            // lblNgayCap
            // 
            this.lblNgayCap.AutoSize = true;
            this.lblNgayCap.Location = new System.Drawing.Point(610, 31);
            this.lblNgayCap.Name = "lblNgayCap";
            this.lblNgayCap.Size = new System.Drawing.Size(70, 18);
            this.lblNgayCap.TabIndex = 6;
            this.lblNgayCap.Text = "Ngày cấp";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(613, 52);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(182, 24);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(24, 101);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(92, 32);
            this.btnThem.TabIndex = 8;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(143, 101);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(92, 32);
            this.btnSua.TabIndex = 9;
            this.btnSua.Text = "Sửa ";
            this.btnSua.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(262, 101);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(92, 32);
            this.btnXoa.TabIndex = 10;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(381, 101);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(92, 32);
            this.btnLamMoi.TabIndex = 11;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(727, 105);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(232, 24);
            this.txtTimKiem.TabIndex = 12;
            // 
            // dgvTheXe
            // 
            this.dgvTheXe.AllowUserToAddRows = false;
            this.dgvTheXe.AllowUserToDeleteRows = false;
            this.dgvTheXe.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvTheXe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTheXe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTheXe.Location = new System.Drawing.Point(0, 156);
            this.dgvTheXe.Name = "dgvTheXe";
            this.dgvTheXe.RowHeadersVisible = false;
            this.dgvTheXe.Size = new System.Drawing.Size(1000, 404);
            this.dgvTheXe.TabIndex = 1;
            // 
            // ucTheXe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.dgvTheXe);
            this.Controls.Add(this.grbThongTintheXe);
            this.Name = "ucTheXe";
            this.Size = new System.Drawing.Size(1000, 560);
            this.grbThongTintheXe.ResumeLayout(false);
            this.grbThongTintheXe.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTheXe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbThongTintheXe;
        private System.Windows.Forms.TextBox txtMaThe;
        private System.Windows.Forms.Label lblMaThe;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lblNgayCap;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.ComboBox cboLoaiThe;
        private System.Windows.Forms.Label lblLoaiThe;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.DataGridView dgvTheXe;
    }
}
