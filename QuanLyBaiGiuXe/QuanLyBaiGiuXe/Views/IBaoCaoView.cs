// [Người 4] Hợp đồng giữa ucBaoCao và BaoCaoPresenter.
using System;
using System.Collections.Generic;
using QuanLyBaiXe.Models;

namespace QuanLyBaiXe.Views
{
    public interface IBaoCaoView : IViewCoBan
    {
        DateTime TuNgay { get; }
        DateTime DenNgay { get; }
        bool TheoThang { get; }             // false = theo ngày

        void HienThiBang(List<DoanhThuDTO> ds);
        void VeBieuDo(List<DoanhThuDTO> ds);            // vẽ bằng GDI+ hoặc Chart tùy nhóm chốt
        void HienThiTong(decimal doanhThuLuotGui, decimal doanhThuVeThang);
        string ChonNoiLuuCsv();                         // mở SaveFileDialog, trả về null nếu hủy
    }
}
