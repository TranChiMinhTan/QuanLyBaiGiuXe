// [Người 1 — BẢN TẠM, chỉ có LayTheoLoaiXe.]
using System.Data.SqlClient;
using QuanLyBaiXe.Models;

namespace QuanLyBaiXe.DAL
{
    public class BangGiaDAL
    {
        public BangGiaDTO LayTheoLoaiXe(int maLoaiXe)
        {
            using (var cn = Database.TaoKetNoi())
            using (var cmd = new SqlCommand(
                "SELECT TOP 1 MaBangGia, MaLoaiXe, MienPhiPhut, GiaKhoi, SoGioKhoi, PhuThuQuaDem, GiaVeThang " +
                "FROM BangGia WHERE MaLoaiXe = @lx", cn))
            {
                cmd.Parameters.AddWithValue("@lx", maLoaiXe);
                cn.Open();
                using (var r = cmd.ExecuteReader())
                    return r.Read()
                        ? new BangGiaDTO
                        {
                            MaBangGia = (int)r["MaBangGia"],
                            MaLoaiXe = (int)r["MaLoaiXe"],
                            MienPhiPhut = (int)r["MienPhiPhut"],
                            GiaKhoi = (decimal)r["GiaKhoi"],
                            SoGioKhoi = (int)r["SoGioKhoi"],
                            PhuThuQuaDem = (decimal)r["PhuThuQuaDem"],
                            GiaVeThang = (decimal)r["GiaVeThang"]
                        }
                        : null;
            }
        }
    }
}
