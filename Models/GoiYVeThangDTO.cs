// Khách gửi lẻ nhiều nên nên mời đăng ký vé tháng. Các cột khớp FrmGoiYVeThang.
namespace QuanLyBaiGiuXe.Models
{
    public class GoiYVeThangDTO
    {
        public string BienSo { get; set; }
        public string TenLoaiXe { get; set; }
        public int SoLuot { get; set; }             // số lượt gửi lẻ trong 30 ngày qua
        public decimal TongPhi { get; set; }        // tổng phí gửi lẻ trong 30 ngày qua
        public decimal GiaVeThang { get; set; }
        /// <summary>TongPhi - GiaVeThang: dương = mua vé tháng sẽ rẻ hơn chừng đó.</summary>
        public decimal ChenhLech { get; set; }
    }
}
