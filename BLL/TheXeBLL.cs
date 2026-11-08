using System.Collections.Generic;
using System.Text.RegularExpressions;
using QuanLyBaiXe.DAL;
using QuanLyBaiXe.DTO;

namespace QuanLyBaiXe.BLL
{
    public class TheXeBLL
    {
        private readonly TheXeDAL dal = new TheXeDAL();
        private static readonly Regex MauMaThe = new Regex(@"^[A-Za-z0-9\-]{3,20}$");

        public List<TheXeDTO> LayTatCa()
        {
            return dal.LayTatCa();
        }

        public TheXeDTO LayTheoMa(string maThe)
        {
            return dal.LayTheoMa((maThe ?? "").Trim().ToUpper());
        }

        private static string KiemTra(TheXeDTO t)
        {
            t.MaThe = (t.MaThe ?? "").Trim().ToUpper();

            if (t.MaThe.Length == 0) return "Mã thẻ không được để trống.";
            if (!MauMaThe.IsMatch(t.MaThe)) return "Mã thẻ gồm 3-20 ký tự chữ, số hoặc dấu gạch ngang, không có khoảng trắng.";
            if (t.MaLoaiXe <= 0) return "Vui lòng chọn loại xe.";
            if (t.TrangThai != TrangThaiThe.SanSang && t.TrangThai != TrangThaiThe.DangDung && t.TrangThai != TrangThaiThe.Khoa)
                return "Trạng thái thẻ không hợp lệ.";
            return null;
        }

        public KetQua Them(TheXeDTO t)
        {
            return KetQua.Chay(() =>
            {
                string loi = KiemTra(t);
                if (loi != null) return KetQua.Loi(loi);
                if (t.TrangThai == TrangThaiThe.DangDung)
                    return KetQua.Loi("Trạng thái \"Đang dùng\" do hệ thống tự cập nhật khi xe vào, không đặt thủ công.");
                if (dal.TonTai(t.MaThe)) return KetQua.Loi("Mã thẻ đã tồn tại.");

                dal.Them(t);
                return KetQua.OK("Thêm thẻ xe thành công.");
            });
        }

        public KetQua Sua(TheXeDTO t)
        {
            return KetQua.Chay(() =>
            {
                string loi = KiemTra(t);
                if (loi != null) return KetQua.Loi(loi);

                TheXeDTO hienTai = dal.LayTheoMa(t.MaThe);
                if (hienTai == null) return KetQua.Loi("Không tìm thấy thẻ xe cần sửa.");

                bool dangCoXe = hienTai.TrangThai == TrangThaiThe.DangDung;
                if (!dangCoXe && t.TrangThai == TrangThaiThe.DangDung)
                    return KetQua.Loi("Trạng thái \"Đang dùng\" do hệ thống tự cập nhật khi xe vào, không đặt thủ công.");
                if (dangCoXe && t.TrangThai != TrangThaiThe.DangDung)
                    return KetQua.Loi("Thẻ đang có xe gửi, không thể đổi trạng thái. Hãy cho xe ra trước.");
                if (dangCoXe && t.MaLoaiXe != hienTai.MaLoaiXe)
                    return KetQua.Loi("Thẻ đang có xe gửi, không thể đổi loại xe.");

                dal.Sua(t);
                return KetQua.OK("Cập nhật thẻ xe thành công.");
            });
        }

        public KetQua Xoa(string maThe)
        {
            return KetQua.Chay(() =>
            {
                maThe = (maThe ?? "").Trim().ToUpper();
                if (dal.DaCoLuotGui(maThe))
                    return KetQua.Loi("Thẻ đã có lịch sử lượt gửi nên không thể xóa. Hãy chuyển trạng thái sang \"Khóa\".");

                if (dal.Xoa(maThe) == 0) return KetQua.Loi("Không tìm thấy thẻ xe cần xóa.");
                return KetQua.OK("Xóa thẻ xe thành công.");
            });
        }
    }
}
