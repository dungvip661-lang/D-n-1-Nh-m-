using DuAn1_Nhom4.BLL;
using DuAn1_Nhom4.Models;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.ComponentModel;
namespace DuAn1_Nhom4.GUI.Hóa_đơn
{
    public partial class KhachHangF : Form
    {
        GenericBLL<KhachHang> GenericBLL = new GenericBLL<KhachHang>();
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]

        public KhachHang Kh { get; set; }
        public KhachHangF()
        {
            InitializeComponent();
        }

        private bool CheckNull()
        {

            if (string.IsNullOrEmpty(txtDiachi.Text) ||
                string.IsNullOrEmpty(txtEmail.Text) ||
                string.IsNullOrEmpty(txtSdt.Text) ||
                string.IsNullOrEmpty(txtTen.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            string sdt = txtSdt.Text.Trim();
            if (!Regex.IsMatch(sdt, @"^\d{10}$"))
            {
                MessageBox.Show("Số điện thoại phải gồm đúng 10 chữ số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSdt.Focus();
                return false;
            }
            string email = txtEmail.Text.Trim();
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Email không đúng định dạng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }


            return true; // Hợp lệ
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CheckNull() == false)
            {
                return; // Dừng nếu có trường hợp không hợp lệ
            }
            try
            {
                var khachHang = new KhachHang()
                {
                    Ten = txtTen.Text.Trim(),
                    DiaChi = txtDiachi.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Sdt = txtSdt.Text.Trim()
                };
                GenericBLL.Add(khachHang);
                MessageBox.Show("Thêm khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetForm(); // Reset form sau khi thêm thành công
                LoadKhachHang(); // Tải lại danh sách khách hàng
            }

            catch (Exception)
            {
                MessageBox.Show("Thêm khách hàng không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ResetForm()
        {
            txtDiachi.ResetText();
            txtEmail.ResetText();
            txtSdt.ResetText();
            txtTen.ResetText();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void LoadKhachHang()
        {
            dtgKH.DataSource = GenericBLL.GetAll().Select(
                (kh, index) => new
                {
                    STT = index + 1,
                    MaKH = kh.MaKh,
                    TenKH = kh.Ten,
                    Sdt = kh.Sdt,
                    DiaChi = kh.DiaChi,
                    Email = kh.Email

                }).ToList();

            dtgKH.Columns["MaKH"].HeaderText = "Mã khách hàng";
            dtgKH.Columns["TenKH"].HeaderText = "Tên khách hàng";
            dtgKH.Columns["Sdt"].HeaderText = "Số điện thoại";
            dtgKH.Columns["DiaChi"].HeaderText = "Địa chỉ";

        }

        private void KhachHangF_Load(object sender, EventArgs e)
        {
            LoadKhachHang();
        }

        private void txtTk_TextChanged(object sender, EventArgs e)
        {
            dtgKH.DataSource = GenericBLL.GetAll().Where(x => x.Sdt.Contains(txtTk.Text)).Select(
                (kh, index) => new
                {
                    STT = index + 1,
                    MaKH = kh.MaKh,
                    TenKH = kh.Ten,
                    Sdt = kh.Sdt,
                    DiaChi = kh.DiaChi,
                    Email = kh.Email

                }).ToList();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            var khachHang = dtgKH.CurrentRow.Cells["MaKH"].Value;
            if (khachHang == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Kh = GenericBLL.GetById((int)khachHang);
            if (Kh != null)
            {
                MessageBox.Show($"Đã chọn khách hàng: {Kh.Ten}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; // Trả về DialogResult OK để xác nhận
                this.Close(); // Đóng form sau khi xác nhận
            }
            else
            {
                MessageBox.Show("Không tìm thấy khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dtgKH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}
