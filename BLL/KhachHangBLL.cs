using DAL;
using DTO;
using System;
using System.Data;

namespace BLL
{
    public class KhachHangBLL
    {
        private KhachHangDAL dal =
            new KhachHangDAL();

        public DataTable GetAll()
        {
            return dal.GetAll();
        }

        public bool Them(KhachHangDTO kh)
        {
            if (string.IsNullOrWhiteSpace(kh.HoTen))
                throw new Exception(
                    "Họ tên không được để trống");

            if (string.IsNullOrWhiteSpace(kh.SoDienThoai))
                throw new Exception(
                    "SĐT không được để trống");

            return dal.Insert(kh);
        }

        public bool Sua(KhachHangDTO kh)
        {
            return dal.Update(kh);
        }

        public bool Xoa(int maKH)
        {
            return dal.Delete(maKH);
        }
    }
}
