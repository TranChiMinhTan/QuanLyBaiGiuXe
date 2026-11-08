# Nhật ký tái cấu trúc MVP (branch `ai/mvp-refactor`)

Nguyên tắc: không sửa `main` hay branch thành viên; không xóa code gốc (chỉ `git mv` vào `_Legacy/`);
không DROP/TRUNCATE; chưa chạm Database thật.

## Giai đoạn 1 - Vệ sinh repo
**Di chuyển (git mv, lịch sử được giữ):**
- `GUI/*` (13 file, Dự án B / MDI) -> `_Legacy/GUI/`
- `DTO/*` (8 file) -> `_Legacy/DTO/`
- `Scripts/Database.sql` (có DROP TABLE, schema lệch code) -> `_Legacy/Scripts/Database.sql`
- `QUanLyBaiGiuXe.slnx` -> `QuanLyBaiGiuXe.slnx` (sửa chữ hoa)

**Gỡ khỏi git index (`git rm --cached`, file vẫn còn trên máy):** `bin/`, `obj/` (31 file), `QuanLyBaiGiuXe.csproj.user`.

**Sửa:**
- `QuanLyBaiGiuXe.csproj`: bỏ HintPath tuyệt đối của `System`, bỏ tham chiếu `System.Windows.Forms.DataVisualization`
  (biểu đồ dùng GDI+), thêm `DAL/BaoCaoDAL.cs`, `Models/BaoCaoDoanhThuDTO.cs`, `Views/InPhieu.cs`;
  gỡ 18 mục trỏ tới file chưa có trong repo và ghi lại ở khối chú thích PENDING.
- `App.config`: thêm thẻ gốc `<configuration>`.
- `DAL/Database.cs`: đọc khóa `QuanLyBaiGiuXeDB` (trùng App.config; trước đó đọc `QuanLyBaiXeDB` -> NullReference).

**Xóa:** không có.

## Giai đoạn 2 - BLL / DAL / Presenter / Database (viết lại 18 file thiếu theo xác nhận "phương án B")

### Kết quả kiểm tra trước khi viết
- 18 file không có ở bất kỳ branch nào; hợp đồng của từng file suy ra từ nơi gọi (Views, FrmMain, Program, VeThangBLL, I*View).
- Phát hiện thêm: `BaoCaoBLL/DAL/Presenter`, `TraCuuBLL/DAL/Presenter`, `InPhieu`, `BaoCaoDoanhThuDTO` còn namespace `QuanLyBaiXe`
  (lẽ ra không thể build chung với phần còn lại) -> đã đổi sang `QuanLyBaiGiuXe.*`.
- Database thật: instance SQLEXPRESS của nhóm trưởng KHÔNG có database dự án (chỉ EduManagerDB, QLSinhVienLab12) -> chưa có DB riêng.

### 18 file mới (nghiệp vụ suy ra từ code; mục "suy luận" cần nhóm trưởng xác nhận ở báo cáo giai đoạn)
| File | Nguồn nghiệp vụ |
|---|---|
| Models/NhatKyDTO, GioCaoDiemDTO, GoiYVeThangDTO, ChoTrongDTO | Cột mà `FrmNhatKy`, `FrmGioCaoDiem`, `FrmGoiYVeThang`, `FrmMain`, `LoaiXeDTO` đang dùng |
| BLL/KiemTra | Regex biển số từ `LuotGuiBLL`, mã thẻ từ `TheXeBLL` (Dự án B); SĐT/CCCD là suy luận |
| BLL/BaoMat | `TaiKhoanDTO.Muoi/MatKhauHash`; PBKDF2-SHA256, tương thích hash SHA-256 cũ và tự nâng cấp |
| BLL/PhienLamViec | `Program.cs` (`PhienLamViec.TaiKhoan`) |
| BLL/NhatKyBLL, DAL/NhatKyDAL | `FrmNhatKy` (500 dòng gần nhất, tìm theo người dùng/hành động/chi tiết), `VeThangBLL`, `FrmMain` |
| DAL/ThongKeDAL | `FrmGioCaoDiem` (24 cột theo giờ vào), `FrmGoiYVeThang` (30 ngày, >= 80% giá vé tháng, chưa có vé còn hạn) |
| Presenters x8 | `I*View` + lời gọi trong `uc*`/`Frm*` |

