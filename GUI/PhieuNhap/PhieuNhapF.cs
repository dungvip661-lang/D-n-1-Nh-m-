using System.Data;
using DuAn1_Nhom4.BLL;
using DuAn1_Nhom4.Models;

namespace DuAn1_Nhom4.GUI.Nhập_hàng
{
    public partial class PhieuNhapF : Form
    {

        private GenericBLL<ChiTietPhieuNhap> phieuNhapCtBLL;
        private GenericBLL<ChiTietSanPham> sanPhamBLL;
        private GenericBLL<PhieuNhap> phieuNhapBLL;
        decimal _tongTien = 0;
        private int maPN = 0;
        private int maCT = 0; // thêm biến toàn cục để lưu mã chi tiết sản phẩm
        private string trangThaiThanhToan = "Chưa thanh toán";
        private NhanVien _nhanVien;
        public PhieuNhapF(NhanVien nhanVien)
        {
            InitializeComponent();
            phieuNhapBLL = new GenericBLL<PhieuNhap>();
            phieuNhapCtBLL = new GenericBLL<ChiTietPhieuNhap>();
            sanPhamBLL = new GenericBLL<ChiTietSanPham>();
            _nhanVien = nhanVien;
        }

        private void LoadTrangThaiThanhToan()
        {
            cbTrangThai.Items.Clear();
            cbTrangThai.Items.Add("Tất cả");
            cbTrangThai.Items.Add("Đã thanh toán");
            cbTrangThai.Items.Add("Chưa thanh toán");
            cbTrangThai.Items.Add("Đã hủy");
            cbTrangThai.Text = trangThaiThanhToan;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadPhieuNhap();
            LoadTrangThaiThanhToan();

            // Kiểm tra vai trò ngay khi form load
            string vaiTro = _nhanVien.MaChucVuNavigation?.TenChucVu;
            if (vaiTro == "Nhân viên kiểm kho")
            {
                // Ẩn nút thanh toán hoàn toàn
                btnThanhToan.Visible = false;
                btnThanhToan.Enabled = false;
            }
            else if (vaiTro == "Quản lý kho" || vaiTro == "Quản trị viên")
            {
                // Cho phép hiển thị nút thanh toán
                btnThanhToan.Visible = true;
                btnThanhToan.Enabled = true;
            }
        }

