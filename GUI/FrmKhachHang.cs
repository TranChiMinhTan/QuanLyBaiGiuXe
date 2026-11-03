using BLL;
using DTO;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class FrmKhachHang : Form
    {
        private KhachHangBLL bll = new KhachHangBLL();

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
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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
                        HoTen = txtHoTen.Text.Trim(),
                        SoDienThoai = txtSDT.Text.Trim(),
                        DiaChi = txtDiaChi.Text.Trim()
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
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
