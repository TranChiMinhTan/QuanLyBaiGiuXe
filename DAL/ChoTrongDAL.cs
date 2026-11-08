// Số chỗ trống theo loại xe, gọi STORED PROCEDURE sp_SoChoTrong.
using System.Collections.Generic;
using QuanLyBaiGiuXe.Models;
using static QuanLyBaiGiuXe.DAL.Database;

namespace QuanLyBaiGiuXe.DAL
{
    public class ChoTrongDAL
    {
        public List<ChoTrongDTO> Lay()
            => GoiProc<ChoTrongDTO>("sp_SoChoTrong", r => new ChoTrongDTO
            {
                MaLoaiXe = r.Gt<int>("MaLoaiXe"), TenLoai = r.Gt<string>("TenLoai"),
                SucChua = r.Gt<int>("SucChua"), DangGui = r.Gt<int>("DangGui")
            });
    }
}
