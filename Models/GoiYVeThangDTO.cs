// [SÁNG TẠO #7] Khách gửi lẻ nhiều, nên được gợi ý đăng ký vé tháng.
namespace QuanLyBaiGiuXe.Models
{
    public class GoiYVeThangDTO
    {
        public string BienSo { get; set; }
        public string TenLoaiXe { get; set; }
        public int SoLuot { get; set; }
        public decimal TongPhi { get; set; }
        public decimal GiaVeThang { get; set; }
        public decimal ChenhLech => TongPhi - GiaVeThang;   // dương = đã trả lẻ nhiều hơn giá vé tháng; âm = còn thấp hơn một chút (nhưng đã đạt từ 80%)
    }
}
