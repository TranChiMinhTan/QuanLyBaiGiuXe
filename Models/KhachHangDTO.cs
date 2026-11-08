// [Người 3] Khách hàng. TenHienThi dùng cho ComboBox chọn khách khi đăng ký vé tháng.
namespace QuanLyBaiGiuXe.Models
{
    public class KhachHangDTO
    {
        public string MaKH { get; set; }
        public string HoTen { get; set; }
        public string SDT { get; set; }
        public string CCCD { get; set; }
        public string DiaChi { get; set; }
        public int SoVeThang { get; set; }
        public string TenHienThi => MaKH + " - " + HoTen;
    }
}