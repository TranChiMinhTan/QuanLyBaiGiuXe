// [Người 1] Hợp đồng giữa ucBangGia và BangGiaPresenter.
using System.Collections.Generic;
using QuanLyBaiGiuXe.Models;

namespace QuanLyBaiGiuXe.Views
{
    public interface IBangGiaView : IViewCoBan
    {
        int MaLoaiXe { get; }
        int MienPhiPhut { get; }
        decimal GiaGioDau { get; }
        decimal GiaGioTiepTheo { get; }
        decimal GiaToiDaNgay { get; }       // trần cho mỗi khối 24 giờ
        decimal GiaVeThang { get; }

        void NapLoaiXe(List<LoaiXeDTO> ds);
        void HienThiDanhSach(List<BangGiaDTO> ds);
        void HienThiChiTiet(BangGiaDTO gia);
        void XoaNhap();
    }
}
