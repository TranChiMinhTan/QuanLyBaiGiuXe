/* ============================================================
   QuanLyBaiXe - Database.sql  (SQL Server 2016 trở lên)
   Người 1 phụ trách: tạo CSDL, bảng, dữ liệu mẫu, tài khoản mẫu.
   Chạy toàn bộ file trong SSMS (có thể chạy lại nhiều lần).
   ============================================================ */
USE master;
GO
IF DB_ID(N'QuanLyBaiXe') IS NULL
    CREATE DATABASE QuanLyBaiXe;
GO
USE QuanLyBaiXe;
GO

/* ---------- 1. Xóa bảng cũ (theo thứ tự khóa ngoại) ---------- */
IF OBJECT_ID(N'dbo.LuotGui',   N'U') IS NOT NULL DROP TABLE dbo.LuotGui;
IF OBJECT_ID(N'dbo.VeThang',   N'U') IS NOT NULL DROP TABLE dbo.VeThang;
IF OBJECT_ID(N'dbo.KhachHang', N'U') IS NOT NULL DROP TABLE dbo.KhachHang;
IF OBJECT_ID(N'dbo.BangGia',   N'U') IS NOT NULL DROP TABLE dbo.BangGia;
IF OBJECT_ID(N'dbo.TheXe',     N'U') IS NOT NULL DROP TABLE dbo.TheXe;
IF OBJECT_ID(N'dbo.LoaiXe',    N'U') IS NOT NULL DROP TABLE dbo.LoaiXe;
IF OBJECT_ID(N'dbo.TaiKhoan',  N'U') IS NOT NULL DROP TABLE dbo.TaiKhoan;
GO

/* ---------- 2. Tạo bảng ---------- */

-- Tài khoản đăng nhập (mật khẩu lưu dạng SHA-256, 64 ký tự hex in hoa)
CREATE TABLE dbo.TaiKhoan (
    TenDangNhap VARCHAR(30)   NOT NULL PRIMARY KEY,
    MatKhauHash CHAR(64)      NOT NULL,
    HoTen       NVARCHAR(100) NOT NULL,
    VaiTro      VARCHAR(20)   NOT NULL
                CONSTRAINT CK_TaiKhoan_VaiTro CHECK (VaiTro IN ('QuanLy', 'NhanVien')),
    KichHoat    BIT           NOT NULL CONSTRAINT DF_TaiKhoan_KichHoat DEFAULT 1
);
GO

CREATE TABLE dbo.LoaiXe (
    MaLoaiXe  INT IDENTITY(1,1) PRIMARY KEY,
    TenLoaiXe NVARCHAR(50)  NOT NULL CONSTRAINT UQ_LoaiXe_Ten UNIQUE,
    MoTa      NVARCHAR(200) NULL,
    SucChua   INT           NOT NULL CONSTRAINT DF_LoaiXe_SucChua DEFAULT 0
              CONSTRAINT CK_LoaiXe_SucChua CHECK (SucChua >= 0)   -- dùng cho "số chỗ trống"
);
GO

CREATE TABLE dbo.TheXe (
    MaThe     VARCHAR(20) NOT NULL PRIMARY KEY,
    MaLoaiXe  INT         NOT NULL
              CONSTRAINT FK_TheXe_LoaiXe REFERENCES dbo.LoaiXe(MaLoaiXe),
    TrangThai NVARCHAR(20) NOT NULL CONSTRAINT DF_TheXe_TrangThai DEFAULT N'Sẵn sàng'
              CONSTRAINT CK_TheXe_TrangThai CHECK (TrangThai IN (N'Sẵn sàng', N'Đang dùng', N'Khóa'))
);
GO

CREATE TABLE dbo.BangGia (
    MaBangGia       INT IDENTITY(1,1) PRIMARY KEY,
    MaLoaiXe        INT NOT NULL
                    CONSTRAINT FK_BangGia_LoaiXe REFERENCES dbo.LoaiXe(MaLoaiXe),
    GiaGioDau       DECIMAL(18,0) NOT NULL CONSTRAINT CK_BangGia_GioDau  CHECK (GiaGioDau >= 0),
    GiaGioTiepTheo  DECIMAL(18,0) NOT NULL CONSTRAINT CK_BangGia_TiepTheo CHECK (GiaGioTiepTheo >= 0),
    GiaToiDaNgay    DECIMAL(18,0) NOT NULL CONSTRAINT CK_BangGia_ToiDa   CHECK (GiaToiDaNgay >= 0),
    GiaVeThang      DECIMAL(18,0) NOT NULL CONSTRAINT CK_BangGia_VeThang CHECK (GiaVeThang >= 0),
    NgayApDung      DATE NOT NULL CONSTRAINT DF_BangGia_Ngay DEFAULT (CONVERT(DATE, GETDATE())),
    ConHieuLuc      BIT  NOT NULL CONSTRAINT DF_BangGia_HieuLuc DEFAULT 1
);
GO

-- Bảng của Người 3 (Người 3 được phép đề nghị Người 1 thêm cột nếu cần)
CREATE TABLE dbo.KhachHang (
    MaKH         INT IDENTITY(1,1) PRIMARY KEY,
    HoTen        NVARCHAR(100) NOT NULL,
    SoDienThoai  VARCHAR(15)   NULL,
    BienSoXe     VARCHAR(15)   NULL,
    DiaChi       NVARCHAR(200) NULL
);
GO

