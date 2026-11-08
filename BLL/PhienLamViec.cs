// Phiên làm việc hiện tại: ai đang đăng nhập. Program gán sau khi đăng nhập, xóa khi đăng xuất.
using QuanLyBaiGiuXe.Models;

namespace QuanLyBaiGiuXe.BLL
{
    public static class PhienLamViec
    {
        public static TaiKhoanDTO TaiKhoan { get; set; }

        public static bool DaDangNhap => TaiKhoan != null;
        public static bool LaQuanLy => TaiKhoan != null && TaiKhoan.LaQuanLy;
        public static string TenDangNhap => TaiKhoan == null ? null : TaiKhoan.TenDangNhap;
    }
}
