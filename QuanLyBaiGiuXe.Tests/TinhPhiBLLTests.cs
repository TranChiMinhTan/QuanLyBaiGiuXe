// Kiểm thử đơn vị cho mô hình tính phí B+. CHƯA được chạy (môi trường soạn thảo không có .NET Framework / MSTest).
// Cách chạy: mở solution trong Visual Studio -> Test Explorer -> Run All, hoặc `dotnet test` (cần SDK có hỗ trợ net48).
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuanLyBaiGiuXe.BLL;
using QuanLyBaiGiuXe.Models;

namespace QuanLyBaiGiuXe.Tests
{
    [TestClass]
    public class TinhPhiBLLTests
    {
        private static readonly DateTime Vao = new DateTime(2026, 11, 8, 8, 0, 0);

        private static readonly BangGiaDTO XeMay = new BangGiaDTO
        {
            MienPhiPhut = 15, GiaGioDau = 3000, GiaGioTiepTheo = 2000, GiaToiDaNgay = 15000, GiaVeThang = 120000
        };

        private static decimal Phi(TimeSpan thoiGian)
            => TinhPhiBLL.TinhPhi(new LuotGuiDTO { GioVao = Vao, GioRa = Vao + thoiGian }, XeMay);

        [TestMethod] public void MuoiPhut_MienPhi() => Assert.AreEqual(0m, Phi(TimeSpan.FromMinutes(10)));
        [TestMethod] public void DungMuoiLamPhut_MienPhi() => Assert.AreEqual(0m, Phi(TimeSpan.FromMinutes(15)));
        [TestMethod] public void MuoiLamPhutMotGiay_TinhGioDau() => Assert.AreEqual(3000m, Phi(TimeSpan.FromSeconds(15 * 60 + 1)));
        [TestMethod] public void NamMuoiPhut() => Assert.AreEqual(3000m, Phi(TimeSpan.FromMinutes(50)));
        [TestMethod] public void DungMotGio() => Assert.AreEqual(3000m, Phi(TimeSpan.FromHours(1)));
        [TestMethod] public void MotGioMotGiay_LamTronLen() => Assert.AreEqual(5000m, Phi(TimeSpan.FromSeconds(3601)));
        [TestMethod] public void BaGioHaiMuoiPhut() => Assert.AreEqual(9000m, Phi(new TimeSpan(3, 20, 0)));
        [TestMethod] public void ChamTranTrongNgay() => Assert.AreEqual(15000m, Phi(TimeSpan.FromHours(9)));
        [TestMethod] public void DungHaiMuoiBonGio() => Assert.AreEqual(15000m, Phi(TimeSpan.FromHours(24)));
        [TestMethod] public void HaiMuoiBonGioMuoiPhut() => Assert.AreEqual(18000m, Phi(new TimeSpan(24, 10, 0)));
        [TestMethod] public void BaMuoiGio() => Assert.AreEqual(28000m, Phi(TimeSpan.FromHours(30)));
        [TestMethod] public void BonMuoiTamGio() => Assert.AreEqual(30000m, Phi(TimeSpan.FromHours(48)));

        [TestMethod]
        public void CoVeThangConHan_MienPhi()
            => Assert.AreEqual(0m, TinhPhiBLL.TinhTien(new LuotGuiDTO { GioVao = Vao, GioRa = Vao.AddHours(30) }, XeMay, true));

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GioRaTruocGioVao_NemLoi()
            => TinhPhiBLL.TinhPhi(new LuotGuiDTO { GioVao = Vao, GioRa = Vao.AddMinutes(-1) }, XeMay);
    }
}
