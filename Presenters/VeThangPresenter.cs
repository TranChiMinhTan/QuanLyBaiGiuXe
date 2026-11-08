// Điều phối màn Vé tháng. BLL trả null = thành công, ngược lại là câu báo lỗi.
using System;
using QuanLyBaiGiuXe.BLL;
using QuanLyBaiGiuXe.Models;
using QuanLyBaiGiuXe.Views;

namespace QuanLyBaiGiuXe.Presenters
{
    public class VeThangPresenter
    {
        private readonly IVeThangView _view;
        private readonly VeThangBLL _bll;
        private readonly KhachHangBLL _khachBll = new KhachHangBLL();
        private readonly LoaiXeBLL _loaiXeBll = new LoaiXeBLL();

        public VeThangPresenter(IVeThangView view) : this(view, new VeThangBLL()) { }

        public VeThangPresenter(IVeThangView view, VeThangBLL bll)
        {
            _view = view;
            _bll = bll;
        }

        public void KhoiDong()
        {
            try
            {
                _view.NapKhachHang(_khachBll.LayTatCa(null));
                _view.NapLoaiXe(_loaiXeBll.LayTatCa(null));
            }
            catch (Exception ex) { _view.BaoLoi("Không tải được danh sách khách hàng / loại xe: " + ex.Message); }
            Tai();
            CapNhatNgayHetHan();
        }

        public void Tai()
        {
            try { _view.HienThiDanhSach(_bll.LayTatCa(_view.TuKhoaTim)); }
            catch (Exception ex) { _view.BaoLoi("Không tải được danh sách vé tháng: " + ex.Message); }
        }

        /// <summary>Tính lại "Hết hạn: ..." khi người dùng đổi ngày đăng ký hoặc số tháng.</summary>
        public void CapNhatNgayHetHan()
            => _view.HienThiNgayHetHan(_bll.TinhNgayHetHan(_view.NgayDangKy, _view.SoThang));

        public void Chon(VeThangDTO ve)
        {
            if (ve == null) return;
            _view.HienThiChiTiet(ve);
            string canhBao = null;
            if (ve.TinhTrang == "Hết hạn") canhBao = "Vé đã hết hạn " + (-ve.ConLai) + " ngày. Bấm Gia hạn để dùng tiếp.";
            else if (ve.TinhTrang == "Sắp hết hạn") canhBao = "Vé còn " + ve.ConLai + " ngày: nhắc khách gia hạn.";
            _view.HienThiCanhBaoVe(canhBao ?? "");
        }

        public void DangKy()
        {
            string loi = _bll.DangKy(_view.BienSo, _view.MaKH, _view.MaLoaiXe, _view.NgayDangKy, _view.SoThang);
            if (loi != null) { _view.BaoLoi(loi); return; }
            _view.ThongBao("Đăng ký vé tháng thành công.");
            _view.XoaNhap();
            _view.HienThiCanhBaoVe("");
            Tai();
            CapNhatNgayHetHan();
        }

        public void GiaHan()
        {
            string loi = _bll.GiaHan(_view.MaVe, _view.SoThang);
            if (loi != null) { _view.BaoLoi(loi); return; }
            _view.ThongBao("Gia hạn vé tháng thành công.");
            _view.HienThiCanhBaoVe("");
            Tai();
        }

        public void Sua()
        {
            string loi = _bll.Sua(_view.MaVe, _view.BienSo, _view.MaKH);
            if (loi != null) { _view.BaoLoi(loi); return; }
            _view.ThongBao("Cập nhật vé tháng thành công.");
            Tai();
        }

        /// <summary>Nút "Xóa" trên giao diện thực chất là HỦY vé (không xóa bản ghi để giữ lịch sử thanh toán).</summary>
        public void Huy()
        {
            if (_view.MaVe <= 0) { _view.BaoLoi("Hãy chọn một vé trong danh sách để hủy."); return; }
            if (!_view.XacNhan("Hủy vé tháng của biển số " + _view.BienSo + "?")) return;
            string loi = _bll.Huy(_view.MaVe);
            if (loi != null) { _view.BaoLoi(loi); return; }
            _view.ThongBao("Đã hủy vé tháng.");
            _view.XoaNhap();
            _view.HienThiCanhBaoVe("");
            Tai();
        }
    }
}
