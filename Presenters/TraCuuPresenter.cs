//Điều phối màn hình tra cứu: nhận thao tác từ View, gọi BLL, rồi bảo View hiển thị.
using System;
using System.Linq;
using QuanLyBaiXe.BLL;
using QuanLyBaiXe.Models;
using QuanLyBaiXe.Views;

namespace QuanLyBaiXe.Presenters
{
    public class TraCuuPresenter
    {
        private readonly ITraCuuView _view;
        private readonly TraCuuBLL _bll;

        public TraCuuPresenter(ITraCuuView view) : this(view, new TraCuuBLL()) { }

        public TraCuuPresenter(ITraCuuView view, TraCuuBLL bll)
        {
            _view = view;
            _bll = bll;
        }

        /// <summary>Gọi một lần khi UserControl Load.</summary>
        public void KhoiDong()
        {
            try { _view.NapLoaiXe(_bll.LayLoaiXe()); }
            catch (Exception ex) { _view.BaoLoi("Không tải được danh sách loại xe: " + ex.Message); }
            TimKiem();
        }

        public void TimKiem()
        {
            try
            {
                var ds = _bll.TimKiem(_view.BienSo, _view.MaThe, _view.TuNgay, _view.DenNgay, _view.MaLoaiXe);
                _view.HienThiKetQua(ds);
                _view.HienThiTong(ds.Count, ds.Sum(x => x.Phi));
            }
            catch (ArgumentException ex) { _view.BaoLoi(ex.Message); }
            catch (Exception ex) { _view.BaoLoi("Không tra cứu được (kiểm tra kết nối cơ sở dữ liệu): " + ex.Message); }
        }

        /// <summary>View truyền vào lượt đang chọn trong bảng (interface không có thuộc tính "dòng đang chọn").</summary>
        public void InBienNhan(LuotGuiDTO luot)
        {
            if (luot == null)
            {
                _view.ThongBao("Hãy chọn một lượt gửi trong bảng trước khi in.");
                return;
            }
            _view.InBienNhan(_bll.TaoBienNhan(luot));
        }
    }
}