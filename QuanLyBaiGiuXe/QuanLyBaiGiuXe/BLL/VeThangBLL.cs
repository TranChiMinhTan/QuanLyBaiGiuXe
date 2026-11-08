// [Người 3 — BẢN TẠM, chỉ có KiemTraVeThang. Người 3 thay bằng bản đầy đủ, GIỮ NGUYÊN chữ ký hàm này.]
using QuanLyBaiXe.DAL;
using QuanLyBaiXe.Models;

namespace QuanLyBaiXe.BLL
{
    public class VeThangBLL
    {
        private readonly VeThangDAL _dal = new VeThangDAL();

        /// <summary>Trả về vé tháng gần nhất của biển số (còn hạn hay hết hạn đều trả về), null nếu chưa từng đăng ký.</summary>
        public VeThangDTO KiemTraVeThang(string bienSo) => _dal.LayMoiNhatTheoBienSo(bienSo);
    }
}
