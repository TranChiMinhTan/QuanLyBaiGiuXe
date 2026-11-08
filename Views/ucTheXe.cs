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
    public partial class ucTheXe : UserControl, ucViewBase, ITheXeView
    {
        private TheXePresenter _p;

        public ucTheXe() { InitializeComponent(); }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (UiHelper.DangThietKe) return;
            UiHelper.CaiDatLuoi(dgvTheXe);
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.AddRange(new object[] { "Đang trống", "Đang dùng", "Đã mất" });
            cboTrangThai.SelectedIndex = 0;
            dtpNgayCap.MaxDate = DateTime.Today;

            _p = new TheXePresenter(this);
            btnThem.Click += (s, a) => _p.Them();
            btnSua.Click += (s, a) => _p.Sua();
            btnXoa.Click += (s, a) => _p.Xoa();
            btnLamMoi.Click += (s, a) => { XoaNhap(); txtTim.Clear(); _p.Tai(); };
            txtTim.TextChanged += (s, a) => _p.Tai();
            dgvTheXe.CellClick += (s, a) =>
            {
                var t = a.RowIndex >= 0 ? dgvTheXe.Rows[a.RowIndex].DataBoundItem as TheXeDTO : null;
                if (t != null) _p.Chon(t);
            };
            _p.KhoiDong();
        }

        public string MaThe => txtMaThe.Text.Trim();
        public int MaLoaiXe => cboLoaiThe.SelectedValue is int v ? v : 0;
        public string TrangThai => cboTrangThai.Text;
        public DateTime NgayCap => dtpNgayCap.Value.Date;
        public string TuKhoaTim => txtTim.Text.Trim();

        public void NapLoaiXe(List<LoaiXeDTO> ds)
        {
            cboLoaiThe.DisplayMember = "TenLoai";
            cboLoaiThe.ValueMember = "MaLoaiXe";
            cboLoaiThe.DataSource = ds;
        }

        public void HienThiDanhSach(List<TheXeDTO> ds) =>
            UiHelper.DoLuoi(dgvTheXe, ds, "MaThe|Mã thẻ", "TenLoaiXe|Loại thẻ", "TrangThai|Trạng thái",
                            "NgayCap|Ngày cấp|dd/MM/yyyy", "BienSoDangGui|Đang gắn với xe");

        public void HienThiChiTiet(TheXeDTO t)
        {
            txtMaThe.Text = t.MaThe;
            txtMaThe.ReadOnly = true;                 // mã thẻ là khóa chính, không đổi khi sửa
            cboLoaiThe.SelectedValue = t.MaLoaiXe;
            cboTrangThai.Text = t.TrangThai;
            dtpNgayCap.Value = t.NgayCap > dtpNgayCap.MaxDate ? dtpNgayCap.MaxDate : t.NgayCap;
        }

        public void XoaNhap()
        {
            txtMaThe.Clear();
            txtMaThe.ReadOnly = false;
            cboTrangThai.SelectedIndex = 0;
            dtpNgayCap.Value = DateTime.Today;
            txtMaThe.Focus();
        }
    }
}
