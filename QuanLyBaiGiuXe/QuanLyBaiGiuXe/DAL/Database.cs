// [Người 1 — BẢN TẠM do Người 2 viết để chạy thử. Người 1 thay bằng bản chính thức, giữ nguyên tên hàm.]
// Cần thêm Reference: System.Configuration
using System.Configuration;
using System.Data.SqlClient;

namespace QuanLyBaiXe.DAL
{
    public static class Database
    {
        private static string ChuoiKetNoi =>
            ConfigurationManager.ConnectionStrings["QuanLyBaiXeDB"].ConnectionString;

        public static SqlConnection TaoKetNoi() => new SqlConnection(ChuoiKetNoi);

        /// <summary>Chỉ bật tạm khi demo rollback (xem LuotGuiDAL.XeRa).</summary>
        public static bool GiaLapLoi { get; set; }
    }
}
