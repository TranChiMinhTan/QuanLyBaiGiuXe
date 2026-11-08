//Điều phối màn hình tra cứu: nhận thao tác từ View, gọi BLL, rồi bảo View hiển thị.
using System;
using System.Linq;
using QuanLyBaiGiuXe.BLL;
using QuanLyBaiGiuXe.Models;
using QuanLyBaiGiuXe.Views;

namespace QuanLyBaiGiuXe.Presenters
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
            Tim();
        }

        public void Tim()
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

        /// <summary>Chọn một dòng trong lưới: hiện lại ảnh biển số của lượt đó (nếu có).</summary>
        public void Chon(LuotGuiDTO luot)
        {
            if (luot == null) return;
            _view.HienThiAnh(luot.DuongDanAnh);
        }

        /// <summary>In vé (xe còn trong bãi) hoặc biên nhận (xe đã ra) của lượt đang chọn trong lưới.</summary>
        public void InBienNhan()
        {
            var luot = _view.LuotDangChon;
            if (luot == null)
            {
                _view.ThongBao("Hãy chọn một lượt gửi trong bảng trước khi in.");
                return;
            }
            _view.InBienNhan(_bll.TaoBienNhan(luot));
        }
    }
}