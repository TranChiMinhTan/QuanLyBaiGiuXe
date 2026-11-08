using QuanLyBaiGiuXe.Models;
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
    public partial class ucKhachHang : UserControl, ucViewBase, IKhachHangView
    {
        private KhachHangPresenter _p;

        public ucKhachHang() { InitializeComponent(); }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (UiHelper.DangThietKe) return;
            UiHelper.CaiDatLuoi(dgvKhachHang);
            _p = new KhachHangPresenter(this);
            btnThem.Click += (s, a) => _p.Them();
            btnSua.Click += (s, a) => _p.Sua();
            btnXoa.Click += (s, a) => _p.Xoa();
            btnLamMoi.Click += (s, a) => { txtTim.Clear(); _p.NhapMoi(); _p.Tai(); };
            txtTim.TextChanged += (s, a) => _p.Tai();
            dgvKhachHang.CellClick += (s, a) =>
            {
                var k = a.RowIndex >= 0 ? dgvKhachHang.Rows[a.RowIndex].DataBoundItem as KhachHangDTO : null;
                if (k != null) _p.Chon(k);
            };
            _p.KhoiDong();
        }

        public string MaKH => txtMaKH.Text.Trim();
        public string HoTen => txtHoTen.Text.Trim();
        public string SDT => txtSDT.Text.Trim();
        public string CCCD => txtCCCD.Text.Trim();
        public string DiaChi => txtDiaChi.Text.Trim();
        public string TuKhoaTim => txtTim.Text.Trim();

        public void HienThiDanhSach(List<KhachHangDTO> ds) =>
            UiHelper.DoLuoi(dgvKhachHang, ds, "MaKH|Mã KH", "HoTen|Họ tên", "SDT|SĐT", "CCCD|CCCD",
                            "DiaChi|Địa chỉ", "SoVeThang|Vé tháng");

        public void HienThiChiTiet(KhachHangDTO k)
        {
            txtMaKH.Text = k.MaKH; txtHoTen.Text = k.HoTen; txtSDT.Text = k.SDT;
            txtCCCD.Text = k.CCCD; txtDiaChi.Text = k.DiaChi;
        }

        public void DatMaKH(string maKH) => txtMaKH.Text = maKH;

        public void XoaNhap()
        {
            txtMaKH.Clear(); txtHoTen.Clear(); txtSDT.Clear(); txtCCCD.Clear(); txtDiaChi.Clear();
            txtHoTen.Focus();
        }
    }
}
