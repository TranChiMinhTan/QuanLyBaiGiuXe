using System;

namespace QuanLyBaiXe.BLL
{
    /// <summary>Kết quả trả về từ BLL cho GUI: thành công hay không + thông báo hiển thị.</summary>
    public class KetQua
    {
        public bool ThanhCong { get; private set; }
        public string ThongBao { get; private set; }

        public static KetQua OK(string thongBao)
        {
            return new KetQua { ThanhCong = true, ThongBao = thongBao };
        }

        public static KetQua Loi(string thongBao)
        {
            return new KetQua { ThanhCong = false, ThongBao = thongBao };
        }

        /// <summary>Chạy một công việc, nếu có exception (mất kết nối, vi phạm ràng buộc...) thì đổi thành KetQua.Loi.</summary>
        public static KetQua Chay(Func<KetQua> viec)
        {
            try
            {
                return viec();
            }
            catch (Exception ex)
            {
                return Loi("Lỗi cơ sở dữ liệu: " + ex.Message);
            }
        }
    }
}
