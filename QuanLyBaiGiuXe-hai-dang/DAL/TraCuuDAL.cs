//Tra cứu lịch sử lượt gửi. Chỉ chứa SQL tham số hóa, không có nghiệp vụ.
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QuanLyBaiXe.Models;

namespace QuanLyBaiXe.DAL
{
    public class TraCuuDAL
    {
        private const string Sql =
            "SELECT l.MaLuot, l.BienSo, l.MaThe, l.MaLoaiXe, lx.TenLoai, l.GioVao, l.GioRa, l.Phi, l.DuongDanAnh " +
            "FROM LuotGui l JOIN LoaiXe lx ON lx.MaLoaiXe = l.MaLoaiXe " +
            "WHERE l.GioVao >= @tu AND l.GioVao < @den " +
            "AND (@bs  IS NULL OR l.BienSo LIKE '%' + @bs  + '%' ESCAPE '\\') " +
            "AND (@the IS NULL OR l.MaThe  LIKE '%' + @the + '%' ESCAPE '\\') " +
            "AND (@lx  IS NULL OR l.MaLoaiXe = @lx) " +
            "ORDER BY l.GioVao DESC";

        /// <param name="bienSo">null = không lọc</param>
        /// <param name="maThe">null = không lọc</param>
        /// <param name="tuNgay">lọc theo NGÀY VÀO, tính từ 00:00 của ngày này</param>
        /// <param name="denNgay">đến hết ngày này (23:59:59)</param>
        /// <param name="maLoaiXe">null = tất cả loại xe</param>
        public List<LuotGuiDTO> TimKiem(string bienSo, string maThe, DateTime tuNgay, DateTime denNgay, int? maLoaiXe)
        {
            var ds = new List<LuotGuiDTO>();
            using (var cn = Database.TaoKetNoi())
            using (var cmd = new SqlCommand(Sql, cn))
            {
                cmd.Parameters.Add("@tu", SqlDbType.DateTime).Value = tuNgay.Date;
                cmd.Parameters.Add("@den", SqlDbType.DateTime).Value = denNgay.Date.AddDays(1);
                cmd.Parameters.Add("@bs", SqlDbType.NVarChar, 100).Value =
                    bienSo == null ? (object)DBNull.Value : ThoatLike(bienSo);
                cmd.Parameters.Add("@the", SqlDbType.NVarChar, 100).Value =
                    maThe == null ? (object)DBNull.Value : ThoatLike(maThe);
                cmd.Parameters.Add("@lx", SqlDbType.Int).Value =
                    maLoaiXe.HasValue ? (object)maLoaiXe.Value : DBNull.Value;

                cn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read()) ds.Add(Doc(r));
            }
            return ds;
        }

        /// <summary>Người dùng gõ % hoặc _ thì coi như ký tự thường, không phải ký tự đại diện của LIKE.</summary>
        private static string ThoatLike(string s)
        {
            return s.Replace("\\", "\\\\").Replace("%", "\\%").Replace("_", "\\_").Replace("[", "\\[");
        }

        private static LuotGuiDTO Doc(SqlDataReader r)
        {
            return new LuotGuiDTO
            {
                MaLuot = (int)r["MaLuot"],
                BienSo = (string)r["BienSo"],
                MaThe = (string)r["MaThe"],
                MaLoaiXe = (int)r["MaLoaiXe"],
                TenLoaiXe = (string)r["TenLoai"],
                GioVao = (DateTime)r["GioVao"],
                GioRa = r["GioRa"] == DBNull.Value ? (DateTime?)null : (DateTime)r["GioRa"],
                Phi = r["Phi"] == DBNull.Value ? 0m : Convert.ToDecimal(r["Phi"]),
                DuongDanAnh = r["DuongDanAnh"] == DBNull.Value ? null : (string)r["DuongDanAnh"]
            };
        }
    }
}