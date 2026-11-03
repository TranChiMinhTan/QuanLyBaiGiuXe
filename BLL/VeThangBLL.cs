public class VeThangBLL
{
    VeThangDAL dal =
        new VeThangDAL();

    public bool DangKy(VeThangDTO vt)
    {
        return dal.DangKy(vt);
    }

    public bool GiaHan(int maVe)
    {
        DateTime ngayMoi =
            DateTime.Now.AddMonths(1);

        return dal.GiaHan(maVe, ngayMoi);
    }

    public bool Huy(int maVe)
    {
        return dal.Huy(maVe);
    }
}
