// [Người 2] Hợp đồng giữa ucVanHanh và VanHanhPresenter.
using System.Collections.Generic;
using QuanLyBaiGiuXe.Models;

namespace QuanLyBaiGiuXe.Views
{
    public interface IVanHanhView : IViewCoBan
    {
        // ----- dữ liệu Presenter đọc từ giao diện -----
        string BienSo { get; }
        string MaThe { get; }
        int MaLoaiXe { get; }               // 0 nếu chưa chọn
        string DuongDanAnh { get; }         // đường dẫn file ảnh người dùng vừa chọn (tuyệt đối, tạm thời)
        bool GiaLapLoi { get; }             // chỉ true khi demo rollback

        // ----- Presenter ra lệnh cho giao diện hiển thị -----
        void NapLoaiXe(List<LoaiXeDTO> ds);
        void HienThiLuotGui(List<LuotGuiDTO> ds);
        void HienThiSoDo(List<OGuiDTO> ds);
        void HienThiConTrong(int trong, int tong);
        void HienThiXeTrongBai(int soXe);
        void HienThiCanhBao(string noiDung);                              // chuỗi rỗng = xóa cảnh báo
        void HienThiXeRa(LuotGuiDTO luot, decimal phi, string ghiChu);    // master-detail: thông tin + phí tạm tính
        void HienThiPhi(decimal phi);
        void HienThiThongTinO(OGuiDTO o);
        void DatMaThe(string maThe);
        void XoaNhap();
        void InBienNhan(BienNhanDTO bienNhan);                            // mở PrintPreview
    }
}
