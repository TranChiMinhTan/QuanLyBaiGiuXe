// [Người 2] Điều phối: nhận thao tác từ View, gọi BLL, rồi bảo View hiển thị. Không biết control nào cả.
using System;
using System.Collections.Generic;
using System.Linq;
using QuanLyBaiGiuXe.BLL;
using QuanLyBaiGiuXe.Models;
using QuanLyBaiGiuXe.Views;

namespace QuanLyBaiGiuXe.Presenters
{
    public class VanHanhPresenter
    {
        private readonly IVanHanhView _view;
        private readonly LuotGuiBLL _bll;
        private List<OGuiDTO> _dsO = new List<OGuiDTO>();

        public VanHanhPresenter(IVanHanhView view) : this(view, new LuotGuiBLL()) { }

        public VanHanhPresenter(IVanHanhView view, LuotGuiBLL bll)
        {
            _view = view;
            _bll = bll;
        }

        /// <summary>Gọi một lần khi UserControl Load.</summary>
        public void KhoiDong()
        {
            try { _view.NapLoaiXe(_bll.LayLoaiXe()); }
            catch (Exception ex) { _view.BaoLoi("Không tải được danh sách loại xe: " + ex.Message); }
            LamMoi();
        }

        /// <summary>Nạp lại bảng lượt gửi, sơ đồ bãi, số chỗ trống.</summary>
        public void LamMoi()
        {
            try
            {
                _view.HienThiLuotGui(_bll.LayLuotHienThi());
                _dsO = _bll.LayOGui();
                _view.HienThiSoDo(_dsO);
                _view.HienThiConTrong(_dsO.Count(o => o.TrangThai == "Đang trống"), _dsO.Count);
                _view.HienThiXeTrongBai(_dsO.Count(o => o.CoXe));
            }
            catch (Exception ex) { _view.BaoLoi("Không tải được dữ liệu: " + ex.Message); }
        }

        public void XeVao()
        {
            _view.HienThiCanhBao("");
            var kq = _bll.XeVao(_view.BienSo, _view.MaThe, _view.MaLoaiXe, _view.DuongDanAnh);
            if (!kq.ThanhCong) { _view.BaoLoi(kq.ThongBao); return; }

            _view.XoaNhap();
            LamMoi();
            if (!string.IsNullOrEmpty(kq.CanhBao))
            {
                _view.HienThiCanhBao(kq.CanhBao);       // cảnh báo vé tháng sắp hết hạn
                _view.ThongBao(kq.CanhBao);
            }
            if (_view.XacNhan("Ghi nhận xe vào thành công. In vé?"))
                _view.InBienNhan(kq.BienNhan);
        }

        /// <summary>Master-detail bước 1: hiện thông tin lượt gửi và phí tạm tính, chưa ghi gì.</summary>
        public void XemPhiXeRa()
        {
            var kq = _bll.XemPhiXeRa(_view.MaThe);
            if (!kq.ThanhCong) { _view.BaoLoi(kq.ThongBao); return; }
            _view.HienThiXeRa(kq.Luot, kq.Luot.Phi, kq.CanhBao);
        }

        /// <summary>Master-detail bước 2: xác nhận rồi thanh toán trong transaction.</summary>
        public void ThanhToan()
        {
            var xem = _bll.XemPhiXeRa(_view.MaThe);
            if (!xem.ThanhCong) { _view.BaoLoi(xem.ThongBao); return; }
            _view.HienThiXeRa(xem.Luot, xem.Luot.Phi, xem.CanhBao);

            if (!_view.XacNhan("Phí " + xem.Luot.Phi.ToString("N0") + " đ. Xác nhận thanh toán và cho xe ra?"))
                return;

            var kq = _bll.ThanhToan(_view.MaThe, _view.GiaLapLoi);
            if (!kq.ThanhCong)
            {
                _view.BaoLoi(kq.ThongBao + "\n\nDữ liệu đã được hoàn tác: lượt gửi chưa đóng, thẻ vẫn \"Đang dùng\".");
                LamMoi();
                return;
            }

            _view.XoaNhap();
            _view.HienThiPhi(kq.Luot.Phi);
            LamMoi();
            if (_view.XacNhan("Thanh toán thành công. In biên nhận?"))
                _view.InBienNhan(kq.BienNhan);
        }

        public void InVe()
        {
            var kq = _bll.TaoVeVao(_view.MaThe);
            if (!kq.ThanhCong) { _view.BaoLoi(kq.ThongBao); return; }
            _view.InBienNhan(kq.BienNhan);
        }

        /// <summary>Bấm vào một ô trên sơ đồ.</summary>
        public void ChonO(string maThe)
        {
            var o = _dsO.FirstOrDefault(x => x.MaThe == maThe);
            if (o == null) return;
            _view.HienThiThongTinO(o);
            if (o.CoXe) _view.DatMaThe(o.MaThe);        // điền sẵn mã thẻ để bấm Xe ra cho nhanh
        }
    }
}
