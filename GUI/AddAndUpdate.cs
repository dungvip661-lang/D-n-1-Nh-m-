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
using DuAn1_Nhom4.BLL;
using DuAn1_Nhom4.Models;

namespace DuAn1_Nhom4.GUI
{
    public partial class AddAndUpdate : Form
    {
        NhaCungCap _ncc;
        GenericBLL<NhaCungCap> nhaCungCapBAL;
        public AddAndUpdate(NhaCungCap? nhaCungCap)
        {
            InitializeComponent();
            _ncc = nhaCungCap;
            LoadNccData();
            nhaCungCapBAL = new GenericBLL<NhaCungCap>();
        }
        private void LoadNccData()
        {
            if (_ncc != null)
            {
                // Chế độ SỬA: Đổ dữ liệu cũ vào
                txtMaNCC.Text = _ncc.MaNcc.ToString();
                txtTenNCC.Text = _ncc.TenNcc;
                txtDiaChi.Text = _ncc.DiaChi;
                txtEmail.Text = _ncc.Email;
                txtSDT.Text = _ncc.SoDienThoai;

                txtMaNCC.ReadOnly = true; // Không cho sửa mã khi đang cập nhật
            }
            else
            {
                // Chế độ THÊM MỚI: Tự sinh mã
                ClearForm();
                txtMaNCC.Text = GenerateNewMaNCC(); // Hiển thị mã vừa tạo
                txtMaNCC.ReadOnly = true;          // Khóa lại để người dùng biết đây là mã tự động
                txtMaNCC.BackColor = Color.LightGray; // Đổi màu xám cho chuyên nghiệp
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput()) return;
                if (_ncc == null)
                {
                    _ncc = new NhaCungCap
                    {
                        TenNcc = txtTenNCC.Text,
                        DiaChi = txtDiaChi.Text,
                        Email = txtEmail.Text,
                        SoDienThoai = txtSDT.Text
                    };
                    // Add logic to save the new NhaCungCap to the database
                    nhaCungCapBAL.Add(_ncc);
                    MessageBox.Show("Thêm nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _ncc.TenNcc = txtTenNCC.Text;
                    _ncc.DiaChi = txtDiaChi.Text;
                    _ncc.Email = txtEmail.Text;
                    _ncc.SoDienThoai = txtSDT.Text;

                    // Add logic to update the existing NhaCungCap in the database
                    nhaCungCapBAL.Update(_ncc);
                    MessageBox.Show("Cập nhật nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClearForm()
        {
            txtMaNCC.Clear();
            txtTenNCC.Clear();
            txtDiaChi.Clear();
            txtEmail.Clear();
            txtSDT.Clear();
        }
        private bool IsValidEmail(string email)
        {
            // Định dạng email: ký tự + @ + tên miền
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        private bool IsValidPhone(string phone)
        {
            // Định dạng số điện thoại Việt Nam: 10 chữ số, bắt đầu bằng 0
            return Regex.IsMatch(phone, @"^0\d{9}$");
        }

        private bool ValidateInput()
        {
            // Check trống trước
            if (string.IsNullOrWhiteSpace(txtTenNCC.Text))
            {
                MessageBox.Show("Vui lòng nhập tên nhà cung cấp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập email.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Nếu đã nhập đủ → mới check định dạng

            if (!IsValidPhone(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại hợp lệ (10 số, bắt đầu bằng 0).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập email hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private string GenerateNewMaNCC()
        {
            // Cách 1: Dùng thời gian (NCC + NgàyGiờPhútGiây) - Đơn giản, không lo trùng
            return "NCC" + DateTime.Now.ToString("ddMMHHmm");

            // Cách 2: Nếu bạn muốn NCC001, NCC002 thì cần gọi vào DB để đếm (hơi phức tạp hơn một chút)
        }
    }
}
