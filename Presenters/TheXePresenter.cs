// Điều phối màn Thẻ xe.
using System;
using QuanLyBaiGiuXe.BLL;
using QuanLyBaiGiuXe.Models;
using QuanLyBaiGiuXe.Views;

namespace QuanLyBaiGiuXe.Presenters
{
    public class TheXePresenter
    {
        private readonly ITheXeView _view;
        private readonly TheXeBLL _bll;
        private readonly LoaiXeBLL _loaiXeBll = new LoaiXeBLL();

        public TheXePresenter(ITheXeView view) : this(view, new TheXeBLL()) { }

        public TheXePresenter(ITheXeView view, TheXeBLL bll)
        {
            _view = view;
            _bll = bll;
        }

        /// <summary>Gọi một lần khi UserControl Load: nạp loại xe rồi danh sách thẻ.</summary>
        public void KhoiDong()
        {
            try { _view.NapLoaiXe(_loaiXeBll.LayTatCa(null)); }
            catch (Exception ex) { _view.BaoLoi("Không tải được danh sách loại xe: " + ex.Message); }
            Tai();
        }

        public void Tai()
        {
            try { _view.HienThiDanhSach(_bll.LayTatCa(_view.TuKhoaTim)); }
            catch (Exception ex) { _view.BaoLoi("Không tải được danh sách thẻ xe: " + ex.Message); }
        }

        public void Chon(TheXeDTO t) { if (t != null) _view.HienThiChiTiet(t); }

        public void Them()
        {
            string loi = _bll.Them(DocTuView());
            if (loi != null) { _view.BaoLoi(loi); return; }
            _view.ThongBao("Thêm thẻ xe thành công.");
            _view.XoaNhap();
            Tai();
        }

        public void Sua()
        {
            string loi = _bll.Sua(DocTuView());
            if (loi != null) { _view.BaoLoi(loi); return; }
            _view.ThongBao("Cập nhật thẻ xe thành công.");
            Tai();
        }

        public void Xoa()
        {
            if (string.IsNullOrEmpty(_view.MaThe)) { _view.BaoLoi("Hãy chọn một thẻ trong danh sách để xóa."); return; }
            if (!_view.XacNhan("Xóa thẻ " + _view.MaThe + "?")) return;
            string loi = _bll.Xoa(_view.MaThe);
            if (loi != null) { _view.BaoLoi(loi); return; }
            _view.ThongBao("Xóa thẻ xe thành công.");
            _view.XoaNhap();
            Tai();
        }

        private TheXeDTO DocTuView() => new TheXeDTO
        {
            MaThe = _view.MaThe, MaLoaiXe = _view.MaLoaiXe, TrangThai = _view.TrangThai, NgayCap = _view.NgayCap
        };
    }
}
