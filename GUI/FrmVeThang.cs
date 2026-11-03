using BLL;
using DTO;

namespace GUI
{
    public partial class FrmVeThang : Form
    {
        private VeThangBLL bll = new VeThangBLL();

        public FrmVeThang()
        {
            InitializeComponent();
        }

        private void FrmVeThang_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                dgvVeThang.DataSource = bll.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            try
            {
                VeThangDTO vt = new VeThangDTO();

                vt.MaKH = int.Parse(txtMaKH.Text);
                vt.SoThe = txtSoThe.Text;
                vt.NgayDangKy = DateTime.Now;
                vt.NgayHetHan = DateTime.Now.AddMonths(1);
                vt.TrangThai = true;

                if (bll.DangKy(vt))
                {
                    MessageBox.Show("Đăng ký thành công");
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGiaHan_Click(object sender, EventArgs e)
        {
            try
            {
                int maVe = int.Parse(txtMaVe.Text);

                if (bll.GiaHan(maVe))
                {
                    MessageBox.Show("Gia hạn thành công");
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnHuyVe_Click(object sender, EventArgs e)
        {
            try
            {
                int maVe = int.Parse(txtMaVe.Text);

                if (bll.Huy(maVe))
                {
                    MessageBox.Show("Đã hủy vé");
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            try
            {
                bool ketQua =
                    bll.KiemTraVeThang(txtSoThe.Text);

                MessageBox.Show(
                    ketQua
                    ? "Vé còn hiệu lực"
                    : "Vé hết hạn");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvVeThang_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row =
                dgvVeThang.Rows[e.RowIndex];

            txtMaVe.Text =
                row.Cells["MaVe"].Value.ToString();

            txtMaKH.Text =
                row.Cells["MaKH"].Value.ToString();

            txtSoThe.Text =
                row.Cells["SoThe"].Value.ToString();
        }
    }
}
