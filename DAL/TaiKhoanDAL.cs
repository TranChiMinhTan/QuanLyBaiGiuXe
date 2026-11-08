using System;
using System.Data;
using QuanLyBaiXe.DTO;

namespace QuanLyBaiXe.DAL
{
    public class TaiKhoanDAL
    {
        public TaiKhoanDTO LayTheoTen(string tenDangNhap)
        {
            DataTable dt = Database.LayBang(
                "SELECT TenDangNhap, MatKhauHash, HoTen, VaiTro, KichHoat " +
                "FROM TaiKhoan WHERE TenDangNhap = @ten",
                Database.Tham("@ten", tenDangNhap));

            if (dt.Rows.Count == 0) return null;

            DataRow r = dt.Rows[0];
            return new TaiKhoanDTO
            {
                TenDangNhap = r["TenDangNhap"].ToString(),
                MatKhauHash = r["MatKhauHash"].ToString(),
                HoTen = r["HoTen"].ToString(),
                VaiTro = r["VaiTro"].ToString(),
                KichHoat = Convert.ToBoolean(r["KichHoat"])
            };
        }

        public int CapNhatMatKhau(string tenDangNhap, string matKhauHashMoi)
        {
            return Database.ThucThi(
                "UPDATE TaiKhoan SET MatKhauHash = @hash WHERE TenDangNhap = @ten",
                Database.Tham("@hash", matKhauHashMoi),
                Database.Tham("@ten", tenDangNhap));
        }
    }
}
