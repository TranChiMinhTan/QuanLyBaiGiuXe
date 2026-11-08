// Bảng NhatKy: ghi và đọc nhật ký thao tác. Chỉ có SQL tham số hóa.
using System.Collections.Generic;
using System.Data.SqlClient;
using QuanLyBaiGiuXe.Models;
using static QuanLyBaiGiuXe.DAL.Database;

namespace QuanLyBaiGiuXe.DAL
{
    public class NhatKyDAL
    {
        private static NhatKyDTO Map(SqlDataReader r) => new NhatKyDTO
        {
            MaNhatKy = r.Gt<int>("MaNhatKy"),
            ThoiDiem = r.Gt<System.DateTime>("ThoiDiem"),
            TenDangNhap = r.Gt<string>("TenDangNhap"),
            HanhDong = r.Gt<string>("HanhDong"),
            ChiTiet = r.Gt<string>("ChiTiet")
        };

        public void Ghi(string tenDangNhap, string hanhDong, string chiTiet)
            => ThucThi("INSERT INTO NhatKy(TenDangNhap, HanhDong, ChiTiet) VALUES(@u, @h, @c)",
                       P("@u", tenDangNhap), P("@h", hanhDong), P("@c", chiTiet));

        /// <summary>Tối đa <paramref name="soDong"/> dòng mới nhất, lọc theo người dùng / hành động / chi tiết.</summary>
        public List<NhatKyDTO> LayGanNhat(string tuKhoa, int soDong)
        {
            string k = string.IsNullOrWhiteSpace(tuKhoa) ? null : tuKhoa.Trim();
            return Doc<NhatKyDTO>(
                "SELECT TOP (@n) MaNhatKy, ThoiDiem, TenDangNhap, HanhDong, ChiTiet FROM NhatKy " +
                "WHERE (@k IS NULL OR TenDangNhap LIKE N'%' + @k + N'%' OR HanhDong LIKE N'%' + @k + N'%' " +
                "OR ChiTiet LIKE N'%' + @k + N'%') ORDER BY ThoiDiem DESC, MaNhatKy DESC",
                Map, P("@n", soDong), P("@k", k));
        }
    }
}
