public class ChoTrongBLL
{
    ChoTrongDAL dal =
        new ChoTrongDAL();

    public DataTable LayBaoCao()
    {
        return dal.LaySoChoTrong();
    }
}
