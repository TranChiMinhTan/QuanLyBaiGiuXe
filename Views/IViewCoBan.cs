// [ ] Ba hàm mà MỌI màn hình đều cần. Các interface View khác kế thừa interface này.
namespace QuanLyBaiGiuXe.Views
{
    public interface IViewCoBan
    {
        void ThongBao(string noiDung);
        void BaoLoi(string noiDung);
        bool XacNhan(string noiDung);       // true = người dùng chọn Yes
    }
}
