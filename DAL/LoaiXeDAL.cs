// Bảng LoaiXe.
using System.Collections.Generic;
using QuanLyBaiGiuXe.Models;
using static QuanLyBaiGiuXe.DAL.Database;

namespace QuanLyBaiGiuXe.DAL
{
    public class LoaiXeDAL
    {
        private static LoaiXeDTO Map(System.Data.SqlClient.SqlDataReader r) => new LoaiXeDTO
        {
            MaLoaiXe = r.Gt<int>("MaLoaiXe"),
            TenLoai = r.Gt<string>("TenLoai"),
            SucChua = r.Gt<int>("SucChua"),
            MoTa = r.Gt<string>("MoTa")
        };

        public List<LoaiXeDTO> LayTatCa(string tuKhoa = null)
        {
            string k = string.IsNullOrWhiteSpace(tuKhoa) ? null : tuKhoa.Trim();
            return Doc<LoaiXeDTO>(
                "SELECT MaLoaiXe, TenLoai, SucChua, MoTa FROM LoaiXe " +
                "WHERE (@k IS NULL OR TenLoai LIKE N'%' + @k + N'%') ORDER BY MaLoaiXe", Map, P("@k", k));
        }

        public bool TrungTen(string ten, int boQuaMa)
            => (int)LayGiaTri("SELECT COUNT(*) FROM LoaiXe WHERE TenLoai = @t AND MaLoaiXe <> @id",
                              P("@t", ten), P("@id", boQuaMa)) > 0;

        public void Them(LoaiXeDTO x)
            => ThucThi("INSERT INTO LoaiXe(TenLoai, SucChua, MoTa) VALUES(@t, @s, @m)",
                       P("@t", x.TenLoai), P("@s", x.SucChua), P("@m", x.MoTa));

        public void Sua(LoaiXeDTO x)
            => ThucThi("UPDATE LoaiXe SET TenLoai = @t, SucChua = @s, MoTa = @m WHERE MaLoaiXe = @id",
                       P("@t", x.TenLoai), P("@s", x.SucChua), P("@m", x.MoTa), P("@id", x.MaLoaiXe));

        /// <summary>Loại xe đã có thẻ, lượt gửi hoặc vé tháng thì không được xóa.</summary>
        public bool DangDuocDung(int ma)
            => (int)LayGiaTri(
                "SELECT (SELECT COUNT(*) FROM TheXe WHERE MaLoaiXe = @id) + (SELECT COUNT(*) FROM LuotGui WHERE MaLoaiXe = @id) " +
                "+ (SELECT COUNT(*) FROM VeThang WHERE MaLoaiXe = @id)", P("@id", ma)) > 0;

        public void Xoa(int ma)
            => ThucThi("SET XACT_ABORT ON; BEGIN TRAN; DELETE FROM BangGia WHERE MaLoaiXe = @id; " +
                       "DELETE FROM LoaiXe WHERE MaLoaiXe = @id; COMMIT;", P("@id", ma));
    }
}