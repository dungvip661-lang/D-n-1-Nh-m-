
-- Tạo database
CREATE DATABASE QuanLyKhoHangQuanAo;
GO

USE QuanLyKhoHangQuanAo;
GO

CREATE TABLE ChucVu(
    MaChucVu INT PRIMARY KEY IDENTITY,
    TenChucVu NVARCHAR(50) NOT NULL
);
GO

CREATE TABLE NhanVien (
    Id INT PRIMARY KEY IDENTITY,
    HoTen NVARCHAR(100) NOT NULL,
    SoDienThoai VARCHAR(15) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    MaChucVu INT,
    FOREIGN KEY (MaChucVu) REFERENCES ChucVu(MaChucVu)
);
GO


CREATE TABLE TaiKhoanNhanVien (
    Id INT PRIMARY KEY IDENTITY,
    NhanVienId INT NOT NULL UNIQUE,
    TenDangNhap NVARCHAR(100) NOT NULL UNIQUE,
    MatKhau NVARCHAR(100) NOT NULL,
    TrangThai NVARCHAR(50) NOT NULL DEFAULT N'Hoạt động',
    FOREIGN KEY (NhanVienId) REFERENCES NhanVien(Id)
);
GO

CREATE TABLE KhachHang (
    MaKH INT PRIMARY KEY IDENTITY,
    Ten NVARCHAR(100) NOT NULL,
    SDT VARCHAR(15) NOT NULL,
    DiaChi NVARCHAR(255),
    Email NVARCHAR(100)
);
GO

CREATE TABLE ThuongHieu (
    MaThuongHieu INT PRIMARY KEY IDENTITY,
    TenThuongHieu NVARCHAR(100) NOT NULL UNIQUE
);
GO

CREATE TABLE NhaCungCap (
    MaNCC INT PRIMARY KEY IDENTITY,
    TenNCC NVARCHAR(100) NOT NULL,
    DiaChi NVARCHAR(200),
    Email NVARCHAR(100) NOT NULL UNIQUE,
    SoDienThoai VARCHAR(15) NOT NULL
);
GO

CREATE TABLE SanPham (
    MaSP INT PRIMARY KEY IDENTITY,
    MaNCC INT,
    TenSP NVARCHAR(100) NOT NULL,
    MoTa NVARCHAR(MAX),
    MaThuongHieu INT,
    TrangThai NVARCHAR(50) NOT NULL,
    FOREIGN KEY (MaThuongHieu) REFERENCES ThuongHieu(MaThuongHieu),
    FOREIGN KEY (MaNCC) REFERENCES NhaCungCap(MaNCC)
);
GO

CREATE TABLE MauSac (
    MaMau INT PRIMARY KEY IDENTITY,
    TenMau NVARCHAR(50) NOT NULL UNIQUE
);
GO

CREATE TABLE KichThuoc (
    MaKichThuoc INT PRIMARY KEY IDENTITY,
    TenKichThuoc NVARCHAR(50) NOT NULL UNIQUE
);
GO

CREATE TABLE ChiTietSanPham (
    MaCTSP INT PRIMARY KEY IDENTITY,
    MaSP INT NOT NULL,
    MaMau INT,
    MaKichThuoc INT,
    DonGiaNhap DECIMAL(18,2) NOT NULL CHECK (DonGiaNhap >= 0),
    DonGiaXuat DECIMAL(18,2) NOT NULL CHECK (DonGiaXuat >= 0),
    SoLuong INT NOT NULL CHECK (SoLuong >= 0),
    GhiChu NVARCHAR(255),
    FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP),
    FOREIGN KEY (MaMau) REFERENCES MauSac(MaMau),
    FOREIGN KEY (MaKichThuoc) REFERENCES KichThuoc(MaKichThuoc)
);
GO

CREATE TABLE PhieuNhap (
    MaPhieuNhap INT PRIMARY KEY IDENTITY,
    MaNV INT NOT NULL,
    NgayNhap DATE NOT NULL DEFAULT GETDATE(),
    GhiChu NVARCHAR(255),
    TrangThaiThanhToan NVARCHAR(50) NOT NULL,
    NgayThanhToan DATE,
    FOREIGN KEY (MaNV) REFERENCES NhanVien(Id)
);
GO

CREATE TABLE ChiTietPhieuNhap (
    MaPhieuCT INT PRIMARY KEY IDENTITY,
    MaPhieuNhap INT NOT NULL,
    MaCTSP INT NOT NULL,
    SoLuong INT NOT NULL CHECK (SoLuong > 0),
    DonGia DECIMAL(18, 2) NOT NULL CHECK (DonGia >= 0),
    FOREIGN KEY (MaPhieuNhap) REFERENCES PhieuNhap(MaPhieuNhap),
    FOREIGN KEY (MaCTSP) REFERENCES ChiTietSanPham(MaCTSP)
);
GO

