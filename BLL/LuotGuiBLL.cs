// Nghiệp vụ xe vào / xe ra. KHÔNG dùng MessageBox, KHÔNG đụng control.
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using QuanLyBaiGiuXe.DAL;
using QuanLyBaiGiuXe.Models;

namespace QuanLyBaiGiuXe.BLL
{
    public class LuotGuiBLL
    {
        private readonly LuotGuiDAL _luotDal = new LuotGuiDAL();
        private readonly TheXeDAL _theDal = new TheXeDAL();
        private readonly BangGiaDAL _giaDal = new BangGiaDAL();
        private readonly LoaiXeDAL _loaiXeDal = new LoaiXeDAL();
        private readonly VeThangBLL _veThangBll = new VeThangBLL();

        private static readonly Regex MauBienSo = new Regex(@"^[A-Z0-9][A-Z0-9\.\- ]{3,14}$");

        // ---------- dữ liệu cho giao diện ----------
        public List<LoaiXeDTO> LayLoaiXe() => _loaiXeDal.LayTatCa();
        public List<LuotGuiDTO> LayLuotHienThi() => _luotDal.LayLuotHienThi();
        public List<OGuiDTO> LayOGui() => _luotDal.LayTrangThaiBai();

        // ---------- XE VÀO ----------
        public KetQua XeVao(string bienSo, string maThe, int maLoaiXe, string anhNguon)
        {
            bienSo = (bienSo ?? "").Trim().ToUpper();
            maThe = (maThe ?? "").Trim().ToUpper();

            if (bienSo.Length == 0) return KetQua.Loi("Biển số không được để trống.");
            if (!MauBienSo.IsMatch(bienSo)) return KetQua.Loi("Biển số không hợp lệ (ví dụ 51A-123.45).");
            if (maThe.Length == 0) return KetQua.Loi("Vui lòng nhập mã thẻ.");
            if (maLoaiXe <= 0) return KetQua.Loi("Vui lòng chọn loại xe.");

            string duongDanAnh = null;
            try
            {
                if (_luotDal.DangTrongBai(bienSo))                                // chống xe vào trùng
                    return KetQua.Loi("Xe " + bienSo + " đang ở trong bãi, không thể ghi nhận vào lần nữa.");

                var the = _theDal.LayTheoMa(maThe);
                if (the == null) return KetQua.Loi("Không tìm thấy thẻ " + maThe + ".");
                if (the.TrangThai == "Đã mất") return KetQua.Loi("Thẻ " + maThe + " đã báo mất, không được sử dụng.");
                if (the.TrangThai != "Sẵn sàng") return KetQua.Loi("Thẻ " + maThe + " đang được sử dụng.");
                if (the.MaLoaiXe > 0 && the.MaLoaiXe != maLoaiXe)
                    return KetQua.Loi("Thẻ " + maThe + " dành cho loại xe " + the.TenLoaiXe + ".");

                duongDanAnh = LuuAnh(anhNguon);
                var luot = new LuotGuiDTO
                {
                    BienSo = bienSo, MaThe = maThe, MaLoaiXe = maLoaiXe,
                    GioVao = DateTime.Now, DuongDanAnh = duongDanAnh
                };
                luot.MaLuot = _luotDal.XeVao(luot);                                // transaction

                var bn = TaoBienNhan(luot, the.TenLoaiXe);
                return KetQua.Ok(luot, CanhBaoVeThang(bienSo), bn);
            }
            catch (Exception ex)
            {
                XoaAnh(duongDanAnh);                                               // dọn ảnh đã copy nếu ghi DB lỗi
                return KetQua.Loi("Không ghi nhận được xe vào: " + ex.Message);
            }
        }

