using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DuAn1_Nhom4.Models;

public partial class QuanLyKhoHangQuanAoContext : DbContext
{
    public QuanLyKhoHangQuanAoContext()
    {
    }

    public QuanLyKhoHangQuanAoContext(DbContextOptions<QuanLyKhoHangQuanAoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }

    public virtual DbSet<ChiTietSanPham> ChiTietSanPhams { get; set; }

    public virtual DbSet<ChucVu> ChucVus { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<KichThuoc> KichThuocs { get; set; }

    public virtual DbSet<MauSac> MauSacs { get; set; }

    public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<PhieuNhap> PhieuNhaps { get; set; }

    public virtual DbSet<PhieuXuat> PhieuXuats { get; set; }

    public virtual DbSet<PhieuXuatChiTiet> PhieuXuatChiTiets { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    public virtual DbSet<TaiKhoanNhanVien> TaiKhoanNhanViens { get; set; }

    public virtual DbSet<ThuongHieu> ThuongHieus { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.

        => optionsBuilder.UseSqlServer("Server=DESKTOP-OIKIQ5D\\SQL2022;Database=QuanLyKhoHangQuanAo1;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChiTietPhieuNhap>(entity =>
        {
            entity.HasKey(e => e.MaPhieuCt).HasName("PK__ChiTietP__880CA1392BE51079");

            entity.ToTable("ChiTietPhieuNhap");

            entity.Property(e => e.MaPhieuCt).HasColumnName("MaPhieuCT");
            entity.Property(e => e.DonGia).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MaCtsp).HasColumnName("MaCTSP");

            entity.HasOne(d => d.MaCtspNavigation).WithMany(p => p.ChiTietPhieuNhaps)
                .HasForeignKey(d => d.MaCtsp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietPh__MaCTS__628FA481");

            entity.HasOne(d => d.MaPhieuNhapNavigation).WithMany(p => p.ChiTietPhieuNhaps)
                .HasForeignKey(d => d.MaPhieuNhap)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietPh__MaPhi__619B8048");
        });

        modelBuilder.Entity<ChiTietSanPham>(entity =>
        {
            entity.HasKey(e => e.MaCtsp).HasName("PK__ChiTietS__1E4FCECD5A111232");

            entity.ToTable("ChiTietSanPham");

            entity.Property(e => e.MaCtsp).HasColumnName("MaCTSP");
            entity.Property(e => e.DonGiaNhap).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DonGiaXuat).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.GhiChu).HasMaxLength(255);
            entity.Property(e => e.MaSp).HasColumnName("MaSP");

            entity.HasOne(d => d.MaKichThuocNavigation).WithMany(p => p.ChiTietSanPhams)
                .HasForeignKey(d => d.MaKichThuoc)
                .HasConstraintName("FK__ChiTietSa__MaKic__59063A47");

            entity.HasOne(d => d.MaMauNavigation).WithMany(p => p.ChiTietSanPhams)
                .HasForeignKey(d => d.MaMau)
                .HasConstraintName("FK__ChiTietSa__MaMau__5812160E");

            entity.HasOne(d => d.MaSpNavigation).WithMany(p => p.ChiTietSanPhams)
                .HasForeignKey(d => d.MaSp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietSan__MaSP__571DF1D5");
        });

        modelBuilder.Entity<ChucVu>(entity =>
        {
            entity.HasKey(e => e.MaChucVu).HasName("PK__ChucVu__D4639533F8162856");

            entity.ToTable("ChucVu");

            entity.Property(e => e.TenChucVu).HasMaxLength(50);
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKh).HasName("PK__KhachHan__2725CF1E37242659");

            entity.ToTable("KhachHang");

            entity.Property(e => e.MaKh).HasColumnName("MaKH");
            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Sdt)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("SDT");
            entity.Property(e => e.Ten).HasMaxLength(100);
        });

        modelBuilder.Entity<KichThuoc>(entity =>
        {
            entity.HasKey(e => e.MaKichThuoc).HasName("PK__KichThuo__22BFD664D64780A0");

            entity.ToTable("KichThuoc");

            entity.HasIndex(e => e.TenKichThuoc, "UQ__KichThuo__9D0743DAA8DBD9B1").IsUnique();

            entity.Property(e => e.TenKichThuoc).HasMaxLength(50);
        });

        modelBuilder.Entity<MauSac>(entity =>
        {
            entity.HasKey(e => e.MaMau).HasName("PK__MauSac__3A5BBB7DF8DE72BE");

            entity.ToTable("MauSac");

            entity.HasIndex(e => e.TenMau, "UQ__MauSac__332F6A91EC332EE6").IsUnique();

            entity.Property(e => e.TenMau).HasMaxLength(50);
        });

