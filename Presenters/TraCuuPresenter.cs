// Điều phối màn hình Tra cứu.
using System;
using System.Collections.Generic;
using System.Linq;
using QuanLyBaiGiuXe.BLL;
using QuanLyBaiGiuXe.Models;
using QuanLyBaiGiuXe.Views;

namespace QuanLyBaiGiuXe.Presenters
{
    public class TraCuuPresenter
    {
        private readonly ITraCuuView _view;
        private readonly TraCuuBLL _bll = new TraCuuBLL();
        private readonly LoaiXeBLL _loaiXeBll = new LoaiXeBLL();

        public TraCuuPresenter(ITraCuuView view) { _view = view; }

        public void KhoiDong()
        {
            try { _view.NapLoaiXe(_loaiXeBll.LayTatCa()); }
            catch (Exception ex) { _view.BaoLoi("Không tải được loại xe: " + ex.Message); }
            Tim();
        }

        public void Tim()
        {
            List<LuotGuiDTO> ds;
            string loi = _bll.Tim(_view.BienSo, _view.MaThe, _view.TuNgay, _view.DenNgay, _view.MaLoaiXe, out ds);
            if (loi != null) { _view.BaoLoi(loi); return; }
            _view.HienThiKetQua(ds);
            _view.HienThiTong(ds.Count, ds.Sum(l => l.Phi));
            _view.HienThiAnh(null);
        }

        public void Chon(LuotGuiDTO l) => _view.HienThiAnh(l.DuongDanAnh);

        public void InBienNhan()
        {
            var l = _view.LuotDangChon;
            if (l == null) { _view.ThongBao("Hãy chọn một dòng trong bảng để in."); return; }
            _view.InBienNhan(_bll.TaoBienNhan(l));
        }
    }
}
