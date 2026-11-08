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
`-- Scripts   (Database.sql)
```