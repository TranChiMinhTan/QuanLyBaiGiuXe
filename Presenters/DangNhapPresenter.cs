// Điều phối màn đăng nhập: đọc tên/mật khẩu từ View, gọi TaiKhoanBLL, báo kết quả cho View.
using QuanLyBaiGiuXe.BLL;
using QuanLyBaiGiuXe.Models;
using QuanLyBaiGiuXe.Views;

namespace QuanLyBaiGiuXe.Presenters
{
    public class DangNhapPresenter
    {
        private readonly IDangNhapView _view;
        private readonly TaiKhoanBLL _bll;

        public DangNhapPresenter(IDangNhapView view) : this(view, new TaiKhoanBLL()) { }

        public DangNhapPresenter(IDangNhapView view, TaiKhoanBLL bll)
        {
            _view = view;
            _bll = bll;
        }

        public void DangNhap()
        {
            TaiKhoanDTO tk;
            string loi = _bll.DangNhap(_view.TenDangNhap, _view.MatKhau, out tk);
            if (loi != null)
            {
                _view.BaoLoi(loi);
                _view.XoaMatKhau();
                return;
            }
            _view.DangNhapThanhCong(tk);
        }
    }
}
