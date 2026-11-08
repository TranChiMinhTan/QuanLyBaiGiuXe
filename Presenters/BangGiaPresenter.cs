// Điều phối màn hình Bảng giá.
using System;
using QuanLyBaiGiuXe.BLL;
using QuanLyBaiGiuXe.Models;
using QuanLyBaiGiuXe.Views;

namespace QuanLyBaiGiuXe.Presenters
{
    public class BangGiaPresenter
    {
        private readonly IBangGiaView _view;
        private readonly BangGiaBLL _bll = new BangGiaBLL();
        private readonly LoaiXeBLL _loaiXeBll = new LoaiXeBLL();

        public BangGiaPresenter(IBangGiaView view) { _view = view; }

        public void KhoiDong()
        {
            try { _view.NapLoaiXe(_loaiXeBll.LayTatCa()); }
            catch (Exception ex) { _view.BaoLoi("Không tải được loại xe: " + ex.Message); }
            Tai();
        }

        public void Tai()
        {
            try { _view.HienThiDanhSach(_bll.LayTatCa()); }
            catch (Exception ex) { _view.BaoLoi("Không tải được dữ liệu: " + ex.Message); }
        }

        public void Chon(BangGiaDTO g) => _view.HienThiChiTiet(g);

        private BangGiaDTO DocForm() => new BangGiaDTO
        {
            MaLoaiXe = _view.MaLoaiXe, MienPhiPhut = _view.MienPhiPhut, GiaKhoi = _view.GiaKhoi,
            SoGioKhoi = _view.SoGioKhoi, PhuThuQuaDem = _view.PhuThuQuaDem, GiaVeThang = _view.GiaVeThang
        };

        public void Them() => ThaoTac(_bll.Them(DocForm()), "Đã thêm bảng giá.");
        public void CapNhat() => ThaoTac(_bll.CapNhat(DocForm()), "Đã cập nhật bảng giá.");

        public void Xoa()
        {
            if (!_view.XacNhan("Xóa bảng giá của loại xe đang chọn?")) return;
            ThaoTac(_bll.Xoa(_view.MaLoaiXe), "Đã xóa bảng giá.");
        }

        private void ThaoTac(string loi, string thanhCong)
        {
            if (loi != null) { _view.BaoLoi(loi); return; }
            _view.ThongBao(thanhCong);
            Tai();
        }
    }
}
