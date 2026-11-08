using QuanLyBaiGiuXe.Models;
using QuanLyBaiGiuXe.Presenters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBaiGiuXe.Views
{
    public partial class ucBaoCao :  ucViewBase, IBaoCaoView
    {
        private BaoCaoPresenter _p;
        private List<DoanhThuDTO> _dsBieuDo = new List<DoanhThuDTO>();

        public ucBaoCao() { InitializeComponent(); }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (UiHelper.DangThietKe) return;
            UiHelper.CaiDatLuoi(dgvBaoCao);
            UiHelper.BatDoubleBuffer(pnlBieuDo);
            dtpTu.Value = DateTime.Today.AddDays(-6);
            dtpDen.Value = DateTime.Today;

            _p = new BaoCaoPresenter(this);
            btnXem.Click += (s, a) => _p.Xem();
            btnXuatCsv.Click += (s, a) => _p.XuatCsv();
            btnGioCaoDiem.Click += (s, a) => _p.GioCaoDiem();
            btnGoiYVeThang.Click += (s, a) => _p.GoiYVeThang();
            pnlBieuDo.Paint += (s, a) => BieuDo.VeCot(a.Graphics, pnlBieuDo.ClientRectangle,
                _dsBieuDo.Select(d => d.Nhan).ToList(), _dsBieuDo.Select(d => d.DoanhThu).ToList(),
                TheoThang ? "Doanh thu theo tháng (đ)" : "Doanh thu theo ngày (đ)");
            pnlBieuDo.Resize += (s, a) => pnlBieuDo.Invalidate();
            _p.Xem();
        }

        public DateTime TuNgay => dtpTu.Value.Date;
        public DateTime DenNgay => dtpDen.Value.Date;
        public bool TheoThang => rdoTheoThang.Checked;

        public void HienThiBang(List<DoanhThuDTO> ds) =>
            UiHelper.DoLuoi(dgvBaoCao, ds, "Nhan|Thời gian", "SoLuot|Số lượt", "DoanhThu|Doanh thu (đ)|N0");

        public void VeBieuDo(List<DoanhThuDTO> ds) { _dsBieuDo = ds; pnlBieuDo.Invalidate(); }

        public void HienThiTong(decimal doanhThuLuotGui, decimal doanhThuVeThang) =>
            lblTong.Text = "Tổng: " + (doanhThuLuotGui + doanhThuVeThang).ToString("N0") + " đ  (lượt gửi " +
                           doanhThuLuotGui.ToString("N0") + " + vé tháng " + doanhThuVeThang.ToString("N0") + ")";

        public string ChonNoiLuuCsv()
        {
            using (var dlg = new SaveFileDialog
            {
                Title = "Xuất báo cáo doanh thu",
                Filter = "CSV (mở được bằng Excel)|*.csv",
                FileName = "DoanhThu_" + DateTime.Now.ToString("yyyyMMdd") + ".csv"
            })
                return dlg.ShowDialog(this) == DialogResult.OK ? dlg.FileName : null;
        }

        public void HienThiGioCaoDiem(List<GioCaoDiemDTO> ds) { using (var f = new FrmGioCaoDiem(ds)) f.ShowDialog(this); }
        public void HienThiGoiYVeThang(List<GoiYVeThangDTO> ds) { using (var f = new FrmGoiYVeThang(ds)) f.ShowDialog(this); }
    }
}
