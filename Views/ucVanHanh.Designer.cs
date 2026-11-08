namespace QuanLyBaiGiuXe.Views
{
    partial class ucVanHanh
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
            this.ofdAnh = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grbThanhToan = new System.Windows.Forms.GroupBox();
            this.lblPhi = new System.Windows.Forms.Label();
            this.lblThoiGian = new System.Windows.Forms.Label();
            this.grbCanhBao = new System.Windows.Forms.GroupBox();
            this.lblCanhBao = new System.Windows.Forms.Label();
            this.grbGhiNhan = new System.Windows.Forms.GroupBox();
            this.btnInVe = new System.Windows.Forms.Button();
            this.btnXeRa = new System.Windows.Forms.Button();
            this.btnXeVao = new System.Windows.Forms.Button();
            this.btnChonAnh = new System.Windows.Forms.Button();
            this.pbBienSo = new System.Windows.Forms.PictureBox();
            this.cboLoaiXe = new System.Windows.Forms.ComboBox();
            this.lblLoaiXe = new System.Windows.Forms.Label();
            this.txtMaThe = new System.Windows.Forms.TextBox();
            this.txtBienSo = new System.Windows.Forms.TextBox();
            this.aThe = new System.Windows.Forms.Label();
            this.lblBienSo = new System.Windows.Forms.Label();
            this.grbLuocGui = new System.Windows.Forms.GroupBox();
            this.dgvLuotGui = new System.Windows.Forms.DataGridView();
            this.grbSoDo = new System.Windows.Forms.GroupBox();
            this.lblConTrong = new System.Windows.Forms.Label();
            this.pnlSoDo = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grbThanhToan.SuspendLayout();
            this.grbCanhBao.SuspendLayout();
            this.grbGhiNhan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBienSo)).BeginInit();
            this.grbLuocGui.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLuotGui)).BeginInit();
            this.grbSoDo.SuspendLayout();
            this.SuspendLayout();
            // 
            // ofdAnh
            // 
            this.ofdAnh.FileName = "ofdAnh";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grbThanhToan);
            this.splitContainer1.Panel1.Controls.Add(this.grbCanhBao);
            this.splitContainer1.Panel1.Controls.Add(this.grbGhiNhan);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grbLuocGui);
            this.splitContainer1.Panel2.Controls.Add(this.grbSoDo);
            this.splitContainer1.Size = new System.Drawing.Size(1300, 700);
            this.splitContainer1.SplitterDistance = 391;
            this.splitContainer1.TabIndex = 2;
            // 
            // grbThanhToan
            // 
            this.grbThanhToan.Controls.Add(this.lblPhi);
            this.grbThanhToan.Controls.Add(this.lblThoiGian);
            this.grbThanhToan.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbThanhToan.Location = new System.Drawing.Point(0, 568);
            this.grbThanhToan.Name = "grbThanhToan";
            this.grbThanhToan.Size = new System.Drawing.Size(391, 122);
            this.grbThanhToan.TabIndex = 4;
            this.grbThanhToan.TabStop = false;
            this.grbThanhToan.Text = "Thanh toán xe ra";
            // 
            // lblPhi
            // 
            this.lblPhi.AutoSize = true;
            this.lblPhi.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhi.Location = new System.Drawing.Point(97, 68);
            this.lblPhi.Name = "lblPhi";
            this.lblPhi.Size = new System.Drawing.Size(140, 26);
            this.lblPhi.TabIndex = 1;
            this.lblPhi.Text = "Phí: 6.000 đ";
            // 
            // lblThoiGian
            // 
            this.lblThoiGian.AutoSize = true;
            this.lblThoiGian.Location = new System.Drawing.Point(44, 34);
            this.lblThoiGian.Name = "lblThoiGian";
            this.lblThoiGian.Size = new System.Drawing.Size(243, 18);
            this.lblThoiGian.TabIndex = 0;
            this.lblThoiGian.Text = "Vào 08:12 · Ra 12:40 (4 giờ 28 phút)";
            // 
            // grbCanhBao
            // 
            this.grbCanhBao.Controls.Add(this.lblCanhBao);
            this.grbCanhBao.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbCanhBao.Location = new System.Drawing.Point(0, 474);
            this.grbCanhBao.Name = "grbCanhBao";
            this.grbCanhBao.Size = new System.Drawing.Size(391, 94);
            this.grbCanhBao.TabIndex = 2;
            this.grbCanhBao.TabStop = false;
            this.grbCanhBao.Text = "Cảnh báo";
            // 
            // lblCanhBao
            // 
            this.lblCanhBao.AutoSize = true;
            this.lblCanhBao.BackColor = System.Drawing.Color.LemonChiffon;
            this.lblCanhBao.Location = new System.Drawing.Point(140, 42);
            this.lblCanhBao.Name = "lblCanhBao";
            this.lblCanhBao.Size = new System.Drawing.Size(72, 18);
            this.lblCanhBao.TabIndex = 0;
            this.lblCanhBao.Text = "Cảnh báo";
            // 
            // grbGhiNhan
            // 
            this.grbGhiNhan.Controls.Add(this.btnInVe);
            this.grbGhiNhan.Controls.Add(this.btnXeRa);
            this.grbGhiNhan.Controls.Add(this.btnXeVao);
            this.grbGhiNhan.Controls.Add(this.btnChonAnh);
            this.grbGhiNhan.Controls.Add(this.pbBienSo);
            this.grbGhiNhan.Controls.Add(this.cboLoaiXe);
            this.grbGhiNhan.Controls.Add(this.lblLoaiXe);
            this.grbGhiNhan.Controls.Add(this.txtMaThe);
            this.grbGhiNhan.Controls.Add(this.txtBienSo);
            this.grbGhiNhan.Controls.Add(this.aThe);
            this.grbGhiNhan.Controls.Add(this.lblBienSo);
            this.grbGhiNhan.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbGhiNhan.Location = new System.Drawing.Point(0, 0);
            this.grbGhiNhan.Name = "grbGhiNhan";
            this.grbGhiNhan.Size = new System.Drawing.Size(391, 474);
            this.grbGhiNhan.TabIndex = 3;
            this.grbGhiNhan.TabStop = false;
            this.grbGhiNhan.Text = "Ghi nhận xe";
            // 
            // btnInVe
            // 
            this.btnInVe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnInVe.Location = new System.Drawing.Point(25, 403);
            this.btnInVe.Name = "btnInVe";
            this.btnInVe.Size = new System.Drawing.Size(337, 37);
            this.btnInVe.TabIndex = 10;
            this.btnInVe.Text = "In vé / biên nhận";
            this.btnInVe.UseVisualStyleBackColor = false;
            // 
            // btnXeRa
            // 
            this.btnXeRa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnXeRa.Location = new System.Drawing.Point(203, 360);
            this.btnXeRa.Name = "btnXeRa";
            this.btnXeRa.Size = new System.Drawing.Size(159, 37);
            this.btnXeRa.TabIndex = 9;
            this.btnXeRa.Text = "Xe ra";
            this.btnXeRa.UseVisualStyleBackColor = false;
            // 
            // btnXeVao
            // 
            this.btnXeVao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnXeVao.Location = new System.Drawing.Point(25, 360);
            this.btnXeVao.Name = "btnXeVao";
            this.btnXeVao.Size = new System.Drawing.Size(159, 37);
            this.btnXeVao.TabIndex = 8;
            this.btnXeVao.Text = "Xe vào";
            this.btnXeVao.UseVisualStyleBackColor = false;
            // 
            // btnChonAnh
            // 
            this.btnChonAnh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnChonAnh.Location = new System.Drawing.Point(234, 284);
            this.btnChonAnh.Name = "btnChonAnh";
            this.btnChonAnh.Size = new System.Drawing.Size(128, 37);
            this.btnChonAnh.TabIndex = 7;
            this.btnChonAnh.Text = "Chọn ảnh";
            this.btnChonAnh.UseVisualStyleBackColor = false;
            // 
            // pbBienSo
            // 
            this.pbBienSo.Location = new System.Drawing.Point(25, 242);
            this.pbBienSo.Name = "pbBienSo";
            this.pbBienSo.Size = new System.Drawing.Size(203, 112);
            this.pbBienSo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbBienSo.TabIndex = 6;
            this.pbBienSo.TabStop = false;
            // 
            // cboLoaiXe
            // 
            this.cboLoaiXe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiXe.FormattingEnabled = true;
            this.cboLoaiXe.Location = new System.Drawing.Point(25, 194);
            this.cboLoaiXe.Name = "cboLoaiXe";
            this.cboLoaiXe.Size = new System.Drawing.Size(337, 25);
            this.cboLoaiXe.TabIndex = 5;
            // 
            // lblLoaiXe
            // 
            this.lblLoaiXe.AutoSize = true;
            this.lblLoaiXe.Location = new System.Drawing.Point(23, 169);
            this.lblLoaiXe.Name = "lblLoaiXe";
            this.lblLoaiXe.Size = new System.Drawing.Size(55, 18);
            this.lblLoaiXe.TabIndex = 4;
            this.lblLoaiXe.Text = "Loại xe";
            // 
            // txtMaThe
            // 
            this.txtMaThe.Location = new System.Drawing.Point(25, 128);
            this.txtMaThe.Name = "txtMaThe";
            this.txtMaThe.Size = new System.Drawing.Size(337, 24);
            this.txtMaThe.TabIndex = 3;
            // 
            // txtBienSo
            // 
            this.txtBienSo.Location = new System.Drawing.Point(25, 62);
            this.txtBienSo.Name = "txtBienSo";
            this.txtBienSo.Size = new System.Drawing.Size(337, 24);
            this.txtBienSo.TabIndex = 2;
            // 
            // aThe
            // 
            this.aThe.AutoSize = true;
            this.aThe.Location = new System.Drawing.Point(23, 103);
            this.aThe.Name = "aThe";
            this.aThe.Size = new System.Drawing.Size(53, 18);
            this.aThe.TabIndex = 1;
            this.aThe.Text = "Mã thẻ";
            // 
            // lblBienSo
            // 
            this.lblBienSo.AutoSize = true;
            this.lblBienSo.Location = new System.Drawing.Point(23, 37);
            this.lblBienSo.Name = "lblBienSo";
            this.lblBienSo.Size = new System.Drawing.Size(58, 18);
            this.lblBienSo.TabIndex = 0;
            this.lblBienSo.Text = "Biển số";
            // 
            // grbLuocGui
            // 
            this.grbLuocGui.Controls.Add(this.dgvLuotGui);
            this.grbLuocGui.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbLuocGui.Location = new System.Drawing.Point(0, 335);
            this.grbLuocGui.Name = "grbLuocGui";
            this.grbLuocGui.Size = new System.Drawing.Size(905, 365);
            this.grbLuocGui.TabIndex = 3;
            this.grbLuocGui.TabStop = false;
            this.grbLuocGui.Text = "Lược gửi hôm nay";
            // 
            // dgvLuotGui
            // 
            this.dgvLuotGui.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvLuotGui.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLuotGui.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLuotGui.Location = new System.Drawing.Point(3, 20);
            this.dgvLuotGui.Name = "dgvLuotGui";
            this.dgvLuotGui.RowHeadersWidth = 51;
            this.dgvLuotGui.RowTemplate.Height = 24;
            this.dgvLuotGui.Size = new System.Drawing.Size(899, 342);
            this.dgvLuotGui.TabIndex = 0;
            // 
            // grbSoDo
            // 
            this.grbSoDo.Controls.Add(this.pnlSoDo);
            this.grbSoDo.Controls.Add(this.lblConTrong);
            this.grbSoDo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbSoDo.Location = new System.Drawing.Point(0, 0);
            this.grbSoDo.Name = "grbSoDo";
            this.grbSoDo.Size = new System.Drawing.Size(905, 335);
            this.grbSoDo.TabIndex = 2;
            this.grbSoDo.TabStop = false;
            this.grbSoDo.Text = "Sơ đồ bãi xe";
            // 
            // lblConTrong
            // 
            this.lblConTrong.AutoSize = true;
            this.lblConTrong.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblConTrong.Location = new System.Drawing.Point(3, 20);
            this.lblConTrong.Name = "lblConTrong";
            this.lblConTrong.Size = new System.Drawing.Size(118, 18);
            this.lblConTrong.TabIndex = 0;
            this.lblConTrong.Text = "Còn trống: 17/30";
            // 
            // pnlSoDo
            // 
            this.pnlSoDo.AutoScroll = true;
            this.pnlSoDo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSoDo.Location = new System.Drawing.Point(3, 38);
            this.pnlSoDo.Name = "pnlSoDo";
            this.pnlSoDo.Padding = new System.Windows.Forms.Padding(8);
            this.pnlSoDo.Size = new System.Drawing.Size(899, 294);
            this.pnlSoDo.TabIndex = 0;
            // 
            // ucVanHanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "ucVanHanh";
            this.Size = new System.Drawing.Size(1300, 700);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grbThanhToan.ResumeLayout(false);
            this.grbThanhToan.PerformLayout();
            this.grbCanhBao.ResumeLayout(false);
            this.grbCanhBao.PerformLayout();
            this.grbGhiNhan.ResumeLayout(false);
            this.grbGhiNhan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBienSo)).EndInit();
            this.grbLuocGui.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLuotGui)).EndInit();
            this.grbSoDo.ResumeLayout(false);
            this.grbSoDo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog ofdAnh;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grbThanhToan;
        private System.Windows.Forms.Label lblPhi;
        private System.Windows.Forms.Label lblThoiGian;
        private System.Windows.Forms.GroupBox grbCanhBao;
        private System.Windows.Forms.Label lblCanhBao;
        private System.Windows.Forms.GroupBox grbGhiNhan;
        private System.Windows.Forms.Button btnInVe;
        private System.Windows.Forms.Button btnXeRa;
        private System.Windows.Forms.Button btnXeVao;
        private System.Windows.Forms.Button btnChonAnh;
        private System.Windows.Forms.PictureBox pbBienSo;
        private System.Windows.Forms.ComboBox cboLoaiXe;
        private System.Windows.Forms.Label lblLoaiXe;
        private System.Windows.Forms.TextBox txtMaThe;
        private System.Windows.Forms.TextBox txtBienSo;
        private System.Windows.Forms.Label aThe;
        private System.Windows.Forms.Label lblBienSo;
        private System.Windows.Forms.GroupBox grbLuocGui;
        private System.Windows.Forms.DataGridView dgvLuotGui;
        private System.Windows.Forms.GroupBox grbSoDo;
        private System.Windows.Forms.Label lblConTrong;
        private System.Windows.Forms.FlowLayoutPanel pnlSoDo;
    }
}
