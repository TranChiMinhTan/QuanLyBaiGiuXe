// Điều phối màn đổi mật khẩu của người đang đăng nhập (PhienLamViec).
using QuanLyBaiGiuXe.BLL;
using QuanLyBaiGiuXe.Views;

namespace QuanLyBaiGiuXe.Presenters
{
    public class DoiMatKhauPresenter
    {
        private readonly IDoiMatKhauView _view;
        private readonly TaiKhoanBLL _bll;

        public DoiMatKhauPresenter(IDoiMatKhauView view) : this(view, new TaiKhoanBLL()) { }

        public DoiMatKhauPresenter(IDoiMatKhauView view, TaiKhoanBLL bll)
        {
            _view = view;
            _bll = bll;
        }

        public void DoiMatKhau()
        {
            string loi = _bll.DoiMatKhau(_view.MatKhauCu, _view.MatKhauMoi, _view.NhapLaiMatKhauMoi);
            if (loi != null) { _view.BaoLoi(loi); return; }
            _view.ThongBao("Đổi mật khẩu thành công.");
            _view.DongForm();
        }
    }
}
