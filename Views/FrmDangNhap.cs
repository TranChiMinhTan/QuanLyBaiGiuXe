// [Người 1] Code-behind của FrmDangNhap (Designer là của bạn). Control cần có đúng tên:
//   TextBox txtTenDangNhap, txtMatKhau (UseSystemPasswordChar = True) | Button btnDangNhap, btnThoat
using System;
using System.Windows.Forms;
using QuanLyBaiGiuXe.Models;
using QuanLyBaiGiuXe.Presenters;

namespace QuanLyBaiGiuXe.Views
{
    public partial class FrmDangNhap : Form, IDangNhapView
    {
        private readonly DangNhapPresenter _p;
        public TaiKhoanDTO TaiKhoanDangNhap { get; private set; }

        public FrmDangNhap()
        {
            InitializeComponent();
            AcceptButton = btnDangNhap;                 // Enter = đăng nhập
            CancelButton = btnThoat;                    // Esc = thoát
            btnThoat.DialogResult = DialogResult.Cancel;

            // -= trước += để không bị gắn đúp nếu Designer đã gắn sẵn sự kiện cùng tên
            btnDangNhap.Click -= btnDangNhap_Click; btnDangNhap.Click += btnDangNhap_Click;
            btnThoat.Click -= btnThoat_Click; btnThoat.Click += btnThoat_Click;
            _p = new DangNhapPresenter(this);
        }

        private void btnDangNhap_Click(object sender, EventArgs e) => _p.DangNhap();
        private void btnThoat_Click(object sender, EventArgs e) => Close();

        public string TenDangNhap => txtTenDangNhap.Text.Trim();
        public string MatKhau => txtMatKhau.Text;

        public void DangNhapThanhCong(TaiKhoanDTO taiKhoan)
        {
            TaiKhoanDangNhap = taiKhoan;
            DialogResult = DialogResult.OK;
        }

        public void XoaMatKhau() { txtMatKhau.Clear(); txtMatKhau.Focus(); }

        public void ThongBao(string noiDung) => UiHelper.ThongBao(noiDung);
        public void BaoLoi(string noiDung) => UiHelper.BaoLoi(noiDung);
        public bool XacNhan(string noiDung) => UiHelper.XacNhan(noiDung);
    }
}