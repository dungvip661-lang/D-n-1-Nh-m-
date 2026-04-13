using System;
using System.Collections.Generic;

namespace DuAn1_Nhom4.Models;

public partial class TaiKhoanNhanVien
{
    public int Id { get; set; }

    public int NhanVienId { get; set; }

    public string TenDangNhap { get; set; } = null!;

    public string MatKhau { get; set; } = null!;

    public string TrangThai { get; set; } = null!;

    public virtual NhanVien NhanVien { get; set; } = null!;
}
