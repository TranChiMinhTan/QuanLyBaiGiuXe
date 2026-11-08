// [Người 3] Hợp đồng giữa ucKhachHang và KhachHangPresenter.
using System.Collections.Generic;
using QuanLyBaiGiuXe.Models;

namespace QuanLyBaiGiuXe.Views
{
    public interface IKhachHangView : IViewCoBan
    {
        string MaKH { get; }
        string HoTen { get; }
        string SDT { get; }
        string CCCD { get; }
        string DiaChi { get; }
        string TuKhoaTim { get; }

        void HienThiDanhSach(List<KhachHangDTO> ds);
        void HienThiChiTiet(KhachHangDTO khach);
        void DatMaKH(string maKH);          // mã tự sinh cho khách mới
        void XoaNhap();
    }
}
