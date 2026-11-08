// Tra cứu lịch sử lượt gửi: mọi điều kiện lọc đều là tham số (không nối chuỗi, chống SQL injection).
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using QuanLyBaiGiuXe.Models;
using static QuanLyBaiGiuXe.DAL.Database;

namespace QuanLyBaiGiuXe.DAL
{
    public class TraCuuDAL
    {
        public List<LuotGuiDTO> Tim(string bienSo, string maThe, DateTime tu, DateTime den, int? maLoaiXe)
            => Doc<LuotGuiDTO>(
                "SELECT TOP 1000 l.MaLuot, l.BienSo, l.MaThe, l.MaLoaiXe, lx.TenLoai, l.GioVao, l.GioRa, l.Phi, l.DuongDanAnh " +
                "FROM LuotGui l JOIN LoaiXe lx ON lx.MaLoaiXe = l.MaLoaiXe " +
                "WHERE (@bs IS NULL OR l.BienSo LIKE N'%' + @bs + N'%') AND (@the IS NULL OR l.MaThe = @the) " +
                "AND CAST(l.GioVao AS DATE) BETWEEN @tu AND @den AND (@lx IS NULL OR l.MaLoaiXe = @lx) " +
                "ORDER BY l.GioVao DESC",
                Map,
                P("@bs", bienSo), P("@the", maThe), P("@tu", tu.Date), P("@den", den.Date), P("@lx", maLoaiXe));

        private static LuotGuiDTO Map(SqlDataReader r) => new LuotGuiDTO
        {
            MaLuot = r.Gt<int>("MaLuot"), BienSo = r.Gt<string>("BienSo"), MaThe = r.Gt<string>("MaThe"),
            MaLoaiXe = r.Gt<int>("MaLoaiXe"), TenLoaiXe = r.Gt<string>("TenLoai"),
            GioVao = r.Gt<DateTime>("GioVao"), GioRa = r.Gt<DateTime?>("GioRa"),
            Phi = r.Gt<decimal>("Phi"), DuongDanAnh = r.Gt<string>("DuongDanAnh")
        };
    }
}
