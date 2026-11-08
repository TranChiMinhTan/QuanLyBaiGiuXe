// Bảng VeThang và ThanhToanVeThang. Đăng ký và gia hạn đều dùng TRANSACTION (vé + tiền cùng lưu hoặc cùng hủy).
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using QuanLyBaiGiuXe.Models;
using static QuanLyBaiGiuXe.DAL.Database;

namespace QuanLyBaiGiuXe.DAL
{
    public class VeThangDAL
    {
        private const string Chon =
            "SELECT v.MaVe, v.BienSo, v.MaKH, k.HoTen, v.MaLoaiXe, lx.TenLoai, v.NgayDangKy, v.NgayHetHan, v.PhiDangKy, v.TrangThai " +
            "FROM VeThang v JOIN KhachHang k ON k.MaKH = v.MaKH JOIN LoaiXe lx ON lx.MaLoaiXe = v.MaLoaiXe ";

        private static VeThangDTO Map(SqlDataReader r) => new VeThangDTO
        {
            MaVe = r.Gt<int>("MaVe"),
            BienSo = r.Gt<string>("BienSo"),
            MaKH = r.Gt<string>("MaKH"),
            HoTenKhach = r.Gt<string>("HoTen"),
            MaLoaiXe = r.Gt<int>("MaLoaiXe"),
            TenLoaiXe = r.Gt<string>("TenLoai"),
            NgayDangKy = r.Gt<DateTime>("NgayDangKy"),
            NgayHetHan = r.Gt<DateTime>("NgayHetHan"),
            PhiDangKy = r.Gt<decimal>("PhiDangKy"),
            TrangThai = r.Gt<string>("TrangThai")
        };

        public List<VeThangDTO> LayTatCa(string tuKhoa)
        {
            string k = string.IsNullOrWhiteSpace(tuKhoa) ? null : tuKhoa.Trim();
            return Doc<VeThangDTO>(Chon + "WHERE (@k IS NULL OR v.BienSo LIKE N'%' + @k + N'%' OR k.HoTen LIKE N'%' + @k + N'%') " +
                                   "ORDER BY v.NgayHetHan", Map, P("@k", k));
        }

        public VeThangDTO LayTheoMa(int maVe)
            => Doc<VeThangDTO>(Chon + "WHERE v.MaVe = @id", Map, P("@id", maVe)).FirstOrDefault();

        /// <summary>Vé (chưa hủy) có hạn mới nhất của biển số. gọi qua VeThangBLL.KiemTraVeThang.</summary>
        public VeThangDTO LayMoiNhatTheoBienSo(string bienSo)
            => Doc<VeThangDTO>("SELECT TOP 1 " + Chon.Substring("SELECT ".Length) +
                               "WHERE v.BienSo = @b AND v.TrangThai = N'Hoạt động' ORDER BY v.NgayHetHan DESC",
                               Map, P("@b", bienSo)).FirstOrDefault();

        public int DangKy(VeThangDTO ve)
        {
            using (var cn = TaoKetNoi())
            {
                cn.Open();
                using (var tran = cn.BeginTransaction())
                {
                    try
                    {
                        var c1 = new SqlCommand(
                            "INSERT INTO VeThang(BienSo, MaKH, MaLoaiXe, NgayDangKy, NgayHetHan, PhiDangKy) OUTPUT INSERTED.MaVe " +
                            "VALUES(@b, @kh, @lx, @dk, @hh, @phi)", cn, tran);
                        c1.Parameters.Add(P("@b", ve.BienSo)); c1.Parameters.Add(P("@kh", ve.MaKH));
                        c1.Parameters.Add(P("@lx", ve.MaLoaiXe)); c1.Parameters.Add(P("@dk", ve.NgayDangKy));
                        c1.Parameters.Add(P("@hh", ve.NgayHetHan)); c1.Parameters.Add(P("@phi", ve.PhiDangKy));
                        int ma = (int)c1.ExecuteScalar();

                        var c2 = new SqlCommand(
                            "INSERT INTO ThanhToanVeThang(MaVe, SoTien) VALUES(@id, @t)", cn, tran);
                        c2.Parameters.Add(P("@id", ma)); c2.Parameters.Add(P("@t", ve.PhiDangKy));
                        c2.ExecuteNonQuery();

                        tran.Commit();
                        return ma;
                    }
                    catch { tran.Rollback(); throw; }
                }
            }
        }

        public void GiaHan(int maVe, DateTime ngayHetHanMoi, decimal soTien)
        {
            using (var cn = TaoKetNoi())
            {
                cn.Open();
                using (var tran = cn.BeginTransaction())
                {
                    try
                    {
                        var c1 = new SqlCommand("UPDATE VeThang SET NgayHetHan = @hh WHERE MaVe = @id", cn, tran);
                        c1.Parameters.Add(P("@hh", ngayHetHanMoi)); c1.Parameters.Add(P("@id", maVe));
                        c1.ExecuteNonQuery();

                        var c2 = new SqlCommand(
                            "" +
                            "INSERT INTO ThanhToanVeThang(MaVe, SoTien) VALUES(@id, @t)", cn, tran);
                        c2.Parameters.Add(P("@id", maVe)); c2.Parameters.Add(P("@t", soTien));
                        c2.ExecuteNonQuery();

                        tran.Commit();
                    }
                    catch { tran.Rollback(); throw; }
                }
            }
        }

        public void Sua(int maVe, string bienSo, string maKH)
            => ThucThi("UPDATE VeThang SET BienSo = @b, MaKH = @kh WHERE MaVe = @id",
                       P("@b", bienSo), P("@kh", maKH), P("@id", maVe));

        public void Huy(int maVe)
            => ThucThi("UPDATE VeThang SET TrangThai = N'Đã hủy' WHERE MaVe = @id", P("@id", maVe));
    }
}