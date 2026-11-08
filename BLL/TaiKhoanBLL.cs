// Đăng nhập và đổi mật khẩu. Trả về chuỗi lỗi, null nghĩa là thành công.
using System;
using QuanLyBaiGiuXe.DAL;
using QuanLyBaiGiuXe.Models;

namespace QuanLyBaiGiuXe.BLL
{
    public class TaiKhoanBLL
    {
        private readonly TaiKhoanDAL _dal = new TaiKhoanDAL();

        public string DangNhap(string tenDangNhap, string matKhau, out TaiKhoanDTO taiKhoan)
        {
            taiKhoan = null;
            tenDangNhap = (tenDangNhap ?? "").Trim();
            if (tenDangNhap.Length == 0 || string.IsNullOrEmpty(matKhau))
                return "Vui lòng nhập tên đăng nhập và mật khẩu.";
            try
            {
                var t = _dal.LayTheoTen(tenDangNhap);
                bool dung = t != null && t.HoatDong &&
                            string.Equals(BaoMat.Bam(t.Muoi, matKhau), t.MatKhauHash, StringComparison.OrdinalIgnoreCase);
                if (!dung) return "Sai tên đăng nhập hoặc mật khẩu.";

                t.Muoi = null; t.MatKhauHash = null;           // không giữ dữ liệu nhạy cảm trong bộ nhớ
                taiKhoan = t;
                return null;
            }
            catch (Exception ex) { return "Không kết nối được cơ sở dữ liệu: " + Database.DichLoi(ex); }
        }

        public string DoiMatKhau(string cu, string moi, string nhapLai)
        {
            var tk = PhienLamViec.TaiKhoan;
            if (tk == null) return "Chưa đăng nhập.";
            if (string.IsNullOrEmpty(cu)) return "Vui lòng nhập mật khẩu hiện tại.";
            if (string.IsNullOrEmpty(moi) || moi.Length < 6) return "Mật khẩu mới phải có ít nhất 6 ký tự.";
            if (moi != nhapLai) return "Nhập lại mật khẩu mới không khớp.";
            if (moi == cu) return "Mật khẩu mới phải khác mật khẩu cũ.";
            try
            {
                var t = _dal.LayTheoTen(tk.TenDangNhap);
                if (t == null || !string.Equals(BaoMat.Bam(t.Muoi, cu), t.MatKhauHash, StringComparison.OrdinalIgnoreCase))
                    return "Mật khẩu hiện tại không đúng.";
                string muoi = BaoMat.TaoMuoi();
                _dal.CapNhatMatKhau(t.Id, muoi, BaoMat.Bam(muoi, moi));
                NhatKyBLL.Ghi("Đổi mật khẩu");
                return null;
            }
            catch (Exception ex) { return Database.DichLoi(ex); }
        }
    }
}
