using System;
using System.Drawing;
using System.Windows.Forms;
using QuanLyBaiXe.BLL;
using QuanLyBaiXe.DAL;

namespace QuanLyBaiXe.GUI
{
    /// <summary>
    /// Màn hình chính MDI: MenuStrip + ToolStrip + StatusStrip.
    /// QUY ƯỚC: chỉ Người 1 sửa file này. Form của người khác được mở bằng tên lớp (xem MoForm),
    /// nên chưa có form cũng không lỗi biên dịch; khi có form đúng tên lớp thì menu tự mở được.
    /// </summary>
    public class FrmMain : Form
    {
        public bool DangXuat { get; private set; }

        private readonly MenuStrip menu = new MenuStrip();
        private readonly ToolStrip tool = new ToolStrip();
        private readonly StatusStrip status = new StatusStrip();
        private readonly ToolStripStatusLabel lblNguoiDung = new ToolStripStatusLabel();
        private readonly ToolStripStatusLabel lblKetNoi = new ToolStripStatusLabel();
        private readonly ToolStripStatusLabel lblGio = new ToolStripStatusLabel();
        private readonly Timer timer = new Timer { Interval = 1000 };
        private int demGiay = 0;

        private ToolStripMenuItem mnuDanhMuc;
        private ToolStripMenuItem mnuBaoCao;

        public FrmMain()
        {
            Text = "Quản lý bãi giữ xe";
            IsMdiContainer = true;
            WindowState = FormWindowState.Maximized;
            MinimumSize = new Size(900, 600);

            TaoMenu();
            TaoToolStrip();
            TaoStatusStrip();

            // Thứ tự Add: status, tool, menu -> menu nằm trên cùng, tool ngay dưới menu
            Controls.Add(status);
            Controls.Add(tool);
            Controls.Add(menu);
            MainMenuStrip = menu;

            PhanQuyen();

            timer.Tick += Timer_Tick;
            Load += delegate { CapNhatKetNoi(); CapNhatGio(); timer.Start(); };
            FormClosing += FrmMain_FormClosing;
            FormClosed += delegate { timer.Stop(); };
        }

        // ================= Menu =================
        private ToolStripMenuItem TaoMuc(string chu, EventHandler click, Keys phim)
        {
            ToolStripMenuItem m = new ToolStripMenuItem(chu);
            if (click != null) m.Click += click;
            if (phim != Keys.None) m.ShortcutKeys = phim;
            return m;
        }

        private ToolStripMenuItem MucMoForm(string chu, string tenLop)
        {
            return TaoMuc(chu, delegate { MoForm(tenLop); }, Keys.None);
        }

