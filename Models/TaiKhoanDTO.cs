// [Người 1] Tài khoản đăng nhập. Muoi và MatKhauHash chỉ dùng nội bộ, xóa trắng sau khi đăng nhập xong.
namespace QuanLyBaiGiuXe.Models
{
    public class TaiKhoanDTO
    {
        public int Id { get; set; }
        public string TenDangNhap { get; set; }
        public string HoTen { get; set; }
        public string VaiTro { get; set; }          // "NhanVien" hoặc "QuanLy"
        public bool HoatDong { get; set; }
        public string Muoi { get; set; }
        public string MatKhauHash { get; set; }
        public bool LaQuanLy => VaiTro == "QuanLy";
    }
}