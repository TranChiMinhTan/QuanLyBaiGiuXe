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
    public partial class ucVeThang : ucViewBase, IVeThangView
    {
        private VeThangPresenter _p;
        private int _maVe;
        private bool _dangNap;

        public ucVeThang() { InitializeComponent(); }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (UiHelper.DangThietKe) return;
            UiHelper.CaiDatLuoi(dgvVeThang);
            numSoThang.Minimum = 1; numSoThang.Maximum = 12;
            _p = new VeThangPresenter(this);

            btnDangKy.Click += (s, a) => _p.DangKy();
            btnGiaHan.Click += (s, a) => _p.GiaHan();
            btnSua.Click += (s, a) => _p.Sua();
            btnXoa.Click += (s, a) => _p.Huy();
            txtTim.TextChanged += (s, a) => _p.Tai();
            dtpNgayDangKy.ValueChanged += (s, a) => { if (!_dangNap) _p.CapNhatNgayHetHan(); };
            numSoThang.ValueChanged += (s, a) => { if (!_dangNap) _p.CapNhatNgayHetHan(); };
            cboKhachHang.SelectedIndexChanged += (s, a) =>
            {
                var k = cboKhachHang.SelectedItem as KhachHangDTO;
                txtSDT.Text = k != null ? k.SDT : "";
            };
            dgvVeThang.CellClick += (s, a) =>
            {
                var v = a.RowIndex >= 0 ? dgvVeThang.Rows[a.RowIndex].DataBoundItem as VeThangDTO : null;
                if (v != null) _p.Chon(v);
            };
            _p.KhoiDong();
        }

        public int MaVe => _maVe;
        public string BienSo => txtBienSo.Text.Trim();
        public string MaKH => cboKhachHang.SelectedValue as string;
        public int MaLoaiXe => cboLoaiXe.SelectedValue is int v ? v : 0;
        public DateTime NgayDangKy => dtpNgayDangKy.Value.Date;
        public int SoThang => (int)numSoThang.Value;
        public string TuKhoaTim => txtTim.Text.Trim();

        public void NapKhachHang(List<KhachHangDTO> ds)
        {
            cboKhachHang.DisplayMember = "TenHienThi";
            cboKhachHang.ValueMember = "MaKH";
            cboKhachHang.DataSource = ds;
        }

        public void NapLoaiXe(List<LoaiXeDTO> ds)
        {
            cboLoaiXe.DisplayMember = "TenLoai";
            cboLoaiXe.ValueMember = "MaLoaiXe";
            cboLoaiXe.DataSource = ds;
        }

        public void HienThiDanhSach(List<VeThangDTO> ds)
        {
            UiHelper.DoLuoi(dgvVeThang, ds, "BienSo|Biển số", "HoTenKhach|Khách hàng", "TenLoaiXe|Loại xe",
                            "NgayDangKy|Ngày đăng ký|dd/MM/yyyy", "NgayHetHan|Ngày hết hạn|dd/MM/yyyy",
                            "ConLai|Còn lại (ngày)", "TinhTrang|Tình trạng");
            foreach (System.Windows.Forms.DataGridViewRow dong in dgvVeThang.Rows)
            {
                var ve = dong.DataBoundItem as VeThangDTO;
                if (ve == null) continue;
                if (ve.TinhTrang == "Sắp hết hạn") dong.DefaultCellStyle.BackColor = Color.LemonChiffon;
                else if (ve.TinhTrang == "Hết hạn") dong.DefaultCellStyle.BackColor = Color.MistyRose;
                else if (ve.TinhTrang == "Đã hủy") dong.DefaultCellStyle.BackColor = Color.LightGray;
            }
        }

        public void HienThiChiTiet(VeThangDTO ve)
        {
            _dangNap = true;
            _maVe = ve.MaVe;
            txtBienSo.Text = ve.BienSo;
            cboKhachHang.SelectedValue = ve.MaKH;
            cboLoaiXe.SelectedValue = ve.MaLoaiXe;
            dtpNgayDangKy.Value = ve.NgayDangKy;
            numSoThang.Value = 1;                     // số tháng dùng cho lần GIA HẠN tiếp theo
            _dangNap = false;
            HienThiNgayHetHan(ve.NgayHetHan);
        }

        public void HienThiNgayHetHan(DateTime ngay) => lblNgayHetHan.Text = "Hết hạn: " + ngay.ToString("dd/MM/yyyy");

        public void HienThiCanhBaoVe(string noiDung)
        {
            lblCanhBaoVe.Text = noiDung;
            lblCanhBaoVe.BackColor = string.IsNullOrEmpty(noiDung) ? SystemColors.Control : Color.LemonChiffon;
        }

        public void XoaNhap()
        {
            _dangNap = true;
            _maVe = 0;
            txtBienSo.Clear();
            dtpNgayDangKy.Value = DateTime.Today;
            numSoThang.Value = 1;
            _dangNap = false;
            txtBienSo.Focus();
        }
    }
}
