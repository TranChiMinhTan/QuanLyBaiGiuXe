using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QuanLyBaiXe.DTO;

namespace QuanLyBaiXe.DAL
{
    public class BangGiaDAL
    {
        private const string SqlChon =
            "SELECT g.MaBangGia, g.MaLoaiXe, l.TenLoaiXe, g.GiaGioDau, g.GiaGioTiepTheo, " +
            "       g.GiaToiDaNgay, g.GiaVeThang, g.NgayApDung, g.ConHieuLuc " +
            "FROM BangGia g JOIN LoaiXe l ON l.MaLoaiXe = g.MaLoaiXe ";

        private static BangGiaDTO Doc(DataRow r)
        {
            return new BangGiaDTO
            {
                MaBangGia = Convert.ToInt32(r["MaBangGia"]),
                MaLoaiXe = Convert.ToInt32(r["MaLoaiXe"]),
                TenLoaiXe = r["TenLoaiXe"].ToString(),
                GiaGioDau = Convert.ToDecimal(r["GiaGioDau"]),
                GiaGioTiepTheo = Convert.ToDecimal(r["GiaGioTiepTheo"]),
                GiaToiDaNgay = Convert.ToDecimal(r["GiaToiDaNgay"]),
                GiaVeThang = Convert.ToDecimal(r["GiaVeThang"]),
                NgayApDung = Convert.ToDateTime(r["NgayApDung"]),
                ConHieuLuc = Convert.ToBoolean(r["ConHieuLuc"])
            };
        }

        public List<BangGiaDTO> LayTatCa()
        {
            DataTable dt = Database.LayBang(SqlChon + "ORDER BY l.TenLoaiXe, g.NgayApDung DESC, g.MaBangGia DESC");
            List<BangGiaDTO> ds = new List<BangGiaDTO>();
            foreach (DataRow r in dt.Rows) ds.Add(Doc(r));
            return ds;
        }

        /// <summary>
        /// Lấy bảng giá đang áp dụng của một loại xe (mới nhất, còn hiệu lực, ngày áp dụng &lt;= hôm nay).
        /// Người 2 dùng hàm này để tính phí. Trả về null nếu chưa có bảng giá.
        /// </summary>
        public BangGiaDTO LayHieuLucTheoLoai(int maLoaiXe)
        {
            DataTable dt = Database.LayBang(
                SqlChon +
                "WHERE g.MaLoaiXe = @loai AND g.ConHieuLuc = 1 AND g.NgayApDung <= CONVERT(DATE, GETDATE()) " +
                "ORDER BY g.NgayApDung DESC, g.MaBangGia DESC",
                Database.Tham("@loai", maLoaiXe));
            return dt.Rows.Count == 0 ? null : Doc(dt.Rows[0]);
        }

        /// <summary>Thêm bảng giá. Nếu bảng giá mới còn hiệu lực thì các bảng giá cũ của loại xe đó bị tắt (cùng transaction).</summary>
        public int Them(BangGiaDTO g)
        {
            int maMoi = 0;
            Database.ChayTrongTransaction(delegate (SqlConnection cn, SqlTransaction tr)
            {
                if (g.ConHieuLuc)
                {
                    Database.ThucThi(cn, tr,
                        "UPDATE BangGia SET ConHieuLuc = 0 WHERE MaLoaiXe = @loai",
                        Database.Tham("@loai", g.MaLoaiXe));
                }
                object kq = Database.LayGiaTri(cn, tr,
                    "INSERT INTO BangGia (MaLoaiXe, GiaGioDau, GiaGioTiepTheo, GiaToiDaNgay, GiaVeThang, NgayApDung, ConHieuLuc) " +
                    "OUTPUT INSERTED.MaBangGia " +
                    "VALUES (@loai, @gd, @gt, @td, @vt, @ngay, @hl)",
                    Database.Tham("@loai", g.MaLoaiXe),
                    Database.Tham("@gd", g.GiaGioDau),
                    Database.Tham("@gt", g.GiaGioTiepTheo),
                    Database.Tham("@td", g.GiaToiDaNgay),
                    Database.Tham("@vt", g.GiaVeThang),
                    Database.Tham("@ngay", g.NgayApDung.Date),
                    Database.Tham("@hl", g.ConHieuLuc));
                maMoi = Convert.ToInt32(kq);
            });
            return maMoi;
        }

        public int Sua(BangGiaDTO g)
        {
            int soDong = 0;
            Database.ChayTrongTransaction(delegate (SqlConnection cn, SqlTransaction tr)
            {
                if (g.ConHieuLuc)
                {
                    Database.ThucThi(cn, tr,
                        "UPDATE BangGia SET ConHieuLuc = 0 WHERE MaLoaiXe = @loai AND MaBangGia <> @ma",
                        Database.Tham("@loai", g.MaLoaiXe),
                        Database.Tham("@ma", g.MaBangGia));
                }
                soDong = Database.ThucThi(cn, tr,
                    "UPDATE BangGia SET MaLoaiXe = @loai, GiaGioDau = @gd, GiaGioTiepTheo = @gt, " +
                    "GiaToiDaNgay = @td, GiaVeThang = @vt, NgayApDung = @ngay, ConHieuLuc = @hl " +
                    "WHERE MaBangGia = @ma",
                    Database.Tham("@loai", g.MaLoaiXe),
                    Database.Tham("@gd", g.GiaGioDau),
                    Database.Tham("@gt", g.GiaGioTiepTheo),
                    Database.Tham("@td", g.GiaToiDaNgay),
                    Database.Tham("@vt", g.GiaVeThang),
                    Database.Tham("@ngay", g.NgayApDung.Date),
                    Database.Tham("@hl", g.ConHieuLuc),
                    Database.Tham("@ma", g.MaBangGia));
            });
            return soDong;
        }

        public int Xoa(int maBangGia)
        {
            return Database.ThucThi("DELETE FROM BangGia WHERE MaBangGia = @ma",
                Database.Tham("@ma", maBangGia));
        }
    }
}
