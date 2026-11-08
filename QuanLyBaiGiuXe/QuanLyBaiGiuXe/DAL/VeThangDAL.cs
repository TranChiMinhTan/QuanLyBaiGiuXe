// [Người 3 — BẢN TẠM, chỉ có LayMoiNhatTheoBienSo.]
using System;
using System.Data.SqlClient;
using QuanLyBaiXe.Models;

namespace QuanLyBaiXe.DAL
{
    public class VeThangDAL
    {
        public VeThangDTO LayMoiNhatTheoBienSo(string bienSo)
        {
            using (var cn = Database.TaoKetNoi())
            using (var cmd = new SqlCommand(
                "SELECT TOP 1 MaVe, BienSo, MaLoaiXe, NgayDangKy, NgayHetHan, PhiDangKy " +
                "FROM VeThang WHERE BienSo = @bs ORDER BY NgayHetHan DESC", cn))
            {
                cmd.Parameters.AddWithValue("@bs", bienSo);
                cn.Open();
                using (var r = cmd.ExecuteReader())
                    return r.Read()
                        ? new VeThangDTO
                        {
                            MaVe = (int)r["MaVe"],
                            BienSo = (string)r["BienSo"],
                            MaLoaiXe = (int)r["MaLoaiXe"],
                            NgayDangKy = (DateTime)r["NgayDangKy"],
                            NgayHetHan = (DateTime)r["NgayHetHan"],
                            PhiDangKy = (decimal)r["PhiDangKy"]
                        }
                        : null;
            }
        }
    }
}
