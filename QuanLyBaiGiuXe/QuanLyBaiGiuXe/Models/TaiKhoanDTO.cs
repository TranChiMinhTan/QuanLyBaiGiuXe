// [Người 1 — BẢN NHÁP do Người 2 viết để project biên dịch được. Chủ module có thể sửa tự do.]
namespace QuanLyBaiXe.Models
{
    public class TaiKhoanDTO
    {
        public int Id { get; set; }
        public string TenDangNhap { get; set; }
        public string HoTen { get; set; }
        public string VaiTro { get; set; }         // "NhanVien" hoặc "QuanLy"
        public bool LaQuanLy => VaiTro == "QuanLy";
    }
}
