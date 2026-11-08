// [Người 4] Hợp đồng giữa ucTraCuu và TraCuuPresenter. (THAY file ITraCuuView cũ: thêm LuotDangChon, HienThiAnh.)
using System;
using System.Collections.Generic;
using QuanLyBaiGiuXe.Models;

namespace QuanLyBaiGiuXe.Views
{
    public interface ITraCuuView : IViewCoBan
    {
        string BienSo { get; }
        string MaThe { get; }
        DateTime TuNgay { get; }
        DateTime DenNgay { get; }
        int? MaLoaiXe { get; }              // null = tất cả loại xe
        LuotGuiDTO LuotDangChon { get; }    // dòng đang chọn trong lưới, null nếu chưa chọn

        void NapLoaiXe(List<LoaiXeDTO> ds);
        void HienThiKetQua(List<LuotGuiDTO> ds);
        void HienThiTong(int soLuot, decimal tongPhi);
        void HienThiAnh(string duongDanTuongDoi);       // [SÁNG TẠO #9] xem lại ảnh biển số
        void InBienNhan(BienNhanDTO bienNhan);
    }
}