        modelBuilder.Entity<NhaCungCap>(entity =>
        {
            entity.HasKey(e => e.MaNcc).HasName("PK__NhaCungC__3A185DEB777B5BE5");

            entity.ToTable("NhaCungCap");

            entity.HasIndex(e => e.Email, "UQ__NhaCungC__A9D10534C377E567").IsUnique();

            entity.Property(e => e.MaNcc).HasColumnName("MaNCC");
            entity.Property(e => e.DiaChi).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.TenNcc)
                .HasMaxLength(100)
                .HasColumnName("TenNCC");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NhanVien__3214EC0783A2C830");

            entity.ToTable("NhanVien");

            entity.HasIndex(e => e.Email, "UQ__NhanVien__A9D10534BD857E7A").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.MaChucVuNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.MaChucVu)
                .HasConstraintName("FK__NhanVien__MaChuc__3A81B327");
        });

        modelBuilder.Entity<PhieuNhap>(entity =>
        {
            entity.HasKey(e => e.MaPhieuNhap).HasName("PK__PhieuNha__1470EF3B50CC6104");

            entity.ToTable("PhieuNhap");

            entity.Property(e => e.GhiChu).HasMaxLength(255);
            entity.Property(e => e.MaNv).HasColumnName("MaNV");
            entity.Property(e => e.NgayNhap).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.TrangThaiThanhToan).HasMaxLength(50);

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.PhieuNhaps)
                .HasForeignKey(d => d.MaNv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PhieuNhap__MaNV__5CD6CB2B");
        });

        modelBuilder.Entity<PhieuXuat>(entity =>
        {
            entity.HasKey(e => e.MaPhieuXuat).HasName("PK__PhieuXua__26C4B5A23E29C664");

            entity.ToTable("PhieuXuat");

            entity.Property(e => e.MaKh).HasColumnName("MaKH");
            entity.Property(e => e.MaNv).HasColumnName("MaNV");
            entity.Property(e => e.NgayXuat).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.TrangThaiThanhToan).HasMaxLength(50);

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.PhieuXuats)
                .HasForeignKey(d => d.MaKh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PhieuXuat__MaKH__66603565");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.PhieuXuats)
                .HasForeignKey(d => d.MaNv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PhieuXuat__MaNV__6754599E");
        });

        modelBuilder.Entity<PhieuXuatChiTiet>(entity =>
        {
            entity.HasKey(e => e.MaCt).HasName("PK__PhieuXua__27258E74350C49F2");

            entity.ToTable("PhieuXuatChiTiet");

            entity.Property(e => e.MaCt).HasColumnName("MaCT");
            entity.Property(e => e.GiaBan).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MaCtsp).HasColumnName("MaCTSP");

            entity.HasOne(d => d.MaCtspNavigation).WithMany(p => p.PhieuXuatChiTiets)
                .HasForeignKey(d => d.MaCtsp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PhieuXuat__MaCTS__6D0D32F4");

            entity.HasOne(d => d.MaPhieuXuatNavigation).WithMany(p => p.PhieuXuatChiTiets)
                .HasForeignKey(d => d.MaPhieuXuat)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PhieuXuat__MaPhi__6C190EBB");
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.HasKey(e => e.MaSp).HasName("PK__SanPham__2725081C94309B64");

            entity.ToTable("SanPham");

            entity.Property(e => e.MaSp).HasColumnName("MaSP");
            entity.Property(e => e.MaNcc).HasColumnName("MaNCC");
            entity.Property(e => e.TenSp)
                .HasMaxLength(100)
                .HasColumnName("TenSP");
            entity.Property(e => e.TrangThai).HasMaxLength(50);

            entity.HasOne(d => d.MaNccNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.MaNcc)
                .HasConstraintName("FK__SanPham__MaNCC__4BAC3F29");

            entity.HasOne(d => d.MaThuongHieuNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.MaThuongHieu)
                .HasConstraintName("FK__SanPham__MaThuon__4AB81AF0");
        });

        modelBuilder.Entity<TaiKhoanNhanVien>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TaiKhoan__3214EC07A1B421AE");

            entity.ToTable("TaiKhoanNhanVien");

            entity.HasIndex(e => e.TenDangNhap, "UQ__TaiKhoan__55F68FC0CDD9E599").IsUnique();

            entity.HasIndex(e => e.NhanVienId, "UQ__TaiKhoan__E27FD78B1F416C20").IsUnique();

            entity.Property(e => e.MatKhau).HasMaxLength(100);
            entity.Property(e => e.TenDangNhap).HasMaxLength(100);
            entity.Property(e => e.TrangThai)
                .HasMaxLength(50)
                .HasDefaultValue("Hoạt động");

            entity.HasOne(d => d.NhanVien).WithOne(p => p.TaiKhoanNhanVien)
                .HasForeignKey<TaiKhoanNhanVien>(d => d.NhanVienId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TaiKhoanN__NhanV__403A8C7D");
        });

        modelBuilder.Entity<ThuongHieu>(entity =>
        {
            entity.HasKey(e => e.MaThuongHieu).HasName("PK__ThuongHi__A3733E2CCB3EE93B");

            entity.ToTable("ThuongHieu");

            entity.HasIndex(e => e.TenThuongHieu, "UQ__ThuongHi__98D6A83401D39344").IsUnique();

            entity.Property(e => e.TenThuongHieu).HasMaxLength(100);
        });
        // Seed dữ liệu cho bảng ChucVu
        modelBuilder.Entity<ChucVu>().HasData(
            new ChucVu { MaChucVu = 1, TenChucVu = "Quản trị viên" },
            new ChucVu { MaChucVu = 2, TenChucVu = "Quản lý kho" },
            new ChucVu { MaChucVu = 3, TenChucVu = "Nhân viên kiểm kho" },
            new ChucVu { MaChucVu = 4, TenChucVu = "Nhân viên bán hàng" },
            new ChucVu { MaChucVu = 5, TenChucVu = "Nhân viên nhập hàng" }
        );

        // Nếu muốn seed thêm Admin mặc định
        modelBuilder.Entity<NhanVien>().HasData(
            new NhanVien
            {
                Id = 1,
                HoTen = "Admin Hệ Thống",
                Email = "admin@fpt.edu.vn",
                SoDienThoai = "0123456789",
                MaChucVu = 1
            }
        );

        modelBuilder.Entity<TaiKhoanNhanVien>().HasData(
            new TaiKhoanNhanVien
            {
                Id = 1,
                NhanVienId = 1,
                TenDangNhap = "admin",
                MatKhau = "123",
                TrangThai = "Hoạt động"
            }
        );

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
