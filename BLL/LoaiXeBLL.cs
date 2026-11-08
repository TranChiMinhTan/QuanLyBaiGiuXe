// Nghiệp vụ loại xe. Quy tắc kiểm tra lấy từ Dự án B (_Legacy/BLL/LoaiXeBLL.cs).
// Trả về null = thành công, ngược lại là câu báo lỗi. Không dùng MessageBox.
using System;
using System.Collections.Generic;
using QuanLyBaiGiuXe.DAL;
using QuanLyBaiGiuXe.Models;

namespace QuanLyBaiGiuXe.BLL
{
    public class LoaiXeBLL
    {
        private readonly LoaiXeDAL _dal = new LoaiXeDAL();
        private readonly ChoTrongDAL _choDal = new ChoTrongDAL();

        /// <summary>Kèm số xe đang gửi và chỗ còn trống (từ sp_SoChoTrong).</summary>
        public List<LoaiXeDTO> LayTatCa(string tuKhoa)
        {
            var ds = _dal.LayTatCa(tuKhoa);
            var cho = new Dictionary<int, ChoTrongDTO>();
            foreach (var c in _choDal.LayTheoLoaiXe()) cho[c.MaLoaiXe] = c;
            foreach (var x in ds)
            {
                ChoTrongDTO c;
                if (cho.TryGetValue(x.MaLoaiXe, out c)) { x.DangGui = c.DangGui; x.ConTrong = c.ConTrong; }
                else { x.DangGui = 0; x.ConTrong = x.SucChua; }
            }
            return ds;
        }

        private static string KiemTraDuLieu(LoaiXeDTO x)
        {
            x.TenLoai = (x.TenLoai ?? "").Trim();
            x.MoTa = (x.MoTa ?? "").Trim();
            if (x.TenLoai.Length == 0) return "Tên loại xe không được để trống.";
            if (x.TenLoai.Length > 50) return "Tên loại xe tối đa 50 ký tự.";
            if (x.MoTa.Length > 200) return "Mô tả tối đa 200 ký tự.";
            if (x.SucChua < 0) return "Sức chứa không được âm.";
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
                return null;
            }
            catch (Exception ex) { return Database.DichLoi(ex); }
        }

        public string Xoa(int maLoaiXe)
        {
            if (maLoaiXe <= 0) return "Hãy chọn một loại xe trong danh sách để xóa.";
            try
            {
                if (_dal.DangDuocDung(maLoaiXe))
                    return "Loại xe đang được dùng bởi thẻ xe, lượt gửi hoặc vé tháng nên không thể xóa.";
                _dal.Xoa(maLoaiXe);
                return null;
            }
            catch (Exception ex) { return Database.DichLoi(ex); }
        }
    }
}