        // ---------- XE RA: bước 1, chỉ tính, KHÔNG ghi DB ----------
        public KetQua XemPhiXeRa(string maThe)
        {
            maThe = (maThe ?? "").Trim().ToUpper();
            if (maThe.Length == 0) return KetQua.Loi("Vui lòng nhập mã thẻ.");
            try
            {
                var luot = _luotDal.LayLuotDangGui(maThe);
                if (luot == null)
                    return KetQua.Loi("Thẻ " + maThe + " không có lượt gửi đang hoạt động (xe chưa vào hoặc đã ra).");

                var gia = _giaDal.LayTheoLoaiXe(luot.MaLoaiXe);
                if (gia == null) return KetQua.Loi("Chưa có bảng giá cho loại xe " + luot.TenLoaiXe + ".");

                luot.GioRa = DateTime.Now;
                var ve = _veThangBll.KiemTraVeThang(luot.BienSo);
                bool coVeConHan = ve != null && ve.NgayHetHan.Date >= DateTime.Today;
                luot.Phi = TinhPhiBLL.TinhTien(luot, gia, coVeConHan);

                string ghiChu = null;
                if (coVeConHan) ghiChu = "Vé tháng còn hạn: miễn phí.";
                else if (ve != null) ghiChu = "Vé tháng đã hết hạn: tính phí như xe thường.";
                return KetQua.Ok(luot, ghiChu);
            }
            catch (Exception ex) { return KetQua.Loi("Không tính được phí: " + ex.Message); }
        }

        // ---------- XE RA: bước 2, thanh toán trong transaction ----------
        public KetQua ThanhToan(string maThe, bool giaLapLoi)
        {
            var xem = XemPhiXeRa(maThe);                    // tính lại theo giờ ra thật sự lúc bấm thanh toán
            if (!xem.ThanhCong) return xem;
            try
            {
                Database.GiaLapLoi = giaLapLoi;             // chỉ dùng khi demo rollback
                _luotDal.XeRa(xem.Luot);                    // transaction
                return KetQua.Ok(xem.Luot, xem.CanhBao, TaoBienNhan(xem.Luot, xem.Luot.TenLoaiXe));
            }
            catch (Exception ex) { return KetQua.Loi("Thanh toán thất bại: " + ex.Message); }
            finally { Database.GiaLapLoi = false; }
        }

        /// <summary>In lại vé vào của xe đang gửi (theo mã thẻ).</summary>
        public KetQua TaoVeVao(string maThe)
        {
            maThe = (maThe ?? "").Trim().ToUpper();
            if (maThe.Length == 0) return KetQua.Loi("Nhập mã thẻ của xe cần in vé.");
            try
            {
                var luot = _luotDal.LayLuotDangGui(maThe);
                if (luot == null) return KetQua.Loi("Thẻ " + maThe + " không có xe đang gửi.");
                return KetQua.Ok(luot, null, TaoBienNhan(luot, luot.TenLoaiXe));
            }
            catch (Exception ex) { return KetQua.Loi(ex.Message); }
        }

        // ---------- hàm phụ ----------
        private string CanhBaoVeThang(string bienSo)
        {
            var ve = _veThangBll.KiemTraVeThang(bienSo);
            if (ve == null) return null;
            int conLai = (ve.NgayHetHan.Date - DateTime.Today).Days;
            if (conLai < 0) return "Vé tháng đã hết hạn, tính phí như xe thường.";
            if (conLai <= 7) return "Vé tháng còn " + conLai + " ngày, nhắc khách gia hạn.";
            return null;
        }

        private static BienNhanDTO TaoBienNhan(LuotGuiDTO l, string tenLoai)
        {
            var tg = l.ThoiGianGui;
            return new BienNhanDTO
            {
                MaThe = l.MaThe, BienSo = l.BienSo, TenLoaiXe = tenLoai,
                GioVao = l.GioVao, GioRa = l.GioRa, Phi = l.Phi,
                ThoiGianGui = (int)tg.TotalHours + " giờ " + tg.Minutes + " phút"
            };
        }

        /// <summary>Copy ảnh vào thư mục của ứng dụng, trả về đường dẫn TƯƠNG ĐỐI để lưu DB.</summary>
        private static string LuuAnh(string nguon)
        {
            if (string.IsNullOrWhiteSpace(nguon) || !File.Exists(nguon)) return null;
            string thuMuc = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "BienSo");
            Directory.CreateDirectory(thuMuc);
            string ten = Guid.NewGuid().ToString("N") + Path.GetExtension(nguon);
            File.Copy(nguon, Path.Combine(thuMuc, ten));
            return Path.Combine("Images", "BienSo", ten);
        }

        private static void XoaAnh(string duongDanTuongDoi)
        {
            if (string.IsNullOrEmpty(duongDanTuongDoi)) return;
            try { File.Delete(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, duongDanTuongDoi)); } catch { }
        }
    }
}
