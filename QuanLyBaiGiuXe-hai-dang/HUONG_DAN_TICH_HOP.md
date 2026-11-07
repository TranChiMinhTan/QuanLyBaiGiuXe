# Module Người 4 (bản MVP): Tra cứu, In ấn, Báo cáo doanh thu

Viết lại để khớp repo `QuanLyBaiGiuXe-vinh-kiet` (MVP: Models / Views / Presenters, màn hình là UserControl).
Cấu trúc thư mục trong gói này trùng với thư mục project `QuanLyBaiGiuXe/QuanLyBaiGiuXe/`, chỉ cần chép đè.

## 1. File và vị trí

| File | Việc | Ghi chú |
|---|---|---|
| `Views/ucTraCuu.cs` | **Thay** bản rỗng | Cài `ITraCuuView`, bám đúng tên control trong Designer |
| `Views/ucBaoCao.cs` | **Thay** bản rỗng | Cài `IBaoCaoView`, biểu đồ vẽ bằng GDI+ |
| `Views/ucBaoCao.Designer.cs` | **Thay** | Chỉ khác bản gốc ở chỗ: bỏ control `Chart`, thêm `Panel pnlBieuDo` |
| `Views/InPhieu.cs` | Thêm | In vé / biên nhận từ `BienNhanDTO` |
| `Presenters/TraCuuPresenter.cs`, `BaoCaoPresenter.cs` | Thêm | |
| `BLL/TraCuuBLL.cs`, `BaoCaoBLL.cs` | Thêm | |
| `DAL/TraCuuDAL.cs`, `BaoCaoDAL.cs` | Thêm | Dùng `Database.TaoKetNoi()` |
| `Models/BaoCaoDoanhThuDTO.cs` | Thêm | Không sửa `DoanhThuDTO`, `LuotGuiDTO`, `BienNhanDTO` có sẵn |
| `Database/Database_Nguoi4.sql` | Chạy 1 lần | Tạo `sp_BaoCaoDoanhThu`, không sửa bảng nào |

## 2. Khai báo file trong `QuanLyBaiGiuXe.csproj`

Project dùng định dạng cũ nên **file mới phải được khai báo**, nếu không sẽ báo lỗi thiếu lớp. Thêm vào nhóm `<Compile Include=...>`:

```xml
<Compile Include="BLL\BaoCaoBLL.cs" />
<Compile Include="BLL\TraCuuBLL.cs" />
<Compile Include="DAL\BaoCaoDAL.cs" />
<Compile Include="DAL\TraCuuDAL.cs" />
<Compile Include="Models\BaoCaoDoanhThuDTO.cs" />
<Compile Include="Presenters\BaoCaoPresenter.cs" />
<Compile Include="Presenters\TraCuuPresenter.cs" />
<Compile Include="Views\InPhieu.cs" />
```

Có thể xóa dòng `<Reference Include="System.Windows.Forms.DataVisualization" />` vì không còn dùng control Chart (không xóa cũng không sao).

## 3. Việc cần người khác làm (đã đối chiếu code của họ)

**Người 1: `FrmMain` đang trống, chỉ có `tabMain`.** Thêm hai tab:

```csharp
void ThemTab(string tieuDe, Control uc)
{
    uc.Dock = DockStyle.Fill;
    var tp = new TabPage(tieuDe);
    tp.Controls.Add(uc);
    tabMain.TabPages.Add(tp);
}
// ThemTab("Tra cứu", new ucTraCuu());
// ThemTab("Báo cáo doanh thu", new ucBaoCao());   // chỉ hiện với vai trò Quản lý
```

**Người 2 (Vĩnh Kiệt): `ucVanHanh.cs` trong zip vẫn là bản rỗng.** Hàm in theo `IVanHanhView.InBienNhan`:

```csharp
public void InBienNhan(BienNhanDTO bienNhan)
{
    InPhieu.XemTruoc(FindForm(), bienNhan);   // GioRa == null thì in vé, có GioRa thì in biên nhận
}
```

**Người 3 (Bảo Hoan): bảng `VeThang` phải thống nhất với Kiệt.** Báo cáo của mình đọc `VeThang.NgayDangKy` và `VeThang.PhiDangKy` (đúng `VeThangDTO` của Kiệt). Bản hiện tại của Hoan (khóa theo `SoThe`, không có `PhiDangKy`) sẽ làm `sp_BaoCaoDoanhThu` báo lỗi *Invalid column name*. Nếu bảng `VeThang` chưa sẵn sàng khi demo, thay tạm khối `VeThang_Ky` bằng:

