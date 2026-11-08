namespace QuanLyBaiGiuXe.Views
{
    public interface IDoiMatKhauView : IViewCoBan
    {
        string MatKhauCu { get; }
        string MatKhauMoi { get; }
        string NhapLaiMatKhauMoi { get; }
        void DongForm();
    }
}
