// Số chỗ theo loại xe, lấy từ stored procedure sp_SoChoTrong (xem Database/01_Migration.sql).
using System.Collections.Generic;
using QuanLyBaiGiuXe.Models;
using static QuanLyBaiGiuXe.DAL.Database;

namespace QuanLyBaiGiuXe.DAL
{
    public class ChoTrongDAL
    {
        public List<ChoTrongDTO> LayTheoLoaiXe()
            => GoiProc<ChoTrongDTO>("sp_SoChoTrong", r => new ChoTrongDTO
            {
                MaLoaiXe = r.Gt<int>("MaLoaiXe"),
                TenLoai = r.Gt<string>("TenLoai"),
                SucChua = r.Gt<int>("SucChua"),
                DangGui = r.Gt<int>("DangGui")
            });
    }
}
