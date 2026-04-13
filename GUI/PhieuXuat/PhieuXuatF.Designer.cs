namespace DuAn1_Nhom4.GUI
{
    partial class PhieuXuatF
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
            components = new System.ComponentModel.Container();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            groupBox5 = new GroupBox();
            tabControl1 = new TabControl();
            tabHoaDon = new TabPage();
            panel3 = new Panel();
            btnHuy = new Button();
            btnTao = new Button();
            btnThanhToan = new Button();
            panel2 = new Panel();
            label3 = new Label();
            txtTienkhach = new TextBox();
            lbNV = new Label();
            lbTienthua = new Label();
            label6 = new Label();
            lbTongtienhd = new Label();
            panel4 = new Panel();
            txtsdt = new TextBox();
            label2 = new Label();
            txtTen = new TextBox();
            label1 = new Label();
            panel1 = new Panel();
            groupBox3 = new GroupBox();
            btnSua = new Button();
            label4 = new Label();
            textBox1 = new TextBox();
            btnThem = new Button();
            btnXoa = new Button();
            dtgGioHang = new DataGridView();
            groupBox2 = new GroupBox();
            dtgDanhSachSP = new DataGridView();
            groupBox1 = new GroupBox();
            dtgDanhSachHD = new DataGridView();
            backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            contextMenuStrip1 = new ContextMenuStrip(components);
            groupBox5.SuspendLayout();
            tabControl1.SuspendLayout();
            tabHoaDon.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            panel1.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgGioHang).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgDanhSachSP).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgDanhSachHD).BeginInit();
            SuspendLayout();
            // 
            // groupBox5
            // 
            groupBox5.BackColor = Color.AliceBlue;
            groupBox5.Controls.Add(tabControl1);
            groupBox5.Dock = DockStyle.Right;
            groupBox5.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox5.Location = new Point(954, 0);
            groupBox5.Margin = new Padding(2);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new Padding(2);
            groupBox5.Size = new Size(441, 895);
            groupBox5.TabIndex = 5;
            groupBox5.TabStop = false;
            groupBox5.Text = "Tạo hóa đơn";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabHoaDon);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(2, 21);
            tabControl1.Margin = new Padding(2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(437, 872);
            tabControl1.TabIndex = 0;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabHoaDon
            // 
            tabHoaDon.Controls.Add(panel3);
            tabHoaDon.Controls.Add(panel2);
            tabHoaDon.Controls.Add(panel4);
            tabHoaDon.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabHoaDon.Location = new Point(4, 28);
            tabHoaDon.Margin = new Padding(2);
            tabHoaDon.Name = "tabHoaDon";
            tabHoaDon.Padding = new Padding(2);
            tabHoaDon.Size = new Size(429, 840);
            tabHoaDon.TabIndex = 0;
            tabHoaDon.Text = "Hóa đơn";
            tabHoaDon.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            panel3.Controls.Add(btnHuy);
            panel3.Controls.Add(btnTao);
            panel3.Controls.Add(btnThanhToan);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(2, 527);
            panel3.Margin = new Padding(2);
            panel3.Name = "panel3";
            panel3.Size = new Size(425, 311);
            panel3.TabIndex = 11;
            // 
            // btnHuy
            // 
            btnHuy.BackColor = Color.LightCoral;
            btnHuy.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHuy.Image = Properties.Resources.icons8_delete_document_30;
            btnHuy.ImageAlign = ContentAlignment.MiddleLeft;
            btnHuy.Location = new Point(250, 142);
            btnHuy.Margin = new Padding(2);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(144, 60);
            btnHuy.TabIndex = 2;
            btnHuy.Text = "Hủy hóa đơn";
            btnHuy.TextAlign = ContentAlignment.MiddleRight;
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.Click += btnHuy_Click;
            // 
            // btnTao
            // 
            btnTao.BackColor = Color.LimeGreen;
            btnTao.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTao.Image = Properties.Resources.icons8_create_order_30;
            btnTao.ImageAlign = ContentAlignment.MiddleLeft;
            btnTao.Location = new Point(35, 142);
            btnTao.Margin = new Padding(2);
            btnTao.Name = "btnTao";
            btnTao.Size = new Size(143, 60);
            btnTao.TabIndex = 1;
            btnTao.Text = "Tạo hóa đơn";
            btnTao.TextAlign = ContentAlignment.MiddleRight;
            btnTao.UseVisualStyleBackColor = false;
            btnTao.Click += btnTao_Click;
            // 
            // btnThanhToan
            // 
            btnThanhToan.BackColor = Color.Gold;
            btnThanhToan.Font = new Font("Segoe UI Semibold", 13.2F, FontStyle.Bold);
            btnThanhToan.Image = Properties.Resources.icons8_money_601;
            btnThanhToan.ImageAlign = ContentAlignment.MiddleLeft;
            btnThanhToan.Location = new Point(35, 33);
            btnThanhToan.Margin = new Padding(2);
            btnThanhToan.Name = "btnThanhToan";
            btnThanhToan.Size = new Size(359, 65);
            btnThanhToan.TabIndex = 0;
            btnThanhToan.Text = "Thanh toán ";
            btnThanhToan.UseVisualStyleBackColor = false;
            btnThanhToan.Click += btnThanhToan_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.AliceBlue;
            panel2.Controls.Add(label3);
            panel2.Controls.Add(txtTienkhach);
            panel2.Controls.Add(lbNV);
            panel2.Controls.Add(lbTienthua);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(lbTongtienhd);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(2, 172);
            panel2.Margin = new Padding(2);
            panel2.Name = "panel2";
            panel2.Size = new Size(425, 666);
            panel2.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(403, 144);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(14, 15);
            label3.TabIndex = 8;
            label3.Text = "đ";
            // 
            // txtTienkhach
            // 
            txtTienkhach.BorderStyle = BorderStyle.FixedSingle;
            txtTienkhach.Location = new Point(247, 137);
            txtTienkhach.Margin = new Padding(2);
            txtTienkhach.Name = "txtTienkhach";
            txtTienkhach.Size = new Size(152, 23);
            txtTienkhach.TabIndex = 7;
            txtTienkhach.TextAlign = HorizontalAlignment.Right;
            txtTienkhach.TextChanged += txtTienkhach_TextChanged;
            // 
            // lbNV
            // 
            lbNV.AutoSize = true;
            lbNV.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lbNV.Location = new Point(55, 99);
            lbNV.Margin = new Padding(2, 0, 2, 0);
            lbNV.Name = "lbNV";
            lbNV.Size = new Size(80, 19);
            lbNV.TabIndex = 6;
            lbNV.Text = "Nhân viên: ";
            // 
            // lbTienthua
            // 
            lbTienthua.AutoSize = true;
            lbTienthua.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lbTienthua.Location = new Point(55, 187);
            lbTienthua.Margin = new Padding(2, 0, 2, 0);
            lbTienthua.Name = "lbTienthua";
            lbTienthua.Size = new Size(72, 19);
            lbTienthua.TabIndex = 4;
            lbTienthua.Text = "Tiền thừa:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label6.Location = new Point(55, 141);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(109, 19);
            label6.TabIndex = 3;
            label6.Text = "Tiền khách đưa:";
            // 
            // lbTongtienhd
            // 
            lbTongtienhd.AutoSize = true;
            lbTongtienhd.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTongtienhd.Location = new Point(48, 37);
            lbTongtienhd.Margin = new Padding(2, 0, 2, 0);
            lbTongtienhd.Name = "lbTongtienhd";
            lbTongtienhd.Size = new Size(151, 32);
            lbTongtienhd.TabIndex = 0;
            lbTongtienhd.Text = "Tổng tiền: 0 ";
            // 
            // panel4
            // 
            panel4.BackColor = Color.AliceBlue;
            panel4.Controls.Add(txtsdt);
            panel4.Controls.Add(label2);
            panel4.Controls.Add(txtTen);
            panel4.Controls.Add(label1);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(2, 2);
            panel4.Margin = new Padding(2);
            panel4.Name = "panel4";
            panel4.Size = new Size(425, 170);
            panel4.TabIndex = 9;
            // 
            // txtsdt
            // 
            txtsdt.BorderStyle = BorderStyle.FixedSingle;
            txtsdt.Location = new Point(194, 74);
            txtsdt.Margin = new Padding(2);
            txtsdt.Name = "txtsdt";
            txtsdt.ReadOnly = true;
            txtsdt.Size = new Size(175, 23);
            txtsdt.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            label2.Location = new Point(57, 73);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(99, 20);
            label2.TabIndex = 4;
            label2.Text = "Số điện thoại";
            // 
            // txtTen
            // 
            txtTen.BorderStyle = BorderStyle.FixedSingle;
            txtTen.Location = new Point(194, 26);
            txtTen.Margin = new Padding(2);
            txtTen.Name = "txtTen";
            txtTen.ReadOnly = true;
            txtTen.Size = new Size(175, 23);
            txtTen.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            label1.Location = new Point(48, 27);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(117, 20);
            label1.TabIndex = 0;
            label1.Text = "Tên khách hàng";
            // 
            // panel1
            // 
            panel1.Controls.Add(groupBox3);
            panel1.Controls.Add(groupBox2);
            panel1.Controls.Add(groupBox1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(954, 895);
            panel1.TabIndex = 6;
            // 
            // groupBox3
            // 
            groupBox3.BackColor = Color.AliceBlue;
            groupBox3.Controls.Add(btnSua);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(textBox1);
            groupBox3.Controls.Add(btnThem);
            groupBox3.Controls.Add(btnXoa);
            groupBox3.Controls.Add(dtgGioHang);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox3.Location = new Point(0, 223);
            groupBox3.Margin = new Padding(2);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(2);
            groupBox3.Size = new Size(954, 481);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Giỏ hàng ";
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.Khaki;
            btnSua.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            btnSua.Image = Properties.Resources.icons8_edit_30;
            btnSua.ImageAlign = ContentAlignment.MiddleLeft;
            btnSua.Location = new Point(522, 304);
            btnSua.Margin = new Padding(2);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(218, 41);
            btnSua.TabIndex = 33;
            btnSua.Text = "Sửa số lượng";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(53, 399);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(95, 19);
            label4.TabIndex = 32;
            label4.Text = "Tên sản phẩm";
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top;
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Location = new Point(175, 399);
            textBox1.Margin = new Padding(2);
            textBox1.Name = "textBox1";
            textBox1.RightToLeft = RightToLeft.No;
            textBox1.Size = new Size(319, 26);
            textBox1.TabIndex = 31;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.LimeGreen;
            btnThem.DialogResult = DialogResult.Yes;
            btnThem.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            btnThem.Image = Properties.Resources.icons8_add_to_shopping_basket_301;
            btnThem.ImageAlign = ContentAlignment.MiddleLeft;
            btnThem.Location = new Point(23, 304);
            btnThem.Margin = new Padding(2);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(206, 41);
            btnThem.TabIndex = 30;
            btnThem.Text = "Thêm vào giỏ hàng";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.LightCoral;
            btnXoa.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            btnXoa.Image = Properties.Resources.icons8_delete_302;
            btnXoa.ImageAlign = ContentAlignment.MiddleLeft;
            btnXoa.Location = new Point(270, 304);
            btnXoa.Margin = new Padding(2);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(218, 41);
            btnXoa.TabIndex = 24;
            btnXoa.Text = "Xóa sản phẩm";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // dtgGioHang
            // 
            dtgGioHang.AllowUserToAddRows = false;
            dtgGioHang.AllowUserToDeleteRows = false;
            dtgGioHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgGioHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgGioHang.Dock = DockStyle.Top;
            dtgGioHang.Location = new Point(2, 21);
            dtgGioHang.Margin = new Padding(2);
            dtgGioHang.MultiSelect = false;
            dtgGioHang.Name = "dtgGioHang";
            dtgGioHang.ReadOnly = true;
            dtgGioHang.RowHeadersWidth = 51;
            dtgGioHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgGioHang.Size = new Size(950, 259);
            dtgGioHang.TabIndex = 0;
            dtgGioHang.CellContentClick += dtgGioHang_CellContentClick;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.AliceBlue;
            groupBox2.Controls.Add(dtgDanhSachSP);
            groupBox2.Dock = DockStyle.Bottom;
            groupBox2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(0, 704);
            groupBox2.Margin = new Padding(2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(2);
            groupBox2.Size = new Size(954, 191);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách sản phẩm ";
            // 
            // dtgDanhSachSP
            // 
            dtgDanhSachSP.AllowUserToAddRows = false;
            dtgDanhSachSP.AllowUserToDeleteRows = false;
            dtgDanhSachSP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgDanhSachSP.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgDanhSachSP.Dock = DockStyle.Fill;
            dtgDanhSachSP.Location = new Point(2, 21);
            dtgDanhSachSP.Margin = new Padding(2);
            dtgDanhSachSP.MultiSelect = false;
            dtgDanhSachSP.Name = "dtgDanhSachSP";
            dtgDanhSachSP.ReadOnly = true;
            dtgDanhSachSP.RowHeadersWidth = 51;
            dtgDanhSachSP.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgDanhSachSP.Size = new Size(950, 168);
            dtgDanhSachSP.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.AliceBlue;
            groupBox1.Controls.Add(dtgDanhSachHD);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(0, 0);
            groupBox1.Margin = new Padding(2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2);
            groupBox1.Size = new Size(954, 223);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Danh sách hóa đơn";
            // 
            // dtgDanhSachHD
            // 
            dtgDanhSachHD.AllowUserToAddRows = false;
            dtgDanhSachHD.AllowUserToDeleteRows = false;
            dtgDanhSachHD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgDanhSachHD.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgDanhSachHD.Dock = DockStyle.Fill;
            dtgDanhSachHD.Location = new Point(2, 21);
            dtgDanhSachHD.Margin = new Padding(2);
            dtgDanhSachHD.MultiSelect = false;
            dtgDanhSachHD.Name = "dtgDanhSachHD";
            dtgDanhSachHD.ReadOnly = true;
            dtgDanhSachHD.RowHeadersWidth = 51;
            dtgDanhSachHD.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgDanhSachHD.Size = new Size(950, 200);
            dtgDanhSachHD.TabIndex = 0;
            dtgDanhSachHD.CellClick += dtgDanhSachHD_CellClick;
            dtgDanhSachHD.CellContentClick += dtgDanhSachHD_CellContentClick;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // PhieuXuatF
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1395, 895);
            Controls.Add(panel1);
            Controls.Add(groupBox5);
            Margin = new Padding(2);
            Name = "PhieuXuatF";
            Text = "HoaDon";
            Load += HoaDon_Load;
            groupBox5.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabHoaDon.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgGioHang).EndInit();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtgDanhSachSP).EndInit();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtgDanhSachHD).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private GroupBox groupBox5;
        private Panel panel1;
        private GroupBox groupBox3;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private DataGridView dtgGioHang;
        private DataGridView dtgDanhSachSP;
        private DataGridView dtgDanhSachHD;
        private Button btnXoa;
        private TextBox textBox1;
        private Button btnThem;
        private ContextMenuStrip contextMenuStrip1;
        private Label label4;
        private Button btnSua;
        private TabControl tabControl1;
        private TabPage tabHoaDon;
        private Panel panel3;
        private Button btnHuy;
        private Button btnTao;
        private Button btnThanhToan;
        private Panel panel2;
        private Label label3;
        private TextBox txtTienkhach;
        private Label lbNV;
        private Label lbTienthua;
        private Label label6;
        private Label lbTongtienhd;
        private Panel panel4;
        private TextBox txtsdt;
        private Label label2;
        private TextBox txtTen;
        private Label label1;
    }
}