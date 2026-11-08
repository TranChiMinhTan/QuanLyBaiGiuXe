-- =====================================================================
-- 02_Verify.sql : kiểm tra sau migration. CHỈ ĐỌC (SELECT). Mỗi dòng kết quả có cột KetQua = OK hoặc THIEU/LOI.
-- Mở SSMS, chọn đúng database (hoặc sửa USE), chạy, gửi lại kết quả.
-- =====================================================================
-- USE [QuanLyBaiGiuXe];
GO
SET NOCOUNT ON;

PRINT N'=== 1. Bảng và cột mà code đang dùng ===';
DECLARE @can TABLE (Bang SYSNAME, Cot SYSNAME);
INSERT INTO @can VALUES
 ('TaiKhoan','Id'),('TaiKhoan','TenDangNhap'),('TaiKhoan','MatKhauHash'),('TaiKhoan','Muoi'),('TaiKhoan','HoTen'),('TaiKhoan','VaiTro'),('TaiKhoan','HoatDong'),
 ('LoaiXe','MaLoaiXe'),('LoaiXe','TenLoai'),('LoaiXe','SucChua'),('LoaiXe','MoTa'),
 ('TheXe','MaThe'),('TheXe','MaLoaiXe'),('TheXe','TrangThai'),('TheXe','NgayCap'),
 ('BangGia','MaBangGia'),('BangGia','MaLoaiXe'),('BangGia','MienPhiPhut'),('BangGia','GiaGioDau'),('BangGia','GiaGioTiepTheo'),('BangGia','GiaToiDaNgay'),('BangGia','GiaVeThang'),
 ('KhachHang','MaKH'),('KhachHang','HoTen'),('KhachHang','SDT'),('KhachHang','CCCD'),('KhachHang','DiaChi'),
 ('VeThang','MaVe'),('VeThang','BienSo'),('VeThang','MaKH'),('VeThang','MaLoaiXe'),('VeThang','NgayDangKy'),('VeThang','NgayHetHan'),('VeThang','PhiDangKy'),('VeThang','TrangThai'),
 ('LuotGui','MaLuot'),('LuotGui','BienSo'),('LuotGui','MaThe'),('LuotGui','MaLoaiXe'),('LuotGui','GioVao'),('LuotGui','GioRa'),('LuotGui','Phi'),('LuotGui','DuongDanAnh'),
 ('ThanhToan','MaThanhToan'),('ThanhToan','MaLuot'),('ThanhToan','SoTien'),('ThanhToan','ThoiDiem'),
 ('ThanhToanVeThang','MaThanhToan'),('ThanhToanVeThang','MaVe'),('ThanhToanVeThang','SoTien'),('ThanhToanVeThang','Loai'),('ThanhToanVeThang','ThoiDiem'),
 ('NhatKy','MaNhatKy'),('NhatKy','ThoiDiem'),('NhatKy','TenDangNhap'),('NhatKy','HanhDong'),('NhatKy','ChiTiet');
SELECT c.Bang, c.Cot,
       CASE WHEN OBJECT_ID(N'dbo.' + c.Bang, N'U') IS NULL THEN N'THIEU BANG'
            WHEN COL_LENGTH(N'dbo.' + c.Bang, c.Cot) IS NULL THEN N'THIEU COT' ELSE N'OK' END AS KetQua
FROM @can c ORDER BY CASE WHEN OBJECT_ID(N'dbo.' + c.Bang, N'U') IS NULL OR COL_LENGTH(N'dbo.' + c.Bang, c.Cot) IS NULL THEN 0 ELSE 1 END, c.Bang, c.Cot;

PRINT N'=== 2. Stored procedure ===';
SELECT n.Ten, CASE WHEN OBJECT_ID(N'dbo.' + n.Ten, N'P') IS NULL THEN N'THIEU' ELSE N'OK' END AS KetQua
FROM (VALUES ('sp_SoChoTrong'), ('sp_BaoCaoDoanhThu')) n(Ten);

