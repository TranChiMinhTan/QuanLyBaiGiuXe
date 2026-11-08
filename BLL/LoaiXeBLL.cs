// Nghiệp vụ loại xe. Các hàm ghi dữ liệu trả về chuỗi lỗi, null nghĩa là thành công.
using System;
using System.Collections.Generic;
using System.Linq;
using QuanLyBaiGiuXe.DAL;
using QuanLyBaiGiuXe.Models;

namespace QuanLyBaiGiuXe.BLL
{
    public class LoaiXeBLL
    {
        private readonly LoaiXeDAL _dal = new LoaiXeDAL();
        private readonly ChoTrongDAL _cho = new ChoTrongDAL();

        public List<LoaiXeDTO> LayTatCa(string tuKhoa = null)
        {
            var ds = _dal.LayTatCa(tuKhoa);
            try
            {
                var cho = _cho.Lay();
                foreach (var x in ds)
                {
                    var c = cho.FirstOrDefault(k => k.MaLoaiXe == x.MaLoaiXe);
                    if (c != null) { x.DangGui = c.DangGui; x.ConTrong = c.ConTrong; }
                }
            }
            catch { }
            return ds;
        }

        private static string KiemTraDuLieu(LoaiXeDTO x)
        {
            if (string.IsNullOrWhiteSpace(x.TenLoai)) return "Tên loại xe không được để trống.";
            if (x.TenLoai.Trim().Length > 50) return "Tên loại xe tối đa 50 ký tự.";
            if (x.SucChua < 1 || x.SucChua > 500) return "Sức chứa phải từ 1 đến 500.";
            x.TenLoai = x.TenLoai.Trim();
            return null;
        }

        public string Them(LoaiXeDTO x)
        {
            string loi = KiemTraDuLieu(x);
            if (loi != null) return loi;
            try
            {
                if (_dal.TrungTen(x.TenLoai, 0)) return "Tên loại xe đã tồn tại.";
                _dal.Them(x);
                NhatKyBLL.Ghi("Thêm loại xe", x.TenLoai);
                return null;
            }
            catch (Exception ex) { return Database.DichLoi(ex); }
        }

        public string Sua(LoaiXeDTO x)
        {
            if (x.MaLoaiXe <= 0) return "Hãy chọn một loại xe trong danh sách để sửa.";
            string loi = KiemTraDuLieu(x);
            if (loi != null) return loi;
            try
            {
                if (_dal.TrungTen(x.TenLoai, x.MaLoaiXe)) return "Tên loại xe đã tồn tại.";
                _dal.Sua(x);
                NhatKyBLL.Ghi("Sửa loại xe", x.TenLoai);
                return null;
            }
            catch (Exception ex) { return Database.DichLoi(ex); }
        }

        public string Xoa(int ma, string ten)
        {
            if (ma <= 0) return "Hãy chọn một loại xe trong danh sách để xóa.";
            try
            {
                if (_dal.DangDuocDung(ma)) return "Không thể xóa: loại xe đã có thẻ, lượt gửi hoặc vé tháng.";
                _dal.Xoa(ma);
                NhatKyBLL.Ghi("Xóa loại xe", ten);
                return null;
            }
            catch (Exception ex) { return Database.DichLoi(ex); }
        }
    }
}
