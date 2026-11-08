using System;
using System.Drawing;
using System.Windows.Forms;
using QuanLyBaiXe.BLL;
using QuanLyBaiXe.DTO;

namespace QuanLyBaiXe.GUI
{
    public class FrmDangNhap : Form
    {
        private readonly TextBox txtTen = new TextBox();
        private readonly TextBox txtMatKhau = new TextBox();
        private readonly Button btnDangNhap = new Button();
        private readonly Button btnThoat = new Button();
        private readonly ErrorProvider errorProvider = new ErrorProvider();
        private readonly TaiKhoanBLL bll = new TaiKhoanBLL();
        private int soLanSai = 0;

        public FrmDangNhap()
        {
            Text = "Đăng nhập - Quản lý bãi giữ xe";
            ClientSize = new Size(380, 250);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;

            Label tieuDe = new Label
            {
                Text = "QUẢN LÝ BÃI GIỮ XE",
                Font = new Font("Segoe UI", 15F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Left = 0, Top = 15, Width = 380, Height = 40
            };
            Label lblTen = new Label { Text = "Tên đăng nhập", Left = 30, Top = 75, Width = 100 };
            Label lblMk = new Label { Text = "Mật khẩu", Left = 30, Top = 115, Width = 100 };

            txtTen.SetBounds(135, 72, 200, 25);
            txtTen.MaxLength = 30;
            txtMatKhau.SetBounds(135, 112, 200, 25);
            txtMatKhau.UseSystemPasswordChar = true;
            txtMatKhau.MaxLength = 50;

            btnDangNhap.Text = "Đăng nhập";
            btnDangNhap.SetBounds(135, 155, 95, 32);
            btnDangNhap.Click += BtnDangNhap_Click;

            btnThoat.Text = "Thoát";
            btnThoat.SetBounds(240, 155, 95, 32);
            btnThoat.DialogResult = DialogResult.Cancel;

            Label goiY = new Label
            {
                Text = "Tài khoản mẫu: admin / 123456 (quản lý)\nnv01 / 123456 (nhân viên)",
                ForeColor = Color.Gray,
                Left = 30, Top = 200, Width = 320, Height = 36
            };

            Controls.AddRange(new Control[] { tieuDe, lblTen, txtTen, lblMk, txtMatKhau, btnDangNhap, btnThoat, goiY });
            AcceptButton = btnDangNhap;
            CancelButton = btnThoat;

            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        }

        private void BtnDangNhap_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();

            bool hopLe = true;
            if (txtTen.Text.Trim().Length == 0)
            {
                errorProvider.SetError(txtTen, "Vui lòng nhập tên đăng nhập.");
                hopLe = false;
            }
            if (txtMatKhau.Text.Length == 0)
            {
                errorProvider.SetError(txtMatKhau, "Vui lòng nhập mật khẩu.");
                hopLe = false;
            }
            if (!hopLe) return;

            TaiKhoanDTO taiKhoan;
            KetQua kq = bll.DangNhap(txtTen.Text, txtMatKhau.Text, out taiKhoan);
            if (kq.ThanhCong)
            {
                PhienDangNhap.NguoiDung = taiKhoan;
                DialogResult = DialogResult.OK;
                return;
            }

            soLanSai++;
            MessageBox.Show(kq.ThongBao, "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtMatKhau.Clear();
            txtMatKhau.Focus();

            if (soLanSai >= 5)
            {
                MessageBox.Show("Bạn đã nhập sai 5 lần. Chương trình sẽ đóng.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                DialogResult = DialogResult.Cancel;
            }
        }
    }
}
