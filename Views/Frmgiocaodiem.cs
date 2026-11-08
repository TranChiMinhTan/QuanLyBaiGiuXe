// [ ] [SÁNG TẠO #8] Thống kê giờ cao điểm: 24 cột, 3 giờ đông nhất tô màu cam kèm gợi ý bố trí nhân viên.
// Dựng bằng code, không cần Designer.
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QuanLyBaiGiuXe.Models;

namespace QuanLyBaiGiuXe.Views
{
    public class FrmGioCaoDiem : Form
    {
        public FrmGioCaoDiem(List<GioCaoDiemDTO> ds)
        {
            Text = "Thống kê giờ cao điểm";
            Size = new Size(820, 480);
            StartPosition = FormStartPosition.CenterParent;

            var top3 = ds.Where(x => x.SoLuot > 0).OrderByDescending(x => x.SoLuot).Take(3).ToList();
            string goiY = top3.Count == 0
                ? "Chưa có xe vào trong khoảng thời gian đã chọn."
                : "Đông nhất lúc " + top3[0].Gio + "h (" + top3[0].SoLuot + " lượt). Gợi ý: bố trí thêm nhân viên các khung giờ " +
                  string.Join(", ", top3.OrderBy(x => x.Gio).Select(x => x.Gio + "h")) + ".";

            var nhan = new Label
            {
                Text = goiY,
                Dock = DockStyle.Top,
                Height = 44,
                Padding = new Padding(10, 10, 10, 0),
                Font = new Font("Segoe UI", 10)
            };
            var bang = new Panel { Dock = DockStyle.Fill };
            UiHelper.BatDoubleBuffer(bang);

            var nhanTruc = ds.Select(x => x.Gio + "h").ToList();
            var gia = ds.Select(x => (decimal)x.SoLuot).ToList();
            var noiBat = new HashSet<int>(top3.Select(x => x.Gio));            // chỉ số cột = giờ vì luôn đủ 24 giờ
            bang.Paint += (s, e) => BieuDo.VeCot(e.Graphics, bang.ClientRectangle, nhanTruc, gia,
                                                 "Số lượt xe vào theo giờ (cam = 3 giờ cao điểm)", noiBat);
            bang.Resize += (s, e) => bang.Invalidate();

            Controls.Add(bang);        // control Fill thêm trước, control Top thêm sau
            Controls.Add(nhan);
        }
    }
}