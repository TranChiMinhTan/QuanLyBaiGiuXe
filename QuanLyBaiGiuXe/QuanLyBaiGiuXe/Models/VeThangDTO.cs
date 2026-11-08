// [Người 3 — BẢN NHÁP do Người 2 viết để project biên dịch được. Chủ module có thể sửa tự do.]
using System;
namespace QuanLyBaiXe.Models
{
    public class VeThangDTO
    {
        public int MaVe { get; set; }
        public string BienSo { get; set; }
        public string MaKH { get; set; }
        public string HoTenKhach { get; set; }
        public int MaLoaiXe { get; set; }
        public DateTime NgayDangKy { get; set; }
        public DateTime NgayHetHan { get; set; }
        public decimal PhiDangKy { get; set; }
        public int ConLai => (NgayHetHan.Date - DateTime.Today).Days;
    }
}
