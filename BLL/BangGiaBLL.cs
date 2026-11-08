using System.Collections.Generic;
using QuanLyBaiXe.DAL;
using QuanLyBaiXe.DTO;

namespace QuanLyBaiXe.BLL
{
    public class BangGiaBLL
    {
        private readonly BangGiaDAL dal = new BangGiaDAL();

        public List<BangGiaDTO> LayTatCa()
        {
            return dal.LayTatCa();
        }

        /// <summary>Người 2 dùng để tính phí gửi xe. Trả về null nếu loại xe chưa có bảng giá.</summary>
        public BangGiaDTO LayHieuLucTheoLoai(int maLoaiXe)
        {
            return dal.LayHieuLucTheoLoai(maLoaiXe);
        }

        private static string KiemTra(BangGiaDTO g)
        {
            if (g.MaLoaiXe <= 0) return "Vui lòng chọn loại xe.";
            if (g.GiaGioDau <= 0) return "Giá giờ đầu phải lớn hơn 0.";
            if (g.GiaGioTiepTheo < 0) return "Giá giờ tiếp theo không được âm.";
            if (g.GiaToiDaNgay < g.GiaGioDau) return "Giá tối đa theo ngày không được nhỏ hơn giá giờ đầu.";
            if (g.GiaVeThang <= 0) return "Giá vé tháng phải lớn hơn 0.";
            return null;
        }

        public KetQua Them(BangGiaDTO g)
        {
            return KetQua.Chay(() =>
            {
                string loi = KiemTra(g);
                if (loi != null) return KetQua.Loi(loi);

                dal.Them(g);
                return KetQua.OK("Thêm bảng giá thành công." +
                    (g.ConHieuLuc ? " Các bảng giá cũ của loại xe này đã được tắt hiệu lực." : ""));
            });
        }

        public KetQua Sua(BangGiaDTO g)
        {
            return KetQua.Chay(() =>
            {
                string loi = KiemTra(g);
                if (loi != null) return KetQua.Loi(loi);

                if (dal.Sua(g) == 0) return KetQua.Loi("Không tìm thấy bảng giá cần sửa.");
                return KetQua.OK("Cập nhật bảng giá thành công.");
            });
        }

        public KetQua Xoa(int maBangGia)
        {
            return KetQua.Chay(() =>
            {
                if (dal.Xoa(maBangGia) == 0) return KetQua.Loi("Không tìm thấy bảng giá cần xóa.");
                return KetQua.OK("Xóa bảng giá thành công.");
            });
        }
    }
}
