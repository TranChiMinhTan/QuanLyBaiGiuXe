-- =====================================================================
-- Database_Nguoi4.sql : stored procedure cho module Báo cáo doanh thu (Người 4)
-- Chạy SAU khi đã có các bảng LuotGui, ThanhToan, VeThang. Cần SQL Server 2016 SP1 trở lên.
-- Không thêm cột nào vào bảng của người khác (ảnh biển số đã có sẵn cột LuotGui.DuongDanAnh).
--
-- Nguồn doanh thu:
--   * Lượt gửi : bảng ThanhToan (SoTien, ThoiDiem) - ghi cùng transaction với việc xe ra.
--                Xe có vé tháng còn hạn ra với phí 0 nên không làm tăng doanh thu.
--   * Vé tháng : bảng VeThang (PhiDangKy, NgayDangKy) - tính vào ngày đăng ký/gia hạn.
-- =====================================================================
USE QuanLyBaiXe;
GO

CREATE OR ALTER PROCEDURE sp_BaoCaoDoanhThu
    @TuNgay    DATE,
    @DenNgay   DATE,
    @TheoThang BIT          -- 0 = theo ngày, 1 = theo tháng (cột Ky là mùng 1 của tháng)
AS
BEGIN
    SET NOCOUNT ON;

    ;WITH LuotGui_Ky AS (
        SELECT k.Ky,
               COUNT(*)        AS SoLuot,
               SUM(t.SoTien)   AS TienLuotGui
        FROM ThanhToan t
        CROSS APPLY (SELECT CASE WHEN @TheoThang = 1
                                 THEN DATEFROMPARTS(YEAR(t.ThoiDiem), MONTH(t.ThoiDiem), 1)
                                 ELSE CAST(t.ThoiDiem AS DATE) END AS Ky) k
        WHERE t.ThoiDiem >= @TuNgay AND t.ThoiDiem < DATEADD(DAY, 1, @DenNgay)
        GROUP BY k.Ky
    ),
    VeThang_Ky AS (
        SELECT k.Ky,
               SUM(v.PhiDangKy) AS TienVeThang
        FROM VeThang v
        CROSS APPLY (SELECT CASE WHEN @TheoThang = 1
                                 THEN DATEFROMPARTS(YEAR(v.NgayDangKy), MONTH(v.NgayDangKy), 1)
                                 ELSE CAST(v.NgayDangKy AS DATE) END AS Ky) k
        WHERE v.NgayDangKy >= @TuNgay AND v.NgayDangKy < DATEADD(DAY, 1, @DenNgay)
        GROUP BY k.Ky
    )
    SELECT COALESCE(a.Ky, b.Ky)        AS Ky,
           ISNULL(a.SoLuot, 0)         AS SoLuot,
           ISNULL(a.TienLuotGui, 0)    AS TienLuotGui,
           ISNULL(b.TienVeThang, 0)    AS TienVeThang
    FROM LuotGui_Ky a
    FULL OUTER JOIN VeThang_Ky b ON a.Ky = b.Ky
    ORDER BY COALESCE(a.Ky, b.Ky);
END
GO

-- Kiểm tra nhanh (bỏ comment để chạy thử)
-- EXEC sp_BaoCaoDoanhThu '2026-11-01', '2026-11-30', 0;   -- theo ngày
-- EXEC sp_BaoCaoDoanhThu '2026-01-01', '2026-12-31', 1;   -- theo tháng