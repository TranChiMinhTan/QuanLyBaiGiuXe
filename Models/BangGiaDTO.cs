namespace QuanLyBaiGiuXe.Models
{
    public class BangGiaDTO
    {
        public int MaBangGia { get; set; }
        public int MaLoaiXe { get; set; }
        public string TenLoaiXe { get; set; }
        public int MienPhiPhut { get; set; }       // miễn phí N phút đầu
        public decimal GiaKhoi { get; set; }       // giá mỗi khối giờ
        public int SoGioKhoi { get; set; }        // một khối là bao nhiêu giờ
        public decimal PhuThuQuaDem { get; set; }  // phụ thu mỗi đêm
        public decimal GiaVeThang { get; set; }
    }
}
