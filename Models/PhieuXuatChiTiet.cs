using System;
using System.Collections.Generic;

namespace DuAn1_Nhom4.Models;

public partial class PhieuXuatChiTiet
{
    public int MaCt { get; set; }

    public int MaPhieuXuat { get; set; }

    public int MaCtsp { get; set; }

    public int SoLuong { get; set; }

    public decimal GiaBan { get; set; }

    public virtual ChiTietSanPham MaCtspNavigation { get; set; } = null!;

    public virtual PhieuXuat MaPhieuXuatNavigation { get; set; } = null!;
}
