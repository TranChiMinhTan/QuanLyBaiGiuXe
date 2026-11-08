//  Nghiệp vụ thẻ xe.
using System;
using System.Collections.Generic;
using QuanLyBaiGiuXe.DAL;
using QuanLyBaiGiuXe.Models;

namespace QuanLyBaiGiuXe.BLL
{
    public class TheXeBLL
    {
        private readonly TheXeDAL _dal = new TheXeDAL();
        private static readonly string[] TrangThaiHopLe = { "Đang trống", "Đang dùng", "Đã mất" };

        public List<TheXeDTO> LayTatCa(string tuKhoa) => _dal.LayTatCa(tuKhoa);

        private static string KiemTraDuLieu(TheXeDTO t)
        {
            t.MaThe = (t.MaThe ?? "").Trim().ToUpper();
            if (t.MaThe.Length == 0) return "Mã thẻ không được để trống.";
            if (!KiemTra.MaTheHopLe(t.MaThe)) return "Mã thẻ chỉ gồm chữ và số, dài 2 đến 10 ký tự (ví dụ T001).";
            if (t.MaLoaiXe <= 0) return "Vui lòng chọn loại thẻ.";
            if (Array.IndexOf(TrangThaiHopLe, t.TrangThai) < 0) return "Trạng thái không hợp lệ.";
            if (t.NgayCap.Date > DateTime.Today) return "Ngày cấp không được ở tương lai.";
            return null;
        }

        public string Them(TheXeDTO t)
        {
            string loi = KiemTraDuLieu(t);
            if (loi != null) return loi;
            try
            {
                if (_dal.LayTheoMa(t.MaThe) != null) return "Mã thẻ " + t.MaThe + " đã tồn tại.";
                if (t.TrangThai == "Đang dùng") return "Thẻ mới không thể ở trạng thái Đang dùng (chỉ đổi khi có xe vào).";
                _dal.Them(t);
                NhatKyBLL.Ghi("Thêm thẻ xe", t.MaThe);
                return null;
            }
            catch (Exception ex) { return Database.DichLoi(ex); }
        }

        public string Sua(TheXeDTO t)
        {
            string loi = KiemTraDuLieu(t);
            if (loi != null) return loi;
            try
            {
                var cu = _dal.LayTheoMa(t.MaThe);
                if (cu == null) return "Hãy chọn một thẻ trong danh sách để sửa.";
                if (cu.BienSoDangGui != null)
                    return "Thẻ đang có xe " + cu.BienSoDangGui + " gửi trong bãi, không được sửa. Hãy cho xe ra trước.";
                if (t.TrangThai == "Đang dùng") return "Trạng thái Đang dùng do hệ thống tự đặt khi có xe vào.";
                _dal.Sua(t);
                NhatKyBLL.Ghi("Sửa thẻ xe", t.MaThe + " -> " + t.TrangThai);
                return null;
            }
            catch (Exception ex) { return Database.DichLoi(ex); }
        }

        public string Xoa(string maThe)
        {
            if (string.IsNullOrWhiteSpace(maThe)) return "Hãy chọn một thẻ trong danh sách để xóa.";
            try
            {
                if (_dal.CoLuotGui(maThe)) return "Không thể xóa thẻ đã có lịch sử lượt gửi. Hãy đổi trạng thái thành Đã mất.";
                _dal.Xoa(maThe);
                NhatKyBLL.Ghi("Xóa thẻ xe", maThe);
                return null;
            }
            catch (Exception ex) { return Database.DichLoi(ex); }
        }
    }
}
