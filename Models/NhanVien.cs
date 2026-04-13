using System;
using System.Collections.Generic;

namespace DuAn1_Nhom4.Models;

public partial class NhanVien
{
    public int Id { get; set; }

    public string HoTen { get; set; } = null!;

    public string SoDienThoai { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int? MaChucVu { get; set; }

    public virtual ChucVu? MaChucVuNavigation { get; set; }

    public virtual ICollection<PhieuNhap> PhieuNhaps { get; set; } = new List<PhieuNhap>();

    public virtual ICollection<PhieuXuat> PhieuXuats { get; set; } = new List<PhieuXuat>();

    public virtual TaiKhoanNhanVien? TaiKhoanNhanVien { get; set; }
}
