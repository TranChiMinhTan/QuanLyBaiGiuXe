// Tài khoản đang đăng nhập, dùng để ghi nhật ký và phân quyền.
using QuanLyBaiGiuXe.Models;

namespace QuanLyBaiGiuXe.BLL
{
    public static class PhienLamViec
    {
        public static TaiKhoanDTO TaiKhoan { get; set; }
        public static string TenNguoiDung => TaiKhoan != null ? TaiKhoan.TenDangNhap : "he-thong";
    }
}
