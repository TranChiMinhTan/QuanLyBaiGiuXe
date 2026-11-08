using System;
using System.Collections.Generic;
using System.Data;
using QuanLyBaiXe.DTO;

namespace QuanLyBaiXe.DAL
{
    public class LoaiXeDAL
    {
        private static LoaiXeDTO Doc(DataRow r)
        {
            return new LoaiXeDTO
            {
                MaLoaiXe = Convert.ToInt32(r["MaLoaiXe"]),
                TenLoaiXe = r["TenLoaiXe"].ToString(),
                MoTa = r["MoTa"] == DBNull.Value ? "" : r["MoTa"].ToString(),
                SucChua = Convert.ToInt32(r["SucChua"])
            };
        }

        public List<LoaiXeDTO> LayTatCa()
        {
            DataTable dt = Database.LayBang(
                "SELECT MaLoaiXe, TenLoaiXe, MoTa, SucChua FROM LoaiXe ORDER BY MaLoaiXe");
            List<LoaiXeDTO> ds = new List<LoaiXeDTO>();
            foreach (DataRow r in dt.Rows) ds.Add(Doc(r));
            return ds;
        }

        public LoaiXeDTO LayTheoMa(int maLoaiXe)
        {
            DataTable dt = Database.LayBang(
                "SELECT MaLoaiXe, TenLoaiXe, MoTa, SucChua FROM LoaiXe WHERE MaLoaiXe = @ma",
                Database.Tham("@ma", maLoaiXe));
            return dt.Rows.Count == 0 ? null : Doc(dt.Rows[0]);
        }

        public int Them(LoaiXeDTO x)
        {
            return Database.ThucThi(
                "INSERT INTO LoaiXe (TenLoaiXe, MoTa, SucChua) VALUES (@ten, @mota, @suc)",
                Database.Tham("@ten", x.TenLoaiXe),
                Database.Tham("@mota", string.IsNullOrEmpty(x.MoTa) ? null : x.MoTa),
                Database.Tham("@suc", x.SucChua));
        }

        public int Sua(LoaiXeDTO x)
        {
            return Database.ThucThi(
                "UPDATE LoaiXe SET TenLoaiXe = @ten, MoTa = @mota, SucChua = @suc WHERE MaLoaiXe = @ma",
                Database.Tham("@ten", x.TenLoaiXe),
                Database.Tham("@mota", string.IsNullOrEmpty(x.MoTa) ? null : x.MoTa),
                Database.Tham("@suc", x.SucChua),
                Database.Tham("@ma", x.MaLoaiXe));
        }

        public int Xoa(int maLoaiXe)
        {
            return Database.ThucThi("DELETE FROM LoaiXe WHERE MaLoaiXe = @ma",
                Database.Tham("@ma", maLoaiXe));
        }

        /// <summary>Kiểm tra trùng tên (bỏ qua chính bản ghi có mã boQuaMa; truyền 0 khi thêm mới).</summary>
        public bool TonTaiTen(string ten, int boQuaMa)
        {
            object kq = Database.LayGiaTri(
                "SELECT COUNT(*) FROM LoaiXe WHERE TenLoaiXe = @ten AND MaLoaiXe <> @ma",
                Database.Tham("@ten", ten),
                Database.Tham("@ma", boQuaMa));
            return Convert.ToInt32(kq) > 0;
        }

        /// <summary>Loại xe đã được thẻ xe, bảng giá hoặc vé tháng tham chiếu thì không được xóa.</summary>
        public bool DangDuocSuDung(int maLoaiXe)
        {
            object kq = Database.LayGiaTri(
                "SELECT (SELECT COUNT(*) FROM TheXe   WHERE MaLoaiXe = @ma) " +
                "     + (SELECT COUNT(*) FROM BangGia WHERE MaLoaiXe = @ma) " +
                "     + (SELECT COUNT(*) FROM VeThang WHERE MaLoaiXe = @ma)",
                Database.Tham("@ma", maLoaiXe));
            return Convert.ToInt32(kq) > 0;
        }
    }
}
