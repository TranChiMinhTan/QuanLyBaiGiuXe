# Phần của Người 2: Xe vào / Xe ra / Tính phí / Transaction
 
## 1. Cách đưa vào project
1. Giải nén, copy các file `.cs` vào đúng thư mục tương ứng trong project `QuanLyBaiXe` (Solution Explorer, chuột phải thư mục, Add > Existing Item).
2. Thêm Reference **System.Configuration** (chuột phải References > Add Reference > Assemblies).
3. Dán `App.config.mau.txt` vào `App.config`, đổi `Server=` cho đúng máy.
4. Chạy `Database/00_TaoDB_Tam_ChoNguoi2.sql` trong SSMS.
5. Mở `ucVanHanh.Designer` (do bạn dựng) và đặt đúng tên control như ghi ở đầu file `Views/ucVanHanh.cs`.
6. Trong `FrmMain` phải có `public void CapNhatSoXe(int dangGui)` (đã có ở hướng dẫn FrmMain).
7. Build. Lỗi thường gặp: namespace trong Designer khác `QuanLyBaiXe.Views` thì sửa dòng `namespace` trong `ucVanHanh.cs`.
## 2. File nào của ai
| File | Chủ | Ghi chú |
|---|---|---|
| Models: LuotGuiDTO, ThanhToanDTO, BienNhanDTO, OGuiDTO, KetQua | Người 2 | Hoàn chỉnh |
| DAL/LuotGuiDAL, BLL/TinhPhiBLL, BLL/LuotGuiBLL, Presenters/VanHanhPresenter | Người 2 | Hoàn chỉnh |
| Views/IVanHanhView, Views/ucVanHanh (code-behind), Views/IViewCoBan | Người 2 | Hoàn chỉnh |
| Views/IDangNhapView, ILoaiXeView, ITheXeView, IBangGiaView | Người 1 | Interface xong, Người 1 viết Presenter |
| Views/IKhachHangView, IVeThangView | Người 3 | Như trên |
| Views/ITraCuuView, IBaoCaoView | Người 4 | Như trên |
| Models: LoaiXeDTO, TheXeDTO, BangGiaDTO, TaiKhoanDTO | Người 1 | **Bản nháp**, sửa tự do |
| Models: KhachHangDTO, VeThangDTO | Người 3 | **Bản nháp** |
| Models: DoanhThuDTO | Người 4 | **Bản nháp** |
| DAL/Database, LoaiXeDAL, TheXeDAL, BangGiaDAL | Người 1 | **Bản tạm**, thay bằng bản đầy đủ, giữ tên hàm |
| DAL/VeThangDAL, BLL/VeThangBLL | Người 3 | **Bản tạm**, giữ nguyên `KiemTraVeThang(string bienSo)` |
 
## 3. Interface View là gì?
Mỗi màn hình có một interface liệt kê **những gì Presenter được phép đọc và ra lệnh**:
- Thuộc tính (`BienSo`, `TuNgay`...) là dữ liệu Presenter **đọc** từ ô nhập.
- Hàm (`HienThiDanhSach`, `BaoLoi`...) là việc Presenter **bảo** giao diện làm.
Nhờ vậy Presenter không biết `TextBox` hay `DataGridView` là gì, nên test được mà không mở form, và đổi giao diện không phải sửa logic. Cả 9 interface cùng kế thừa `IViewCoBan` (ThongBao, BaoLoi, XacNhan).
 
## 4. Việc Người 1 và Người 3 phải làm để khớp với bạn
- Giữ đúng tên bảng, tên cột trong script SQL tạm (hoặc báo bạn để sửa `LuotGuiDAL`).
- Bảng `BangGia` phải có `MienPhiPhut, GiaKhoi, SoGioKhoi, PhuThuQuaDem`.
- `TheXe.TrangThai` chỉ nhận ba giá trị: `Đang trống`, `Đang dùng`, `Đã mất`.
- `VeThangBLL.KiemTraVeThang(bienSo)` trả về vé gần nhất của biển số, **kể cả đã hết hạn**, trả null nếu chưa từng đăng ký.
## 5. Checklist tự kiểm thử (đưa vào test case của Chương 4)
| ID | Thao tác | Kết quả mong đợi |
|---|---|---|
| TC-V01 | Xe vào, biển số rỗng | Báo "Biển số không được để trống" |
| TC-V02 | Xe vào, biển số sai định dạng (ví dụ `@@`) | Báo biển số không hợp lệ |
| TC-V03 | Xe vào hai lần cùng biển số | Lần hai báo "đang ở trong bãi" |
| TC-V04 | Xe vào với thẻ đang dùng | Báo thẻ đang được sử dụng |
| TC-V05 | Xe vào với thẻ Đã mất | Báo thẻ đã báo mất |
| TC-V06 | Chọn loại xe không khớp loại thẻ | Báo thẻ dành cho loại xe khác |
| TC-V07 | Xe vào với biển số `59C1-678.90` (vé còn 5 ngày) | Hiện cảnh báo vé sắp hết hạn |
| TC-R01 | Xe ra, mã thẻ không có xe | Báo không có lượt gửi đang hoạt động |
| TC-R02 | Gửi 10 phút | Phí = 0 (miễn phí 15 phút) |
| TC-R03 | Gửi 2 giờ xe máy | Phí = 3.000 |
| TC-R04 | Gửi 5 giờ xe máy (làm tròn lên 2 khối) | Phí = 6.000 |
| TC-R05 | Gửi qua đêm | Phí cộng phụ thu qua đêm |
| TC-R06 | Xe có vé tháng còn hạn ra | Phí = 0, ghi chú miễn phí |
| TC-R07 | Xe có vé tháng hết hạn ra | Tính phí thường, có ghi chú hết hạn |
| TC-R08 | Bật giả lập lỗi, bấm thanh toán | Báo lỗi, **lượt gửi chưa có giờ ra, không có dòng ThanhToan, thẻ vẫn Đang dùng** |
| TC-R09 | Tắt giả lập lỗi, thanh toán lại | Thành công, thẻ về Đang trống, ô trên sơ đồ chuyển xanh lá |
| TC-A01 | Chọn ảnh rồi xe vào | Có file trong `Images\BienSo`, DB lưu đường dẫn tương đối |
 
Test Func tính phí không cần giao diện: gọi `TinhPhiBLL.TinhPhi(luot, gia)` với `GioVao`, `GioRa` tự đặt.