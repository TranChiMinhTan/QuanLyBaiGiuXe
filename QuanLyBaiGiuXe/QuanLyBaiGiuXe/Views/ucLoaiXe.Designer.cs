namespace QuanLyBaiGiuXe.Views
{
    partial class ucLoaiXe
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
            this.grbLoaiXe = new System.Windows.Forms.GroupBox();
            this.lblMaLoai = new System.Windows.Forms.Label();
            this.txtMaLoai = new System.Windows.Forms.TextBox();
            this.txtTenLoai = new System.Windows.Forms.TextBox();
            this.lblTenLoai = new System.Windows.Forms.Label();
            this.lblSucChua = new System.Windows.Forms.Label();
            this.numSucChua = new System.Windows.Forms.NumericUpDown();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.pnlGhiChu = new System.Windows.Forms.Panel();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.dgvLoaiXe = new System.Windows.Forms.DataGridView();
            this.grbLoaiXe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSucChua)).BeginInit();
            this.pnlGhiChu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiXe)).BeginInit();
            this.SuspendLayout();
            // 
            // grbLoaiXe
            // 
            this.grbLoaiXe.Controls.Add(this.btnLamMoi);
            this.grbLoaiXe.Controls.Add(this.btnXoa);
            this.grbLoaiXe.Controls.Add(this.btnSua);
            this.grbLoaiXe.Controls.Add(this.btnThem);
            this.grbLoaiXe.Controls.Add(this.txtTimKiem);
            this.grbLoaiXe.Controls.Add(this.txtMoTa);
            this.grbLoaiXe.Controls.Add(this.lblMoTa);
            this.grbLoaiXe.Controls.Add(this.numSucChua);
            this.grbLoaiXe.Controls.Add(this.lblSucChua);
            this.grbLoaiXe.Controls.Add(this.lblTenLoai);
            this.grbLoaiXe.Controls.Add(this.txtTenLoai);
            this.grbLoaiXe.Controls.Add(this.txtMaLoai);
            this.grbLoaiXe.Controls.Add(this.lblMaLoai);
            this.grbLoaiXe.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbLoaiXe.Location = new System.Drawing.Point(0, 0);
            this.grbLoaiXe.Name = "grbLoaiXe";
            this.grbLoaiXe.Size = new System.Drawing.Size(1300, 165);
            this.grbLoaiXe.TabIndex = 0;
            this.grbLoaiXe.TabStop = false;
            this.grbLoaiXe.Text = "Thông tin loại xe";
            // 
            // lblMaLoai
            // 
            this.lblMaLoai.AutoSize = true;
            this.lblMaLoai.Location = new System.Drawing.Point(18, 35);
            this.lblMaLoai.Name = "lblMaLoai";
            this.lblMaLoai.Size = new System.Drawing.Size(67, 22);
            this.lblMaLoai.TabIndex = 0;
            this.lblMaLoai.Text = "Mã loại";
            // 
            // txtMaLoai
            // 
            this.txtMaLoai.Location = new System.Drawing.Point(22, 60);
            this.txtMaLoai.Name = "txtMaLoai";
            this.txtMaLoai.Size = new System.Drawing.Size(173, 28);
            this.txtMaLoai.TabIndex = 1;
            // 
            // txtTenLoai
            // 
            this.txtTenLoai.Location = new System.Drawing.Point(238, 60);
            this.txtTenLoai.Name = "txtTenLoai";
            this.txtTenLoai.Size = new System.Drawing.Size(183, 28);
            this.txtTenLoai.TabIndex = 2;
            // 
            // lblTenLoai
            // 
            this.lblTenLoai.AutoSize = true;
            this.lblTenLoai.Location = new System.Drawing.Point(234, 35);
            this.lblTenLoai.Name = "lblTenLoai";
            this.lblTenLoai.Size = new System.Drawing.Size(80, 22);
            this.lblTenLoai.TabIndex = 3;
            this.lblTenLoai.Text = "Tên loại ";
            // 
            // lblSucChua
            // 
            this.lblSucChua.AutoSize = true;
            this.lblSucChua.Location = new System.Drawing.Point(460, 35);
            this.lblSucChua.Name = "lblSucChua";
            this.lblSucChua.Size = new System.Drawing.Size(85, 22);
            this.lblSucChua.TabIndex = 4;
            this.lblSucChua.Text = "Sức chứa";
            // 
            // numSucChua
            // 
            this.numSucChua.Location = new System.Drawing.Point(464, 60);
            this.numSucChua.Name = "numSucChua";
            this.numSucChua.Size = new System.Drawing.Size(104, 28);
            this.numSucChua.TabIndex = 5;
            // 
            // lblMoTa
            // 
            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Location = new System.Drawing.Point(617, 35);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(54, 22);
            this.lblMoTa.TabIndex = 6;
            this.lblMoTa.Text = "Mô tả";
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(611, 60);
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(271, 28);
            this.txtMoTa.TabIndex = 7;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(970, 60);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(293, 28);
            this.txtTimKiem.TabIndex = 8;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(22, 109);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(92, 35);
            this.btnThem.TabIndex = 9;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(151, 109);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(92, 35);
            this.btnSua.TabIndex = 10;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(280, 109);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(92, 35);
            this.btnXoa.TabIndex = 11;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(409, 109);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(92, 35);
            this.btnLamMoi.TabIndex = 12;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // pnlGhiChu
            // 
            this.pnlGhiChu.Controls.Add(this.lblGhiChu);
            this.pnlGhiChu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlGhiChu.Location = new System.Drawing.Point(0, 651);
            this.pnlGhiChu.Name = "pnlGhiChu";
            this.pnlGhiChu.Size = new System.Drawing.Size(1300, 49);
            this.pnlGhiChu.TabIndex = 1;
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Location = new System.Drawing.Point(22, 15);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(790, 22);
            this.lblGhiChu.TabIndex = 0;
            this.lblGhiChu.Text = "Tổng sức chứa 30 chỗ · đang gửi 13 · còn trống 17. Không cho xóa loại xe đã có th" +
    "ẻ hoặc lượt gửi.";
            // 
            // dgvLoaiXe
            // 
            this.dgvLoaiXe.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvLoaiXe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoaiXe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLoaiXe.Location = new System.Drawing.Point(0, 165);
            this.dgvLoaiXe.Name = "dgvLoaiXe";
            this.dgvLoaiXe.RowHeadersWidth = 51;
            this.dgvLoaiXe.RowTemplate.Height = 24;
            this.dgvLoaiXe.Size = new System.Drawing.Size(1300, 486);
            this.dgvLoaiXe.TabIndex = 2;
            // 
            // ucLoaiXe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvLoaiXe);
            this.Controls.Add(this.pnlGhiChu);
            this.Controls.Add(this.grbLoaiXe);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ucLoaiXe";
            this.Size = new System.Drawing.Size(1300, 700);
            this.grbLoaiXe.ResumeLayout(false);
            this.grbLoaiXe.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSucChua)).EndInit();
            this.pnlGhiChu.ResumeLayout(false);
            this.pnlGhiChu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiXe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbLoaiXe;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.NumericUpDown numSucChua;
        private System.Windows.Forms.Label lblSucChua;
        private System.Windows.Forms.Label lblTenLoai;
        private System.Windows.Forms.TextBox txtTenLoai;
        private System.Windows.Forms.TextBox txtMaLoai;
        private System.Windows.Forms.Label lblMaLoai;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Panel pnlGhiChu;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.DataGridView dgvLoaiXe;
    }
}
