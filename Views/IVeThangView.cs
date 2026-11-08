using System;
using System.Collections.Generic;
using QuanLyBaiGiuXe.Models;

namespace QuanLyBaiGiuXe.Views
{
    public interface IVeThangView : IViewCoBan
    {
        int MaVe { get; } 
        string BienSo { get; }
        string MaKH { get; }
        int MaLoaiXe { get; }
        DateTime NgayDangKy { get; }
        int SoThang { get; }
        string TuKhoaTim { get; }

        void NapKhachHang(List<KhachHangDTO> ds);
        void NapLoaiXe(List<LoaiXeDTO> ds);
        void HienThiDanhSach(List<VeThangDTO> ds);
        void HienThiChiTiet(VeThangDTO ve);
        void HienThiNgayHetHan(DateTime ngay);
        void HienThiCanhBaoVe(string noiDung);
        void XoaNhap();
    }
}