using System.Security.Cryptography;
using System.Text;
using QuanLyBaiXe.DTO;

namespace QuanLyBaiXe.BLL
{
    /// <summary>Thông tin người dùng đang đăng nhập (dùng ở mọi form: PhienDangNhap.NguoiDung).</summary>
    public static class PhienDangNhap
    {
        public static TaiKhoanDTO NguoiDung { get; set; }

        public static bool DangQuanLy
        {
            get { return NguoiDung != null && NguoiDung.VaiTro == Quyen.QuanLy; }
        }

        /// <summary>Tên đăng nhập hiện tại, dùng điền NhanVienVao / NhanVienRa.</summary>
        public static string TenDangNhap
        {
            get { return NguoiDung == null ? null : NguoiDung.TenDangNhap; }
        }
    }

    public static class MatKhauHelper
    {
        /// <summary>Băm SHA-256, trả về 64 ký tự hex in hoa (khớp HASHBYTES('SHA2_256') trong SQL).</summary>
        public static string BamSHA256(string matKhau)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(matKhau ?? ""));
                StringBuilder sb = new StringBuilder(64);
                foreach (byte b in bytes) sb.Append(b.ToString("X2"));
                return sb.ToString();
            }
        }
    }
}
