// [SÁNG TẠO #6] Một dòng nhật ký thao tác.
using System;

namespace QuanLyBaiGiuXe.Models
{
    public class NhatKyDTO
    {
        public int MaNK { get; set; }
        public DateTime ThoiDiem { get; set; }
        public string TenDangNhap { get; set; }
        public string HanhDong { get; set; }
        public string ChiTiet { get; set; }
    }
}
