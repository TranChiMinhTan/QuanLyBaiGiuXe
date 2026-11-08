/* =====================================================================
   Database.sql - QuanLyBaiGiuXe (bản đã đồng bộ với code C#)
   CẢNH BÁO: script này XÓA database cũ rồi tạo lại => mất hết dữ liệu.
   Đóng ứng dụng C# trước khi chạy. Mở trong tab New Query MỚI rồi bấm Execute 1 lần.
   ===================================================================== */
USE master;
GO

IF DB_ID(N'QuanLyBaiGiuXe') IS NOT NULL
BEGIN
    ALTER DATABASE QuanLyBaiGiuXe SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE QuanLyBaiGiuXe;
END
GO

CREATE DATABASE QuanLyBaiGiuXe;
GO
USE QuanLyBaiGiuXe;
GO

/* ---------- 1. Tạo bảng ---------- */
CREATE TABLE dbo.TaiKhoan (
    Id          INT IDENTITY(1,1) PRIMARY KEY,
    TenDangNhap VARCHAR(30)   NOT NULL CONSTRAINT UQ_TaiKhoan_TenDangNhap UNIQUE,
    Muoi        VARCHAR(100)  NULL,
    MatKhauHash CHAR(64)      NOT NULL,
    HoTen       NVARCHAR(100) NOT NULL,
    VaiTro      VARCHAR(20)   NOT NULL
                CONSTRAINT CK_TaiKhoan_VaiTro CHECK (VaiTro IN ('QuanLy', 'NhanVien')),
    HoatDong    BIT           NOT NULL CONSTRAINT DF_TaiKhoan_HoatDong DEFAULT 1
);
GO

CREATE TABLE dbo.LoaiXe (
    MaLoaiXe  INT IDENTITY(1,1) PRIMARY KEY,
    TenLoai   NVARCHAR(50)  NOT NULL CONSTRAINT UQ_LoaiXe_Ten UNIQUE,
    MoTa      NVARCHAR(200) NULL,
    SucChua   INT           NOT NULL CONSTRAINT DF_LoaiXe_SucChua DEFAULT 0
              CONSTRAINT CK_LoaiXe_SucChua CHECK (SucChua >= 0)
);
GO

-- TrangThai: 'Sẵn sàng' (trống), 'Đang dùng' (có xe), 'Đã mất', 'Khóa'
CREATE TABLE dbo.TheXe (
    MaThe     VARCHAR(20)  NOT NULL PRIMARY KEY,
    MaLoaiXe  INT          NOT NULL
              CONSTRAINT FK_TheXe_LoaiXe REFERENCES dbo.LoaiXe(MaLoaiXe),
    NgayCap   DATE         NOT NULL CONSTRAINT DF_TheXe_NgayCap DEFAULT GETDATE(),
    TrangThai NVARCHAR(20) NOT NULL CONSTRAINT DF_TheXe_TrangThai DEFAULT N'Sẵn sàng'
              CONSTRAINT CK_TheXe_TrangThai CHECK (TrangThai IN (N'Sẵn sàng', N'Đang dùng', N'Đã mất', N'Khóa'))
);
GO

CREATE TABLE dbo.BangGia (
    MaBangGia       INT IDENTITY(1,1) PRIMARY KEY,
    MaLoaiXe        INT NOT NULL
                    CONSTRAINT FK_BangGia_LoaiXe REFERENCES dbo.LoaiXe(MaLoaiXe),
    MienPhiPhut     INT NOT NULL CONSTRAINT DF_BangGia_MienPhi DEFAULT 0,
    GiaKhoi         DECIMAL(18,0) NOT NULL CONSTRAINT CK_BangGia_GiaKhoi CHECK (GiaKhoi >= 0),
    SoGioKhoi       INT NOT NULL CONSTRAINT DF_BangGia_SoGioKhoi DEFAULT 1,
    GiaGioTiepTheo  DECIMAL(18,0) NOT NULL CONSTRAINT CK_BangGia_TiepTheo CHECK (GiaGioTiepTheo >= 0),
    GiaToiDaNgay    DECIMAL(18,0) NOT NULL CONSTRAINT CK_BangGia_ToiDa CHECK (GiaToiDaNgay >= 0),
    PhuThuQuaDem    DECIMAL(18,0) NOT NULL CONSTRAINT CK_BangGia_QuaDem CHECK (PhuThuQuaDem >= 0),
    GiaVeThang      DECIMAL(18,0) NOT NULL CONSTRAINT CK_BangGia_VeThang CHECK (GiaVeThang >= 0),
    NgayApDung      DATE NOT NULL CONSTRAINT DF_BangGia_Ngay DEFAULT (CONVERT(DATE, GETDATE())),
    ConHieuLuc      BIT  NOT NULL CONSTRAINT DF_BangGia_HieuLuc DEFAULT 1
);
GO

