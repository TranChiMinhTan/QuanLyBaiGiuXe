// Số chỗ trống: theo từng loại xe và tổng hợp toàn bãi (thanh trạng thái FrmMain, màn Loại xe).
using System.Collections.Generic;
using System.Linq;
using QuanLyBaiGiuXe.DAL;
using QuanLyBaiGiuXe.Models;

namespace QuanLyBaiGiuXe.BLL
{
    public class ChoTrongBLL
    {
        private readonly ChoTrongDAL _dal = new ChoTrongDAL();

        public List<ChoTrongDTO> LayTheoLoaiXe() => _dal.LayTheoLoaiXe();

        public TongHopChoDTO TongHop()
        {
            var ds = _dal.LayTheoLoaiXe();
            return new TongHopChoDTO { SucChua = ds.Sum(x => x.SucChua), DangGui = ds.Sum(x => x.DangGui) };
        }
    }
}
