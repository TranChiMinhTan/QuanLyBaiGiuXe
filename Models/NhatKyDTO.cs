// Một dòng nhật ký thao tác (bảng NhatKy). FrmNhatKy hiển thị các cột ThoiDiem, TenDangNhap, HanhDong, ChiTiet.
using System;

namespace QuanLyBaiGiuXe.Models
{
    public class NhatKyDTO
    {
        public int MaNhatKy { get; set; }
        public DateTime ThoiDiem { get; set; }
        public string TenDangNhap { get; set; }
        public string HanhDong { get; set; }
        public string ChiTiet { get; set; }
    }
}
