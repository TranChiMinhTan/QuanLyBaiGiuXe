// Nghiệp vụ khách hàng. Trả về null = thành công, ngược lại là câu báo lỗi. Không dùng MessageBox.
using System;
using System.Collections.Generic;
using QuanLyBaiGiuXe.DAL;
using QuanLyBaiGiuXe.Models;

namespace QuanLyBaiGiuXe.BLL
{
    public class KhachHangBLL
    {
        private readonly KhachHangDAL _dal = new KhachHangDAL();

        public List<KhachHangDTO> LayTatCa(string tuKhoa) => _dal.LayTatCa(tuKhoa);
        public string TaoMaMoi() => _dal.TaoMaMoi();

        private static string KiemTraDuLieu(KhachHangDTO k)
        {
            k.HoTen = (k.HoTen ?? "").Trim();
            k.SDT = (k.SDT ?? "").Trim();
            k.CCCD = string.IsNullOrWhiteSpace(k.CCCD) ? null : k.CCCD.Trim();
            k.DiaChi = string.IsNullOrWhiteSpace(k.DiaChi) ? null : k.DiaChi.Trim();

            if (k.HoTen.Length == 0) return "Họ tên không được để trống.";
            if (k.HoTen.Length > 100) return "Họ tên tối đa 100 ký tự.";
            if (k.SDT.Length == 0) return "Số điện thoại không được để trống.";
            if (!KiemTra.SdtHopLe(k.SDT)) return "Số điện thoại không hợp lệ (bắt đầu bằng 0, gồm 10-11 chữ số).";
            if (k.CCCD != null && !KiemTra.CccdHopLe(k.CCCD)) return "CCCD phải gồm 12 chữ số (hoặc CMND 9 chữ số).";
            if (k.DiaChi != null && k.DiaChi.Length > 200) return "Địa chỉ tối đa 200 ký tự.";
            return null;
        }

        public string Them(KhachHangDTO k)
        {
            string loi = KiemTraDuLieu(k);
            if (loi != null) return loi;
            try
            {
                if (k.CCCD != null && _dal.TrungCCCD(k.CCCD, null)) return "CCCD này đã thuộc về một khách hàng khác.";
                k.MaKH = _dal.TaoMaMoi();            // luôn sinh lại lúc lưu để tránh trùng khi nhiều máy cùng thêm
                _dal.Them(k);
                return null;
            }
            catch (Exception ex) { return Database.DichLoi(ex); }
        }

        public string Sua(KhachHangDTO k)
        {
            if (string.IsNullOrWhiteSpace(k.MaKH)) return "Hãy chọn một khách hàng trong danh sách để sửa.";
            string loi = KiemTraDuLieu(k);
            if (loi != null) return loi;
            try
            {
                if (k.CCCD != null && _dal.TrungCCCD(k.CCCD, k.MaKH)) return "CCCD này đã thuộc về một khách hàng khác.";
                if (_dal.Sua(k) == 0) return "Không tìm thấy khách hàng cần sửa (có thể đã bị xóa).";
                return null;
            }
            catch (Exception ex) { return Database.DichLoi(ex); }
        }

        public string Xoa(string maKH)
        {
            if (string.IsNullOrWhiteSpace(maKH)) return "Hãy chọn một khách hàng trong danh sách để xóa.";
            try
            {
                if (_dal.CoVeThang(maKH)) return "Khách hàng đã có vé tháng nên không thể xóa.";
                if (_dal.Xoa(maKH) == 0) return "Không tìm thấy khách hàng cần xóa.";
                return null;
            }
            catch (Exception ex) { return Database.DichLoi(ex); }
        }
    }
}
