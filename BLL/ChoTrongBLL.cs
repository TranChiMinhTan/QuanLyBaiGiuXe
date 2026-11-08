// Số chỗ trống theo từng loại xe và tổng toàn bãi (hiển thị ở thanh trạng thái FrmMain).
using System.Collections.Generic;
using System.Linq;
using QuanLyBaiGiuXe.DAL;
using QuanLyBaiGiuXe.Models;

namespace QuanLyBaiGiuXe.BLL
{
    public class ChoTrongBLL
    {
        private readonly ChoTrongDAL _dal = new ChoTrongDAL();

        public List<ChoTrongDTO> TheoLoai() => _dal.Lay();

        public ChoTrongDTO TongHop()
        {
            var ds = _dal.Lay();
            return new ChoTrongDTO { TenLoai = "Tổng", SucChua = ds.Sum(x => x.SucChua), DangGui = ds.Sum(x => x.DangGui) };
        }
    }
}
