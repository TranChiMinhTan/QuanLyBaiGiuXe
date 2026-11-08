//Báo cáo doanh thu: gọi stored procedure sp_BaoCaoDoanhThu (xem Database/Database_Nguoi4.sql).
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QuanLyBaiGiuXe.Models;

namespace QuanLyBaiGiuXe.DAL
{
    public class BaoCaoDAL
    {
        /// <summary>Chỉ trả về các kỳ CÓ phát sinh doanh thu; kỳ trống do BLL tự điền số 0.</summary>
        public List<DoanhThuKyDTO> LayDoanhThu(DateTime tuNgay, DateTime denNgay, bool theoThang)
        {
            var ds = new List<DoanhThuKyDTO>();
            using (var cn = Database.TaoKetNoi())
            using (var cmd = new SqlCommand("sp_BaoCaoDoanhThu", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@TuNgay", SqlDbType.Date).Value = tuNgay.Date;
                cmd.Parameters.Add("@DenNgay", SqlDbType.Date).Value = denNgay.Date;
                cmd.Parameters.Add("@TheoThang", SqlDbType.Bit).Value = theoThang;

                cn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        ds.Add(new DoanhThuKyDTO
                        {
                            Ky = Convert.ToDateTime(r["Ky"]),
                            SoLuot = Convert.ToInt32(r["SoLuot"]),
                            TienLuotGui = Convert.ToDecimal(r["TienLuotGui"]),
                            TienVeThang = Convert.ToDecimal(r["TienVeThang"])
                        });
            }
            return ds;
        }
    }
}