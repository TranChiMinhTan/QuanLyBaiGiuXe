using System;
using System.Windows.Forms;
using BLL;
using DTO;

namespace GUI
{
    public partial class FrmVeThang : Form
    {
        private VeThangBLL bll =
            new VeThangBLL();

        ComboBox cboKhachHang =
            new ComboBox();

        ComboBox cboSoThe =
            new ComboBox();

        TextBox txtMaVe =
            new TextBox();

        TextBox txtSoThe =
            new TextBox();

        Button btnDangKy =
            new Button();

        Button btnGiaHan =
            new Button();

        Button btnHuy =
            new Button();

        Button btnKiemTra =
            new Button();

        DataGridView dgvVeThang =
            new DataGridView();

        public FrmVeThang()
        {
            InitializeComponentCustom();
        }

        private void InitializeComponentCustom()
        {
            this.Text = "Quản lý vé tháng";
            this.Size = new Size(900, 600);

            btnDangKy.Text = "Đăng ký";
            btnDangKy.Location =
                new Point(20, 20);

            btnDangKy.Click +=
                btnDangKy_Click;

            btnGiaHan.Text =
                "Gia hạn";

            btnGiaHan.Location =
                new Point(120, 20);

            btnGiaHan.Click +=
                btnGiaHan_Click;

            btnHuy.Text =
                "Hủy vé";

            btnHuy.Location =
                new Point(220, 20);

            btnHuy.Click +=
                btnHuyVe_Click;

            btnKiemTra.Text =
                "Kiểm tra";

            btnKiemTra.Location =
                new Point(320, 20);

            btnKiemTra.Click +=
                btnKiemTra_Click;

            dgvVeThang.Location =
                new Point(20, 100);

            dgvVeThang.Size =
                new Size(820, 400);

            Controls.Add(btnDangKy);
            Controls.Add(btnGiaHan);
            Controls.Add(btnHuy);
            Controls.Add(btnKiemTra);
            Controls.Add(dgvVeThang);

            Load += FrmVeThang_Load;
        }

        private void FrmVeThang_Load(
            object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dgvVeThang.DataSource =
                bll.GetAll();
        }
    }
}
