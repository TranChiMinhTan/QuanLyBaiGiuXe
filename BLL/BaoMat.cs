// [SÁNG TẠO #10] Mật khẩu không lưu nguyên văn: lưu muối + SHA-256(muối + mật khẩu).
using System;
using System.Security.Cryptography;
using System.Text;

namespace QuanLyBaiGiuXe.BLL
{
    public static class BaoMat
    {
        public static string TaoMuoi() => Guid.NewGuid().ToString("N").Substring(0, 8);

        public static string Bam(string muoi, string matKhau)
        {
            using (var sha = SHA256.Create())
            {
                byte[] b = sha.ComputeHash(Encoding.UTF8.GetBytes(muoi + matKhau));
                return BitConverter.ToString(b).Replace("-", "");
            }
        }
    }
}
