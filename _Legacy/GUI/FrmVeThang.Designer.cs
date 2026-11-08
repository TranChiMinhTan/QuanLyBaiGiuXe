namespace GUI
{
    partial class FrmVeThang
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblMaVe;
        private Label lblMaKH;
        private Label lblSoThe;

        private TextBox txtMaVe;
        private TextBox txtMaKH;
        private TextBox txtSoThe;

        private Button btnDangKy;
        private Button btnGiaHan;
        private Button btnHuyVe;
        private Button btnKiemTra;

        private DataGridView dgvVeThang;

        private void InitializeComponent()
        {
            lblMaVe = new Label();
            lblMaKH = new Label();
            lblSoThe = new Label();

            txtMaVe = new TextBox();
            txtMaKH = new TextBox();
            txtSoThe = new TextBox();

            btnDangKy = new Button();
            btnGiaHan = new Button();
            btnHuyVe = new Button();
            btnKiemTra = new Button();

            dgvVeThang = new DataGridView();

            SuspendLayout();

            lblMaVe.Text = "Mã vé";
            lblMaVe.Location = new Point(20, 20);

            txtMaVe.Location = new Point(120, 20);
            txtMaVe.Width = 200;

            lblMaKH.Text = "Mã KH";
            lblMaKH.Location = new Point(20, 60);

            txtMaKH.Location = new Point(120, 60);
            txtMaKH.Width = 200;

            lblSoThe.Text = "Số thẻ";
            lblSoThe.Location = new Point(20, 100);

            txtSoThe.Location = new Point(120, 100);
            txtSoThe.Width = 200;

            btnDangKy.Text = "Đăng ký";
            btnDangKy.Location = new Point(20, 150);

            btnGiaHan.Text = "Gia hạn";
            btnGiaHan.Location = new Point(120, 150);

            btnHuyVe.Text = "Hủy vé";
            btnHuyVe.Location = new Point(220, 150);

            btnKiemTra.Text = "Kiểm tra";
            btnKiemTra.Location = new Point(320, 150);

            dgvVeThang.Location =
                new Point(20, 220);

            dgvVeThang.Size =
                new Size(760, 250);

            dgvVeThang.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            btnDangKy.Click +=
                btnDangKy_Click;

            btnGiaHan.Click +=
                btnGiaHan_Click;

            btnHuyVe.Click +=
                btnHuyVe_Click;

            btnKiemTra.Click +=
                btnKiemTra_Click;

            dgvVeThang.CellClick +=
                dgvVeThang_CellClick;

            Controls.Add(lblMaVe);
            Controls.Add(lblMaKH);
            Controls.Add(lblSoThe);

            Controls.Add(txtMaVe);
            Controls.Add(txtMaKH);
            Controls.Add(txtSoThe);

            Controls.Add(btnDangKy);
            Controls.Add(btnGiaHan);
            Controls.Add(btnHuyVe);
            Controls.Add(btnKiemTra);

            Controls.Add(dgvVeThang);

            Load += FrmVeThang_Load;

            ClientSize =
                new Size(820, 520);

            Text =
                "Quản lý vé tháng";

            ResumeLayout(false);
            PerformLayout();
        }
    }
}
