using System;
using System.Collections.Generic;

namespace DuAn1_Nhom4.Models;

public partial class PhieuXuat
{
    public int MaPhieuXuat { get; set; }

    public int MaKh { get; set; }

    public int MaNv { get; set; }

    public DateOnly NgayXuat { get; set; }

    public string TrangThaiThanhToan { get; set; } = null!;

    public string? MoTa { get; set; }

    public virtual KhachHang MaKhNavigation { get; set; } = null!;

    public virtual NhanVien MaNvNavigation { get; set; } = null!;

    public virtual ICollection<PhieuXuatChiTiet> PhieuXuatChiTiets { get; set; } = new List<PhieuXuatChiTiet>();
}
