using BLL;
using DTO;
using System;
using System.Windows.Forms;

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
            try
            {
                dgvKhachHang.DataSource =
                    bll.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message);
            }
        }

        private void btnThem_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                KhachHangDTO kh =
                    new KhachHangDTO()
                    {
                        HoTen =
                            txtHoTen.Text.Trim(),

                        SoDienThoai =
                            txtSDT.Text.Trim(),

                        DiaChi =
                            txtDiaChi.Text.Trim()
                    };

                bll.Them(kh);

                MessageBox.Show(
                    "Thêm thành công");

                LoadData();

                LamMoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message);
            }
        }

        private void btnSua_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                KhachHangDTO kh =
                    new KhachHangDTO()
                    {
                        MaKH =
                            int.Parse(
                                txtMaKH.Text),

                        HoTen =
                            txtHoTen.Text.Trim(),

                        SoDienThoai =
                            txtSDT.Text.Trim(),

                        DiaChi =
                            txtDiaChi.Text.Trim()
                    };

                bll.Sua(kh);

                MessageBox.Show(
                    "Cập nhật thành công");

                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message);
            }
        }

        private void btnXoa_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                DialogResult rs =
                    MessageBox.Show(
                        "Xóa khách hàng?",
                        "Thông báo",
                        MessageBoxButtons.YesNo);

                if (rs == DialogResult.Yes)
                {
                    bll.Xoa(
                        int.Parse(
                            txtMaKH.Text));

                    MessageBox.Show(
                        "Xóa thành công");

                    LoadData();

                    LamMoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message);
            }
        }

        private void btnLamMoi_Click(
            object sender,
            EventArgs e)
        {
            LamMoi();
        }

        private void LamMoi()
        {
            txtMaKH.Clear();
            txtHoTen.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();

            txtHoTen.Focus();
        }

        private void dgvKhachHang_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;

                DataGridViewRow row =
                    dgvKhachHang.Rows[e.RowIndex];

                txtMaKH.Text =
                    row.Cells["MaKH"]
                        .Value.ToString();

                txtHoTen.Text =
                    row.Cells["HoTen"]
                        .Value.ToString();

                txtSDT.Text =
                    row.Cells["SoDienThoai"]
                        .Value.ToString();

                txtDiaChi.Text =
                    row.Cells["DiaChi"]
                        .Value.ToString();
            }
            catch
            {
            }
        }
    }
}
