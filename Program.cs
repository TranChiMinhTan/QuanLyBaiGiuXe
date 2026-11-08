using System;
using System.Windows.Forms;
using QuanLyBaiXe.BLL;
using QuanLyBaiXe.DAL;
using QuanLyBaiXe.GUI;

namespace QuanLyBaiXe
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string loi;
            if (!Database.KiemTraKetNoi(out loi))
            {
                MessageBox.Show(
                    "Không kết nối được cơ sở dữ liệu.\n\n" + loi +
                    "\n\nHãy kiểm tra SQL Server đã chạy, đã chạy Scripts/Database.sql và chuỗi kết nối trong App.config.",
                    "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Vòng lặp để hỗ trợ "Đăng xuất" -> quay lại màn hình đăng nhập
            while (true)
            {
                PhienDangNhap.NguoiDung = null;

                using (FrmDangNhap dangNhap = new FrmDangNhap())
                {
                    if (dangNhap.ShowDialog() != DialogResult.OK) return;
                }

                FrmMain main = new FrmMain();
                Application.Run(main);
                if (!main.DangXuat) return;
            }
        }
    }
}