-- MaKH là CHUỖI dạng KH001 (code C# KhachHangDAL.SinhMaMoi cắt chuỗi này)
CREATE TABLE dbo.KhachHang (
    MaKH    VARCHAR(10)   NOT NULL PRIMARY KEY,
    HoTen   NVARCHAR(100) NOT NULL,
    SDT     VARCHAR(15)   NULL,
    CCCD    VARCHAR(20)   NULL,
    BienSo  VARCHAR(15)   NULL,
    DiaChi  NVARCHAR(200) NULL
);
GO

-- TrangThai mặc định 'Hoạt động' (code C# lọc theo chữ này)
CREATE TABLE dbo.VeThang (
    MaVe        INT IDENTITY(1,1) PRIMARY KEY,
    MaKH        VARCHAR(10) NOT NULL CONSTRAINT FK_VeThang_KH REFERENCES dbo.KhachHang(MaKH),
    MaLoaiXe    INT NOT NULL CONSTRAINT FK_VeThang_LoaiXe REFERENCES dbo.LoaiXe(MaLoaiXe),
    BienSo      VARCHAR(15) NOT NULL,
    NgayCap     DATE NOT NULL CONSTRAINT DF_VeThang_NgayCap DEFAULT GETDATE(),
    NgayDangKy  DATE NOT NULL,
    NgayHetHan  DATE NOT NULL,
    PhiDangKy   DECIMAL(18,0) NOT NULL CONSTRAINT DF_VeThang_Phi DEFAULT 0,
    TrangThai   NVARCHAR(20) NOT NULL CONSTRAINT DF_VeThang_TT DEFAULT N'Hoạt động',
    CONSTRAINT CK_VeThang_Ngay CHECK (NgayHetHan >= NgayDangKy)
);
GO

-- TrangThai của LuotGui là cột TÍNH TOÁN: GioRa NULL = 'Đang gửi', ngược lại 'Đã ra'.
-- (Code C# khi xe ra chỉ cập nhật GioRa/Phi, không cập nhật TrangThai, nên để DB tự suy ra.)
CREATE TABLE dbo.LuotGui (
    MaLuot       INT IDENTITY(1,1) PRIMARY KEY,
    MaThe        VARCHAR(20) NOT NULL CONSTRAINT FK_LuotGui_The REFERENCES dbo.TheXe(MaThe),
    MaLoaiXe     INT NULL CONSTRAINT FK_LuotGui_LoaiXe REFERENCES dbo.LoaiXe(MaLoaiXe),
    BienSo       VARCHAR(15) NOT NULL,
    DuongDanAnh  NVARCHAR(260) NULL,
    GioVao       DATETIME NOT NULL CONSTRAINT DF_LuotGui_Vao DEFAULT GETDATE(),
    GioRa        DATETIME NULL,
    Phi          DECIMAL(18,0) NULL,
    MaVe         INT NULL CONSTRAINT FK_LuotGui_Ve REFERENCES dbo.VeThang(MaVe),
    NhanVienVao  VARCHAR(30) NULL CONSTRAINT FK_LuotGui_NVVao REFERENCES dbo.TaiKhoan(TenDangNhap),
    NhanVienRa   VARCHAR(30) NULL CONSTRAINT FK_LuotGui_NVRa  REFERENCES dbo.TaiKhoan(TenDangNhap),
    TrangThai    AS (CASE WHEN GioRa IS NULL THEN N'Đang gửi' ELSE N'Đã ra' END),
    CONSTRAINT CK_LuotGui_Gio CHECK (GioRa IS NULL OR GioRa >= GioVao)
);
GO
-- Mỗi thẻ chỉ có tối đa 1 lượt chưa ra
CREATE UNIQUE INDEX UX_LuotGui_TheDangGui ON dbo.LuotGui(MaThe) WHERE GioRa IS NULL;
GO

-- Bảng ghi thanh toán lượt gửi (LuotGuiDAL.XeRa ghi vào đây)
CREATE TABLE dbo.ThanhToan (
    MaThanhToan INT IDENTITY(1,1) PRIMARY KEY,
    MaLuot      INT NOT NULL CONSTRAINT FK_ThanhToan_LuotGui REFERENCES dbo.LuotGui(MaLuot),
    SoTien      DECIMAL(18,0) NOT NULL,
    ThoiDiem    DATETIME NOT NULL
);
GO

-- Bảng thanh toán vé tháng (ThongKeDAL.DoanhThuVeThang đọc từ đây)
CREATE TABLE dbo.ThanhToanVeThang (
    MaThanhToan INT IDENTITY(1,1) PRIMARY KEY,
    MaVe        INT NULL,
    SoTien      DECIMAL(18,0) NOT NULL,
    Loai        NVARCHAR(30) NULL,   -- 'Đăng ký' hoặc 'Gia hạn' (VeThangDAL ghi cột này)
    ThoiDiem    DATETIME NOT NULL CONSTRAINT DF_TTVT_ThoiDiem DEFAULT GETDATE()
);
GO

/* ---------- 2. Dữ liệu mẫu ---------- */
INSERT INTO dbo.TaiKhoan (TenDangNhap, Muoi, MatKhauHash, HoTen, VaiTro, HoatDong) VALUES
('admin', '', CONVERT(CHAR(64), HASHBYTES('SHA2_256', '123456'), 2), N'Quản lý bãi xe',   'QuanLy',   1),
('nv01',  '', CONVERT(CHAR(64), HASHBYTES('SHA2_256', '123456'), 2), N'Nhân viên trực 01', 'NhanVien', 1);
GO

INSERT INTO dbo.LoaiXe (TenLoai, MoTa, SucChua) VALUES
(N'Xe máy', N'Xe máy, xe tay ga',   100),
(N'Ô tô',   N'Ô tô dưới 9 chỗ',      30),
(N'Xe đạp', N'Xe đạp, xe đạp điện',  50);
GO

INSERT INTO dbo.BangGia (MaLoaiXe, MienPhiPhut, GiaKhoi, SoGioKhoi, GiaGioTiepTheo, GiaToiDaNgay, PhuThuQuaDem, GiaVeThang)
SELECT MaLoaiXe, 0, 3000, 1, 2000, 15000, 5000, 120000 FROM dbo.LoaiXe WHERE TenLoai = N'Xe máy';
INSERT INTO dbo.BangGia (MaLoaiXe, MienPhiPhut, GiaKhoi, SoGioKhoi, GiaGioTiepTheo, GiaToiDaNgay, PhuThuQuaDem, GiaVeThang)
SELECT MaLoaiXe, 0, 20000, 1, 10000, 100000, 20000, 1500000 FROM dbo.LoaiXe WHERE TenLoai = N'Ô tô';
INSERT INTO dbo.BangGia (MaLoaiXe, MienPhiPhut, GiaKhoi, SoGioKhoi, GiaGioTiepTheo, GiaToiDaNgay, PhuThuQuaDem, GiaVeThang)
SELECT MaLoaiXe, 0, 1000, 1, 1000, 5000, 2000, 40000 FROM dbo.LoaiXe WHERE TenLoai = N'Xe đạp';
GO

-- 20 thẻ: XM001-010, OT001-005, XD001-005 (TrangThai mặc định 'Sẵn sàng')
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
GO

/* ---------- 3. Stored procedures ---------- */
-- Tham số: @TuNgay, @DenNgay, @TheoThang
-- (trong ThongKeDAL.cs phải truyền đúng tên: P("@TuNgay", ...), P("@DenNgay", ...), P("@TheoThang", ...))
-- Chỉ tính các lượt ĐÃ RA (GioRa IS NOT NULL), tính theo ngày ra.
-- Nhận cả hai kiểu tên tham số (@Tu/@Den hoặc @TuNgay/@DenNgay) nên code C# viết kiểu nào cũng chạy.
CREATE PROCEDURE dbo.sp_DoanhThu
    @Tu        DATE = NULL,
    @Den       DATE = NULL,
    @TuNgay    DATE = NULL,
    @DenNgay   DATE = NULL,
    @TheoThang BIT  = 0
AS
BEGIN
    SET NOCOUNT ON;
    SET @TuNgay  = COALESCE(@TuNgay,  @Tu,  DATEADD(DAY, -7, CAST(GETDATE() AS DATE)));
    SET @DenNgay = COALESCE(@DenNgay, @Den, CAST(GETDATE() AS DATE));

    IF @TheoThang = 1
        SELECT
            RIGHT('0' + CAST(MONTH(GioRa) AS VARCHAR(2)), 2) + '/' + CAST(YEAR(GioRa) AS VARCHAR(4)) AS Nhan,
            COUNT(*)                 AS SoLuot,
            SUM(ISNULL(Phi, 0))      AS DoanhThu
        FROM dbo.LuotGui
        WHERE GioRa IS NOT NULL
          AND CAST(GioRa AS DATE) BETWEEN @TuNgay AND @DenNgay
        GROUP BY YEAR(GioRa), MONTH(GioRa)
        ORDER BY YEAR(GioRa), MONTH(GioRa);
    ELSE
        SELECT
            CONVERT(VARCHAR(10), CAST(GioRa AS DATE), 103) AS Nhan,
            COUNT(*)                 AS SoLuot,
            SUM(ISNULL(Phi, 0))      AS DoanhThu
        FROM dbo.LuotGui
        WHERE GioRa IS NOT NULL
          AND CAST(GioRa AS DATE) BETWEEN @TuNgay AND @DenNgay
        GROUP BY CAST(GioRa AS DATE)
        ORDER BY CAST(GioRa AS DATE);
END
GO

CREATE PROCEDURE dbo.sp_SoChoTrong
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        lx.MaLoaiXe,
        lx.TenLoai,
        lx.SucChua,
        (SELECT COUNT(*) FROM dbo.LuotGui lg WHERE lg.MaLoaiXe = lx.MaLoaiXe AND lg.GioRa IS NULL) AS DangGui
    FROM dbo.LoaiXe lx;
END
GO

PRINT N'Tạo database QuanLyBaiGiuXe thành công.';
GO