CREATE TABLE PhieuXuat (
    MaPhieuXuat INT PRIMARY KEY IDENTITY,
    MaKH INT NOT NULL,
    MaNV INT NOT NULL,
    NgayXuat DATE NOT NULL DEFAULT GETDATE(),
    TrangThaiThanhToan NVARCHAR(50) NOT NULL,
    MoTa NVARCHAR(MAX),
    FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH),
    FOREIGN KEY (MaNV) REFERENCES NhanVien(Id)
);
GO


CREATE TABLE PhieuXuatChiTiet (
    MaCT INT PRIMARY KEY IDENTITY,
    MaPhieuXuat INT NOT NULL,
    MaCTSP INT NOT NULL,
    SoLuong INT NOT NULL CHECK (SoLuong > 0),
    GiaBan DECIMAL(18, 2) NOT NULL CHECK (GiaBan >= 0),
    FOREIGN KEY (MaPhieuXuat) REFERENCES PhieuXuat(MaPhieuXuat),
    FOREIGN KEY (MaCTSP) REFERENCES ChiTietSanPham(MaCTSP)
);
GO

INSERT INTO ChucVu (TenChucVu) VALUES
(N'Quản lý'),
(N'Nhân viên');
GO

INSERT INTO NhanVien (HoTen, SoDienThoai, Email, MaChucVu) VALUES
(N'Nguyễn Thị Mai',     '0912345678', 'mainguyen@gmail.com', 1),
(N'Lê Văn Hùng',        '0934567890', 'hunghlv@gmail.com', 2),
(N'Trần Thị Hương',     '0987654321', 'huongtran@gmail.com', 1),
(N'Phạm Minh Tuấn',     '0909090909', 'tuanpham@gmail.com', 2),
(N'Hồ Thị Lan',         '0922334455', 'lanhothi@gmail.com', 2),
(N'Võ Đức Anh',         '0944112233', 'anhvo.duc@gmail.com', 2),
(N'Đỗ Thị Kim Ngân',    '0977553311', 'kimngandtk@gmail.com', 1),
(N'Bùi Văn Quang',      '0966332211', 'quangbui@gmail.com', 2),
(N'Ngô Thị Thảo',       '0955778899', 'thaongo@gmail.com', 2),
(N'Huỳnh Quốc Khánh',   '0933888899', 'khanhhuynh@gmail.com', 2);
GO

INSERT INTO TaiKhoanNhanVien (NhanVienId, TenDangNhap, MatKhau) VALUES
(1, 'mainguyen', '123456'),
(2, 'hunghlv', '123456'),
(3, 'huongtran', '123456'),
(4, 'tuanpham', '123456'),
(5, 'lanhothi', '123456'),
(6, 'anhvo', '123456'),
(7, 'kimngan', '123456'),
(8, 'quangbui', '123456'),
(9, 'thaongo', '123456'),
(10, 'khanhhuynh', '123456');
GO

INSERT INTO KhachHang (Ten, SDT, DiaChi, Email) VALUES
(N'Nguyễn Thị Thanh', '0905123456', N'123 Lý Thường Kiệt, Hà Nội', 'thanhnguyen@gmail.com'),
(N'Lê Hoàng Long', '0912345678', N'45 Nguyễn Trãi, TP.HCM', 'longle@gmail.com'),
(N'Trần Thị Bích Ngọc', '0988776655', N'88 Hai Bà Trưng, Đà Nẵng', 'bichngoc.tran@gmail.com'),
(N'Phạm Văn Nam', '0934567890', N'12 Trần Hưng Đạo, Cần Thơ', 'nampham@gmail.com'),
(N'Hoàng Minh Châu', '0944332211', N'76 Phạm Văn Đồng, Huế', 'chauhm@gmail.com'),
(N'Vũ Thị Hà', '0977553311', N'22 Điện Biên Phủ, Hà Nội', 'havu@gmail.com'),
(N'Đặng Quốc Bảo', '0966887799', N'18 Nguyễn Văn Cừ, TP.HCM', 'baodq@gmail.com'),
(N'Ngô Thị Kim Yến', '0955998877', N'99 Nguyễn Huệ, Đà Nẵng', 'yenngo.kim@gmail.com'),
(N'Huỳnh Văn Hậu', '0933112233', N'5 Lê Duẩn, Hải Phòng', 'hauhuynh@gmail.com'),
(N'Bùi Thị Thu Trang', '0922446688', N'34 Trần Phú, Nha Trang', 'trangbui@gmail.com');
GO