        private void LoadPhieuNhap()
        {
            // 1. Lấy tất cả phiếu nhập kèm thông tin nhân viên để kiểm tra quyền
            var list = phieuNhapBLL.GetAll(x => x.MaNvNavigation);

            // 2. PHÂN QUYỀN: 
            // Nếu không phải là Quản trị viên hoặc Quản lý kho, thì chỉ lọc phiếu của chính mình
            string chucVu = _nhanVien.MaChucVuNavigation?.TenChucVu;

            if (chucVu != "Quản trị viên" && chucVu != "Quản lý kho")
            {
                list = list.Where(x => x.MaNv == _nhanVien.Id);
            }

            // 3. Lọc theo trạng thái thanh toán từ ComboBox
            if (trangThaiThanhToan != "Tất cả")
            {
                list = list.Where(x => x.TrangThaiThanhToan == trangThaiThanhToan);
            }

            dgvDanhSachPhieuNhap.Columns.Clear();

            // 4. Hiển thị lên DataGridView
            dgvDanhSachPhieuNhap.DataSource = list.Select((px, index) => new
            {
                STT = index + 1,
                MaPN = px.MaPhieuNhap,
                TenNV = px.MaNvNavigation?.HoTen ?? "N/A",
                NgayNhap = px.NgayNhap.ToString("dd/MM/yyyy"),
                TrangThai = px.TrangThaiThanhToan
            }).OrderByDescending(x => x.MaPN).ToList(); // Sắp xếp phiếu mới nhất lên đầu

            // Thiết lập Header
            dgvDanhSachPhieuNhap.Columns["MaPN"].HeaderText = "Mã phiếu nhập";
            dgvDanhSachPhieuNhap.Columns["TenNV"].HeaderText = "Tên nhân viên";
            dgvDanhSachPhieuNhap.Columns["NgayNhap"].HeaderText = "Ngày nhập";
            dgvDanhSachPhieuNhap.Columns["TrangThai"].HeaderText = "Trạng thái";

            // Tự động load chi tiết cho phiếu đầu tiên nếu có dữ liệu
            if (dgvDanhSachPhieuNhap.Rows.Count > 0)
            {
                maPN = Convert.ToInt32(dgvDanhSachPhieuNhap.Rows[0].Cells["MaPN"].Value);
                LoadCTPN(maPN);
            }
            else
            {
                dgvGioHang.DataSource = null; // Xóa giỏ hàng nếu không có phiếu nào
            }

            foreach (DataGridViewColumn column in dgvDanhSachPhieuNhap.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
        private void dgvGioHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // bỏ qua khi click header

            try
            {
                if (dgvGioHang.Columns.Contains("MaCT"))
                {
                    var cellValue = dgvGioHang.Rows[e.RowIndex].Cells["MaCT"].Value;
                    if (cellValue != null)
                    {
                        maCT = Convert.ToInt32(cellValue);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy mã chi tiết: " + ex.Message);
            }
        }
        private void dgvDanhSachPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
{
    // Kiểm tra nếu click vào tiêu đề cột thì bỏ qua
    if (e.RowIndex < 0) return;

    try
    {
        // 1. Lấy mã phiếu từ dòng được chọn
        maPN = Convert.ToInt32(dgvDanhSachPhieuNhap.Rows[e.RowIndex].Cells["MaPN"].Value);
        var phieu = phieuNhapBLL.GetById(maPN);
        if (phieu == null) return;

        // 2. LẤY VAI TRÒ CHÍNH XÁC
        string vaiTro = _nhanVien.MaChucVuNavigation?.TenChucVu;

        // Kiểm tra trạng thái phiếu
        bool chuaThanhToan = (phieu.TrangThaiThanhToan == "Chưa thanh toán");

        // Ẩn nút thanh toán mặc định
        btnThanhToan.Visible = false;
        btnThanhToan.Enabled = false;

        // 3. LOGIC PHÂN QUYỀN VÀ ĐIỀU KHIỂN GIAO DIỆN
        if (vaiTro == "Nhân viên kiểm kho")
        {
            // Nhân viên kiểm kho: KHÔNG có nút thanh toán
            btnThem.Enabled = chuaThanhToan;
            btnThayDoiSoLuong.Enabled = chuaThanhToan;
            btnXoaSanPham.Enabled = chuaThanhToan;
            btnHuyPhieu.Enabled = chuaThanhToan;
        }
        else if (vaiTro == "Quản lý kho" || vaiTro == "Quản trị viên")
        {
            // Quản lý/Admin: có quyền thanh toán
            btnThanhToan.Visible = true;
            btnThanhToan.Enabled = chuaThanhToan;

            btnThem.Enabled = chuaThanhToan;
            btnThayDoiSoLuong.Enabled = chuaThanhToan;
            btnXoaSanPham.Enabled = chuaThanhToan;
            btnHuyPhieu.Enabled = chuaThanhToan;
        }

        // 4. Load chi tiết sản phẩm của phiếu đó lên
        LoadCTPN(maPN);
    }
    catch (Exception ex)
    {
        MessageBox.Show("Lỗi khi chọn phiếu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}


        private void LoadCTPN(int maPX)
        {
            var list = phieuNhapCtBLL.GetAll(
                   x => x.MaCtspNavigation.MaSpNavigation,
                   x => x.MaCtspNavigation.MaMauNavigation!,
                   x => x.MaCtspNavigation.MaKichThuocNavigation!,
                   x => x.MaCtspNavigation.MaSpNavigation!,
                   x => x.MaPhieuNhapNavigation)
                   .Where(x => x.MaPhieuNhap == maPX)
                   .ToList();

            dgvGioHang.Columns.Clear();

            dgvGioHang.DataSource = list.Select((ct, index) => new
            {
                STT = index + 1,
                MaCT = ct.MaPhieuCt,   // Đặt đúng tên MaCT
                TenSP = ct.MaCtspNavigation?.MaSpNavigation?.TenSp ?? "",
                MauSac = ct.MaCtspNavigation?.MaMauNavigation?.TenMau ?? "",
                KichThuoc = ct.MaCtspNavigation?.MaKichThuocNavigation?.TenKichThuoc ?? "",
                SoLuong = ct.SoLuong,
                DonGia = ct.MaCtspNavigation?.DonGiaNhap.ToString("N0") + "đ",
                ThanhTien = (ct.SoLuong * (ct.MaCtspNavigation?.DonGiaNhap ?? 0)).ToString("N0") + "đ"
            }).ToList();

            dgvGioHang.Columns["MaCT"].HeaderText = "Mã chi tiết";
            dgvGioHang.Columns["TenSP"].HeaderText = "Tên sản phẩm";
            dgvGioHang.Columns["MauSac"].HeaderText = "Màu sắc";
            dgvGioHang.Columns["KichThuoc"].HeaderText = "Kích thước";
            dgvGioHang.Columns["SoLuong"].HeaderText = "Số lượng";
            dgvGioHang.Columns["DonGia"].HeaderText = "Đơn giá";
            dgvGioHang.Columns["ThanhTien"].HeaderText = "Thành tiền";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (maPN == 0)
            {
                MessageBox.Show("Vui lòng chọn hoặc tạo mới phiếu nhập!");
                return;
            }

            var phieu = phieuNhapBLL.GetById(maPN);
            if (phieu == null) return;

            // Sửa dòng này trong btnThem_Click
            if (phieu.TrangThaiThanhToan == "Đã thanh toán")
            {
                MessageBox.Show("Phiếu này đã thanh toán, không thể thêm sản phẩm!");
                return;
            }

            SanPhamF formSpham = new SanPhamF(this);
            formSpham.ShowDialog();

            LoadDataGioHang();
            TinhTongTien();
        }

        // Nếu bạn chưa có 2 hàm này, hãy thêm vào cuối file PhieuNhapF.cs:
        private void LoadDataGioHang()
        {
            dgvGioHang.DataSource = phieuNhapCtBLL.GetAll().Where(x => x.MaPhieuNhap == maPN).ToList();
        }

        private void TinhTongTien()
        {
            try
            {
                // 1. Lấy danh sách chi tiết dựa trên MaPhieuNhap (Khớp với Model bạn gửi)
                var chiTiet = phieuNhapCtBLL.GetAll().Where(x => x.MaPhieuNhap == maPN).ToList();

                // 2. Tính tổng: Số lượng * DonGia (Sửa GiaNhap thành DonGia)
                decimal tongTien = chiTiet.Sum(x => x.SoLuong * x.DonGia);

                // 3. Hiển thị lên Label lbTongTien
                lbTongTien.Text = tongTien.ToString("N0") + " VNĐ";
            }
            catch (Exception ex)
            {
                lbTongTien.Text = "0 VNĐ";
            }
        }

        public void ThemGioHang(int maCtsp, int soLuong, decimal donGia)
        {   // Kiểm tra mã sản phẩm và số lượng
            var spTonTai = phieuNhapCtBLL.GetAll()
                .Any(x => x.MaPhieuNhap == maPN && x.MaCtsp == maCtsp);
            if (spTonTai)
            {
                MessageBox.Show("Sản phẩm này đã có trong phiếu nhập, vui lòng chỉnh sửa số lượng thay vì thêm mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            phieuNhapCtBLL.Add(new ChiTietPhieuNhap() // Tạo mới chi tiết phiếu nhập
            {
                MaPhieuNhap = maPN,
                MaCtsp = maCtsp,
                SoLuong = soLuong,
                DonGia = donGia,
            });

            LoadCTPN(maPN);// Tải lại danh sách chi tiết phiếu nhập
        }
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            // 1. Lấy phiếu nhập hiện tại
            var phieuNhap = phieuNhapBLL.GetById(maPN);
            if (phieuNhap == null)
            {
                MessageBox.Show("Không tìm thấy phiếu nhập.");
                return;
            }

            var sp = phieuNhapCtBLL.GetAll().Where(x => x.MaPhieuNhap == maPN).ToList();
            if (sp.Count == 0)
            {
                MessageBox.Show("Phiếu nhập này chưa có sản phẩm nào, không thể thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                 "Bạn có chắc muốn hoàn thành thanh toán?",
                 "Xác nhận hoàn thành",
                 MessageBoxButtons.YesNo,
                 MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Lấy tất cả chi tiết phiếu nhập của phiếu này
                var chiTiets = phieuNhapCtBLL.GetAll().Where(x => x.MaPhieuNhap == maPN);

                // Cập nhật số lượng sản phẩm trong kho
                foreach (var chiTiet in chiTiets)
                {
                    var chiTietSanPham = sanPhamBLL.GetById(chiTiet.MaCtsp);
                    if (chiTietSanPham == null) continue;

                    chiTietSanPham.SoLuong += chiTiet.SoLuong;
                    sanPhamBLL.Update(chiTietSanPham);
                }

                // Cập nhật trạng thái phiếu
                phieuNhap.TrangThaiThanhToan = "Đã thanh toán";
                phieuNhapBLL.Update(phieuNhap);

                MessageBox.Show("Hoàn thành thanh toán thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPhieuNhap();
            }
        }

        private void btnThemPhieuNhap_Click(object sender, EventArgs e)
        {
            var phieuMoi = new PhieuNhap
            {
                NgayNhap = DateOnly.FromDateTime(DateTime.Now),
                TrangThaiThanhToan = "Chưa thanh toán",
                MaNv = _nhanVien.Id
            };

            phieuNhapBLL.Add(phieuMoi);
            MessageBox.Show("Thêm phiếu nhập thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Cập nhật lại filter để thấy phiếu mới
            trangThaiThanhToan = "Chưa thanh toán";
            cbTrangThai.SelectedItem = "Chưa thanh toán";

            LoadPhieuNhap();

            // Tự động chọn dòng cuối cùng (phiếu vừa tạo)
            if (dgvDanhSachPhieuNhap.Rows.Count > 0)
            {
                int lastIndex = dgvDanhSachPhieuNhap.Rows.Count - 1;
                dgvDanhSachPhieuNhap.Rows[lastIndex].Selected = true;
                maPN = Convert.ToInt32(dgvDanhSachPhieuNhap.Rows[lastIndex].Cells["MaPN"].Value);
                LoadCTPN(maPN);
            }
        }
        private void cbTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            trangThaiThanhToan = cbTrangThai!.SelectedItem!.ToString()!;
            LoadPhieuNhap();
            maPN = 0;

            dgvGioHang.DataSource = null;
            dgvGioHang.Columns.Clear();

            //btnThem.Enabled = (trangThaiThanhToan == "Chưa thanh toán");
        }
        private void btnThayDoiSoLuong_Click(object sender, EventArgs e)
        {
            if (maCT == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần chỉnh sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dgvGioHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một dòng để chỉnh sửa số lượng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var ct = phieuNhapCtBLL.GetById(maCT);
            if (ct == null) return;

            var phieuNhap = phieuNhapBLL.GetById(ct.MaPhieuNhap); // Giả sử ct có MaPn

            PhieuNhapSoLuong frm = new PhieuNhapSoLuong(ct.SoLuong);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ct.SoLuong = frm.SoLuongMoi;
                phieuNhapCtBLL.Update(ct);
                MessageBox.Show("Cập nhật thành công.");
                LoadCTPN(maPN);
            }
        }
        private void btnXoaSanPham_Click(object sender, EventArgs e)
        {
            if (maCT == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var ct = phieuNhapCtBLL.GetById(maCT);
            if (ct == null) return;
            var phieuNhap = phieuNhapBLL.GetById(ct.MaPhieuNhap);

            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn xóa mặt hàng này?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                phieuNhapCtBLL.Delete(maCT);
                MessageBox.Show("Xóa thành công.");
                LoadCTPN(maPN);
                maCT = 0; // reset sau khi xóa
            }
        }

        private void btnHuyPhieu_Click(object sender, EventArgs e)
        {
            var phieuNhap = phieuNhapBLL.GetById(maPN);
            if (phieuNhap == null)
            {
                MessageBox.Show("Không tìm thấy phiếu nhập để hủy.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn hủy phiếu nhập này hay không?",
                "Xác nhận hủy",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                phieuNhap!.TrangThaiThanhToan = "Đã hủy";
                phieuNhapBLL.Update(phieuNhap);

                MessageBox.Show("Hủy thành công.");
                LoadPhieuNhap();

                dgvGioHang.DataSource = null;
                dgvGioHang.Columns.Clear();
            }
        }

        private void dgvDanhSachPhieuNhap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
