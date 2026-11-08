// Điều phối đăng nhập.
using QuanLyBaiGiuXe.BLL;
using QuanLyBaiGiuXe.Models;
using QuanLyBaiGiuXe.Views;

namespace QuanLyBaiGiuXe.Presenters
{
    public class DangNhapPresenter
    {
        private readonly IDangNhapView _view;
        private readonly TaiKhoanBLL _bll = new TaiKhoanBLL();

        public DangNhapPresenter(IDangNhapView view) { _view = view; }

        public void DangNhap()
        {
            TaiKhoanDTO tk;
            string loi = _bll.DangNhap(_view.TenDangNhap, _view.MatKhau, out tk);
            if (loi != null) { _view.BaoLoi(loi); _view.XoaMatKhau(); return; }

            PhienLamViec.TaiKhoan = tk;
            NhatKyBLL.Ghi("Đăng nhập");
            _view.DangNhapThanhCong(tk);
        }
    }
}
