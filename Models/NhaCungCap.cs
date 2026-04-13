using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DuAn1_Nhom4.Models;

public partial class NhaCungCap
{
    public int MaNcc { get; set; }

    public string TenNcc { get; set; } = null!;

    public string? DiaChi { get; set; }

    public string Email { get; set; } = null!;

    public string SoDienThoai { get; set; } = null!;
    [Browsable(false)]
    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
