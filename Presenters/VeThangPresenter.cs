// Điều phối màn hình Vé tháng.
using System;
using System.Collections.Generic;
using System.Linq;
using QuanLyBaiGiuXe.BLL;
using QuanLyBaiGiuXe.Models;
using QuanLyBaiGiuXe.Views;

namespace QuanLyBaiGiuXe.Presenters
{
    public class VeThangPresenter
    {
        private readonly IVeThangView _view;
        private readonly VeThangBLL _bll = new VeThangBLL();
        private readonly KhachHangBLL _khBll = new KhachHangBLL();
        private readonly LoaiXeBLL _loaiXeBll = new LoaiXeBLL();

        public VeThangPresenter(IVeThangView view) { _view = view; }

        public void KhoiDong()
        {
            try
            {
                _view.NapKhachHang(_khBll.LayTatCa(null));
                _view.NapLoaiXe(_loaiXeBll.LayTatCa());
            }
            catch (Exception ex) { _view.BaoLoi("Không tải được danh mục: " + ex.Message); }
            CapNhatNgayHetHan();
            Tai();
        }

        public void Tai()
        {
            try
            {
                List<VeThangDTO> ds = _bll.LayTatCa(_view.TuKhoaTim);
                _view.HienThiDanhSach(ds);

                // [SÁNG TẠO #1] Dải cảnh báo vé sắp hết hạn / đã hết hạn
                int sap = ds.Count(v => v.TinhTrang == "Sắp hết hạn");
                int het = ds.Count(v => v.TinhTrang == "Hết hạn");
                var phan = new List<string>();
                if (sap > 0) phan.Add(sap + " vé sắp hết hạn trong 7 ngày");
                if (het > 0) phan.Add(het + " vé đã hết hạn");
                _view.HienThiCanhBaoVe(string.Join(" · ", phan));
            }
            catch (Exception ex) { _view.BaoLoi("Không tải được dữ liệu: " + ex.Message); }
        }

        public void CapNhatNgayHetHan() => _view.HienThiNgayHetHan(_bll.TinhNgayHetHan(_view.NgayDangKy, _view.SoThang));
        public void Chon(VeThangDTO ve) => _view.HienThiChiTiet(ve);

        public void DangKy() => ThaoTac(_bll.DangKy(_view.BienSo, _view.MaKH, _view.MaLoaiXe, _view.NgayDangKy, _view.SoThang),
                                        "Đã đăng ký vé tháng.");
        public void GiaHan() => ThaoTac(_bll.GiaHan(_view.MaVe, _view.SoThang), "Đã gia hạn vé tháng.");
        public void Sua() => ThaoTac(_bll.Sua(_view.MaVe, _view.BienSo, _view.MaKH), "Đã cập nhật vé tháng.");

        public void Huy()
        {
            if (_view.MaVe <= 0) { _view.BaoLoi("Hãy chọn một vé trong danh sách để hủy."); return; }
            if (!_view.XacNhan("Hủy vé tháng của biển số " + _view.BienSo + "?")) return;
            ThaoTac(_bll.Huy(_view.MaVe), "Đã hủy vé tháng.");
        }

        private void ThaoTac(string loi, string thanhCong)
        {
            if (loi != null) { _view.BaoLoi(loi); return; }
            _view.ThongBao(thanhCong);
            _view.XoaNhap();
            CapNhatNgayHetHan();
            Tai();
        }
    }
}
