using BLL;
using DTO;

namespace GUI
{
    public partial class FrmKhachHang : Form
    {
        private KhachHangBLL bll = new KhachHangBLL();

        public FrmKhachHang()
        {
            InitializeComponent();
        }

        private void FrmKhachHang_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dgvKhachHang.DataSource = bll.GetAll();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                KhachHangDTO kh = new KhachHangDTO()
                {
                    HoTen = txtHoTen.Text,
                    SoDienThoai = txtSDT.Text,
                    DiaChi = txtDiaChi.Text
                };

                bll.Them(kh);

                MessageBox.Show("Thêm thành công");

                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            KhachHangDTO kh = new KhachHangDTO()
            {
                MaKH = int.Parse(txtMaKH.Text),
                HoTen = txtHoTen.Text,
                SoDienThoai = txtSDT.Text,
                DiaChi = txtDiaChi.Text
            };

            bll.Sua(kh);

            MessageBox.Show("Cập nhật thành công");

            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Xóa khách hàng?",
                "Thông báo",
                MessageBoxButtons.YesNo)
                == DialogResult.Yes)
            {
                bll.Xoa(int.Parse(txtMaKH.Text));

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