```sql
VeThang_Ky AS (SELECT CAST(NULL AS DATE) AS Ky, CAST(0 AS DECIMAL(18,0)) AS TienVeThang WHERE 1 = 0)
```

## 4. Cách tính và hành vi

- **Doanh thu lượt gửi** lấy từ `ThanhToan.SoTien` theo `ThoiDiem` (bảng này được ghi cùng transaction khi xe ra). Xe có vé tháng ra với phí 0 nên không làm tăng doanh thu.
- **Doanh thu vé tháng** lấy từ `VeThang.PhiDangKy` theo `NgayDangKy`. Ô tổng hiển thị đúng dạng "Tổng: X (lượt gửi A + vé tháng B)".
- **Theo ngày:** tối đa 365 ngày. **Theo tháng:** tự lấy trọn tháng, tối đa 60 tháng. Kỳ không có xe vẫn hiện số 0.
- **Biểu đồ GDI+:** cột là doanh thu (trục trái), đường là số lượt xe ra (trục phải). Đây cũng là phần "thống kê lượt xe theo ngày" của đề.
- **Tra cứu:** lọc theo biển số, mã thẻ (gõ một phần cũng được), loại xe, khoảng **ngày vào**. Nhập `%` hoặc `_` được coi là ký tự thường.
- **Nút "In biên nhận":** chọn lượt đã ra thì in biên nhận, chọn lượt đang gửi thì in vé vào. Nhấp đúp một dòng để xem ảnh biển số.
- **Xuất CSV:** UTF-8 có BOM, phân cách `;` và có dòng `sep=;` nên Excel mở ra đúng cột và đúng tiếng Việt.

## 5. Test case gợi ý (Chương 4)

| Chức năng | Tình huống | Kết quả mong đợi |
|---|---|---|
| Tra cứu | Để trống mọi ô | Hiện các lượt vào trong 7 ngày gần nhất |
| Tra cứu | Từ ngày lớn hơn Đến ngày | Hộp thoại báo lỗi, không truy vấn |
| Tra cứu | Biển số không tồn tại | Bảng trống, "Tìm thấy 0 lượt" |
| Tra cứu | Gõ `%` hoặc `'; DROP TABLE` vào biển số | Không lỗi, không khớp lung tung |
| Tra cứu | Lọc đúng 1 loại xe | Chỉ hiện loại đó |
| In | Chưa chọn dòng nào, bấm In | Nhắc chọn lượt gửi |
| In | Máy chưa cài máy in | Thông báo, gợi ý "Microsoft Print to PDF" |
| Ảnh | Nhấp đúp lượt không có ảnh / file ảnh bị xóa | Thông báo, không sập |
| Báo cáo | Khoảng ngày không có giao dịch | Toàn số 0, biểu đồ trống |
| Báo cáo | Khoảng hơn 365 ngày (theo ngày) | Báo lỗi giới hạn |
| Báo cáo | Tháng có cả vé tháng và lượt gửi | Tổng = lượt gửi + vé tháng |
| CSV | Xuất khi file đang mở trong Excel | Báo lỗi ghi file, không sập |
| Lỗi kết nối | Tắt SQL Server rồi bấm Tìm kiếm / Xem | Báo lỗi, chương trình không sập |

## 6. Điểm nói khi thuyết trình

1. Theo mô hình MVP: View chỉ chứa control, Presenter điều phối, BLL kiểm tra nghiệp vụ, DAL chỉ chứa SQL tham số hóa.
2. Tra cứu nhiều điều kiện bằng một câu SQL tham số hóa, chống SQL injection.
3. In bằng PrintDocument và PrintPreviewDialog, vé khổ 80 mm.
4. Biểu đồ vẽ bằng GDI+ trong sự kiện Paint, thang trục tự chọn bước chia 1-2-5.
5. Báo cáo dùng stored procedure, gom doanh thu lượt gửi và vé tháng theo ngày/tháng.

## 7. Chưa kiểm chứng được

Chưa biên dịch và chưa chạy với SQL Server thật. Mình đã đối chiếu tên control, namespace, interface, tên cột và tên hàm với code của Kiệt bằng script, nhưng bạn vẫn cần build thử trong Visual Studio và chạy `sp_BaoCaoDoanhThu` với dữ liệu mẫu trước khi demo.
