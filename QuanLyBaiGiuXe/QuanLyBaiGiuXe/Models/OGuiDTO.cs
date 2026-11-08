// [Người 2] Một ô trên sơ đồ bãi = một thẻ xe. Màu ô quyết định từ các thuộc tính này.
using System;

namespace QuanLyBaiXe.Models
{
    public class OGuiDTO
    {
        public string MaThe { get; set; }
        public string TrangThai { get; set; }         // "Đang trống" / "Đang dùng" / "Đã mất"
        public string BienSo { get; set; }            // null nếu ô trống
        public DateTime? GioVao { get; set; }
        public bool CoVeThang { get; set; }

        public bool CoXe => BienSo != null;
        public bool QuaHan24h => GioVao.HasValue && (DateTime.Now - GioVao.Value).TotalHours > 24;
    }
}
