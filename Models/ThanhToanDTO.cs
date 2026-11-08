// Một lần thanh toán khi xe ra.
using System;

namespace QuanLyBaiGiuXe.Models
{
    public class ThanhToanDTO
    {
        public int MaThanhToan { get; set; }
        public int MaLuot { get; set; }
        public decimal SoTien { get; set; }
        public DateTime ThoiDiem { get; set; }
    }
}
