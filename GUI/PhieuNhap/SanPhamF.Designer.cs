namespace DuAn1_Nhom4.GUI.Nhập_hàng
{
    partial class SanPhamF
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            txtSanPham = new TextBox();
            groupBox1 = new GroupBox();
            label2 = new Label();
            dgvSP = new DataGridView();
            txtSearch = new TextBox();
            btnThemGioHang = new Button();
            label8 = new Label();
            txtSoluongNhap = new TextBox();
            label1 = new Label();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSP).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.AliceBlue;
            panel1.Controls.Add(txtSanPham);
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(btnThemGioHang);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(txtSoluongNhap);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1005, 508);
            panel1.TabIndex = 0;
            // 
            // txtSanPham
            // 
            txtSanPham.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtSanPham.BorderStyle = BorderStyle.FixedSingle;
            txtSanPham.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            txtSanPham.Location = new Point(332, 48);
            txtSanPham.Margin = new Padding(3, 2, 3, 2);
            txtSanPham.Name = "txtSanPham";
            txtSanPham.ReadOnly = true;
            txtSanPham.Size = new Size(368, 26);
            txtSanPham.TabIndex = 22;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(dgvSP);
            groupBox1.Controls.Add(txtSearch);
            groupBox1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(0, 233);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(1005, 275);
            groupBox1.TabIndex = 21;
            groupBox1.TabStop = false;
            groupBox1.Text = "Danh sách sản phẩm";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 62);
            label2.Name = "label2";
            label2.Size = new Size(99, 19);
            label2.TabIndex = 17;
            label2.Text = "Tên sản phẩm ";
            // 
            // dgvSP
            // 
            dgvSP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSP.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSP.Dock = DockStyle.Bottom;
            dgvSP.Location = new Point(3, 100);
            dgvSP.Margin = new Padding(3, 2, 3, 2);
            dgvSP.MultiSelect = false;
            dgvSP.Name = "dgvSP";
            dgvSP.ReadOnly = true;
            dgvSP.RowHeadersWidth = 51;
            dgvSP.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSP.Size = new Size(999, 173);
            dgvSP.TabIndex = 11;
            dgvSP.CellClick += dgvSP_CellClick;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(144, 57);
            txtSearch.Margin = new Padding(3, 2, 3, 2);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Nhập tên sản phẩm cần tìm";
            txtSearch.Size = new Size(368, 26);
            txtSearch.TabIndex = 10;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // btnThemGioHang
            // 
            btnThemGioHang.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnThemGioHang.BackColor = Color.LimeGreen;
            btnThemGioHang.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            btnThemGioHang.Image = Properties.Resources.icons8_add_shopping_cart_30;
            btnThemGioHang.ImageAlign = ContentAlignment.MiddleLeft;
            btnThemGioHang.Location = new Point(402, 165);
            btnThemGioHang.Margin = new Padding(3, 2, 3, 2);
            btnThemGioHang.Name = "btnThemGioHang";
            btnThemGioHang.Size = new Size(227, 36);
            btnThemGioHang.TabIndex = 20;
            btnThemGioHang.Text = "Thêm vào giỏ hàng";
            btnThemGioHang.UseVisualStyleBackColor = false;
            btnThemGioHang.Click += btnThemGioHang_Click;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label8.Location = new Point(214, 112);
            label8.Name = "label8";
            label8.Size = new Size(103, 19);
            label8.TabIndex = 19;
            label8.Text = "Nhập số lượng";
            // 
            // txtSoluongNhap
            // 
            txtSoluongNhap.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtSoluongNhap.BorderStyle = BorderStyle.FixedSingle;
            txtSoluongNhap.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            txtSoluongNhap.Location = new Point(332, 107);
            txtSoluongNhap.Margin = new Padding(3, 2, 3, 2);
            txtSoluongNhap.Name = "txtSoluongNhap";
            txtSoluongNhap.Size = new Size(368, 26);
            txtSoluongNhap.TabIndex = 18;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label1.Location = new Point(217, 53);
            label1.Name = "label1";
            label1.Size = new Size(99, 19);
            label1.TabIndex = 17;
            label1.Text = "Tên sản phẩm ";
            // 
            // SanPhamF
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1005, 508);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "SanPhamF";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sản phẩm";
            Load += DanhSachSanPham_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSP).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox txtSanPham;
        private GroupBox groupBox1;
        private Label label2;
        private DataGridView dgvSP;
        private TextBox txtSearch;
        private Button btnThemGioHang;
        private Label label8;
        private TextBox txtSoluongNhap;
        private Label label1;
    }
}