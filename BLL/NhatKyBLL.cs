// Nhật ký thao tác. Ghi nhật ký KHÔNG BAO GIỜ được làm hỏng thao tác chính, nên Ghi nuốt lỗi.
using System;
using System.Collections.Generic;
using QuanLyBaiGiuXe.DAL;
using QuanLyBaiGiuXe.Models;

namespace QuanLyBaiGiuXe.BLL
{
    public class NhatKyBLL
    {
        public const int SoDongToiDa = 500;
        private readonly NhatKyDAL _dal = new NhatKyDAL();

        /// <summary>Ghi theo người đang đăng nhập (PhienLamViec).</summary>
        public static void Ghi(string hanhDong, string chiTiet = null) => Ghi(PhienLamViec.TenDangNhap, hanhDong, chiTiet);

        /// <summary>Ghi theo tên người dùng chỉ định (dùng lúc đăng nhập, khi PhienLamViec chưa được gán).</summary>
        public static void Ghi(string tenDangNhap, string hanhDong, string chiTiet)
        {
            try
            {
                if (chiTiet != null && chiTiet.Length > 500) chiTiet = chiTiet.Substring(0, 500);
                new NhatKyDAL().Ghi(tenDangNhap, hanhDong, chiTiet);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Không ghi được nhật ký: " + ex.Message);
            }
        }

        /// <summary>Chỉ Quản lý được xem nhật ký (đúng với menu trong FrmMain); kiểm tra lại ở đây để không phụ thuộc giao diện.</summary>
        public List<NhatKyDTO> LayGanNhat(string tuKhoa)
        {
            if (!PhienLamViec.LaQuanLy) throw new UnauthorizedAccessException("Chỉ Quản lý mới được xem nhật ký thao tác.");
            return _dal.LayGanNhat(tuKhoa, SoDongToiDa);
        }
    }
}
