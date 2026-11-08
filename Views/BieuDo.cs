// [ ] Biểu đồ cột vẽ bằng GDI+ (Graphics), không dùng control Chart.
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace QuanLyBaiGiuXe.Views
{
    public static class BieuDo
    {
        /// <param name="noiBat">Chỉ số các cột tô màu cam (ví dụ 3 giờ cao điểm). Có thể để null.</param>
        public static void VeCot(Graphics g, Rectangle vung, IList<string> nhan, IList<decimal> giaTri,
                                 string tieuDe, ISet<int> noiBat = null)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Color.White);
            using (var fTieuDe = new Font("Segoe UI", 10, FontStyle.Bold))
                g.DrawString(tieuDe, fTieuDe, Brushes.Black, vung.X + 8, vung.Y + 6);

            using (var f = new Font("Segoe UI", 8))
            {
                if (giaTri.Count == 0)
                {
                    g.DrawString("Không có dữ liệu trong khoảng thời gian này.", f, Brushes.Gray, vung.X + 20, vung.Y + 50);
                    return;
                }

                int le = 62, tren = 36, duoi = 30;
                var khung = new Rectangle(vung.X + le, vung.Y + tren, vung.Width - le - 14, vung.Height - tren - duoi);
                if (khung.Width < 40 || khung.Height < 40) return;

                decimal max = giaTri.Max();
                if (max <= 0) max = 1;

                using (var buta = new Pen(Color.Gainsboro))
                    for (int i = 0; i <= 4; i++)                                  // 5 đường lưới ngang kèm số
                    {
                        float y = khung.Bottom - (float)khung.Height * i / 4;
                        g.DrawLine(buta, khung.Left, y, khung.Right, y);
                        string so = (max * i / 4).ToString("N0");
                        var kt = g.MeasureString(so, f);
                        g.DrawString(so, f, Brushes.DimGray, khung.Left - kt.Width - 4, y - kt.Height / 2);
                    }

                float rongCot = (float)khung.Width / giaTri.Count;
                float rongVe = Math.Max(4f, rongCot * 0.6f);
                int buoc = (int)Math.Ceiling(40f / rongCot);                       // thưa nhãn trục X khi quá dày

                using (var xanh = new SolidBrush(Color.FromArgb(31, 78, 140)))
                using (var cam = new SolidBrush(Color.FromArgb(230, 126, 34)))
                    for (int i = 0; i < giaTri.Count; i++)
                    {
                        float cao = (float)(giaTri[i] / max) * khung.Height;
                        float x = khung.Left + i * rongCot + (rongCot - rongVe) / 2;
                        bool sang = noiBat != null && noiBat.Contains(i);
                        g.FillRectangle(sang ? cam : xanh, x, khung.Bottom - cao, rongVe, cao);

                        if (i % buoc == 0)
                        {
                            var kt = g.MeasureString(nhan[i], f);
                            g.DrawString(nhan[i], f, Brushes.Black, x + rongVe / 2 - kt.Width / 2, khung.Bottom + 4);
                        }
                        if (rongCot >= 44 && giaTri[i] > 0)                         // đủ rộng mới ghi số trên đầu cột
                        {
                            string so = giaTri[i].ToString("N0");
                            var kt = g.MeasureString(so, f);
                            g.DrawString(so, f, Brushes.Black, x + rongVe / 2 - kt.Width / 2, khung.Bottom - cao - kt.Height);
                        }
                    }
                using (var truc = new Pen(Color.Black)) g.DrawLine(truc, khung.Left, khung.Bottom, khung.Right, khung.Bottom);
            }
        }
    }
}
