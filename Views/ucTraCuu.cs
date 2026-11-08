// [Người 4] Màn hình tra cứu lịch sử lượt gửi. Chỉ làm việc với control; mọi xử lý do TraCuuPresenter.
// Namespace phải trùng với ucTraCuu.Designer.cs (QuanLyBaiGiuXe.Views).
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using QuanLyBaiXe.Models;
using QuanLyBaiXe.Presenters;
using QuanLyBaiXe.Views;

namespace QuanLyBaiGiuXe.Views
{
    public partial class ucTraCuu : UserControl, ITraCuuView
    {
        private static readonly CultureInfo VN = new CultureInfo("vi-VN");
        private readonly TraCuuPresenter _presenter;

        public ucTraCuu()
        {
            InitializeComponent();
            _presenter = new TraCuuPresenter(this);

            KhoiTaoLuoi();
            dtpTuNgay.Value = DateTime.Today.AddDays(-6);
            dtpDenNgay.Value = DateTime.Today;

            btnTimKiem.Click += (s, e) => _presenter.TimKiem();
            btnInBienNhan.Click += (s, e) => _presenter.InBienNhan(LuotDangChon());
            dgvKetQua.CellDoubleClick += dgvKetQua_CellDoubleClick;
            txtBienSo.KeyDown += NhanEnterDeTimKiem;
            txtMaThe.KeyDown += NhanEnterDeTimKiem;

            Load += (s, e) => { if (!DesignMode) _presenter.KhoiDong(); };
        }

        // ------------------------------------------------------------------
        //  Bảng kết quả
        // ------------------------------------------------------------------
        private void KhoiTaoLuoi()
        {
            dgvKetQua.AutoGenerateColumns = false;
            dgvKetQua.ReadOnly = true;
            dgvKetQua.AllowUserToAddRows = false;
            dgvKetQua.AllowUserToDeleteRows = false;
            dgvKetQua.MultiSelect = false;
            dgvKetQua.RowHeadersVisible = false;
            dgvKetQua.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKetQua.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvKetQua.Columns.Add("colMaLuot", "Mã lượt");
            dgvKetQua.Columns.Add("colMaThe", "Mã thẻ");
            dgvKetQua.Columns.Add("colBienSo", "Biển số");
            dgvKetQua.Columns.Add("colLoaiXe", "Loại xe");
            dgvKetQua.Columns.Add("colGioVao", "Giờ vào");
            dgvKetQua.Columns.Add("colGioRa", "Giờ ra");
            dgvKetQua.Columns.Add("colThoiGian", "Thời gian gửi");
            dgvKetQua.Columns.Add("colPhi", "Phí (đ)");
            dgvKetQua.Columns.Add("colTrangThai", "Trạng thái");

            dgvKetQua.Columns["colMaLuot"].FillWeight = 50;
            dgvKetQua.Columns["colPhi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            foreach (DataGridViewColumn c in dgvKetQua.Columns)
                c.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private LuotGuiDTO LuotDangChon()
        {
            DataGridViewRow dong = dgvKetQua.CurrentRow;
            return dong == null ? null : dong.Tag as LuotGuiDTO;
        }

        private void NhanEnterDeTimKiem(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            e.SuppressKeyPress = true;
            _presenter.TimKiem();
        }

        // Nhấp đúp một dòng để xem ảnh biển số (ảnh do Người 2 lưu lúc xe vào, đường dẫn tương đối so với thư mục .exe).
        private void dgvKetQua_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            LuotGuiDTO l = dgvKetQua.Rows[e.RowIndex].Tag as LuotGuiDTO;
            if (l != null) XemAnhBienSo(l);
        }

        private void XemAnhBienSo(LuotGuiDTO l)
        {
            if (string.IsNullOrEmpty(l.DuongDanAnh))
            {
                ThongBao("Lượt gửi này không có ảnh biển số.");
                return;
            }

            string day = Path.IsPathRooted(l.DuongDanAnh)
                ? l.DuongDanAnh
                : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, l.DuongDanAnh);
            if (!File.Exists(day))
            {
                BaoLoi("Không tìm thấy file ảnh: " + l.DuongDanAnh);
                return;
            }

            Image anh;
            try
            {
                // Đọc rồi sao chép ra Bitmap để không khóa file ảnh.
                using (var fs = new FileStream(day, FileMode.Open, FileAccess.Read, FileShare.Read))
                using (var goc = Image.FromStream(fs))
                    anh = new Bitmap(goc);
            }
            catch (Exception ex)
            {
                BaoLoi("Không mở được ảnh: " + ex.Message);
                return;
            }

            using (var frm = new Form
            {
                Text = "Ảnh biển số - " + l.BienSo,
                StartPosition = FormStartPosition.CenterParent,
                Size = new Size(640, 480)
            })
            {
                frm.Controls.Add(new PictureBox { Dock = DockStyle.Fill, SizeMode = PictureBoxSizeMode.Zoom, Image = anh });
                frm.ShowDialog(FindForm());
            }
            anh.Dispose();
        }

