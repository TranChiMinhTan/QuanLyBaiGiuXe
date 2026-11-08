public class KhachHangDAL
{
    public DataTable GetAll()
    {
        string sql = "SELECT * FROM KhachHang";
        return Database.GetData(sql);
    }

    public bool Insert(KhachHangDTO kh)
    {
        string sql = @"
        INSERT INTO KhachHang
        (
            HoTen,
            SoDienThoai,
            DiaChi
        )
        VALUES
        (
            @HoTen,
            @SDT,
            @DiaChi
        )";

        SqlParameter[] p =
        {
            new SqlParameter("@HoTen", kh.HoTen),
            new SqlParameter("@SDT", kh.SoDienThoai),
            new SqlParameter("@DiaChi", kh.DiaChi)
        };

        return Database.ExecuteNonQuery(sql, p) > 0;
    }

    public bool Update(KhachHangDTO kh)
    {
        string sql = @"
        UPDATE KhachHang
        SET HoTen=@HoTen,
            SoDienThoai=@SDT,
            DiaChi=@DiaChi
        WHERE MaKH=@MaKH";

        SqlParameter[] p =
        {
            new SqlParameter("@MaKH", kh.MaKH),
            new SqlParameter("@HoTen", kh.HoTen),
            new SqlParameter("@SDT", kh.SoDienThoai),
            new SqlParameter("@DiaChi", kh.DiaChi)
        };

        return Database.ExecuteNonQuery(sql, p) > 0;
    }

    public bool Delete(int maKH)
    {
        string sql =
            "DELETE FROM KhachHang WHERE MaKH=@MaKH";

        SqlParameter[] p =
        {
            new SqlParameter("@MaKH",maKH)
        };

        return Database.ExecuteNonQuery(sql,p) > 0;
    }
}
