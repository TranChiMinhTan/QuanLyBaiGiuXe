// [Người 4] Hợp đồng giữa ucTraCuu và TraCuuPresenter.
using System;
using System.Collections.Generic;
using QuanLyBaiXe.Models;

namespace QuanLyBaiXe.Views
{
    public interface ITraCuuView : IViewCoBan
    {
        string BienSo { get; }
        string MaThe { get; }
        DateTime TuNgay { get; }
        DateTime DenNgay { get; }
        int? MaLoaiXe { get; }              // null = tất cả loại xe

        void NapLoaiXe(List<LoaiXeDTO> ds);
        void HienThiKetQua(List<LuotGuiDTO> ds);
        void HienThiTong(int soLuot, decimal tongPhi);
        void InBienNhan(BienNhanDTO bienNhan);
    }
}
