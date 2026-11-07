using System;
using System.Windows.Forms;
using QuanLyBaiXe.BLL;
using QuanLyBaiXe.DTO;

namespace QuanLyBaiXe.GUI
{
    public class FrmBangGia : FrmDanhMucBase
    {
        private readonly BangGiaBLL bll = new BangGiaBLL();
        private readonly LoaiXeBLL loaiXeBll = new LoaiXeBLL();

        private int maBangGia = 0;   // 0 khi đang thêm mới

        private readonly ComboBox cboLoaiXe = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
        private readonly NumericUpDown nudGioDau = TaoNudTien();
        private readonly NumericUpDown nudTiepTheo = TaoNudTien();
        private readonly NumericUpDown nudToiDa = TaoNudTien();
        private readonly NumericUpDown nudVeThang = TaoNudTien();
        private readonly DateTimePicker dtpNgay = new DateTimePicker { Format = DateTimePickerFormat.Short };
        private readonly CheckBox chkHieuLuc = new CheckBox { Text = "Còn hiệu lực", Checked = true };

        private static NumericUpDown TaoNudTien()
        {
            return new NumericUpDown
            {
                Minimum = 0,
                Maximum = 100000000,
                Increment = 500,
                DecimalPlaces = 0,
                ThousandsSeparator = true
            };
        }

        public FrmBangGia() : base("Danh mục bảng giá", 150)
        {
            ThemO("Loại xe", cboLoaiXe, 20, 15, 200);
            ThemO("Giá giờ đầu (đ)", nudGioDau, 20, 50, 200);
            ThemO("Giá giờ tiếp theo", nudTiepTheo, 20, 85, 200);
            ThemO("Giá tối đa/ngày", nudToiDa, 440, 15, 200);
            ThemO("Giá vé tháng", nudVeThang, 440, 50, 200);
            ThemO("Ngày áp dụng", dtpNgay, 440, 85, 200);
            chkHieuLuc.SetBounds(545, 118, 200, 24);
            pnlNhap.Controls.Add(chkHieuLuc);
        }

        protected override void TaiDuLieu()
        {
            cboLoaiXe.DataSource = null;
            cboLoaiXe.DisplayMember = "TenLoaiXe";
            cboLoaiXe.ValueMember = "MaLoaiXe";
            cboLoaiXe.DataSource = loaiXeBll.LayTatCa();

            NapLuoi(bll.LayTatCa());
        }

        protected override void DinhDangCot()
        {
            dgv.Columns["MaBangGia"].HeaderText = "Mã";
            dgv.Columns["MaBangGia"].FillWeight = 25;
            dgv.Columns["MaLoaiXe"].Visible = false;
            dgv.Columns["TenLoaiXe"].HeaderText = "Loại xe";
            dgv.Columns["GiaGioDau"].HeaderText = "Giá giờ đầu";
            dgv.Columns["GiaGioTiepTheo"].HeaderText = "Giá giờ tiếp theo";
            dgv.Columns["GiaToiDaNgay"].HeaderText = "Tối đa/ngày";
            dgv.Columns["GiaVeThang"].HeaderText = "Vé tháng";
            dgv.Columns["NgayApDung"].HeaderText = "Ngày áp dụng";
            dgv.Columns["ConHieuLuc"].HeaderText = "Hiệu lực";
            dgv.Columns["ConHieuLuc"].FillWeight = 40;

            foreach (string cot in new[] { "GiaGioDau", "GiaGioTiepTheo", "GiaToiDaNgay", "GiaVeThang" })
            {
                dgv.Columns[cot].DefaultCellStyle.Format = "N0";
                dgv.Columns[cot].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            dgv.Columns["NgayApDung"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        protected override void XoaTrang()
        {
            maBangGia = 0;
            if (cboLoaiXe.Items.Count > 0) cboLoaiXe.SelectedIndex = 0;
            nudGioDau.Value = 0;
            nudTiepTheo.Value = 0;
            nudToiDa.Value = 0;
            nudVeThang.Value = 0;
            dtpNgay.Value = DateTime.Today;
            chkHieuLuc.Checked = true;
        }

        protected override void HienThiDoiTuong(object doiTuong)
        {
            BangGiaDTO g = doiTuong as BangGiaDTO;
            if (g == null) { XoaTrang(); return; }

            maBangGia = g.MaBangGia;
            cboLoaiXe.SelectedValue = g.MaLoaiXe;
            nudGioDau.Value = g.GiaGioDau;
            nudTiepTheo.Value = g.GiaGioTiepTheo;
            nudToiDa.Value = g.GiaToiDaNgay;
            nudVeThang.Value = g.GiaVeThang;
            dtpNgay.Value = g.NgayApDung;
            chkHieuLuc.Checked = g.ConHieuLuc;
        }

        protected override void BatNhapLieu(bool bat, bool laThem)
        {
            cboLoaiXe.Enabled = bat;
            nudGioDau.Enabled = bat;
            nudTiepTheo.Enabled = bat;
            nudToiDa.Enabled = bat;
            nudVeThang.Enabled = bat;
            dtpNgay.Enabled = bat;
            chkHieuLuc.Enabled = bat;
        }

        protected override bool KiemTraDauVao()
        {
            bool hopLe = true;
            if (cboLoaiXe.SelectedValue == null)
            {
                errorProvider.SetError(cboLoaiXe, "Vui lòng chọn loại xe.");
                hopLe = false;
            }
            if (nudGioDau.Value <= 0)
            {
                errorProvider.SetError(nudGioDau, "Giá giờ đầu phải lớn hơn 0.");
                hopLe = false;
            }
            if (nudToiDa.Value < nudGioDau.Value)
            {
                errorProvider.SetError(nudToiDa, "Giá tối đa/ngày không được nhỏ hơn giá giờ đầu.");
                hopLe = false;
            }
            if (nudVeThang.Value <= 0)
            {
                errorProvider.SetError(nudVeThang, "Giá vé tháng phải lớn hơn 0.");
                hopLe = false;
            }
            return hopLe;
        }

        protected override KetQua Luu(bool laThem)
        {
            BangGiaDTO g = new BangGiaDTO
            {
                MaBangGia = laThem ? 0 : maBangGia,
                MaLoaiXe = (int)cboLoaiXe.SelectedValue,
                GiaGioDau = nudGioDau.Value,
                GiaGioTiepTheo = nudTiepTheo.Value,
                GiaToiDaNgay = nudToiDa.Value,
                GiaVeThang = nudVeThang.Value,
                NgayApDung = dtpNgay.Value.Date,
                ConHieuLuc = chkHieuLuc.Checked
            };
            return laThem ? bll.Them(g) : bll.Sua(g);
        }

        protected override KetQua Xoa()
        {
            BangGiaDTO g = DoiTuongDangChon as BangGiaDTO;
            return bll.Xoa(g.MaBangGia);
        }
    }
}
