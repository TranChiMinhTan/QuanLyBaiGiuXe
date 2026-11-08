// [Người 4] Hợp đồng giữa ucBaoCao và BaoCaoPresenter. (THAY file IBaoCaoView cũ: thêm giờ cao điểm và gợi ý vé tháng.)
using System;
using System.Collections.Generic;
using QuanLyBaiGiuXe.Models;

namespace QuanLyBaiGiuXe.Views
{
    public interface IBaoCaoView : IViewCoBan
    {
        DateTime TuNgay { get; }
        DateTime DenNgay { get; }
        bool TheoThang { get; }             // false = theo ngày

        void HienThiBang(List<DoanhThuDTO> ds);
        void VeBieuDo(List<DoanhThuDTO> ds);                           // vẽ bằng GDI+
        void HienThiTong(decimal doanhThuLuotGui, decimal doanhThuVeThang);
        string ChonNoiLuuCsv();                                        // SaveFileDialog, null nếu hủy
        void HienThiGioCaoDiem(List<GioCaoDiemDTO> ds);                // [SÁNG TẠO #8]
        void HienThiGoiYVeThang(List<GoiYVeThangDTO> ds);              // [SÁNG TẠO #7]
    }
}