public class ChoTrongDAL
{
    public DataTable LaySoChoTrong()
    {
        SqlConnection conn =
            Database.GetConnection();

        SqlDataAdapter da =
            new SqlDataAdapter(
                "sp_SoChoTrong",
                conn);

        da.SelectCommand.CommandType =
            CommandType.StoredProcedure;

        DataTable dt =
            new DataTable();

        da.Fill(dt);

        return dt;
    }
}
