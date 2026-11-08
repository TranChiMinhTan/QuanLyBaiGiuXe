using QuanLyBaiGiuXe.Models;
using QuanLyBaiGiuXe.Presenters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBaiGiuXe.Views
{
    public partial class ucTraCuu : ucViewBase, ITraCuuView
    {
        private TraCuuPresenter _p;

        public ucTraCuu() { InitializeComponent(); }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (UiHelper.DangThietKe) return;
            UiHelper.CaiDatLuoi(dgvKetQua);
            dtpTuNgay.Value = DateTime.Today.AddDays(-7);
            dtpDenNgay.Value = DateTime.Today;

            _p = new TraCuuPresenter(this);
            btnTimKiem.Click += (s, a) => _p.Tim();
            btnInBienNhan.Click += (s, a) => _p.InBienNhan();
            txtBienSo.KeyDown += (s, a) => { if (a.KeyCode == Keys.Enter) { a.SuppressKeyPress = true; _p.Tim(); } };
            txtMaThe.KeyDown += (s, a) => { if (a.KeyCode == Keys.Enter) { a.SuppressKeyPress = true; _p.Tim(); } };
            dgvKetQua.CellClick += (s, a) =>
            {
                var l = a.RowIndex >= 0 ? dgvKetQua.Rows[a.RowIndex].DataBoundItem as LuotGuiDTO : null;
                if (l != null) _p.Chon(l);
            };
            _p.KhoiDong();
        }

        public string BienSo => txtBienSo.Text.Trim();
        public string MaThe => txtMaThe.Text.Trim();
        public DateTime TuNgay => dtpTuNgay.Value.Date;
        public DateTime DenNgay => dtpDenNgay.Value.Date;
        public int? MaLoaiXe => cboLoaiXe.SelectedValue is int v && v > 0 ? (int?)v : null;
        public LuotGuiDTO LuotDangChon => dgvKetQua.CurrentRow != null ? dgvKetQua.CurrentRow.DataBoundItem as LuotGuiDTO : null;

        public void NapLoaiXe(List<LoaiXeDTO> ds)
        {
            var tatCa = new List<LoaiXeDTO> { new LoaiXeDTO { MaLoaiXe = 0, TenLoai = "Tất cả" } };
            tatCa.AddRange(ds);
            cboLoaiXe.DisplayMember = "TenLoai";
            cboLoaiXe.ValueMember = "MaLoaiXe";
            cboLoaiXe.DataSource = tatCa;
        }

        public void HienThiKetQua(List<LuotGuiDTO> ds) =>
            UiHelper.DoLuoi(dgvKetQua, ds, "MaThe|Mã thẻ", "BienSo|Biển số", "TenLoaiXe|Loại xe",
                            "GioVao|Giờ vào|HH:mm dd/MM/yyyy", "GioRa|Giờ ra|HH:mm dd/MM/yyyy", "Phi|Phí (đ)|N0");

        public void HienThiTong(int soLuot, decimal tongPhi) =>
            lblTong.Text = "Tìm thấy " + soLuot + " lượt · Tổng phí: " + tongPhi.ToString("N0") + " đ";

        public void HienThiAnh(string duongDanTuongDoi)
        {
            var pb = Controls.Find("pbAnh", true).OfType<PictureBox>().FirstOrDefault();
            if (pb == null) return;                                         // không có PictureBox thì bỏ qua
            if (pb.Image != null) { pb.Image.Dispose(); pb.Image = null; }
            if (string.IsNullOrEmpty(duongDanTuongDoi)) return;
            string day = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, duongDanTuongDoi);
            if (!File.Exists(day)) return;
            using (var goc = Image.FromFile(day)) pb.Image = new Bitmap(goc);   // copy để không khóa file
        }

        public void InBienNhan(BienNhanDTO bienNhan) => InAn.XemTruoc(this, bienNhan);
    }
}
