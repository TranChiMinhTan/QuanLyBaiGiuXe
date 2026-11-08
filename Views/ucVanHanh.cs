using QuanLyBaiGiuXe.Views;
using QuanLyBaiGiuXe.Models;
using QuanLyBaiGiuXe.Presenters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyBaiGiuXe.Views
{
    public partial class ucVanHanh : UserControl, IVanHanhView
    {
        private VanHanhPresenter _presenter;
        private string _duongDanAnh;
        private BienNhanDTO _bienNhan;
        private readonly PrintDocument _pd = new PrintDocument();
        private readonly OpenFileDialog _ofd = new OpenFileDialog
        {
            Title = "Chọn ảnh biển số",
            Filter = "Ảnh|*.jpg;*.jpeg;*.png"
        };

        public ucVanHanh()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            _presenter = new VanHanhPresenter(this);

            btnXeVao.Click += (s, a) => _presenter.XeVao();
            btnXeRa.Click += (s, a) => _presenter.ThanhToan();
            btnInVe.Click += (s, a) => _presenter.InVe();
            btnChonAnh.Click += BtnChonAnh_Click;
            txtMaThe.KeyDown += (s, a) =>
            {
                if (a.KeyCode != Keys.Enter) return;
                a.SuppressKeyPress = true;
                _presenter.XemPhiXeRa();
            };
            _pd.PrintPage += Pd_PrintPage;

            _presenter.KhoiDong();
        }

        // ================= IVanHanhView: dữ liệu đầu vào =================
        public string BienSo => txtBienSo.Text.Trim();
        public string MaThe => txtMaThe.Text.Trim();
        public int MaLoaiXe => cboLoaiXe.SelectedValue is int v ? v : 0;
        public string DuongDanAnh => _duongDanAnh;
        public bool GiaLapLoi =>
            Controls.Find("chkGiaLapLoi", true).OfType<CheckBox>().Any(c => c.Checked);

        // ================= IVanHanhView: hiển thị =================
        public void NapLoaiXe(List<LoaiXeDTO> ds)
        {
            cboLoaiXe.DisplayMember = "TenLoai";
            cboLoaiXe.ValueMember = "MaLoaiXe";
            cboLoaiXe.DataSource = ds;
        }

        public void HienThiLuotGui(List<LuotGuiDTO> ds)
        {
            dgvLuotGui.DataSource = ds.Select(l => new
            {
                l.MaThe,
                l.BienSo,
                LoaiXe = l.TenLoaiXe,
                l.GioVao,
                l.GioRa,
                l.Phi
            }).ToList();

            DatTieuDe("MaThe", "Mã thẻ");
            DatTieuDe("BienSo", "Biển số");
            DatTieuDe("LoaiXe", "Loại xe");
            DatTieuDe("GioVao", "Giờ vào");
            DatTieuDe("GioRa", "Giờ ra");
            DatTieuDe("Phi", "Phí (đ)");
            if (dgvLuotGui.Columns["GioVao"] != null) dgvLuotGui.Columns["GioVao"].DefaultCellStyle.Format = "HH:mm dd/MM";
            if (dgvLuotGui.Columns["GioRa"] != null) dgvLuotGui.Columns["GioRa"].DefaultCellStyle.Format = "HH:mm dd/MM";
            if (dgvLuotGui.Columns["Phi"] != null) dgvLuotGui.Columns["Phi"].DefaultCellStyle.Format = "N0";
        }

        private void DatTieuDe(string cot, string tieuDe)
        {
            if (dgvLuotGui.Columns[cot] != null) dgvLuotGui.Columns[cot].HeaderText = tieuDe;
        }

        public void HienThiSoDo(List<OGuiDTO> ds)
        {
            pnlSoDo.SuspendLayout();
            while (pnlSoDo.Controls.Count > 0) pnlSoDo.Controls[0].Dispose();

            foreach (var o in ds)
            {
                var btn = new Button
                {
                    Text = o.MaThe + (o.CoXe ? Environment.NewLine + o.BienSo : ""),
                    Width = 76,
                    Height = 52,
                    Font = new Font("Segoe UI", 7.5f),
                    FlatStyle = FlatStyle.Flat,
                    Tag = o.MaThe
                };
                // Màu: xám = thẻ mất, cam = quá 24 giờ, xanh dương = vé tháng, đỏ = có xe, xanh lá = trống
                if (o.TrangThai == "Đã mất") { btn.BackColor = Color.DarkGray; btn.ForeColor = Color.White; }
                else if (o.CoXe && o.QuaHan24h) { btn.BackColor = Color.FromArgb(255, 183, 77); btn.ForeColor = Color.Black; }
                else if (o.CoXe && o.CoVeThang) { btn.BackColor = Color.FromArgb(21, 101, 192); btn.ForeColor = Color.White; }
                else if (o.CoXe) { btn.BackColor = Color.FromArgb(192, 57, 43); btn.ForeColor = Color.White; }
                else { btn.BackColor = Color.FromArgb(165, 214, 167); btn.ForeColor = Color.Black; }

                btn.Click += (s, a) => _presenter.ChonO((string)((Button)s).Tag);
                pnlSoDo.Controls.Add(btn);
            }
            pnlSoDo.ResumeLayout();
        }

        public void HienThiConTrong(int trong, int tong)
        {
            lblConTrong.Text = "Còn trống: " + trong + "/" + tong;
        }

        /*public void HienThiXeTrongBai(int soXe)
        {
            var frm = ParentForm as FrmMain;               // cập nhật thanh trạng thái của form chính
            if (frm != null) frm.CapNhatSoXe(soXe);
        }*/

        public void HienThiCanhBao(string noiDung)
        {
            lblCanhBao.Text = noiDung;
            lblCanhBao.BackColor = string.IsNullOrEmpty(noiDung) ? SystemColors.Control : Color.LemonChiffon;
        }

        public void HienThiXeRa(LuotGuiDTO luot, decimal phi, string ghiChu)
        {
            var tg = luot.ThoiGianGui;
            lblThoiGian.Text = "Vào " + luot.GioVao.ToString("HH:mm dd/MM") + " · " + luot.BienSo + " · " +
                               (int)tg.TotalHours + " giờ " + tg.Minutes + " phút" +
                               (string.IsNullOrEmpty(ghiChu) ? "" : Environment.NewLine + ghiChu);
            HienThiPhi(phi);
        }

        public void HienThiPhi(decimal phi)
        {
            lblPhi.Text = "Phí: " + phi.ToString("N0") + " đ";
        }

        public void HienThiThongTinO(OGuiDTO o)
        {
            if (!o.CoXe) { ThongBao("Thẻ " + o.MaThe + ": " + o.TrangThai + "."); return; }
            var tg = DateTime.Now - o.GioVao.Value;
            ThongBao("Thẻ " + o.MaThe + "\nBiển số: " + o.BienSo +
                     "\nGiờ vào: " + o.GioVao.Value.ToString("HH:mm dd/MM/yyyy") +
                     "\nĐã gửi: " + (int)tg.TotalHours + " giờ " + tg.Minutes + " phút" +
                     (o.CoVeThang ? "\nCó vé tháng" : ""));
        }

        public void DatMaThe(string maThe)
        {
            txtMaThe.Text = maThe;
        }

        public void XoaNhap()
        {
            txtBienSo.Clear();
            txtMaThe.Clear();
            _duongDanAnh = null;
            if (pbBienSo.Image != null) { pbBienSo.Image.Dispose(); pbBienSo.Image = null; }
            lblThoiGian.Text = "";
            lblPhi.Text = "";
            txtBienSo.Focus();
        }

        // ================= IViewCoBan =================
        public void ThongBao(string noiDung) =>
            MessageBox.Show(noiDung, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        public void BaoLoi(string noiDung) =>
            MessageBox.Show(noiDung, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

        public bool XacNhan(string noiDung) =>
            MessageBox.Show(noiDung, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

        // ================= Chọn ảnh biển số (chỉ là thao tác giao diện) =================
        private void BtnChonAnh_Click(object sender, EventArgs e)
        {
            if (_ofd.ShowDialog(this) != DialogResult.OK) return;
            _duongDanAnh = _ofd.FileName;
            if (pbBienSo.Image != null) pbBienSo.Image.Dispose();
            using (var goc = Image.FromFile(_duongDanAnh))
                pbBienSo.Image = new Bitmap(goc);          // copy ra Bitmap để không khóa file ảnh gốc
        }

        // ================= In vé / biên nhận (PrintPreview) =================
        public void InBienNhan(BienNhanDTO bienNhan)
        {
            _bienNhan = bienNhan;
            using (var dlg = new PrintPreviewDialog { Document = _pd, Width = 700, Height = 760 })
                dlg.ShowDialog(this);                      // bấm nút máy in trong cửa sổ này để in thật
        }

        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (_bienNhan == null) return;
            var g = e.Graphics;
            float x = 30, y = 30;
            bool laVeVao = _bienNhan.GioRa == null;

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
                Dong("Mã thẻ : " + _bienNhan.MaThe, f);
                Dong("Biển số: " + _bienNhan.BienSo, f);
                Dong("Loại xe: " + _bienNhan.TenLoaiXe, f);
                Dong("Giờ vào: " + _bienNhan.GioVao.ToString("HH:mm dd/MM/yyyy"), f);
                if (!laVeVao)
                {
                    Dong("Giờ ra : " + _bienNhan.GioRa.Value.ToString("HH:mm dd/MM/yyyy"), f);
                    Dong("Đã gửi : " + _bienNhan.ThoiGianGui, f);
                    Dong("--------------------------------", f);
                    Dong("TỔNG TIỀN: " + _bienNhan.Phi.ToString("N0") + " đ", fd);
                }
                Dong("--------------------------------", f);
                Dong(laVeVao ? "Giữ vé để nhận xe" : "Cảm ơn quý khách", f);
            }
            e.HasMorePages = false;
        }
    }
}
