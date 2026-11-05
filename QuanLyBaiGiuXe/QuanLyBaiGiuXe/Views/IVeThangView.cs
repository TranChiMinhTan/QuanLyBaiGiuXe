// [Người 3] Hợp đồng giữa ucVeThang và VeThangPresenter.
using System;
using System.Collections.Generic;
using QuanLyBaiXe.Models;

namespace QuanLyBaiXe.Views
{
    public interface IVeThangView : IViewCoBan
    {
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
        void HienThiNgayHetHan(DateTime ngay);          // tự tính khi đổi ngày đăng ký hoặc số tháng
        void HienThiCanhBaoVe(string noiDung);          // ví dụ "1 vé sắp hết hạn"
        void XoaNhap();
    }
}
