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
        private Button btnLamMoi;

        private DataGridView dgvKhachHang;

        protected override void Dispose(
            bool disposing)
        {
            if (disposing &&
                (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

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
            btnLamMoi = new Button();

            dgvKhachHang =
                new DataGridView();

            ((System.ComponentModel.ISupportInitialize)
                dgvKhachHang).BeginInit();

            SuspendLayout();

            lblMaKH.Text = "Mã KH";
            lblMaKH.Location = new Point(20, 20);

            txtMaKH.Location = new Point(120, 20);
            txtMaKH.ReadOnly = true;

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
            btnThem.Location =
                new Point(20, 190);

            btnSua.Text = "Sửa";
            btnSua.Location =
                new Point(120, 190);

            btnXoa.Text = "Xóa";
            btnXoa.Location =
                new Point(220, 190);

            btnLamMoi.Text = "Làm mới";
            btnLamMoi.Location =
                new Point(320, 190);

            dgvKhachHang.Location =
                new Point(20, 250);

            dgvKhachHang.Size =
                new Size(760, 250);

            dgvKhachHang.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += btnLamMoi_Click;

            dgvKhachHang.CellClick +=
                dgvKhachHang_CellClick;

            Controls.Add(lblMaKH);
            Controls.Add(lblHoTen);
            Controls.Add(lblSDT);
            Controls.Add(lblDiaChi);

            Controls.Add(txtMaKH);
            Controls.Add(txtHoTen);
            Controls.Add(txtSDT);
            Controls.Add(txtDiaChi);

            Controls.Add(btnThem);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnLamMoi);

            Controls.Add(dgvKhachHang);

            Load += FrmKhachHang_Load;

            ClientSize =
                new Size(820, 550);

            Text =
                "Quản lý khách hàng";

            ((System.ComponentModel.ISupportInitialize)
                dgvKhachHang).EndInit();

            ResumeLayout(false);
            PerformLayout();
        }
    }
}
