// [Người 3] Vé tháng. TinhTrang tính từ ngày hết hạn và trạng thái hủy.
using System;

namespace QuanLyBaiGiuXe.Models
{
    public class VeThangDTO
    {
        public int MaVe { get; set; }
        public string BienSo { get; set; }
        public string MaKH { get; set; }
        public string HoTenKhach { get; set; }
        public int MaLoaiXe { get; set; }
        public string TenLoaiXe { get; set; }
        public DateTime NgayDangKy { get; set; }
        public DateTime NgayHetHan { get; set; }
        public decimal PhiDangKy { get; set; }
        public string TrangThai { get; set; }       // "Hoạt động" / "Đã hủy"

        public int ConLai => (NgayHetHan.Date - DateTime.Today).Days;
        public string TinhTrang
        {
            get
            {
                if (TrangThai == "Đã hủy") return "Đã hủy";
                if (ConLai < 0) return "Hết hạn";
                if (ConLai <= 7) return "Sắp hết hạn";
                return "Còn hạn";
            }
        }
    }
}