Viết lại (bản gốc chuyển vào `_Legacy/BLL`, `_Legacy/DAL` bằng `git mv`): `BangGiaBLL, LoaiXeBLL, TheXeBLL, TaiKhoanBLL, KhachHangBLL,
ChoTrongBLL, KetQua(BLL), PhienDangNhap` và `ChoTrongDAL, KhachHangDAL, TaiKhoanDAL`. Validation của Dự án B được port sang (ghi chú trong từng file).

### Chuẩn hóa
- `Models/TrangThai.cs`: `TrangThaiThe` có **4** giá trị `Đang trống / Đang dùng / Khóa / Đã mất` (Khóa và Đã mất giữ riêng theo yêu cầu);
  `LuotGuiBLL`, `LuotGuiDAL`, `VanHanhPresenter` dùng hằng số thay chuỗi rải rác. `LuotGuiBLL` báo lỗi riêng cho thẻ Khóa.
- `LuotGuiDAL.XeRa`: câu lệnh trả thẻ về "Đang trống" thêm điều kiện `TrangThai = 'Đang dùng'` (không ghi đè Khóa/Đã mất).
- Tính phí mô hình B+ (`BLL/TinhPhiBLL.cs`, `docs/MO_HINH_TINH_PHI.md`); `BangGiaDTO/DAL/BLL`, `IBangGiaView` đổi theo.
- `BaoCaoPresenter` thêm `GioCaoDiem()`, `GoiYVeThang()`; `TraCuuPresenter` đổi `TimKiem`->`Tim`, thêm `Chon()`, `InBienNhan()` không tham số.
- `QuanLyBaiGiuXe.csproj`: thêm 19 file mới, bỏ khối PENDING. Thêm `QuanLyBaiGiuXe.Tests/` (MSTest) vào `.slnx`.

### Database (chỉ VIẾT, chưa chạy ở đâu cả)
- `Database/00_Inspect.sql` (chỉ SELECT), `01_Migration.sql`, `02_Verify.sql` (chỉ SELECT), `03_DuLieuMau.sql` (tùy chọn).
- `Database_Nguoi4.sql` -> `_Legacy/Scripts/` (nhầm `USE QuanLyBaiXe`, bỏ sót tiền gia hạn); `sp_BaoCaoDoanhThu` bản mới nằm trong `01_Migration.sql`.
- Không có DROP / TRUNCATE / DELETE trên dữ liệu dự án. Nếu gặp bảng cũ khác cấu trúc, script DỪNG, không tự chuyển dữ liệu.

### Việc còn lại (giai đoạn 3 - Views)
`ucBangGia` (Designer còn control mô hình A), `ucTheXe` (combobox mới 3 trạng thái), `ucViewBase` vs `: UserControl, ucViewBase` (CS1721),
lệch tên control Designer/code-behind, thiếu `using QuanLyBaiGiuXe.Presenters`, `HienThiXeTrongBai`, `pbAnh`, `btnGoiYVeThang`,
file Designer lệch tên class (`Form1`, `Frmnhatky`...), gộp 3 bản in.

## Chưa kiểm thử
Môi trường làm việc không có Visual Studio/.NET Framework 4.8/SQL Server: **chưa build, chưa chạy ứng dụng, chưa chạy script SQL, chưa chạy unit test**.
Đã làm được: kiểm tra cú pháp C# bằng trình phân tích (0 lỗi cú pháp, không phải biên dịch), mô phỏng thuật toán tính phí bằng Python (12/12 ca khớp).
