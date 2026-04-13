using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DuAn1_Nhom4.Models;
namespace DuAn1_Nhom4.GUI
{
    public partial class ThongKe : Form
    {
        public ThongKe()
        {
            InitializeComponent();
        }
        private void LoadThongTinTongQuan()
        {
            using (var db = new QuanLyKhoHangQuanAoContext())
            {
                // Tổng phiếu xuất
                int tongPhieuXuat = db.PhieuXuats.Count();

                // Tổng phiếu nhập
                int tongPhieuNhap = db.PhieuNhaps.Count();

                // Tổng số lượng tồn kho (tổng tất cả số lượng còn trong ChiTietSanPham)
                int tongSoLuongTonKho = db.ChiTietSanPhams.Sum(ct => ct.SoLuong);

                // Tổng số khách hàng
                int tongKhachHang = db.KhachHangs.Count();

                // Gán vào các Label
                lblTongPhieuXuat.Text = tongPhieuXuat.ToString();
                lblTongPhieuNhap.Text = tongPhieuNhap.ToString();
                lblTonKho.Text = tongSoLuongTonKho.ToString();
                lblKhachHang.Text = tongKhachHang.ToString();
            }
        }
        private void LoadTongDoanhThu()
        {
            using (var db = new QuanLyKhoHangQuanAoContext())
            {
                var tongDoanhThu = db.PhieuXuatChiTiets
                    .Sum(ct => ct.SoLuong * ct.GiaBan);

                lblTongDoanhThu.Text = tongDoanhThu.ToString("N0") + " đ"; // Định dạng tiền VNĐ
            }
        }
        private List<NhanVienThongKeDTO> LayDanhSachThongKeNhanVien(DateTime tuNgay, DateTime denNgay, bool isGetAll = false)
        {
            DateOnly start = DateOnly.FromDateTime(tuNgay);
            DateOnly end = DateOnly.FromDateTime(denNgay);

            using (var db = new QuanLyKhoHangQuanAoContext())
            {
                var query = from nv in db.NhanViens
                            select new NhanVienThongKeDTO
                            {
                                // Đổi tên hiển thị thành Họ Tên
                                TenDangNhap = nv.HoTen,

                                // Nếu isGetAll = true thì count hết, ngược lại thì lọc theo ngày
                                SoDonTiepNhan = isGetAll
                                    ? nv.PhieuXuats.Count()
                                    : nv.PhieuXuats.Count(px => px.NgayXuat >= start && px.NgayXuat <= end),

                                SoDonThanhToan = isGetAll
                                    ? nv.PhieuXuats.Count(px => px.TrangThaiThanhToan == "Đã thanh toán")
                                    : nv.PhieuXuats.Count(px => px.NgayXuat >= start && px.NgayXuat <= end && px.TrangThaiThanhToan == "Đã thanh toán"),

                                TongDoanhThu = nv.PhieuXuats
                                    .Where(px => isGetAll || (px.NgayXuat >= start && px.NgayXuat <= end))
                                    .SelectMany(px => px.PhieuXuatChiTiets)
                                    .Sum(ct => (decimal?)ct.SoLuong * ct.GiaBan) ?? 0
                            };

                return query.ToList();
            }
        }
        private void HienThiLenLuoiNhanVien(List<NhanVienThongKeDTO> data, string loaiLoc)
        {
            string khoangThoiGian = $"{dtpTuNgay.Value:dd/MM/yyyy} - {dtpDenNgay.Value:dd/MM/yyyy}";

            var displayData = data.Select(nv => new
            {
                // Cột 1: Giá trị (Số đơn hoặc Tiền)
                GiaTri = loaiLoc == "DonHang" ? nv.SoDonThanhToan.ToString() : nv.TongDoanhThu.ToString("N0") + " đ",
                // Cột 2: Họ tên
                HoTen = nv.TenDangNhap,
                // Cột 3: Thời gian
                ThoiGian = khoangThoiGian
            }).ToList();

            dataGridView1.DataSource = displayData;

            // Đặt lại tên cột cho dataGridView1
            dataGridView1.Columns["GiaTri"].HeaderText = loaiLoc == "DonHang" ? "Số Đơn" : "Doanh Thu";
            dataGridView1.Columns["HoTen"].HeaderText = "Nhân Viên";
            dataGridView1.Columns["ThoiGian"].HeaderText = "Thời Gian";

            // Căn lề cho đẹp
            dataGridView1.Columns["GiaTri"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["ThoiGian"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void HienThiDuLieu(List<NhanVienThongKeDTO> data)
        {
            dgvNhanVien.DataSource = data.Select((nv, index) => new
            {
                STT = index + 1,
                HoTen = nv.TenDangNhap, // Hiển thị dưới tên HoTen
                SoDonTiepNhan = nv.SoDonTiepNhan,
                SoDonThanhToan = nv.SoDonThanhToan,
                DoanhThu = nv.TongDoanhThu.ToString("N0") + " đ",
            }).ToList();

            // Đặt Header Text cho bảng chính
            dgvNhanVien.Columns["HoTen"].HeaderText = "Họ Tên Nhân Viên";
            dgvNhanVien.Columns["SoDonTiepNhan"].HeaderText = "Số Đơn Tiếp Nhận";
            dgvNhanVien.Columns["SoDonThanhToan"].HeaderText = "Số Đơn Thanh Toán";
            dgvNhanVien.Columns["DoanhThu"].HeaderText = "Doanh Thu";
        }
        private void LoadDoanhThuMacDinh()
        {
            DateOnly tuNgay = DateOnly.FromDateTime(DateTime.Today.AddMonths(-1));
            DateOnly denNgay = DateOnly.FromDateTime(DateTime.Today);

            using (var db = new QuanLyKhoHangQuanAoContext())
            {
                var phieuXuatTrongKhoang = db.PhieuXuats
                    .Where(p => p.NgayXuat >= tuNgay && p.NgayXuat <= denNgay)
                    .ToList();

                int soDonHang = phieuXuatTrongKhoang.Count;

                int soKhachHang = phieuXuatTrongKhoang
                    .Select(p => p.MaKh)
                    .Distinct()
                    .Count();

                var chiTietPhieu = phieuXuatTrongKhoang
                    .SelectMany(p => db.PhieuXuatChiTiets.Where(ct => ct.MaPhieuXuat == p.MaPhieuXuat))
                    .ToList();

                decimal doanhThu = chiTietPhieu.Sum(ct => ct.SoLuong * ct.GiaBan);

                dgvDoanhThu.DataSource = new List<DoanhThuDTO>

        {
            new DoanhThuDTO
            {
                ThoiGian = $"{tuNgay:dd/MM/yyyy} - {denNgay:dd/MM/yyyy}",
                SoKhachHang = soKhachHang,
                SoDonHang = soDonHang,
                DoanhThu = doanhThu
            }
        };
                DinhDangLuoiDoanhThu();

                // Định dạng doanh thu
                dgvDoanhThu.Columns["DoanhThu"].DefaultCellStyle.Format = "N0";
                dgvDoanhThu.Columns["DoanhThu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void DinhDangLuoiDoanhThu()
        {
            if (dgvDoanhThu.Columns.Count == 0) return;

            // Cấu hình chung cho bảng
            dgvDoanhThu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvDoanhThu.AllowUserToAddRows = false; // Chặn dòng trống cuối bảng
            dgvDoanhThu.ReadOnly = true;            // Chỉ cho xem, không cho sửa trực tiếp
            dgvDoanhThu.RowHeadersVisible = false;  // Ẩn cột đầu dòng cho gọn

            // 1. Cột Khoảng Thời Gian (Cho chiếm hết không gian còn lại)
            if (dgvDoanhThu.Columns.Contains("ThoiGian"))
            {
                dgvDoanhThu.Columns["ThoiGian"].HeaderText = "Khoảng Thời Gian";
                dgvDoanhThu.Columns["ThoiGian"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvDoanhThu.Columns["ThoiGian"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }

            // 2. Cột Số Khách Hàng
            if (dgvDoanhThu.Columns.Contains("SoKhachHang"))
            {
                dgvDoanhThu.Columns["SoKhachHang"].HeaderText = "Số Khách";
                dgvDoanhThu.Columns["SoKhachHang"].Width = 150;
                dgvDoanhThu.Columns["SoKhachHang"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // 3. Cột Số Đơn Hàng
            if (dgvDoanhThu.Columns.Contains("SoDonHang"))
            {
                dgvDoanhThu.Columns["SoDonHang"].HeaderText = "Số Đơn";
                dgvDoanhThu.Columns["SoDonHang"].Width = 150;
                dgvDoanhThu.Columns["SoDonHang"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // 4. Cột Doanh Thu (Quan trọng nhất)
            if (dgvDoanhThu.Columns.Contains("DoanhThu"))
            {
                dgvDoanhThu.Columns["DoanhThu"].HeaderText = "Doanh Thu";
                dgvDoanhThu.Columns["DoanhThu"].Width = 180;
                dgvDoanhThu.Columns["DoanhThu"].DefaultCellStyle.Format = "N0"; // Định dạng 1.000.000
                dgvDoanhThu.Columns["DoanhThu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDoanhThu.Columns["DoanhThu"].DefaultCellStyle.ForeColor = Color.DarkRed; // Làm nổi bật số tiền
            }
        }
        private void ThongKe_Load(object sender, EventArgs e)
        {
            LoadThongTinTongQuan();
            LoadTongDoanhThu();
            LoadDoanhThuMacDinh();

            cmbBoLocNhanVien.Items.Clear();
            cmbBoLocNhanVien.Items.Add("Nhân viên có đơn nhiều nhất");
            cmbBoLocNhanVien.Items.Add("Nhân viên có doanh thu cao nhất");
            cmbBoLocNhanVien.SelectedIndex = 0;

            // 1. Dữ liệu bảng nhỏ (dataGridView1): Vẫn lọc theo ngày
            var danhSachTheoNgay = LayDanhSachThongKeNhanVien(dtpTuNgay.Value, dtpDenNgay.Value, false);
            HienThiLenLuoiNhanVien(danhSachTheoNgay, "DonHang");

            // 2. Dữ liệu bảng lớn (dgvNhanVien): Lấy TẤT CẢ (isGetAll = true)
            var danhSachTong = LayDanhSachThongKeNhanVien(dtpTuNgay.Value, dtpDenNgay.Value, true);
            HienThiDuLieu(danhSachTong);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            // 1. Lấy dữ liệu ngày từ giao diện
            DateTime tuNgayDT = dtpTuNgay.Value.Date;
            DateTime denNgayDT = dtpDenNgay.Value.Date;

            if (tuNgayDT > denNgayDT)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateOnly start = DateOnly.FromDateTime(tuNgayDT);
            DateOnly end = DateOnly.FromDateTime(denNgayDT);

            // KHAI BÁO BIẾN Ở ĐÂY ĐỂ DÙNG ĐƯỢC CHO CẢ HÀM
            decimal doanhThu = 0;

            using (var db = new QuanLyKhoHangQuanAoContext())
            {
                var phieuXuatTrongKhoang = db.PhieuXuats
                    .Where(p => p.NgayXuat >= start && p.NgayXuat <= end)
                    .ToList();

                int soDonHang = phieuXuatTrongKhoang.Count;
                int soKhachHang = phieuXuatTrongKhoang.Select(p => p.MaKh).Distinct().Count();

                var maPhieuList = phieuXuatTrongKhoang.Select(p => p.MaPhieuXuat).ToList();

                // Gán giá trị vào biến đã khai báo bên trên
                doanhThu = db.PhieuXuatChiTiets
                    .Where(ct => maPhieuList.Contains(ct.MaPhieuXuat))
                    .Sum(ct => (decimal?)ct.SoLuong * ct.GiaBan) ?? 0;

                dgvDoanhThu.DataSource = new List<DoanhThuDTO>
        {
            new DoanhThuDTO
            {
                ThoiGian = $"{start:dd/MM/yyyy} - {end:dd/MM/yyyy}",
                SoKhachHang = soKhachHang,
                SoDonHang = soDonHang,
                DoanhThu = doanhThu
            }
        };
                DinhDangLuoiDoanhThu();

                var danhSachTong = LayDanhSachThongKeNhanVien(tuNgayDT, denNgayDT, true);
                HienThiDuLieu(danhSachTong);

                var danhSachTheoNgay = LayDanhSachThongKeNhanVien(tuNgayDT, denNgayDT, false);
                string loaiLoc = cmbBoLocNhanVien.SelectedIndex == 1 ? "DoanhThu" : "DonHang";

                if (loaiLoc == "DonHang")
                    danhSachTheoNgay = danhSachTheoNgay.OrderByDescending(x => x.SoDonThanhToan).ToList();
                else
                    danhSachTheoNgay = danhSachTheoNgay.OrderByDescending(x => x.TongDoanhThu).ToList();

                HienThiLenLuoiNhanVien(danhSachTheoNgay, loaiLoc);
            }

            // Bây giờ dòng này sẽ không còn lỗi nữa
            lblTongDoanhThu.Text = doanhThu.ToString("N0") + " đ";
        }
        private void cmbBoLocNhanVien_SelectedIndexChanged(object sender, EventArgs e)
{
    // SỬA TẠI ĐÂY: Truyền tham số ngày vào hàm
    var danhSach = LayDanhSachThongKeNhanVien(dtpTuNgay.Value, dtpDenNgay.Value);

    if (cmbBoLocNhanVien.SelectedItem == null) return;
    string luaChon = cmbBoLocNhanVien.SelectedItem.ToString();

    if (luaChon == "Nhân viên có đơn nhiều nhất")
    {
        // Sắp xếp theo số đơn tiếp nhận giảm dần và hiển thị lên dataGridView1
        var all = danhSach.OrderByDescending(x => x.SoDonTiepNhan).ToList();
        HienThiLenLuoiNhanVien(all, "DonHang"); // Dùng hàm hiển thị lên dataGridView1 cho đồng bộ
    }
    else if (luaChon == "Nhân viên có doanh thu cao nhất")
    {
        // Sắp xếp theo doanh thu giảm dần và hiển thị lên dataGridView1
        var all = danhSach.OrderByDescending(x => x.TongDoanhThu).ToList();
        HienThiLenLuoiNhanVien(all, "DoanhThu");
    }
}

        private void lblTongPhieuXuat_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }
        private void btnThongKeNhanh_Click(object sender, EventArgs e)
        {
            // 1. Lấy dữ liệu thô từ DB theo ngày trên giao diện
            var danhSach = LayDanhSachThongKeNhanVien(dtpTuNgay.Value, dtpDenNgay.Value);

            if (cmbBoLocNhanVien.SelectedItem == null) return;
            string luaChon = cmbBoLocNhanVien.SelectedItem.ToString();

            // 2. Sắp xếp và CHỈ hiển thị lên dataGridView1
            if (luaChon == "Nhân viên có đơn nhiều nhất")
            {
                var sorted = danhSach.OrderByDescending(x => x.SoDonThanhToan).ToList();
                HienThiLenLuoiNhanVien(sorted, "DonHang");
            }
            else if (luaChon == "Nhân viên có doanh thu cao nhất")
            {
                var sorted = danhSach.OrderByDescending(x => x.TongDoanhThu).ToList();
                HienThiLenLuoiNhanVien(sorted, "DoanhThu");
            }
        }
        //private void ThucHienThongKeDoanhThuChung()
        //{
        //    DateOnly tuNgay = DateOnly.FromDateTime(dtpTuNgay.Value.Date);
        //    DateOnly denNgay = DateOnly.FromDateTime(dtpDenNgay.Value.Date);

        //    using (var db = new QuanLyKhoHangQuanAoContext())
        //    {
        //        var phieuXuatTrongKhoang = db.PhieuXuats
        //            .Where(p => p.NgayXuat >= tuNgay && p.NgayXuat <= denNgay)
        //            .ToList();

        //        int soDonHang = phieuXuatTrongKhoang.Count;
        //        int soKhachHang = phieuXuatTrongKhoang.Select(p => p.MaKh).Distinct().Count();

        //        var chiTietPhieu = phieuXuatTrongKhoang
        //            .SelectMany(p => db.PhieuXuatChiTiets.Where(ct => ct.MaPhieuXuat == p.MaPhieuXuat))
        //            .ToList();

        //        decimal doanhThu = chiTietPhieu.Sum(ct => ct.SoLuong * ct.GiaBan);

        //        dgvDoanhThu.DataSource = new List<DoanhThuDTO>
        //{
        //    new DoanhThuDTO
        //    {
        //        ThoiGian = $"{tuNgay:dd/MM/yyyy} - {denNgay:dd/MM/yyyy}",
        //        SoKhachHang = soKhachHang,
        //        SoDonHang = soDonHang,
        //        DoanhThu = doanhThu
        //    }
        //};
        //        DinhDangLuoiDoanhThu();
        //    }
        //}
        //private void ThucHienThongKeNhanVien()
        //{
        //    if (cmbBoLocNhanVien.SelectedItem == null) return;

        //    // Lấy dữ liệu từ DB dựa trên ngày hiện tại trên giao diện
        //    var danhSach = LayDanhSachThongKeNhanVien(dtpTuNgay.Value, dtpDenNgay.Value);
        //    string luaChon = cmbBoLocNhanVien.SelectedItem.ToString();

        //    // Sắp xếp dữ liệu từ LỚN đến BÉ theo yêu cầu của bạn
        //    if (luaChon == "Nhân viên có đơn nhiều nhất")
        //    {
        //        var sorted = danhSach.OrderByDescending(x => x.SoDonTiepNhan).ToList();
        //        HienThiThongKeNhanVien(sorted, "DonHang");
        //    }
        //    else if (luaChon == "Nhân viên có doanh thu cao nhất")
        //    {
        //        var sorted = danhSach.OrderByDescending(x => x.TongDoanhThu).ToList();
        //        HienThiThongKeNhanVien(sorted, "DoanhThu");
        //    }
        //}
    }
}
