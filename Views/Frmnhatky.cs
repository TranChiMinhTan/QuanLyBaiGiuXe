// [Người 1] [SÁNG TẠO #6] Màn hình xem nhật ký thao tác (chỉ Quản lý). Dựng bằng code, không cần Designer.
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using QuanLyBaiGiuXe.Models;
using QuanLyBaiGiuXe.Presenters;

namespace QuanLyBaiGiuXe.Views
{
    public class FrmNhatKy : Form, INhatKyView
    {
        private readonly TextBox _tim = new TextBox { Width = 260 };
        private readonly Button _lamMoi = new Button { Text = "Làm mới", AutoSize = true };
        private readonly DataGridView _dgv = new DataGridView { Dock = DockStyle.Fill };
        private readonly NhatKyPresenter _p;

        public FrmNhatKy()
        {
            Text = "Nhật ký thao tác (500 dòng gần nhất)";
            Size = new Size(940, 560);
            StartPosition = FormStartPosition.CenterParent;

            var top = new FlowLayoutPanel { Dock = DockStyle.Top, Height = 42, Padding = new Padding(8, 8, 8, 0) };
            top.Controls.Add(new Label { Text = "Tìm (người dùng, hành động, chi tiết):", AutoSize = true, Margin = new Padding(0, 6, 6, 0) });
            top.Controls.Add(_tim);
            top.Controls.Add(_lamMoi);
            Controls.Add(_dgv);        // thêm control Fill trước, control Top sau
            Controls.Add(top);
            UiHelper.CaiDatLuoi(_dgv);

            _p = new NhatKyPresenter(this);
            _lamMoi.Click += (s, e) => _p.Tai();
            _tim.TextChanged += (s, e) => _p.Tai();
            Load += (s, e) => _p.Tai();
        }

        public string TuKhoaTim => _tim.Text.Trim();

        public void HienThiDanhSach(List<NhatKyDTO> ds) =>
            UiHelper.DoLuoi(_dgv, ds, "ThoiDiem|Thời điểm|dd/MM/yyyy HH:mm:ss", "TenDangNhap|Người dùng",
                            "HanhDong|Hành động", "ChiTiet|Chi tiết");

        public void ThongBao(string noiDung) => UiHelper.ThongBao(noiDung);
        public void BaoLoi(string noiDung) => UiHelper.BaoLoi(noiDung);
        public bool XacNhan(string noiDung) => UiHelper.XacNhan(noiDung);
    }
}
