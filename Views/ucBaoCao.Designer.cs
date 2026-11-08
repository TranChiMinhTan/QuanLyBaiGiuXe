// File Designer sinh tự động cho ucBaoCao. Dán đè toàn bộ nội dung file ucBaoCao.Designer.cs.
namespace QuanLyBaiGiuXe.Views
{
    partial class ucBaoCao
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
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.dgvBaoCao = new System.Windows.Forms.DataGridView();
            this.pnlBieuDo = new System.Windows.Forms.Panel();
            this.lblTong = new System.Windows.Forms.Label();
            this.grpLoc = new System.Windows.Forms.GroupBox();
            this.lblC59 = new System.Windows.Forms.Label();
            this.dtpTu = new System.Windows.Forms.DateTimePicker();
            this.lblC60 = new System.Windows.Forms.Label();
            this.dtpDen = new System.Windows.Forms.DateTimePicker();
            this.rdoTheoNgay = new System.Windows.Forms.RadioButton();
            this.rdoTheoThang = new System.Windows.Forms.RadioButton();
            this.btnXem = new System.Windows.Forms.Button();
            this.btnXuatCsv = new System.Windows.Forms.Button();
            this.btnGioCaoDiem = new System.Windows.Forms.Button();
            this.btnGoiYVeThang = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).BeginInit();
            this.splitMain.SuspendLayout();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.pnlBieuDo.SuspendLayout();
            this.grpLoc.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitMain
            // 
            this.splitMain.Name = "splitMain";
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Size = new System.Drawing.Size(1000, 300);
            this.splitMain.TabIndex = 0;
            this.splitMain.SplitterDistance = 420;
            // 
            // dgvBaoCao
            // 
            this.dgvBaoCao.Name = "dgvBaoCao";
            this.dgvBaoCao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBaoCao.Size = new System.Drawing.Size(420, 300);
            this.dgvBaoCao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBaoCao.TabIndex = 0;
            // 
            // pnlBieuDo
            // 
            this.pnlBieuDo.Name = "pnlBieuDo";
            this.pnlBieuDo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBieuDo.Size = new System.Drawing.Size(570, 300);
            this.pnlBieuDo.BackColor = System.Drawing.Color.White;
            this.pnlBieuDo.TabIndex = 0;
            // 
            // lblTong
            // 
            this.lblTong.Name = "lblTong";
            this.lblTong.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTong.Size = new System.Drawing.Size(1000, 34);
            this.lblTong.Text = "";
            this.lblTong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTong.TabIndex = 1;
            // 
            // grpLoc
            // 
            this.grpLoc.Name = "grpLoc";
            this.grpLoc.Text = "Bộ lọc";
            this.grpLoc.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpLoc.Size = new System.Drawing.Size(1000, 100);
            this.grpLoc.TabIndex = 2;
            // 
            // lblC59
            // 
            this.lblC59.Name = "lblC59";
            this.lblC59.Text = "Từ ngày";
            this.lblC59.Location = new System.Drawing.Point(15, 28);
            this.lblC59.AutoSize = true;
            this.lblC59.TabIndex = 0;
            // 
            // dtpTu
            // 
            this.dtpTu.Name = "dtpTu";
            this.dtpTu.Location = new System.Drawing.Point(15, 50);
            this.dtpTu.Size = new System.Drawing.Size(130, 20);
            this.dtpTu.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTu.TabIndex = 1;
            // 
            // lblC60
            // 
            this.lblC60.Name = "lblC60";
            this.lblC60.Text = "Đến ngày";
            this.lblC60.Location = new System.Drawing.Point(165, 28);
            this.lblC60.AutoSize = true;
            this.lblC60.TabIndex = 2;
            // 
            // dtpDen
            // 
            this.dtpDen.Name = "dtpDen";
            this.dtpDen.Location = new System.Drawing.Point(165, 50);
            this.dtpDen.Size = new System.Drawing.Size(130, 20);
            this.dtpDen.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDen.TabIndex = 3;
            // 
            // rdoTheoNgay
            // 
            this.rdoTheoNgay.Name = "rdoTheoNgay";
            this.rdoTheoNgay.Text = "Theo ngày";
            this.rdoTheoNgay.Location = new System.Drawing.Point(315, 52);
            this.rdoTheoNgay.AutoSize = true;
            this.rdoTheoNgay.Checked = true;
            this.rdoTheoNgay.TabStop = true;
            this.rdoTheoNgay.TabIndex = 4;
            // 
            // rdoTheoThang
            // 
            this.rdoTheoThang.Name = "rdoTheoThang";
            this.rdoTheoThang.Text = "Theo tháng";
            this.rdoTheoThang.Location = new System.Drawing.Point(405, 52);
            this.rdoTheoThang.AutoSize = true;
            this.rdoTheoThang.TabIndex = 5;
            // 
            // btnXem
            // 
            this.btnXem.Name = "btnXem";
            this.btnXem.Text = "Xem";
            this.btnXem.Location = new System.Drawing.Point(510, 44);
            this.btnXem.Size = new System.Drawing.Size(90, 32);
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.TabIndex = 6;
            // 
            // btnXuatCsv
            // 
            this.btnXuatCsv.Name = "btnXuatCsv";
            this.btnXuatCsv.Text = "Xuất CSV";
            this.btnXuatCsv.Location = new System.Drawing.Point(610, 44);
            this.btnXuatCsv.Size = new System.Drawing.Size(100, 32);
            this.btnXuatCsv.UseVisualStyleBackColor = true;
            this.btnXuatCsv.TabIndex = 7;
            // 
            // btnGioCaoDiem
            // 
            this.btnGioCaoDiem.Name = "btnGioCaoDiem";
            this.btnGioCaoDiem.Text = "Giờ cao điểm";
            this.btnGioCaoDiem.Location = new System.Drawing.Point(720, 44);
            this.btnGioCaoDiem.Size = new System.Drawing.Size(110, 32);
            this.btnGioCaoDiem.UseVisualStyleBackColor = true;
            this.btnGioCaoDiem.TabIndex = 8;
            // 
            // btnGoiYVeThang
            // 
            this.btnGoiYVeThang.Name = "btnGoiYVeThang";
            this.btnGoiYVeThang.Text = "Gợi ý vé tháng";
            this.btnGoiYVeThang.Location = new System.Drawing.Point(840, 44);
            this.btnGoiYVeThang.Size = new System.Drawing.Size(130, 32);
            this.btnGoiYVeThang.UseVisualStyleBackColor = true;
            this.btnGoiYVeThang.TabIndex = 9;
            // 
            // ucBaoCao
            // 
            this.Controls.Add(this.splitMain);
            this.splitMain.Panel1.Controls.Add(this.dgvBaoCao);
            this.splitMain.Panel2.Controls.Add(this.pnlBieuDo);
            this.Controls.Add(this.lblTong);
            this.Controls.Add(this.grpLoc);
            this.grpLoc.Controls.Add(this.lblC59);
            this.grpLoc.Controls.Add(this.dtpTu);
            this.grpLoc.Controls.Add(this.lblC60);
            this.grpLoc.Controls.Add(this.dtpDen);
            this.grpLoc.Controls.Add(this.rdoTheoNgay);
            this.grpLoc.Controls.Add(this.rdoTheoThang);
            this.grpLoc.Controls.Add(this.btnXem);
            this.grpLoc.Controls.Add(this.btnXuatCsv);
            this.grpLoc.Controls.Add(this.btnGioCaoDiem);
            this.grpLoc.Controls.Add(this.btnGoiYVeThang);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ucBaoCao";
            this.Size = new System.Drawing.Size(1000, 600);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            this.pnlBieuDo.ResumeLayout(false);
            this.pnlBieuDo.PerformLayout();
            this.grpLoc.ResumeLayout(false);
            this.grpLoc.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.DataGridView dgvBaoCao;
        private System.Windows.Forms.Panel pnlBieuDo;
        private System.Windows.Forms.Label lblTong;
        private System.Windows.Forms.GroupBox grpLoc;
        private System.Windows.Forms.Label lblC59;
        private System.Windows.Forms.DateTimePicker dtpTu;
        private System.Windows.Forms.Label lblC60;
        private System.Windows.Forms.DateTimePicker dtpDen;
        private System.Windows.Forms.RadioButton rdoTheoNgay;
        private System.Windows.Forms.RadioButton rdoTheoThang;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.Button btnXuatCsv;
        private System.Windows.Forms.Button btnGioCaoDiem;
        private System.Windows.Forms.Button btnGoiYVeThang;
    }
}