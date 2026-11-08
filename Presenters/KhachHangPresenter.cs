// Điều phối màn hình Khách hàng.
using System;
using QuanLyBaiGiuXe.BLL;
using QuanLyBaiGiuXe.Models;
using QuanLyBaiGiuXe.Views;

namespace QuanLyBaiGiuXe.Presenters
{
    public class KhachHangPresenter
    {
        private readonly IKhachHangView _view;
        private readonly KhachHangBLL _bll = new KhachHangBLL();

        public KhachHangPresenter(IKhachHangView view) { _view = view; }

        public void KhoiDong() { Tai(); NhapMoi(); }

        public void Tai()
        {
            try { _view.HienThiDanhSach(_bll.LayTatCa(_view.TuKhoaTim)); }
            catch (Exception ex) { _view.BaoLoi("Không tải được dữ liệu: " + ex.Message); }
        }

        public void NhapMoi() { _view.XoaNhap(); _view.DatMaKH(_bll.SinhMaMoi()); }

        public void Chon(KhachHangDTO k) => _view.HienThiChiTiet(k);

        private KhachHangDTO DocForm() => new KhachHangDTO
        {
            MaKH = _view.MaKH, HoTen = _view.HoTen, SDT = _view.SDT, CCCD = _view.CCCD, DiaChi = _view.DiaChi
        };

        public void Them() => ThaoTac(_bll.Them(DocForm()), "Đã thêm khách hàng.");
        public void Sua() => ThaoTac(_bll.Sua(DocForm()), "Đã cập nhật khách hàng.");

        public void Xoa()
        {
            if (!_view.XacNhan("Xóa khách hàng " + _view.MaKH + " - " + _view.HoTen + "?")) return;
            ThaoTac(_bll.Xoa(_view.MaKH), "Đã xóa khách hàng.");
        }

        private void ThaoTac(string loi, string thanhCong)
        {
            if (loi != null) { _view.BaoLoi(loi); return; }
            _view.ThongBao(thanhCong);
            NhapMoi();
            Tai();
        }
    }
}
