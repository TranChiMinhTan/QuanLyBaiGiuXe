// [Người 1] Khung chính: 8 tab, thanh trạng thái, phân quyền.
// Control cần có đúng tên: TabControl tabMain; TabPage tabVanHanh, tabTraCuu, tabVeThang, tabKhachHang,
//   tabBaoCao, tabBangGia, tabLoaiXe, tabTheXe; StatusStrip với ToolStripStatusLabel lblNguoiDung, lblNgayGio,
//   lblXeTrongBai; Timer timerDongHo (Interval 1000, Enabled).
// [SÁNG TẠO #5] Thanh trạng thái cảnh báo "bãi sắp đầy / đã đầy" (CapNhatTrangThaiBai).
// [SÁNG TẠO #6] Bấm vào tên người dùng ở thanh trạng thái: Đổi mật khẩu, Nhật ký thao tác, Đăng xuất.
using System;
using System.Drawing;
using System.Windows.Forms;
using QuanLyBaiGiuXe.BLL;
using QuanLyBaiGiuXe.Models;

namespace QuanLyBaiGiuXe.Views
{
    public partial class FrmMain : Form
    {
        private readonly TaiKhoanDTO _tk;
        private readonly ChoTrongBLL _choTrong = new ChoTrongBLL();
        private int _dem;

        public bool DangXuat { get; private set; }

        public FrmMain(TaiKhoanDTO taiKhoan)
        {
            InitializeComponent();
            _tk = taiKhoan;
            // -= trước += để không gắn đúp nếu Designer đã gắn sự kiện cùng tên
            Load -= FrmMain_Load; Load += FrmMain_Load;
            timerDongHo.Tick -= timerDongHo_Tick; timerDongHo.Tick += timerDongHo_Tick;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            lblNguoiDung.Text = "Nhân viên: " + _tk.HoTen + " (" + (_tk.LaQuanLy ? "Quản lý" : "Nhân viên") + ") ▾";
            lblNguoiDung.IsLink = true;
            lblNguoiDung.Click -= LblNguoiDung_Click; lblNguoiDung.Click += LblNguoiDung_Click;
            CapNhatDongHo();

            NhungMan(tabVanHanh, new ucVanHanh());
            NhungMan(tabTraCuu, new ucTraCuu());
            NhungMan(tabVeThang, new ucVeThang());
            NhungMan(tabKhachHang, new ucKhachHang());
            NhungMan(tabBaoCao, new ucBaoCao());
            NhungMan(tabBangGia, new ucBangGia());
            NhungMan(tabLoaiXe, new ucLoaiXe());
            NhungMan(tabTheXe, new ucTheXe());

            PhanQuyen();
            CapNhatTrangThaiBai();
        }

        private static void NhungMan(TabPage tab, UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            tab.Controls.Add(uc);
        }

        /// <summary>Nhân viên chỉ thấy 4 tab đầu. Quản lý thấy cả 8 tab.</summary>
        private void PhanQuyen()
        {
            if (_tk.LaQuanLy) return;
            tabMain.TabPages.Remove(tabBaoCao);
            tabMain.TabPages.Remove(tabBangGia);
            tabMain.TabPages.Remove(tabLoaiXe);
            tabMain.TabPages.Remove(tabTheXe);
        }

        private void timerDongHo_Tick(object sender, EventArgs e)
        {
            CapNhatDongHo();
            if (++_dem % 30 == 0) CapNhatTrangThaiBai();        // làm mới số chỗ trống mỗi 30 giây
        }

        private void CapNhatDongHo() => lblNgayGio.Text = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");

        /// <summary>ucVanHanh gọi hàm này sau mỗi lần xe vào/ra.</summary>
        public void CapNhatSoXe(int dangGui) => CapNhatTrangThaiBai();

        private void CapNhatTrangThaiBai()
        {
            try
            {
                var t = _choTrong.TongHop();
                string s = "Xe trong bãi: " + t.DangGui + " | Còn trống: " + t.ConTrong + "/" + t.SucChua;
                if (t.SucChua > 0 && t.ConTrong <= 0)
                {
                    lblXeTrongBai.Text = s + " | BÃI ĐÃ ĐẦY";
                    lblXeTrongBai.ForeColor = Color.White; lblXeTrongBai.BackColor = Color.Firebrick;
                }
                else if (t.SucChua > 0 && t.ConTrong * 10 <= t.SucChua)
                {
                    lblXeTrongBai.Text = s + " | Bãi sắp đầy";
                    lblXeTrongBai.ForeColor = Color.Black; lblXeTrongBai.BackColor = Color.Orange;
                }
                else
                {
                    lblXeTrongBai.Text = s;
                    lblXeTrongBai.ForeColor = SystemColors.ControlText; lblXeTrongBai.BackColor = Color.Transparent;
                }
            }
            catch { lblXeTrongBai.Text = "Chưa kết nối được cơ sở dữ liệu"; }
        }

        private void LblNguoiDung_Click(object sender, EventArgs e)
        {
            var menu = new ContextMenuStrip();
            menu.Items.Add("Đổi mật khẩu", null, (a, b) => { using (var f = new FrmDoiMatKhau()) f.ShowDialog(this); });
            if (_tk.LaQuanLy)
                menu.Items.Add("Nhật ký thao tác", null, (a, b) => { using (var f = new FrmNhatKy()) f.ShowDialog(this); });
            menu.Items.Add("Đăng xuất", null, (a, b) =>
            {
                if (!UiHelper.XacNhan("Đăng xuất khỏi hệ thống?")) return;
                NhatKyBLL.Ghi("Đăng xuất");
                DangXuat = true;
                Close();
            });
            menu.Show(Cursor.Position);
        }
    }
}