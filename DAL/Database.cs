// [Người 1] Kết nối và các hàm dùng chung cho mọi DAL. Chỉ Người 1 sửa file này.
// Cần Reference: System.Configuration. Mọi câu SQL đều phải truyền tham số qua P(...).
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyBaiGiuXe.DAL
{
    public static class Database
    {
        private static string ChuoiKetNoi =>
            ConfigurationManager.ConnectionStrings["QuanLyBaiGiuXeDB"].ConnectionString;

        public static SqlConnection TaoKetNoi() => new SqlConnection(ChuoiKetNoi);

        /// <summary>Chỉ bật tạm khi demo rollback (xem LuotGuiDAL.XeRa).</summary>
        public static bool GiaLapLoi { get; set; }

        public static SqlParameter P(string ten, object giaTri) => new SqlParameter(ten, giaTri ?? DBNull.Value);

        /// <summary>Đọc giá trị cột, tự xử lý NULL: r.Gt&lt;string&gt;("MoTa"), r.Gt&lt;DateTime?&gt;("GioRa").</summary>
        public static T Gt<T>(this SqlDataReader r, string cot)
        {
            object v = r[cot];
            if (v == DBNull.Value) return default(T);
            Type kieu = Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);
            return (T)Convert.ChangeType(v, kieu);
        }

        public static List<T> Doc<T>(string sql, Func<SqlDataReader, T> map, params SqlParameter[] ps)
            => Chay(sql, CommandType.Text, map, ps);

        public static List<T> GoiProc<T>(string tenProc, Func<SqlDataReader, T> map, params SqlParameter[] ps)
            => Chay(tenProc, CommandType.StoredProcedure, map, ps);

        private static List<T> Chay<T>(string cauLenh, CommandType loai, Func<SqlDataReader, T> map, SqlParameter[] ps)
        {
            var ds = new List<T>();
            using (var cn = TaoKetNoi())
            using (var cmd = new SqlCommand(cauLenh, cn) { CommandType = loai })
            {
                cmd.Parameters.AddRange(ps);
                cn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read()) ds.Add(map(r));
            }
            return ds;
        }

        public static int ThucThi(string sql, params SqlParameter[] ps)
        {
            using (var cn = TaoKetNoi())
            using (var cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.AddRange(ps);
                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static object LayGiaTri(string sql, params SqlParameter[] ps)
        {
            using (var cn = TaoKetNoi())
            using (var cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.AddRange(ps);
                cn.Open();
                return cmd.ExecuteScalar();
            }
        }

        /// <summary>Đổi lỗi SQL khó hiểu thành câu thông báo cho người dùng.</summary>
        public static string DichLoi(Exception ex)
        {
            var sql = ex as SqlException;
            if (sql == null) return ex.Message;
            if (sql.Number == 547) return "Dữ liệu đang được sử dụng ở nơi khác, không thể thực hiện thao tác này.";
            if (sql.Number == 2627 || sql.Number == 2601) return "Dữ liệu bị trùng với bản ghi đã có.";
            return "Lỗi cơ sở dữ liệu: " + sql.Message;
        }
    }
}