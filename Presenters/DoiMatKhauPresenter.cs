// Điều phối đổi mật khẩu.
using QuanLyBaiGiuXe.BLL;
using QuanLyBaiGiuXe.Views;

namespace QuanLyBaiGiuXe.Presenters
{
    public class DoiMatKhauPresenter
    {
        private readonly IDoiMatKhauView _view;
        private readonly TaiKhoanBLL _bll = new TaiKhoanBLL();

        public DoiMatKhauPresenter(IDoiMatKhauView view) { _view = view; }

        public void DoiMatKhau()
        {
            string loi = _bll.DoiMatKhau(_view.MatKhauCu, _view.MatKhauMoi, _view.NhapLaiMatKhauMoi);
            if (loi != null) { _view.BaoLoi(loi); return; }
            _view.ThongBao("Đổi mật khẩu thành công.");
            _view.DongForm();
        }
    }
}
