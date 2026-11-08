// Bảng KhachHang.
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using QuanLyBaiGiuXe.Models;
using static QuanLyBaiGiuXe.DAL.Database;

namespace QuanLyBaiGiuXe.DAL
{
    public class KhachHangDAL
    {
        private static KhachHangDTO Map(SqlDataReader r) => new KhachHangDTO
        {
            MaKH = r.Gt<string>("MaKH"), HoTen = r.Gt<string>("HoTen"), SDT = r.Gt<string>("SDT"),
            CCCD = r.Gt<string>("CCCD"), DiaChi = r.Gt<string>("DiaChi"), SoVeThang = r.Gt<int>("SoVeThang")
        };

        private const string Chon =
            "SELECT k.MaKH, k.HoTen, k.SDT, k.CCCD, k.DiaChi, " +
            "  (SELECT COUNT(*) FROM VeThang v WHERE v.MaKH = k.MaKH AND v.TrangThai = N'Hoạt động') AS SoVeThang FROM KhachHang k ";

        public List<KhachHangDTO> LayTatCa(string tuKhoa)
        {
            string k = string.IsNullOrWhiteSpace(tuKhoa) ? null : tuKhoa.Trim();
            return Doc<KhachHangDTO>(Chon + "WHERE (@k IS NULL OR k.MaKH LIKE N'%' + @k + N'%' OR k.HoTen LIKE N'%' + @k + N'%' " +
                                     "OR k.SDT LIKE N'%' + @k + N'%' OR k.CCCD LIKE N'%' + @k + N'%') ORDER BY k.MaKH DESC", Map, P("@k", k));
        }

        public KhachHangDTO LayTheoMa(string ma)
            => Doc<KhachHangDTO>(Chon + "WHERE k.MaKH = @m", Map, P("@m", ma)).FirstOrDefault();

        public string SinhMaMoi()
        {
            int n = (int)LayGiaTri("SELECT ISNULL(MAX(CAST(SUBSTRING(MaKH, 3, 10) AS INT)), 0) + 1 FROM KhachHang");
            return "KH" + n.ToString("000");
        }

        public bool TrungCccd(string cccd, string boQuaMa)
            => (int)LayGiaTri("SELECT COUNT(*) FROM KhachHang WHERE CCCD = @c AND MaKH <> @m",
                              P("@c", cccd), P("@m", boQuaMa ?? "")) > 0;

        public void Them(KhachHangDTO k)
            => ThucThi("INSERT INTO KhachHang(MaKH, HoTen, SDT, CCCD, DiaChi) VALUES(@m, @h, @s, @c, @d)",
                       P("@m", k.MaKH), P("@h", k.HoTen), P("@s", k.SDT), P("@c", k.CCCD), P("@d", k.DiaChi));

        public void Sua(KhachHangDTO k)
            => ThucThi("UPDATE KhachHang SET HoTen = @h, SDT = @s, CCCD = @c, DiaChi = @d WHERE MaKH = @m",
                       P("@m", k.MaKH), P("@h", k.HoTen), P("@s", k.SDT), P("@c", k.CCCD), P("@d", k.DiaChi));

        public bool CoVeThang(string ma)
            => (int)LayGiaTri("SELECT COUNT(*) FROM VeThang WHERE MaKH = @m", P("@m", ma)) > 0;

        public void Xoa(string ma) => ThucThi("DELETE FROM KhachHang WHERE MaKH = @m", P("@m", ma));
    }
}
