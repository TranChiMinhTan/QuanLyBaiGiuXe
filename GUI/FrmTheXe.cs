using System.Windows.Forms;
using QuanLyBaiXe.BLL;
using QuanLyBaiXe.DTO;

namespace QuanLyBaiXe.GUI
{
    public class FrmTheXe : FrmDanhMucBase
    {
        private readonly TheXeBLL bll = new TheXeBLL();
        private readonly LoaiXeBLL loaiXeBll = new LoaiXeBLL();

        private readonly TextBox txtMaThe = new TextBox { MaxLength = 20, CharacterCasing = CharacterCasing.Upper };
        private readonly ComboBox cboLoaiXe = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
        private readonly ComboBox cboTrangThai = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };

        public FrmTheXe() : base("Danh mục thẻ xe", 110)
        {
            cboTrangThai.Items.AddRange(new object[] { TrangThaiThe.SanSang, TrangThaiThe.DangDung, TrangThaiThe.Khoa });

            ThemO("Mã thẻ", txtMaThe, 20, 15, 200);
            ThemO("Loại xe", cboLoaiXe, 20, 50, 200);
            ThemO("Trạng thái", cboTrangThai, 440, 15, 200);
        }

        protected override void TaiDuLieu()
        {
            // nạp lại loại xe mỗi lần để thấy loại xe mới thêm
            cboLoaiXe.DataSource = null;
            cboLoaiXe.DisplayMember = "TenLoaiXe";
            cboLoaiXe.ValueMember = "MaLoaiXe";
            cboLoaiXe.DataSource = loaiXeBll.LayTatCa();

            NapLuoi(bll.LayTatCa());
        }

        protected override void DinhDangCot()
        {
            dgv.Columns["MaThe"].HeaderText = "Mã thẻ";
            dgv.Columns["MaLoaiXe"].Visible = false;
            dgv.Columns["TenLoaiXe"].HeaderText = "Loại xe";
            dgv.Columns["TrangThai"].HeaderText = "Trạng thái";
        }

        protected override void XoaTrang()
        {
            txtMaThe.Clear();
            if (cboLoaiXe.Items.Count > 0) cboLoaiXe.SelectedIndex = 0;
            cboTrangThai.SelectedItem = TrangThaiThe.SanSang;
        }

        protected override void HienThiDoiTuong(object doiTuong)
        {
            TheXeDTO t = doiTuong as TheXeDTO;
            if (t == null) { XoaTrang(); return; }

            txtMaThe.Text = t.MaThe;
            cboLoaiXe.SelectedValue = t.MaLoaiXe;
            cboTrangThai.SelectedItem = t.TrangThai;
        }

        protected override void BatNhapLieu(bool bat, bool laThem)
        {
            txtMaThe.ReadOnly = !(bat && laThem);   // chỉ nhập mã thẻ khi thêm mới, không sửa khóa chính
            cboLoaiXe.Enabled = bat;
            cboTrangThai.Enabled = bat;
            if (bat && laThem) txtMaThe.Focus();
        }

        protected override bool KiemTraDauVao()
        {
            bool hopLe = true;
            if (txtMaThe.Text.Trim().Length == 0)
            {
                errorProvider.SetError(txtMaThe, "Mã thẻ không được để trống.");
                hopLe = false;
            }
            if (cboLoaiXe.SelectedValue == null)
            {
                errorProvider.SetError(cboLoaiXe, "Vui lòng chọn loại xe.");
                hopLe = false;
            }
            if (cboTrangThai.SelectedItem == null)
            {
                errorProvider.SetError(cboTrangThai, "Vui lòng chọn trạng thái.");
                hopLe = false;
            }
            return hopLe;
        }

        protected override KetQua Luu(bool laThem)
        {
            TheXeDTO t = new TheXeDTO
            {
                MaThe = txtMaThe.Text,
                MaLoaiXe = (int)cboLoaiXe.SelectedValue,
                TrangThai = (string)cboTrangThai.SelectedItem
            };
            return laThem ? bll.Them(t) : bll.Sua(t);
        }

        protected override KetQua Xoa()
        {
            TheXeDTO t = DoiTuongDangChon as TheXeDTO;
            return bll.Xoa(t.MaThe);
        }
    }
}
