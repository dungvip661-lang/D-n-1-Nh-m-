using DuAn1_Nhom4.GUI;
using DuAn1_Nhom4.GUI.Nhập_hàng;
using DuAn1_Nhom4.Models;
using System.ComponentModel;
using System.Windows.Forms;
using System.ComponentModel;
namespace DuAn1_Nhom4
{
    public partial class FormMain : Form
    {
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]

        public NhanVien NhanVien { get; set; }

        public FormMain()
        {
            InitializeComponent();

        }
        private void LoadFormToPanel(Form form)
        {
            panelMain.Controls.Clear();

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panelMain.Controls.Add(form);
            form.Show();
        }

        private void btnSP_Click(object sender, EventArgs e)
        {
            LoadFormToPanel(new QuanLySanPham());
            HighlightButton((Button)sender);
        }

        private void btnNV_Click(object sender, EventArgs e)
        {
            LoadFormToPanel(new QuanLyNhanVien());
            HighlightButton((Button)sender);
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            LoadFormToPanel(new PhieuNhapF(NhanVien));
            HighlightButton((Button)sender);
        }
        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            LoadFormToPanel(new GUI.PhieuXuatF(NhanVien));
            HighlightButton((Button)sender);
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            // Mặc định load Form Thống kê khi mở máy
            LoadFormToPanel(new ThongKe());

            // Lấy tên chức vụ từ biến toàn cục đã lưu lúc đăng nhập
            string chucVu = Program.ChucVuDangNhap;

            // PHÂN QUYỀN: Chỉ Quản trị viên mới thấy nút Nhân Viên
            if (chucVu != "Quản trị viên")
            {
                btnNV.Visible = false; // Ẩn nút Nhân viên nếu không phải Admin
            }

            // Bạn có thể ẩn thêm các nút khác tùy theo chức vụ ở đây
            PhanQuyenChiTiet(chucVu);
        }
        private void PhanQuyenChiTiet(string chucVu)
        {
            // 1. Mặc định hiện tất cả các nút
            btnNV.Visible = true;
            btnNhapHang.Visible = true;
            btnXuatHang.Visible = true;
            btnThongKe.Visible = true;

            // 2. Mặc định hiện các bảng thống kê (Giả sử bạn gom chúng vào pnThongKe)
            panelMain.Controls.Clear();

            if (chucVu == "Nhân viên bán hàng")
            {
                btnThongKe.Visible = false;
                btnNV.Visible = false;
                btnNhapHang.Visible = false;
                btnNCC.Visible = false;
                // PHẢI THÊM DÒNG NÀY:
                panelMain.Controls.Clear();
                LoadFormToPanel(new QuanLySanPham());
            }
            else if (chucVu == "Nhân viên kiểm kho")
            {
                btnThongKe.Visible = false;
                btnXuatHang.Visible = false;
                btnNV.Visible = false;

                // Tương tự, nhân viên kho cũng không được xem doanh thu
                panelMain.Controls.Clear();
            }
            else if (chucVu == "Quản lý kho")
            {
                btnNV.Visible = false;
                btnThongKe.Visible = false;   // Ẩn nút Thống kê
                btnXuatHang.Visible = false;  // Ẩn nút Xuất hàng (Lưu ý: kiểm tra tên ID nút này có đúng là btnXuatHang hay btnHoaDon nhé)
                // Quản lý kho có thể xem thống kê nên không cần ẩn pnThongKe
            }
        }
        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            LoadFormToPanel(new TaiKhoanF(NhanVien));
            HighlightButton((Button)sender);
        }

        private void btnLichSu_Click(object sender, EventArgs e)
        {
            LoadFormToPanel(new FormLichSu(this.NhanVien));
            HighlightButton((Button)sender);
        }

        private void btnNCC_Click_1(object sender, EventArgs e)
        {
            LoadFormToPanel(new QuanLyNCC());
            HighlightButton((Button)sender);

        }
        private void HighlightButton(Button clickedButton)
        {
            foreach (Control ctrl in panelSidebar.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.BackColor = Color.FromArgb(176, 196, 222); // Màu nền gốc
                    btn.ForeColor = Color.Black;
                    btn.Font = new Font(btn.Font, FontStyle.Regular);
                }
            }

            // Đổi màu nút đang được click
            clickedButton.BackColor = Color.FromArgb(100, 149, 237); // Màu đậm hơn (CornflowerBlue)
            clickedButton.ForeColor = Color.Black;
            clickedButton.Font = new Font(clickedButton.Font, FontStyle.Bold);
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            HighlightButton((Button)sender);

            DialogResult result = MessageBox.Show(
        "Bạn có chắc muốn đăng xuất không?",
        "Xác nhận đăng xuất",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Ẩn FormMain
                this.Hide();

                // Mở lại FormDangNhap
                FormDangNhap formDangNhap = new FormDangNhap();
                formDangNhap.Show();

                // Đóng hẳn FormMain khi FormDangNhap được đóng
                formDangNhap.FormClosed += (s, args) => this.Close();
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            LoadFormToPanel(new ThongKe());
            HighlightButton((Button)sender);
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}
