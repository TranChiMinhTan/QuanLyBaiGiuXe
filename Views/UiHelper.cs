using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace QuanLyBaiGiuXe.Views
{
    public static class UiHelper
    {
        public static bool DangThietKe => LicenseManager.UsageMode == LicenseUsageMode.Designtime;

        public static void ThongBao(string s) =>
            MessageBox.Show(s, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        public static void BaoLoi(string s) =>
            MessageBox.Show(s, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

        public static bool XacNhan(string s) =>
            MessageBox.Show(s, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

        public static void CaiDatLuoi(DataGridView g)
        {
            g.ReadOnly = true;
            g.AllowUserToAddRows = false;
            g.AllowUserToDeleteRows = false;
            g.MultiSelect = false;
            g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            g.RowHeadersVisible = false;
            g.BackgroundColor = System.Drawing.Color.White;
        }

        /// <summary>
        /// Đổ danh sách DTO vào lưới. Mỗi phần tử của cot có dạng "TenThuocTinh|Tiêu đề" hoặc "TenThuocTinh|Tiêu đề|Định dạng".
        /// Thuộc tính không liệt kê sẽ bị ẩn. DataBoundItem của mỗi dòng vẫn là DTO gốc.
        /// </summary>
        public static void DoLuoi(DataGridView g, object ds, params string[] cot)
        {
            g.AutoGenerateColumns = true;
            g.DataSource = ds;
            var hien = cot.Select(c => c.Split('|')).ToList();
            foreach (DataGridViewColumn c in g.Columns)
                c.Visible = hien.Any(h => h[0] == c.Name);
            int i = 0;
            foreach (var h in hien)
            {
                var c = g.Columns[h[0]];
                if (c == null) continue;
                c.HeaderText = h[1];
                c.DisplayIndex = i++;
                if (h.Length > 2) c.DefaultCellStyle.Format = h[2];
            }
            g.ClearSelection();
        }

        public static void BatDoubleBuffer(Control c)
        {
            typeof(Control).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)
                           .SetValue(c, true, null);
        }
    }
}
