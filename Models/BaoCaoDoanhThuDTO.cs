//Kết quả báo cáo doanh thu. DoanhThuDTO (của Người 2 viết nháp) giữ nguyên, không sửa.
using System;
using System.Collections.Generic;

namespace QuanLyBaiXe.Models
{
    /// <summary>Một kỳ (ngày hoặc tháng) đọc thẳng từ stored procedure sp_BaoCaoDoanhThu.</summary>
    public class DoanhThuKyDTO
    {
        public DateTime Ky { get; set; }           // ngày, hoặc mùng 1 của tháng
        public int SoLuot { get; set; }            // số lượt xe ra (có ghi thanh toán)
        public decimal TienLuotGui { get; set; }   // từ bảng ThanhToan
        public decimal TienVeThang { get; set; }   // từ bảng VeThang (PhiDangKy theo NgayDangKy)
    }

    /// <summary>Toàn bộ báo cáo: các dòng cho bảng/biểu đồ và tổng theo từng nguồn thu.</summary>
    public class BaoCaoDoanhThuDTO
    {
        public List<DoanhThuDTO> Dong { get; set; } = new List<DoanhThuDTO>();
        public decimal TongLuotGui { get; set; }
        public decimal TongVeThang { get; set; }
        public decimal TongDoanhThu => TongLuotGui + TongVeThang;
    }
}