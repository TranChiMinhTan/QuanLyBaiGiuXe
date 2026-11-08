// Func tính phí: hàm thuần, không đụng DB hay giao diện, nên test rất dễ.
using System;
using QuanLyBaiGiuXe.Models;

namespace QuanLyBaiGiuXe.BLL
{
    public static class TinhPhiBLL
    {
        /// <summary>
        /// Quy tắc: miễn phí N phút đầu; sau đó tính theo khối giờ (làm tròn lên);
        /// cộng phụ thu cho mỗi đêm qua ngày. Mọi số liệu đọc từ bảng giá, không hard-code.
        /// </summary>
        public static readonly Func<LuotGuiDTO, BangGiaDTO, decimal> TinhPhi = (luot, gia) =>
        {
            DateTime ra = luot.GioRa ?? DateTime.Now;
            if (ra < luot.GioVao)
                throw new ArgumentException("Giờ ra không được trước giờ vào.");

            TimeSpan thoiGian = ra - luot.GioVao;
            if (thoiGian.TotalMinutes <= gia.MienPhiPhut) return 0m;

            int soGioKhoi = Math.Max(1, gia.SoGioKhoi);
            int soKhoi = (int)Math.Ceiling(thoiGian.TotalHours / soGioKhoi);
            decimal phi = soKhoi * gia.GiaKhoi;

            int soDem = (ra.Date - luot.GioVao.Date).Days;      // số lần qua nửa đêm
            phi += soDem * gia.PhuThuQuaDem;
            return phi;
        };

        /// <summary>Có vé tháng còn hạn thì miễn phí, ngược lại tính phí thường.</summary>
        public static decimal TinhTien(LuotGuiDTO luot, BangGiaDTO gia, bool coVeThangConHan)
            => coVeThangConHan ? 0m : TinhPhi(luot, gia);
    }
}
