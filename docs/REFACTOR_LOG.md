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

## Đang chờ (PENDING) - 18 file không tồn tại ở bất kỳ branch nào
Presenters: BangGia, DangNhap, DoiMatKhau, KhachHang, LoaiXe, NhatKy, TheXe, VeThang
BLL: BaoMat, KiemTra, NhatKyBLL, PhienLamViec | DAL: NhatKyDAL, ThongKeDAL
Models: ChoTrongDTO, GioCaoDiemDTO, GoiYVeThangDTO, NhatKyDTO

Cho tới khi có các file này (hoặc được viết lại), solution CHƯA build được.

## Chưa kiểm thử
Môi trường làm việc không có Visual Studio/.NET Framework 4.8/SQL Server: chưa build, chưa chạy.
