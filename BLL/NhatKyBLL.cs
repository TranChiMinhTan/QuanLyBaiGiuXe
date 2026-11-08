// [SÁNG TẠO #6] Nhật ký thao tác (audit log). Gọi NhatKyBLL.Ghi(...) ở bất kỳ BLL nào.
// Ghi nhật ký lỗi thì bỏ qua, không làm hỏng thao tác chính.
using System.Collections.Generic;
using QuanLyBaiGiuXe.DAL;
using QuanLyBaiGiuXe.Models;

namespace QuanLyBaiGiuXe.BLL
{
    public static class NhatKyBLL
    {
        private static readonly NhatKyDAL Dal = new NhatKyDAL();

        public static void Ghi(string hanhDong, string chiTiet = null)
        {
            try { Dal.Ghi(PhienLamViec.TenNguoiDung, hanhDong, chiTiet); }
            catch { }
        }

        public static List<NhatKyDTO> LayGanDay(string tuKhoa) => Dal.LayGanDay(tuKhoa);
    }
}
