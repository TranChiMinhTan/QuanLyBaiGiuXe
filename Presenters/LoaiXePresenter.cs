// Điều phối màn Loại xe: nhận thao tác từ View, gọi LoaiXeBLL, bảo View hiển thị.
using System;
using QuanLyBaiGiuXe.BLL;
using QuanLyBaiGiuXe.Models;
using QuanLyBaiGiuXe.Views;

namespace QuanLyBaiGiuXe.Presenters
{
    public class LoaiXePresenter
    {
        private readonly ILoaiXeView _view;
        private readonly LoaiXeBLL _bll;

        public LoaiXePresenter(ILoaiXeView view) : this(view, new LoaiXeBLL()) { }

        public LoaiXePresenter(ILoaiXeView view, LoaiXeBLL bll)
        {
            _view = view;
            _bll = bll;
        }

        public void Tai()
        {
            try { _view.HienThiDanhSach(_bll.LayTatCa(_view.TuKhoaTim)); }
            catch (Exception ex) { _view.BaoLoi("Không tải được danh sách loại xe: " + ex.Message); }
        }

        public void Chon(LoaiXeDTO x) { if (x != null) _view.HienThiChiTiet(x); }

        public void Them()
        {
            string loi = _bll.Them(DocTuView());
            if (loi != null) { _view.BaoLoi(loi); return; }
            _view.ThongBao("Thêm loại xe thành công.");
            _view.XoaNhap();
            Tai();
        }

        public void Sua()
        {
            string loi = _bll.Sua(DocTuView());
            if (loi != null) { _view.BaoLoi(loi); return; }
            _view.ThongBao("Cập nhật loại xe thành công.");
            Tai();
        }

        public void Xoa()
        {
            if (_view.MaLoaiXe <= 0) { _view.BaoLoi("Hãy chọn một loại xe trong danh sách để xóa."); return; }
            if (!_view.XacNhan("Xóa loại xe \"" + _view.TenLoai + "\" cùng bảng giá của nó?")) return;
            string loi = _bll.Xoa(_view.MaLoaiXe);
            if (loi != null) { _view.BaoLoi(loi); return; }
            _view.ThongBao("Xóa loại xe thành công.");
            _view.XoaNhap();
            Tai();
        }

        private LoaiXeDTO DocTuView() => new LoaiXeDTO
        {
            MaLoaiXe = _view.MaLoaiXe, TenLoai = _view.TenLoai, SucChua = _view.SucChua, MoTa = _view.MoTa
        };
    }
}
