using System;
using System.Collections.Generic;

namespace DuAn1_Nhom4.Models;

public partial class MauSac
{
    public int MaMau { get; set; }

    public string TenMau { get; set; } = null!;

    public virtual ICollection<ChiTietSanPham> ChiTietSanPhams { get; set; } = new List<ChiTietSanPham>();
}
