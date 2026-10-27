namespace QuanLyBaiGiuXe.Views
{
    partial class FrmMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblNguoiDung = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNgayGio = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblXeTrongBai = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabVanHanh = new System.Windows.Forms.TabPage();
            this.tabTraCuu = new System.Windows.Forms.TabPage();
            this.tabVeThang = new System.Windows.Forms.TabPage();
            this.tabKhachHang = new System.Windows.Forms.TabPage();
            this.tabBaoCao = new System.Windows.Forms.TabPage();
            this.tabBangGia = new System.Windows.Forms.TabPage();
            this.tabTheXe = new System.Windows.Forms.TabPage();
            this.timerDongHo = new System.Windows.Forms.Timer(this.components);
            this.tabLoaiXe = new System.Windows.Forms.TabPage();
            this.statusStrip.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblNguoiDung,
            this.lblNgayGio,
            this.lblXeTrongBai});
            this.statusStrip.Location = new System.Drawing.Point(0, 677);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1332, 26);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip";
            // 
            // lblNguoiDung
            // 
            this.lblNguoiDung.Name = "lblNguoiDung";
            this.lblNguoiDung.Size = new System.Drawing.Size(103, 20);
            this.lblNguoiDung.Text = "lblNguoiDung";
            // 
            // lblNgayGio
            // 
            this.lblNgayGio.Name = "lblNgayGio";
            this.lblNgayGio.Size = new System.Drawing.Size(84, 20);
            this.lblNgayGio.Text = "lblNgayGio";
            // 
            // lblXeTrongBai
            // 
            this.lblXeTrongBai.Name = "lblXeTrongBai";
            this.lblXeTrongBai.Size = new System.Drawing.Size(102, 20);
            this.lblXeTrongBai.Text = "lblXeTrongBai";
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabVanHanh);
            this.tabMain.Controls.Add(this.tabTraCuu);
            this.tabMain.Controls.Add(this.tabVeThang);
            this.tabMain.Controls.Add(this.tabKhachHang);
            this.tabMain.Controls.Add(this.tabBaoCao);
            this.tabMain.Controls.Add(this.tabBangGia);
            this.tabMain.Controls.Add(this.tabTheXe);
            this.tabMain.Controls.Add(this.tabLoaiXe);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1332, 677);
            this.tabMain.TabIndex = 1;
            // 
            // tabVanHanh
            // 
            this.tabVanHanh.Location = new System.Drawing.Point(4, 33);
            this.tabVanHanh.Name = "tabVanHanh";
            this.tabVanHanh.Padding = new System.Windows.Forms.Padding(3);
            this.tabVanHanh.Size = new System.Drawing.Size(976, 548);
            this.tabVanHanh.TabIndex = 0;
            this.tabVanHanh.Text = "Vận hành";
            this.tabVanHanh.UseVisualStyleBackColor = true;
            // 
            // tabTraCuu
            // 
            this.tabTraCuu.Location = new System.Drawing.Point(4, 33);
            this.tabTraCuu.Name = "tabTraCuu";
            this.tabTraCuu.Padding = new System.Windows.Forms.Padding(3);
            this.tabTraCuu.Size = new System.Drawing.Size(976, 552);
            this.tabTraCuu.TabIndex = 1;
            this.tabTraCuu.Text = "Tra cứu";
            this.tabTraCuu.UseVisualStyleBackColor = true;
            // 
            // tabVeThang
            // 
            this.tabVeThang.Location = new System.Drawing.Point(4, 33);
            this.tabVeThang.Name = "tabVeThang";
            this.tabVeThang.Padding = new System.Windows.Forms.Padding(3);
            this.tabVeThang.Size = new System.Drawing.Size(976, 548);
            this.tabVeThang.TabIndex = 2;
            this.tabVeThang.Text = "Vé tháng";
            this.tabVeThang.UseVisualStyleBackColor = true;
            // 
            // tabKhachHang
            // 
            this.tabKhachHang.Location = new System.Drawing.Point(4, 33);
            this.tabKhachHang.Name = "tabKhachHang";
            this.tabKhachHang.Padding = new System.Windows.Forms.Padding(3);
            this.tabKhachHang.Size = new System.Drawing.Size(976, 552);
            this.tabKhachHang.TabIndex = 3;
            this.tabKhachHang.Text = "Khách hàng";
            this.tabKhachHang.UseVisualStyleBackColor = true;
            // 
            // tabBaoCao
            // 
            this.tabBaoCao.Location = new System.Drawing.Point(4, 33);
            this.tabBaoCao.Name = "tabBaoCao";
            this.tabBaoCao.Padding = new System.Windows.Forms.Padding(3);
            this.tabBaoCao.Size = new System.Drawing.Size(976, 548);
            this.tabBaoCao.TabIndex = 4;
            this.tabBaoCao.Text = "Báo cáo";
            this.tabBaoCao.UseVisualStyleBackColor = true;
            // 
            // tabBangGia
            // 
            this.tabBangGia.Location = new System.Drawing.Point(4, 33);
            this.tabBangGia.Name = "tabBangGia";
            this.tabBangGia.Padding = new System.Windows.Forms.Padding(3);
            this.tabBangGia.Size = new System.Drawing.Size(976, 548);
            this.tabBangGia.TabIndex = 5;
            this.tabBangGia.Text = "Bảng giá";
            this.tabBangGia.UseVisualStyleBackColor = true;
            // 
            // tabTheXe
            // 
            this.tabTheXe.Location = new System.Drawing.Point(4, 33);
            this.tabTheXe.Name = "tabTheXe";
            this.tabTheXe.Padding = new System.Windows.Forms.Padding(3);
            this.tabTheXe.Size = new System.Drawing.Size(976, 548);
            this.tabTheXe.TabIndex = 6;
            this.tabTheXe.Text = "Thẻ xe";
            this.tabTheXe.UseVisualStyleBackColor = true;
            // 
            // timerDongHo
            // 
            this.timerDongHo.Enabled = true;
            this.timerDongHo.Interval = 1000;
            // 
            // tabLoaiXe
            // 
            this.tabLoaiXe.Location = new System.Drawing.Point(4, 33);
            this.tabLoaiXe.Name = "tabLoaiXe";
            this.tabLoaiXe.Padding = new System.Windows.Forms.Padding(3);
            this.tabLoaiXe.Size = new System.Drawing.Size(1324, 640);
            this.tabLoaiXe.TabIndex = 7;
            this.tabLoaiXe.Text = "Loại xe";
            this.tabLoaiXe.UseVisualStyleBackColor = true;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1332, 703);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.statusStrip);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblNguoiDung;
        private System.Windows.Forms.ToolStripStatusLabel lblNgayGio;
        private System.Windows.Forms.ToolStripStatusLabel lblXeTrongBai;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabVanHanh;
        private System.Windows.Forms.TabPage tabTraCuu;
        private System.Windows.Forms.TabPage tabVeThang;
        private System.Windows.Forms.TabPage tabKhachHang;
        private System.Windows.Forms.TabPage tabBaoCao;
        private System.Windows.Forms.TabPage tabBangGia;
        private System.Windows.Forms.TabPage tabTheXe;
        private System.Windows.Forms.Timer timerDongHo;
        private System.Windows.Forms.TabPage tabLoaiXe;
    }
}