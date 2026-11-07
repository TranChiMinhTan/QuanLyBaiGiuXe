using System;
using System.Drawing;
using System.Windows.Forms;
using QuanLyBaiXe.BLL;

namespace QuanLyBaiXe.GUI
{
    public class FrmDoiMatKhau : Form
    {
        private readonly TextBox txtCu = new TextBox();
        private readonly TextBox txtMoi = new TextBox();
        private readonly TextBox txtXacNhan = new TextBox();
        private readonly Button btnLuu = new Button();
        private readonly Button btnHuy = new Button();
        private readonly ErrorProvider errorProvider = new ErrorProvider();
        private readonly TaiKhoanBLL bll = new TaiKhoanBLL();

        public FrmDoiMatKhau()
        {
            Text = "Đổi mật khẩu";
            ClientSize = new Size(380, 230);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;

            ThemDong("Mật khẩu hiện tại", txtCu, 25);
            ThemDong("Mật khẩu mới", txtMoi, 65);
            ThemDong("Nhập lại mật khẩu mới", txtXacNhan, 105);

            btnLuu.Text = "Lưu";
            btnLuu.SetBounds(150, 160, 90, 32);
            btnLuu.Click += BtnLuu_Click;

            btnHuy.Text = "Hủy";
            btnHuy.SetBounds(250, 160, 90, 32);
            btnHuy.DialogResult = DialogResult.Cancel;

            Controls.Add(btnLuu);
            Controls.Add(btnHuy);
            AcceptButton = btnLuu;
            CancelButton = btnHuy;

            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        }

        private void ThemDong(string nhan, TextBox o, int top)
        {
            Controls.Add(new Label { Text = nhan, Left = 20, Top = top + 3, Width = 130 });
            o.SetBounds(155, top, 190, 25);
            o.UseSystemPasswordChar = true;
            o.MaxLength = 50;
            Controls.Add(o);
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();

            if (txtCu.Text.Length == 0) { errorProvider.SetError(txtCu, "Nhập mật khẩu hiện tại."); return; }
            if (txtMoi.Text.Length < 6) { errorProvider.SetError(txtMoi, "Mật khẩu mới tối thiểu 6 ký tự."); return; }
            if (txtMoi.Text != txtXacNhan.Text) { errorProvider.SetError(txtXacNhan, "Xác nhận không khớp."); return; }

            KetQua kq = bll.DoiMatKhau(PhienDangNhap.TenDangNhap, txtCu.Text, txtMoi.Text, txtXacNhan.Text);
            if (kq.ThanhCong)
            {
                MessageBox.Show(kq.ThongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show(kq.ThongBao, "Không thể đổi mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
