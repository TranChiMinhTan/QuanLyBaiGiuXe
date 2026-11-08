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
    public partial class ucLoaiXe : ucViewBase, ILoaiXeView
    {
        private LoaiXePresenter _p;
        private int _ma;

        public ucLoaiXe() { InitializeComponent(); }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (UiHelper.DangThietKe) return;
            UiHelper.CaiDatLuoi(dgvLoaiXe);
            _p = new LoaiXePresenter(this);
            btnThem.Click += (s, a) => _p.Them();
            btnSua.Click += (s, a) => _p.Sua();
            btnXoa.Click += (s, a) => _p.Xoa();
            btnLamMoi.Click += (s, a) => { XoaNhap(); txtTim.Clear(); _p.Tai(); };
            txtTim.TextChanged += (s, a) => _p.Tai();
            dgvLoaiXe.CellClick += (s, a) =>
            {
                var x = a.RowIndex >= 0 ? dgvLoaiXe.Rows[a.RowIndex].DataBoundItem as LoaiXeDTO : null;
                if (x != null) _p.Chon(x);
            };
            _p.Tai();
        }

        public int MaLoaiXe => _ma;
        public string TenLoai => txtTenLoai.Text.Trim();
        public int SucChua => (int)numSucChua.Value;
        public string MoTa => txtMoTa.Text.Trim();
        public string TuKhoaTim => txtTim.Text.Trim();

        public void HienThiDanhSach(List<LoaiXeDTO> ds) =>
            UiHelper.DoLuoi(dgvLoaiXe, ds, "MaLoaiXe|Mã", "TenLoai|Tên loại", "SucChua|Sức chứa",
                            "DangGui|Đang gửi", "ConTrong|Còn trống", "MoTa|Mô tả");

        public void HienThiChiTiet(LoaiXeDTO x)
        {
            _ma = x.MaLoaiXe;
            txtMaLoai.Text = x.MaLoaiXe.ToString();
            txtTenLoai.Text = x.TenLoai;
            numSucChua.Value = Math.Min(numSucChua.Maximum, Math.Max(numSucChua.Minimum, x.SucChua));
            txtMoTa.Text = x.MoTa;
        }

        public void XoaNhap()
        {
            _ma = 0;
            txtMaLoai.Clear(); txtTenLoai.Clear(); txtMoTa.Clear();
            numSucChua.Value = numSucChua.Minimum;
            txtTenLoai.Focus();
        }
    }
}
