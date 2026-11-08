// Bảng giá theo mô hình B+ (xem docs/MO_HINH_TINH_PHI.md): giờ đầu + giờ tiếp theo + trần mỗi 24 giờ + miễn phí N phút đầu.
// Mỗi loại xe có đúng một dòng bảng giá hiện hành.
namespace QuanLyBaiGiuXe.Models
{
    public class BangGiaDTO
    {
        public int MaBangGia { get; set; }
        public int MaLoaiXe { get; set; }
        public string TenLoaiXe { get; set; }
        public int MienPhiPhut { get; set; }           // miễn phí N phút đầu (0 = không miễn phí)
        public decimal GiaGioDau { get; set; }         // giá giờ đầu tiên
        public decimal GiaGioTiepTheo { get; set; }    // giá mỗi giờ tiếp theo (làm tròn lên)
        public decimal GiaToiDaNgay { get; set; }      // trần cho mỗi khối 24 giờ
        public decimal GiaVeThang { get; set; }
    }
}
