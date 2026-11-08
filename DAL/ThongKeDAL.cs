// Thống kê: doanh thu (stored procedure sp_DoanhThu), giờ cao điểm, gợi ý vé tháng.
using System;
using System.Collections.Generic;
using QuanLyBaiGiuXe.Models;
using static QuanLyBaiGiuXe.DAL.Database;

namespace QuanLyBaiGiuXe.DAL
{
    public class ThongKeDAL
    {
        public List<DoanhThuDTO> DoanhThu(DateTime tu, DateTime den, bool theoThang)
            => GoiProc<DoanhThuDTO>("sp_DoanhThu",
                r => new DoanhThuDTO { Nhan = r.Gt<string>("Nhan"), SoLuot = r.Gt<int>("SoLuot"), DoanhThu = r.Gt<decimal>("DoanhThu") },
                P("@TuNgay", tu.Date), P("@DenNgay", den.Date), P("@TheoThang", theoThang));

        public decimal DoanhThuVeThang(DateTime tu, DateTime den)
            => Convert.ToDecimal(LayGiaTri(
                "SELECT ISNULL(SUM(SoTien), 0) FROM ThanhToanVeThang WHERE CAST(ThoiDiem AS DATE) BETWEEN @tu AND @den",
                P("@tu", tu.Date), P("@den", den.Date)));

        /// <summary>[SÁNG TẠO #8] Số xe vào theo từng giờ trong khoảng ngày (giờ không có xe không xuất hiện, BLL sẽ bù 0).</summary>
        public List<GioCaoDiemDTO> GioCaoDiem(DateTime tu, DateTime den)
            => Doc<GioCaoDiemDTO>(
                "SELECT DATEPART(HOUR, GioVao) AS Gio, COUNT(*) AS SoLuot FROM LuotGui " +
                "WHERE CAST(GioVao AS DATE) BETWEEN @tu AND @den GROUP BY DATEPART(HOUR, GioVao) ORDER BY Gio",
                r => new GioCaoDiemDTO { Gio = r.Gt<int>("Gio"), SoLuot = r.Gt<int>("SoLuot") },
                P("@tu", tu.Date), P("@den", den.Date));

        /// <summary>
        /// [SÁNG TẠO #7] Biển số chưa có vé tháng còn hạn, trong 30 ngày qua gửi lẻ với tổng phí đã đạt từ 80% giá vé tháng trở lên.
        /// </summary>
        public List<GoiYVeThangDTO> GoiYVeThang()
            => Doc<GoiYVeThangDTO>(
                "SELECT l.BienSo, lx.TenLoai, COUNT(*) AS SoLuot, SUM(ISNULL(l.Phi, 0)) AS TongPhi, bg.GiaVeThang " +
                "FROM LuotGui l JOIN LoaiXe lx ON lx.MaLoaiXe = l.MaLoaiXe JOIN BangGia bg ON bg.MaLoaiXe = l.MaLoaiXe " +
                "WHERE l.GioRa IS NOT NULL AND l.GioRa >= DATEADD(DAY, -30, GETDATE()) " +
                "  AND NOT EXISTS (SELECT 1 FROM VeThang v WHERE v.BienSo = l.BienSo AND v.TrangThai = N'Hoạt động' " +
                "                  AND v.NgayHetHan >= CAST(GETDATE() AS DATE)) " +
                "GROUP BY l.BienSo, lx.TenLoai, bg.GiaVeThang " +
                "HAVING SUM(ISNULL(l.Phi, 0)) >= bg.GiaVeThang * 0.8 ORDER BY SUM(ISNULL(l.Phi, 0)) DESC",
                r => new GoiYVeThangDTO
                {
                    BienSo = r.Gt<string>("BienSo"), TenLoaiXe = r.Gt<string>("TenLoai"), SoLuot = r.Gt<int>("SoLuot"),
                    TongPhi = r.Gt<decimal>("TongPhi"), GiaVeThang = r.Gt<decimal>("GiaVeThang")
                });
    }
}
