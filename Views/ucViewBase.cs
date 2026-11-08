using System.Windows.Forms;

namespace QuanLyBaiGiuXe.Views
{
    public class ucViewBase : UserControl, IViewCoBan
    {
        public void ThongBao(string noiDung) => UiHelper.ThongBao(noiDung);
        public void BaoLoi(string noiDung) => UiHelper.BaoLoi(noiDung);
        public bool XacNhan(string noiDung) => UiHelper.XacNhan(noiDung);
    }
}
