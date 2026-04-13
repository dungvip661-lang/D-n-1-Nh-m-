using System;
using System.Collections.Generic;

namespace DuAn1_Nhom4.Models;

public partial class SanPham
{
    public int MaSp { get; set; }

    public int? MaNcc { get; set; }

    public string TenSp { get; set; } = null!;

    public string? MoTa { get; set; }

    public int? MaThuongHieu { get; set; }

    public string TrangThai { get; set; } = null!;

    public virtual ICollection<ChiTietSanPham> ChiTietSanPhams { get; set; } = new List<ChiTietSanPham>();

    public virtual NhaCungCap? MaNccNavigation { get; set; }

    public virtual ThuongHieu? MaThuongHieuNavigation { get; set; }
}
