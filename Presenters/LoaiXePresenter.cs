// Điều phối màn hình Loại xe.
using System;
using QuanLyBaiGiuXe.BLL;
using QuanLyBaiGiuXe.Models;
using QuanLyBaiGiuXe.Views;

namespace QuanLyBaiGiuXe.Presenters
{
    public class LoaiXePresenter
    {
        private readonly ILoaiXeView _view;
        private readonly LoaiXeBLL _bll = new LoaiXeBLL();

        public LoaiXePresenter(ILoaiXeView view) { _view = view; }

        public void Tai()
        {
            try { _view.HienThiDanhSach(_bll.LayTatCa(_view.TuKhoaTim)); }
            catch (Exception ex) { _view.BaoLoi("Không tải được dữ liệu: " + ex.Message); }
        }

        public void Chon(LoaiXeDTO x) => _view.HienThiChiTiet(x);

        private LoaiXeDTO DocForm() => new LoaiXeDTO
        {
            MaLoaiXe = _view.MaLoaiXe, TenLoai = _view.TenLoai, SucChua = _view.SucChua, MoTa = _view.MoTa
        };

        public void Them() => ThaoTac(_bll.Them(DocForm()), "Đã thêm loại xe.");
        public void Sua() => ThaoTac(_bll.Sua(DocForm()), "Đã cập nhật loại xe.");

        public void Xoa()
        {
            if (_view.MaLoaiXe <= 0) { _view.BaoLoi("Hãy chọn một loại xe trong danh sách để xóa."); return; }
            if (!_view.XacNhan("Xóa loại xe \"" + _view.TenLoai + "\"?")) return;
            ThaoTac(_bll.Xoa(_view.MaLoaiXe, _view.TenLoai), "Đã xóa loại xe.");
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
