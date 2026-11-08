//Nghiệp vụ tra cứu. BLL không hiện MessageBox: lỗi nhập liệu ném ArgumentException cho Presenter xử lý.
using System;
using System.Collections.Generic;
using QuanLyBaiXe.DAL;
using QuanLyBaiXe.Models;

namespace QuanLyBaiXe.BLL
{
    public class TraCuuBLL
    {
        private readonly TraCuuDAL _dal = new TraCuuDAL();
        private readonly LoaiXeDAL _loaiXeDal = new LoaiXeDAL();

        public List<LoaiXeDTO> LayLoaiXe()
        {
            return _loaiXeDal.LayTatCa();
        }

        public List<LuotGuiDTO> TimKiem(string bienSo, string maThe, DateTime tuNgay, DateTime denNgay, int? maLoaiXe)
        {
            if (tuNgay.Date > denNgay.Date)
                throw new ArgumentException("Từ ngày không được lớn hơn Đến ngày.");

            return _dal.TimKiem(ChuanHoa(bienSo), ChuanHoa(maThe), tuNgay, denNgay, maLoaiXe);
        }

        /// <summary>Đổi một lượt gửi thành dữ liệu để in: xe chưa ra thì in vé (GioRa = null), xe đã ra thì in biên nhận.</summary>
        public BienNhanDTO TaoBienNhan(LuotGuiDTO l)
        {
            if (l == null) throw new ArgumentNullException("l");

            TimeSpan tg = l.ThoiGianGui;
            if (tg < TimeSpan.Zero) tg = TimeSpan.Zero;

            return new BienNhanDTO
            {
                MaThe = l.MaThe,
                BienSo = l.BienSo,
                TenLoaiXe = l.TenLoaiXe,
                GioVao = l.GioVao,
                GioRa = l.GioRa,
                ThoiGianGui = (int)tg.TotalHours + " giờ " + tg.Minutes + " phút",   // cùng định dạng với LuotGuiBLL
                Phi = l.Phi
            };
        }

        private static string ChuanHoa(string s)
        {
            s = (s ?? "").Trim();
            return s.Length == 0 ? null : s;
        }
    }
}