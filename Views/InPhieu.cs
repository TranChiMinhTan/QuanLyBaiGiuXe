// [Người 4] In vé khi xe vào và biên nhận khi xe ra, từ BienNhanDTO (hợp đồng chung giữa Người 2 và Người 4).
//   BienNhanDTO.GioRa == null  -> in VÉ GỬI XE
//   BienNhanDTO.GioRa != null  -> in BIÊN NHẬN THANH TOÁN
// Người 2 gọi trong ucVanHanh:  public void InBienNhan(BienNhanDTO bn) { InPhieu.XemTruoc(FindForm(), bn); }
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Globalization;
using System.Windows.Forms;
using QuanLyBaiXe.Models;

namespace QuanLyBaiXe.Views
{
    public static class InPhieu
    {
        private static readonly CultureInfo VN = new CultureInfo("vi-VN");

        public static string Tien(decimal soTien)
        {
            return soTien.ToString("N0", VN) + " đ";
        }

        /// <summary>Mở hộp thoại xem trước; từ đó người dùng bấm nút in nếu muốn.</summary>
        public static void XemTruoc(IWin32Window owner, BienNhanDTO bn)
        {
            if (bn == null) return;

            bool daRa = bn.GioRa.HasValue;
            var dong = new List<string[]>
            {
                new[] { "Mã thẻ", bn.MaThe },
                new[] { "Biển số", bn.BienSo },
                new[] { "Loại xe", bn.TenLoaiXe },
                new[] { "Giờ vào", bn.GioVao.ToString("dd/MM/yyyy HH:mm") }
            };
            if (daRa)
            {
                dong.Add(new[] { "Giờ ra", bn.GioRa.Value.ToString("dd/MM/yyyy HH:mm") });
                dong.Add(new[] { "Thời gian gửi", bn.ThoiGianGui });
            }

            string tieuDe = daRa ? "BIÊN NHẬN THANH TOÁN" : "VÉ GỬI XE";
            string[] tong = daRa ? new[] { "TỔNG TIỀN", Tien(bn.Phi) } : null;
            string chanTrang = daRa
                ? "Cảm ơn quý khách!"
                : "Vui lòng giữ vé cẩn thận.\nMất vé xin báo nhân viên.";

            XemTruocPhieu(owner, tieuDe, dong, tong, chanTrang);
        }

        // Giấy nhiệt khổ 80 mm. Đơn vị PrintDocument: 1/100 inch (315 ≈ 80 mm).
        private static void XemTruocPhieu(IWin32Window owner, string tieuDe, List<string[]> dong,
                                          string[] tong, string chanTrang)
        {
            string[] dongChanTrang = chanTrang.Split('\n');
            var pd = new PrintDocument { DocumentName = tieuDe };

            int cao = 70 + dong.Count * 22 + (tong != null ? 40 : 0) + dongChanTrang.Length * 14 + 40;
            pd.DefaultPageSettings.PaperSize = new PaperSize("Phieu80mm", 315, cao);
            pd.DefaultPageSettings.Margins = new Margins(10, 10, 10, 10);

            pd.PrintPage += (s, e) =>
            {
                Graphics g = e.Graphics;
                float x = 10;
                float w = e.PageBounds.Width - 20;
                float y = 10;

                using (Font fTen = new Font("Arial", 11, FontStyle.Bold))
                using (Font fTieuDe = new Font("Arial", 13, FontStyle.Bold))
                using (Font fThuong = new Font("Arial", 9))
                using (Font fDam = new Font("Arial", 9, FontStyle.Bold))
                using (Font fTong = new Font("Arial", 11, FontStyle.Bold))
                using (Font fNho = new Font("Arial", 8, FontStyle.Italic))
                using (StringFormat giua = new StringFormat { Alignment = StringAlignment.Center })
                using (StringFormat phai = new StringFormat { Alignment = StringAlignment.Far })
                using (Pen net = new Pen(Color.Black) { DashStyle = DashStyle.Dash })
                {
                    g.DrawString("BÃI GIỮ XE", fTen, Brushes.Black, new RectangleF(x, y, w, 20), giua);
                    y += 22;
                    g.DrawString(tieuDe, fTieuDe, Brushes.Black, new RectangleF(x, y, w, 24), giua);
                    y += 28;
                    g.DrawLine(net, x, y, x + w, y);
                    y += 8;

                    foreach (string[] d in dong)
                    {
                        g.DrawString(d[0], fThuong, Brushes.Black, x, y);
                        g.DrawString(d[1] ?? "", fDam, Brushes.Black, new RectangleF(x, y, w, 20), phai);
                        y += 22;
                    }

                    if (tong != null)
                    {
                        g.DrawLine(net, x, y, x + w, y);
                        y += 8;
                        g.DrawString(tong[0], fTong, Brushes.Black, x, y);
                        g.DrawString(tong[1], fTong, Brushes.Black, new RectangleF(x, y, w, 24), phai);
                        y += 32;
                    }

                    g.DrawLine(net, x, y, x + w, y);
                    y += 8;
                    foreach (string dongCuoi in dongChanTrang)
                    {
                        g.DrawString(dongCuoi, fNho, Brushes.Black, new RectangleF(x, y, w, 14), giua);
                        y += 14;
                    }
                }
                e.HasMorePages = false;
            };

            HienXemTruoc(owner, pd, tieuDe);
        }

        private static void HienXemTruoc(IWin32Window owner, PrintDocument pd, string tieuDe)
        {
            try
            {
                using (PrintPreviewDialog dlg = new PrintPreviewDialog())
                {
                    dlg.Document = pd;
                    dlg.Text = "Xem trước: " + tieuDe;
                    dlg.Width = 500;
                    dlg.Height = 700;
                    dlg.UseAntiAlias = true;
                    dlg.StartPosition = FormStartPosition.CenterParent;
                    dlg.ShowDialog(owner);
                }
            }
            catch (InvalidPrinterException)
            {
                MessageBox.Show("Máy chưa cài đặt máy in nào nên không thể xem trước.\n" +
                                "Hãy cài một máy in (có thể dùng 'Microsoft Print to PDF') rồi thử lại.",
                                "Không có máy in", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}