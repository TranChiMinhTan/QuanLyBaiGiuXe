// [Người 1] Bảng TheXe. LayTheoMa được Người 2 gọi khi xe vào.
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using QuanLyBaiGiuXe.Models;
using static QuanLyBaiGiuXe.DAL.Database;

namespace QuanLyBaiGiuXe.DAL
{
    public class TheXeDAL
    {
        private const string Chon =
            "SELECT t.MaThe, t.MaLoaiXe, lx.TenLoai, t.TrangThai, t.NgayCap, " +
            "  (SELECT TOP 1 l.BienSo FROM LuotGui l WHERE l.MaThe = t.MaThe AND l.GioRa IS NULL) AS BienSoDangGui " +
            "FROM TheXe t JOIN LoaiXe lx ON lx.MaLoaiXe = t.MaLoaiXe ";

        private static TheXeDTO Map(SqlDataReader r) => new TheXeDTO
        {
            MaThe = r.Gt<string>("MaThe"),
            MaLoaiXe = r.Gt<int>("MaLoaiXe"),
            TenLoaiXe = r.Gt<string>("TenLoai"),
            TrangThai = r.Gt<string>("TrangThai"),
            NgayCap = r.Gt<System.DateTime>("NgayCap"),
            BienSoDangGui = r.Gt<string>("BienSoDangGui")
        };

        public TheXeDTO LayTheoMa(string maThe)
            => Doc<TheXeDTO>(Chon + "WHERE t.MaThe = @the", Map, P("@the", maThe)).FirstOrDefault();

        public List<TheXeDTO> LayTatCa(string tuKhoa)
        {
            string k = string.IsNullOrWhiteSpace(tuKhoa) ? null : tuKhoa.Trim();
            return Doc<TheXeDTO>(Chon + "WHERE (@k IS NULL OR t.MaThe LIKE N'%' + @k + N'%' OR lx.TenLoai LIKE N'%' + @k + N'%' " +
                                 "OR t.TrangThai LIKE N'%' + @k + N'%') ORDER BY t.MaThe", Map, P("@k", k));
        }

        public void Them(TheXeDTO t)
            => ThucThi("INSERT INTO TheXe(MaThe, MaLoaiXe, TrangThai, NgayCap) VALUES(@m, @lx, @tt, @nc)",
                       P("@m", t.MaThe), P("@lx", t.MaLoaiXe), P("@tt", t.TrangThai), P("@nc", t.NgayCap));

        public void Sua(TheXeDTO t)
            => ThucThi("UPDATE TheXe SET MaLoaiXe = @lx, TrangThai = @tt, NgayCap = @nc WHERE MaThe = @m",
                       P("@m", t.MaThe), P("@lx", t.MaLoaiXe), P("@tt", t.TrangThai), P("@nc", t.NgayCap));

        public bool CoLuotGui(string maThe)
            => (int)LayGiaTri("SELECT COUNT(*) FROM LuotGui WHERE MaThe = @m", P("@m", maThe)) > 0;

        public void Xoa(string maThe) => ThucThi("DELETE FROM TheXe WHERE MaThe = @m", P("@m", maThe));
    }
}