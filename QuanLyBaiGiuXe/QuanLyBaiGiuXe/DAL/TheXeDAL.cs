// [Người 1 — BẢN TẠM, chỉ có LayTheoMa.]
using System;
using System.Data.SqlClient;
using QuanLyBaiXe.Models;

namespace QuanLyBaiXe.DAL
{
    public class TheXeDAL
    {
        public TheXeDTO LayTheoMa(string maThe)
        {
            using (var cn = Database.TaoKetNoi())
            using (var cmd = new SqlCommand(
                "SELECT t.MaThe, t.MaLoaiXe, lx.TenLoai, t.TrangThai, t.NgayCap " +
                "FROM TheXe t JOIN LoaiXe lx ON lx.MaLoaiXe = t.MaLoaiXe WHERE t.MaThe = @the", cn))
            {
                cmd.Parameters.AddWithValue("@the", maThe);
                cn.Open();
                using (var r = cmd.ExecuteReader())
                    return r.Read()
                        ? new TheXeDTO
                        {
                            MaThe = (string)r["MaThe"],
                            MaLoaiXe = (int)r["MaLoaiXe"],
                            TenLoaiXe = (string)r["TenLoai"],
                            TrangThai = (string)r["TrangThai"],
                            NgayCap = (DateTime)r["NgayCap"]
                        }
                        : null;
            }
        }
    }
}
