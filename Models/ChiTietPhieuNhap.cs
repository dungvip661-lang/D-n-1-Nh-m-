using System;
using System.Collections.Generic;

namespace DuAn1_Nhom4.Models;

public partial class ChiTietPhieuNhap
{
    public int MaPhieuCt { get; set; }

    public int MaPhieuNhap { get; set; }

    public int MaCtsp { get; set; }

    public int SoLuong { get; set; }

    public decimal DonGia { get; set; }

    public virtual ChiTietSanPham MaCtspNavigation { get; set; } = null!;

    public virtual PhieuNhap MaPhieuNhapNavigation { get; set; } = null!;
}
