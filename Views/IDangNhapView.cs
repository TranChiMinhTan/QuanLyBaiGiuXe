// [ ] Hợp đồng giữa FrmDangNhap và DangNhapPresenter.
using QuanLyBaiGiuXe.Models;

namespace QuanLyBaiGiuXe.Views
{
    public interface IDangNhapView : IViewCoBan
    {
        string TenDangNhap { get; }
        string MatKhau { get; }

        void DangNhapThanhCong(TaiKhoanDTO taiKhoan);   // gán kết quả, DialogResult = OK, đóng form
        void XoaMatKhau();
    }
}
