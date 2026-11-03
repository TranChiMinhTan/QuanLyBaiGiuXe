using BLL;
using DTO;

namespace GUI
{
    public partial class FrmKhachHang : Form
    {
        private KhachHangBLL bll =
            new KhachHangBLL();

        public FrmKhachHang()
        {
            InitializeComponent();
        }

        private void FrmKhachHang_Load(
            object sender,
            EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dgvKhachHang.DataSource =
                bll.GetAll();
        }

        private void btnThem_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                KhachHangDTO kh =
                    new KhachHangDTO();

                kh.HoTen =
                    txtHoTen.Text.Trim();

                kh.SoDienThoai =
                    txtSDT.Text.Trim();

                kh.DiaChi =
                    txtDiaChi.Text.Trim();

                bll.Them(kh);

                MessageBox.Show(
                    "Thêm thành công");

                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSua_Click(
            object sender,
            EventArgs e)
        {
            KhachHangDTO kh =
                new KhachHangDTO();

            kh.MaKH =
                Convert.ToInt32(txtMaKH.Text);

            kh.HoTen =
                txtHoTen.Text;

            kh.SoDienThoai =
                txtSDT.Text;

            kh.DiaChi =
                txtDiaChi.Text;

            bll.Sua(kh);

            MessageBox.Show(
                "Cập nhật thành công");

            LoadData();
        }

        private void btnXoa_Click(
            object sender,
            EventArgs e)
        {
            int maKH =
                Convert.ToInt32(txtMaKH.Text);

            if (MessageBox.Show(
                "Xóa khách hàng?",
                "Xác nhận",
                MessageBoxButtons.YesNo)
                == DialogResult.Yes)
            {
                bll.Xoa(maKH);

                LoadData();
            }
        }

        private void dgvKhachHang_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row =
                dgvKhachHang.Rows[e.RowIndex];

            txtMaKH.Text =
                row.Cells["MaKH"].Value.ToString();

            txtHoTen.Text =
                row.Cells["HoTen"].Value.ToString();

            txtSDT.Text =
                row.Cells["SoDienThoai"].Value.ToString();

            txtDiaChi.Text =
                row.Cells["DiaChi"].Value.ToString();
        }
    }
}
