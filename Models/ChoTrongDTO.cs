// Số chỗ trống theo loại xe (kết quả của stored procedure sp_SoChoTrong).
namespace QuanLyBaiGiuXe.Models
{
    public class ChoTrongDTO
    {
        public int MaLoaiXe { get; set; }
        public string TenLoai { get; set; }
        public int SucChua { get; set; }
        public int DangGui { get; set; }
        public int ConTrong => SucChua - DangGui;
    }
}
