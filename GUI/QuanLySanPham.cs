using DuAn1_Nhom4.BLL;
using DuAn1_Nhom4.GUI;
using DuAn1_Nhom4.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DuAn1_Nhom4
{
    public partial class QuanLySanPham : Form
    {
        GenericBLL<ChiTietSanPham> ctspBll = new GenericBLL<ChiTietSanPham>();
        GenericBLL<KichThuoc> ktBll = new GenericBLL<KichThuoc>();
        GenericBLL<MauSac> msBll = new GenericBLL<MauSac>();
        GenericBLL<ThuongHieu> thBll = new GenericBLL<ThuongHieu>();
        GenericBLL<NhaCungCap> nccBll = new GenericBLL<NhaCungCap>();
        public QuanLySanPham()
        {
            InitializeComponent();
            LoadDSSP();
            LoadDsKt();
            LoadDsMs();
            LoadTh();
            LoadKt();
            LoadMs();
            LoadNcc();
            rbConHang.Checked = true;
            btnLuuAddSP.Visible = false;
            btnLuuEditSP.Visible = false;
            btnHuyLuu.Visible = false;
        }
        #region Tab Thông Tin Sản Phẩm
        private void LoadDSSP()
        {
            var ds = ctspBll.GetAll(x => x.MaSpNavigation.MaNccNavigation, x => x.MaMauNavigation, x => x.MaKichThuocNavigation, x => x.MaSpNavigation.MaThuongHieuNavigation)
                .Select((x, Index) => new
                {
                    STT = Index + 1,
                    x.MaCtsp,
                    x.MaSpNavigation.TenSp,
                    x.DonGiaNhap,
                    x.SoLuong,
                    x.MaKichThuocNavigation?.TenKichThuoc,
                    x.MaSpNavigation.MaThuongHieuNavigation?.TenThuongHieu,
                    TenMau = x.MaMauNavigation?.TenMau,
                    x.MaSpNavigation.MaNccNavigation?.TenNcc,
                    x.MaSpNavigation.TrangThai
                }).ToList();
            dtgThongTinSP.DataSource = ds;
            dtgThongTinSP.Columns["MaCtsp"].HeaderText = "Mã chi tiết SP";
            dtgThongTinSP.Columns["TenSp"].HeaderText = "Tên sản phẩm";
            dtgThongTinSP.Columns["DonGiaNhap"].HeaderText = "Đơn giá nhập";
            dtgThongTinSP.Columns["SoLuong"].HeaderText = "Số lượng";
            dtgThongTinSP.Columns["TenKichThuoc"].HeaderText = "Kích thước";
            dtgThongTinSP.Columns["TenThuongHieu"].HeaderText = "Thương hiệu";
            dtgThongTinSP.Columns["TenMau"].HeaderText = "Màu sắc";
            dtgThongTinSP.Columns["TenNcc"].HeaderText = "Nhà cung cấp";
            dtgThongTinSP.Columns["TrangThai"].HeaderText = "Trạng thái";

        }

        private void LoadKt()
        {
            var dskt = ktBll.GetAll();
            cbKichThuoc.DataSource = dskt;
            cbKichThuoc.DisplayMember = "TenKichThuoc";
            cbKichThuoc.ValueMember = "MaKichThuoc";
            dgvKt.Columns["MaKichThuoc"].HeaderText = "Mã kích thước";
            dgvKt.Columns["TenKichThuoc"].HeaderText = "Tên kích thước";

        }

        private void LoadMs()
        {
            var dsMs = msBll.GetAll();
            cbMau.DataSource = dsMs;
            cbMau.DisplayMember = "TenMau";
            cbMau.ValueMember = "MaMau";
            dgvMs.Columns["MaMau"].HeaderText = "Mã màu";
            dgvMs.Columns["TenMau"].HeaderText = "Tên màu";


        }
        private void LoadTh()
        {
            var dsThuongHieu = thBll.GetAll()
                .Select((x, Index) => new
                {
                    STT = Index + 1,
                    x.MaThuongHieu,
                    x.TenThuongHieu
                }).ToList();

            cbTH.DataSource = dsThuongHieu;
            cbTH.DisplayMember = "TenThuongHieu";
            cbTH.ValueMember = "MaThuongHieu";

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dsThuongHieu;
            dataGridView1.Columns["MaThuongHieu"].HeaderText = "Mã thương hiệu";
            dataGridView1.Columns["TenThuongHieu"].HeaderText = "Tên thương hiệu";

        }

        private void LoadNcc()
        {
            var dsNcc = nccBll.GetAll();
            cbNcc.DataSource = dsNcc;
            cbNcc.DisplayMember = "TenNcc";
            cbNcc.ValueMember = "MaNcc";
        }
        private void Clear()
        {
            txtMa.Clear();
            txtTen.Clear();
            txtDonGia.Clear();
            txtSoLuong.Clear();
            txtTim.Clear();

            // Thêm phần này để các ô tự chọn quay về mục đầu tiên
            if (cbTH.Items.Count > 0) cbTH.SelectedIndex = 0;       // Thương hiệu
            if (cbMau.Items.Count > 0) cbMau.SelectedIndex = 0;     // Màu sắc
            if (cbKichThuoc.Items.Count > 0) cbKichThuoc.SelectedIndex = 0; // Kích thước
            if (cbNcc.Items.Count > 0) cbNcc.SelectedIndex = 0;    // Nhà cung cấp

            rbConHang.Checked = true; // Mặc định chọn trạng thái Còn hàng
        }
        private void addSp()
        {
            try
            {
                // 1. Kiểm tra dữ liệu số trước
                if (!decimal.TryParse(txtDonGia.Text, out decimal donGiaNhap) ||
                    !int.TryParse(txtSoLuong.Text, out int soLuong) ||
                    soLuong < 0 || donGiaNhap < 0)
                {
                    MessageBox.Show("Đơn giá và số lượng phải là số dương!", "Thông báo");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtTen.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên sản phẩm!");
                    return;
                }

                // 2. TẠO MỚI SẢN PHẨM (Nếu bạn muốn tạo mới hoàn toàn)
                SanPham sp = new SanPham();
                sp.TenSp = txtTen.Text.Trim();
                sp.MaNcc = Convert.ToInt32(cbNcc.SelectedValue);
                sp.MaThuongHieu = Convert.ToInt32(cbTH.SelectedValue);
                sp.TrangThai = rbConHang.Checked ? "Còn hàng" : "Ngừng kinh doanh";

                // 3. TẠO CHI TIẾT SẢN PHẨM
                ChiTietSanPham ctsp = new ChiTietSanPham();
                ctsp.DonGiaNhap = donGiaNhap;
                ctsp.SoLuong = soLuong;
                ctsp.MaKichThuoc = Convert.ToInt32(cbKichThuoc.SelectedValue);
                ctsp.MaMau = Convert.ToInt32(cbMau.SelectedValue);

                // Gán mối quan hệ: Chi tiết này thuộc về sản phẩm vừa tạo
                ctsp.MaSpNavigation = sp;

                // 4. LƯU (Gọi thông qua BLL của Chi tiết sản phẩm)
                ctspBll.Add(ctsp);

                LoadDSSP();
                Clear();
                MessageBox.Show("Thêm sản phẩm và chi tiết thành công!");
            }
            catch (Exception ex)
            {
                // Hiện lỗi chi tiết nhất từ SQL Server để Debug
                var inner = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                MessageBox.Show("Lỗi Database: " + inner);
            }
        }
        private void deleteSp()
        {
            try
            {
                // Kiểm tra nếu không nhập mã
                if (string.IsNullOrWhiteSpace(txtMa.Text))
                {
                    MessageBox.Show("Vui lòng chọn dữ liệu cần xóa!");
                    return;
                }

                int id = int.Parse(txtMa.Text);

                var timId = ctspBll.GetById(id);

                if (timId == null)
                {
                    MessageBox.Show("Không tìm thấy sản phẩm cần xóa!");
                    return;
                }

                // Xác nhận xóa
                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.No)
                    return;

                ctspBll.Delete(id);
                LoadDSSP();
                Clear();

                MessageBox.Show("Xóa thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void editSp()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMa.Text))
                {
                    MessageBox.Show("Vui lòng chọn dữ liệu cần sửa!");
                    return;
                }

                int id = int.Parse(txtMa.Text);
                var timId = ctspBll.GetById(id);

                if (timId == null)
                {
                    MessageBox.Show("Không tìm thấy sản phẩm cần sửa!");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtTen.Text) ||
                    !decimal.TryParse(txtDonGia.Text, out decimal donGiaNhap) ||
                    !int.TryParse(txtSoLuong.Text, out int soLuong))
                {
                    MessageBox.Show("Vui lòng nhập đúng và đầy đủ thông tin!");
                    return;
                }
                if (int.TryParse(txtSoLuong.Text, out int value))
                {
                    if (value < 0)
                    {
                        MessageBox.Show("Không được nhập số âm!");
                        return;
                    }
                }
                if (int.TryParse(txtSoLuong.Text, out int ok))
                {
                    if (ok < 0)
                    {
                        MessageBox.Show("Không được nhập số âm!");
                        return;
                    }
                }

                // Cập nhật dữ liệu
                timId.MaSpNavigation.TenSp = txtTen.Text.Trim();
                timId.DonGiaNhap = donGiaNhap;
                timId.SoLuong = soLuong;

                // Gán ID, không gán tên
                timId.MaKichThuoc = Convert.ToInt32(cbKichThuoc.SelectedValue);
                timId.MaSpNavigation.MaThuongHieu = Convert.ToInt32(cbTH.SelectedValue);
                timId.MaMau = Convert.ToInt32(cbMau.SelectedValue);
                timId.MaSpNavigation.MaNcc = Convert.ToInt32(cbNcc.SelectedValue);
                timId.MaSpNavigation.TrangThai = rbConHang.Checked ? "Còn hàng" : "Ngừng kinh doanh";

                ctspBll.Update(timId);
                LoadDSSP();
                Clear();

                MessageBox.Show("Sửa thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void findSp()
        {
            string keyword = txtTim.Text.Trim().ToLower();
            var danhSach = ctspBll.GetAll(x => x.MaSpNavigation);

            var ketQua = danhSach.Where(x =>
                x.MaSpNavigation.TenSp.ToLower().Contains(keyword) ||
                x.MaSpNavigation.MaThuongHieuNavigation.TenThuongHieu.ToString().ToLower().Contains(keyword) ||
                x.MaSpNavigation.MaNccNavigation.TenNcc.ToString().ToLower().Contains(keyword)
            ).Select((x, Index) => new
            {
                STT = Index + 1,
                x.MaCtsp,
                x.MaSpNavigation.TenSp,
                x.DonGiaNhap,
                x.SoLuong,
                x.MaKichThuocNavigation?.TenKichThuoc,
                x.MaSpNavigation.MaThuongHieuNavigation?.TenThuongHieu,
                x.MaMauNavigation?.TenMau,
                x.MaSpNavigation.MaNccNavigation?.TenNcc,
                x.MaSpNavigation.TrangThai
            }).ToList();

            // Hiển thị lên DataGridView
            dtgThongTinSP.DataSource = ketQua;
        }


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void QuanLySanPham_Load(object sender, EventArgs e)
        {
            // 1. Tải dữ liệu ban đầu
            LoadKt(); LoadMs(); LoadTh(); LoadNcc(); LoadDSSP();

            // 2. Lấy thông tin vai trò (Sử dụng cả MaVaiTro hoặc ChucVu tùy theo logic của bạn)
            int maVaiTro = Program.MaVaiTroDangNhap;
            string chucVu = Program.ChucVuDangNhap;

            // 3. Thực hiện phân quyền cho NHÂN VIÊN BÁN HÀNG
            // Giả sử mã vai trò của nhân viên bán hàng là 3 (hoặc kiểm tra theo tên chức vụ)
            if (maVaiTro != 1 && maVaiTro != 2)
            {
                // Ẩn các nút thao tác dữ liệu
                btnThem.Visible = false;
                btnSua.Visible = false;
                btnXoa.Visible = false;
                btnLamMoi.Visible = true;

                // --- PHẦN QUAN TRỌNG: ẨN TAB MÀU & KÍCH THƯỚC ---
                // Giả sử TabControl của bạn tên là tabControl1 
                // Và TabPage chứa Màu/Kích thước tên là tpMauKichThuoc (hoặc tabControl1.TabPages[1])
                if (tabControl1.TabPages.Contains(tabThuocTinh))
                {
                    tabControl1.TabPages.Remove(tabThuocTinh);
                }

                // Khóa các ô nhập liệu ở Tab Sản phẩm để chỉ cho phép XEM
                ThietLapCheDoChinhSua(false);

                // Chặn thêm các ComboBox nếu hàm ThietLapCheDoChinhSua chưa làm
                txtTen.ReadOnly = true;
                txtDonGia.ReadOnly = true;
                txtSoLuong.ReadOnly = true;
                cbKichThuoc.Enabled = false;
                cbMau.Enabled = false;
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            Clear();
            txtMa.Text = SinhMaTuDong();
            txtMa.ReadOnly = true;
            txtMa.Enabled = false;

            ThietLapCheDoChinhSua(true); // mở khóa khi thêm
            btnHuyLuu.Visible = true;
            btnLuuAddSP.Visible = true;

            btnThem.Visible = false;
            btnSua.Visible = false;
            btnXoa.Visible = false;
            btnLamMoi.Visible = false;

            txtTen.Focus();
        }

        // Giả sử hàm này lấy mã mới dựa trên số lượng sản phẩm hiện có hoặc số lớn nhất trong DB
        private string SinhMaTuDong()
        {
            // 1. Kết nối DB và đếm số lượng sản phẩm (Ví dụ đơn giản)
            // 2. Logic: "SP" + (Số lượng + 1)
            // Ở đây mình ví dụ logic tạo mã theo thời gian để đảm bảo không trùng:
            return "SP" + DateTime.Now.ToString("yyyyMMddHHmmss");

            // Hoặc nếu bạn muốn số thứ tự (SP001, SP002), bạn cần viết 1 câu truy vấn 
            // "SELECT MAX(MaSP) FROM SanPham" rồi xử lý chuỗi.
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            ThietLapCheDoChinhSua(true); // mở khóa khi sửa
            btnHuyLuu.Visible = true;
            btnLuuEditSP.Visible = true;

            btnThem.Visible = false;
            btnSua.Visible = false;
            btnXoa.Visible = false;
            btnLamMoi.Visible = false;
        }
        private void btnLuuAddSP_Click(object sender, EventArgs e)
        {
            addSp();
            
            // Sau khi lưu xong thì tự động quay về trạng thái ban đầu
            txtTen.ReadOnly = true;
            txtDonGia.ReadOnly = true;
            txtSoLuong.ReadOnly = true;

            btnHuyLuu.Visible = false;
            btnLuuEditSP.Visible = false;
            btnLuuAddSP.Visible = false;

            btnThem.Visible = true;
            btnSua.Visible = true;
            btnXoa.Visible = true;
            btnLamMoi.Visible = true;

            allowCellClick = true;

            ThietLapCheDoChinhSua(false); // khóa lại toàn bộ khi xong
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            deleteSp();
        }
        private void btnLuuEditSP_Click(object sender, EventArgs e)
        {
            editSp();

            // Sau khi lưu xong thì tự động quay về trạng thái ban đầu
            txtTen.ReadOnly = true;
            txtDonGia.ReadOnly = true;
            txtSoLuong.ReadOnly = true;

            btnHuyLuu.Visible = false;
            btnLuuEditSP.Visible = false;
            btnLuuAddSP.Visible = false;

            btnThem.Visible = true;
            btnSua.Visible = true;
            btnXoa.Visible = true;
            btnLamMoi.Visible = true;

            allowCellClick = true;

            ThietLapCheDoChinhSua(false); // khóa lại toàn bộ khi xong
        }

        private void btnHuyLuu_Click(object sender, EventArgs e)
        {
            txtTen.ReadOnly = true;
            txtDonGia.ReadOnly = true;
            txtSoLuong.ReadOnly = true;

            btnHuyLuu.Visible = false;
            btnLuuEditSP.Visible = false;
            btnLuuAddSP.Visible = false;

            btnThem.Visible = true;
            btnSua.Visible = true;
            btnXoa.Visible = true;
            btnLamMoi.Visible = true;

            allowCellClick = true;

            // QUAN TRỌNG: khóa lại toàn bộ khi hủy
            ThietLapCheDoChinhSua(false);
        }

        private bool allowCellClick = true;

        private void dtgThongTinSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 1. Kiểm tra điều kiện click hợp lệ
            if (!allowCellClick || e.RowIndex < 0) return;

            try
            {
                DataGridViewRow row = dtgThongTinSP.Rows[e.RowIndex];

                // 2. Đổ dữ liệu cơ bản lên các điều khiển
                txtMa.Text = row.Cells["MaCtsp"].Value?.ToString();
                txtTen.Text = row.Cells["TenSp"].Value?.ToString();
                txtSoLuong.Text = row.Cells["SoLuong"].Value?.ToString();
                cbKichThuoc.Text = row.Cells["TenKichThuoc"].Value?.ToString();
                cbMau.Text = row.Cells["TenMau"].Value?.ToString();
                cbTH.Text = row.Cells["TenThuongHieu"].Value?.ToString();
                cbNcc.Text = row.Cells["TenNcc"].Value?.ToString();
                txtDonGia.Text = row.Cells["DonGiaNhap"].Value?.ToString();

                // 3. Gán RadioButton theo trạng thái
                string trangThai = row.Cells["TrangThai"].Value?.ToString();
                rbConHang.Checked = (trangThai == "Còn hàng");
                rbNgung.Checked = (trangThai == "Ngừng kinh doanh");

                // 4. Luôn khóa các ô nhập liệu khi chỉ xem
                ThietLapCheDoChinhSua(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi hiển thị chi tiết: " + ex.Message,
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Hàm phụ trợ để khóa/mở các ô nhập liệu nhanh
        private void ThietLapCheDoChinhSua(bool allows)
        {
            // TextBox
            txtTen.ReadOnly = !allows;
            txtDonGia.ReadOnly = !allows;
            txtSoLuong.ReadOnly = !allows;

            // ComboBox
            cbTH.Enabled = allows;
            cbMau.Enabled = allows;
            cbKichThuoc.Enabled = allows;
            cbNcc.Enabled = allows;

            // RadioButton
            rbConHang.Enabled = allows;
            rbNgung.Enabled = allows;
        }


        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            findSp();
        }
        #endregion
        #region Tab Thuộc Tính Sản Phẩm
        private void LoadDsKt()
        {
            var dsKt = ktBll.GetAll()
                .Select((x, Index) => new
                {
                    STT = Index + 1,
                    x.MaKichThuoc,
                    x.TenKichThuoc
                }).ToList();
            dgvKt.DataSource = dsKt;
        }

        private void LoadDsMs()
        {
            var dsMs = msBll.GetAll()
                .Select((x, Index) => new
                {
                    STT = Index + 1,
                    x.MaMau,
                    x.TenMau
                }).ToList();
            dgvMs.DataSource = dsMs;
        }


        private void Clear2()
        {
            txbKt.Clear();
            txbMs.Clear();
            textBox1.Clear();
        }
        private void AddKt()
        {
            try
            {
                string tenKt = txbKt.Text.Trim();
                if (string.IsNullOrWhiteSpace(tenKt))
                {
                    MessageBox.Show("Vui lòng nhập kích thước!");
                    return;
                }

                if (ktBll.Exists(x => x.TenKichThuoc.ToLower() == tenKt.ToLower()))
                {
                    MessageBox.Show("Kích thước này đã tồn tại!");
                    return;
                }

                ktBll.Add(new KichThuoc { TenKichThuoc = tenKt });
                LoadDsKt();
                txbKt.Clear();
                MessageBox.Show("Thêm kích thước thành công!");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void AddMs()
        {
            try
            {
                string tenMoi = txbMs.Text.Trim();
                if (string.IsNullOrWhiteSpace(tenMoi))
                {
                    MessageBox.Show("Vui lòng nhập tên màu sắc!");
                    return;
                }

                // Kiểm tra trùng tên (không phân biệt hoa thường)
                if (msBll.Exists(x => x.TenMau.ToLower() == tenMoi.ToLower()))
                {
                    MessageBox.Show("Tên màu này đã tồn tại!");
                    return;
                }

                msBll.Add(new MauSac { TenMau = tenMoi });
                LoadDsMs(); // Load lại Grid thuộc tính
                LoadMs();   // Load lại ComboBox bên tab Sản phẩm
                txbMs.Clear();
                MessageBox.Show("Thêm màu sắc thành công!");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void EditMs()
        {
            try
            {
                if (dgvMs.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn màu cần sửa!");
                    return;
                }

                int ma = int.Parse(dgvMs.CurrentRow.Cells["MaMau"].Value.ToString());
                var mau = msBll.GetById(ma);

                mau.TenMau = txbMs.Text.Trim();

                msBll.Update(mau);
                LoadDsMs();
                LoadMs();
                txbMs.Clear();
                MessageBox.Show("Sửa màu sắc thành công!");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }
        private void DeleteMs()
        {
            try
            {
                if (dgvMs.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn dòng cần xóa!");
                    return;
                }

                int ma = int.Parse(dgvMs.CurrentRow.Cells["MaMau"].Value.ToString());

                // KIỂM TRA RÀNG BUỘC: Nếu có sản phẩm đang dùng màu này thì không cho xóa
                if (ctspBll.Exists(x => x.MaMau == ma))
                {
                    MessageBox.Show("Không thể xóa! Màu này đang được sử dụng cho sản phẩm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Bạn có chắc muốn xóa màu này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    msBll.Delete(ma);
                    LoadDsMs();
                    LoadMs();
                    txbMs.Clear();
                    MessageBox.Show("Xóa thành công!");
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi hệ thống: " + ex.Message); }
        }
        private void editKt()
        {
            try
            {
                if (dgvKt.Rows.Count == 0)
                {
                    MessageBox.Show($"Vui lòng chọn dòng cần sửa!");
                    return;
                }

                var duLieu = int.Parse(dgvKt.CurrentRow.Cells["MaKichThuoc"].Value.ToString());
                var timDuLieu = ktBll.GetById(duLieu);

                timDuLieu.TenKichThuoc = txbKt.Text.Trim();

                ktBll.Update(timDuLieu);
                LoadDsKt();
                Clear2();
                MessageBox.Show($"Sửa thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void deleteKt()
        {
            try
            {
                if (dgvKt.RowCount == 0)
                {
                    MessageBox.Show($"Vui lòng chọn dòng cần xóa!");
                    return;
                }
                int maKichThuoc = int.Parse(dgvKt.CurrentRow.Cells["MaKichThuoc"].Value.ToString());
                var timMa = ktBll.GetById(maKichThuoc);

                var confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.No) return;

                ktBll.Delete(maKichThuoc);
                LoadDsKt();

                MessageBox.Show($"Xóa thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xảy ra: " + ex.Message);
            }

        }
        #endregion

        private void btnAddKt_Click(object sender, EventArgs e)
        {
            AddKt();
        }

        private void btnEditKt_Click(object sender, EventArgs e)
        {
            editKt();
        }

        private void btnDeleteKt_Click(object sender, EventArgs e)
        {
            deleteKt();
        }

        private void btnAddMs_Click(object sender, EventArgs e)
        {
            AddMs();    // Gọi hàm thêm vào DB
            LoadMs();   // PHẢI CÓ: Gọi lại hàm này để đổ dữ liệu mới từ DB lên ComboBox/Grid
            LoadDSSP(); // (Nếu cần) Cập nhật lại bảng danh sách sản phẩm
        }

        private void btnEditMs_Click(object sender, EventArgs e)
        {
            EditMs();
        }

        private void btnDeleteMs_Click(object sender, EventArgs e)
        {
            DeleteMs();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clear2();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clear2();
        }

        private void dgvKt_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvKt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvKt.Rows.Count)
            {
                var val = dgvKt.Rows[e.RowIndex].Cells["TenKichThuoc"].Value;
                txbKt.Text = val != null ? val.ToString() : "";
            }
        }
        private void dgvMs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvMs.CurrentRow != null)
            {
                var val = dgvMs.Rows[e.RowIndex].Cells["TenMau"].Value;
                txbMs.Text = val != null ? val.ToString() : "";
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.CurrentRow != null)
            {
                var val = dataGridView1.Rows[e.RowIndex].Cells["TenThuongHieu"].Value;
                textBox1.Text = val != null ? val.ToString() : "";
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtMa_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbTH_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvMs_CellContentClick(object sender, EventArgs e)
        {

        }
        // --- THÊM THƯƠNG HIỆU ---
        private void AddTH()
        {
            try
            {
                string tenTH = textBox1.Text.Trim(); // textBox1 là ô nhập của Thương hiệu
                if (string.IsNullOrWhiteSpace(tenTH))
                {
                    MessageBox.Show("Vui lòng nhập tên thương hiệu!");
                    return;
                }

                if (thBll.Exists(x => x.TenThuongHieu.ToLower() == tenTH.ToLower()))
                {
                    MessageBox.Show("Thương hiệu này đã tồn tại!");
                    return;
                }

                thBll.Add(new ThuongHieu { TenThuongHieu = tenTH });
                LoadTh(); // Hàm này của bạn đã bao gồm load cả Grid và ComboBox
                textBox1.Clear();
                MessageBox.Show("Thêm thương hiệu thành công!");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        // --- SỬA THƯƠNG HIỆU ---
        private void EditTH()
        {
            try
            {
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn thương hiệu cần sửa!");
                    return;
                }

                int ma = int.Parse(dataGridView1.CurrentRow.Cells["MaThuongHieu"].Value.ToString());
                var th = thBll.GetById(ma);

                th.TenThuongHieu = textBox1.Text.Trim();

                thBll.Update(th);
                LoadTh();
                textBox1.Clear();
                MessageBox.Show("Cập nhật thành công!");
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void deleteTH()
        {
            try
            {
                if (dataGridView1.CurrentRow == null) return;

                // Lấy mã từ dòng đang chọn
                int ma = int.Parse(dataGridView1.CurrentRow.Cells["MaThuongHieu"].Value.ToString());

                // BƯỚC QUAN TRỌNG: Kiểm tra xem có sản phẩm nào đang dùng Thương hiệu này không
                // Nếu bạn không check dòng này, SaveChanges() sẽ luôn báo lỗi như trong ảnh
                bool isUsed = ctspBll.Exists(x => x.MaSpNavigation.MaThuongHieu == ma);

                if (isUsed)
                {
                    MessageBox.Show("Không thể xóa! Thương hiệu này đang được dùng cho sản phẩm trong kho.");
                    return; // Dừng lại luôn, không chạy xuống lệnh Delete
                }

                if (MessageBox.Show("Bạn có chắc muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    thBll.Delete(ma);
                    LoadTh(); // Gọi hàm này để danh sách cập nhật ngay lập tức mà không cần log out
                    MessageBox.Show("Xóa thành công!");
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            AddTH();      // Gọi hàm xử lý thêm
            LoadDSSP();   // Cập nhật lại bảng danh sách sản phẩm (nếu có hiển thị cột Thương hiệu)
        }

        // Nút Sửa Thương hiệu (Button 5)
        private void button5_Click(object sender, EventArgs e)
        {
            // Xác nhận trước khi sửa
            var res = MessageBox.Show("Bạn có chắc chắn muốn sửa thương hiệu này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                EditTH();
                LoadDSSP();
            }
        }

        // Nút Xóa Thương hiệu (Button 4)
        private void button4_Click(object sender, EventArgs e)
        {
            // Xác nhận trước khi xóa
            var res = MessageBox.Show("Xóa thương hiệu có thể ảnh hưởng đến sản phẩm liên quan. Bạn vẫn muốn xóa?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                deleteTH();
                LoadDSSP();
            }
        }

        // Nút Làm mới Thương hiệu (Button 3)
        private void button3_Click(object sender, EventArgs e)
        {
            cbTH.SelectedIndex = -1;
            cbTH.Text = "";
        }
    }
}