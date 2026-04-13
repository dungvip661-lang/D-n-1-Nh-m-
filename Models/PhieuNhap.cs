using System;
using System.Collections.Generic;

namespace DuAn1_Nhom4.Models;

public partial class PhieuNhap
{
    public int MaPhieuNhap { get; set; }

    public int MaNv { get; set; }

    public DateOnly NgayNhap { get; set; }

    public string? GhiChu { get; set; }

    public string TrangThaiThanhToan { get; set; } = null!;

    public DateOnly? NgayThanhToan { get; set; }

    public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; } = new List<ChiTietPhieuNhap>();

    public virtual NhanVien MaNvNavigation { get; set; } = null!;
}
