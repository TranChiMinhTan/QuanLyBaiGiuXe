namespace GUI
{
    partial class FrmChoTrong
    {
        private System.ComponentModel.IContainer components = null;

        private DataGridView dgvChoTrong;
        private Button btnTaiLai;
        private Label lblTieuDe;

        private void InitializeComponent()
        {
            dgvChoTrong =
                new DataGridView();

            btnTaiLai =
                new Button();

            lblTieuDe =
                new Label();

            SuspendLayout();

            lblTieuDe.Text =
                "BÁO CÁO CHỖ TRỐNG";

            lblTieuDe.Font =
                new Font(
                    "Segoe UI",
                    12F,
                    FontStyle.Bold);

            lblTieuDe.Location =
                new Point(20, 20);

            btnTaiLai.Text =
                "Tải lại";

            btnTaiLai.Location =
                new Point(670, 20);

            btnTaiLai.Size =
                new Size(100, 30);

            dgvChoTrong.Location =
                new Point(20, 70);

            dgvChoTrong.Size =
                new Size(750, 320);

            dgvChoTrong.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            btnTaiLai.Click +=
                btnTaiLai_Click;

            Controls.Add(lblTieuDe);
            Controls.Add(btnTaiLai);
            Controls.Add(dgvChoTrong);

            Load += FrmChoTrong_Load;

            ClientSize =
                new Size(800, 420);

            Text =
                "Chỗ trống";

            ResumeLayout(false);
            PerformLayout();
        }
    }
}
