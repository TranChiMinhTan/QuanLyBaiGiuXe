// Nghiệp vụ vé tháng: đăng ký, gia hạn, hủy, kiểm tra hạn.
using System;
using System.Collections.Generic;
using QuanLyBaiGiuXe.DAL;
using QuanLyBaiGiuXe.Models;

namespace QuanLyBaiGiuXe.BLL
{
    public class VeThangBLL
    {
        private readonly VeThangDAL _dal = new VeThangDAL();
        private readonly BangGiaDAL _giaDal = new BangGiaDAL();

        public List<VeThangDTO> LayTatCa(string tuKhoa) => _dal.LayTatCa(tuKhoa);

        /// <summary>Vé chưa hủy gần nhất của biển số (còn hạn hay hết hạn đều trả về), null nếu chưa từng đăng ký.</summary>
        public VeThangDTO KiemTraVeThang(string bienSo) => _dal.LayMoiNhatTheoBienSo(bienSo);

        /// <summary>Đăng ký ngày 01/10, 1 tháng thì hết hạn 31/10.</summary>
        public DateTime TinhNgayHetHan(DateTime ngayDangKy, int soThang)
            => ngayDangKy.Date.AddMonths(Math.Max(1, soThang)).AddDays(-1);

        public string DangKy(string bienSo, string maKH, int maLoaiXe, DateTime ngayDangKy, int soThang)
        {
            bienSo = (bienSo ?? "").Trim().ToUpper();
            if (!KiemTra.BienSoHopLe(bienSo)) return "Biển số không hợp lệ (ví dụ 51A-123.45).";
            if (string.IsNullOrEmpty(maKH)) return "Vui lòng chọn khách hàng.";
            if (maLoaiXe <= 0) return "Vui lòng chọn loại xe.";
            if (soThang < 1 || soThang > 12) return "Số tháng phải từ 1 đến 12.";
            if (ngayDangKy.Date < DateTime.Today.AddDays(-31)) return "Ngày đăng ký quá xa trong quá khứ.";
            try
            {
                var gia = _giaDal.LayTheoLoaiXe(maLoaiXe);
                if (gia == null) return "Chưa có bảng giá cho loại xe này, hãy nhờ Quản lý cấu hình.";

                var cu = _dal.LayMoiNhatTheoBienSo(bienSo);
                if (cu != null && cu.NgayHetHan.Date >= ngayDangKy.Date)
                    return "Biển số này đã có vé còn hạn đến " + cu.NgayHetHan.ToString("dd/MM/yyyy") + ". Hãy dùng Gia hạn.";

                var ve = new VeThangDTO
                {
                    BienSo = bienSo,
                    MaKH = maKH,
                    MaLoaiXe = maLoaiXe,
                    NgayDangKy = ngayDangKy.Date,
                    NgayHetHan = TinhNgayHetHan(ngayDangKy, soThang),
                    PhiDangKy = gia.GiaVeThang * soThang
                };
                _dal.DangKy(ve);                                           // transaction
                NhatKyBLL.Ghi("Đăng ký vé tháng", bienSo + " - " + soThang + " tháng - " + ve.PhiDangKy.ToString("N0") + " đ");
                return null;
            }
            catch (Exception ex) { return Database.DichLoi(ex); }
        }

        public string GiaHan(int maVe, int soThang)
        {
            if (maVe <= 0) return "Hãy chọn một vé trong danh sách để gia hạn.";
            if (soThang < 1 || soThang > 12) return "Số tháng phải từ 1 đến 12.";
            try
            {
                var ve = _dal.LayTheoMa(maVe);
                if (ve == null) return "Không tìm thấy vé.";
                if (ve.TrangThai == "Đã hủy") return "Vé đã hủy, không thể gia hạn. Hãy đăng ký vé mới.";
                var gia = _giaDal.LayTheoLoaiXe(ve.MaLoaiXe);
                if (gia == null) return "Chưa có bảng giá cho loại xe này.";

                // Còn hạn thì nối tiếp từ ngày hết hạn; đã hết hạn thì tính lại từ hôm nay.
                DateTime moi = ve.NgayHetHan.Date >= DateTime.Today
                    ? ve.NgayHetHan.Date.AddMonths(soThang)
                    : DateTime.Today.AddMonths(soThang).AddDays(-1);
                decimal phi = gia.GiaVeThang * soThang;
                _dal.GiaHan(maVe, moi, phi);                               // transaction
                NhatKyBLL.Ghi("Gia hạn vé tháng", ve.BienSo + " + " + soThang + " tháng, hết hạn mới " + moi.ToString("dd/MM/yyyy"));
                return null;
            }
            catch (Exception ex) { return Database.DichLoi(ex); }
        }

        public string Sua(int maVe, string bienSo, string maKH)
        {
            bienSo = (bienSo ?? "").Trim().ToUpper();
            if (maVe <= 0) return "Hãy chọn một vé trong danh sách để sửa.";
            if (!KiemTra.BienSoHopLe(bienSo)) return "Biển số không hợp lệ.";
            if (string.IsNullOrEmpty(maKH)) return "Vui lòng chọn khách hàng.";
            try
            {
                var khac = _dal.LayMoiNhatTheoBienSo(bienSo);
                if (khac != null && khac.MaVe != maVe && khac.NgayHetHan.Date >= DateTime.Today)
                    return "Biển số này đã có vé tháng khác còn hạn.";
                _dal.Sua(maVe, bienSo, maKH);
                NhatKyBLL.Ghi("Sửa vé tháng", "Vé " + maVe + " - " + bienSo);
                return null;
            }
            catch (Exception ex) { return Database.DichLoi(ex); }
        }

        public string Huy(int maVe)
        {
            if (maVe <= 0) return "Hãy chọn một vé trong danh sách để hủy.";
            try
            {
                var ve = _dal.LayTheoMa(maVe);
                if (ve == null) return "Không tìm thấy vé.";
                if (ve.TrangThai == "Đã hủy") return "Vé này đã được hủy trước đó.";
                _dal.Huy(maVe);
                NhatKyBLL.Ghi("Hủy vé tháng", ve.BienSo);
                return null;
            }
            catch (Exception ex) { return Database.DichLoi(ex); }
        }
    }
}