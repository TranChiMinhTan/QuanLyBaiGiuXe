// Hằng số dùng chung để mọi tầng so sánh trạng thái bằng cùng một giá trị (khớp ràng buộc CHECK trong CSDL).
namespace QuanLyBaiGiuXe.Models
{
    /// <summary>
    /// Trạng thái thẻ xe. "Khóa" (vô hiệu hóa) và "Đã mất" (thất lạc) là hai trạng thái KHÁC NHAU, giữ riêng.
    /// Cả hai đều không cho xe vào. "Đang dùng" chỉ do hệ thống đặt khi xe vào, trả về "Đang trống" khi xe ra.
    /// </summary>
    public static class TrangThaiThe
    {
        public const string DangTrong = "Đang trống";
        public const string DangDung = "Đang dùng";
        public const string Khoa = "Khóa";
        public const string DaMat = "Đã mất";

        public static readonly string[] TatCa = { DangTrong, DangDung, Khoa, DaMat };
        /// <summary>Các trạng thái người dùng được chọn thủ công (không gồm "Đang dùng").</summary>
        public static readonly string[] DatThuCong = { DangTrong, Khoa, DaMat };

        public static bool HopLe(string s) => System.Array.IndexOf(TatCa, s) >= 0;
    }

    public static class TrangThaiVeThang
    {
        public const string HoatDong = "Hoạt động";
        public const string DaHuy = "Đã hủy";
    }

    public static class VaiTro
    {
        public const string QuanLy = "QuanLy";
        public const string NhanVien = "NhanVien";
    }
}
