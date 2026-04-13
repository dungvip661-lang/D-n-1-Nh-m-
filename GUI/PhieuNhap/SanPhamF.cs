using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DuAn1_Nhom4.BLL;
using DuAn1_Nhom4.Models;

namespace DuAn1_Nhom4.GUI.Nhập_hàng
{
    public partial class SanPhamF : Form
    {
        GenericBLL<ChiTietSanPham> ctSanPhamBAL;
        GenericBLL<SanPham> sanPhamBAL;
        PhieuNhapF _phieuNhapF;

        private int maSp = 0;
        private decimal donGia = 0;

        public SanPhamF(PhieuNhapF phieuNhapF)
        {
            _phieuNhapF = phieuNhapF;
            InitializeComponent();

            ctSanPhamBAL = new GenericBLL<ChiTietSanPham>();
            sanPhamBAL = new GenericBLL<SanPham>();
        }
        private void LoadSP()
        {
            try
            {
                var list = ctSanPhamBAL.GetAll(
                    x => x.MaSpNavigation,
                    x => x.MaMauNavigation,
                    x => x.MaKichThuocNavigation,
                    x => x.MaSpNavigation.MaThuongHieuNavigation,
                    x => x.MaSpNavigation.MaNccNavigation);

                dgvSP.DataSource = list.Select((sp, index) => new
                {
                    STT = index + 1,
                    MaSP = sp.MaCtsp,
                    TenSP = sp.MaSpNavigation.TenSp,
                    MauSac = sp.MaMauNavigation.TenMau,
                    DonGia = sp.DonGiaNhap,
                    KichThuoc = sp.MaKichThuocNavigation.TenKichThuoc,
                    ThuongHieu = sp.MaSpNavigation.MaThuongHieuNavigation.TenThuongHieu,
                    NhaCungCap = sp.MaSpNavigation.MaNccNavigation.TenNcc
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load sản phẩm: " + ex.Message);
            }

            dgvSP.Columns["MaSP"].HeaderText = "Mã sản phẩm";
            dgvSP.Columns["TenSP"].HeaderText = "Tên sản phẩm";
            dgvSP.Columns["MauSac"].HeaderText = "Màu sắc";
            dgvSP.Columns["DonGia"].HeaderText = "Đơn giá";
            dgvSP.Columns["KichThuoc"].HeaderText = "Kích thước";
            dgvSP.Columns["ThuongHieu"].HeaderText = "Thương hiệu";
            dgvSP.Columns["NhaCungCap"].HeaderText = "Nhà cung cấp";

            dgvSP.Columns["TenSP"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            foreach (DataGridViewColumn column in dgvSP.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; // Căn giữa tiêu đề cột

            }

        }
        private void dgvSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvSP.Rows[e.RowIndex];
            txtSanPham.Text = row.Cells["TenSP"].Value.ToString();
            maSp = int.Parse(row.Cells["MaSP"].Value.ToString() ?? "0");
            var gia = row.Cells["DonGia"].Value.ToString()?.Replace(".00", "0");
            donGia = decimal.Parse(gia ?? "0");
        }
        private void DanhSachSanPham_Load(object sender, EventArgs e)
        {
            LoadSP();
        }
        private void btnThemGioHang_Click(object sender, EventArgs e)
        {
            try
            {
                if (maSp == 0)
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm trước khi thêm vào giỏ hàng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
             if (string.IsNullOrWhiteSpace(txtSoluongNhap.Text))
                {
                    MessageBox.Show("Vui lòng nhập số lượng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoluongNhap.Focus(); // Đưa con trỏ về lại ô nhập
                    return;
                }

                if (!int.TryParse(txtSoluongNhap.Text.Trim(), out int soLuong))
                {
                    MessageBox.Show("Vui lòng chỉ nhập số nguyên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoluongNhap.Clear(); // Xoá nội dung sai
                    txtSoluongNhap.Focus(); // Đưa con trỏ về lại ô nhập
                    return;
                }

                if (soLuong <= 0)
                {
                    MessageBox.Show("Số lượng phải lớn hơn 0!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoluongNhap.Clear(); // Xoá số lượng <= 0
                    txtSoluongNhap.Focus(); // Đưa con trỏ về lại ô nhập
                    return;
                }

                _phieuNhapF.ThemGioHang(maSp, soLuong, donGia);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string tuKhoa = txtSearch.Text.Trim().ToLower();

                var danhSach = ctSanPhamBAL.GetAll(
                    x => x.MaSpNavigation,
                    x => x.MaMauNavigation,
                    x => x.MaKichThuocNavigation,
                    x => x.MaSpNavigation.MaThuongHieuNavigation,
                    x => x.MaSpNavigation.MaNccNavigation
                );

                // Lọc theo tên sản phẩm
                var ketQua = danhSach
                    .Where(sp => sp.MaSpNavigation.TenSp != null &&
                                 sp.MaSpNavigation.TenSp.ToLower().Contains(tuKhoa))
                    .Select((sp, index) => new
                    {
                        STT = index + 1,
                        MaSP = sp.MaCtsp,
                        TenSP = sp.MaSpNavigation.TenSp,
                        MauSac = sp.MaMauNavigation.TenMau,
                        DonGia = sp.DonGiaNhap,
                        KichThuoc = sp.MaKichThuocNavigation.TenKichThuoc,
                        ThuongHieu = sp.MaSpNavigation.MaThuongHieuNavigation.TenThuongHieu,
                        NhaCungCap = sp.MaSpNavigation.MaNccNavigation.TenNcc
                    })
                    .ToList();

                dgvSP.DataSource = ketQua;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
