using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyBaiXe.DAL
{
    /// <summary>
    /// Lớp truy cập CSDL dùng chung cho cả nhóm.
    /// QUY ƯỚC: chỉ Người 1 sửa file này. Cần thêm hàm thì báo Người 1.
    /// Mọi câu SQL phải dùng tham số (Database.Tham) - không nối chuỗi.
    /// </summary>
    public static class Database
    {
        // ---------- Kết nối ----------
        public static string ChuoiKetNoi
        {
            get { return ConfigurationManager.ConnectionStrings["QuanLyBaiXe"].ConnectionString; }
        }

        public static SqlConnection TaoKetNoi()
        {
            return new SqlConnection(ChuoiKetNoi);
        }

        /// <summary>Kiểm tra kết nối. Trả về false và thông báo lỗi nếu không mở được.</summary>
        public static bool KiemTraKetNoi(out string loi)
        {
            try
            {
                using (SqlConnection cn = TaoKetNoi())
                {
                    cn.Open();
                }
                loi = null;
                return true;
            }
            catch (Exception ex)
            {
                loi = ex.Message;
                return false;
            }
        }

        // ---------- Tham số ----------
        /// <summary>Tạo SqlParameter, tự đổi null thành DBNull.</summary>
        public static SqlParameter Tham(string ten, object giaTri)
        {
            return new SqlParameter(ten, giaTri ?? DBNull.Value);
        }

        // ---------- Câu lệnh thường (tự mở/đóng kết nối) ----------
        public static DataTable LayBang(string sql, params SqlParameter[] ps)
        {
            return Chay(sql, false, ps, LayBangTuLenh);
        }

        public static int ThucThi(string sql, params SqlParameter[] ps)
        {
            return Chay(sql, false, ps, delegate (SqlCommand cmd) { return cmd.ExecuteNonQuery(); });
        }

        public static object LayGiaTri(string sql, params SqlParameter[] ps)
        {
            return Chay(sql, false, ps, delegate (SqlCommand cmd) { return cmd.ExecuteScalar(); });
        }

        // ---------- Stored procedure ----------
        public static DataTable LayBangProc(string tenProc, params SqlParameter[] ps)
        {
            return Chay(tenProc, true, ps, LayBangTuLenh);
        }

        public static int ThucThiProc(string tenProc, params SqlParameter[] ps)
        {
            return Chay(tenProc, true, ps, delegate (SqlCommand cmd) { return cmd.ExecuteNonQuery(); });
        }

        public static object LayGiaTriProc(string tenProc, params SqlParameter[] ps)
        {
            return Chay(tenProc, true, ps, delegate (SqlCommand cmd) { return cmd.ExecuteScalar(); });
        }

        // ---------- Transaction ----------
        /// <summary>
        /// Chạy nhiều lệnh trong một transaction. Nếu công việc ném exception thì tự Rollback
        /// rồi ném lại exception cho nơi gọi (dùng cho xe ra + thanh toán, đăng ký vé tháng...).
        /// Ví dụ:
        ///   Database.ChayTrongTransaction((cn, tr) => {
        ///       Database.ThucThi(cn, tr, "UPDATE ...", Database.Tham("@a", 1));
        ///       Database.ThucThi(cn, tr, "INSERT ...", Database.Tham("@b", 2));
        ///   });
        /// </summary>
        public static void ChayTrongTransaction(Action<SqlConnection, SqlTransaction> congViec)
        {
            using (SqlConnection cn = TaoKetNoi())
            {
                cn.Open();
                using (SqlTransaction tr = cn.BeginTransaction())
                {
                    try
                    {
                        congViec(cn, tr);
                        tr.Commit();
                    }
                    catch
                    {
                        try { tr.Rollback(); } catch { /* bỏ qua lỗi rollback */ }
                        throw;
                    }
                }
            }
        }

        // Các hàm dùng bên trong transaction (truyền kết nối và transaction đang mở)
        public static DataTable LayBang(SqlConnection cn, SqlTransaction tr, string sql, params SqlParameter[] ps)
        {
            using (SqlCommand cmd = TaoLenh(cn, tr, sql, false, ps))
            {
                return LayBangTuLenh(cmd);
            }
        }

        public static int ThucThi(SqlConnection cn, SqlTransaction tr, string sql, params SqlParameter[] ps)
        {
            using (SqlCommand cmd = TaoLenh(cn, tr, sql, false, ps))
            {
                return cmd.ExecuteNonQuery();
            }
        }

        public static object LayGiaTri(SqlConnection cn, SqlTransaction tr, string sql, params SqlParameter[] ps)
        {
            using (SqlCommand cmd = TaoLenh(cn, tr, sql, false, ps))
            {
                return cmd.ExecuteScalar();
            }
        }

        // ---------- Hàm nội bộ ----------
        private static SqlCommand TaoLenh(SqlConnection cn, SqlTransaction tr, string cauLenh, bool laProc, SqlParameter[] ps)
        {
            SqlCommand cmd = new SqlCommand(cauLenh, cn, tr);
            cmd.CommandType = laProc ? CommandType.StoredProcedure : CommandType.Text;
            if (ps != null && ps.Length > 0)
            {
                cmd.Parameters.AddRange(ps);
            }
            return cmd;
        }

        private static DataTable LayBangTuLenh(SqlCommand cmd)
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                da.Fill(dt);
            }
            return dt;
        }

        private static T Chay<T>(string cauLenh, bool laProc, SqlParameter[] ps, Func<SqlCommand, T> xuLy)
        {
            using (SqlConnection cn = TaoKetNoi())
            {
                cn.Open();
                using (SqlCommand cmd = TaoLenh(cn, null, cauLenh, laProc, ps))
                {
                    return xuLy(cmd);
                }
            }
        }
    }
}
