using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using QuanLyBaiGiuXe.DAL;
using QuanLyBaiGiuXe.Models;

namespace QuanLyBaiGiuXe.BLL
{
    public class BaoCaoBLL
    {
        private readonly ThongKeDAL _dal = new ThongKeDAL();

        public string KiemTraKhoang(DateTime tu, DateTime den)
        {
            if (tu.Date > den.Date) return "\"Từ ngày\" phải nhỏ hơn hoặc bằng \"Đến ngày\".";
            if ((den.Date - tu.Date).TotalDays > 732) return "Khoảng thời gian tối đa 2 năm.";
            return null;
        }

        public List<DoanhThuDTO> DoanhThu(DateTime tu, DateTime den, bool theoThang) => _dal.DoanhThu(tu, den, theoThang);
        public decimal DoanhThuVeThang(DateTime tu, DateTime den) => _dal.DoanhThuVeThang(tu, den);

        /// <summary>Luôn trả đủ 24 giờ (0 đến 23), giờ không có xe thì SoLuot = 0.</summary>
        public List<GioCaoDiemDTO> GioCaoDiem(DateTime tu, DateTime den)
        {
            var coDuLieu = _dal.GioCaoDiem(tu, den);
            return Enumerable.Range(0, 24)
                .Select(h => new GioCaoDiemDTO { Gio = h, SoLuot = coDuLieu.Where(x => x.Gio == h).Sum(x => x.SoLuot) })
                .ToList();
        }

        public List<GoiYVeThangDTO> GoiYVeThang() => _dal.GoiYVeThang();

        /// <summary>Xuất CSV có BOM UTF-8 để Excel đọc đúng tiếng Việt.</summary>
        public void XuatCsv(string duongDan, List<DoanhThuDTO> ds, decimal doanhThuVeThang)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Thời gian,Số lượt,Doanh thu lượt gửi (đ)");
            foreach (var d in ds) sb.AppendLine(d.Nhan + "," + d.SoLuot + "," + d.DoanhThu.ToString("0"));
            sb.AppendLine("Tổng lượt gửi," + ds.Sum(x => x.SoLuot) + "," + ds.Sum(x => x.DoanhThu).ToString("0"));
            sb.AppendLine("Doanh thu vé tháng,," + doanhThuVeThang.ToString("0"));
            sb.AppendLine("TỔNG DOANH THU,," + (ds.Sum(x => x.DoanhThu) + doanhThuVeThang).ToString("0"));
            File.WriteAllText(duongDan, sb.ToString(), new UTF8Encoding(true));
            NhatKyBLL.Ghi("Xuất báo cáo CSV", Path.GetFileName(duongDan));
        }
    }
}
