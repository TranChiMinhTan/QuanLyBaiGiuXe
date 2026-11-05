// [Người 1 — BẢN TẠM, chỉ có LayTatCa.]
using System.Collections.Generic;
using System.Data.SqlClient;
using QuanLyBaiXe.Models;

namespace QuanLyBaiXe.DAL
{
    public class LoaiXeDAL
    {
        public List<LoaiXeDTO> LayTatCa()
        {
            var ds = new List<LoaiXeDTO>();
            using (var cn = Database.TaoKetNoi())
            using (var cmd = new SqlCommand("SELECT MaLoaiXe, TenLoai, SucChua, MoTa FROM LoaiXe ORDER BY MaLoaiXe", cn))
            {
                cn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        ds.Add(new LoaiXeDTO
                        {
                            MaLoaiXe = (int)r["MaLoaiXe"],
                            TenLoai = (string)r["TenLoai"],
                            SucChua = (int)r["SucChua"],
                            MoTa = r["MoTa"] == System.DBNull.Value ? null : (string)r["MoTa"]
                        });
            }
            return ds;
        }
    }
}
