// [Người 2] Hàm tính phí: hàm thuần, không đụng DB hay giao diện nên kiểm thử rất dễ.
// Mô hình B+ (chi tiết và bảng ví dụ: docs/MO_HINH_TINH_PHI.md).
using System;
using QuanLyBaiGiuXe.Models;

namespace QuanLyBaiGiuXe.BLL
{
    public static class TinhPhiBLL
    {
        /// <summary>
        /// Quy tắc:
        ///  1. Gửi không quá MienPhiPhut phút: miễn phí.
        ///  2. Cứ trọn 24 giờ tính GiaToiDaNgay.
        ///  3. Phần lẻ còn lại (làm tròn LÊN theo giờ): GiaGioDau + (số giờ - 1) x GiaGioTiepTheo, nhưng không quá GiaToiDaNgay.
        /// Mọi số liệu đọc từ bảng giá, không hard-code. Không còn phụ thu qua đêm (đã gộp vào trần mỗi 24 giờ).
        /// </summary>
        public static readonly Func<LuotGuiDTO, BangGiaDTO, decimal> TinhPhi = (luot, gia) =>
        {
            DateTime ra = luot.GioRa ?? DateTime.Now;
            if (ra < luot.GioVao)
                throw new ArgumentException("Giờ ra không được trước giờ vào.");

            TimeSpan tg = ra - luot.GioVao;
            if (tg.TotalMinutes <= gia.MienPhiPhut) return 0m;

            long soNgayTron = tg.Ticks / TimeSpan.TicksPerDay;           // số khối 24 giờ trọn vẹn
            long du = tg.Ticks - soNgayTron * TimeSpan.TicksPerDay;      // phần lẻ còn lại

            decimal phi = soNgayTron * gia.GiaToiDaNgay;
            if (du > 0)
            {
                long soGio = (du + TimeSpan.TicksPerHour - 1) / TimeSpan.TicksPerHour;   // làm tròn lên, tối thiểu 1
                decimal phiLe = gia.GiaGioDau + (soGio - 1) * gia.GiaGioTiepTheo;
                phi += Math.Min(phiLe, gia.GiaToiDaNgay);
            }
            return phi;
        };

        /// <summary>Có vé tháng còn hạn thì miễn phí, ngược lại tính phí thường.</summary>
        public static decimal TinhTien(LuotGuiDTO luot, BangGiaDTO gia, bool coVeThangConHan)
            => coVeThangConHan ? 0m : TinhPhi(luot, gia);
    }
}
