// Bảng KhachHang (MaKH dạng chuỗi "KH001", tự sinh). Người 3.
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using QuanLyBaiGiuXe.Models;
using static QuanLyBaiGiuXe.DAL.Database;

namespace QuanLyBaiGiuXe.DAL
{
    public class KhachHangDAL
    {
        private const string Chon =
            "SELECT k.MaKH, k.HoTen, k.SDT, k.CCCD, k.DiaChi, " +
            "  (SELECT COUNT(*) FROM VeThang v WHERE v.MaKH = k.MaKH AND v.TrangThai = N'Hoạt động') AS SoVeThang " +
            "FROM KhachHang k ";

        private static KhachHangDTO Map(SqlDataReader r) => new KhachHangDTO
        {
            MaKH = r.Gt<string>("MaKH"),
            HoTen = r.Gt<string>("HoTen"),
            SDT = r.Gt<string>("SDT"),
            CCCD = r.Gt<string>("CCCD"),
            DiaChi = r.Gt<string>("DiaChi"),
            SoVeThang = r.Gt<int>("SoVeThang")
        };

        public List<KhachHangDTO> LayTatCa(string tuKhoa)
        {
            string k = string.IsNullOrWhiteSpace(tuKhoa) ? null : tuKhoa.Trim();
            return Doc<KhachHangDTO>(Chon +
                "WHERE (@k IS NULL OR k.MaKH LIKE N'%' + @k + N'%' OR k.HoTen LIKE N'%' + @k + N'%' " +
                "OR k.SDT LIKE N'%' + @k + N'%' OR k.CCCD LIKE N'%' + @k + N'%') ORDER BY k.MaKH", Map, P("@k", k));
        }

        public KhachHangDTO LayTheoMa(string maKH)
            => Doc<KhachHangDTO>(Chon + "WHERE k.MaKH = @m", Map, P("@m", maKH)).FirstOrDefault();

        /// <summary>Mã kế tiếp: KH + số lớn nhất hiện có + 1, tối thiểu 3 chữ số (KH001, KH002, ...).</summary>
        public string TaoMaMoi()
        {
            object v = LayGiaTri("SELECT MAX(TRY_CAST(SUBSTRING(MaKH, 3, 10) AS INT)) FROM KhachHang WHERE MaKH LIKE 'KH%'");
            int so = (v == null || v == System.DBNull.Value ? 0 : System.Convert.ToInt32(v)) + 1;
            return "KH" + so.ToString("000");
        }

        public bool TrungCCCD(string cccd, string boQuaMaKH)
            => (int)LayGiaTri("SELECT COUNT(*) FROM KhachHang WHERE CCCD = @c AND MaKH <> @m",
                              P("@c", cccd), P("@m", boQuaMaKH ?? "")) > 0;

        public void Them(KhachHangDTO k)
            => ThucThi("INSERT INTO KhachHang(MaKH, HoTen, SDT, CCCD, DiaChi) VALUES(@m, @t, @s, @c, @d)",
                       P("@m", k.MaKH), P("@t", k.HoTen), P("@s", k.SDT), P("@c", k.CCCD), P("@d", k.DiaChi));

        public int Sua(KhachHangDTO k)
            => ThucThi("UPDATE KhachHang SET HoTen = @t, SDT = @s, CCCD = @c, DiaChi = @d WHERE MaKH = @m",
                       P("@m", k.MaKH), P("@t", k.HoTen), P("@s", k.SDT), P("@c", k.CCCD), P("@d", k.DiaChi));

        public bool CoVeThang(string maKH)
            => (int)LayGiaTri("SELECT COUNT(*) FROM VeThang WHERE MaKH = @m", P("@m", maKH)) > 0;

        public int Xoa(string maKH) => ThucThi("DELETE FROM KhachHang WHERE MaKH = @m", P("@m", maKH));
    }
}
