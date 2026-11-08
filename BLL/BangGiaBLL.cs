// Nghiệp vụ bảng giá (mô hình B+). Quy tắc kiểm tra lấy từ Dự án B (_Legacy/BLL/BangGiaBLL.cs).
// Mỗi loại xe có đúng một bảng giá hiện hành. Trả về null = thành công, ngược lại là câu báo lỗi.
using System;
using System.Collections.Generic;
using QuanLyBaiGiuXe.DAL;
using QuanLyBaiGiuXe.Models;

namespace QuanLyBaiGiuXe.BLL
{
    public class BangGiaBLL
    {
        private readonly BangGiaDAL _dal = new BangGiaDAL();
        private readonly LoaiXeDAL _loaiXeDal = new LoaiXeDAL();

        public List<BangGiaDTO> LayTatCa() => _dal.LayTatCa();
        public List<LoaiXeDTO> LayLoaiXe() => _loaiXeDal.LayTatCa();
        public BangGiaDTO LayTheoLoaiXe(int maLoaiXe) => _dal.LayTheoLoaiXe(maLoaiXe);

        private static string KiemTraDuLieu(BangGiaDTO g)
        {
            if (g.MaLoaiXe <= 0) return "Vui lòng chọn loại xe.";
            if (g.MienPhiPhut < 0 || g.MienPhiPhut >= 24 * 60) return "Số phút miễn phí phải từ 0 đến dưới 1440.";
            if (g.GiaGioDau <= 0) return "Giá giờ đầu phải lớn hơn 0.";
            if (g.GiaGioTiepTheo < 0) return "Giá giờ tiếp theo không được âm.";
            if (g.GiaToiDaNgay < g.GiaGioDau) return "Giá tối đa theo ngày không được nhỏ hơn giá giờ đầu.";
            if (g.GiaVeThang <= 0) return "Giá vé tháng phải lớn hơn 0.";
            return null;
        }

        public string Them(BangGiaDTO g)
        {
            string loi = KiemTraDuLieu(g);
            if (loi != null) return loi;
            try
            {
                if (_dal.DaCoGia(g.MaLoaiXe)) return "Loại xe này đã có bảng giá. Hãy chọn dòng đó và bấm Cập nhật.";
                _dal.Them(g);
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
                if (_dal.Sua(g) == 0) return "Loại xe này chưa có bảng giá để cập nhật. Hãy bấm Thêm.";
                return null;
            }
            catch (Exception ex) { return Database.DichLoi(ex); }
        }

        public string Xoa(int maLoaiXe)
        {
            if (maLoaiXe <= 0) return "Hãy chọn một bảng giá trong danh sách để xóa.";
            try
            {
                if (_dal.Xoa(maLoaiXe) == 0) return "Không tìm thấy bảng giá cần xóa.";
                return null;
            }
            catch (Exception ex) { return Database.DichLoi(ex); }
        }
    }
}
