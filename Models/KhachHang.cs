using System;
using System.Collections.Generic;

namespace DuAn1_Nhom4.Models;

public partial class KhachHang
{
    public int MaKh { get; set; }

    public string Ten { get; set; } = null!;

    public string Sdt { get; set; } = null!;

    public string? DiaChi { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<PhieuXuat> PhieuXuats { get; set; } = new List<PhieuXuat>();
}
