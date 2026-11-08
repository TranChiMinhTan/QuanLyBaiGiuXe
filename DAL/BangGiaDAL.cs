// Bảng BangGia (mô hình B+). LayTheoLoaiXe được LuotGuiBLL/VeThangBLL gọi khi tính phí / giá vé tháng.
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using QuanLyBaiGiuXe.Models;
using static QuanLyBaiGiuXe.DAL.Database;

namespace QuanLyBaiGiuXe.DAL
{
    public class BangGiaDAL
    {
        private const string Chon =
            "SELECT b.MaBangGia, b.MaLoaiXe, lx.TenLoai, b.MienPhiPhut, b.GiaGioDau, b.GiaGioTiepTheo, b.GiaToiDaNgay, b.GiaVeThang " +
            "FROM BangGia b JOIN LoaiXe lx ON lx.MaLoaiXe = b.MaLoaiXe ";

        private static BangGiaDTO Map(SqlDataReader r) => new BangGiaDTO
        {
            MaBangGia = r.Gt<int>("MaBangGia"),
            MaLoaiXe = r.Gt<int>("MaLoaiXe"),
            TenLoaiXe = r.Gt<string>("TenLoai"),
            MienPhiPhut = r.Gt<int>("MienPhiPhut"),
            GiaGioDau = r.Gt<decimal>("GiaGioDau"),
            GiaGioTiepTheo = r.Gt<decimal>("GiaGioTiepTheo"),
            GiaToiDaNgay = r.Gt<decimal>("GiaToiDaNgay"),
            GiaVeThang = r.Gt<decimal>("GiaVeThang")
        };

        public BangGiaDTO LayTheoLoaiXe(int maLoaiXe)
            => Doc<BangGiaDTO>(Chon + "WHERE b.MaLoaiXe = @lx", Map, P("@lx", maLoaiXe)).FirstOrDefault();

        public List<BangGiaDTO> LayTatCa() => Doc<BangGiaDTO>(Chon + "ORDER BY b.MaLoaiXe", Map);

        public bool DaCoGia(int maLoaiXe)
            => (int)LayGiaTri("SELECT COUNT(*) FROM BangGia WHERE MaLoaiXe = @lx", P("@lx", maLoaiXe)) > 0;

        public void Them(BangGiaDTO g)
            => ThucThi("INSERT INTO BangGia(MaLoaiXe, MienPhiPhut, GiaGioDau, GiaGioTiepTheo, GiaToiDaNgay, GiaVeThang) " +
                       "VALUES(@lx, @mp, @gd, @gt, @td, @vt)",
                       P("@lx", g.MaLoaiXe), P("@mp", g.MienPhiPhut), P("@gd", g.GiaGioDau),
                       P("@gt", g.GiaGioTiepTheo), P("@td", g.GiaToiDaNgay), P("@vt", g.GiaVeThang));

        public int Sua(BangGiaDTO g)
            => ThucThi("UPDATE BangGia SET MienPhiPhut = @mp, GiaGioDau = @gd, GiaGioTiepTheo = @gt, GiaToiDaNgay = @td, " +
                       "GiaVeThang = @vt WHERE MaLoaiXe = @lx",
                       P("@lx", g.MaLoaiXe), P("@mp", g.MienPhiPhut), P("@gd", g.GiaGioDau),
                       P("@gt", g.GiaGioTiepTheo), P("@td", g.GiaToiDaNgay), P("@vt", g.GiaVeThang));

        public int Xoa(int maLoaiXe) => ThucThi("DELETE FROM BangGia WHERE MaLoaiXe = @lx", P("@lx", maLoaiXe));
    }
}
