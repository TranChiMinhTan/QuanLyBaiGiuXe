// [ ] Hợp đồng giữa ucLoaiXe và LoaiXePresenter.
using System.Collections.Generic;
using QuanLyBaiGiuXe.Models;

namespace QuanLyBaiGiuXe.Views
{
    public interface ILoaiXeView : IViewCoBan
    {
        int MaLoaiXe { get; }               // 0 khi đang thêm mới
        string TenLoai { get; }
        int SucChua { get; }
        string MoTa { get; }
        string TuKhoaTim { get; }

        void HienThiDanhSach(List<LoaiXeDTO> ds);
        void HienThiChiTiet(LoaiXeDTO loaiXe);          // đổ dòng đang chọn lên các ô nhập
        void XoaNhap();
    }
}
