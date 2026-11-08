// Điều phối màn Khách hàng. Mã khách hàng tự sinh khi bấm "mới" (NhapMoi).
using System;
using QuanLyBaiGiuXe.BLL;
using QuanLyBaiGiuXe.Models;
using QuanLyBaiGiuXe.Views;

namespace QuanLyBaiGiuXe.Presenters
{
    public class KhachHangPresenter
    {
        private readonly IKhachHangView _view;
        private readonly KhachHangBLL _bll;

        public KhachHangPresenter(IKhachHangView view) : this(view, new KhachHangBLL()) { }

        public KhachHangPresenter(IKhachHangView view, KhachHangBLL bll)
        {
            _view = view;
            _bll = bll;
        }

        public void KhoiDong()
        {
            NhapMoi();
            Tai();
        }

        public void Tai()
        {
            try { _view.HienThiDanhSach(_bll.LayTatCa(_view.TuKhoaTim)); }
            catch (Exception ex) { _view.BaoLoi("Không tải được danh sách khách hàng: " + ex.Message); }
        }

        /// <summary>Xóa ô nhập và hiện mã dự kiến cho khách mới (mã thật được sinh lại lúc lưu).</summary>
        public void NhapMoi()
        {
            _view.XoaNhap();
            try { _view.DatMaKH(_bll.TaoMaMoi()); }
            catch (Exception ex) { _view.BaoLoi("Không tạo được mã khách hàng: " + ex.Message); }
        }

        public void Chon(KhachHangDTO k) { if (k != null) _view.HienThiChiTiet(k); }

        public void Them()
        {
            string loi = _bll.Them(DocTuView());
            if (loi != null) { _view.BaoLoi(loi); return; }
            _view.ThongBao("Thêm khách hàng thành công.");
            NhapMoi();
            Tai();
        }

        public void Sua()
        {
            string loi = _bll.Sua(DocTuView());
            if (loi != null) { _view.BaoLoi(loi); return; }
            _view.ThongBao("Cập nhật khách hàng thành công.");
            Tai();
        }

        public void Xoa()
        {
            if (string.IsNullOrEmpty(_view.MaKH)) { _view.BaoLoi("Hãy chọn một khách hàng trong danh sách để xóa."); return; }
            if (!_view.XacNhan("Xóa khách hàng " + _view.HoTen + "?")) return;
            string loi = _bll.Xoa(_view.MaKH);
            if (loi != null) { _view.BaoLoi(loi); return; }
            _view.ThongBao("Xóa khách hàng thành công.");
            NhapMoi();
            Tai();
        }

        private KhachHangDTO DocTuView() => new KhachHangDTO
        {
            MaKH = _view.MaKH, HoTen = _view.HoTen, SDT = _view.SDT, CCCD = _view.CCCD, DiaChi = _view.DiaChi
        };
    }
}
