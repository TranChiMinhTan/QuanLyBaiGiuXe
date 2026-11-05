// [Người 1] Hợp đồng giữa ucBangGia và BangGiaPresenter.
using System.Collections.Generic;
using QuanLyBaiXe.Models;

namespace QuanLyBaiXe.Views
{
    public interface IBangGiaView : IViewCoBan
    {
        int MaLoaiXe { get; }
        int MienPhiPhut { get; }
        decimal GiaKhoi { get; }
        int SoGioKhoi { get; }
        decimal PhuThuQuaDem { get; }
        decimal GiaVeThang { get; }

        void NapLoaiXe(List<LoaiXeDTO> ds);
        void HienThiDanhSach(List<BangGiaDTO> ds);
        void HienThiChiTiet(BangGiaDTO gia);
        void XoaNhap();
    }
}
