using System.Linq;
using QuanLyBaiGiuXe.Models;
using static QuanLyBaiGiuXe.DAL.Database;

namespace QuanLyBaiGiuXe.DAL
{
    public class TaiKhoanDAL
    {
        public TaiKhoanDTO LayTheoTen(string tenDangNhap)
            => Doc<TaiKhoanDTO>(
                "SELECT Id, TenDangNhap, HoTen, VaiTro, HoatDong, Muoi, MatKhauHash FROM TaiKhoan WHERE TenDangNhap = @t",
                r => new TaiKhoanDTO
                {
                    Id = r.Gt<int>("Id"), TenDangNhap = r.Gt<string>("TenDangNhap"), HoTen = r.Gt<string>("HoTen"),
                    VaiTro = r.Gt<string>("VaiTro"), HoatDong = r.Gt<bool>("HoatDong"),
                    Muoi = r.Gt<string>("Muoi"), MatKhauHash = r.Gt<string>("MatKhauHash")
                },
                P("@t", tenDangNhap)).FirstOrDefault();

        public void CapNhatMatKhau(int id, string muoi, string hash)
            => ThucThi("UPDATE TaiKhoan SET Muoi = @m, MatKhauHash = @h WHERE Id = @id",
                       P("@m", muoi), P("@h", hash), P("@id", id));
    }
}