INSERT INTO ThuongHieu (TenThuongHieu) VALUES
(N'Adidas'),
(N'Nike'),
(N'Puma'),
(N'Zara'),
(N'Uniqlo'),
(N'Gucci'),
(N'Louis Vuitton'),
(N'H&M'),
(N'Lacoste'),
(N'Mango');
GO

INSERT INTO NhaCungCap (TenNCC, DiaChi, Email, SoDienThoai) VALUES
(N'Công ty TNHH Vạn Thành', N'123 Nguyễn Trãi, Hà Nội', 'vanthanh@gmail.com', '0909000011'),
(N'Công ty May Kim Liên', N'45 Lý Tự Trọng, TP.HCM', 'kimlien@gmail.com', '0911000022'),
(N'Cửa hàng Thời Trang ABC', N'88 Trần Hưng Đạo, Đà Nẵng', 'abcfashion@gmail.com', '0922000033'),
(N'Xưởng Sản Xuất Áo Quần Quang Minh', N'12 Trần Phú, Cần Thơ', 'quangminh@gmail.com', '0933000044'),
(N'Nhà cung cấp Zara Việt Nam', N'76 Nguyễn Văn Cừ, Huế', 'zara.vn@gmail.com', '0944000055'),
(N'Xưởng Uniqlo Việt Nam', N'22 Hai Bà Trưng, Hà Nội', 'uniqlo.vn@gmail.com', '0955000066'),
(N'Công ty TNHH Gucci', N'18 Nguyễn Huệ, TP.HCM', 'gucci.vn@gmail.com', '0966000077'),
(N'Nhà phân phối Mango', N'99 Lê Duẩn, Đà Nẵng', 'mango@gmail.com', '0977000088'),
(N'Tổng kho Adidas', N'5 Điện Biên Phủ, Hải Phòng', 'adidas@gmail.com', '0988000099'),
(N'Công ty TNHH Louis Vuitton', N'34 Lê Lợi, Nha Trang', 'lv@gmail.com', '0999000010');
GO

INSERT INTO SanPham (MaNCC, TenSP, MoTa, MaThuongHieu, TrangThai) VALUES
(1, N'Áo Thun Nam Adidas', N'Áo thun nam chính hãng, thấm hút tốt.', 1, N'Còn hàng'),
(2, N'Quần Jean Nữ Nike', N'Quần jean nữ co giãn, phù hợp mặc đi làm hoặc đi chơi.', 2, N'Còn hàng'),
(3, N'Áo Khoác Puma', N'Áo khoác thể thao, giữ ấm tốt.', 3, N'Ngừng kinh doanh'),
(4, N'Váy Zara', N'Váy thời trang nữ cao cấp.', 4, N'Còn hàng'),
(5, N'Áo Sơ Mi Uniqlo', N'Sản phẩm vải mát, dễ mặc, phù hợp công sở.', 5, N'Còn hàng'),
(6, N'Quần Tây Gucci', N'Quần tây cao cấp cho nam.', 6, N'Còn hàng'),
(7, N'Túi Xách Louis Vuitton', N'Túi xách hàng hiệu chính hãng.', 7, N'Còn hàng'),
(8, N'Áo Khoác H&M', N'Áo khoác thời trang trẻ trung.', 8, N'Còn hàng'),
(9, N'Áo Polo Lacoste', N'Áo polo nam nữ năng động.', 9, N'Còn hàng'),
(10, N'Chân Váy Mango', N'Chân váy nữ tính, phong cách.', 10, N'Còn hàng');
GO

