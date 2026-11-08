// Điều phối màn xem nhật ký thao tác (chỉ Quản lý).
using System;
using QuanLyBaiGiuXe.BLL;
using QuanLyBaiGiuXe.Views;

namespace QuanLyBaiGiuXe.Presenters
{
    public class NhatKyPresenter
    {
        private readonly INhatKyView _view;
        private readonly NhatKyBLL _bll;

        public NhatKyPresenter(INhatKyView view) : this(view, new NhatKyBLL()) { }

        public NhatKyPresenter(INhatKyView view, NhatKyBLL bll)
        {
            _view = view;
            _bll = bll;
        }

        public void Tai()
        {
            try { _view.HienThiDanhSach(_bll.LayGanNhat(_view.TuKhoaTim)); }
            catch (UnauthorizedAccessException ex) { _view.BaoLoi(ex.Message); }
            catch (Exception ex) { _view.BaoLoi("Không tải được nhật ký: " + ex.Message); }
        }
    }
}
