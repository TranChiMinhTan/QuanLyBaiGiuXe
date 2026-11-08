// [Người 2] Chỉ chứa SQL tham số hóa. Hai transaction: XeVao và XeRa.
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using QuanLyBaiGiuXe.Models;

namespace QuanLyBaiGiuXe.DAL
{
    public class LuotGuiDAL
    {
        private const string CotVaBang =
            "SELECT l.MaLuot, l.BienSo, l.MaThe, l.MaLoaiXe, lx.TenLoai, l.GioVao, l.GioRa, l.Phi, l.DuongDanAnh " +
            "FROM LuotGui l JOIN LoaiXe lx ON lx.MaLoaiXe = l.MaLoaiXe ";

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
                Phi = r["Phi"] == DBNull.Value ? 0m : (decimal)r["Phi"],
                DuongDanAnh = r["DuongDanAnh"] == DBNull.Value ? null : (string)r["DuongDanAnh"]
            };
        }

        /// <summary>Biển số này đang ở trong bãi chưa? (chống xe vào trùng)</summary>
        public bool DangTrongBai(string bienSo)
        {
            using (var cn = Database.TaoKetNoi())
            using (var cmd = new SqlCommand(
                "SELECT COUNT(*) FROM LuotGui WHERE BienSo = @bs AND GioRa IS NULL", cn))
            {
                cmd.Parameters.AddWithValue("@bs", bienSo);
                cn.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        public LuotGuiDTO LayLuotDangGui(string maThe)
        {
            using (var cn = Database.TaoKetNoi())
            using (var cmd = new SqlCommand(CotVaBang + "WHERE l.MaThe = @the AND l.GioRa IS NULL", cn))
            {
                cmd.Parameters.AddWithValue("@the", maThe);
                cn.Open();
                using (var r = cmd.ExecuteReader())
                    return r.Read() ? Doc(r) : null;
            }
        }

        /// <summary>Lượt đang gửi và lượt đã ra trong hôm nay, mới nhất ở trên.</summary>
        public List<LuotGuiDTO> LayLuotHienThi()
        {
            var ds = new List<LuotGuiDTO>();
            using (var cn = Database.TaoKetNoi())
            using (var cmd = new SqlCommand(
                CotVaBang + "WHERE l.GioRa IS NULL OR CAST(l.GioRa AS DATE) = CAST(GETDATE() AS DATE) " +
                "ORDER BY l.GioVao DESC", cn))
            {
                cn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read()) ds.Add(Doc(r));
            }
            return ds;
        }

        /// <summary>Mỗi thẻ xe = một ô trên sơ đồ bãi.</summary>
        public List<OGuiDTO> LayTrangThaiBai()
        {
            var ds = new List<OGuiDTO>();
            const string sql =
                "SELECT t.MaThe, t.TrangThai, l.BienSo, l.GioVao, " +
                "  CASE WHEN l.BienSo IS NOT NULL AND EXISTS (SELECT 1 FROM VeThang v " +
                "       WHERE v.BienSo = l.BienSo AND v.NgayHetHan >= CAST(GETDATE() AS DATE)) THEN 1 ELSE 0 END AS CoVeThang " +
                "FROM TheXe t LEFT JOIN LuotGui l ON l.MaThe = t.MaThe AND l.GioRa IS NULL " +
                "ORDER BY t.MaThe";
            using (var cn = Database.TaoKetNoi())
            using (var cmd = new SqlCommand(sql, cn))
            {
                cn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        ds.Add(new OGuiDTO
                        {
                            MaThe = (string)r["MaThe"],
                            TrangThai = (string)r["TrangThai"],
                            BienSo = r["BienSo"] == DBNull.Value ? null : (string)r["BienSo"],
                            GioVao = r["GioVao"] == DBNull.Value ? (DateTime?)null : (DateTime)r["GioVao"],
                            CoVeThang = (int)r["CoVeThang"] == 1
                        });
            }
            return ds;
        }

        /// <summary>
        /// TRANSACTION xe vào: đổi thẻ sang "Đang dùng" VÀ thêm lượt gửi. Một trong hai lỗi thì hoàn tác cả hai.
        /// </summary>
        public int XeVao(LuotGuiDTO luot)
        {
            using (var cn = Database.TaoKetNoi())
            {
                cn.Open();
                using (var tran = cn.BeginTransaction())
                {
                    try
                    {
                        var c1 = new SqlCommand(
                            "UPDATE TheXe SET TrangThai = N'" + TrangThaiThe.DangDung + "' WHERE MaThe = @the AND TrangThai = N'" + TrangThaiThe.DangTrong + "'", cn, tran);
                        c1.Parameters.AddWithValue("@the", luot.MaThe);
                        if (c1.ExecuteNonQuery() != 1)
                            throw new InvalidOperationException("Thẻ không còn ở trạng thái trống.");

                        var c2 = new SqlCommand(
                            "INSERT INTO LuotGui(BienSo, MaThe, MaLoaiXe, GioVao, DuongDanAnh) " +
                            "OUTPUT INSERTED.MaLuot VALUES(@bs, @the, @lx, @vao, @anh)", cn, tran);
                        c2.Parameters.AddWithValue("@bs", luot.BienSo);
                        c2.Parameters.AddWithValue("@the", luot.MaThe);
                        c2.Parameters.AddWithValue("@lx", luot.MaLoaiXe);
                        c2.Parameters.AddWithValue("@vao", luot.GioVao);
                        c2.Parameters.AddWithValue("@anh", (object)luot.DuongDanAnh ?? DBNull.Value);
                        int ma = (int)c2.ExecuteScalar();

                        tran.Commit();
                        return ma;
                    }
                    catch { tran.Rollback(); throw; }
                }
            }
        }

        /// <summary>
        /// TRANSACTION xe ra và thanh toán: cập nhật lượt gửi, ghi thanh toán, trả thẻ về "Đang trống".
        /// Lỗi ở bất kỳ bước nào thì hoàn tác tất cả.
        /// </summary>
        public void XeRa(LuotGuiDTO luot)
        {
            using (var cn = Database.TaoKetNoi())
            {
                cn.Open();
                using (var tran = cn.BeginTransaction())
                {
                    try
                    {
                        var c1 = new SqlCommand(
                            "UPDATE LuotGui SET GioRa = @ra, Phi = @phi WHERE MaLuot = @id AND GioRa IS NULL", cn, tran);
                        c1.Parameters.AddWithValue("@ra", luot.GioRa);
                        c1.Parameters.AddWithValue("@phi", luot.Phi);
                        c1.Parameters.AddWithValue("@id", luot.MaLuot);
                        if (c1.ExecuteNonQuery() != 1)
                            throw new InvalidOperationException("Lượt gửi này đã được xử lý trước đó.");

                        var c2 = new SqlCommand(
                            "INSERT INTO ThanhToan(MaLuot, SoTien, ThoiDiem) VALUES(@id, @tien, @td)", cn, tran);
                        c2.Parameters.AddWithValue("@id", luot.MaLuot);
                        c2.Parameters.AddWithValue("@tien", luot.Phi);
                        c2.Parameters.AddWithValue("@td", DateTime.Now);
                        c2.ExecuteNonQuery();

                        // Chỉ bật khi demo: giả lập lỗi SAU hai bước trên để chứng minh rollback.
                        if (Database.GiaLapLoi)
                            throw new Exception("Lỗi giả lập giữa chừng (demo rollback).");

                        var c3 = new SqlCommand(
                            "UPDATE TheXe SET TrangThai = N'" + TrangThaiThe.DangTrong + "' WHERE MaThe = @the AND TrangThai = N'" + TrangThaiThe.DangDung + "'", cn, tran);
                        c3.Parameters.AddWithValue("@the", luot.MaThe);
                        c3.ExecuteNonQuery();

                        tran.Commit();
                    }
                    catch { tran.Rollback(); throw; }
                }
            }
        }
    }
}