PRINT N'=== 3. Ràng buộc trạng thái thẻ phải cho phép đủ 4 giá trị ===';
SELECT cc.name AS RangBuoc, cc.definition AS DinhNghia,
       CASE WHEN cc.definition LIKE N'%Đang trống%' AND cc.definition LIKE N'%Đang dùng%'
             AND cc.definition LIKE N'%Khóa%' AND cc.definition LIKE N'%Đã mất%' THEN N'OK' ELSE N'LOI' END AS KetQua
FROM sys.check_constraints cc WHERE cc.parent_object_id = OBJECT_ID(N'dbo.TheXe') AND cc.definition LIKE N'%TrangThai%';

PRINT N'=== 4. Dữ liệu bất thường (phải là 0 dòng) ===';
IF OBJECT_ID(N'dbo.TheXe', N'U') IS NOT NULL
    SELECT N'Thẻ có trạng thái ngoài 4 giá trị' AS Kiem, COUNT(*) AS SoDong FROM dbo.TheXe
    WHERE TrangThai NOT IN (N'Đang trống', N'Đang dùng', N'Khóa', N'Đã mất');
IF OBJECT_ID(N'dbo.TheXe', N'U') IS NOT NULL AND OBJECT_ID(N'dbo.LuotGui', N'U') IS NOT NULL
    SELECT N'Thẻ "Đang dùng" nhưng không có lượt gửi đang mở' AS Kiem, COUNT(*) AS SoDong FROM dbo.TheXe t
    WHERE t.TrangThai = N'Đang dùng' AND NOT EXISTS (SELECT 1 FROM dbo.LuotGui l WHERE l.MaThe = t.MaThe AND l.GioRa IS NULL);
IF OBJECT_ID(N'dbo.LuotGui', N'U') IS NOT NULL AND OBJECT_ID(N'dbo.TheXe', N'U') IS NOT NULL
    SELECT N'Lượt gửi đang mở nhưng thẻ không "Đang dùng"' AS Kiem, COUNT(*) AS SoDong FROM dbo.LuotGui l
    JOIN dbo.TheXe t ON t.MaThe = l.MaThe WHERE l.GioRa IS NULL AND t.TrangThai <> N'Đang dùng';
IF OBJECT_ID(N'dbo.LuotGui', N'U') IS NOT NULL AND OBJECT_ID(N'dbo.ThanhToan', N'U') IS NOT NULL
    SELECT N'Lượt gửi đã ra nhưng chưa có thanh toán' AS Kiem, COUNT(*) AS SoDong FROM dbo.LuotGui l
    WHERE l.GioRa IS NOT NULL AND NOT EXISTS (SELECT 1 FROM dbo.ThanhToan t WHERE t.MaLuot = l.MaLuot);
IF OBJECT_ID(N'dbo.LoaiXe', N'U') IS NOT NULL AND OBJECT_ID(N'dbo.BangGia', N'U') IS NOT NULL
    SELECT N'Loại xe chưa có bảng giá (sẽ không tính được phí)' AS Kiem, COUNT(*) AS SoDong FROM dbo.LoaiXe lx
    WHERE NOT EXISTS (SELECT 1 FROM dbo.BangGia b WHERE b.MaLoaiXe = lx.MaLoaiXe);

PRINT N'=== 5. Chạy thử hai stored procedure (chỉ đọc) ===';
IF OBJECT_ID(N'dbo.sp_SoChoTrong', N'P') IS NOT NULL EXEC dbo.sp_SoChoTrong;
IF OBJECT_ID(N'dbo.sp_BaoCaoDoanhThu', N'P') IS NOT NULL EXEC dbo.sp_BaoCaoDoanhThu @TuNgay = '2000-01-01', @DenNgay = '2099-12-31', @TheoThang = 1;

PRINT N'=== 6. Số dòng từng bảng ===';
SELECT t.name AS Bang, SUM(p.rows) AS SoDong FROM sys.tables t
JOIN sys.partitions p ON p.object_id = t.object_id AND p.index_id IN (0, 1) GROUP BY t.name ORDER BY t.name;
GO
