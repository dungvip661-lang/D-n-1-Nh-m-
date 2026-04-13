using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DuAn1_Nhom4.BLL;
using DuAn1_Nhom4.Models;

namespace DuAn1_Nhom4.GUI
{

    public partial class TaiKhoanF : Form
    {
        NhanVien _NhanVien;
        GenericBLL<TaiKhoanNhanVien> _tkBLL = new GenericBLL<TaiKhoanNhanVien>();
        GenericBLL<ChucVu> _chucVuBLL = new GenericBLL<ChucVu>();
        bool isNewShown = false;
        bool isConfirmShown = false;
        bool isOldShown = false;
        public TaiKhoanF(NhanVien nhanVien)
        {
            InitializeComponent();
            _NhanVien = nhanVien;
        }
        private void LoadNhanVien()
        {
            // Kiểm tra tài khoản
            var tk = _tkBLL.GetAll().FirstOrDefault(x => x.NhanVienId == _NhanVien.Id);

            // SỬA TẠI ĐÂY: Kiểm tra MaChucVu trước khi lấy thông tin chức vụ
            string tenChucVu = "Chưa gán";
            if (_NhanVien.MaChucVu.HasValue)
            {
                var chucVu = _chucVuBLL.GetById((int)_NhanVien.MaChucVu.Value);
                if (chucVu != null) tenChucVu = chucVu.TenChucVu;
            }

            var capChar = CapChar();

            txtMa.Text = _NhanVien.Id.ToString();
            txtHoTen.Text = _NhanVien.HoTen;
            txtSDT.Text = _NhanVien.SoDienThoai;
            txtEmail.Text = _NhanVien.Email;

            // Gán tên chức vụ đã kiểm tra
            txtChucVu.Text = tenChucVu;

            // Kiểm tra tk có null không trước khi lấy TenDangNhap để tránh lỗi tiếp theo
            txtTenDangNhap.Text = tk?.TenDangNhap ?? "Chưa có TK";

            lbcapchar.Text = capChar;
        }
        private string CapChar(int length = 6)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }


        private void TaiKhoanF_Load(object sender, EventArgs e)
        {
            LoadNhanVien();

            picEyeNew.Image = Properties.Resources.eye_off;
            picEyeConfirm.Image = Properties.Resources.eye_off;
            pictureBoxeyeOld.Image = Properties.Resources.eye_off;

            // Ẩn mật khẩu ban đầu
            txtMKMoi.UseSystemPasswordChar = true;
            txtXacNhan.UseSystemPasswordChar = true;
            txtMkCu.UseSystemPasswordChar = true;


        }


        private void btnLuuMK_Click(object sender, EventArgs e)
        {
            if (txtMaXacNhan.Text != lbcapchar.Text)
            {
                MessageBox.Show("Mã xác nhận không đúng, vui lòng nhập lại.");
                return;
            }
            if (txtMKMoi.Text == txtXacNhan.Text)
            {
                var tk = _tkBLL.GetAll().FirstOrDefault(x => x.Id == _NhanVien.Id);
                if (tk != null)
                {
                    if (txtMkCu.Text != tk.MatKhau)
                    {
                        MessageBox.Show("Mật khẩu cũ không đúng, vui lòng nhập lại.");
                        return;
                    }
                    if (txtMKMoi.Text.Length < 6)
                    {
                        MessageBox.Show("Mật khẩu mới phải có ít nhất 6 ký tự.");
                        return;
                    }
                    tk.MatKhau = txtMKMoi.Text;
                    _tkBLL.Update(tk);
                    MessageBox.Show("Cập nhật mật khẩu thành công!");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy tài khoản của nhân viên này.");
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu không khớp, vui lòng nhập lại.");
            }
            ResetFields();
        }
        private void ResetFields()
        {
            txtMKMoi.Clear();
            txtMkCu.Clear();
            txtXacNhan.Clear();
            txtMaXacNhan.Clear();
            lbcapchar.Text = CapChar();
        }
        private void picEyeNew_Click(object sender, EventArgs e)
        {
            isNewShown = !isNewShown;
            txtMKMoi.UseSystemPasswordChar = !isNewShown;
            picEyeNew.Image = isNewShown ? Properties.Resources.eye : Properties.Resources.eye_off;
        }

        private void picEyeConfirm_Click(object sender, EventArgs e)
        {
            isConfirmShown = !isConfirmShown;
            txtXacNhan.UseSystemPasswordChar = !isConfirmShown;
            picEyeConfirm.Image = isConfirmShown ? Properties.Resources.eye : Properties.Resources.eye_off;
        }

        private void pictureBoxeyeOld_Click(object sender, EventArgs e)
        {
            isOldShown = !isOldShown;
            txtMkCu.UseSystemPasswordChar = !isOldShown;
            pictureBoxeyeOld.Image = isOldShown ? Properties.Resources.eye : Properties.Resources.eye_off;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
