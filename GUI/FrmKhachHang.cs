using System;
using System.Windows.Forms;
using BLL;
using DTO;

namespace GUI
{
    public partial class FrmKhachHang : Form
    {
        private KhachHangBLL bll = new KhachHangBLL();

        TextBox txtMaKH = new TextBox();
        TextBox txtHoTen = new TextBox();
        TextBox txtSDT = new TextBox();
        TextBox txtDiaChi = new TextBox();

        Button btnThem = new Button();
        Button btnSua = new Button();
        Button btnXoa = new Button();
        Button btnLamMoi = new Button();

        DataGridView dgvKhachHang = new DataGridView();

        public FrmKhachHang()
        {
            InitializeComponentCustom();
        }

        private void InitializeComponentCustom()
        {
            this.Text = "Quản lý khách hàng";
            this.Size = new Size(900, 600);

            Label lblTen = new Label();
            lblTen.Text = "Họ tên";
            lblTen.Location = new Point(20, 20);

            txtHoTen.Location = new Point(120, 20);

            Label lblSDT = new Label();
            lblSDT.Text = "SĐT";
            lblSDT.Location = new Point(20, 60);

            txtSDT.Location = new Point(120, 60);

            Label lblDiaChi = new Label();
            lblDiaChi.Text = "Địa chỉ";
            lblDiaChi.Location = new Point(20, 100);

            txtDiaChi.Location = new Point(120, 100);

            btnThem.Text = "Thêm";
            btnThem.Location = new Point(20, 150);
            btnThem.Click += btnThem_Click;

            btnSua.Text = "Sửa";
            btnSua.Location = new Point(120, 150);
            btnSua.Click += btnSua_Click;

            btnXoa.Text = "Xóa";
            btnXoa.Location = new Point(220, 150);
            btnXoa.Click += btnXoa_Click;

            dgvKhachHang.Location =
                new Point(20, 220);

            dgvKhachHang.Size =
                new Size(820, 300);

            dgvKhachHang.CellClick +=
                dgvKhachHang_CellClick;

            Controls.Add(lblTen);
            Controls.Add(txtHoTen);
            Controls.Add(lblSDT);
            Controls.Add(txtSDT);
            Controls.Add(lblDiaChi);
            Controls.Add(txtDiaChi);
            Controls.Add(btnThem);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(dgvKhachHang);

            Load += FrmKhachHang_Load;
        }

        private void FrmKhachHang_Load(
            object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dgvKhachHang.DataSource =
                bll.GetAll();
        }

        private void btnThem_Click(
            object sender, EventArgs e)
        {
            KhachHangDTO kh =
                new KhachHangDTO();

            kh.HoTen = txtHoTen.Text;
            kh.SoDienThoai = txtSDT.Text;
            kh.DiaChi = txtDiaChi.Text;

            bll.Them(kh);

            LoadData();
        }

        private void btnSua_Click(
            object sender, EventArgs e)
        {
        }

        private void btnXoa_Click(
            object sender, EventArgs e)
        {
        }

        private void dgvKhachHang_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
        }
    }
}
