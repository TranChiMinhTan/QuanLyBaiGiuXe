// [ ] Bảng BangGia. LayTheoLoaiXe được   gọi khi tính phí xe ra.
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
            "SELECT b.MaBangGia, b.MaLoaiXe, lx.TenLoai, b.MienPhiPhut, b.GiaKhoi, b.SoGioKhoi, b.PhuThuQuaDem, b.GiaVeThang " +
            "FROM BangGia b JOIN LoaiXe lx ON lx.MaLoaiXe = b.MaLoaiXe ";

        private static BangGiaDTO Map(SqlDataReader r) => new BangGiaDTO
        {
            MaBangGia = r.Gt<int>("MaBangGia"),
            MaLoaiXe = r.Gt<int>("MaLoaiXe"),
            TenLoaiXe = r.Gt<string>("TenLoai"),
            MienPhiPhut = r.Gt<int>("MienPhiPhut"),
            GiaKhoi = r.Gt<decimal>("GiaKhoi"),
            SoGioKhoi = r.Gt<int>("SoGioKhoi"),
            PhuThuQuaDem = r.Gt<decimal>("PhuThuQuaDem"),
            GiaVeThang = r.Gt<decimal>("GiaVeThang")
        };

        public BangGiaDTO LayTheoLoaiXe(int maLoaiXe)
            => Doc<BangGiaDTO>(Chon + "WHERE b.MaLoaiXe = @lx", Map, P("@lx", maLoaiXe)).FirstOrDefault();

        public List<BangGiaDTO> LayTatCa() => Doc<BangGiaDTO>(Chon + "ORDER BY b.MaLoaiXe", Map);

        public void Them(BangGiaDTO g)
            => ThucThi("INSERT INTO BangGia(MaLoaiXe, MienPhiPhut, GiaKhoi, SoGioKhoi, PhuThuQuaDem, GiaVeThang) " +
                       "VALUES(@lx, @mp, @gk, @sg, @pt, @vt)",
                       P("@lx", g.MaLoaiXe), P("@mp", g.MienPhiPhut), P("@gk", g.GiaKhoi),
                       P("@sg", g.SoGioKhoi), P("@pt", g.PhuThuQuaDem), P("@vt", g.GiaVeThang));

        public void Sua(BangGiaDTO g)
            => ThucThi("UPDATE BangGia SET MienPhiPhut = @mp, GiaKhoi = @gk, SoGioKhoi = @sg, PhuThuQuaDem = @pt, " +
                       "GiaVeThang = @vt WHERE MaLoaiXe = @lx",
                       P("@lx", g.MaLoaiXe), P("@mp", g.MienPhiPhut), P("@gk", g.GiaKhoi),
                       P("@sg", g.SoGioKhoi), P("@pt", g.PhuThuQuaDem), P("@vt", g.GiaVeThang));

        public void Xoa(int maLoaiXe) => ThucThi("DELETE FROM BangGia WHERE MaLoaiXe = @lx", P("@lx", maLoaiXe));
    }
}