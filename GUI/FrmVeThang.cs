using BLL;
using DTO;

namespace GUI
{
    public partial class FrmVeThang : Form
    {
        private VeThangBLL bll =
            new VeThangBLL();

        public FrmVeThang()
        {
            InitializeComponent();
        }

        private void FrmVeThang_Load(
            object sender,
            EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dgvVeThang.DataSource =
                bll.GetAll();
        }

        private void btnDangKy_Click(
            object sender,
            EventArgs e)
        {
            VeThangDTO vt =
                new VeThangDTO();

            vt.MaKH =
                Convert.ToInt32(
                    cboKhachHang.SelectedValue);

            vt.SoThe =
                cboSoThe.Text;

            vt.NgayDangKy =
                DateTime.Now;

            vt.NgayHetHan =
                DateTime.Now.AddMonths(1);

            vt.TrangThai =
                true;

            if (bll.DangKy(vt))
            {
                MessageBox.Show(
                    "Đăng ký thành công");

                LoadData();
            }
        }

        private void btnGiaHan_Click(
            object sender,
            EventArgs e)
        {
            int maVe =
                Convert.ToInt32(txtMaVe.Text);

            if (bll.GiaHan(maVe))
            {
                MessageBox.Show(
                    "Gia hạn thành công");

                LoadData();
            }
        }

        private void btnHuyVe_Click(
            object sender,
            EventArgs e)
        {
            int maVe =
                Convert.ToInt32(txtMaVe.Text);

            if (bll.Huy(maVe))
            {
                MessageBox.Show(
                    "Đã hủy vé");

                LoadData();
            }
        }

        private void btnKiemTra_Click(
            object sender,
            EventArgs e)
        {
            bool ketQua =
                bll.KiemTraVeThang(
                    txtSoThe.Text);

            MessageBox.Show(
                ketQua
                ? "Vé còn hạn"
                : "Vé đã hết hạn");
        }

        private void dgvVeThang_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            txtMaVe.Text =
                dgvVeThang.Rows[e.RowIndex]
                .Cells["MaVe"]
                .Value.ToString();

            txtSoThe.Text =
                dgvVeThang.Rows[e.RowIndex]
                .Cells["SoThe"]
                .Value.ToString();
        }
    }
}
