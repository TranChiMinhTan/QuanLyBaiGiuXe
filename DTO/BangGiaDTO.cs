using System;

namespace QuanLyBaiXe.DTO
{
    public class BangGiaDTO
    {
        public int MaBangGia { get; set; }
        public int MaLoaiXe { get; set; }
        public string TenLoaiXe { get; set; }       // chỉ để hiển thị (JOIN LoaiXe)
        public decimal GiaGioDau { get; set; }
        public decimal GiaGioTiepTheo { get; set; }
        public decimal GiaToiDaNgay { get; set; }
        public decimal GiaVeThang { get; set; }
        public DateTime NgayApDung { get; set; }
        public bool ConHieuLuc { get; set; }
    }
}
