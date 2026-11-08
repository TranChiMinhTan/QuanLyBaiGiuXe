-- =====================================================================
-- 01_Migration.sql : tạo / bổ sung cấu trúc CSDL cho dự án Quản lý Bãi Giữ Xe (MVP).
--
-- AN TOÀN DỮ LIỆU
--   * KHÔNG có DROP DATABASE / DROP TABLE / TRUNCATE / DELETE / UPDATE trên dữ liệu của dự án
--     (chỉ dùng một bảng tạm #MigrationStop của phiên làm việc để đánh dấu lỗi tương thích).
--   * Chạy lại nhiều lần được (idempotent): chỉ tạo đối tượng CHƯA có, chỉ thêm cột còn thiếu.
--   * Nếu một bảng ĐÃ TỒN TẠI nhưng khác cấu trúc mà code đang dùng (ví dụ CSDL cũ "QuanLyBaiXe" của Dự án B),
--     script DỪNG LẠI ở bước 1 và liệt kê điểm khác biệt, KHÔNG tự sửa / chuyển đổi dữ liệu cũ.
--     Việc chuyển dữ liệu cũ cần một phương án riêng được nhóm trưởng xác nhận.
--
-- CÁCH DÙNG (theo yêu cầu: thử trên BẢN SAO trước)
--   1. Với database mới: chạy nguyên file. Database QuanLyBaiGiuXe sẽ được tạo nếu chưa có.
--   2. Với database đã có dữ liệu: BACKUP trước, RESTORE thành bản sao (tên khác), đổi tên database ở 2 dòng
--      "USE [...]" và "CREATE DATABASE" bên dưới sang tên bản sao, chạy, rồi chạy 02_Verify.sql.
--   3. Chỉ áp dụng lên database thật sau khi bản sao đã qua kiểm tra và nhóm trưởng xác nhận.
-- Yêu cầu: SQL Server 2012 trở lên.
-- =====================================================================
SET NOCOUNT ON;
GO
-- ---------- 0. Tạo database nếu chưa có (không đụng database khác) ----------
IF DB_ID(N'QuanLyBaiGiuXe') IS NULL
    CREATE DATABASE [QuanLyBaiGiuXe];
GO
USE [QuanLyBaiGiuXe];
GO
SET NOEXEC OFF;
GO
-- Bảng tạm của phiên làm việc (không phải dữ liệu dự án): cờ báo bước 1 phát hiện cấu trúc không tương thích.
-- Hãy chạy file trong một cửa sổ truy vấn MỚI để cờ này luôn bắt đầu rỗng.
IF OBJECT_ID(N'tempdb..#MigrationStop') IS NULL CREATE TABLE #MigrationStop (Dummy INT);
GO

-- ---------- 1. Kiểm tra tương thích: bảng đã có nhưng thiếu cột mà code cần -> dừng ----------
DECLARE @loi TABLE (Bang SYSNAME, Cot SYSNAME);
DECLARE @can TABLE (Bang SYSNAME, Cot SYSNAME);
INSERT INTO @can (Bang, Cot) VALUES
 ('TaiKhoan','Id'),('TaiKhoan','TenDangNhap'),('TaiKhoan','MatKhauHash'),('TaiKhoan','Muoi'),('TaiKhoan','HoTen'),('TaiKhoan','VaiTro'),('TaiKhoan','HoatDong'),
 ('LoaiXe','MaLoaiXe'),('LoaiXe','TenLoai'),('LoaiXe','SucChua'),('LoaiXe','MoTa'),
 ('TheXe','MaThe'),('TheXe','MaLoaiXe'),('TheXe','TrangThai'),
 ('BangGia','MaBangGia'),('BangGia','MaLoaiXe'),('BangGia','MienPhiPhut'),('BangGia','GiaGioDau'),('BangGia','GiaGioTiepTheo'),('BangGia','GiaToiDaNgay'),('BangGia','GiaVeThang'),
 ('KhachHang','MaKH'),('KhachHang','HoTen'),('KhachHang','SDT'),('KhachHang','DiaChi'),
 ('VeThang','MaVe'),('VeThang','BienSo'),('VeThang','MaKH'),('VeThang','MaLoaiXe'),('VeThang','NgayDangKy'),('VeThang','NgayHetHan'),('VeThang','PhiDangKy'),('VeThang','TrangThai'),
 ('LuotGui','MaLuot'),('LuotGui','BienSo'),('LuotGui','MaThe'),('LuotGui','MaLoaiXe'),('LuotGui','GioVao'),('LuotGui','GioRa'),('LuotGui','Phi'),('LuotGui','DuongDanAnh'),
 ('ThanhToan','MaThanhToan'),('ThanhToan','MaLuot'),('ThanhToan','SoTien'),('ThanhToan','ThoiDiem'),
 ('ThanhToanVeThang','MaThanhToan'),('ThanhToanVeThang','MaVe'),('ThanhToanVeThang','SoTien'),('ThanhToanVeThang','Loai'),('ThanhToanVeThang','ThoiDiem'),
 ('NhatKy','MaNhatKy'),('NhatKy','ThoiDiem'),('NhatKy','TenDangNhap'),('NhatKy','HanhDong'),('NhatKy','ChiTiet');
-- NgayCap (TheXe) và CCCD (KhachHang) là cột chỉ-thêm: được bổ sung an toàn ở bước 3, nên không tính là lỗi.

INSERT INTO @loi (Bang, Cot)
SELECT c.Bang, c.Cot FROM @can c
WHERE OBJECT_ID(N'dbo.' + c.Bang, N'U') IS NOT NULL            -- bảng đã tồn tại
  AND COL_LENGTH(N'dbo.' + c.Bang, c.Cot) IS NULL;             -- nhưng thiếu cột

-- Ràng buộc trạng thái thẻ kiểu cũ (Sẵn sàng/Khóa) = CSDL của Dự án B
IF OBJECT_ID(N'dbo.TheXe', N'U') IS NOT NULL
   AND EXISTS (SELECT 1 FROM sys.check_constraints cc WHERE cc.parent_object_id = OBJECT_ID(N'dbo.TheXe')
               AND cc.definition LIKE N'%Sẵn sàng%')
    INSERT INTO @loi VALUES ('TheXe', N'CHECK trạng thái kiểu cũ (Sẵn sàng/Khóa)');

IF EXISTS (SELECT 1 FROM @loi)
BEGIN
    SELECT N'CSDL hiện có KHÁC cấu trúc mà code đang dùng. Script dừng, không thay đổi gì.' AS ThongBao;
    SELECT Bang, Cot AS ThieuHoacKhac FROM @loi ORDER BY Bang, Cot;
    INSERT INTO #MigrationStop (Dummy) VALUES (1);
    RAISERROR (N'01_Migration dừng ở bước 1: cấu trúc hiện có không tương thích (xem danh sách vừa hiển thị).', 16, 1);
END
GO
IF EXISTS (SELECT 1 FROM #MigrationStop) SET NOEXEC ON;
GO
-- (nếu bước 1 phát hiện lỗi, mọi lệnh phía dưới bị bỏ qua cho tới SET NOEXEC OFF ở cuối file)

-- ---------- 2. Tạo bảng còn thiếu ----------
IF OBJECT_ID(N'dbo.TaiKhoan', N'U') IS NULL
CREATE TABLE dbo.TaiKhoan (
    Id          INT IDENTITY(1,1) CONSTRAINT PK_TaiKhoan PRIMARY KEY,
    TenDangNhap VARCHAR(30)   NOT NULL CONSTRAINT UQ_TaiKhoan_Ten UNIQUE,
    MatKhauHash VARCHAR(128)  NOT NULL,                    -- PBKDF2-SHA256 (hex) hoặc SHA-256 cũ không muối (64 hex)
    Muoi        VARCHAR(64)   NULL,                        -- NULL/rỗng = hash cũ không muối, ứng dụng tự nâng cấp khi đăng nhập
    HoTen       NVARCHAR(100) NOT NULL,
    VaiTro      VARCHAR(20)   NOT NULL CONSTRAINT CK_TaiKhoan_VaiTro CHECK (VaiTro IN ('QuanLy','NhanVien')),
    HoatDong    BIT           NOT NULL CONSTRAINT DF_TaiKhoan_HoatDong DEFAULT 1
);
GO
IF OBJECT_ID(N'dbo.LoaiXe', N'U') IS NULL
CREATE TABLE dbo.LoaiXe (
    MaLoaiXe INT IDENTITY(1,1) CONSTRAINT PK_LoaiXe PRIMARY KEY,
    TenLoai  NVARCHAR(50)  NOT NULL CONSTRAINT UQ_LoaiXe_Ten UNIQUE,
    SucChua  INT           NOT NULL CONSTRAINT DF_LoaiXe_SucChua DEFAULT 0 CONSTRAINT CK_LoaiXe_SucChua CHECK (SucChua >= 0),
    MoTa     NVARCHAR(200) NULL
);
GO
IF OBJECT_ID(N'dbo.TheXe', N'U') IS NULL
CREATE TABLE dbo.TheXe (
    MaThe     VARCHAR(20)  NOT NULL CONSTRAINT PK_TheXe PRIMARY KEY,
    MaLoaiXe  INT          NOT NULL CONSTRAINT FK_TheXe_LoaiXe REFERENCES dbo.LoaiXe(MaLoaiXe),
    TrangThai NVARCHAR(20) NOT NULL CONSTRAINT DF_TheXe_TrangThai DEFAULT N'Đang trống',
    NgayCap   DATE         NOT NULL CONSTRAINT DF_TheXe_NgayCap DEFAULT (CONVERT(DATE, GETDATE())),
    CONSTRAINT CK_TheXe_TrangThai CHECK (TrangThai IN (N'Đang trống', N'Đang dùng', N'Khóa', N'Đã mất'))
);
GO
IF OBJECT_ID(N'dbo.BangGia', N'U') IS NULL
CREATE TABLE dbo.BangGia (                                 -- mô hình B+: mỗi loại xe đúng một dòng
    MaBangGia      INT IDENTITY(1,1) CONSTRAINT PK_BangGia PRIMARY KEY,
    MaLoaiXe       INT NOT NULL CONSTRAINT UQ_BangGia_LoaiXe UNIQUE CONSTRAINT FK_BangGia_LoaiXe REFERENCES dbo.LoaiXe(MaLoaiXe),
    MienPhiPhut    INT NOT NULL CONSTRAINT DF_BangGia_MienPhi DEFAULT 15 CONSTRAINT CK_BangGia_MienPhi CHECK (MienPhiPhut >= 0),
    GiaGioDau      DECIMAL(18,0) NOT NULL CONSTRAINT CK_BangGia_GioDau   CHECK (GiaGioDau > 0),
    GiaGioTiepTheo DECIMAL(18,0) NOT NULL CONSTRAINT CK_BangGia_TiepTheo CHECK (GiaGioTiepTheo >= 0),
    GiaToiDaNgay   DECIMAL(18,0) NOT NULL CONSTRAINT CK_BangGia_ToiDa    CHECK (GiaToiDaNgay > 0),
    GiaVeThang     DECIMAL(18,0) NOT NULL CONSTRAINT CK_BangGia_VeThang  CHECK (GiaVeThang > 0),
    CONSTRAINT CK_BangGia_TranLonHonGioDau CHECK (GiaToiDaNgay >= GiaGioDau)
);
GO
IF OBJECT_ID(N'dbo.KhachHang', N'U') IS NULL
CREATE TABLE dbo.KhachHang (
    MaKH    VARCHAR(10)   NOT NULL CONSTRAINT PK_KhachHang PRIMARY KEY,   -- KH001, KH002, ...
    HoTen   NVARCHAR(100) NOT NULL,
    SDT     VARCHAR(15)   NOT NULL,
    CCCD    VARCHAR(12)   NULL,
    DiaChi  NVARCHAR(200) NULL
);
GO
IF OBJECT_ID(N'dbo.VeThang', N'U') IS NULL
CREATE TABLE dbo.VeThang (
    MaVe       INT IDENTITY(1,1) CONSTRAINT PK_VeThang PRIMARY KEY,
    BienSo     VARCHAR(15)  NOT NULL,
    MaKH       VARCHAR(10)  NOT NULL CONSTRAINT FK_VeThang_KH REFERENCES dbo.KhachHang(MaKH),
    MaLoaiXe   INT          NOT NULL CONSTRAINT FK_VeThang_LoaiXe REFERENCES dbo.LoaiXe(MaLoaiXe),
    NgayDangKy DATE         NOT NULL,
    NgayHetHan DATE         NOT NULL,
    PhiDangKy  DECIMAL(18,0) NOT NULL CONSTRAINT DF_VeThang_Phi DEFAULT 0,
    TrangThai  NVARCHAR(20) NOT NULL CONSTRAINT DF_VeThang_TT DEFAULT N'Hoạt động'
               CONSTRAINT CK_VeThang_TT CHECK (TrangThai IN (N'Hoạt động', N'Đã hủy')),
    CONSTRAINT CK_VeThang_Ngay CHECK (NgayHetHan >= NgayDangKy)
);
GO
IF OBJECT_ID(N'dbo.LuotGui', N'U') IS NULL
CREATE TABLE dbo.LuotGui (
    MaLuot      INT IDENTITY(1,1) CONSTRAINT PK_LuotGui PRIMARY KEY,
    BienSo      VARCHAR(15)  NOT NULL,
    MaThe       VARCHAR(20)  NOT NULL CONSTRAINT FK_LuotGui_The REFERENCES dbo.TheXe(MaThe),
    MaLoaiXe    INT          NOT NULL CONSTRAINT FK_LuotGui_LoaiXe REFERENCES dbo.LoaiXe(MaLoaiXe),
    GioVao      DATETIME     NOT NULL CONSTRAINT DF_LuotGui_Vao DEFAULT GETDATE(),
    GioRa       DATETIME     NULL,                          -- NULL = xe còn trong bãi
    Phi         DECIMAL(18,0) NULL,
    DuongDanAnh NVARCHAR(260) NULL,                         -- đường dẫn tương đối, ví dụ Images\BienSo\abc.jpg
    CONSTRAINT CK_LuotGui_Gio CHECK (GioRa IS NULL OR GioRa >= GioVao)
);
GO
IF OBJECT_ID(N'dbo.ThanhToan', N'U') IS NULL
CREATE TABLE dbo.ThanhToan (
    MaThanhToan INT IDENTITY(1,1) CONSTRAINT PK_ThanhToan PRIMARY KEY,
    MaLuot      INT NOT NULL CONSTRAINT UQ_ThanhToan_Luot UNIQUE CONSTRAINT FK_ThanhToan_Luot REFERENCES dbo.LuotGui(MaLuot),
    SoTien      DECIMAL(18,0) NOT NULL CONSTRAINT CK_ThanhToan_Tien CHECK (SoTien >= 0),
    ThoiDiem    DATETIME NOT NULL CONSTRAINT DF_ThanhToan_TD DEFAULT GETDATE()
);
GO
IF OBJECT_ID(N'dbo.ThanhToanVeThang', N'U') IS NULL
CREATE TABLE dbo.ThanhToanVeThang (
    MaThanhToan INT IDENTITY(1,1) CONSTRAINT PK_ThanhToanVeThang PRIMARY KEY,
    MaVe        INT NOT NULL CONSTRAINT FK_TTVT_Ve REFERENCES dbo.VeThang(MaVe),
    SoTien      DECIMAL(18,0) NOT NULL CONSTRAINT CK_TTVT_Tien CHECK (SoTien >= 0),
    Loai        NVARCHAR(20) NOT NULL CONSTRAINT CK_TTVT_Loai CHECK (Loai IN (N'Đăng ký', N'Gia hạn')),
    ThoiDiem    DATETIME NOT NULL CONSTRAINT DF_TTVT_TD DEFAULT GETDATE()
);
GO
IF OBJECT_ID(N'dbo.NhatKy', N'U') IS NULL
CREATE TABLE dbo.NhatKy (
    MaNhatKy    INT IDENTITY(1,1) CONSTRAINT PK_NhatKy PRIMARY KEY,
    ThoiDiem    DATETIME      NOT NULL CONSTRAINT DF_NhatKy_TD DEFAULT GETDATE(),
    TenDangNhap VARCHAR(30)   NULL,
    HanhDong    NVARCHAR(100) NOT NULL,
    ChiTiet     NVARCHAR(500) NULL
);
GO

-- ---------- 3. Bổ sung cột còn thiếu trên bảng đã có (chỉ THÊM, không sửa/xóa cột) ----------
IF OBJECT_ID(N'dbo.TheXe', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.TheXe', N'NgayCap') IS NULL
    ALTER TABLE dbo.TheXe ADD NgayCap DATE NOT NULL CONSTRAINT DF_TheXe_NgayCap DEFAULT (CONVERT(DATE, GETDATE()));
GO
IF OBJECT_ID(N'dbo.KhachHang', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.KhachHang', N'CCCD') IS NULL
    ALTER TABLE dbo.KhachHang ADD CCCD VARCHAR(12) NULL;
GO

-- ---------- 4. Chỉ mục ----------
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'UX_LuotGui_TheDangGui' AND object_id = OBJECT_ID(N'dbo.LuotGui'))
    CREATE UNIQUE INDEX UX_LuotGui_TheDangGui ON dbo.LuotGui(MaThe) WHERE GioRa IS NULL;        -- mỗi thẻ tối đa 1 lượt đang gửi
GO
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'UX_LuotGui_BienSoDangGui' AND object_id = OBJECT_ID(N'dbo.LuotGui'))
    CREATE UNIQUE INDEX UX_LuotGui_BienSoDangGui ON dbo.LuotGui(BienSo) WHERE GioRa IS NULL;    -- mỗi biển số tối đa 1 lượt đang gửi
GO
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'UX_KhachHang_CCCD' AND object_id = OBJECT_ID(N'dbo.KhachHang'))
    CREATE UNIQUE INDEX UX_KhachHang_CCCD ON dbo.KhachHang(CCCD) WHERE CCCD IS NOT NULL;
GO
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'IX_LuotGui_GioVao' AND object_id = OBJECT_ID(N'dbo.LuotGui'))
    CREATE INDEX IX_LuotGui_GioVao ON dbo.LuotGui(GioVao) INCLUDE (BienSo, MaLoaiXe, GioRa, Phi);
