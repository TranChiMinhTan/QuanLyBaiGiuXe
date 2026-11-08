// [Người 4] In vé / biên nhận có Xem trước (PrintPreview). Dùng chung cho ucTraCuu (và có thể cho ucVanHanh).
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using QuanLyBaiGiuXe.Models;

namespace QuanLyBaiGiuXe.Views
{
    public static class InAn
    {
        public static void XemTruoc(IWin32Window cha, BienNhanDTO bn)
        {
            var pd = new PrintDocument();
            pd.PrintPage += (s, e) => Ve(e, bn);
            using (var dlg = new PrintPreviewDialog { Document = pd, Width = 700, Height = 760 })
                dlg.ShowDialog(cha);                    // bấm nút máy in trong cửa sổ này để in thật
        }

        private static void Ve(PrintPageEventArgs e, BienNhanDTO bn)
        {
            var g = e.Graphics;
            float x = 30, y = 30;
            bool laVeVao = bn.GioRa == null;

            using (var f = new Font("Consolas", 10))
            using (var fd = new Font("Consolas", 13, FontStyle.Bold))
            {
                void Dong(string s, Font font)
                {
                    g.DrawString(s, font, Brushes.Black, x, y);
                    y += font.GetHeight(g) + 6;
                }

                Dong("BÃI GIỮ XE", fd);
                Dong(laVeVao ? "VÉ GỬI XE" : "BIÊN NHẬN XE RA", fd);
                Dong("--------------------------------", f);
                Dong("Mã thẻ : " + bn.MaThe, f);
                Dong("Biển số: " + bn.BienSo, f);
                Dong("Loại xe: " + bn.TenLoaiXe, f);
                Dong("Giờ vào: " + bn.GioVao.ToString("HH:mm dd/MM/yyyy"), f);
                if (!laVeVao)
                {
                    Dong("Giờ ra : " + bn.GioRa.Value.ToString("HH:mm dd/MM/yyyy"), f);
                    Dong("Đã gửi : " + bn.ThoiGianGui, f);
                    Dong("--------------------------------", f);
                    Dong("TỔNG TIỀN: " + bn.Phi.ToString("N0") + " đ", fd);
                }
                Dong("--------------------------------", f);
                Dong(laVeVao ? "Giữ vé để nhận xe" : "Cảm ơn quý khách", f);
            }
            e.HasMorePages = false;
        }
    }
}
