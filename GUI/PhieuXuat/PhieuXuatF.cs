using System.Data;
using System.Globalization;
using System.Windows.Forms;
using DuAn1_Nhom4.BLL;
using DuAn1_Nhom4.GUI.Hóa_đơn;
using DuAn1_Nhom4.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace DuAn1_Nhom4.GUI
{
    public partial class PhieuXuatF : Form
    {
        private GenericBLL<ChiTietSanPham> _ctSanphamBLL = new GenericBLL<ChiTietSanPham>();
        private GenericBLL<PhieuXuat> _phieuXuatBLL = new GenericBLL<PhieuXuat>();
        private GenericBLL<PhieuXuatChiTiet> _ctPhieuXuatBLL = new GenericBLL<PhieuXuatChiTiet>();
        NhanVien _nhanVien;
        //KhachHang _khachHang;
        public PhieuXuatF(NhanVien nhanVien)
        {
            InitializeComponent();
            _nhanVien = nhanVien;
        }
        private void LoadSanPham()
        {
            var list = _ctSanphamBLL.GetAll(x => x.MaSpNavigation, x => x.MaMauNavigation, x => x.MaKichThuocNavigation);
            dtgDanhSachSP.DataSource = list.Select((sp, index) => new
            {
                STT = index + 1,
                MaSP = sp.MaCtsp,
                TenSP = sp.MaSpNavigation.TenSp,
                MauSac = sp.MaMauNavigation?.TenMau,
                KichThuoc = sp.MaKichThuocNavigation?.TenKichThuoc,
                SoLuong = sp.SoLuong,
                DonGiaNhap = sp.DonGiaNhap,
                // SỬA DÒNG NÀY ĐỂ TÍNH LÃI 20%
                DonGiaXuat = sp.DonGiaNhap * 1.2m
            }).ToList();

            // --- GIỮ NGUYÊN CÁC DÒNG FORMAT BÊN DƯỚI ---
            dtgDanhSachSP.Columns["STT"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgDanhSachSP.Columns["MaSP"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgDanhSachSP.Columns["TenSP"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgDanhSachSP.Columns["MauSac"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgDanhSachSP.Columns["KichThuoc"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgDanhSachSP.Columns["SoLuong"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgDanhSachSP.Columns["DonGiaNhap"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgDanhSachSP.Columns["DonGiaXuat"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgDanhSachSP.Columns["STT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDanhSachSP.Columns["MaSP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDanhSachSP.Columns["SoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDanhSachSP.Columns["DonGiaNhap"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDanhSachSP.Columns["DonGiaXuat"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // THÊM ĐỊNH DẠNG TIỀN TỆ ĐỂ HIỂN THỊ ĐẸP HƠN (Tùy chọn)
            dtgDanhSachSP.Columns["DonGiaNhap"].DefaultCellStyle.Format = "N0";
            dtgDanhSachSP.Columns["DonGiaXuat"].DefaultCellStyle.Format = "N0";

            dtgDanhSachSP.Columns["MaSP"].HeaderText = "Mã sản phẩm";
            dtgDanhSachSP.Columns["TenSP"].HeaderText = "Tên sản phẩm";
            dtgDanhSachSP.Columns["MauSac"].HeaderText = "Màu sắc";
            dtgDanhSachSP.Columns["KichThuoc"].HeaderText = "Kích thước";
            dtgDanhSachSP.Columns["SoLuong"].HeaderText = "Số lượng";
            dtgDanhSachSP.Columns["DonGiaNhap"].HeaderText = "Đơn giá nhập";
            dtgDanhSachSP.Columns["DonGiaXuat"].HeaderText = "Đơn giá xuất";

            dtgDanhSachSP.Columns["TenSP"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }


        private void LoadPhieuXuat()
        {
            var list = _phieuXuatBLL.GetAll(x => x.MaKhNavigation, x => x.MaNvNavigation).Where(x => x.TrangThaiThanhToan == "Chưa thanh toán");
            dtgDanhSachHD.DataSource = list.Select((px, index) => new
            {
                STT = index + 1,
                MaPX = px.MaPhieuXuat,
                TenKH = px.MaKhNavigation.Ten,
                TenNV = px.MaNvNavigation.HoTen,
                NgayXuat = px.NgayXuat,
                TrangThai = px.TrangThaiThanhToan,
            }).ToList();
            if (dtgDanhSachHD.Rows.Count <= 0)
            {
                btnXoa.Enabled = false; // Vô hiệu hóa nút Xóa nếu không có phiếu xuất nào
                btnSua.Enabled = false; // Vô hiệu hóa nút Sửa nếu không có phiếu xuất nào
                btnThem.Enabled = false; // Vô hiệu hóa nút Thêm nếu không có phiếu xuất nào
            }
            else
            {
                btnXoa.Enabled = true; // Kích hoạt nút Xóa nếu có phiếu xuất
                btnSua.Enabled = true; // Kích hoạt nút Sửa nếu có phiếu xuất
                btnThem.Enabled = true; // Kích hoạt nút Thêm nếu có phiếu xuất
            }

            dtgDanhSachHD.Columns["STT"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgDanhSachHD.Columns["MaPX"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgDanhSachHD.Columns["TenKH"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgDanhSachHD.Columns["NgayXuat"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgDanhSachHD.Columns["TrangThai"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgDanhSachHD.Columns["STT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDanhSachHD.Columns["MaPX"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDanhSachHD.Columns["NgayXuat"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            dtgDanhSachHD.Columns["MaPX"].HeaderText = "Mã phiếu xuất";
            dtgDanhSachHD.Columns["TenKH"].HeaderText = "Tên khách hàng";
            dtgDanhSachHD.Columns["NgayXuat"].HeaderText = "Ngày xuất";
            dtgDanhSachHD.Columns["TrangThai"].HeaderText = "Trạng thái";
            dtgDanhSachHD.Columns["TenNV"].HeaderText = "Tên nhân viên";


            if (dtgDanhSachHD.Rows.Count > 0)
            {
                int maPX = Convert.ToInt32(dtgDanhSachHD.Rows[0].Cells["MaPX"].Value);
                var px = _phieuXuatBLL.GetById(maPX);
                LoadKhachHang(_phieuXuatBLL.GetById(maPX).MaKhNavigation); // Cập nhật thông tin khách hàng
                lbNV.Text = "Nhân viên: " + px.MaNvNavigation.HoTen;
                LoadCTPX(maPX);
            }

        }


        private void LoadCTPX(int maPX)
        {
            var list = _ctPhieuXuatBLL.GetAll(
                    x => x.MaCtspNavigation.MaSpNavigation,
                    x => x.MaCtspNavigation.MaMauNavigation,
                    x => x.MaCtspNavigation.MaKichThuocNavigation,
                    x => x.MaPhieuXuatNavigation)
                    .Where(x => x.MaPhieuXuat == maPX)
                    .ToList();

            dtgGioHang.DataSource = list.Select((ct, index) => {
                // Lấy giá nhập từ navigation property và tính giá xuất 1.2
                decimal giaNhap = ct.MaCtspNavigation?.DonGiaNhap ?? 0;
                decimal giaBanHienTai = giaNhap * 1.2m;

                return new
                {
                    STT = index + 1,
                    MaCT = ct.MaCt,
                    TenSP = ct.MaCtspNavigation?.MaSpNavigation?.TenSp ?? "",
                    MauSac = ct.MaCtspNavigation?.MaMauNavigation?.TenMau ?? "",
                    KichThuoc = ct.MaCtspNavigation?.MaKichThuocNavigation?.TenKichThuoc ?? "",
                    SoLuong = ct.SoLuong,
                    // SỬA TẠI ĐÂY: Hiển thị giá bán đã tính lãi
                    DonGia = giaBanHienTai,
                    ThanhTien = ct.SoLuong * giaBanHienTai
                };
            }).ToList();

            lbTongtienhd.Text = "Tổng tiền: " + TinhTongTien().ToString("N0") + " VNĐ";

            // Định dạng số cho cột Đơn giá và Thành tiền trong Giỏ hàng
            dtgGioHang.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            dtgGioHang.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";


            //dtgGioHang.Columns["STT"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dtgGioHang.Columns["MaCT"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dtgGioHang.Columns["TenSP"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dtgGioHang.Columns["MauSac"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dtgGioHang.Columns["KichThuoc"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dtgGioHang.Columns["DonGia"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dtgGioHang.Columns["ThanhTien"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgGioHang.Columns["SoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgGioHang.Columns["DonGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgGioHang.Columns["ThanhTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgGioHang.Columns["STT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgGioHang.Columns["MaCT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            foreach (DataGridViewColumn column in dtgGioHang.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; // Căn giữa tiêu đề cột

            }

            dtgGioHang.Columns["MaCT"].HeaderText = "Mã chi tiết";
            dtgGioHang.Columns["TenSP"].HeaderText = "Tên sản phẩm";
            dtgGioHang.Columns["MauSac"].HeaderText = "Màu sắc";
            dtgGioHang.Columns["KichThuoc"].HeaderText = "Kích thước";
            dtgGioHang.Columns["DonGia"].HeaderText = "Đơn giá";
            dtgGioHang.Columns["ThanhTien"].HeaderText = "Thành tiền";
            dtgGioHang.Columns["SoLuong"].HeaderText = "Số lượng";

            dtgGioHang.Columns["TenSP"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            if (dtgGioHang.Rows.Count <= 0)
            {
                btnXoa.Enabled = false; // Vô hiệu hóa nút Xóa nếu giỏ hàng không có sản phẩm
                btnSua.Enabled = false; // Vô hiệu hóa nút Sửa nếu giỏ hàng không có sản phẩm
                txtTienkhach.ReadOnly = true; // Đặt ô tiền khách hàng thành chỉ đọc nếu giỏ hàng không có sản phẩm
            }
            else
            {
                btnXoa.Enabled = true; // Kích hoạt nút Xóa nếu giỏ hàng có sản phẩm
                btnSua.Enabled = true; // Kích hoạt nút Sửa nếu giỏ hàng có sản phẩm
                txtTienkhach.ReadOnly = false; // Bỏ chỉ đọc ô tiền khách hàng nếu giỏ hàng có sản phẩm

            }
        }

        private decimal TinhTongTien()
        {
            decimal tongTien = 0;
            foreach (DataGridViewRow row in dtgGioHang.Rows)
            {
                if (row.Cells["ThanhTien"].Value != null)
                {
                    tongTien += Convert.ToDecimal(row.Cells["ThanhTien"].Value);
                }
            }

            return tongTien;
        }


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void dtgDanhSachHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return; // Không có hàng nào được chọn
            }

            int maPx = Convert.ToInt32(dtgDanhSachHD.Rows[e.RowIndex].Cells[1].Value);

            var px = _phieuXuatBLL.GetById(maPx);

            LoadCTPX(maPx);
            LoadKhachHang(_phieuXuatBLL.GetById(maPx).MaKhNavigation); // Cập nhật thông tin khách hàng
            lbNV.Text = "Nhân viên: " + px.MaNvNavigation.HoTen;

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dtgDanhSachHD.Rows.Count < 0)
            {
                MessageBox.Show("Vui lòng tạo phiếu xuất trước khi xóa sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Không thể xóa sản phẩm nếu chưa có phiếu xuất
            }
            var px = dtgDanhSachHD.CurrentRow.Cells["MaPX"].Value;
            var ctpx = dtgGioHang.CurrentRow?.Cells["MaCT"].Value;
            if (dtgGioHang.Rows.Count < 2)
            {
                MessageBox.Show("Không thể xóa sản phẩm vì giỏ hàng chỉ còn một sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Không thể xóa nếu giỏ hàng chỉ còn một sản phẩm
            }
            if (ctpx == null)
            {
                MessageBox.Show("Vui lòng chọn sản phầm trong giỏ để xóa"); return;
            }
            var ct = _ctPhieuXuatBLL.GetById((int)ctpx);
            var sp = _ctSanphamBLL.GetById(ct.MaCtsp);
            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm {sp.MaSpNavigation.TenSp} không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (sp != null)
                {
                    sp.SoLuong += ct.SoLuong;
                    _ctSanphamBLL.Update(sp);
                    _ctPhieuXuatBLL.Delete(ct.MaCt);
                    LoadSanPham();
                    LoadCTPX((int)px);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm");
                }
            }
            else
            {
                return;
            }


        }

        private void HoaDon_Load(object sender, EventArgs e)
        {
            LoadSanPham();
            LoadPhieuXuat();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var list = _ctSanphamBLL.GetAll(x => x.MaSpNavigation, x => x.MaMauNavigation, x => x.MaKichThuocNavigation)
                .Where(x => x.MaSpNavigation.TenSp.Contains(textBox1.Text, StringComparison.OrdinalIgnoreCase));
            dtgDanhSachSP.DataSource = list.Select((sp, index) => new
            {
                STT = index + 1,
                MaSP = sp.MaCtsp,
                TenSP = sp.MaSpNavigation.TenSp,
                MauSac = sp.MaMauNavigation?.TenMau,
                KichThuoc = sp.MaKichThuocNavigation?.TenKichThuoc,
                SoLuong = sp.SoLuong,
                DonGiaNhap = sp.DonGiaNhap,
                DonGiaXuat = sp.DonGiaXuat

            }).ToList();


            dtgDanhSachSP.Columns["STT"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgDanhSachSP.Columns["MaSP"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgDanhSachSP.Columns["TenSP"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgDanhSachSP.Columns["MauSac"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgDanhSachSP.Columns["KichThuoc"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgDanhSachSP.Columns["SoLuong"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgDanhSachSP.Columns["DonGiaNhap"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgDanhSachSP.Columns["DonGiaXuat"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;


            dtgDanhSachSP.Columns["STT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDanhSachSP.Columns["MaSP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDanhSachSP.Columns["SoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDanhSachSP.Columns["DonGiaNhap"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDanhSachSP.Columns["DonGiaXuat"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDanhSachSP.Columns["DonGiaNhap"].DefaultCellStyle.Format = "N0";
            dtgDanhSachSP.Columns["DonGiaXuat"].DefaultCellStyle.Format = "N0";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (dtgDanhSachHD.Rows.Count < 0)
            {
                MessageBox.Show("Vui lòng tạo phiếu xuất trước khi thêm sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Không thể thêm sản phẩm nếu chưa có phiếu xuất
            }
            var sp = dtgDanhSachSP.CurrentRow.Cells["MaSP"].Value;
            var px = dtgDanhSachHD.CurrentRow.Cells["MaPX"].Value;
            var donGia = dtgDanhSachSP.CurrentRow.Cells["DonGiaXuat"].Value;
            var soLuong = 0;
            if (_ctPhieuXuatBLL.GetAll().FirstOrDefault(x => x.MaPhieuXuat == (int)px && x.MaCtsp == (int)sp) != null)
            {
                MessageBox.Show("Sản phẩm đã có trong giỏ hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Không thêm sản phẩm nếu đã có trong giỏ hàng
            }
            SoLuong soLuongForm = new SoLuong();
            soLuongForm.ShowDialog();
            soLuong = soLuongForm.SoLuongSanPham;
            if (soLuong == 0)
            {
                return;
            }
            var ctpx = new PhieuXuatChiTiet
            {
                MaCtsp = (int)sp,
                GiaBan = Convert.ToDecimal(donGia), // Giá này sẽ mang giá trị đã có lãi 20%
                SoLuong = soLuong,
                MaPhieuXuat = (int)px
            };

            // Kiểm tra số lượng sản phẩm có đủ không
            var ctSanPham = _ctSanphamBLL.GetById(ctpx.MaCtsp);
            if (ctSanPham.SoLuong < soLuong)
            {
                MessageBox.Show("Số lượng sản phẩm không đủ để xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Không thêm vào giỏ hàng nếu số lượng không đủ
            }
            else
            {
                ctSanPham.SoLuong -= soLuong; // Giảm số lượng sản phẩm trong kho
                _ctSanphamBLL.Update(ctSanPham); // Cập nhật số lượng sản phẩm trong kho
                _ctPhieuXuatBLL.Add(ctpx);
                LoadSanPham();
                LoadCTPX((int)px); // Cập nhật giỏ hàng

            }


        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            KhachHangF khachHangForm = new KhachHangF();
            khachHangForm.ShowDialog();
            // Kiểm tra xem khách hàng đã được chọn hay chưa
            var kh = khachHangForm.Kh;
            if (kh == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng trước khi tạo phiếu xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Không thể tạo phiếu xuất nếu chưa chọn khách hàng
            }
            var nhanVien = _nhanVien;
            if (nhanVien == null)
            {
                MessageBox.Show("Vui lòng đăng nhập trước khi tạo phiếu xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Không thể tạo phiếu xuất nếu chưa đăng nhập
            }
            if (kh == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng trước khi tạo phiếu xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Không thể tạo phiếu xuất nếu chưa chọn khách hàng
            }

            var phieuXuat = new PhieuXuat()
            {
                MaKh = kh.MaKh, // Lấy mã khách hàng nếu đã chọn
                MaNv = nhanVien.Id,
                NgayXuat = DateOnly.FromDateTime(DateTime.Now),
                TrangThaiThanhToan = "Chưa thanh toán",
            };
            _phieuXuatBLL.Add(phieuXuat); // Thêm phiếu xuất mới vào cơ sở dữ liệu
            LoadPhieuXuat(); // Cập nhật danh sách phiếu xuất
            dtgDanhSachHD.ClearSelection(); // Xóa lựa chọn hiện tại trong DataGridView

            dtgDanhSachHD.Rows[dtgDanhSachHD.Rows.Count - 1].Selected = true; // Chọn phiếu xuất mới nhất
            dtgDanhSachHD.CurrentCell = dtgDanhSachHD.Rows[dtgDanhSachHD.Rows.Count - 1].Cells[0]; // Đặt con trỏ vào ô đầu tiên của phiếu xuất mới
            dtgDanhSachHD.FirstDisplayedScrollingRowIndex = dtgDanhSachHD.Rows.Count - 1;

            LoadCTPX(phieuXuat.MaPhieuXuat); // Tải giỏ hàng cho phiếu xuất mới


        }



        private void LoadKhachHang(KhachHang khachHang)
        {
            txtTen.Text = khachHang.Ten;
            txtsdt.Text = khachHang.Sdt;
        }


        private void ResetForm_XuatHang()
        {
            // Xóa text các ô bên phải
            txtsdt.Clear();

            txtTen.Clear();

            txtTienkhach.Clear();
            txtsdt.Clear();
            txtTen.Clear();


            lbNV.Text = "Nhân viên: ";


            // Label tổng tiền
            lbTongtienhd.Text = "Tổng tiền: 0";

            // Xóa giỏ hàng (DataGridView giỏ hàng)
            dtgGioHang.DataSource = null;

            // Load lại danh sách sản phẩm
            LoadSanPham();

            // Load lại danh sách hóa đơn (nếu muốn)
            LoadPhieuXuat();


        }
        bool isTyping = false;

        private void txtTienkhach_TextChanged(object sender, EventArgs e)
        {


            var px = dtgDanhSachHD.CurrentRow?.Cells["MaPX"].Value;
            if (px == null)
            {

                txtTienkhach.Clear(); // Xóa ô tiền khách nếu không có phiếu xuất
                return;
            }


            if (isTyping) return;

            isTyping = true;

            TextBox txt = sender as TextBox;
            string text = txt.Text;

            // Xóa các ký tự không phải số
            string clean = new string(text.Where(char.IsDigit).ToArray());

            if (decimal.TryParse(clean, out decimal value))
            {
                // Gán lại định dạng C0 (1.000.000 ₫)
                txt.Text = string.Format(CultureInfo.GetCultureInfo("en-US"), "{0:N0}", value);
                txt.SelectionStart = txt.Text.Length; // Đặt con trỏ ở cuối

                // Tính tiền thừa
                var tongTien = TinhTongTien(); // → bạn phải có hàm này
                var tienKhach = value;
                var tienThua = tienKhach - tongTien;

                if (tienThua >= 0)
                    lbTienthua.Text = "Tiền thừa: " + tienThua.ToString("C0", CultureInfo.GetCultureInfo("vi-VN"));

                else
                    lbTienthua.Text = "Chưa đủ tiền!";
            }
            else
            {
                lbTienthua.Text = "Tiền thừa: 0 đ";
            }

            isTyping = false;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            var pxXoa = dtgDanhSachHD.CurrentRow?.Cells["MaPX"].Value;
            if (pxXoa == null)
            {
                MessageBox.Show("Vui lòng chọn phiếu xuất để hủy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Không thể xóa nếu không có phiếu xuất được chọn
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return; // Không thực hiện xóa nếu người dùng chọn No
            }

            var px = _phieuXuatBLL.GetById((int)pxXoa);
            var list = _ctPhieuXuatBLL.GetAll().Where(x => x.MaPhieuXuat == (int)pxXoa).ToList();
            foreach (var item in list)
            {
                var ctsp = _ctSanphamBLL.GetById(item.MaCtsp);
                if (ctsp != null)
                {
                    ctsp.SoLuong += item.SoLuong; // Trả lại số lượng sản phẩm vào kho
                    _ctSanphamBLL.Update(ctsp); // Cập nhật số lượng sản phẩm trong kho

                }
            }

            px.TrangThaiThanhToan = "Đã hủy"; // Cập nhật trạng thái phiếu xuất

            _phieuXuatBLL.Update(px); // Xóa phiếu xuất
            LoadPhieuXuat(); // Cập nhật danh sách phiếu xuất
            ResetForm_XuatHang(); // Đặt lại form xuất hàng về trạng thái ban đầu
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dtgDanhSachHD.Rows.Count <= 0)
            {
                MessageBox.Show("Vui lòng tạo phiếu xuất trước khi sửa sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Không thể xóa sản phẩm nếu chưa có phiếu xuất
            }
            var ctpx = dtgGioHang.CurrentRow?.Cells["MaCT"].Value;
            if (ctpx == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm trong giỏ hàng để sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var ct = _ctPhieuXuatBLL.GetById((int)ctpx);
            var sp = _ctSanphamBLL.GetById(ct.MaCtsp);
            if (sp == null)
            {
                MessageBox.Show("Không tìm thấy sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SoLuong soLuongForm = new SoLuong();

            soLuongForm.ShowDialog();
            int soLuong = soLuongForm.SoLuongSanPham;
            if (soLuong == 0)
            {
                return; // Không thể sửa nếu không có số lượng
            }

            if (soLuong > sp.SoLuong + ct.SoLuong)
            {
                MessageBox.Show("Số lượng sản phẩm không đủ để sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Không thể sửa nếu số lượng không đủ
            }
            // Cập nhật số lượng sản phẩm trong kho

            sp.SoLuong += ct.SoLuong - soLuong; // Trả lại số lượng cũ vào kho và trừ đi số lượng mới
            _ctSanphamBLL.Update(sp); // Cập nhật số lượng sản phẩm trong kho
            ct.SoLuong = soLuong; // Cập nhật số lượng trong chi tiết phiếu xuất
            _ctPhieuXuatBLL.Update(ct); // Cập nhật chi tiết phiếu xuất
            LoadSanPham(); // Cập nhật danh sách sản phẩm
            LoadCTPX((int)dtgDanhSachHD.CurrentRow.Cells["MaPX"].Value); // Cập nhật giỏ hàng
            MessageBox.Show("Cập nhật số lượng sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            var px = dtgDanhSachHD.CurrentRow?.Cells["MaPX"].Value;
            if (px == null)
            {
                MessageBox.Show("Vui lòng chọn phiếu xuất để thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var phieuXuat = _phieuXuatBLL.GetById((int)px);
            var list = _ctPhieuXuatBLL.GetAll().Where(x => x.MaPhieuXuat == (int)px).ToList();
            if (list.Count() == 0)
            {
                MessageBox.Show("Giỏ hàng không có sản phẩm nào để thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Không thể thanh toán nếu giỏ hàng không có sản phẩm
            }

            decimal tienKhach = 0;

            string raw = txtTienkhach.Text.Trim()
            .Replace(".", "")
            .Replace(",", "")
            .Replace("đ", "")
            .Replace("VNĐ", "")
            .Trim();

            // Parse sang decimal
            if (!decimal.TryParse(raw, out tienKhach))
            {
                MessageBox.Show("Xin vui lòng nhập số tiền hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var tongTien = TinhTongTien();
            if (tienKhach < tongTien)
            {
                MessageBox.Show("Số tiền khách đưa không đủ để thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Không thể thanh toán nếu số tiền không đủ
            }
            // Cập nhật trạng thái thanh toán của phiếu xuất

            if (phieuXuat == null)
            {
                MessageBox.Show("Phiếu xuất không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            phieuXuat.TrangThaiThanhToan = "Đã thanh toán";
            _phieuXuatBLL.Update(phieuXuat); // Cập nhật phiếu xuất
            // Xuất hóa đơn PDF
            if (MessageBox.Show("Bạn có muốn in hóa đơn không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string folderPath = Path.Combine(Application.StartupPath, @"..\..\..\GUI\PhieuXuat\HoaDon");

                // Chuẩn hóa đường dẫn (chuyển từ relative sang absolute)
                folderPath = Path.GetFullPath(folderPath);

                // Tạo thư mục nếu chưa có
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // Tạo file PDF trong thư mục HoaDon
                string filePath = Path.Combine(folderPath, $"HoaDon_{phieuXuat.MaPhieuXuat}.pdf");
                XuatHoaDonPDF(filePath, phieuXuat.MaPhieuXuat.ToString(), phieuXuat.MaKhNavigation.Ten, phieuXuat.NgayXuat.ToDateTime(new TimeOnly()), tongTien, tienKhach, list);
            }

            MessageBox.Show("Thanh toán thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ResetForm_XuatHang(); // Đặt lại form xuất hàng về trạng thái ban đầu sau khi thanh toán thành công
            LoadPhieuXuat(); // Cập nhật danh sách phiếu xuất

        }
        public static void XuatHoaDonPDF(string filePath, string maHoaDon, string tenKhach, DateTime ngayLap, decimal tongTien, decimal tienKhach, List<PhieuXuatChiTiet> chiTiet)
        {
            // Tạo document PDF
            Document document = new Document(PageSize.A4, 25, 25, 30, 30);
            try
            {
                PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
                document.Open();
                // Khai báo font hỗ trợ tiếng Việt (Unicode)
                // Thay đổi đường dẫn đến font Arial Unicode MS hoặc một font khác có sẵn trên máy của bạn
                string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arialuni.ttf");
                // Nếu không tìm thấy font, hãy sử dụng một font mặc định hoặc font có sẵn khác.
                if (!File.Exists(fontPath))
                {
                    fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "times.ttf");
                }
                BaseFont baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                // Định nghĩa các font cần dùng
                iTextSharp.text.Font titleFont = new iTextSharp.text.Font(baseFont, 18, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font normalFont = new iTextSharp.text.Font(baseFont, 12);
                iTextSharp.text.Font boldFont = new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.BOLD);
                // Tiêu đề hóa đơn
                Paragraph title = new Paragraph("HÓA ĐƠN BÁN HÀNG\n\n", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                document.Add(title);
                // Thông tin hóa đơn
                document.Add(new Paragraph($"Mã hóa đơn: {maHoaDon}", normalFont));
                document.Add(new Paragraph($"Khách hàng: {tenKhach}", normalFont));
                document.Add(new Paragraph($"Ngày lập: {ngayLap:dd/MM/yyyy}", normalFont));
                document.Add(new Paragraph("\n"));
                // Bảng chi tiết sản phẩm
                PdfPTable table = new PdfPTable(5);
                table.WidthPercentage = 100;
                table.SetWidths(new float[] { 10f, 40f, 20f, 20f, 20f });
                // Tiêu đề bảng
                PdfPCell cellSTT = new PdfPCell(new Phrase("STT", boldFont));
                cellSTT.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cellSTT);
                PdfPCell cellTensp = new PdfPCell(new Phrase("Tên sản phẩm", boldFont));
                cellTensp.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cellTensp);
                PdfPCell cellSl = new PdfPCell(new Phrase("Số lượng", boldFont));
                cellSl.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cellSl);
                PdfPCell celldonGia = new PdfPCell(new Phrase("Đơn giá", boldFont));
                celldonGia.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(celldonGia);
                PdfPCell cellTongtien = new PdfPCell(new Phrase("Thành tiền", boldFont));
                cellTongtien.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cellTongtien);
                int count = 1; // Biến đếm số thứ tự sản phẩm
                // Dữ liệu chi tiết
                foreach (var item in chiTiet)
                {
                    PdfPCell cellStt = new PdfPCell(new Phrase((count++).ToString(), normalFont));
                    cellStt.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cellStt);
                    // Cột Tên SP
                    table.AddCell(new Phrase(item.MaCtspNavigation.MaSpNavigation.TenSp, normalFont));

                    // Cột Số lượng
                    PdfPCell cellSoLuong = new PdfPCell(new Phrase(item.SoLuong.ToString(), normalFont));
                    cellSoLuong.HorizontalAlignment = Element.ALIGN_RIGHT;
                    table.AddCell(cellSoLuong);

                    // Cột Giá bán
                    PdfPCell cellGiaBan = new PdfPCell(new Phrase(item.GiaBan.ToString("N0"), normalFont));
                    cellGiaBan.HorizontalAlignment = Element.ALIGN_RIGHT;
                    table.AddCell(cellGiaBan);

                    // Cột Thành tiền
                    PdfPCell cellThanhTien = new PdfPCell(new Phrase((item.SoLuong * item.GiaBan).ToString("N0"), normalFont));
                    cellThanhTien.HorizontalAlignment = Element.ALIGN_RIGHT;
                    table.AddCell(cellThanhTien);
                }

                document.Add(table);


                // Tổng tiền
                document.Add(new Paragraph("\n"));
                Paragraph total = new Paragraph($"Tổng cộng: {tongTien:N0} VND", titleFont);
                total.Alignment = Element.ALIGN_RIGHT;
                document.Add(total);

                document.Add(new Paragraph("\n"));
                Paragraph tienKhachTra = new Paragraph($"Tiền khách trả: {tienKhach:N0} VND", titleFont);
                tienKhachTra.Alignment = Element.ALIGN_RIGHT;
                document.Add(tienKhachTra);

                document.Add(new Paragraph("\n"));
                Paragraph tienThua = new Paragraph($"Tiền trả lại: {tienKhach - tongTien:N0} VND", titleFont);
                tienThua.Alignment = Element.ALIGN_RIGHT;
                document.Add(tienThua);



                document.Add(new Paragraph("\nCảm ơn quý khách!", normalFont));
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xuất PDF: " + ex.Message);
            }
            finally
            {
                document.Close();
            }
        }

        private void dtgGioHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgDanhSachHD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

