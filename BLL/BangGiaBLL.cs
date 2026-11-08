using System;
using System.Collections.Generic;
using QuanLyBaiGiuXe.DAL;
using QuanLyBaiGiuXe.Models;

namespace QuanLyBaiGiuXe.BLL
{
    public class BangGiaBLL
    {
        private readonly BangGiaDAL _dal = new BangGiaDAL();

        public List<BangGiaDTO> LayTatCa() => _dal.LayTatCa();

        private static string KiemTraDuLieu(BangGiaDTO g)
        {
            if (g.MaLoaiXe <= 0) return "Vui lòng chọn loại xe.";
            if (g.MienPhiPhut < 0 || g.MienPhiPhut > 240) return "Số phút miễn phí phải từ 0 đến 240.";
            if (g.GiaKhoi <= 0) return "Giá mỗi khối phải lớn hơn 0.";
            if (g.SoGioKhoi < 1 || g.SoGioKhoi > 24) return "Số giờ mỗi khối phải từ 1 đến 24.";
            if (g.PhuThuQuaDem < 0) return "Phụ thu qua đêm không được âm.";
            if (g.GiaVeThang <= 0) return "Giá vé tháng phải lớn hơn 0.";
            return null;
        }

        public string Them(BangGiaDTO g)
        {
            string loi = KiemTraDuLieu(g);
            if (loi != null) return loi;
            try
            {
                if (_dal.LayTheoLoaiXe(g.MaLoaiXe) != null)
                    return "Loại xe này đã có bảng giá. Hãy chọn dòng đó và bấm Cập nhật.";
                _dal.Them(g);
                NhatKyBLL.Ghi("Thêm bảng giá", "Loại xe " + g.MaLoaiXe + ": " + g.GiaKhoi.ToString("N0") + " đ/" + g.SoGioKhoi + " giờ");
                return null;
            }
            catch (Exception ex) { return Database.DichLoi(ex); }
        }

        public string CapNhat(BangGiaDTO g)
        {
            string loi = KiemTraDuLieu(g);
            if (loi != null) return loi;
            try
            {
                var cu = _dal.LayTheoLoaiXe(g.MaLoaiXe);
                if (cu == null) return "Loại xe này chưa có bảng giá. Hãy bấm Thêm.";
                _dal.Sua(g);
                NhatKyBLL.Ghi("Sửa bảng giá", cu.TenLoaiXe + ": giá khối " + cu.GiaKhoi.ToString("N0") + " -> " + g.GiaKhoi.ToString("N0") +
                              ", phụ thu đêm " + cu.PhuThuQuaDem.ToString("N0") + " -> " + g.PhuThuQuaDem.ToString("N0"));
                return null;
            }
            catch (Exception ex) { return Database.DichLoi(ex); }
        }

        public string Xoa(int maLoaiXe)
        {
            if (maLoaiXe <= 0) return "Hãy chọn một dòng trong danh sách để xóa.";
            try
            {
                _dal.Xoa(maLoaiXe);
                NhatKyBLL.Ghi("Xóa bảng giá", "Loại xe " + maLoaiXe);
                return null;
            }
            catch (Exception ex) { return Database.DichLoi(ex); }
        }
    }
}
