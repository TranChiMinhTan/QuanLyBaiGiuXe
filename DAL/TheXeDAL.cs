using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QuanLyBaiXe.DTO;

namespace QuanLyBaiXe.DAL
{
    public class TheXeDAL
    {
        private const string SqlChon =
            "SELECT t.MaThe, t.MaLoaiXe, l.TenLoaiXe, t.TrangThai " +
            "FROM TheXe t JOIN LoaiXe l ON l.MaLoaiXe = t.MaLoaiXe ";

        private static TheXeDTO Doc(DataRow r)
        {
            return new TheXeDTO
            {
                MaThe = r["MaThe"].ToString(),
                MaLoaiXe = Convert.ToInt32(r["MaLoaiXe"]),
                TenLoaiXe = r["TenLoaiXe"].ToString(),
                TrangThai = r["TrangThai"].ToString()
            };
        }

        public List<TheXeDTO> LayTatCa()
        {
            DataTable dt = Database.LayBang(SqlChon + "ORDER BY t.MaThe");
            List<TheXeDTO> ds = new List<TheXeDTO>();
            foreach (DataRow r in dt.Rows) ds.Add(Doc(r));
            return ds;
        }

        /// <summary>Người 2 dùng khi xe vào/ra để lấy thẻ.</summary>
        public TheXeDTO LayTheoMa(string maThe)
        {
            DataTable dt = Database.LayBang(SqlChon + "WHERE t.MaThe = @ma",
                Database.Tham("@ma", maThe));
            return dt.Rows.Count == 0 ? null : Doc(dt.Rows[0]);
        }

        public bool TonTai(string maThe)
        {
            object kq = Database.LayGiaTri("SELECT COUNT(*) FROM TheXe WHERE MaThe = @ma",
                Database.Tham("@ma", maThe));
            return Convert.ToInt32(kq) > 0;
        }

        public int Them(TheXeDTO t)
        {
            return Database.ThucThi(
                "INSERT INTO TheXe (MaThe, MaLoaiXe, TrangThai) VALUES (@ma, @loai, @tt)",
                Database.Tham("@ma", t.MaThe),
                Database.Tham("@loai", t.MaLoaiXe),
                Database.Tham("@tt", t.TrangThai));
        }

        public int Sua(TheXeDTO t)
        {
            return Database.ThucThi(
                "UPDATE TheXe SET MaLoaiXe = @loai, TrangThai = @tt WHERE MaThe = @ma",
                Database.Tham("@loai", t.MaLoaiXe),
                Database.Tham("@tt", t.TrangThai),
                Database.Tham("@ma", t.MaThe));
        }

        public int Xoa(string maThe)
        {
            return Database.ThucThi("DELETE FROM TheXe WHERE MaThe = @ma",
                Database.Tham("@ma", maThe));
        }

        /// <summary>Thẻ đã từng có lượt gửi thì không được xóa (chỉ khóa).</summary>
        public bool DaCoLuotGui(string maThe)
        {
            object kq = Database.LayGiaTri("SELECT COUNT(*) FROM LuotGui WHERE MaThe = @ma",
                Database.Tham("@ma", maThe));
            return Convert.ToInt32(kq) > 0;
        }

        /// <summary>Đổi trạng thái thẻ bên trong transaction (Người 2 gọi khi xe vào/ra).</summary>
        public int CapNhatTrangThai(SqlConnection cn, SqlTransaction tr, string maThe, string trangThai)
        {
            return Database.ThucThi(cn, tr,
                "UPDATE TheXe SET TrangThai = @tt WHERE MaThe = @ma",
                Database.Tham("@tt", trangThai),
                Database.Tham("@ma", maThe));
        }
    }
}
