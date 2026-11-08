// [SÁNG TẠO #6] Điều phối màn hình nhật ký thao tác.
using System;
using QuanLyBaiGiuXe.BLL;
using QuanLyBaiGiuXe.Views;

namespace QuanLyBaiGiuXe.Presenters
{
    public class NhatKyPresenter
    {
        private readonly INhatKyView _view;
        public NhatKyPresenter(INhatKyView view) { _view = view; }

        public void Tai()
        {
            try { _view.HienThiDanhSach(NhatKyBLL.LayGanDay(_view.TuKhoaTim)); }
            catch (Exception ex) { _view.BaoLoi("Không tải được nhật ký: " + ex.Message); }
        }
    }
}
