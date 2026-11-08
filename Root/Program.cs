// [ ] Đăng nhập, mở FrmMain; Đăng xuất thì quay lại màn hình đăng nhập. (Thay file Program.cs cũ.)
using System;
using System.Windows.Forms;
using QuanLyBaiGiuXe.BLL;
using QuanLyBaiGiuXe.Models;
using QuanLyBaiGiuXe.Views;

namespace QuanLyBaiGiuXe
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            while (true)
            {
                TaiKhoanDTO tk;
                using (var dangNhap = new FrmDangNhap())
                {
                    if (dangNhap.ShowDialog() != DialogResult.OK) return;
                    tk = dangNhap.TaiKhoanDangNhap;
                }
                PhienLamViec.TaiKhoan = tk;

                var main = new FrmMain(tk);
                Application.Run(main);
                if (!main.DangXuat) return;
                PhienLamViec.TaiKhoan = null;
            }
        }
    }
}