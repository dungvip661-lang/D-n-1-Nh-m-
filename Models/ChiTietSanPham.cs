using System;
using System.Collections.Generic;

namespace DuAn1_Nhom4.Models;

public partial class ChiTietSanPham
{
    public int MaCtsp { get; set; }

    public int MaSp { get; set; }

    public int? MaMau { get; set; }

    public int? MaKichThuoc { get; set; }

    public decimal DonGiaNhap { get; set; }

    public decimal DonGiaXuat { get; set; }

    public int SoLuong { get; set; }

    public string? GhiChu { get; set; }

    public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; } = new List<ChiTietPhieuNhap>();

    public virtual KichThuoc? MaKichThuocNavigation { get; set; }

    public virtual MauSac? MaMauNavigation { get; set; }

    public virtual SanPham MaSpNavigation { get; set; } = null!;

    public virtual ICollection<PhieuXuatChiTiet> PhieuXuatChiTiets { get; set; } = new List<PhieuXuatChiTiet>();
}