        private void TaoMenu()
        {
            // --- Hệ thống ---
            ToolStripMenuItem mnuHeThong = TaoMuc("&Hệ thống", null, Keys.None);
            mnuHeThong.DropDownItems.Add(TaoMuc("Đổi &mật khẩu", delegate { MoDoiMatKhau(); }, Keys.None));
            mnuHeThong.DropDownItems.Add(new ToolStripSeparator());
            mnuHeThong.DropDownItems.Add(TaoMuc("Đăng &xuất", delegate { DangXuatClick(); }, Keys.None));
            mnuHeThong.DropDownItems.Add(TaoMuc("&Thoát", delegate { Close(); }, Keys.None));

            // --- Danh mục (chỉ quản lý) ---
            mnuDanhMuc = TaoMuc("&Danh mục", null, Keys.None);
            mnuDanhMuc.DropDownItems.Add(MucMoForm("&Loại xe", "FrmLoaiXe"));
            mnuDanhMuc.DropDownItems.Add(MucMoForm("&Thẻ xe", "FrmTheXe"));
            mnuDanhMuc.DropDownItems.Add(MucMoForm("&Bảng giá", "FrmBangGia"));

            // --- Gửi xe (Người 2) ---
            ToolStripMenuItem mnuGuiXe = TaoMuc("&Gửi xe", null, Keys.None);
            mnuGuiXe.DropDownItems.Add(TaoMuc("Xe &vào", delegate { MoForm("FrmXeVao"); }, Keys.F2));
            mnuGuiXe.DropDownItems.Add(TaoMuc("Xe &ra", delegate { MoForm("FrmXeRa"); }, Keys.F3));

            // --- Khách hàng & vé tháng (Người 3) ---
            ToolStripMenuItem mnuKhach = TaoMuc("&Khách hàng", null, Keys.None);
            mnuKhach.DropDownItems.Add(MucMoForm("&Khách hàng", "FrmKhachHang"));
            mnuKhach.DropDownItems.Add(MucMoForm("&Vé tháng", "FrmVeThang"));

            // --- Tra cứu (Người 4) ---
            ToolStripMenuItem mnuTraCuu = TaoMuc("&Tra cứu", null, Keys.None);
            mnuTraCuu.DropDownItems.Add(MucMoForm("&Lịch sử lượt gửi", "FrmLichSuLuotGui"));

            // --- Báo cáo (chỉ quản lý, Người 4) ---
            mnuBaoCao = TaoMuc("&Báo cáo", null, Keys.None);
            mnuBaoCao.DropDownItems.Add(MucMoForm("&Doanh thu", "FrmBaoCaoDoanhThu"));
            mnuBaoCao.DropDownItems.Add(MucMoForm("Thống kê &lượt xe theo ngày", "FrmThongKeLuotXe"));

            // --- Cửa sổ ---
            ToolStripMenuItem mnuCuaSo = TaoMuc("&Cửa sổ", null, Keys.None);
            mnuCuaSo.DropDownItems.Add(TaoMuc("Xếp &chồng", delegate { LayoutMdi(MdiLayout.Cascade); }, Keys.None));
            mnuCuaSo.DropDownItems.Add(TaoMuc("Xếp &ngang", delegate { LayoutMdi(MdiLayout.TileHorizontal); }, Keys.None));
            mnuCuaSo.DropDownItems.Add(TaoMuc("Xếp &dọc", delegate { LayoutMdi(MdiLayout.TileVertical); }, Keys.None));
            mnuCuaSo.DropDownItems.Add(new ToolStripSeparator());
            mnuCuaSo.DropDownItems.Add(TaoMuc("Đóng &tất cả", delegate { DongTatCa(); }, Keys.None));

            // --- Trợ giúp ---
            ToolStripMenuItem mnuTroGiup = TaoMuc("T&rợ giúp", null, Keys.None);
            mnuTroGiup.DropDownItems.Add(TaoMuc("&Giới thiệu", delegate
            {
                MessageBox.Show("Phần mềm Quản lý bãi giữ xe\nĐề tài 19 - Nhóm 4 thành viên.",
                    "Giới thiệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }, Keys.None));

            menu.Items.AddRange(new ToolStripItem[]
            {
                mnuHeThong, mnuDanhMuc, mnuGuiXe, mnuKhach, mnuTraCuu, mnuBaoCao, mnuCuaSo, mnuTroGiup
            });
        }

        // ================= ToolStrip =================
        private ToolStripButton TaoNut(string chu, string tenLop)
        {
            ToolStripButton n = new ToolStripButton(chu);
            n.DisplayStyle = ToolStripItemDisplayStyle.Text;
            n.Click += delegate { MoForm(tenLop); };
            return n;
        }

        private void TaoToolStrip()
        {
            tool.Items.Add(TaoNut("Xe vào (F2)", "FrmXeVao"));
            tool.Items.Add(TaoNut("Xe ra (F3)", "FrmXeRa"));
            tool.Items.Add(new ToolStripSeparator());
            tool.Items.Add(TaoNut("Vé tháng", "FrmVeThang"));
            tool.Items.Add(TaoNut("Tra cứu lịch sử", "FrmLichSuLuotGui"));
        }

        // ================= StatusStrip =================
        private void TaoStatusStrip()
        {
            lblNguoiDung.Spring = true;
            lblNguoiDung.TextAlign = ContentAlignment.MiddleLeft;
            lblNguoiDung.Text = "Người dùng: " + PhienDangNhap.NguoiDung.HoTen +
                " (" + (PhienDangNhap.DangQuanLy ? "Quản lý" : "Nhân viên") + ")";

            lblKetNoi.BorderSides = ToolStripStatusLabelBorderSides.Left;
            lblGio.BorderSides = ToolStripStatusLabelBorderSides.Left;

            status.Items.AddRange(new ToolStripItem[] { lblNguoiDung, lblKetNoi, lblGio });
        }

        private void CapNhatGio()
        {
            lblGio.Text = "  " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "  ";
        }

        private void CapNhatKetNoi()
        {
            string loi;
            bool tot = Database.KiemTraKetNoi(out loi);
            lblKetNoi.Text = tot ? "  CSDL: Đã kết nối  " : "  CSDL: MẤT KẾT NỐI  ";
            lblKetNoi.ForeColor = tot ? Color.ForestGreen : Color.Red;
            lblKetNoi.ToolTipText = tot ? "" : loi;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            CapNhatGio();
            demGiay++;
            if (demGiay % 30 == 0) CapNhatKetNoi();   // kiểm tra kết nối mỗi 30 giây
        }

        // ================= Phân quyền =================
        private void PhanQuyen()
        {
            bool quanLy = PhienDangNhap.DangQuanLy;
            mnuDanhMuc.Visible = quanLy;   // nhân viên không thấy menu Danh mục
            mnuBaoCao.Visible = quanLy;    // nhân viên không thấy menu Báo cáo
        }

        // ================= Mở form con =================
        private void MoForm(string tenLop)
        {
            Type kieu = Type.GetType("QuanLyBaiXe.GUI." + tenLop);
            if (kieu == null)
            {
                MessageBox.Show("Chức năng \"" + tenLop + "\" chưa được tích hợp vào chương trình.",
                    "Chưa có chức năng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Mỗi form chỉ mở một cửa sổ: nếu đã mở thì kích hoạt lại
            foreach (Form con in MdiChildren)
            {
                if (con.GetType() == kieu)
                {
                    if (con.WindowState == FormWindowState.Minimized) con.WindowState = FormWindowState.Normal;
                    con.Activate();
                    return;
                }
            }

            Form f = (Form)Activator.CreateInstance(kieu);
            f.MdiParent = this;
            f.Show();
        }

        private void DongTatCa()
        {
            foreach (Form con in MdiChildren) con.Close();
        }

        private void MoDoiMatKhau()
        {
            using (FrmDoiMatKhau f = new FrmDoiMatKhau())
            {
                f.ShowDialog(this);
            }
        }

        private void DangXuatClick()
        {
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Đăng xuất",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            DangXuat = true;
            Close();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DangXuat) return;

            if (e.CloseReason == CloseReason.UserClosing &&
                MessageBox.Show("Bạn có chắc muốn thoát chương trình?", "Thoát",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
