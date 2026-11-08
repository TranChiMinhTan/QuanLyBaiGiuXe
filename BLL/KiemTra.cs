// Kiểm tra định dạng dùng chung cho mọi BLL. Hàm thuần, không đụng DB hay giao diện.
using System.Text.RegularExpressions;

namespace QuanLyBaiGiuXe.BLL
{
    public static class KiemTra
    {
        // Cùng mẫu với LuotGuiBLL trước đây: 4-15 ký tự chữ hoa/số/dấu chấm/gạch/khoảng trắng, ví dụ 51A-123.45
        private static readonly Regex MauBienSo = new Regex(@"^[A-Z0-9][A-Z0-9\.\- ]{3,14}$");
        // Cùng mẫu với TheXeBLL (Dự án B): 3-20 ký tự chữ, số hoặc gạch ngang
        private static readonly Regex MauMaThe = new Regex(@"^[A-Za-z0-9\-]{3,20}$");
        private static readonly Regex MauSdt = new Regex(@"^0\d{9,10}$");
        private static readonly Regex MauCccd = new Regex(@"^(\d{9}|\d{12})$");

        public static string ChuanHoaBienSo(string s) => (s ?? "").Trim().ToUpper();

        public static bool BienSoHopLe(string bienSo) => MauBienSo.IsMatch(ChuanHoaBienSo(bienSo));
        public static bool MaTheHopLe(string maThe) => MauMaThe.IsMatch((maThe ?? "").Trim());
        public static bool SdtHopLe(string sdt) => MauSdt.IsMatch((sdt ?? "").Trim());
        /// <summary>CMND 9 số hoặc CCCD 12 số.</summary>
        public static bool CccdHopLe(string cccd) => MauCccd.IsMatch((cccd ?? "").Trim());
    }
}
