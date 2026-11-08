// Đăng nhập và đổi mật khẩu. Quy tắc lấy từ Dự án B (_Legacy/BLL/TaiKhoanBLL.cs). Trả về null = thành công, ngược lại là câu báo lỗi.
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
            if (tenDangNhap.Length == 0) return "Vui lòng nhập tên đăng nhập.";
            if (string.IsNullOrEmpty(matKhau)) return "Vui lòng nhập mật khẩu.";

            try
            {
                TaiKhoanDTO tk = _dal.LayTheoTen(tenDangNhap);
                // Một thông báo chung để không lộ tài khoản nào tồn tại / bị khóa.
                if (tk == null || !tk.HoatDong || !BaoMat.KhopMatKhau(matKhau, tk))
                    return "Sai tên đăng nhập hoặc mật khẩu.";

                if (!BaoMat.CoMuoi(tk))                     // nâng cấp hash cũ không muối lên PBKDF2
                {
                    string muoi = BaoMat.TaoMuoi();
                    _dal.CapNhatMatKhau(tk.Id, BaoMat.Bam(matKhau, muoi), muoi);
                }
                tk.Muoi = null; tk.MatKhauHash = null;      // không giữ thông tin băm trong bộ nhớ sau khi đăng nhập
                taiKhoan = tk;
                NhatKyBLL.Ghi(tk.TenDangNhap, "Đăng nhập", null);
                return null;
            }
            catch (Exception ex) { return "Không thể kết nối cơ sở dữ liệu: " + ex.Message; }
        }

        public string DoiMatKhau(string matKhauCu, string matKhauMoi, string nhapLai)
        {
            var hienTai = PhienLamViec.TaiKhoan;
            if (hienTai == null) return "Bạn chưa đăng nhập.";
            if (string.IsNullOrEmpty(matKhauCu)) return "Vui lòng nhập mật khẩu hiện tại.";
            if (string.IsNullOrEmpty(matKhauMoi)) return "Vui lòng nhập mật khẩu mới.";
            if (matKhauMoi.Length < 6) return "Mật khẩu mới phải có ít nhất 6 ký tự.";
            if (matKhauMoi == matKhauCu) return "Mật khẩu mới phải khác mật khẩu hiện tại.";
            if (matKhauMoi != nhapLai) return "Xác nhận mật khẩu không khớp.";

            try
            {
                TaiKhoanDTO tk = _dal.LayTheoTen(hienTai.TenDangNhap);
                if (tk == null || !tk.HoatDong) return "Không tìm thấy tài khoản.";
                if (!BaoMat.KhopMatKhau(matKhauCu, tk)) return "Mật khẩu hiện tại không đúng.";

                string muoi = BaoMat.TaoMuoi();
                _dal.CapNhatMatKhau(tk.Id, BaoMat.Bam(matKhauMoi, muoi), muoi);
                NhatKyBLL.Ghi("Đổi mật khẩu");
                return null;
            }
            catch (Exception ex) { return Database.DichLoi(ex); }
        }
    }
}
