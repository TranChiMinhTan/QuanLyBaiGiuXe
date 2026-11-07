# Quản lý bãi giữ xe (Đề tài 19)

Ứng dụng WinForms (C#) quản lý loại xe, thẻ xe, lượt vào/ra, vé tháng và doanh thu.
Kiến trúc ba lớp: **DTO – DAL – BLL – GUI**. Vai trò: Nhân viên bãi xe, Quản lý.

## 1. Yêu cầu
- Windows, Visual Studio 2019/2022 (workload ".NET desktop development")
- .NET Framework 4.8
- SQL Server (Express / LocalDB / Developer) và SQL Server Management Studio (SSMS)

## 2. Cài đặt và chạy
1. Mở SSMS, mở file `Scripts/Database.sql`, bấm **Execute** (chạy lại được nhiều lần; mỗi lần chạy sẽ tạo lại bảng và dữ liệu mẫu).
2. Mở Visual Studio: **Create new project → Windows Forms App (.NET Framework)**, đặt tên `QuanLyBaiXe`, framework 4.8.
3. Chép các thư mục `DTO`, `DAL`, `BLL`, `GUI` và file `Program.cs`, `App.config` vào thư mục project (ghi đè `Program.cs`, `App.config` có sẵn). Trong Solution Explorer bấm **Show All Files → Include In Project** cho các thư mục vừa chép. Xóa `Form1.cs` mặc định.
4. **References → Add Reference → Assemblies → Framework → tick `System.Configuration`.**
5. Sửa chuỗi kết nối trong `App.config` cho đúng máy (xem mục 3).
6. Nhấn **F5**.

## 3. Chuỗi kết nối (`App.config`)
| Loại SQL Server | Giá trị `Server=` |
|---|---|
| SQL Server Express | `.\SQLEXPRESS` |
| LocalDB | `(localdb)\MSSQLLocalDB` |
| SQL Server mặc định | `.` hoặc tên máy |

Dùng tài khoản SQL: thay `Trusted_Connection=True` bằng `User Id=sa;Password=<mật khẩu>`.
Lỗi thường gặp: *"A network-related or instance-specific error"* → sai tên Server hoặc dịch vụ SQL Server chưa chạy.

## 4. Tài khoản mẫu
| Tên đăng nhập | Mật khẩu | Vai trò | Thấy menu |
|---|---|---|---|
| `admin` | `123456` | Quản lý | Tất cả (kể cả Danh mục, Báo cáo) |
| `nv01` | `123456` | Nhân viên | Gửi xe, Khách hàng, Tra cứu (ẩn Danh mục, Báo cáo) |

## 5. Cấu trúc solution
```
QuanLyBaiXe
|-- DTO       (LoaiXeDTO, TheXeDTO, BangGiaDTO, TaiKhoanDTO, ...)
|-- DAL       (Database.cs, LoaiXeDAL, TheXeDAL, BangGiaDAL, TaiKhoanDAL, ...)
|-- BLL       (KetQua, PhienDangNhap, LoaiXeBLL, TheXeBLL, BangGiaBLL, TaiKhoanBLL, ...)
|-- GUI       (FrmDangNhap, FrmMain, FrmDanhMucBase, FrmLoaiXe, ...)
|-- Resources (ảnh biển số, biểu tượng)
`-- Scripts   (Database.sql)
```

## 6. Quy ước chung cho cả nhóm
**Tên lớp form (FrmMain mở form theo tên lớp, phải đúng chính tả, namespace `QuanLyBaiXe.GUI`, có constructor không tham số):**

| Người | Tên lớp form |
|---|---|
| 1 | `FrmLoaiXe`, `FrmTheXe`, `FrmBangGia` |
| 2 | `FrmXeVao`, `FrmXeRa` |
| 3 | `FrmKhachHang`, `FrmVeThang` |
| 4 | `FrmLichSuLuotGui`, `FrmBaoCaoDoanhThu`, `FrmThongKeLuotXe` |

**Hàm dùng chung do Người 1 cung cấp:**
- `Database.LayBang / ThucThi / LayGiaTri(sql, Database.Tham("@x", giaTri))` – luôn dùng tham số, không nối chuỗi SQL.
- `Database.LayBangProc / ThucThiProc` – gọi stored procedure.
- `Database.ChayTrongTransaction((cn, tr) => { ... })` – transaction, tự rollback khi có exception (dùng cho xe ra + thanh toán, đăng ký vé tháng).
- `BangGiaBLL.LayHieuLucTheoLoai(maLoaiXe)` – bảng giá đang áp dụng (Người 2 dùng để tính phí).
- `TheXeBLL.LayTheoMa(maThe)`, `TheXeDAL.CapNhatTrangThai(cn, tr, maThe, trangThai)` và hằng số `TrangThaiThe` – xe vào đặt `DangDung`, xe ra đặt `SanSang`.
- `PhienDangNhap.TenDangNhap` – tên nhân viên đang đăng nhập, điền vào `NhanVienVao` / `NhanVienRa`.
- `FrmDanhMucBase` – mẫu form danh mục (Thêm/Sửa/Xóa/Lưu/Hủy/Làm mới + DataGridView + ErrorProvider). Người 3 làm `FrmKhachHang` bằng cách kế thừa lớp này, xem `FrmLoaiXe.cs` làm mẫu.
- `KetQua` – kiểu trả về của BLL cho GUI (`ThanhCong`, `ThongBao`).

**Git:**
- Chỉ **Người 1** sửa `Database.cs`, `FrmMain.cs`, `Database.sql`. Người khác cần gì thì báo hoặc tạo pull request.
- Mỗi người làm trên nhánh riêng (`nguoi1-danhmuc`, `nguoi2-guixe`, `nguoi3-vethang`, `nguoi4-baocao`), commit nhiều lần, đều đặn từ tuần 1, message rõ ràng, rồi tạo pull request vào `main`.
- Không commit thư mục `bin/`, `obj/`, `.vs/` (dùng `.gitignore` mẫu của Visual Studio).

## 7. Thành viên
| Người | Phụ trách |
|---|---|
| 1 (nhóm trưởng) | CSDL, Database.cs, đăng nhập/đổi mật khẩu/phân quyền, CRUD Loại xe – Thẻ xe – Bảng giá, FrmMain MDI |
| 2 | Xe vào, xe ra (master-detail), tính phí, transaction thanh toán |
| 3 | Khách hàng, vé tháng, số chỗ trống, test case, kịch bản demo |
| 4 | Tra cứu lịch sử, in vé/biên nhận, báo cáo doanh thu, biểu đồ GDI+, ảnh biển số, slide + PDF |
