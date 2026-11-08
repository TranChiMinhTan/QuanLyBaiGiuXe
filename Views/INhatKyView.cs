// [Người 1] [SÁNG TẠO #6] Hợp đồng giữa FrmNhatKy và NhatKyPresenter.
using System.Collections.Generic;
using QuanLyBaiGiuXe.Models;

namespace QuanLyBaiGiuXe.Views
{
    public interface INhatKyView : IViewCoBan
    {
        string TuKhoaTim { get; }
        void HienThiDanhSach(List<NhatKyDTO> ds);
    }
}
