public class VeThangDAL
{
    public DataTable GetAll()
    {
        return Database.GetData(
            "SELECT * FROM VeThang");
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

    public bool GiaHan(
        int maVe,
        DateTime ngayMoi)
    {
        string sql = @"
        UPDATE VeThang
        SET NgayHetHan=@NgayHetHan
        WHERE MaVe=@MaVe";

        SqlParameter[] p =
        {
            new SqlParameter("@NgayHetHan",ngayMoi),
            new SqlParameter("@MaVe",maVe)
        };

        return Database.ExecuteNonQuery(sql,p) > 0;
    }

    public bool Huy(int maVe)
    {
        string sql = @"
        UPDATE VeThang
        SET TrangThai=0
        WHERE MaVe=@MaVe";

        SqlParameter[] p =
        {
            new SqlParameter("@MaVe",maVe)
        };

        return Database.ExecuteNonQuery(sql,p) > 0;
    }
}
