namespace QuanLyBaiXe.DTO
{
    /// <summary>
    /// Các trạng thái của thẻ xe (khớp ràng buộc CHECK trong CSDL).
    /// Người 2: khi xe vào đặt DangDung, khi xe ra đặt lại SanSang (trong cùng transaction).
    /// </summary>
    public static class TrangThaiThe
    {
        public const string SanSang = "Sẵn sàng";
        public const string DangDung = "Đang dùng";
        public const string Khoa = "Khóa";
    }

    public class TheXeDTO
    {
        public string MaThe { get; set; }
        public int MaLoaiXe { get; set; }
        public string TenLoaiXe { get; set; }   // chỉ để hiển thị (JOIN LoaiXe)
        public string TrangThai { get; set; }
    }
}
