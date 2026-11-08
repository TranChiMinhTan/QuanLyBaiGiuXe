using System;
using QuanLyBaiXe.DAL;
using QuanLyBaiXe.DTO;

namespace QuanLyBaiXe.BLL
{
    public class TaiKhoanBLL
    {
        private readonly TaiKhoanDAL dal = new TaiKhoanDAL();

        public KetQua DangNhap(string tenDangNhap, string matKhau, out TaiKhoanDTO taiKhoan)
        {
            taiKhoan = null;
            tenDangNhap = (tenDangNhap ?? "").Trim();

            if (tenDangNhap.Length == 0) return KetQua.Loi("Vui lòng nhập tên đăng nhập.");
            if (string.IsNullOrEmpty(matKhau)) return KetQua.Loi("Vui lòng nhập mật khẩu.");

            try
            {
                TaiKhoanDTO tk = dal.LayTheoTen(tenDangNhap);
                string hash = MatKhauHelper.BamSHA256(matKhau);

                // Thông báo chung để không lộ tài khoản nào tồn tại
                if (tk == null || !tk.KichHoat ||
                    !string.Equals(tk.MatKhauHash, hash, StringComparison.OrdinalIgnoreCase))
                {
                    return KetQua.Loi("Sai tên đăng nhập hoặc mật khẩu.");
                }

                taiKhoan = tk;
                return KetQua.OK("Đăng nhập thành công.");
            }
            catch (Exception ex)
            {
                return KetQua.Loi("Không thể kết nối cơ sở dữ liệu: " + ex.Message);
            }
        }

        public KetQua DoiMatKhau(string tenDangNhap, string matKhauCu, string matKhauMoi, string xacNhan)
        {
            if (string.IsNullOrEmpty(matKhauCu)) return KetQua.Loi("Vui lòng nhập mật khẩu hiện tại.");
            if (string.IsNullOrEmpty(matKhauMoi)) return KetQua.Loi("Vui lòng nhập mật khẩu mới.");
            if (matKhauMoi.Length < 6) return KetQua.Loi("Mật khẩu mới phải có ít nhất 6 ký tự.");
            if (matKhauMoi == matKhauCu) return KetQua.Loi("Mật khẩu mới phải khác mật khẩu hiện tại.");
            if (matKhauMoi != xacNhan) return KetQua.Loi("Xác nhận mật khẩu không khớp.");

            return KetQua.Chay(() =>
            {
                TaiKhoanDTO tk = dal.LayTheoTen(tenDangNhap);
                if (tk == null) return KetQua.Loi("Không tìm thấy tài khoản.");
                if (!string.Equals(tk.MatKhauHash, MatKhauHelper.BamSHA256(matKhauCu), StringComparison.OrdinalIgnoreCase))
                    return KetQua.Loi("Mật khẩu hiện tại không đúng.");

                dal.CapNhatMatKhau(tenDangNhap, MatKhauHelper.BamSHA256(matKhauMoi));
                return KetQua.OK("Đổi mật khẩu thành công.");
            });
        }
    }
}
