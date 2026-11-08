using DTO;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class VeThangDAL
    {
        public DataTable GetAll()
        {
            string sql = @"
            SELECT *
            FROM VeThang";

            return Database.GetData(sql);
        }

        public bool DangKy(VeThangDTO vt)
        {
            string sql = @"
            INSERT INTO VeThang
            (
                MaKH,
                SoThe,
                NgayDangKy,
                NgayHetHan,
                TrangThai
            )
            VALUES
            (
                @MaKH,
                @SoThe,
                @NgayDangKy,
                @NgayHetHan,
                1
            )";

            SqlParameter[] p =
            {
                new SqlParameter("@MaKH",vt.MaKH),
                new SqlParameter("@SoThe",vt.SoThe),
                new SqlParameter("@NgayDangKy",vt.NgayDangKy),
                new SqlParameter("@NgayHetHan",vt.NgayHetHan)
            };

            return Database.ExecuteNonQuery(sql,p) > 0;
        }

        // SỬA LOGIC GIA HẠN
        public bool GiaHan(int maVe)
        {
            string sql = @"
            UPDATE VeThang
            SET NgayHetHan =
                DATEADD(MONTH,1,NgayHetHan)
            WHERE MaVe=@MaVe";

            SqlParameter[] p =
            {
                new SqlParameter("@MaVe",maVe)
            };

            return Database.ExecuteNonQuery(sql,p) > 0;
        }

        public bool Huy(int maVe)
        {
            string sql = @"
            UPDATE VeThang
            SET TrangThai = 0
            WHERE MaVe=@MaVe";

            SqlParameter[] p =
            {
                new SqlParameter("@MaVe",maVe)
            };

            return Database.ExecuteNonQuery(sql,p) > 0;
        }

        // ĐIỂM TÍCH HỢP VỚI NGƯỜI 2
        public bool KiemTraVeThang(string soThe)
        {
            string sql = @"
            SELECT COUNT(*)
            FROM VeThang
            WHERE SoThe=@SoThe
            AND TrangThai=1
            AND NgayHetHan>=GETDATE()";

            SqlParameter[] p =
            {
                new SqlParameter("@SoThe",soThe)
            };

            int count =
                Convert.ToInt32(
                    Database.ExecuteScalar(sql,p));

            return count > 0;
        }
    }
}
