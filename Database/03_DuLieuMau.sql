-- =====================================================================
-- 03_DuLieuMau.sql : TÙY CHỌN. Dữ liệu khởi tạo cho database MỚI để đăng nhập và chạy thử được.
-- Chỉ INSERT khi bảng đang TRỐNG; không đụng dữ liệu đã có. Đổi mật khẩu ngay sau lần đăng nhập đầu tiên.
-- Tài khoản mẫu: admin / 123456 (Quản lý), nv01 / 123456 (Nhân viên).
-- Mật khẩu lưu SHA-256 không muối (Muoi = NULL); ứng dụng tự nâng cấp lên PBKDF2 khi đăng nhập thành công.
-- Giá tiền mẫu theo bảng ví dụ trong docs/MO_HINH_TINH_PHI.md; hãy sửa theo giá thực tế qua màn Bảng giá.
-- =====================================================================
-- USE [QuanLyBaiGiuXe];
GO
SET NOCOUNT ON;

IF NOT EXISTS (SELECT 1 FROM dbo.TaiKhoan)
    INSERT INTO dbo.TaiKhoan (TenDangNhap, MatKhauHash, Muoi, HoTen, VaiTro) VALUES
    ('admin', CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', '123456'), 2), NULL, N'Quản lý bãi xe',   'QuanLy'),
    ('nv01',  CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', '123456'), 2), NULL, N'Nhân viên trực 01', 'NhanVien');
GO
IF NOT EXISTS (SELECT 1 FROM dbo.LoaiXe)
    INSERT INTO dbo.LoaiXe (TenLoai, SucChua, MoTa) VALUES
    (N'Xe máy', 100, N'Xe máy, xe tay ga'),
    (N'Ô tô',    30, N'Ô tô dưới 9 chỗ'),
    (N'Xe đạp',  50, N'Xe đạp, xe đạp điện');
GO
IF NOT EXISTS (SELECT 1 FROM dbo.BangGia)
    INSERT INTO dbo.BangGia (MaLoaiXe, MienPhiPhut, GiaGioDau, GiaGioTiepTheo, GiaToiDaNgay, GiaVeThang)
    SELECT MaLoaiXe, 15,  3000,  2000,  15000,  120000 FROM dbo.LoaiXe WHERE TenLoai = N'Xe máy' UNION ALL
    SELECT MaLoaiXe, 15, 20000, 10000, 100000, 1500000 FROM dbo.LoaiXe WHERE TenLoai = N'Ô tô'   UNION ALL
    SELECT MaLoaiXe, 15,  1000,  1000,   5000,   40000 FROM dbo.LoaiXe WHERE TenLoai = N'Xe đạp';
GO
IF NOT EXISTS (SELECT 1 FROM dbo.TheXe)
BEGIN
    DECLARE @xm INT = (SELECT MaLoaiXe FROM dbo.LoaiXe WHERE TenLoai = N'Xe máy');
    DECLARE @ot INT = (SELECT MaLoaiXe FROM dbo.LoaiXe WHERE TenLoai = N'Ô tô');
    DECLARE @xd INT = (SELECT MaLoaiXe FROM dbo.LoaiXe WHERE TenLoai = N'Xe đạp');
    DECLARE @i INT = 1;
    WHILE @i <= 10
    BEGIN
        INSERT INTO dbo.TheXe (MaThe, MaLoaiXe) VALUES ('XM' + RIGHT('000' + CAST(@i AS VARCHAR(3)), 3), @xm);
        IF @i <= 5
        BEGIN
            INSERT INTO dbo.TheXe (MaThe, MaLoaiXe) VALUES ('OT' + RIGHT('000' + CAST(@i AS VARCHAR(3)), 3), @ot);
            INSERT INTO dbo.TheXe (MaThe, MaLoaiXe) VALUES ('XD' + RIGHT('000' + CAST(@i AS VARCHAR(3)), 3), @xd);
        END
        SET @i += 1;
    END
END
GO
