// Điều phối màn Bảng giá (mô hình B+).
using System;
using QuanLyBaiGiuXe.BLL;
using QuanLyBaiGiuXe.Models;
using QuanLyBaiGiuXe.Views;

namespace QuanLyBaiGiuXe.Presenters
{
    public class BangGiaPresenter
    {
        private readonly IBangGiaView _view;
        private readonly BangGiaBLL _bll;

        public BangGiaPresenter(IBangGiaView view) : this(view, new BangGiaBLL()) { }

        public BangGiaPresenter(IBangGiaView view, BangGiaBLL bll)
        {
            _view = view;
            _bll = bll;
        }

        public void KhoiDong()
        {
            try { _view.NapLoaiXe(_bll.LayLoaiXe()); }
            catch (Exception ex) { _view.BaoLoi("Không tải được danh sách loại xe: " + ex.Message); }
            Tai();
        }

        public void Tai()
        {
            try { _view.HienThiDanhSach(_bll.LayTatCa()); }
            catch (Exception ex) { _view.BaoLoi("Không tải được bảng giá: " + ex.Message); }
        }

        public void Chon(BangGiaDTO g) { if (g != null) _view.HienThiChiTiet(g); }

        public void Them()
        {
            string loi = _bll.Them(DocTuView());
            if (loi != null) { _view.BaoLoi(loi); return; }
            _view.ThongBao("Thêm bảng giá thành công.");
            _view.XoaNhap();
            Tai();
        }

        public void CapNhat()
        {
            string loi = _bll.CapNhat(DocTuView());
            if (loi != null) { _view.BaoLoi(loi); return; }
            _view.ThongBao("Cập nhật bảng giá thành công. Giá mới chỉ áp dụng cho các lượt tính phí từ bây giờ.");
            Tai();
        }

        public void Xoa()
        {
            if (_view.MaLoaiXe <= 0) { _view.BaoLoi("Hãy chọn một bảng giá trong danh sách để xóa."); return; }
            if (!_view.XacNhan("Xóa bảng giá của loại xe này? Loại xe không có bảng giá sẽ không tính được phí.")) return;
            string loi = _bll.Xoa(_view.MaLoaiXe);
            if (loi != null) { _view.BaoLoi(loi); return; }
            _view.ThongBao("Xóa bảng giá thành công.");
            _view.XoaNhap();
            Tai();
        }

        private BangGiaDTO DocTuView() => new BangGiaDTO
        {
            MaLoaiXe = _view.MaLoaiXe, MienPhiPhut = _view.MienPhiPhut, GiaGioDau = _view.GiaGioDau,
            GiaGioTiepTheo = _view.GiaGioTiepTheo, GiaToiDaNgay = _view.GiaToiDaNgay, GiaVeThang = _view.GiaVeThang
        };
    }
}
