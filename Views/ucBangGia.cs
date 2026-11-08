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
    public partial class ucBangGia : UserControl, IBangGiaView, ucViewBase
    {
        private BangGiaPresenter _p;
        public ucBangGia()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (UiHelper.DangThietKe) return;
            UiHelper.CaiDatLuoi(dgvBangGia);
            _p = new BangGiaPresenter(this);
            btnThem.Click += (s, a) => _p.Them();
            btnCapNhat.Click += (s, a) => _p.CapNhat();
            btnXoa.Click += (s, a) => _p.Xoa();
            dgvBangGia.CellClick += (s, a) =>
            {
                var g = a.RowIndex >= 0 ? dgvBangGia.Rows[a.RowIndex].DataBoundItem as BangGiaDTO : null;
                if (g != null) _p.Chon(g);
            };
            _p.KhoiDong();
        }

        public int MaLoaiXe => cboLoaiXe.SelectedValue is int v ? v : 0;
        public int MienPhiPhut => (int)numMienPhiPhut.Value;
        public decimal GiaKhoi => numGiaKhoi.Value;
        public int SoGioKhoi => (int)numSoGioKhoi.Value;
        public decimal PhuThuQuaDem => numPhuThuQuaDem.Value;
        public decimal GiaVeThang => numGiaVeThang.Value;

        public void NapLoaiXe(List<LoaiXeDTO> ds)
        {
            cboLoaiXe.DisplayMember = "TenLoai";
            cboLoaiXe.ValueMember = "MaLoaiXe";
            cboLoaiXe.DataSource = ds;
        }

        public void HienThiDanhSach(List<BangGiaDTO> ds) =>
            UiHelper.DoLuoi(dgvBangGia, ds, "TenLoaiXe|Loại xe", "MienPhiPhut|Miễn phí (phút)", "GiaKhoi|Giá mỗi khối|N0",
                            "SoGioKhoi|Số giờ/khối", "PhuThuQuaDem|Phụ thu qua đêm|N0", "GiaVeThang|Giá vé tháng|N0");

        public void HienThiChiTiet(BangGiaDTO g)
        {
            cboLoaiXe.SelectedValue = g.MaLoaiXe;
            numMienPhiPhut.Value = Math.Min(numMienPhiPhut.Maximum, g.MienPhiPhut);
            numGiaKhoi.Value = Math.Min(numGiaKhoi.Maximum, g.GiaKhoi);
            numSoGioKhoi.Value = Math.Min(numSoGioKhoi.Maximum, Math.Max(numSoGioKhoi.Minimum, g.SoGioKhoi));
            numPhuThuQuaDem.Value = Math.Min(numPhuThuQuaDem.Maximum, g.PhuThuQuaDem);
            numGiaVeThang.Value = Math.Min(numGiaVeThang.Maximum, g.GiaVeThang);
        }

        public void XoaNhap() { }
    }
}
