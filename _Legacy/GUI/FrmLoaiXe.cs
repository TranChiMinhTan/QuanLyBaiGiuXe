using System;
using System.Windows.Forms;
using QuanLyBaiXe.BLL;
using QuanLyBaiXe.DTO;

namespace QuanLyBaiXe.GUI
{
    /// <summary>Form danh mục mẫu: CRUD Loại xe. Các form danh mục khác bắt chước cấu trúc này.</summary>
    public class FrmLoaiXe : FrmDanhMucBase
    {
        private readonly LoaiXeBLL bll = new LoaiXeBLL();

        private readonly TextBox txtMa = new TextBox { ReadOnly = true };
        private readonly TextBox txtTen = new TextBox { MaxLength = 50 };
        private readonly TextBox txtMoTa = new TextBox { MaxLength = 200 };
        private readonly NumericUpDown nudSucChua = new NumericUpDown { Minimum = 0, Maximum = 10000 };

        public FrmLoaiXe() : base("Danh mục loại xe", 110)
        {
            ThemO("Mã loại xe", txtMa, 20, 15, 120);
            ThemO("Tên loại xe", txtTen, 20, 50, 250);
            ThemO("Sức chứa (chỗ)", nudSucChua, 440, 15, 120);
            ThemO("Mô tả", txtMoTa, 440, 50, 300);
        }

        protected override void TaiDuLieu()
        {
            NapLuoi(bll.LayTatCa());
        }

        protected override void DinhDangCot()
        {
            dgv.Columns["MaLoaiXe"].HeaderText = "Mã";
            dgv.Columns["TenLoaiXe"].HeaderText = "Tên loại xe";
            dgv.Columns["MoTa"].HeaderText = "Mô tả";
            dgv.Columns["SucChua"].HeaderText = "Sức chứa";
            dgv.Columns["MaLoaiXe"].FillWeight = 20;
            dgv.Columns["SucChua"].FillWeight = 30;
        }

        protected override void XoaTrang()
        {
            txtMa.Text = "(tự động)";
            txtTen.Clear();
            txtMoTa.Clear();
            nudSucChua.Value = 0;
        }

        protected override void HienThiDoiTuong(object doiTuong)
        {
            LoaiXeDTO x = doiTuong as LoaiXeDTO;
            if (x == null) { XoaTrang(); txtMa.Clear(); return; }

            txtMa.Text = x.MaLoaiXe.ToString();
            txtTen.Text = x.TenLoaiXe;
            txtMoTa.Text = x.MoTa;
            nudSucChua.Value = Math.Min(x.SucChua, (int)nudSucChua.Maximum);
        }

        protected override void BatNhapLieu(bool bat, bool laThem)
        {
            txtTen.ReadOnly = !bat;
            txtMoTa.ReadOnly = !bat;
            nudSucChua.Enabled = bat;
            if (bat) txtTen.Focus();
        }

        protected override bool KiemTraDauVao()
        {
            if (txtTen.Text.Trim().Length == 0)
            {
                errorProvider.SetError(txtTen, "Tên loại xe không được để trống.");
                txtTen.Focus();
                return false;
            }
            return true;
        }

        private LoaiXeDTO DocTuForm()
        {
            int ma;
            int.TryParse(txtMa.Text, out ma);   // khi thêm mới, txtMa là "(tự động)" nên ma = 0
            return new LoaiXeDTO
            {
                MaLoaiXe = ma,
                TenLoaiXe = txtTen.Text,
                MoTa = txtMoTa.Text,
                SucChua = (int)nudSucChua.Value
            };
        }

        protected override KetQua Luu(bool laThem)
        {
            LoaiXeDTO x = DocTuForm();
            return laThem ? bll.Them(x) : bll.Sua(x);
        }

        protected override KetQua Xoa()
        {
            LoaiXeDTO x = DoiTuongDangChon as LoaiXeDTO;
            return bll.Xoa(x.MaLoaiXe);
        }
    }
}
