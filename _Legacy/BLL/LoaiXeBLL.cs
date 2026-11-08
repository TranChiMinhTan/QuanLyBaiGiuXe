using System.Collections.Generic;
using QuanLyBaiXe.DAL;
using QuanLyBaiXe.DTO;

namespace QuanLyBaiXe.BLL
{
    public class LoaiXeBLL
    {
        private readonly LoaiXeDAL dal = new LoaiXeDAL();

        public List<LoaiXeDTO> LayTatCa()
        {
            return dal.LayTatCa();
        }

        private static string KiemTra(LoaiXeDTO x)
        {
            x.TenLoaiXe = (x.TenLoaiXe ?? "").Trim();
            x.MoTa = (x.MoTa ?? "").Trim();

            if (x.TenLoaiXe.Length == 0) return "Tên loại xe không được để trống.";
            if (x.TenLoaiXe.Length > 50) return "Tên loại xe tối đa 50 ký tự.";
            if (x.MoTa.Length > 200) return "Mô tả tối đa 200 ký tự.";
            if (x.SucChua < 0) return "Sức chứa không được âm.";
            return null;
        }

        public KetQua Them(LoaiXeDTO x)
        {
            return KetQua.Chay(() =>
            {
                string loi = KiemTra(x);
                if (loi != null) return KetQua.Loi(loi);
                if (dal.TonTaiTen(x.TenLoaiXe, 0)) return KetQua.Loi("Tên loại xe đã tồn tại.");

                dal.Them(x);
                return KetQua.OK("Thêm loại xe thành công.");
            });
        }

        public KetQua Sua(LoaiXeDTO x)
        {
            return KetQua.Chay(() =>
            {
                string loi = KiemTra(x);
                if (loi != null) return KetQua.Loi(loi);
                if (dal.TonTaiTen(x.TenLoaiXe, x.MaLoaiXe)) return KetQua.Loi("Tên loại xe đã tồn tại.");

                if (dal.Sua(x) == 0) return KetQua.Loi("Không tìm thấy loại xe cần sửa (có thể đã bị xóa).");
                return KetQua.OK("Cập nhật loại xe thành công.");
            });
        }

        public KetQua Xoa(int maLoaiXe)
        {
            return KetQua.Chay(() =>
            {
                if (dal.DangDuocSuDung(maLoaiXe))
                    return KetQua.Loi("Loại xe đang được dùng bởi thẻ xe, bảng giá hoặc vé tháng nên không thể xóa.");

                if (dal.Xoa(maLoaiXe) == 0) return KetQua.Loi("Không tìm thấy loại xe cần xóa.");
                return KetQua.OK("Xóa loại xe thành công.");
            });
        }
    }
}
