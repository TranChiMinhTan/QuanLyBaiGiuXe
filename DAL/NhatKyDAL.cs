// [SÁNG TẠO #6] Bảng NhatKy.
using System.Collections.Generic;
using System.Data.SqlClient;
using QuanLyBaiGiuXe.Models;
using static QuanLyBaiGiuXe.DAL.Database;

namespace QuanLyBaiGiuXe.DAL
{
    public class NhatKyDAL
    {
        public void Ghi(string tenDangNhap, string hanhDong, string chiTiet)
            => ThucThi("INSERT INTO NhatKy(TenDangNhap, HanhDong, ChiTiet) VALUES(@u, @h, @c)",
                       P("@u", tenDangNhap), P("@h", hanhDong), P("@c", chiTiet));

        public List<NhatKyDTO> LayGanDay(string tuKhoa)
        {
            string k = string.IsNullOrWhiteSpace(tuKhoa) ? null : tuKhoa.Trim();
            return Doc<NhatKyDTO>(
                "SELECT TOP 500 MaNK, ThoiDiem, TenDangNhap, HanhDong, ChiTiet FROM NhatKy " +
                "WHERE (@k IS NULL OR TenDangNhap LIKE N'%' + @k + N'%' OR HanhDong LIKE N'%' + @k + N'%' OR ChiTiet LIKE N'%' + @k + N'%') " +
                "ORDER BY MaNK DESC",
                r => new NhatKyDTO
                {
                    MaNK = r.Gt<int>("MaNK"), ThoiDiem = r.Gt<System.DateTime>("ThoiDiem"),
                    TenDangNhap = r.Gt<string>("TenDangNhap"), HanhDong = r.Gt<string>("HanhDong"),
                    ChiTiet = r.Gt<string>("ChiTiet")
                },
                P("@k", k));
        }
    }
}
