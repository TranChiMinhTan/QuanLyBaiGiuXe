// [Người 1] Loại xe. DangGui và ConTrong lấy từ stored procedure sp_SoChoTrong (Người 3).
namespace QuanLyBaiGiuXe.Models
{
    public class LoaiXeDTO
    {
        public int MaLoaiXe { get; set; }
        public string TenLoai { get; set; }
        public int SucChua { get; set; }
        public string MoTa { get; set; }
        public int DangGui { get; set; }
        public int ConTrong { get; set; }
    }
}