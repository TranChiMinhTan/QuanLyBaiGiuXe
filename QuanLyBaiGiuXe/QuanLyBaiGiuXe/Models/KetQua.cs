// [Người 2] Kết quả trả về từ BLL: thành công hay lỗi, kèm cảnh báo. BLL không được hiện MessageBox.
namespace QuanLyBaiXe.Models
{
    public class KetQua
    {
        public bool ThanhCong { get; private set; }
        public string ThongBao { get; private set; }  // nội dung lỗi khi thất bại
        public string CanhBao { get; private set; }   // cảnh báo nhẹ khi vẫn thành công
        public LuotGuiDTO Luot { get; private set; }
        public BienNhanDTO BienNhan { get; private set; }

        public static KetQua Ok(LuotGuiDTO luot, string canhBao = null, BienNhanDTO bienNhan = null)
            => new KetQua { ThanhCong = true, Luot = luot, CanhBao = canhBao, BienNhan = bienNhan };

        public static KetQua Loi(string thongBao)
            => new KetQua { ThanhCong = false, ThongBao = thongBao };
    }
}
