using DuAn1_Nhom4.BLL;
using DuAn1_Nhom4.Models;
using Org.BouncyCastle.Crypto.Macs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuAn1_Nhom4.GUI
{
    public partial class QuanLyNhanVien : Form
    {
        GenericBLL<NhanVien> nvBll = new GenericBLL<NhanVien>();
        GenericBLL<ChucVu> cvBll = new GenericBLL<ChucVu>();
        GenericBLL<TaiKhoanNhanVien> tkBll = new GenericBLL<TaiKhoanNhanVien>();
        public QuanLyNhanVien()
        {
            InitializeComponent();
            LoadDsNv();
            LoadDsTk();
            LoadCv();
            rbHD.Checked = true;
            btnLuu.Visible = false;
            btnHuyLuu.Visible = false;
            btnLuuThem.Visible = false;
            btnHuyTK.Visible = false;
            btnLuuAddTK.Visible = false;
            btnLuuEditTK.Visible = false;
        }
        #region Tab Thông Tin Nhân Viên
        private void LoadDsNv()
        {
            var dsnv = nvBll.GetAll(x => x.MaChucVuNavigation)
                .Select((x, Index) => new
                {
                    STT = Index + 1,
                    Id = x.Id,
                    HoTen = x.HoTen,
                    SoDienThoai = x.SoDienThoai,
                    Email = x.Email,
                    // Đặt tên tường minh cho cột này là TenChucVu
                    TenChucVu = x.MaChucVuNavigation != null ? x.MaChucVuNavigation.TenChucVu : ""
                }).ToList();

            dataGridView1.DataSource = dsnv;
        }

        private void LoadCv()
        {
            var dsCv = cvBll.GetAll();
            cbVaiTro.DataSource = dsCv;
            cbVaiTro.DisplayMember = "TenChucVu";
            cbVaiTro.ValueMember = "MaChucVu";
        }

        private void clear()
        {
            txbMa.Clear();
            txbHoTen.Clear();
            txbSDT.Clear();
            txbEmail.Clear();
            txbTim.Clear();
        }

        private void addNv()
        {
            try
            {
                // 1. Kiểm tra Validate dữ liệu đầu vào
                if (string.IsNullOrWhiteSpace(txbHoTen.Text))
                {
                    MessageBox.Show("Vui lòng nhập họ tên nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string sdt = txbSDT.Text.Trim();
                if (!Regex.IsMatch(sdt, @"^0\d{8,10}$"))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string email = txbEmail.Text.Trim().ToLower();
                if (!email.EndsWith("@gmail.com"))
                {
                    MessageBox.Show("Email phải có định dạng @gmail.com", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 2. Kiểm tra trùng lặp (SĐT và Email không được trùng trong DB)
                if (nvBll.Exists(x => x.SoDienThoai == sdt))
                {
                    MessageBox.Show("Số điện thoại này đã thuộc về nhân viên khác!");
                    return;
                }

                if (nvBll.Exists(x => x.Email == email))
                {
                    MessageBox.Show("Email này đã được sử dụng!");
                    return;
                }

                // 3. Khởi tạo và gán dữ liệu Nhân viên
                NhanVien nv = new NhanVien();
                nv.HoTen = txbHoTen.Text.Trim();
                nv.SoDienThoai = sdt;
                nv.Email = email;
                nv.MaChucVu = Convert.ToInt32(cbVaiTro.SelectedValue);

                // 4. THỰC THI LƯU NHÂN VIÊN (Quan trọng: Lưu trước để sinh ra ID)
                nvBll.Add(nv);

                // 5. TỰ ĐỘNG TẠO TÀI KHOẢN (Sử dụng nv.Id vừa được SQL cấp)
                try
                {
                    TaiKhoanNhanVien tk = new TaiKhoanNhanVien();
                    tk.NhanVienId = nv.Id; // Kết nối trực tiếp với nhân viên vừa tạo

                    // Tên đăng nhập mặc định là phần trước chữ @ của Email
                    string tenDN = email.Split('@')[0];

                    // Kiểm tra nếu tên đăng nhập này đã tồn tại trong bảng tài khoản chưa
                    if (tkBll.Exists(x => x.TenDangNhap == tenDN))
                    {
                        // Nếu trùng username thì thêm đuôi ID để phân biệt
                        tk.TenDangNhap = tenDN + nv.Id.ToString();
                    }
                    else
                    {
                        tk.TenDangNhap = tenDN;
                    }

                    tk.MatKhau = "123"; // Mật khẩu mặc định
                    tk.TrangThai = "1";

                    tkBll.Add(tk);
                }
                catch (Exception exTk)
                {
                    MessageBox.Show("Lỗi tự động cấp tài khoản: " + exTk.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // 6. Cập nhật lại toàn bộ giao diện và dữ liệu
                LoadDsNv();     // Cập nhật bảng nhân viên
                LoadDsTk();     // Cập nhật bảng tài khoản

                // Nếu bạn có hàm nạp lại ComboBox chọn nhân viên ở Tab tài khoản thì gọi ở đây:
                // LoadComboBoxTenNhanVien(); 

                clear(); // Xóa trắng các ô nhập sau khi thêm thành công

                MessageBox.Show($"Thêm thành công nhân viên: {nv.HoTen}\n" +
                                $"Tài khoản mặc định: {email.Split('@')[0]}\n" +
                                $"Mật khẩu: 123", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Lấy thông báo lỗi sâu nhất từ SQL Server
                string errorDetail = ex.InnerException?.InnerException?.Message
                                     ?? ex.InnerException?.Message
                                     ?? ex.Message;

                MessageBox.Show("Lỗi chi tiết từ hệ thống: " + errorDetail,
                                "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void editNv()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txbMa.Text))
                {
                    MessageBox.Show("Vui lòng chọn dòng cần sửa!");
                    return;
                }

                var ma = int.Parse(txbMa.Text);
                var timMa = nvBll.GetById(ma);

                if (timMa == null)
                {
                    MessageBox.Show("Không tìm thấy nhân viên trong hệ thống!");
                    return;
                }

                // Validate dữ liệu nhập
                if (string.IsNullOrWhiteSpace(txbHoTen.Text))
                {
                    MessageBox.Show("Vui lòng nhập họ tên.");
                    return;
                }

                if (!Regex.IsMatch(txbSDT.Text.Trim(), @"^0\d{8,}$"))
                {
                    MessageBox.Show("Số điện thoại phải bắt đầu bằng số 0 và có ít nhất 9 chữ số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txbEmail.Text) || !txbEmail.Text.Contains("@"))
                {
                    MessageBox.Show("Vui lòng nhập email hợp lệ.");
                    return;
                }

                if (!txbEmail.Text.Trim().EndsWith("@gmail.com"))
                {
                    MessageBox.Show("Email phải kết thúc bằng @gmail.com", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra trùng lặp nhưng loại trừ chính nhân viên đang sửa
                if (nvBll.Exists(x => x.SoDienThoai == txbSDT.Text.Trim() && x.Id != ma))
                {
                    MessageBox.Show("Số điện thoại đã tồn tại!");
                    return;
                }
                // Kiểm tra trùng Email và tìm ra ai đang giữ nó
                var emailNhap = txbEmail.Text.Trim().ToLower();
                var nhanVienTrung = nvBll.GetAll().FirstOrDefault(x => x.Email.ToLower() == emailNhap && x.Id != ma);

                if (nhanVienTrung != null)
                {
                    // Nó sẽ hiện: Email này đã được dùng bởi: Nguyễn Xuân Nam (ID: 7)
                    MessageBox.Show($"Email đã tồn tại!\nNgười đang sử dụng: {nhanVienTrung.HoTen} (Mã NV: {nhanVienTrung.Id})",
                                    "Thông báo trùng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Gán dữ liệu mới
                timMa.HoTen = txbHoTen.Text.Trim();
                timMa.SoDienThoai = txbSDT.Text.Trim();
                timMa.Email = txbEmail.Text.Trim().ToLower();
                timMa.MaChucVu = Convert.ToInt32(cbVaiTro.SelectedValue);

                nvBll.Update(timMa);
                LoadDsNv();
                dataGridView1.DataSource = null;
                LoadDsNv();
                clear();

                MessageBox.Show("Sửa thành công!");
            }
            catch (Exception ex)
            {
                // Lấy thông báo lỗi sâu nhất từ SQL Server
                string errorDetail = ex.InnerException?.InnerException?.Message
                                     ?? ex.InnerException?.Message
                                     ?? ex.Message;

                MessageBox.Show("Lỗi chi tiết từ hệ thống: " + errorDetail, "Lỗi Database",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deletenv()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txbMa.Text))
                {
                    MessageBox.Show($"Vui lòng chọn dòng cần xóa!");
                }

                var nvDaCoTK = tkBll.GetById(int.Parse(txbMa.Text));
                if (nvDaCoTK != null)
                {
                    MessageBox.Show($"Nhân viên này hiện đang có tài khoản!");
                    return;
                }
                var ma = int.Parse(txbMa.Text);
                var timMa = nvBll.GetById(ma);

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No) return;

                nvBll.Delete(timMa.Id);
                LoadDsNv();
                clear();

                MessageBox.Show($"Xóa thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xảy ra: " + ex.Message);
            }

        }
        private void findTk()
        {
            try
            {
                var duLieu = txbTimTk.Text.Trim().ToLower();
                var ds = tkBll.GetAll();

                // Lấy vai trò người đang đăng nhập
                string vaiTroHienTai = Program.ChucVuDangNhap;

                var dsSearch = ds.Where(x =>
                    ((x.NhanVien != null && x.NhanVien.HoTen.ToLower().Contains(duLieu)) ||
                     (x.TenDangNhap != null && x.TenDangNhap.ToLower().Contains(duLieu)))
                );

                // --- PHÂN QUYỀN TẠI ĐÂY ---
                // Nếu không phải Quản trị viên, chỉ cho phép tìm thấy tài khoản CỦA CHÍNH HỌ
                if (vaiTroHienTai != "Quản trị viên")
                {
                    // Giả sử bạn lưu MaNhanVien của người đăng nhập vào Program.MaNV
                    dsSearch = dsSearch.Where(x => x.NhanVienId == Program.MaNV);
                }

                var finalResult = dsSearch.Select((x, Index) => new
                {
                    STT = Index + 1,
                    Id = x.Id,
                    NhanVienId = x.NhanVienId,
                    HoTen = x.NhanVien != null ? x.NhanVien.HoTen : "Chưa xác định",
                    TenDangNhap = x.TenDangNhap,
                    // Nếu không phải Admin thì ẩn mật khẩu đi cho bảo mật
                    MatKhau = (vaiTroHienTai == "Quản trị viên") ? x.MatKhau : "********",
                    TrangThai = (x.TrangThai.ToString() == "1") ? "Đang hoạt động" : "Ngừng hoạt động"
                }).ToList();

                dtgDanhSach.DataSource = finalResult;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // tabTK là tên Page "Tài khoản nhân viên" bạn đã khai báo
            // Chúng ta kiểm tra nếu Tab được chọn là tabTK
            if (tabControl1.SelectedTab == tabTK)
            {
                RefreshTaiKhoanTab();
            }
        }

        private void RefreshTaiKhoanTab()
        {
            try
            {
                // 1. Load lại bảng danh sách tài khoản lên DataGridView
                // (Đảm bảo hàm LoadDsTk của bạn đã được định nghĩa bên dưới)
                LoadDsTk();

                // 2. Dọn dẹp giao diện để bạn TỰ NHẬP MỚI
                // Xóa nội dung trong các ô TextBox để bạn tự điền tay
                txbTenNv.Clear();       // Ô ID nhân viên (bạn sẽ tự nhập mã vào đây)
                txbTenDangNhap.Clear(); // Ô Tên đăng nhập
                txbMk1.Clear();        // Ô Mật khẩu
                txbMaTk.Clear();       // Ô Mã tài khoản (nếu có)

                // 3. Trạng thái mặc định cho RadioButton
                rbHD.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi làm mới giao diện: " + ex.Message, "Thông báo");
            }
        }
        private void LoadComboBoxVaiTro()
        {
            // 1. Tạo một danh sách chứa cả Tên hiển thị và Giá trị ID tương ứng với DB
            var danhSachVaiTro = new List<object>
    {
        new { Ten = "Quản lý kho", Ma = 2 }, // Thay số 1, 2, 3 bằng ID thực tế trong bảng ChucVu của bạn
        new { Ten = "Nhân viên kiểm kho", Ma = 3 },
        new { Ten = "Nhân viên bán hàng", Ma = 4 }
    };

            // 2. Nếu là Admin thì thêm quyền Quản trị viên
            if (Program.ChucVuDangNhap == "Quản trị viên")
            {
                danhSachVaiTro.Add(new { Ten = "Quản trị viên", Ma = 1 });
            }

            // 3. Đổ dữ liệu vào ComboBox
            cbVaiTro.DataSource = danhSachVaiTro;
            cbVaiTro.DisplayMember = "Ten"; // Hiển thị chữ cho người dùng chọn
            cbVaiTro.ValueMember = "Ma";    // Giá trị ID dùng để lưu vào Database

            if (cbVaiTro.Items.Count > 0) cbVaiTro.SelectedIndex = 0;
        }
        private void PhanQuyenGiaoDien()
        {
            string vaiTro = Program.ChucVuDangNhap;

            // Danh sách các vai trò chỉ được xem
            if (vaiTro == "Nhân viên kiểm kho" || vaiTro == "Nhân viên bán hàng" || vaiTro == "Nhân viên nhập hàng")
            {
                // Khóa các ô TextBox không cho sửa
                txbHoTen.ReadOnly = true;
                txbSDT.ReadOnly = true;
                txbEmail.ReadOnly = true;
                cbVaiTro.Enabled = false;

                // Ẩn các nút Thêm, Lưu, Xóa (nếu bạn có đặt tên như vậy)
                btnLuu.Visible = false;
                btnXoa.Visible = false;

                // Vô hiệu hóa tính năng click để sửa nếu cần
                // allowCellClick1 = false; 
            }
        }

        private void QuanLyNhanVien_Load(object sender, EventArgs e)
        {
            LoadComboBoxVaiTro();
            PhanQuyenGiaoDien(); // Gọi hàm phân quyền tại đây
            cbVaiTro.Enabled = false; // Khóa ô vai trò mặc định
        }
        private bool allowCellClick1 = true;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!allowCellClick1) return;
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                    txbMa.Text = row.Cells["Id"]?.Value?.ToString() ?? "";
                    txbHoTen.Text = row.Cells["HoTen"]?.Value?.ToString() ?? "";
                    txbSDT.Text = row.Cells["SoDienThoai"]?.Value?.ToString() ?? "";
                    txbEmail.Text = row.Cells["Email"]?.Value?.ToString() ?? "";

                    // Cách lấy Vai Trò an toàn nhất:
                    // Nếu có cột TenChucVu thì lấy, không thì lấy tạm MaChucVu
                    if (dataGridView1.Columns.Contains("TenChucVu") && row.Cells["TenChucVu"].Value != null)
                    {
                        cbVaiTro.Text = row.Cells["TenChucVu"].Value.ToString();
                    }
                    else if (dataGridView1.Columns.Contains("MaChucVu") && row.Cells["MaChucVu"].Value != null)
                    {
                        cbVaiTro.SelectedValue = row.Cells["MaChucVu"].Value;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tại CellClick: " + ex.Message);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            // Ẩn các nút chính
            button4.Visible = false;
            button3.Visible = false;
            button2.Visible = false;
            button1.Visible = false;

            // Hiện nút Lưu/Hủy
            btnLuuThem.Visible = true;
            btnHuyLuu.Visible = true;

            clear(); // Xóa trắng các ô để nhập mới

            // Sinh mã tự động
            txbMa.Text = SinhMaNhanVienTuDong();
            txbMa.ReadOnly = true; // Không cho sửa mã

            // Mở khóa các ô nhập liệu
            txbHoTen.ReadOnly = false;
            txbSDT.ReadOnly = false;
            txbEmail.ReadOnly = false;
            cbVaiTro.Enabled = true;

            allowCellClick1 = false;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã chọn nhân viên nào chưa
            if (string.IsNullOrEmpty(txbMa.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa từ danh sách!");
                return;
            }

            button4.Visible = false;
            button3.Visible = false;
            button2.Visible = false;
            button1.Visible = false;

            btnLuu.Visible = true;
            btnHuyLuu.Visible = true;

            // Mở khóa các ô nhập liệu
            txbHoTen.ReadOnly = false;
            txbSDT.ReadOnly = false;
            txbEmail.ReadOnly = false;

            // MỞ KHÓA VAI TRÒ ĐỂ THAY ĐỔI
            cbVaiTro.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            deletenv();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            findTk();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            editNv();
        }
        private void btnHuyLuu_Click(object sender, EventArgs e)
        {
            button4.Visible = true;
            button3.Visible = true;
            button2.Visible = true;
            button1.Visible = true;

            btnLuu.Visible = false;
            btnHuyLuu.Visible = false;
            btnLuuThem.Visible = false;

            txbHoTen.ReadOnly = true;
            txbSDT.ReadOnly = true;
            txbEmail.ReadOnly = true;

            // QUAN TRỌNG: Khóa lại ComboBox Vai trò
            cbVaiTro.Enabled = false;

            allowCellClick1 = true;
        }

        private void btnLuuThem_Click(object sender, EventArgs e)
        {
            addNv();
        }
        private void LoadDsTk()
        {
            try
            {
                var data = tkBll.GetAll(x => x.NhanVien);

                var dsTk = data.Select((x, Index) => new
                {
                    STT = Index + 1,
                    Id = x.Id,
                    NhanVienId = x.NhanVienId,
                    HoTen = x.NhanVien != null ? x.NhanVien.HoTen : "Chưa xác định",
                    TenDangNhap = x.TenDangNhap,
                    MatKhau = x.MatKhau,
                    // SO SÁNH CHÍNH XÁC CHUỖI "Đang Hoạt Động"
                    TrangThai = (x.TrangThai == "Đang Hoạt Động") ? "Đang hoạt động" : "Ngừng hoạt động"
                }).ToList();

                dtgDanhSach.DataSource = null;
                dtgDanhSach.DataSource = dsTk;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị danh sách: " + ex.Message);
            }
        }
        private void Clear2()
        {
            txbMaTk.Clear();

            // SỬA TẠI ĐÂY: Dùng .Clear() thay vì .SelectedIndex
            txbTenNv.Clear();

            txbTenDangNhap.Clear();
            txbMk1.Clear();
            txbTimTk.Clear();

            // Nếu bạn có RadioButton trạng thái, có thể reset luôn ở đây
            rbHD.Checked = true;
        }
        private void AddTk()
        {
            try
            {
                // Kiểm tra nhập liệu trống trước khi xử lý
                if (string.IsNullOrWhiteSpace(txbTenNv.Text) ||
                    string.IsNullOrWhiteSpace(txbTenDangNhap.Text) ||
                    string.IsNullOrWhiteSpace(txbMk1.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin tài khoản!");
                    return;
                }

                TaiKhoanNhanVien tk = new TaiKhoanNhanVien();
                tk.NhanVienId = int.Parse(txbTenNv.Text);
                tk.TenDangNhap = txbTenDangNhap.Text.Trim();
                tk.MatKhau = txbMk1.Text.Trim();
                // LƯU CHUỖI CỐ ĐỊNH: Viết hoa các chữ cái đầu
                tk.TrangThai = rbHD.Checked ? "Đang Hoạt Động" : "Ngừng Hoạt Động";

                // Kiểm tra xem nhân viên đã có tài khoản chưa
                if (tkBll.Exists(x => x.NhanVienId.ToString() == txbTenNv.Text))
                {
                    MessageBox.Show($"Nhân viên này đã có tài khoản!");
                    return;
                }

                // Kiểm tra sự tồn tại của nhân viên
                var nhanVien = nvBll.GetById(tk.NhanVienId);
                if (nhanVien == null)
                {
                    MessageBox.Show("Nhân viên này chưa tồn tại trong hệ thống!");
                    return;
                }

                // Kiểm tra trùng tên đăng nhập
                if (tkBll.Exists(x => x.TenDangNhap.ToLower() == tk.TenDangNhap.ToLower()))
                {
                    MessageBox.Show($"Tên tài khoản đã tồn tại!");
                    return;
                }

                tkBll.Add(tk);
                LoadDsTk();
                Clear2();

                MessageBox.Show($"Thêm thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xảy ra: " + ex.Message);
            }
        }
        private void deleteTk()
        {
            try
            {
                if (string.IsNullOrEmpty(txbMaTk.Text))
                {
                    MessageBox.Show($"Vui lòng chọn tài khoản cần xóa!");
                    return;
                }
                var ma = int.Parse(txbMaTk.Text);
                var timMa = tkBll.GetById(ma);

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No) return;

                tkBll.Delete(timMa.Id);
                LoadDsTk();
                Clear2();

                MessageBox.Show($"Xóa thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xảy ra: " + ex.Message);
            }
        }
        private void editTk()
        {
            try
            {
                // 1. Kiểm tra xem đã chọn tài khoản ở GridView chưa
                if (string.IsNullOrEmpty(txbMaTk.Text))
                {
                    MessageBox.Show("Vui lòng chọn tài khoản cần sửa!");
                    return;
                }

                var ma = int.Parse(txbMaTk.Text);
                var timMa = tkBll.GetById(ma);

                if (timMa == null)
                {
                    MessageBox.Show("Không tìm thấy tài khoản trong hệ thống!");
                    return;
                }

                // 2. Kiểm tra nhập liệu trống
                if (string.IsNullOrWhiteSpace(txbTenDangNhap.Text) || string.IsNullOrWhiteSpace(txbMk1.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ Tên đăng nhập và Mật khẩu!");
                    return;
                }

                // 3. Kiểm tra trùng Tên đăng nhập (trừ chính nó)
                if (txbTenDangNhap.Text.ToLower() != timMa.TenDangNhap.ToLower())
                {
                    if (tkBll.Exists(x => x.TenDangNhap.ToLower() == txbTenDangNhap.Text.Trim().ToLower()))
                    {
                        MessageBox.Show("Tên đăng nhập này đã tồn tại, vui lòng chọn tên khác!");
                        return;
                    }
                }

                // 4. Gán dữ liệu mới (LƯU ĐỒNG BỘ VỚI HÀM ADD)
                timMa.TenDangNhap = txbTenDangNhap.Text.Trim();
                timMa.MatKhau = txbMk1.Text.Trim();
                timMa.TrangThai = rbHD.Checked ? "Đang Hoạt Động" : "Ngừng Hoạt Động";

                // 5. Thực thi cập nhật
                tkBll.Update(timMa);

                LoadDsTk();
                Clear2();

                // Hiện lại các nút chức năng
                btnThem.Visible = true;
                btnSua.Visible = true;
                btnXoa.Visible = true;
                btnLamMoi.Visible = true;
                btnLuuEditTK.Visible = false;
                btnHuyTK.Visible = false;

                MessageBox.Show("Cập nhật tài khoản thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xảy ra: " + ex.Message);
            }
        }
        private void dtgDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!allowCellClick2) return;
            try
            {
                if (e.RowIndex >= 0)
                {
                    txbMaTk.Text = dtgDanhSach.Rows[e.RowIndex].Cells["id"].Value.ToString();
                    txbTenNv.Text = dtgDanhSach.Rows[e.RowIndex].Cells["NhanVienId"].Value.ToString();
                    txbTenDangNhap.Text = dtgDanhSach.Rows[e.RowIndex].Cells["TenDangNhap"].Value.ToString();
                    txbMk1.Text = dtgDanhSach.Rows[e.RowIndex].Cells["MatKhau"].Value.ToString();
                    string trangThai = dtgDanhSach.Rows[e.RowIndex].Cells["TrangThai"].Value.ToString();

                    if (trangThai == "Đang Hoạt Động")
                    {
                        rbHD.Checked = true;
                    }
                    else if (trangThai == "Ngừng Hoạt Động")
                    {
                        rbNgung.Checked = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi " + ex.Message);
            }
        }
        private bool allowCellClick2 = true;
        private void btnThem_Click(object sender, EventArgs e)
        {
            txbTenNv.ReadOnly = false;       // Quan trọng: Cho phép nhập ID nhân viên
            txbTenNv.Enabled = true;
            btnThem.Visible = false;
            btnSua.Visible = false;
            btnXoa.Visible = false;
            btnLamMoi.Visible = false;

            txbTenNv.Enabled = true; // Cho phép chọn
            txbTenDangNhap.ReadOnly = false;
            txbMk1.ReadOnly = false;

            Clear2();

            btnLuuAddTK.Visible = true;
            btnHuyTK.Visible = true;

            allowCellClick2 = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            {
                txbTenNv.ReadOnly = false;       // Quan trọng: Cho phép nhập ID nhân viên
                txbTenNv.Enabled = true;
                // 1. Ẩn các nút chức năng chính
                btnThem.Visible = false;
                btnSua.Visible = false;
                btnXoa.Visible = false;
                btnLamMoi.Visible = false;

                // 2. Hiện nút Lưu và Hủy dành riêng cho việc sửa
                btnLuuEditTK.Visible = true;
                btnHuyTK.Visible = true;

                // 3. Thiết lập quyền nhập liệu (ReadOnly)
                // KHÔNG cho sửa Mã tài khoản và ID nhân viên để tránh lỗi logic database
                txbMaTk.ReadOnly = true;
                txbTenNv.Enabled = false; // Khóa lại không cho chọn

                // CHO PHÉP sửa các thông tin còn lại
                txbTenDangNhap.ReadOnly = false;
                txbMk1.ReadOnly = false;

                // Đừng quên cho phép chọn lại trạng thái (RadioButton)
                rbHD.Enabled = true;
                rbNgung.Enabled = true;
            }
        }
        private void btnBatDauThem_Click(object sender, EventArgs e)
        {
            // Gọi hàm sinh mã và hiển thị lên textbox
            txbMa.Text = SinhMaNhanVienTuDong();

            // Khóa textbox lại để người dùng không sửa lung tung
            txbMa.ReadOnly = true;

            // Xóa trống các ô khác để nhập mới
            txbHoTen.Clear();
            txbEmail.Clear();
            txbSDT.Clear();
        }
        private string SinhMaNhanVienTuDong()
        {
            // Lấy nhân viên có Id lớn nhất trong DB
            var lastNV = nvBll.GetAll()
                              .OrderByDescending(x => x.Id)
                              .FirstOrDefault();

            // Nếu chưa có nhân viên nào thì bắt đầu từ NV001
            int lastId = lastNV?.Id ?? 0;

            // Sinh mã mới dựa trên Id tiếp theo
            return "NV" + (lastId + 1).ToString("D3");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            deleteTk();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            Clear2();
        }

        private void txbTimTk_TextChanged(object sender, EventArgs e)
        {
            findTk(); // gọi hàm tìm kiếm tài khoản bạn đã viết
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnHuyTK_Click(object sender, EventArgs e)
        {
            btnThem.Visible = true;
            btnSua.Visible = true;
            btnXoa.Visible = true;
            btnLamMoi.Visible = true;

            txbTenNv.Enabled = false; // Khóa lại không cho chọn
            txbTenDangNhap.ReadOnly = true;
            txbMk1.ReadOnly = true;

            btnLuuAddTK.Visible = false;
            btnLuuEditTK.Visible = false;
            btnHuyTK.Visible = false;

            allowCellClick2 = true;
        }

        private void btnLuuAddTK_Click(object sender, EventArgs e)
        {
            // Cách 1: Dựa vào Mã tài khoản (An toàn nhất)
            // Nếu Mã tài khoản trống -> Chắc chắn là đang Thêm mới
            if (string.IsNullOrEmpty(txbMaTk.Text))
            {
                AddTk();
            }
            else
            {
                editTk();
            }
        }

        private void btnLuuEditTK_Click(object sender, EventArgs e)
        {
            editTk();
        }
        #endregion

        private void txbMa_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}