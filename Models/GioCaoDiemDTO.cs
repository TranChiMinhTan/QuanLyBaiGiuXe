// Số lượt xe vào theo từng giờ trong ngày (0..23). FrmGioCaoDiem dùng Gio và SoLuot.
namespace QuanLyBaiGiuXe.Models
{
    public class GioCaoDiemDTO
    {
        public int Gio { get; set; }        // 0..23
        public int SoLuot { get; set; }
    }
}
