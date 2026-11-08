//Điều phối màn hình báo cáo doanh thu: xem bảng + biểu đồ + tổng, xuất CSV.
using System;
using System.IO;
using QuanLyBaiGiuXe.BLL;
using QuanLyBaiGiuXe.Models;
using QuanLyBaiGiuXe.Views;

namespace QuanLyBaiGiuXe.Presenters
{
    public class BaoCaoPresenter
    {
        private readonly IBaoCaoView _view;
        private readonly BaoCaoBLL _bll;
        private BaoCaoDoanhThuDTO _hienTai;       // báo cáo đang hiển thị, dùng cho xuất CSV
        private bool _hienTaiTheoThang;

        public BaoCaoPresenter(IBaoCaoView view) : this(view, new BaoCaoBLL()) { }

        public BaoCaoPresenter(IBaoCaoView view, BaoCaoBLL bll)
        {
            _view = view;
            _bll = bll;
        }

        /// <summary>Gọi một lần khi UserControl Load.</summary>
        public void KhoiDong()
        {
            Xem();
        }

        public void Xem()
        {
            try
            {
                bool theoThang = _view.TheoThang;
                BaoCaoDoanhThuDTO kq = _bll.LayBaoCao(_view.TuNgay, _view.DenNgay, theoThang);

                _hienTai = kq;
                _hienTaiTheoThang = theoThang;

                _view.HienThiBang(kq.Dong);
                _view.VeBieuDo(kq.Dong);
                _view.HienThiTong(kq.TongLuotGui, kq.TongVeThang);
            }
            catch (ArgumentException ex) { _view.BaoLoi(ex.Message); }
            catch (Exception ex)
            {
                _view.BaoLoi("Không lấy được dữ liệu doanh thu (kiểm tra kết nối và stored procedure " +
                             "sp_BaoCaoDoanhThu): " + ex.Message);
            }
        }

        public void XuatCsv()
        {
            if (_hienTai == null || _hienTai.Dong.Count == 0)
            {
                _view.ThongBao("Chưa có dữ liệu để xuất. Hãy bấm Xem trước.");
                return;
            }

            string duongDan = _view.ChonNoiLuuCsv();
            if (duongDan == null) return;               // người dùng hủy

            try
            {
                _bll.XuatCsv(_hienTai, duongDan, _hienTaiTheoThang);
                _view.ThongBao("Đã xuất file:\n" + duongDan);
            }
            catch (IOException ex)
            {
                _view.BaoLoi("Không ghi được file (file có đang mở trong Excel không?): " + ex.Message);
            }
            catch (UnauthorizedAccessException)
            {
                _view.BaoLoi("Không có quyền ghi vào vị trí này. Hãy chọn thư mục khác.");
            }
            catch (Exception ex)
            {
                _view.BaoLoi("Không xuất được file: " + ex.Message);
            }
        }

        /// <summary>[SÁNG TẠO #8] Thống kê giờ cao điểm theo khoảng ngày đang chọn.</summary>
        public void GioCaoDiem()
        {
            try { _view.HienThiGioCaoDiem(_bll.LayGioCaoDiem(_view.TuNgay, _view.DenNgay)); }
            catch (ArgumentException ex) { _view.BaoLoi(ex.Message); }
            catch (Exception ex) { _view.BaoLoi("Không lấy được thống kê giờ cao điểm: " + ex.Message); }
        }

        /// <summary>[SÁNG TẠO #7] Biển số gửi lẻ nhiều, nên mời đăng ký vé tháng.</summary>
        public void GoiYVeThang()
        {
            try
            {
                var ds = _bll.LayGoiYVeThang();
                if (ds.Count == 0)
                {
                    _view.ThongBao("Hiện chưa có biển số nào đủ điều kiện gợi ý đăng ký vé tháng.");
                    return;
                }
                _view.HienThiGoiYVeThang(ds);
            }
            catch (Exception ex) { _view.BaoLoi("Không lấy được gợi ý vé tháng: " + ex.Message); }
        }
    }
}