        // ------------------------------------------------------------------
        //  ITraCuuView
        // ------------------------------------------------------------------
        public string BienSo { get { return txtBienSo.Text.Trim(); } }
        public string MaThe { get { return txtMaThe.Text.Trim(); } }
        public DateTime TuNgay { get { return dtpTuNgay.Value.Date; } }
        public DateTime DenNgay { get { return dtpDenNgay.Value.Date; } }

        public int? MaLoaiXe
        {
            get
            {
                LoaiXeDTO lx = cboLoaiXe.SelectedItem as LoaiXeDTO;
                return (lx == null || lx.MaLoaiXe == 0) ? (int?)null : lx.MaLoaiXe;   // mục "Tất cả" có mã 0
            }
        }

        public void NapLoaiXe(List<LoaiXeDTO> ds)
        {
            var hienThi = new List<LoaiXeDTO> { new LoaiXeDTO { MaLoaiXe = 0, TenLoai = "-- Tất cả --" } };
            hienThi.AddRange(ds);

            cboLoaiXe.DisplayMember = "TenLoai";
            cboLoaiXe.ValueMember = "MaLoaiXe";
            cboLoaiXe.DataSource = hienThi;
            cboLoaiXe.SelectedIndex = 0;
        }

        public void HienThiKetQua(List<LuotGuiDTO> ds)
        {
            dgvKetQua.SuspendLayout();
            dgvKetQua.Rows.Clear();
            foreach (LuotGuiDTO l in ds)
            {
                int i = dgvKetQua.Rows.Add(
                    l.MaLuot,
                    l.MaThe,
                    l.BienSo,
                    l.TenLoaiXe,
                    l.GioVao.ToString("dd/MM/yyyy HH:mm"),
                    l.GioRa.HasValue ? l.GioRa.Value.ToString("dd/MM/yyyy HH:mm") : "",
                    DinhDangThoiGian(l.ThoiGianGui),
                    l.DangGui ? "" : l.Phi.ToString("N0", VN),
                    l.DangGui ? "Đang gửi" : "Đã ra");

                dgvKetQua.Rows[i].Tag = l;
                if (l.DangGui) dgvKetQua.Rows[i].DefaultCellStyle.ForeColor = Color.DarkGreen;
            }
            dgvKetQua.ResumeLayout();
        }

        public void HienThiTong(int soLuot, decimal tongPhi)
        {
            lblTong.Text = string.Format("Tìm thấy {0} lượt · Tổng phí: {1}", soLuot, InPhieu.Tien(tongPhi));
        }

        public void InBienNhan(BienNhanDTO bienNhan)
        {
            InPhieu.XemTruoc(FindForm(), bienNhan);
        }

        private static string DinhDangThoiGian(TimeSpan ts)
        {
            if (ts < TimeSpan.Zero) ts = TimeSpan.Zero;
            return (int)ts.TotalHours + " giờ " + ts.Minutes + " phút";
        }

        // IViewCoBan
        public void ThongBao(string noiDung)
        {
            MessageBox.Show(noiDung, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void BaoLoi(string noiDung)
        {
            MessageBox.Show(noiDung, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public bool XacNhan(string noiDung)
        {
            return MessageBox.Show(noiDung, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }
    }
}