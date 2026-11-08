-- =====================================================================
-- 00_Inspect.sql : CHỈ ĐỌC (chỉ có SELECT). Không thay đổi bất kỳ dữ liệu hay cấu trúc nào.
-- Cách dùng: mở SSMS, chọn đúng database của dự án trong ô "Available Databases" (hoặc sửa dòng USE bên dưới),
--            chạy cả file, rồi gửi lại toàn bộ kết quả (các tab Results) cho nhóm trưởng / Claude.
-- =====================================================================
-- USE [QuanLyBaiGiuXe];   -- bỏ dấu -- và sửa tên nếu cần
GO
SET NOCOUNT ON;

PRINT N'=== 1. Database đang chọn và phiên bản SQL Server ===';
SELECT DB_NAME() AS DatabaseDangChon, @@SERVERNAME AS Server, CAST(SERVERPROPERTY('ProductVersion') AS NVARCHAR(50)) AS PhienBan,
       CAST(SERVERPROPERTY('Edition') AS NVARCHAR(100)) AS Edition;

PRINT N'=== 2. Danh sách database trên instance ===';
SELECT name AS TenDatabase, create_date FROM sys.databases ORDER BY name;

PRINT N'=== 3. Bảng, số dòng ===';
SELECT s.name AS [Schema], t.name AS Bang, SUM(p.rows) AS SoDong
FROM sys.tables t JOIN sys.schemas s ON s.schema_id = t.schema_id
JOIN sys.partitions p ON p.object_id = t.object_id AND p.index_id IN (0, 1)
GROUP BY s.name, t.name ORDER BY t.name;

PRINT N'=== 4. Cột của từng bảng ===';
SELECT t.name AS Bang, c.column_id AS Stt, c.name AS Cot, ty.name AS KieuDuLieu, c.max_length AS DoDai,
       c.precision AS [Precision], c.scale AS Scale, c.is_nullable AS ChoPhepNull, c.is_identity AS IsIdentity
FROM sys.tables t JOIN sys.columns c ON c.object_id = t.object_id
JOIN sys.types ty ON ty.user_type_id = c.user_type_id
ORDER BY t.name, c.column_id;

PRINT N'=== 5. Khóa chính / khóa ngoại / unique ===';
SELECT OBJECT_NAME(parent_object_id) AS Bang, name AS RangBuoc, type_desc AS Loai FROM sys.key_constraints
UNION ALL
SELECT OBJECT_NAME(parent_object_id), name, N'FOREIGN_KEY -> ' + OBJECT_NAME(referenced_object_id) FROM sys.foreign_keys
ORDER BY 1, 2;

PRINT N'=== 6. Ràng buộc CHECK (cần xem để biết các giá trị trạng thái đang cho phép) ===';
SELECT OBJECT_NAME(parent_object_id) AS Bang, name AS RangBuoc, definition AS DinhNghia FROM sys.check_constraints ORDER BY 1, 2;

PRINT N'=== 7. Stored procedure / function ===';
SELECT name AS TenDoiTuong, type_desc AS Loai, modify_date FROM sys.objects WHERE type IN ('P', 'FN', 'IF', 'TF', 'V') AND is_ms_shipped = 0 ORDER BY name;

PRINT N'=== 8. Các giá trị trạng thái thực tế đang có (chỉ chạy nếu bảng tồn tại) ===';
IF OBJECT_ID(N'dbo.TheXe', N'U') IS NOT NULL EXEC(N'SELECT N''TheXe.TrangThai'' AS Nguon, TrangThai, COUNT(*) AS SoDong FROM dbo.TheXe GROUP BY TrangThai');
IF OBJECT_ID(N'dbo.VeThang', N'U') IS NOT NULL EXEC(N'SELECT N''VeThang.TrangThai'' AS Nguon, TrangThai, COUNT(*) AS SoDong FROM dbo.VeThang GROUP BY TrangThai');
GO
