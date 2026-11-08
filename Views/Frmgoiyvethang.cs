using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using QuanLyBaiGiuXe.Models;

namespace QuanLyBaiGiuXe.Views
{
    public class FrmGoiYVeThang : Form
    {
        public FrmGoiYVeThang(List<GoiYVeThangDTO> ds)
        {
            Text = "Gợi ý đăng ký vé tháng";
            Size = new Size(820, 460);
            StartPosition = FormStartPosition.CenterParent;

            var nhan = new Label
            {
                Dock = DockStyle.Top,
                Height = 62,
                Padding = new Padding(10, 10, 10, 0),
                Font = new Font("Segoe UI", 10),
                Text = "Các biển số CHƯA có vé tháng còn hạn nhưng 30 ngày qua đã gửi lẻ với tổng phí từ 80% giá vé tháng trở lên. " +
                       "Nhân viên có thể mời khách đăng ký vé tháng để khách tiết kiệm hơn."
            };
            var dgv = new DataGridView { Dock = DockStyle.Fill };
            UiHelper.CaiDatLuoi(dgv);
            UiHelper.DoLuoi(dgv, ds, "BienSo|Biển số", "TenLoaiXe|Loại xe", "SoLuot|Số lượt (30 ngày)",
                            "TongPhi|Tổng phí gửi lẻ (đ)|N0", "GiaVeThang|Giá vé tháng (đ)|N0", "ChenhLech|Chênh lệch (đ)|N0");

            Controls.Add(dgv);
            Controls.Add(nhan);
        }
    }
}