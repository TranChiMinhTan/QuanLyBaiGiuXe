//Nghiệp vụ báo cáo doanh thu (theo ngày hoặc theo tháng) và xuất CSV.
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using QuanLyBaiXe.DAL;
using QuanLyBaiXe.Models;

namespace QuanLyBaiXe.BLL
{
    public class BaoCaoBLL
    {
        private readonly BaoCaoDAL _dal = new BaoCaoDAL();
        private static readonly CultureInfo Inv = CultureInfo.InvariantCulture;

        public BaoCaoDoanhThuDTO LayBaoCao(DateTime tuNgay, DateTime denNgay, bool theoThang)
        {
            tuNgay = tuNgay.Date;
            denNgay = denNgay.Date;
            if (tuNgay > denNgay)
                throw new ArgumentException("Từ ngày không được lớn hơn Đến ngày.");

            if (theoThang)
            {
                // Báo cáo theo tháng luôn lấy trọn tháng: từ mùng 1 của tháng đầu đến ngày cuối của tháng cuối.
                tuNgay = new DateTime(tuNgay.Year, tuNgay.Month, 1);
                denNgay = new DateTime(denNgay.Year, denNgay.Month, 1).AddMonths(1).AddDays(-1);
                int soThang = (denNgay.Year - tuNgay.Year) * 12 + denNgay.Month - tuNgay.Month + 1;
                if (soThang > 60)
                    throw new ArgumentException("Báo cáo theo tháng xem tối đa 60 tháng mỗi lần.");
            }
            else if ((denNgay - tuNgay).TotalDays > 364)
            {
                throw new ArgumentException("Báo cáo theo ngày xem tối đa 365 ngày mỗi lần.");
            }

            var theoKy = _dal.LayDoanhThu(tuNgay, denNgay, theoThang).ToDictionary(x => x.Ky.Date);
            var kq = new BaoCaoDoanhThuDTO();

            // Duyệt đủ mọi kỳ trong khoảng để kỳ không có xe vẫn hiện số 0 (biểu đồ liền mạch).
            for (DateTime k = tuNgay; k <= denNgay; k = theoThang ? k.AddMonths(1) : k.AddDays(1))
            {
                DoanhThuKyDTO d;
                theoKy.TryGetValue(k, out d);

                kq.Dong.Add(new DoanhThuDTO
                {
                    Nhan = k.ToString(theoThang ? "MM/yyyy" : "dd/MM", Inv),
                    SoLuot = d == null ? 0 : d.SoLuot,
                    DoanhThu = d == null ? 0m : d.TienLuotGui + d.TienVeThang
                });
                if (d != null)
                {
                    kq.TongLuotGui += d.TienLuotGui;
                    kq.TongVeThang += d.TienVeThang;
                }
            }
            return kq;
        }

        /// <summary>
        /// Ghi CSV UTF-8 có BOM (Excel đọc đúng tiếng Việt). Dùng dấu ';' và dòng "sep=;" để Excel
        /// tự tách cột bất kể cài đặt vùng. Cột thời gian ghi dạng ="05/11" để Excel không tự đổi thành ngày.
        /// </summary>
        public void XuatCsv(BaoCaoDoanhThuDTO bc, string duongDan, bool theoThang)
        {
            if (bc == null || bc.Dong.Count == 0)
                throw new InvalidOperationException("Chưa có dữ liệu để xuất.");

            var sb = new StringBuilder();
            sb.AppendLine("sep=;");
            sb.AppendLine((theoThang ? "Tháng" : "Ngày") + ";Số lượt xe ra;Doanh thu (đ)");
            foreach (DoanhThuDTO d in bc.Dong)
                sb.AppendLine("=\"" + d.Nhan + "\";" + d.SoLuot.ToString(Inv) + ";" + d.DoanhThu.ToString("0", Inv));

            sb.AppendLine("Tổng cộng;" + bc.Dong.Sum(x => x.SoLuot).ToString(Inv) + ";" + bc.TongDoanhThu.ToString("0", Inv));
            sb.AppendLine("Trong đó lượt gửi;;" + bc.TongLuotGui.ToString("0", Inv));
            sb.AppendLine("Trong đó vé tháng;;" + bc.TongVeThang.ToString("0", Inv));

            File.WriteAllText(duongDan, sb.ToString(), new UTF8Encoding(true));
        }
    }
}