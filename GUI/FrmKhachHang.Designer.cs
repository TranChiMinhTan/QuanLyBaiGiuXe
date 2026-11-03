namespace GUI
{
    partial class FrmKhachHang
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblMaKH;
        private Label lblHoTen;
        private Label lblSDT;
        private Label lblDiaChi;

        private TextBox txtMaKH;
        private TextBox txtHoTen;
        private TextBox txtSDT;
        private TextBox txtDiaChi;

        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;

        private DataGridView dgvKhachHang;

        private void InitializeComponent()
        {
            lblMaKH = new Label();
            lblHoTen = new Label();
            lblSDT = new Label();
            lblDiaChi = new Label();

            txtMaKH = new TextBox();
            txtHoTen = new TextBox();
            txtSDT = new TextBox();
            txtDiaChi = new TextBox();

            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();

            dgvKhachHang = new DataGridView();

            SuspendLayout();

            lblMaKH.Text = "Mã KH";
            lblMaKH.Location = new Point(20, 20);

            txtMaKH.Location = new Point(120, 20);

            lblHoTen.Text = "Họ tên";
            lblHoTen.Location = new Point(20, 60);

            txtHoTen.Location = new Point(120, 60);

            lblSDT.Text = "SĐT";
            lblSDT.Location = new Point(20, 100);

            txtSDT.Location = new Point(120, 100);

            lblDiaChi.Text = "Địa chỉ";
            lblDiaChi.Location = new Point(20, 140);

            txtDiaChi.Location = new Point(120, 140);

            btnThem.Text = "Thêm";
            btnThem.Location = new Point(20, 190);

            btnSua.Text = "Sửa";
            btnSua.Location = new Point(120, 190);

            btnXoa.Text = "Xóa";
            btnXoa.Location = new Point(220, 190);

            dgvKhachHang.Location =
                new Point(20, 250);

            dgvKhachHang.Size =
                new Size(750, 250);

            Controls.AddRange(new Control[]
            {
                lblMaKH,lblHoTen,lblSDT,lblDiaChi,
                txtMaKH,txtHoTen,txtSDT,txtDiaChi,
                btnThem,btnSua,btnXoa,
                dgvKhachHang
            });

            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;

            dgvKhachHang.CellClick +=
                dgvKhachHang_CellClick;

            Load += FrmKhachHang_Load;

            Text = "Quản lý khách hàng";
            Size = new Size(820, 600);

            ResumeLayout(false);
        }
    }
}
