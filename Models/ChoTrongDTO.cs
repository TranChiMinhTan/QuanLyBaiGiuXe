// Số chỗ của một loại xe (từ sp_SoChoTrong) và tổng hợp toàn bãi cho thanh trạng thái FrmMain.
namespace QuanLyBaiGiuXe.Models
{
    public class ChoTrongDTO
    {
        public int MaLoaiXe { get; set; }
        public string TenLoai { get; set; }
        public int SucChua { get; set; }
        public int DangGui { get; set; }
        public int ConTrong => SucChua - DangGui < 0 ? 0 : SucChua - DangGui;
    }

    public class TongHopChoDTO
    {
        public int SucChua { get; set; }
        public int DangGui { get; set; }
        public int ConTrong => SucChua - DangGui < 0 ? 0 : SucChua - DangGui;
    }
}
