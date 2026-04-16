using System.Data;
using DuAn1_Nhom4.BLL;
using DuAn1_Nhom4.Models;

namespace DuAn1_Nhom4.GUI
{
    public partial class FormLichSu : Form
    {
        private GenericBLL<PhieuXuat> _pxBLL = new GenericBLL<PhieuXuat>();
        private GenericBLL<PhieuNhap> _pnBLL = new GenericBLL<PhieuNhap>();
        private GenericBLL<ChiTietPhieuNhap> _ctpn = new GenericBLL<ChiTietPhieuNhap>();
        private GenericBLL<PhieuXuatChiTiet> _ctpx = new GenericBLL<PhieuXuatChiTiet>();
        private NhanVien _currentUser;
        public FormLichSu(NhanVien nv) // Thêm tham số nv ở đây
        {
            InitializeComponent();
            _currentUser = nv; // Gán giá trị cho biến toàn cục
        }
        private void LoadCB()
        {
            // 1. Xóa sạch dữ liệu cũ
            comboBox1.Items.Clear();
            cbTrangthai.Items.Clear();
            cbNgayloc.Items.Clear();

            string tenChucVu = _currentUser.MaChucVuNavigation?.TenChucVu;

            // 2. Phân quyền Loại phiếu dựa trên chức vụ
            if (tenChucVu == "Nhân viên bán hàng")
            {
                comboBox1.Items.Add("Phiếu xuất");
            }
            else if (tenChucVu == "Nhân viên kiểm kho")
            {
                comboBox1.Items.Add("Phiếu nhập");
            }
            else // Quản trị viên hoặc các chức vụ cao cấp khác
            {
                comboBox1.Items.Add("Phiếu nhập");
                comboBox1.Items.Add("Phiếu xuất");
            }

            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;

            // 3. Load danh mục Trạng thái
            cbTrangthai.Items.Add("Tất cả");
            cbTrangthai.Items.Add("Chưa thanh toán");
            cbTrangthai.Items.Add("Đã thanh toán");
            cbTrangthai.Items.Add("Đã hủy");
            cbTrangthai.SelectedIndex = 0;

            // 4. Load danh mục Lọc ngày
            cbNgayloc.Items.Add("Tất cả");
            cbNgayloc.Items.Add("Khoảng thời gian");
            cbNgayloc.SelectedIndex = 0;
        }
        private void FormLichSu_Load(object sender, EventArgs e)
        {
            LoadCB();
            ApplyFilters(); // Gọi hàm lọc khi form được tải
            if (dgvPhieu.Rows.Count >= 0)
            {
                dgvPhieu.ClearSelection(); // Xóa lựa chọn cũ trong DataGridView phiếu
                dgvPhieu_CellClick(dgvPhieu, new DataGridViewCellEventArgs(0, 0)); // Gọi sự kiện click để hiển thị chi tiết
            }
        }




        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            cbTrangthai.SelectedItem = "Tất cả"; // Đặt lại trạng thái về "Tất cả" khi thay đổi loại phiếu
            ApplyFilters(); // Gọi hàm lọc khi thay đổi loại phiếu
            dgvCt.DataSource = null; // Xóa dữ liệu cũ trong DataGridView chi tiết
            if (dgvPhieu.Rows.Count > 0)
            {
                dgvPhieu.ClearSelection();
                dgvPhieu.Rows[0].Selected = true;

                dgvPhieu_CellClick(dgvPhieu, new DataGridViewCellEventArgs(0, 0));
            }
        }
        private void LoadCTPX(int maPX)
        {
            var list = _ctpx.GetAll(
                x => x.MaCtspNavigation.MaSpNavigation,
                x => x.MaCtspNavigation.MaMauNavigation,
                x => x.MaCtspNavigation.MaKichThuocNavigation,
                x => x.MaPhieuXuatNavigation)
                .Where(x => x.MaPhieuXuat == maPX)
                .ToList();

            dgvCt.DataSource = list.Select((ct, index) => new
            {
                STT = index + 1,
                MaCT = ct.MaCt,
                TenSP = ct.MaCtspNavigation?.MaSpNavigation?.TenSp ?? "",
                MauSac = ct.MaCtspNavigation?.MaMauNavigation?.TenMau ?? "",
                KichThuoc = ct.MaCtspNavigation?.MaKichThuocNavigation?.TenKichThuoc ?? "",
                SoLuong = ct.SoLuong,
                // Lấy giá bán từ chi tiết phiếu xuất
                DonGia = ct.GiaBan,
                ThanhTien = ct.SoLuong * ct.GiaBan
            }).ToList();

            dgvCt.Columns["STT"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCt.Columns["MaCT"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCt.Columns["TenSP"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCt.Columns["MauSac"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCt.Columns["KichThuoc"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCt.Columns["DonGia"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCt.Columns["ThanhTien"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


            dgvCt.Columns["SoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCt.Columns["DonGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCt.Columns["ThanhTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCt.Columns["STT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCt.Columns["MaCT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvCt.Columns["MaCT"].HeaderText = "Mã chi tiết";
            dgvCt.Columns["TenSP"].HeaderText = "Tên sản phẩm";
            dgvCt.Columns["MauSac"].HeaderText = "Màu sắc";
            dgvCt.Columns["KichThuoc"].HeaderText = "Kích thước";
            dgvCt.Columns["SoLuong"].HeaderText = "Số lượng";
            dgvCt.Columns["DonGia"].HeaderText = "Đơn giá";
            dgvCt.Columns["ThanhTien"].HeaderText = "Thành tiền";


        }

        private void LoadCTPN(int maPN)
        {
            var list = _ctpn.GetAll(
               x => x.MaCtspNavigation.MaSpNavigation,
               x => x.MaCtspNavigation.MaMauNavigation,
               x => x.MaCtspNavigation.MaKichThuocNavigation,
               x => x.MaPhieuNhapNavigation)
               .Where(x => x.MaPhieuNhap == maPN)
               .ToList();
            dgvCt.DataSource = list.Select((ctpn, index) => new
            {
                STT = index + 1,
                MaCTPN = ctpn.MaPhieuNhap,
                TenSp = ctpn.MaCtspNavigation.MaSpNavigation.TenSp,
                SoLuong = ctpn.SoLuong,
                DonGia = ctpn.DonGia,
                ThanhTien = ctpn.SoLuong * ctpn.DonGia
            }).ToList();

            dgvCt.Columns["STT"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCt.Columns["MaCTPN"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCt.Columns["TenSp"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCt.Columns["SoLuong"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCt.Columns["DonGia"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCt.Columns["ThanhTien"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


            dgvCt.Columns["SoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCt.Columns["DonGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCt.Columns["ThanhTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCt.Columns["STT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCt.Columns["MaCTPN"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvCt.Columns["MaCTPN"].HeaderText = "Mã chi tiết";
            dgvCt.Columns["TenSp"].HeaderText = "Tên sản phẩm";
            dgvCt.Columns["SoLuong"].HeaderText = "Số lượng";
            dgvCt.Columns["DonGia"].HeaderText = "Đơn giá";
            dgvCt.Columns["ThanhTien"].HeaderText = "Thành tiền";

        }

        private void dgvPhieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 1. Kiểm tra chỉ số dòng hợp lệ
            if (e.RowIndex < 0 || e.RowIndex >= dgvPhieu.Rows.Count)
            {
                return;
            }

            // 2. Lấy loại phiếu đang chọn hiện tại
            string loaiPhieu = comboBox1.Text;
            var selectedRow = dgvPhieu.Rows[e.RowIndex];

            try
            {
                // --- TRƯỜNG HỢP XEM CHI TIẾT PHIẾU NHẬP ---
                if (loaiPhieu == "Phiếu nhập")
                {
                    if (selectedRow.Cells["MaPN"].Value == null) return;

                    int maPN = Convert.ToInt32(selectedRow.Cells["MaPN"].Value);
                    var pn = _pnBLL.GetById(maPN);

                    if (pn != null)
                    {
                        LoadCTPN(maPN);

                        labelMaNV.Text = "Mã nhân viên: " + (pn.MaNvNavigation?.Id.ToString() ?? "N/A");
                        labelTenNV.Text = "Tên nhân viên: " + (pn.MaNvNavigation?.HoTen ?? "N/A");
                        labelNgayTao.Text = "Ngày tạo: " + pn.NgayNhap.ToString("dd/MM/yyyy");
                        labelTrangThai.Text = "Trạng thái: " + pn.TrangThaiThanhToan;

                        var tongTien = _ctpn.GetAll()
                            .Where(x => x.MaPhieuNhap == maPN)
                            .Sum(x => x.SoLuong * x.DonGia);

                        labelTongTien.Text = "Tổng tiền: " + tongTien.ToString("N0") + " VNĐ";

                        // Ẩn các label chỉ dành cho Phiếu xuất
                        labelTenSP.Text = "";
                        labelSoLuong.Text = "";
                        labelDonGia.Text = "";
                        labelLai.Text = "";
                    }
                }
                // --- TRƯỜNG HỢP XEM CHI TIẾT PHIẾU XUẤT ---
                else if (loaiPhieu == "Phiếu xuất")
                {
                    if (selectedRow.Cells["MaPX"].Value == null) return;

                    int maPX = Convert.ToInt32(selectedRow.Cells["MaPX"].Value);
                    var px = _pxBLL.GetById(maPX);

                    if (px != null)
                    {
                        var chiTiets = _ctpx.GetAll().Where(x => x.MaPhieuXuat == maPX).ToList();
                        LoadCTPX(maPX);

                        labelMaNV.Text = "Mã khách hàng: " + (px.MaKhNavigation?.MaKh.ToString() ?? "N/A");
                        labelTenNV.Text = "Tên khách hàng: " + (px.MaKhNavigation?.Ten ?? "N/A");
                        labelNgayTao.Text = "Ngày xuất: " + px.NgayXuat.ToString("dd/MM/yyyy");
                        labelTrangThai.Text = "Trạng thái: " + px.TrangThaiThanhToan;

                        var tongTien = chiTiets.Sum(x => x.SoLuong * x.GiaBan);
                        labelTongTien.Text = "Tổng tiền: " + tongTien.ToString("N0") + " VNĐ";

                        // --- HIỂN THỊ THÊM THÔNG TIN SẢN PHẨM ---
                        if (chiTiets.Any())
                        {
                            var ct = chiTiets.First(); // lấy sản phẩm đầu tiên

                            labelTenSP.Text = "Tên sản phẩm: " + (ct.MaCtspNavigation?.MaSpNavigation?.TenSp ?? "N/A");
                            labelSoLuong.Text = "Số lượng: " + ct.SoLuong;
                            labelDonGia.Text = "Đơn giá: " + ct.GiaBan.ToString("N0") + " VNĐ";

                            decimal giaNhap = ct.MaCtspNavigation?.DonGiaNhap ?? 0;
                            if (giaNhap > 0)
                            {
                                decimal lai = ((ct.GiaBan / giaNhap) - 1) * 100;
                                labelLai.Text = "Lãi: " + lai.ToString("N0") + "%";
                            }
                            else
                            {
                                labelLai.Text = "Lãi: N/A";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị chi tiết: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnTk_Click(object sender, EventArgs e)
        {

            ApplyFilters(); // Gọi hàm lọc khi nhấn nút tìm kiếm
        }

        private void cbTrangthai_SelectedIndexChanged(object sender, EventArgs e)
        {


            ApplyFilters(); // Gọi hàm lọc khi thay đổi trạng thái
        }
        private void ApplyFilters()
        {
            if (_currentUser == null) return;

            string loaiPhieu = comboBox1.Text;
            string trangThai = cbTrangthai.Text;
            string tenChucVu = _currentUser.MaChucVuNavigation?.TenChucVu;
            int ngayLocIndex = cbNgayloc.SelectedIndex;

            DateOnly tuNgay = DateOnly.FromDateTime(DateTime.MinValue);
            DateOnly denNgay = DateOnly.FromDateTime(DateTime.MaxValue);

            if (ngayLocIndex == 1) // Khoảng thời gian
            {
                tuNgay = DateOnly.FromDateTime(dateTimePicker1.Value.Date);
                denNgay = DateOnly.FromDateTime(dateTimePicker2.Value.Date);
                if (tuNgay > denNgay)
                {
                    MessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // --- XỬ LÝ LỌC PHIẾU NHẬP ---
            if (loaiPhieu == "Phiếu nhập")
            {
                var query = _pnBLL.GetAll(x => x.MaNvNavigation);

                // PHÂN QUYỀN: Nếu không phải Quản trị viên, chỉ xem phiếu nhập của CHÍNH MÌNH
                if (tenChucVu != "Quản trị viên")
                {
                    query = query.Where(pn => pn.MaNv == _currentUser.Id);
                }

                if (trangThai != "Tất cả")
                {
                    query = query.Where(pn => pn.TrangThaiThanhToan == trangThai);
                }

                if (ngayLocIndex == 1)
                {
                    query = query.Where(pn => pn.NgayNhap >= tuNgay && pn.NgayNhap <= denNgay);
                }

                dgvPhieu.DataSource = query.Select((pn, index) => new
                {
                    STT = index + 1,
                    MaPN = pn.MaPhieuNhap,
                    TenNV = pn.MaNvNavigation.HoTen,
                    NgayNhap = pn.NgayNhap,
                    TrangThaiPN = pn.TrangThaiThanhToan
                }).ToList();
            }
            // --- XỬ LÝ LỌC PHIẾU XUẤT ---
            else if (loaiPhieu == "Phiếu xuất")
            {
                // Bảo mật thêm: Nếu là nhân viên kiểm kho mà cố tình xem phiếu xuất (qua code/bug) thì xóa trắng
                if (tenChucVu == "Nhân viên kiểm kho")
                {
                    dgvPhieu.DataSource = null;
                    return;
                }

                var query = _pxBLL.GetAll(x => x.MaKhNavigation, x => x.MaNvNavigation);

                // PHÂN QUYỀN: Nhân viên bán hàng chỉ xem phiếu xuất của CHÍNH MÌNH
                if (tenChucVu != "Quản trị viên")
                {
                    query = query.Where(px => px.MaNv == _currentUser.Id);
                }

                if (trangThai != "Tất cả")
                {
                    query = query.Where(px => px.TrangThaiThanhToan == trangThai);
                }

                if (ngayLocIndex == 1)
                {
                    query = query.Where(px => px.NgayXuat >= tuNgay && px.NgayXuat <= denNgay);
                }

                dgvPhieu.DataSource = query.Select((px, index) => new
                {
                    STT = index + 1,
                    MaPX = px.MaPhieuXuat,
                    TenKH = px.MaKhNavigation.Ten,
                    TenNV = px.MaNvNavigation.HoTen,
                    NgayXuat = px.NgayXuat,
                    TrangThaiPX = px.TrangThaiThanhToan
                }).ToList();
            }
        }
        private void cbNgayloc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbNgayloc.SelectedIndex == 0) // "Tất cả"
            {
                dateTimePicker1.Visible = false;
                dateTimePicker2.Visible = false;
                btnTk.Visible = false;
                lbDenngay.Visible = false;
                lbTungay.Visible = false;

            }
            else // "Khoảng thời gian"
            {
                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;
                btnTk.Visible = true;
                lbDenngay.Visible = true;
                lbTungay.Visible = true;

            }

            // Quan trọng: Gọi hàm lọc để cập nhật dữ liệu ngay lập tức
            ApplyFilters();
        }

        private void dgvPhieu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
