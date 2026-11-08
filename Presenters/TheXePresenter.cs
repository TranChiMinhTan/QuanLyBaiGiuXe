//  Điều phối màn hình Thẻ xe.
using System;
using QuanLyBaiGiuXe.BLL;
using QuanLyBaiGiuXe.Models;
using QuanLyBaiGiuXe.Views;

namespace QuanLyBaiGiuXe.Presenters
{
    public class TheXePresenter
    {
        private readonly ITheXeView _view;
        private readonly TheXeBLL _bll = new TheXeBLL();
        private readonly LoaiXeBLL _loaiXeBll = new LoaiXeBLL();

        public TheXePresenter(ITheXeView view) { _view = view; }

        public void KhoiDong()
        {
            try { _view.NapLoaiXe(_loaiXeBll.LayTatCa()); }
            catch (Exception ex) { _view.BaoLoi("Không tải được loại xe: " + ex.Message); }
            Tai();
        }

        public void Tai()
        {
            try { _view.HienThiDanhSach(_bll.LayTatCa(_view.TuKhoaTim)); }
            catch (Exception ex) { _view.BaoLoi("Không tải được dữ liệu: " + ex.Message); }
        }

        public void Chon(TheXeDTO t) => _view.HienThiChiTiet(t);

        private TheXeDTO DocForm() => new TheXeDTO
        {
            MaThe = _view.MaThe, MaLoaiXe = _view.MaLoaiXe, TrangThai = _view.TrangThai, NgayCap = _view.NgayCap
        };

        public void Them() => ThaoTac(_bll.Them(DocForm()), "Đã thêm thẻ xe.");
        public void Sua() => ThaoTac(_bll.Sua(DocForm()), "Đã cập nhật thẻ xe.");

        public void Xoa()
        {
            if (string.IsNullOrWhiteSpace(_view.MaThe)) { _view.BaoLoi("Hãy chọn một thẻ trong danh sách để xóa."); return; }
            if (!_view.XacNhan("Xóa thẻ " + _view.MaThe + "?")) return;
            ThaoTac(_bll.Xoa(_view.MaThe.Trim().ToUpper()), "Đã xóa thẻ xe.");
        }

        private void ThaoTac(string loi, string thanhCong)
        {
            if (loi != null) { _view.BaoLoi(loi); return; }
            _view.ThongBao(thanhCong);
            _view.XoaNhap();
            Tai();
        }
    }
}
