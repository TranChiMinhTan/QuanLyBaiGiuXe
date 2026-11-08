// Bảng TaiKhoan. Chỉ SQL tham số hóa; việc băm và so khớp mật khẩu nằm ở BLL/BaoMat.
using System.Linq;
using System.Data.SqlClient;
using QuanLyBaiGiuXe.Models;
using static QuanLyBaiGiuXe.DAL.Database;

namespace QuanLyBaiGiuXe.DAL
{
    public class TaiKhoanDAL
    {
        private static TaiKhoanDTO Map(SqlDataReader r) => new TaiKhoanDTO
        {
            Id = r.Gt<int>("Id"),
            TenDangNhap = r.Gt<string>("TenDangNhap"),
            HoTen = r.Gt<string>("HoTen"),
            VaiTro = r.Gt<string>("VaiTro"),
            HoatDong = r.Gt<bool>("HoatDong"),
            Muoi = r.Gt<string>("Muoi"),
            MatKhauHash = r.Gt<string>("MatKhauHash")
        };

        public TaiKhoanDTO LayTheoTen(string tenDangNhap)
            => Doc<TaiKhoanDTO>("SELECT Id, TenDangNhap, MatKhauHash, Muoi, HoTen, VaiTro, HoatDong FROM TaiKhoan " +
                                "WHERE TenDangNhap = @t", Map, P("@t", tenDangNhap)).FirstOrDefault();

        public int CapNhatMatKhau(int id, string hash, string muoi)
            => ThucThi("UPDATE TaiKhoan SET MatKhauHash = @h, Muoi = @m WHERE Id = @id",
                       P("@h", hash), P("@m", muoi), P("@id", id));
    }
}