INSERT INTO MauSac (TenMau) VALUES
(N'Đen'),
(N'Trắng'),
(N'Xám'),
(N'Xanh dương'),
(N'Xanh lá'),
(N'Đỏ'),
(N'Vàng'),
(N'Hồng'),
(N'Nâu'),
(N'Tím');
go
INSERT INTO KichThuoc (TenKichThuoc) VALUES
(N'XS'),
(N'S'),
(N'M'),
(N'L'),
(N'XL');
Go
INSERT INTO ChiTietSanPham (MaSP, MaMau, MaKichThuoc, DonGiaNhap, DonGiaXuat, SoLuong, GhiChu) VALUES
(1, 1, 1, 120000, 180000, 50, N'Hàng mới về'),
(2, 2, 2, 150000, 220000, 40, N'Bán chạy'),
(3, 3, 3, 200000, 280000, 30, NULL),
(4, 4, 4, 180000, 250000, 60, N'Hàng giảm giá'),
(5, 5, 5, 130000, 200000, 35, NULL),
(6, 1, 2, 170000, 240000, 45, NULL),
(7, 2, 3, 300000, 450000, 20, N'Hàng cao cấp'),
(8, 3, 4, 110000, 160000, 55, NULL),
(9, 4, 5, 160000, 230000, 25, NULL),
(10, 5, 1, 190000, 260000, 40, N'Size nhỏ');
go
INSERT INTO PhieuNhap (MaNV, NgayNhap, GhiChu, TrangThaiThanhToan, NgayThanhToan) VALUES
(1, '2025-07-01', N'Nhập hàng Adidas đợt 1', N'Đã thanh toán', '2025-07-02'),
(2, '2025-07-02', N'Nhập hàng Nike', N'Chưa thanh toán', NULL),
(3, '2025-07-03', N'Nhập thêm áo Puma', N'Đã thanh toán', '2025-07-04'),
(4, '2025-07-04', N'Nhập kho Zara', N'Đã thanh toán', '2025-07-05'),
(5, '2025-07-05', N'Nhập hàng tồn kho Uniqlo', N'Chưa thanh toán', NULL),
(6, '2025-07-06', N'Nhập quần Gucci', N'Đã thanh toán', '2025-07-06'),
(7, '2025-07-07', N'Nhập phụ kiện LV', N'Chưa thanh toán', NULL),
(8, '2025-07-08', N'Hàng H&M đợt 2', N'Đã thanh toán', '2025-07-09'),
(9, '2025-07-09', N'Nhập mẫu thử Lacoste', N'Chưa thanh toán', NULL),
(10, '2025-07-10', N'Nhập hàng Mango', N'Đã thanh toán', '2025-07-10');
go
INSERT INTO ChiTietPhieuNhap (MaPhieuNhap, MaCTSP, SoLuong, DonGia) VALUES
(1, 1, 20, 120000),
(2, 2, 15, 150000),
(3, 3, 10, 200000),
(4, 4, 25, 180000),
(5, 5, 30, 130000),
(6, 6, 18, 170000),
(7, 7, 12, 300000),
(8, 8, 22, 110000),
(9, 9, 14, 160000),
(10, 10, 16, 190000);
go
INSERT INTO PhieuXuat (MaKH, MaNV, NgayXuat, TrangThaiThanhToan, MoTa) VALUES
(1, 1, '2025-07-11', N'Đã thanh toán', N'Xuất đơn hàng cho khách Thanh'),
(2, 2, '2025-07-12', N'Chưa thanh toán', N'Đơn hàng khách Long chưa thanh toán'),
(3, 3, '2025-07-13', N'Đã thanh toán', N'Khách Ngọc đặt hàng áo khoác'),
(4, 4, '2025-07-14', N'Đã thanh toán', N'Đơn hàng giao cho anh Nam'),
(5, 5, '2025-07-15', N'Chưa thanh toán', N'Khách Châu sẽ chuyển khoản sau'),
(6, 6, '2025-07-16', N'Đã thanh toán', N'Giao hàng tận nơi cho chị Hà'),
(7, 7, '2025-07-17', N'Chưa thanh toán', N'Đơn của anh Bảo đang xử lý'),
(8, 8, '2025-07-18', N'Đã thanh toán', N'Đơn hàng xuất đi cho Yến'),
(9, 9, '2025-07-19', N'Chưa thanh toán', N'Khách Hậu thanh toán sau'),
(10, 10, '2025-07-20', N'Đã thanh toán', N'Xuất hóa đơn cho chị Trang');
go
INSERT INTO PhieuXuatChiTiet (MaPhieuXuat, MaCTSP, SoLuong, GiaBan) VALUES
(1, 1, 2, 180000),
(2, 2, 1, 220000),
(3, 3, 3, 280000),
(4, 4, 2, 250000),
(5, 5, 1, 200000),
(6, 6, 2, 240000),
(7, 7, 1, 450000),
(8, 8, 4, 160000),
(9, 9, 2, 230000),
(10, 10, 3, 260000);
go

SELECT * FROM ChucVu;
SELECT * FROM NhanVien;
SELECT * FROM TaiKhoanNhanVien;
SELECT * FROM KhachHang;
SELECT * FROM ThuongHieu;
SELECT * FROM NhaCungCap;
SELECT * FROM SanPham;
SELECT * FROM MauSac;
SELECT * FROM KichThuoc;
SELECT * FROM ChiTietSanPham;
SELECT * FROM PhieuNhap;
SELECT * FROM ChiTietPhieuNhap;
SELECT * FROM PhieuXuat;
SELECT * FROM PhieuXuatChiTiet;