GO
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'IX_VeThang_BienSo' AND object_id = OBJECT_ID(N'dbo.VeThang'))
    CREATE INDEX IX_VeThang_BienSo ON dbo.VeThang(BienSo, TrangThai, NgayHetHan);
GO
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'IX_NhatKy_ThoiDiem' AND object_id = OBJECT_ID(N'dbo.NhatKy'))
    CREATE INDEX IX_NhatKy_ThoiDiem ON dbo.NhatKy(ThoiDiem DESC);
GO

-- ---------- 5. Stored procedure (tạo nếu chưa có, rồi ALTER: chạy được trên mọi phiên bản) ----------
IF OBJECT_ID(N'dbo.sp_SoChoTrong', N'P') IS NULL EXEC (N'CREATE PROCEDURE dbo.sp_SoChoTrong AS RETURN 0');
GO
ALTER PROCEDURE dbo.sp_SoChoTrong
AS
BEGIN
    SET NOCOUNT ON;
    SELECT lx.MaLoaiXe, lx.TenLoai, lx.SucChua,
           (SELECT COUNT(*) FROM dbo.LuotGui l WHERE l.MaLoaiXe = lx.MaLoaiXe AND l.GioRa IS NULL) AS DangGui
    FROM dbo.LoaiXe lx
    ORDER BY lx.MaLoaiXe;
