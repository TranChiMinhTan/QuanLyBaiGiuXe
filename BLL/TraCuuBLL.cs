// Nghiệp vụ tra cứu và tạo biên nhận từ một lượt gửi.
using System;
using System.Collections.Generic;
using QuanLyBaiGiuXe.DAL;
using QuanLyBaiGiuXe.Models;

namespace QuanLyBaiGiuXe.BLL
{
    public class TraCuuBLL
    {
        private readonly TraCuuDAL _dal = new TraCuuDAL();

        /// <summary>Trả về chuỗi lỗi hoặc null; danh sách kết quả nằm trong ds.</summary>
        public string Tim(string bienSo, string maThe, DateTime tu, DateTime den, int? maLoaiXe, out List<LuotGuiDTO> ds)
        {
            ds = new List<LuotGuiDTO>();
            if (tu.Date > den.Date) return "\"Từ ngày\" phải nhỏ hơn hoặc bằng \"Đến ngày\".";
            if ((den.Date - tu.Date).TotalDays > 366) return "Chỉ tra cứu tối đa trong 1 năm mỗi lần.";
            string bs = string.IsNullOrWhiteSpace(bienSo) ? null : bienSo.Trim().ToUpper();
            string the = string.IsNullOrWhiteSpace(maThe) ? null : maThe.Trim().ToUpper();
            try { ds = _dal.Tim(bs, the, tu, den, maLoaiXe); return null; }
            catch (Exception ex) { return "Không tra cứu được: " + Database.DichLoi(ex); }
        }

        public BienNhanDTO TaoBienNhan(LuotGuiDTO l)
        {
            var tg = l.ThoiGianGui;
            return new BienNhanDTO
            {
                MaThe = l.MaThe, BienSo = l.BienSo, TenLoaiXe = l.TenLoaiXe, GioVao = l.GioVao, GioRa = l.GioRa,
                Phi = l.Phi, ThoiGianGui = (int)tg.TotalHours + " giờ " + tg.Minutes + " phút"
            };
        }
    }
}
