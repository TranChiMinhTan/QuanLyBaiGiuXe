// Nghiệp vụ thẻ xe. Quy tắc lấy từ Dự án B (_Legacy/BLL/TheXeBLL.cs), áp dụng 4 trạng thái của TrangThaiThe.
// "Đang dùng" chỉ do LuotGuiDAL đặt khi xe vào; người dùng không đặt/ bỏ thủ công.
using System;
using System.Collections.Generic;
using QuanLyBaiGiuXe.DAL;
using QuanLyBaiGiuXe.Models;

namespace QuanLyBaiGiuXe.BLL
{
    public class TheXeBLL
    {
        private readonly TheXeDAL _dal = new TheXeDAL();

        public List<TheXeDTO> LayTatCa(string tuKhoa) => _dal.LayTatCa(tuKhoa);

        private static string KiemTraDuLieu(TheXeDTO t)
        {
            t.MaThe = (t.MaThe ?? "").Trim().ToUpper();
            if (t.MaThe.Length == 0) return "Mã thẻ không được để trống.";
            if (!KiemTra.MaTheHopLe(t.MaThe)) return "Mã thẻ gồm 3-20 ký tự chữ, số hoặc dấu gạch ngang, không có khoảng trắng.";
            if (t.MaLoaiXe <= 0) return "Vui lòng chọn loại xe.";
            if (!TrangThaiThe.HopLe(t.TrangThai)) return "Trạng thái thẻ không hợp lệ.";
            if (t.NgayCap.Date > DateTime.Today) return "Ngày cấp không được ở tương lai.";
            return null;
        }

        public string Them(TheXeDTO t)
        {
            string loi = KiemTraDuLieu(t);
            if (loi != null) return loi;
            if (t.TrangThai == TrangThaiThe.DangDung)
                return "Trạng thái \"Đang dùng\" do hệ thống tự cập nhật khi xe vào, không đặt thủ công.";
            try
            {
                if (_dal.LayTheoMa(t.MaThe) != null) return "Mã thẻ đã tồn tại.";
                _dal.Them(t);
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
                TheXeDTO hienTai = _dal.LayTheoMa(t.MaThe);
                if (hienTai == null) return "Không tìm thấy thẻ xe cần sửa.";

                bool dangCoXe = hienTai.TrangThai == TrangThaiThe.DangDung;
                if (!dangCoXe && t.TrangThai == TrangThaiThe.DangDung)
                    return "Trạng thái \"Đang dùng\" do hệ thống tự cập nhật khi xe vào, không đặt thủ công.";
                if (dangCoXe && t.TrangThai != TrangThaiThe.DangDung)
                    return "Thẻ đang có xe gửi, không thể đổi trạng thái. Hãy cho xe ra trước.";
                if (dangCoXe && t.MaLoaiXe != hienTai.MaLoaiXe)
                    return "Thẻ đang có xe gửi, không thể đổi loại xe.";

                _dal.Sua(t);
                return null;
            }
            catch (Exception ex) { return Database.DichLoi(ex); }
        }

        public string Xoa(string maThe)
        {
            maThe = (maThe ?? "").Trim().ToUpper();
            if (maThe.Length == 0) return "Hãy chọn một thẻ trong danh sách để xóa.";
            try
            {
                var the = _dal.LayTheoMa(maThe);
                if (the == null) return "Không tìm thấy thẻ xe cần xóa.";
                if (the.TrangThai == TrangThaiThe.DangDung) return "Thẻ đang có xe gửi, không thể xóa.";
                if (_dal.CoLuotGui(maThe))
                    return "Thẻ đã có lịch sử lượt gửi nên không thể xóa. Hãy chuyển trạng thái sang \"Khóa\" hoặc \"Đã mất\".";
                _dal.Xoa(maThe);
                return null;
            }
            catch (Exception ex) { return Database.DichLoi(ex); }
        }
    }
}
