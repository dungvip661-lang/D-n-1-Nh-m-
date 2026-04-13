using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DuAn1_Nhom4.BLL;
using DuAn1_Nhom4.Models;
using Microsoft.VisualBasic.ApplicationServices;
using System.Text.RegularExpressions;

namespace DuAn1_Nhom4.GUI
{
    public partial class QuenMatKhauF : Form
    {
        private string OTP;
        private int user;
        private GenericBLL<NhanVien> _nvBLL = new GenericBLL<NhanVien>();
        private GenericBLL<TaiKhoanNhanVien> _tkBLL = new GenericBLL<TaiKhoanNhanVien>();
        public QuenMatKhauF()
        {
            InitializeComponent();
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng nhập email của bạn.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Email không đúng định dạng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            var user = _nvBLL.GetAll().FirstOrDefault(x => x.Email == email);

            if (user == null)
            {
                MessageBox.Show("Email không tồn tại trong hệ thống. Vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            Random rd = new Random();
            OTP = rd.Next(100000, 999999).ToString();
            this.user = user.Id;
            try
            {
                SendMail(email, "Mã xác nhận quên mật khẩu", $"Mã OTP của bạn là: {OTP}");

                MessageBox.Show("Đã gửi mã xác nhận đến email của bạn!");
                txtOTP.Visible = true;
                btnOTP.Visible = true;
                lbOTP.Visible = true;

            }
            catch (Exception)
            {

                MessageBox.Show("Lỗi");
            }

        }

        private void SendMail(string toEmail, string subject, string body)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("o8073449@gmail.com");
                mail.To.Add(toEmail);
                mail.Subject = subject;
                mail.Body = body;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("o8073449@gmail.com", "ciaa rxby rxvl sjcd");
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gửi email: " + ex.Message);
            }
        }

        private void btnOTP_Click(object sender, EventArgs e)
        {
            if (txtOTP.Text == OTP)
            {
                MessageBox.Show("Xác nhận thành công! Vui lòng nhập mật khẩu mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMkmoi.Visible = true;
                btnXacnhan.Visible = true;
                lbMkxacNhan.Visible = true;
                lbMkmoi.Visible = true;
                txtMkxacNhan.Visible = true;
            }
            else
            {
                MessageBox.Show("Mã OTP không đúng. Vui lòng thử lại.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXacnhan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMkmoi.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtMkmoi.Text.Length < 6)
            {
                MessageBox.Show("Mật khẩu mới phải có ít nhất 6 ký tự.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(txtMkmoi.Text != txtMkxacNhan.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp. Vui lòng nhập lại.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var taiKhoan = _tkBLL.GetAll().FirstOrDefault(x => x.NhanVienId == user);
            if (taiKhoan != null)
            {
                taiKhoan.MatKhau = txtMkmoi.Text.Trim();
                _tkBLL.Update(taiKhoan);
                MessageBox.Show("Mật khẩu đã được cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Không tìm thấy tài khoản liên kết với nhân viên này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