END
GO

IF OBJECT_ID(N'dbo.sp_BaoCaoDoanhThu', N'P') IS NULL EXEC (N'CREATE PROCEDURE dbo.sp_BaoCaoDoanhThu AS RETURN 0');
GO
-- Doanh thu vé tháng lấy từ ThanhToanVeThang (cả ĐĂNG KÝ và GIA HẠN, tính vào ngày thu tiền).
-- Bản cũ chỉ cộng VeThang.PhiDangKy theo NgayDangKy nên BỎ SÓT tiền gia hạn.
ALTER PROCEDURE dbo.sp_BaoCaoDoanhThu
    @TuNgay    DATE,
    @DenNgay   DATE,
    @TheoThang BIT          -- 0 = theo ngày, 1 = theo tháng (cột Ky là mùng 1 của tháng)
AS
BEGIN
    SET NOCOUNT ON;

    ;WITH LuotGui_Ky AS (
        SELECT k.Ky, COUNT(*) AS SoLuot, SUM(t.SoTien) AS TienLuotGui
        FROM dbo.ThanhToan t
        CROSS APPLY (SELECT CASE WHEN @TheoThang = 1
                                 THEN DATEFROMPARTS(YEAR(t.ThoiDiem), MONTH(t.ThoiDiem), 1)
                                 ELSE CAST(t.ThoiDiem AS DATE) END AS Ky) k
        WHERE t.ThoiDiem >= @TuNgay AND t.ThoiDiem < DATEADD(DAY, 1, @DenNgay)
        GROUP BY k.Ky
    ),
    VeThang_Ky AS (
        SELECT k.Ky, SUM(v.SoTien) AS TienVeThang
        FROM dbo.ThanhToanVeThang v
        CROSS APPLY (SELECT CASE WHEN @TheoThang = 1
                                 THEN DATEFROMPARTS(YEAR(v.ThoiDiem), MONTH(v.ThoiDiem), 1)
                                 ELSE CAST(v.ThoiDiem AS DATE) END AS Ky) k
        WHERE v.ThoiDiem >= @TuNgay AND v.ThoiDiem < DATEADD(DAY, 1, @DenNgay)
        GROUP BY k.Ky
    )
    SELECT COALESCE(a.Ky, b.Ky)     AS Ky,
           ISNULL(a.SoLuot, 0)      AS SoLuot,
           ISNULL(a.TienLuotGui, 0) AS TienLuotGui,
           ISNULL(b.TienVeThang, 0) AS TienVeThang
    FROM LuotGui_Ky a
    FULL OUTER JOIN VeThang_Ky b ON a.Ky = b.Ky
    ORDER BY COALESCE(a.Ky, b.Ky);
END
GO

SET NOEXEC OFF;
GO
PRINT N'01_Migration hoàn tất (nếu không thấy thông báo dừng ở bước 1). Hãy chạy 02_Verify.sql để kiểm tra.';
GO
