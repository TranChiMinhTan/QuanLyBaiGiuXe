# Mô hình tính phí B+ (áp dụng trong `BLL/TinhPhiBLL.cs`)

## Quy tắc
1. Gửi **không quá `MienPhiPhut`** phút (mặc định 15): miễn phí.
2. Cứ **trọn 24 giờ** tính `GiaToiDaNgay`.
3. Phần lẻ còn lại, **làm tròn lên theo giờ**: `GiaGioDau + (số giờ - 1) × GiaGioTiepTheo`, nhưng **không quá `GiaToiDaNgay`**.
4. Xe có vé tháng còn hạn: phí 0 (giữ nguyên `TinhTien`).
5. Không còn `PhuThuQuaDem` (đã gộp vào trần mỗi 24 giờ). Mỗi loại xe có đúng **một** bảng giá hiện hành.

## Bảng ví dụ (xe máy: miễn phí 15 phút, giờ đầu 3.000, giờ tiếp theo 2.000, trần 15.000)
| Thời gian gửi | Phí B+ | Mô hình cũ (A) |
|---|---|---|
| 10 phút | 0 | 0 |
| 50 phút | 3.000 | 3.000 |
| 3 giờ 20 phút | 9.000 | 12.000 |
| 9 giờ | 15.000 (chạm trần) | 32.000 |
| 30 giờ | 28.000 (15.000 + 13.000) | 95.000 |

Các ca biên đã đối chiếu bằng bản mô phỏng Python của thuật toán: đúng 15 phút → 0; 15 phút 1 giây → 3.000;
đúng 1 giờ → 3.000; 1 giờ 1 giây → 5.000; đúng 24 giờ → 15.000; 24 giờ 10 phút → 18.000; 48 giờ → 30.000.

## Thay đổi so với mô hình cũ (A)
- `BangGiaDTO`: bỏ `GiaKhoi`, `SoGioKhoi`, `PhuThuQuaDem`; thêm `GiaGioDau`, `GiaGioTiepTheo`, `GiaToiDaNgay`.
- Bảng `BangGia` (xem `Database/01_Migration.sql`): một dòng cho mỗi loại xe (`UNIQUE(MaLoaiXe)`); không lưu lịch sử đổi giá
  (phí đã tính được lưu cố định trong `LuotGui.Phi` và `ThanhToan.SoTien`, nên báo cáo cũ không bị ảnh hưởng khi đổi giá).
- `IBangGiaView` đổi tương ứng. **`ucBangGia` (giao diện) chưa được cập nhật** - thuộc giai đoạn Views.
