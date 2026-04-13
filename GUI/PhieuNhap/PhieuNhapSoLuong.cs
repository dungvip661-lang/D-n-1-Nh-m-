using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuAn1_Nhom4.GUI.Nhập_hàng
{
    public partial class PhieuNhapSoLuong : Form
    {
        public int SoLuongMoi { get; private set; }

        public PhieuNhapSoLuong(int soLuongCu)
        {
            InitializeComponent();
            txtSoLuong.Text = soLuongCu.ToString();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string input = txtSoLuong.Text.Trim();

            if (string.IsNullOrEmpty(input))
            {
                MessageBox.Show("Vui lòng nhập số lượng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (int.TryParse(input, out int soLuong))
            {
                if (soLuong > 0)
                {
                    SoLuongMoi = soLuong;
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Số lượng phải lớn hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSoLuong.Clear();
                    txtSoLuong.Focus();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập một số nguyên hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoLuong.Clear();
                txtSoLuong.Focus();
            }
        }

        private void PhieuNhapSoLuong_Load(object sender, EventArgs e)
        {

        }
    }
}
