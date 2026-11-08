using System;
using System.Drawing;
using System.Windows.Forms;
using QuanLyBaiXe.BLL;

namespace QuanLyBaiXe.GUI
{
    /// <summary>
    /// MẪU FORM DANH MỤC dùng chung cho cả nhóm.
    /// Bố cục: [vùng nhập liệu] / [Thêm Sửa Xóa Lưu Hủy Làm mới] / [DataGridView] + ErrorProvider.
    /// Người 3 (Khách hàng) và các form danh mục khác chỉ cần kế thừa lớp này và cài đặt các hàm abstract.
    /// Xem FrmLoaiXe.cs làm ví dụ mẫu.
    /// </summary>
    public abstract class FrmDanhMucBase : Form
    {
        protected enum CheDo { Xem, Them, Sua }

        protected readonly Panel pnlNhap = new Panel();
        protected readonly DataGridView dgv = new DataGridView();
        protected readonly ErrorProvider errorProvider = new ErrorProvider();
        protected CheDo cheDo = CheDo.Xem;

        private readonly Button btnThem = TaoNut("Thêm");
        private readonly Button btnSua = TaoNut("Sửa");
        private readonly Button btnXoa = TaoNut("Xóa");
        private readonly Button btnLuu = TaoNut("Lưu");
        private readonly Button btnHuy = TaoNut("Hủy");
        private readonly Button btnLamMoi = TaoNut("Làm mới");

        private static Button TaoNut(string chu)
        {
            return new Button { Text = chu, Width = 90, Height = 32, Margin = new Padding(6, 6, 0, 6) };
        }

        protected FrmDanhMucBase(string tieuDe, int chieuCaoNhap)
        {
            Text = tieuDe;
            ClientSize = new Size(900, 560);
            StartPosition = FormStartPosition.CenterParent;

            TableLayoutPanel bo = new TableLayoutPanel();
            bo.Dock = DockStyle.Fill;
            bo.ColumnCount = 1;
            bo.RowCount = 3;
            bo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            bo.RowStyles.Add(new RowStyle(SizeType.Absolute, chieuCaoNhap));
            bo.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
            bo.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            pnlNhap.Dock = DockStyle.Fill;

            FlowLayoutPanel pnlNut = new FlowLayoutPanel();
            pnlNut.Dock = DockStyle.Fill;
            pnlNut.FlowDirection = FlowDirection.LeftToRight;
            pnlNut.Controls.AddRange(new Control[] { btnThem, btnSua, btnXoa, btnLuu, btnHuy, btnLamMoi });

            dgv.Dock = DockStyle.Fill;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.MultiSelect = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowHeadersVisible = false;
            dgv.BackgroundColor = SystemColors.Window;

            bo.Controls.Add(pnlNhap, 0, 0);
            bo.Controls.Add(pnlNut, 0, 1);
            bo.Controls.Add(dgv, 0, 2);
            Controls.Add(bo);

            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            btnLuu.Click += BtnLuu_Click;
            btnHuy.Click += BtnHuy_Click;
            btnLamMoi.Click += delegate { TaiLai(); };
            dgv.SelectionChanged += Dgv_SelectionChanged;
        }

        // ---------- Các hàm lớp con phải cài đặt ----------
        /// <summary>Lấy dữ liệu từ BLL rồi gọi NapLuoi(danhSach).</summary>
        protected abstract void TaiDuLieu();
        /// <summary>Xóa trắng các ô nhập.</summary>
        protected abstract void XoaTrang();
        /// <summary>Hiện đối tượng (DTO) của dòng đang chọn lên các ô nhập. doiTuong có thể null.</summary>
        protected abstract void HienThiDoiTuong(object doiTuong);
        /// <summary>Bật/tắt các ô nhập. laThem=true khi thêm mới (khóa chính được phép nhập).</summary>
        protected abstract void BatNhapLieu(bool bat, bool laThem);
        /// <summary>Kiểm tra nhanh trên giao diện bằng errorProvider.SetError; trả về false nếu có lỗi.</summary>
        protected abstract bool KiemTraDauVao();
        /// <summary>Gọi BLL thêm/sửa theo giá trị trong các ô nhập.</summary>
        protected abstract KetQua Luu(bool laThem);
        /// <summary>Gọi BLL xóa dòng đang chọn.</summary>
        protected abstract KetQua Xoa();
        /// <summary>Đặt tiêu đề, định dạng cột sau khi nạp lưới (không bắt buộc).</summary>
        protected virtual void DinhDangCot() { }

        // ---------- Tiện ích cho lớp con ----------
        protected void NapLuoi(object nguon)
        {
            dgv.DataSource = nguon;
            DinhDangCot();
        }

        protected void ThemO(string nhan, Control o, int x, int y, int rong)
        {
            pnlNhap.Controls.Add(new Label { Text = nhan, Left = x, Top = y + 4, Width = 100, AutoSize = false });
            o.Left = x + 105;
            o.Top = y;
            o.Width = rong;
            pnlNhap.Controls.Add(o);
        }

        protected object DoiTuongDangChon
        {
            get { return dgv.CurrentRow == null ? null : dgv.CurrentRow.DataBoundItem; }
        }

        // ---------- Xử lý chung ----------
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            TaiLai();
        }

        private void TaiLai()
        {
            errorProvider.Clear();
            try
            {
                TaiDuLieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            DatCheDo(CheDo.Xem);
            HienThiDoiTuong(DoiTuongDangChon);
        }

        private void DatCheDo(CheDo moi)
        {
            cheDo = moi;
            bool xem = (moi == CheDo.Xem);
            btnThem.Enabled = xem;
            btnSua.Enabled = xem;
            btnXoa.Enabled = xem;
            btnLamMoi.Enabled = xem;
            btnLuu.Enabled = !xem;
            btnHuy.Enabled = !xem;
            dgv.Enabled = xem;
            BatNhapLieu(!xem, moi == CheDo.Them);
        }

        private void Dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (cheDo == CheDo.Xem) HienThiDoiTuong(DoiTuongDangChon);
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            XoaTrang();
            DatCheDo(CheDo.Them);
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (DoiTuongDangChon == null)
            {
                MessageBox.Show("Vui lòng chọn một dòng cần sửa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            errorProvider.Clear();
            DatCheDo(CheDo.Sua);
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (DoiTuongDangChon == null)
            {
                MessageBox.Show("Vui lòng chọn một dòng cần xóa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có chắc muốn xóa dòng đang chọn?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            KetQua kq = Xoa();
            if (kq.ThanhCong)
            {
                MessageBox.Show(kq.ThongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TaiLai();
            }
            else
            {
                MessageBox.Show(kq.ThongBao, "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            if (!KiemTraDauVao()) return;

            KetQua kq = Luu(cheDo == CheDo.Them);
            if (!kq.ThanhCong)
            {
                MessageBox.Show(kq.ThongBao, "Không thể lưu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show(kq.ThongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TaiLai();
        }

        private void BtnHuy_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            DatCheDo(CheDo.Xem);
            HienThiDoiTuong(DoiTuongDangChon);
        }
    }
}
