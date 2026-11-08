//  Điều phối màn hình Báo cáo doanh thu và hai tính năng sáng tạo (giờ cao điểm, gợi ý vé tháng).
using System;
using System.Linq;
using QuanLyBaiGiuXe.BLL;
using QuanLyBaiGiuXe.Views;

namespace QuanLyBaiGiuXe.Presenters
{
    public class BaoCaoPresenter
    {
        private readonly IBaoCaoView _view;
        private readonly BaoCaoBLL _bll = new BaoCaoBLL();

        public BaoCaoPresenter(IBaoCaoView view) { _view = view; }

        public void Xem()
        {
            string loi = _bll.KiemTraKhoang(_view.TuNgay, _view.DenNgay);
            if (loi != null) { _view.BaoLoi(loi); return; }
            try
            {
                var ds = _bll.DoanhThu(_view.TuNgay, _view.DenNgay, _view.TheoThang);
                _view.HienThiBang(ds);
                _view.VeBieuDo(ds);
                _view.HienThiTong(ds.Sum(x => x.DoanhThu), _bll.DoanhThuVeThang(_view.TuNgay, _view.DenNgay));
            }
            catch (Exception ex) { _view.BaoLoi("Không lập được báo cáo: " + ex.Message); }
        }

        public void XuatCsv()
        {
            string loi = _bll.KiemTraKhoang(_view.TuNgay, _view.DenNgay);
            if (loi != null) { _view.BaoLoi(loi); return; }
            string duongDan = _view.ChonNoiLuuCsv();
            if (duongDan == null) return;
            try
            {
                var ds = _bll.DoanhThu(_view.TuNgay, _view.DenNgay, _view.TheoThang);
                _bll.XuatCsv(duongDan, ds, _bll.DoanhThuVeThang(_view.TuNgay, _view.DenNgay));
                _view.ThongBao("Đã xuất báo cáo: " + duongDan);
            }
            catch (Exception ex) { _view.BaoLoi("Không xuất được file: " + ex.Message); }
        }

        public void GioCaoDiem()
        {
            string loi = _bll.KiemTraKhoang(_view.TuNgay, _view.DenNgay);
            if (loi != null) { _view.BaoLoi(loi); return; }
            try { _view.HienThiGioCaoDiem(_bll.GioCaoDiem(_view.TuNgay, _view.DenNgay)); }
            catch (Exception ex) { _view.BaoLoi("Không thống kê được: " + ex.Message); }
        }

        public void GoiYVeThang()
        {
            try
            {
                var ds = _bll.GoiYVeThang();
                if (ds.Count == 0) { _view.ThongBao("Hiện chưa có khách nào gửi lẻ đủ nhiều để gợi ý vé tháng."); return; }
                _view.HienThiGoiYVeThang(ds);
            }
            catch (Exception ex) { _view.BaoLoi("Không phân tích được: " + ex.Message); }
        }
    }
}
