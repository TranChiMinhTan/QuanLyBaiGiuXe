// [Người 1 — BẢN NHÁP do Người 2 viết để project biên dịch được. Chủ module có thể sửa tự do.]
using System;
namespace QuanLyBaiXe.Models
{
    public class TheXeDTO
    {
        public string MaThe { get; set; }
        public int MaLoaiXe { get; set; }
        public string TenLoaiXe { get; set; }
        public string TrangThai { get; set; }      // "Đang trống" / "Đang dùng" / "Đã mất"
        public DateTime NgayCap { get; set; }
    }
}
