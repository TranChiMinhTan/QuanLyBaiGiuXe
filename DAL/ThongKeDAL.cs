// Thống kê cho báo cáo: giờ cao điểm và gợi ý khách nên đăng ký vé tháng. Chỉ SQL tham số hóa.
using System;
using System.Collections.Generic;
using QuanLyBaiGiuXe.Models;
using static QuanLyBaiGiuXe.DAL.Database;

namespace QuanLyBaiGiuXe.DAL
{
    public class ThongKeDAL
    {
        /// <summary>Chỉ trả về các giờ CÓ xe vào; BLL tự điền số 0 cho đủ 24 giờ.</summary>
        public List<GioCaoDiemDTO> LaySoLuotTheoGio(DateTime tuNgay, DateTime denNgay)
            => Doc<GioCaoDiemDTO>(
                "SELECT DATEPART(HOUR, GioVao) AS Gio, COUNT(*) AS SoLuot FROM LuotGui " +
                "WHERE GioVao >= @tu AND GioVao < @den GROUP BY DATEPART(HOUR, GioVao)",
                r => new GioCaoDiemDTO { Gio = r.Gt<int>("Gio"), SoLuot = r.Gt<int>("SoLuot") },
                P("@tu", tuNgay.Date), P("@den", denNgay.Date.AddDays(1)));

        /// <summary>
        /// Biển số CHƯA có vé tháng còn hạn, trong <paramref name="soNgay"/> ngày qua có lượt gửi lẻ đã kết thúc
        /// với tổng phí >= <paramref name="tiLe"/> x giá vé tháng của loại xe đó.
        /// </summary>
        public List<GoiYVeThangDTO> LayGoiYVeThang(int soNgay, decimal tiLe)
            => Doc<GoiYVeThangDTO>(
                "SELECT l.BienSo, lx.TenLoai, COUNT(*) AS SoLuot, SUM(l.Phi) AS TongPhi, b.GiaVeThang " +
                "FROM LuotGui l " +
                "JOIN LoaiXe lx ON lx.MaLoaiXe = l.MaLoaiXe " +
                "JOIN BangGia b ON b.MaLoaiXe = l.MaLoaiXe " +
                "WHERE l.GioRa IS NOT NULL AND l.GioRa >= DATEADD(DAY, -@ngay, GETDATE()) AND b.GiaVeThang > 0 " +
                "AND NOT EXISTS (SELECT 1 FROM VeThang v WHERE v.BienSo = l.BienSo AND v.TrangThai = N'Hoạt động' " +
                "                AND v.NgayHetHan >= CAST(GETDATE() AS DATE)) " +
                "GROUP BY l.BienSo, lx.TenLoai, b.GiaVeThang " +
                "HAVING SUM(l.Phi) >= @tiLe * b.GiaVeThang " +
                "ORDER BY SUM(l.Phi) - b.GiaVeThang DESC",
                r =>
                {
                    decimal tong = r.Gt<decimal>("TongPhi"), gia = r.Gt<decimal>("GiaVeThang");
                    return new GoiYVeThangDTO
                    {
                        BienSo = r.Gt<string>("BienSo"),
                        TenLoaiXe = r.Gt<string>("TenLoai"),
                        SoLuot = r.Gt<int>("SoLuot"),
                        TongPhi = tong,
                        GiaVeThang = gia,
                        ChenhLech = tong - gia
                    };
                },
                P("@ngay", soNgay), P("@tiLe", tiLe));
    }
}
