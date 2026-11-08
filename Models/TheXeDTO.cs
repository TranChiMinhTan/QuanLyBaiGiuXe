// [Người 1] Thẻ xe. BienSoDangGui = biển số xe đang dùng thẻ này (null nếu thẻ trống).
using System;

namespace QuanLyBaiGiuXe.Models
{
    public class TheXeDTO
    {
        public string MaThe { get; set; }
        public int MaLoaiXe { get; set; }
        public string TenLoaiXe { get; set; }
        public string TrangThai { get; set; }       // "Đang trống" / "Đang dùng" / "Đã mất"
        public DateTime NgayCap { get; set; }
        public string BienSoDangGui { get; set; }
    }
}