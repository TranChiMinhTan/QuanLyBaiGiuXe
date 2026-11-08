// [Người 4] Báo cáo doanh thu: bảng + biểu đồ GDI+ + tổng + xuất CSV.
// Biểu đồ: cột = doanh thu (trục trái), đường = số lượt xe ra (trục phải). Vẽ bằng Graphics trong sự kiện Paint,
// không dùng control Chart (theo yêu cầu đề: biểu đồ bằng GDI+).
// Namespace phải trùng với ucBaoCao.Designer.cs (QuanLyBaiGiuXe.Views).
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using QuanLyBaiXe.Models;
using QuanLyBaiXe.Presenters;
using QuanLyBaiXe.Views;

namespace QuanLyBaiGiuXe.Views
{
    public partial class ucBaoCao : UserControl, IBaoCaoView
    {
        private static readonly CultureInfo VN = new CultureInfo("vi-VN");
        private static readonly Color MauCot = Color.FromArgb(52, 120, 246);
        private static readonly Color MauLuot = Color.FromArgb(255, 149, 0);

        private readonly BaoCaoPresenter _presenter;
        private List<DoanhThuDTO> _dsBieuDo = new List<DoanhThuDTO>();
        private bool _bieuDoTheoThang;

        public ucBaoCao()
        {
            InitializeComponent();
            _presenter = new BaoCaoPresenter(this);

            KhoiTaoLuoi();
            rdoTheoNgay.Checked = true;
            dtpTuNgay.Value = DateTime.Today.AddDays(-29);
            dtpDenNgay.Value = DateTime.Today;

            // Bật double buffer cho Panel để vẽ lại không bị nhấp nháy.
            typeof(Control).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)
                           .SetValue(pnlBieuDo, true, null);
            pnlBieuDo.BackColor = Color.White;
            pnlBieuDo.Paint += pnlBieuDo_Paint;
            pnlBieuDo.Resize += (s, e) => pnlBieuDo.Invalidate();

            btnXem.Click += (s, e) => _presenter.Xem();
            btnXuatCsv.Click += (s, e) => _presenter.XuatCsv();

            Load += (s, e) => { if (!DesignMode) _presenter.KhoiDong(); };
        }

