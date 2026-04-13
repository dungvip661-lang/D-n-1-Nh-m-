using System;
using System.Collections.Generic;

namespace DuAn1_Nhom4.Models;

public partial class ThuongHieu
{
    public int MaThuongHieu { get; set; }

    public string TenThuongHieu { get; set; } = null!;

    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
