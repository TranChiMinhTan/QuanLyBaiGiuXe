namespace QuanLyBaiXe.DTO
{
    /// <summary>Các giá trị vai trò (khớp cột TaiKhoan.VaiTro).</summary>
    public static class Quyen
    {
        public const string QuanLy = "QuanLy";
        public const string NhanVien = "NhanVien";
    }

    public class TaiKhoanDTO
    {
        public string TenDangNhap { get; set; }
        public string MatKhauHash { get; set; }
        public string HoTen { get; set; }
        public string VaiTro { get; set; }
        public bool KichHoat { get; set; }
    }
}