        private void KhoiTaoLuoi()
        {
            dgvBaoCao.AutoGenerateColumns = false;
            dgvBaoCao.ReadOnly = true;
            dgvBaoCao.AllowUserToAddRows = false;
            dgvBaoCao.AllowUserToDeleteRows = false;
            dgvBaoCao.RowHeadersVisible = false;
            dgvBaoCao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBaoCao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvBaoCao.Columns.Add("colNhan", "Thời gian");
            dgvBaoCao.Columns.Add("colSoLuot", "Số lượt xe ra");
            dgvBaoCao.Columns.Add("colDoanhThu", "Doanh thu (đ)");
            dgvBaoCao.Columns["colSoLuot"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvBaoCao.Columns["colDoanhThu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            foreach (DataGridViewColumn c in dgvBaoCao.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        // ------------------------------------------------------------------
        //  IBaoCaoView
        // ------------------------------------------------------------------
        public DateTime TuNgay { get { return dtpTuNgay.Value.Date; } }
        public DateTime DenNgay { get { return dtpDenNgay.Value.Date; } }
        public bool TheoThang { get { return rdoTheoThang.Checked; } }

        public void HienThiBang(List<DoanhThuDTO> ds)
        {
            dgvBaoCao.SuspendLayout();
            dgvBaoCao.Rows.Clear();
            foreach (DoanhThuDTO d in ds)
                dgvBaoCao.Rows.Add(d.Nhan, d.SoLuot, d.DoanhThu.ToString("N0", VN));
            dgvBaoCao.ResumeLayout();
        }

        public void VeBieuDo(List<DoanhThuDTO> ds)
        {
            _dsBieuDo = ds ?? new List<DoanhThuDTO>();
            _bieuDoTheoThang = rdoTheoThang.Checked;
            pnlBieuDo.Invalidate();
        }

        public void HienThiTong(decimal doanhThuLuotGui, decimal doanhThuVeThang)
        {
            lblTong.Text = string.Format("Tổng: {0} (lượt gửi {1} + vé tháng {2})",
                InPhieu.Tien(doanhThuLuotGui + doanhThuVeThang),
                InPhieu.Tien(doanhThuLuotGui),
                InPhieu.Tien(doanhThuVeThang));
        }

        public string ChonNoiLuuCsv()
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Title = "Xuất báo cáo doanh thu";
                sfd.Filter = "CSV (*.csv)|*.csv";
                sfd.FileName = "DoanhThu_" + DateTime.Now.ToString("yyyyMMdd") + ".csv";
                return sfd.ShowDialog(FindForm()) == DialogResult.OK ? sfd.FileName : null;
            }
        }

        // IViewCoBan
        public void ThongBao(string noiDung)
        {
            MessageBox.Show(noiDung, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void BaoLoi(string noiDung)
        {
            MessageBox.Show(noiDung, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public bool XacNhan(string noiDung)
        {
            return MessageBox.Show(noiDung, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        // ------------------------------------------------------------------
        //  BIỂU ĐỒ GDI+
        // ------------------------------------------------------------------
        private void pnlBieuDo_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            VeBieuDoGdi(e.Graphics, pnlBieuDo.ClientRectangle);
        }

        private void VeBieuDoGdi(Graphics g, Rectangle vung)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            using (Font fTieuDe = new Font("Segoe UI", 12f, FontStyle.Bold))
            using (Font fNho = new Font("Segoe UI", 8.5f))
            using (Font fSo = new Font("Segoe UI", 8f, FontStyle.Bold))
            using (StringFormat giua = new StringFormat { Alignment = StringAlignment.Center })
            using (StringFormat phai = new StringFormat { Alignment = StringAlignment.Far })
            using (Pen penTruc = new Pen(Color.Black, 1.5f))
            using (Pen penLuoi = new Pen(Color.Gainsboro, 1f))
            using (Pen penDuong = new Pen(MauLuot, 2.5f))
            using (SolidBrush brCot = new SolidBrush(MauCot))
            using (SolidBrush brLuot = new SolidBrush(MauLuot))
            {
                string tieuDe = _bieuDoTheoThang ? "DOANH THU THEO THÁNG" : "DOANH THU THEO NGÀY";
                g.DrawString(tieuDe, fTieuDe, Brushes.Black,
                             new RectangleF(vung.Left, vung.Top + 8, vung.Width, 24), giua);

                if (_dsBieuDo.Count == 0)
                {
                    g.DrawString("Chưa có dữ liệu. Chọn khoảng ngày rồi bấm Xem.", fNho, Brushes.Gray,
                                 new RectangleF(vung.Left, vung.Top + vung.Height / 2f - 10, vung.Width, 20), giua);
                    return;
                }

                // Chú giải
                float lx = vung.Left + 70;
                float ly = vung.Top + 40;
                g.FillRectangle(brCot, lx, ly, 12, 12);
                g.DrawString("Doanh thu (cột, trục trái)", fNho, Brushes.Black, lx + 16, ly - 3);
                g.DrawLine(penDuong, lx + 190, ly + 6, lx + 214, ly + 6);
                g.FillEllipse(brLuot, lx + 196, ly + 2, 8, 8);
                g.DrawString("Số lượt xe ra (đường, trục phải)", fNho, Brushes.Black, lx + 220, ly - 3);

                const int leTrai = 75, lePhai = 55, leTren = 70, leDuoi = 45;
                var plot = new Rectangle(vung.Left + leTrai, vung.Top + leTren,
                                         vung.Width - leTrai - lePhai, vung.Height - leTren - leDuoi);
                if (plot.Width < 80 || plot.Height < 60) return;

                double buocTien, buocLuot;
                double maxTien = ChonThang((double)_dsBieuDo.Max(x => x.DoanhThu), 5, false, out buocTien);
                double maxLuot = ChonThang(_dsBieuDo.Max(x => x.SoLuot), 5, true, out buocLuot);

                // Lưới ngang + nhãn trục trái (tiền)
                int soVach = (int)Math.Round(maxTien / buocTien);
                for (int i = 0; i <= soVach; i++)
                {
                    double v = i * buocTien;
                    float y = plot.Bottom - (float)(v / maxTien * plot.Height);
                    g.DrawLine(penLuoi, plot.Left, y, plot.Right, y);
                    g.DrawString(NganTien((decimal)v), fNho, Brushes.Black,
                                 new RectangleF(plot.Left - 70, y - 8, 64, 16), phai);
                }

                // Nhãn trục phải (số lượt)
                int soVachLuot = (int)Math.Round(maxLuot / buocLuot);
                for (int i = 0; i <= soVachLuot; i++)
                {
                    double v = i * buocLuot;
                    float y = plot.Bottom - (float)(v / maxLuot * plot.Height);
                    g.DrawString(v.ToString("0", VN), fNho, Brushes.DimGray, plot.Right + 6, y - 8);
                }

                // Trục
                g.DrawLine(penTruc, plot.Left, plot.Top, plot.Left, plot.Bottom);
                g.DrawLine(penTruc, plot.Left, plot.Bottom, plot.Right, plot.Bottom);

                // Cột doanh thu + điểm số lượt
                int n = _dsBieuDo.Count;
                float rongNhom = (float)plot.Width / n;
                float rongCot = Math.Min(40f, rongNhom * 0.6f);
                int nhay = Math.Max(1, (int)Math.Ceiling((_bieuDoTheoThang ? 62f : 42f) / rongNhom));
                bool ghiSo = rongNhom >= 46f;
                var diem = new PointF[n];

                for (int i = 0; i < n; i++)
                {
                    DoanhThuDTO d = _dsBieuDo[i];
                    float tam = plot.Left + rongNhom * (i + 0.5f);

                    float cao = (float)((double)d.DoanhThu / maxTien * plot.Height);
                    if (cao > 0)
                    {
                        g.FillRectangle(brCot, tam - rongCot / 2f, plot.Bottom - cao, rongCot, cao);
                        if (ghiSo)
                            g.DrawString(NganTien(d.DoanhThu), fSo, Brushes.Black,
                                         new RectangleF(tam - 30, plot.Bottom - cao - 15, 60, 14), giua);
                    }

                    diem[i] = new PointF(tam, plot.Bottom - (float)(d.SoLuot / maxLuot * plot.Height));

                    if (i % nhay == 0)
                        g.DrawString(d.Nhan, fNho, Brushes.Black,
                                     new RectangleF(tam - 32, plot.Bottom + 5, 64, 16), giua);
                }

                if (n >= 2) g.DrawLines(penDuong, diem);
                for (int i = 0; i < n; i++)
                {
                    g.FillEllipse(brLuot, diem[i].X - 3.5f, diem[i].Y - 3.5f, 7f, 7f);
                    if (ghiSo && _dsBieuDo[i].SoLuot > 0)
                        g.DrawString(_dsBieuDo[i].SoLuot.ToString(), fSo, Brushes.DarkOrange,
                                     new RectangleF(diem[i].X - 15, diem[i].Y - 20, 30, 14), giua);
                }
            }
        }

        /// <summary>Chọn bước chia "đẹp" (1, 2, 5 x 10^k) để trục có khoảng 'soVach' vạch; trả về giá trị tối đa của trục.</summary>
        private static double ChonThang(double max, int soVach, bool soNguyen, out double buoc)
        {
            if (max <= 0) max = 1;
            double tho = max / soVach;
            double bac = Math.Pow(10, Math.Floor(Math.Log10(tho)));
            double h = tho / bac;
            double dep = h <= 1 ? 1 : h <= 2 ? 2 : h <= 5 ? 5 : 10;
            buoc = dep * bac;
            if (soNguyen && buoc < 1) buoc = 1;
            return Math.Ceiling(max / buoc) * buoc;
        }

        /// <summary>1.500.000 -> "1,5 tr", 250.000 -> "250k".</summary>
        private static string NganTien(decimal v)
        {
            if (v >= 1000000m) return (v / 1000000m).ToString("0.##", VN) + " tr";
            if (v >= 1000m) return (v / 1000m).ToString("0.##", VN) + "k";
            return v.ToString("0", VN);
        }
    }
}