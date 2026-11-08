using System;
using System.Drawing;
using System.Windows.Forms;
using QuanLyBaiGiuXe.Presenters;

namespace QuanLyBaiGiuXe.Views
{
    public class FrmDoiMatKhau : Form, IDoiMatKhauView
    {
        private readonly TextBox _cu = new TextBox { UseSystemPasswordChar = true, Width = 200 };
        private readonly TextBox _moi = new TextBox { UseSystemPasswordChar = true, Width = 200 };
        private readonly TextBox _nhapLai = new TextBox { UseSystemPasswordChar = true, Width = 200 };
        private readonly Button _luu = new Button { Text = "Lưu", Width = 90 };
        private readonly Button _huy = new Button { Text = "Hủy", Width = 90, DialogResult = DialogResult.Cancel };
        private readonly DoiMatKhauPresenter _p;

        public FrmDoiMatKhau()
        {
            Text = "Đổi mật khẩu";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false; MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new Size(360, 190);

            ThemDong("Mật khẩu hiện tại", _cu, 18);
            ThemDong("Mật khẩu mới", _moi, 58);
            ThemDong("Nhập lại mật khẩu mới", _nhapLai, 98);
            _luu.Location = new Point(150, 145);
            _huy.Location = new Point(250, 145);
            Controls.Add(_luu); Controls.Add(_huy);
            AcceptButton = _luu; CancelButton = _huy;

            _p = new DoiMatKhauPresenter(this);
            _luu.Click += (s, e) => _p.DoiMatKhau();
        }

        private void ThemDong(string nhan, TextBox o, int y)
        {
            Controls.Add(new Label { Text = nhan, Location = new Point(14, y + 4), AutoSize = true });
            o.Location = new Point(150, y);
            Controls.Add(o);
        }

        public string MatKhauCu => _cu.Text;
        public string MatKhauMoi => _moi.Text;
        public string NhapLaiMatKhauMoi => _nhapLai.Text;
        public void DongForm() { DialogResult = DialogResult.OK; }

        public void ThongBao(string noiDung) => UiHelper.ThongBao(noiDung);
        public void BaoLoi(string noiDung) => UiHelper.BaoLoi(noiDung);
        public bool XacNhan(string noiDung) => UiHelper.XacNhan(noiDung);
    }
}