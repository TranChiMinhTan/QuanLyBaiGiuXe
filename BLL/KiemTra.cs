// Các hàm kiểm tra dữ liệu nhập dùng chung (BLL gọi, giao diện không tự kiểm tra).
using System.Text.RegularExpressions;

namespace QuanLyBaiGiuXe.BLL
{
    public static class KiemTra
    {
        private static readonly Regex BienSo = new Regex(@"^[A-Z0-9][A-Z0-9\.\- ]{3,14}$");
        private static readonly Regex SoDienThoai = new Regex(@"^0\d{9,10}$");
        private static readonly Regex Cccd = new Regex(@"^(\d{9}|\d{12})$");
        private static readonly Regex MaThe = new Regex(@"^[A-Z0-9]{2,10}$");

        public static bool BienSoHopLe(string s) => s != null && BienSo.IsMatch(s);
        public static bool SdtHopLe(string s) => s != null && SoDienThoai.IsMatch(s);
        public static bool CccdHopLe(string s) => s != null && Cccd.IsMatch(s);
        public static bool MaTheHopLe(string s) => s != null && MaThe.IsMatch(s);
    }
}
