using DAL;
using DTO;
using System.Data;

namespace BLL
{
    public class VeThangBLL
    {
        private VeThangDAL dal =
            new VeThangDAL();

        public DataTable GetAll()
        {
            return dal.GetAll();
        }

        public bool DangKy(VeThangDTO vt)
        {
            return dal.DangKy(vt);
        }

        public bool GiaHan(int maVe)
        {
            return dal.GiaHan(maVe);
        }

        public bool Huy(int maVe)
        {
            return dal.Huy(maVe);
        }

        public bool KiemTraVeThang(string soThe)
        {
            return dal.KiemTraVeThang(soThe);
        }
    }
}
