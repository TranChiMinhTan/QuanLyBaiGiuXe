// [Người 1] Hợp đồng giữa FrmDangNhap và DangNhapPresenter.
using QuanLyBaiXe.Models;

namespace QuanLyBaiXe.Views
{
    public interface IDangNhapView : IViewCoBan
    {
        string TenDangNhap { get; }
        string MatKhau { get; }

        void DangNhapThanhCong(TaiKhoanDTO taiKhoan);   // gán kết quả, DialogResult = OK, đóng form
        void XoaMatKhau();
    }
}
