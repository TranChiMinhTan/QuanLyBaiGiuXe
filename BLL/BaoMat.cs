// Băm và so khớp mật khẩu. Mật khẩu mới dùng PBKDF2-SHA256 + muối ngẫu nhiên.
// Tài khoản mẫu tạo bằng SQL chưa có muối (Muoi rỗng, MatKhauHash = SHA-256 hex): vẫn đăng nhập được,
// và TaiKhoanBLL tự nâng cấp lên PBKDF2 ngay lần đăng nhập thành công đầu tiên.
// Cần .NET Framework 4.7.2 trở lên (Rfc2898DeriveBytes có tham số HashAlgorithmName) - dự án dùng 4.8.
using System;
using System.Security.Cryptography;
using System.Text;
using QuanLyBaiGiuXe.Models;

namespace QuanLyBaiGiuXe.BLL
{
    public static class BaoMat
    {
        private const int SoVong = 100000;
        private const int DoDaiHash = 32;

        public static string TaoMuoi()
        {
            var b = new byte[16];
            using (var rng = RandomNumberGenerator.Create()) rng.GetBytes(b);
            return Convert.ToBase64String(b);
        }

        public static string Bam(string matKhau, string muoi)
        {
            using (var kdf = new Rfc2898DeriveBytes(matKhau ?? "", Convert.FromBase64String(muoi), SoVong, HashAlgorithmName.SHA256))
                return ToHex(kdf.GetBytes(DoDaiHash));
        }

        /// <summary>SHA-256 không muối, 64 ký tự hex IN HOA (khớp CONVERT(CHAR(64), HASHBYTES('SHA2_256', ...), 2) trong SQL).</summary>
        public static string BamSha256KhongMuoi(string matKhau)
        {
            using (var sha = SHA256.Create())
                return ToHex(sha.ComputeHash(Encoding.UTF8.GetBytes(matKhau ?? "")));
        }

        public static bool CoMuoi(TaiKhoanDTO tk) => tk != null && !string.IsNullOrEmpty(tk.Muoi);

        public static bool KhopMatKhau(string matKhau, TaiKhoanDTO tk)
        {
            if (tk == null || string.IsNullOrEmpty(tk.MatKhauHash)) return false;
            string tinh = CoMuoi(tk) ? Bam(matKhau, tk.Muoi) : BamSha256KhongMuoi(matKhau);
            return SoSanhHangSo(tinh, tk.MatKhauHash.Trim());
        }

        private static bool SoSanhHangSo(string a, string b)
        {
            a = a.ToUpperInvariant(); b = b.ToUpperInvariant();
            int khac = a.Length ^ b.Length;
            for (int i = 0; i < a.Length && i < b.Length; i++) khac |= a[i] ^ b[i];
            return khac == 0;
        }

        private static string ToHex(byte[] bytes)
        {
            var sb = new StringBuilder(bytes.Length * 2);
            foreach (byte x in bytes) sb.Append(x.ToString("X2"));
            return sb.ToString();
        }
    }
}
