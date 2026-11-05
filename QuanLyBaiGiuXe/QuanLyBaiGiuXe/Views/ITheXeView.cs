// [Người 1] Hợp đồng giữa ucTheXe và TheXePresenter.
using System;
using System.Collections.Generic;
using QuanLyBaiXe.Models;

namespace QuanLyBaiXe.Views
{
    public interface ITheXeView : IViewCoBan
    {
        string MaThe { get; }
        int MaLoaiXe { get; }
        string TrangThai { get; }           // "Đang trống" / "Đang dùng" / "Đã mất"
        DateTime NgayCap { get; }
        string TuKhoaTim { get; }

        void NapLoaiXe(List<LoaiXeDTO> ds);
        void HienThiDanhSach(List<TheXeDTO> ds);
        void HienThiChiTiet(TheXeDTO the);
        void XoaNhap();
    }
}
