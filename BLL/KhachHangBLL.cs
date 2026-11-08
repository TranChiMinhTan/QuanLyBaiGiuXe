// Nghiệp vụ khách hàng.
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
        public string SinhMaMoi() { try { return _dal.SinhMaMoi(); } catch { return "KH001"; } }

        private string KiemTraDuLieu(KhachHangDTO k)
        {
            k.HoTen = (k.HoTen ?? "").Trim();
            k.SDT = (k.SDT ?? "").Trim();
            k.CCCD = (k.CCCD ?? "").Trim();
            k.DiaChi = (k.DiaChi ?? "").Trim();
            if (k.HoTen.Length == 0) return "Họ tên không được để trống.";
            if (k.HoTen.Length > 100) return "Họ tên tối đa 100 ký tự.";
            if (!KiemTra.SdtHopLe(k.SDT)) return "Số điện thoại phải bắt đầu bằng 0 và có 10 hoặc 11 chữ số.";
            if (!KiemTra.CccdHopLe(k.CCCD)) return "CCCD phải gồm 9 hoặc 12 chữ số.";
            if (k.DiaChi.Length > 200) return "Địa chỉ tối đa 200 ký tự.";
            return null;
        }

        public string Them(KhachHangDTO k)
        {
            string loi = KiemTraDuLieu(k);
            if (loi != null) return loi;
            try
            {
                if (_dal.TrungCccd(k.CCCD, null)) return "CCCD này đã thuộc về một khách hàng khác.";
                k.MaKH = _dal.SinhMaMoi();                      // luôn sinh mã ở đây để không bị trùng khi nhiều máy cùng nhập
                _dal.Them(k);
                NhatKyBLL.Ghi("Thêm khách hàng", k.MaKH + " - " + k.HoTen);
                return null;
            }
            catch (Exception ex) { return Database.DichLoi(ex); }
        }

        public string Sua(KhachHangDTO k)
        {
            string loi = KiemTraDuLieu(k);
            if (loi != null) return loi;
            try
            {
                if (string.IsNullOrEmpty(k.MaKH) || _dal.LayTheoMa(k.MaKH) == null)
                    return "Hãy chọn một khách hàng trong danh sách để sửa.";
                if (_dal.TrungCccd(k.CCCD, k.MaKH)) return "CCCD này đã thuộc về một khách hàng khác.";
                _dal.Sua(k);
                NhatKyBLL.Ghi("Sửa khách hàng", k.MaKH + " - " + k.HoTen);
                return null;
            }
            catch (Exception ex) { return Database.DichLoi(ex); }
        }

        public string Xoa(string maKH)
        {
            try
            {
                if (string.IsNullOrEmpty(maKH) || _dal.LayTheoMa(maKH) == null)
                    return "Hãy chọn một khách hàng trong danh sách để xóa.";
                if (_dal.CoVeThang(maKH)) return "Không thể xóa: khách hàng đã từng đăng ký vé tháng.";
                _dal.Xoa(maKH);
                NhatKyBLL.Ghi("Xóa khách hàng", maKH);
                return null;
            }
            catch (Exception ex) { return Database.DichLoi(ex); }
        }
    }
}
