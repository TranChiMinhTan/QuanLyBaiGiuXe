// [Người 2] Một lượt gửi xe: từ lúc xe vào đến lúc xe ra.
using System;

namespace QuanLyBaiGiuXe.Models
{
    public class LuotGuiDTO
    {
        public int MaLuot { get; set; }
        public string BienSo { get; set; }
        public string MaThe { get; set; }
        public int MaLoaiXe { get; set; }
        public string TenLoaiXe { get; set; }
        public DateTime GioVao { get; set; }
        public DateTime? GioRa { get; set; }          // null = xe còn trong bãi
        public decimal Phi { get; set; }
        public string DuongDanAnh { get; set; }       // đường dẫn TƯƠNG ĐỐI, ví dụ Images\BienSo\abc.jpg

        public bool DangGui => GioRa == null;
        public TimeSpan ThoiGianGui => (GioRa ?? DateTime.Now) - GioVao;
    }
}
