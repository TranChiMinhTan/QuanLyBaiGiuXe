// [Người 4 — BẢN NHÁP do Người 2 viết để project biên dịch được. Chủ module có thể sửa tự do.]
namespace QuanLyBaiGiuXe.Models
{
    public class DoanhThuDTO
    {
        public string Nhan { get; set; }           // "26/10" hoặc "10/2026"
        public int SoLuot { get; set; }
        public decimal DoanhThu { get; set; }
    }
}