CREATE TABLE dbo.VeThang (
    MaVe       INT IDENTITY(1,1) PRIMARY KEY,
    MaKH       INT NOT NULL CONSTRAINT FK_VeThang_KH REFERENCES dbo.KhachHang(MaKH),
    MaLoaiXe   INT NOT NULL CONSTRAINT FK_VeThang_LoaiXe REFERENCES dbo.LoaiXe(MaLoaiXe),
    BienSoXe   VARCHAR(15) NOT NULL,
    NgayBatDau DATE NOT NULL,
    NgayHetHan DATE NOT NULL,
    PhiDaDong  DECIMAL(18,0) NOT NULL CONSTRAINT DF_VeThang_Phi DEFAULT 0,
    TrangThai  NVARCHAR(20) NOT NULL CONSTRAINT DF_VeThang_TT DEFAULT N'Còn hạn',
    CONSTRAINT CK_VeThang_Ngay CHECK (NgayHetHan >= NgayBatDau)
);
GO

-- Bảng của Người 2, Người 4 dùng
CREATE TABLE dbo.LuotGui (
    MaLuot       INT IDENTITY(1,1) PRIMARY KEY,
    MaThe        VARCHAR(20) NOT NULL CONSTRAINT FK_LuotGui_The REFERENCES dbo.TheXe(MaThe),
    BienSo       VARCHAR(15) NOT NULL,
    AnhBienSo    NVARCHAR(260) NULL,                -- đường dẫn ảnh trong thư mục Resources
    ThoiGianVao  DATETIME NOT NULL CONSTRAINT DF_LuotGui_Vao DEFAULT GETDATE(),
    ThoiGianRa   DATETIME NULL,
    PhiGui       DECIMAL(18,0) NULL,
    MaVe         INT NULL CONSTRAINT FK_LuotGui_Ve REFERENCES dbo.VeThang(MaVe),
    NhanVienVao  VARCHAR(30) NULL CONSTRAINT FK_LuotGui_NVVao REFERENCES dbo.TaiKhoan(TenDangNhap),
    NhanVienRa   VARCHAR(30) NULL CONSTRAINT FK_LuotGui_NVRa  REFERENCES dbo.TaiKhoan(TenDangNhap),
    TrangThai    NVARCHAR(20) NOT NULL CONSTRAINT DF_LuotGui_TT DEFAULT N'Đang gửi'
                 CONSTRAINT CK_LuotGui_TT CHECK (TrangThai IN (N'Đang gửi', N'Đã ra')),
    CONSTRAINT CK_LuotGui_Gio CHECK (ThoiGianRa IS NULL OR ThoiGianRa >= ThoiGianVao)
);
GO
-- Mỗi thẻ chỉ có tối đa 1 lượt "Đang gửi" tại một thời điểm
CREATE UNIQUE INDEX UX_LuotGui_TheDangGui ON dbo.LuotGui(MaThe) WHERE TrangThai = N'Đang gửi';
GO

/* ---------- 3. Dữ liệu mẫu của Người 1 ---------- */

-- Tài khoản mẫu: mật khẩu cả hai đều là 123456
INSERT INTO dbo.TaiKhoan (TenDangNhap, MatKhauHash, HoTen, VaiTro) VALUES
('admin', CONVERT(CHAR(64), HASHBYTES('SHA2_256', '123456'), 2), N'Quản lý bãi xe',   'QuanLy'),
('nv01',  CONVERT(CHAR(64), HASHBYTES('SHA2_256', '123456'), 2), N'Nhân viên trực 01', 'NhanVien');
GO

INSERT INTO dbo.LoaiXe (TenLoaiXe, MoTa, SucChua) VALUES
(N'Xe máy', N'Xe máy, xe tay ga',        100),
(N'Ô tô',   N'Ô tô dưới 9 chỗ',           30),
(N'Xe đạp', N'Xe đạp, xe đạp điện',       50);
GO

INSERT INTO dbo.BangGia (MaLoaiXe, GiaGioDau, GiaGioTiepTheo, GiaToiDaNgay, GiaVeThang)
SELECT MaLoaiXe, 3000, 2000, 15000, 120000 FROM dbo.LoaiXe WHERE TenLoaiXe = N'Xe máy';
INSERT INTO dbo.BangGia (MaLoaiXe, GiaGioDau, GiaGioTiepTheo, GiaToiDaNgay, GiaVeThang)
SELECT MaLoaiXe, 20000, 10000, 100000, 1500000 FROM dbo.LoaiXe WHERE TenLoaiXe = N'Ô tô';
INSERT INTO dbo.BangGia (MaLoaiXe, GiaGioDau, GiaGioTiepTheo, GiaToiDaNgay, GiaVeThang)
SELECT MaLoaiXe, 1000, 1000, 5000, 40000 FROM dbo.LoaiXe WHERE TenLoaiXe = N'Xe đạp';
GO

-- Sinh thẻ xe mẫu: XM001..XM010, OT001..OT005, XD001..XD005
DECLARE @xm INT = (SELECT MaLoaiXe FROM dbo.LoaiXe WHERE TenLoaiXe = N'Xe máy');
DECLARE @ot INT = (SELECT MaLoaiXe FROM dbo.LoaiXe WHERE TenLoaiXe = N'Ô tô');
DECLARE @xd INT = (SELECT MaLoaiXe FROM dbo.LoaiXe WHERE TenLoaiXe = N'Xe đạp');
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

/* ---------- 4. Dữ liệu mẫu và stored procedure của thành viên khác ----------
   Người 2: dán dữ liệu mẫu LuotGui bên dưới.
   Người 3: dán dữ liệu mẫu KhachHang, VeThang và sp_SoChoTrong bên dưới.
   Người 4: dán sp_ThongKeDoanhThu bên dưới.
   (Mỗi người gửi đoạn script của mình cho Người 1 hoặc tạo pull request.)
   ------------------------------------------------------------------------- */
GO
