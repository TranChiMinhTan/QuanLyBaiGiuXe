// Dữ liệu để in vé (GioRa = null) hoặc biên nhận (có GioRa).
using System;

namespace QuanLyBaiGiuXe.Models
{
    public class BienNhanDTO
    {
        public string MaThe { get; set; }
        public string BienSo { get; set; }
        public string TenLoaiXe { get; set; }
        public DateTime GioVao { get; set; }
        public DateTime? GioRa { get; set; }
        public string ThoiGianGui { get; set; }       // ví dụ "4 giờ 28 phút"
        public decimal Phi { get; set; }
    }
}
