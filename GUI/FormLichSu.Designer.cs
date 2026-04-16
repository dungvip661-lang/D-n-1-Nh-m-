namespace DuAn1_Nhom4.GUI
{
    partial class FormLichSu
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
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            groupBox1 = new GroupBox();
            label5 = new Label();
            cbNgayloc = new ComboBox();
            label4 = new Label();
            cbTrangthai = new ComboBox();
            btnTk = new Button();
            dgvPhieu = new DataGridView();
            lbDenngay = new Label();
            lbTungay = new Label();
            label1 = new Label();
            dateTimePicker2 = new DateTimePicker();
            dateTimePicker1 = new DateTimePicker();
            comboBox1 = new ComboBox();
            groupBox2 = new GroupBox();
            dgvCt = new DataGridView();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            sqlCommand2 = new Microsoft.Data.SqlClient.SqlCommand();
            labelMaNV = new Label();
            labelTenNV = new Label();
            labelNgayTao = new Label();
            labelTrangThai = new Label();
            labelTongTien = new Label();
            panel1 = new Panel();
            labelTenSP = new Label();
            labelSoLuong = new Label();
            labelDonGia = new Label();
            labelLai = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPhieu).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCt).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.AliceBlue;
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(cbNgayloc);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(cbTrangthai);
            groupBox1.Controls.Add(btnTk);
            groupBox1.Controls.Add(dgvPhieu);
            groupBox1.Controls.Add(lbDenngay);
            groupBox1.Controls.Add(lbTungay);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(dateTimePicker2);
            groupBox1.Controls.Add(dateTimePicker1);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(0, 0);
            groupBox1.Margin = new Padding(2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2);
            groupBox1.Size = new Size(1091, 499);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Lịch sử hoạt động";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(30, 132);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(65, 19);
            label5.TabIndex = 11;
            label5.Text = "Ngày lọc";
            // 
            // cbNgayloc
            // 
            cbNgayloc.FormattingEnabled = true;
            cbNgayloc.Location = new Point(112, 129);
            cbNgayloc.Margin = new Padding(2);
            cbNgayloc.Name = "cbNgayloc";
            cbNgayloc.Size = new Size(155, 27);
            cbNgayloc.TabIndex = 10;
            cbNgayloc.SelectedIndexChanged += cbNgayloc_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(298, 69);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(72, 19);
            label4.TabIndex = 9;
            label4.Text = "Trạng thái";
            // 
            // cbTrangthai
            // 
            cbTrangthai.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTrangthai.FormattingEnabled = true;
            cbTrangthai.Location = new Point(381, 67);
            cbTrangthai.Margin = new Padding(2);
            cbTrangthai.Name = "cbTrangthai";
            cbTrangthai.Size = new Size(155, 27);
            cbTrangthai.TabIndex = 8;
            cbTrangthai.SelectedIndexChanged += cbTrangthai_SelectedIndexChanged;
            // 
            // btnTk
            // 
            btnTk.BackColor = Color.PaleTurquoise;
            btnTk.Image = Properties.Resources.icons8_view_30;
            btnTk.ImageAlign = ContentAlignment.MiddleLeft;
            btnTk.Location = new Point(821, 119);
            btnTk.Margin = new Padding(2);
            btnTk.Name = "btnTk";
            btnTk.Size = new Size(122, 37);
            btnTk.TabIndex = 7;
            btnTk.Text = "Tìm kiếm";
            btnTk.TextAlign = ContentAlignment.MiddleRight;
            btnTk.UseVisualStyleBackColor = false;
            btnTk.Click += btnTk_Click;
            // 
            // dgvPhieu
            // 
            dgvPhieu.AllowUserToAddRows = false;
            dgvPhieu.AllowUserToDeleteRows = false;
            dgvPhieu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPhieu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPhieu.Dock = DockStyle.Bottom;
            dgvPhieu.Location = new Point(2, 196);
            dgvPhieu.Margin = new Padding(2);
            dgvPhieu.MultiSelect = false;
            dgvPhieu.Name = "dgvPhieu";
            dgvPhieu.ReadOnly = true;
            dgvPhieu.RowHeadersWidth = 51;
            dgvPhieu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPhieu.Size = new Size(1087, 301);
            dgvPhieu.TabIndex = 6;
            dgvPhieu.CellClick += dgvPhieu_CellClick;
            dgvPhieu.CellContentClick += dgvPhieu_CellContentClick;
            // 
            // lbDenngay
            // 
            lbDenngay.AutoSize = true;
            lbDenngay.Location = new Point(550, 127);
            lbDenngay.Margin = new Padding(2, 0, 2, 0);
            lbDenngay.Name = "lbDenngay";
            lbDenngay.Size = new Size(68, 19);
            lbDenngay.TabIndex = 5;
            lbDenngay.Text = "Đến ngày";
            // 
            // lbTungay
            // 
            lbTungay.AutoSize = true;
            lbTungay.Location = new Point(297, 131);
            lbTungay.Margin = new Padding(2, 0, 2, 0);
            lbTungay.Name = "lbTungay";
            lbTungay.Size = new Size(60, 19);
            lbTungay.TabIndex = 4;
            lbTungay.Text = "Từ ngày";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 67);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(74, 19);
            label1.TabIndex = 3;
            label1.Text = "Loại phiếu";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Format = DateTimePickerFormat.Short;
            dateTimePicker2.Location = new Point(653, 127);
            dateTimePicker2.Margin = new Padding(2);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(155, 26);
            dateTimePicker2.TabIndex = 2;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(381, 127);
            dateTimePicker1.Margin = new Padding(2);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(155, 26);
            dateTimePicker1.TabIndex = 1;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(112, 65);
            comboBox1.Margin = new Padding(2);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(155, 27);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvCt);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(0, 499);
            groupBox2.Margin = new Padding(2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(2);
            groupBox2.Size = new Size(1091, 196);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách sản phẩm";
            // 
            // dgvCt
            // 
            dgvCt.AllowUserToAddRows = false;
            dgvCt.AllowUserToDeleteRows = false;
            dgvCt.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCt.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCt.Dock = DockStyle.Fill;
            dgvCt.Location = new Point(2, 21);
            dgvCt.Margin = new Padding(2);
            dgvCt.MultiSelect = false;
            dgvCt.Name = "dgvCt";
            dgvCt.ReadOnly = true;
            dgvCt.RowHeadersWidth = 51;
            dgvCt.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCt.Size = new Size(1087, 173);
            dgvCt.TabIndex = 7;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // sqlCommand2
            // 
            sqlCommand2.CommandTimeout = 30;
            sqlCommand2.EnableOptimizedParameterBinding = false;
            // 
            // labelMaNV
            // 
            labelMaNV.AutoSize = true;
            labelMaNV.Font = new Font("Segoe UI Semibold", 12.2F, FontStyle.Bold);
            labelMaNV.Location = new Point(33, 61);
            labelMaNV.Margin = new Padding(2, 0, 2, 0);
            labelMaNV.Name = "labelMaNV";
            labelMaNV.Size = new Size(120, 23);
            labelMaNV.TabIndex = 0;
            labelMaNV.Text = "Mã nhân viên:";
            // 
            // labelTenNV
            // 
            labelTenNV.AutoSize = true;
            labelTenNV.Font = new Font("Segoe UI Semibold", 12.2F, FontStyle.Bold);
            labelTenNV.Location = new Point(33, 123);
            labelTenNV.Margin = new Padding(2, 0, 2, 0);
            labelTenNV.Name = "labelTenNV";
            labelTenNV.Size = new Size(121, 23);
            labelTenNV.TabIndex = 1;
            labelTenNV.Text = "Tên nhân viên:";
            // 
            // labelNgayTao
            // 
            labelNgayTao.AutoSize = true;
            labelNgayTao.Font = new Font("Segoe UI Semibold", 12.2F, FontStyle.Bold);
            labelNgayTao.Location = new Point(33, 195);
            labelNgayTao.Margin = new Padding(2, 0, 2, 0);
            labelNgayTao.Name = "labelNgayTao";
            labelNgayTao.Size = new Size(85, 23);
            labelNgayTao.TabIndex = 4;
            labelNgayTao.Text = "Ngày tạo:";
            // 
            // labelTrangThai
            // 
            labelTrangThai.AutoSize = true;
            labelTrangThai.Font = new Font("Segoe UI Semibold", 12.2F, FontStyle.Bold);
            labelTrangThai.Location = new Point(33, 346);
            labelTrangThai.Margin = new Padding(2, 0, 2, 0);
            labelTrangThai.Name = "labelTrangThai";
            labelTrangThai.Size = new Size(91, 23);
            labelTrangThai.TabIndex = 5;
            labelTrangThai.Text = "Trạng thái:";
            // 
            // labelTongTien
            // 
            labelTongTien.AutoSize = true;
            labelTongTien.Font = new Font("Segoe UI Semibold", 12.2F, FontStyle.Bold);
            labelTongTien.Location = new Point(33, 266);
            labelTongTien.Margin = new Padding(2, 0, 2, 0);
            labelTongTien.Name = "labelTongTien";
            labelTongTien.Size = new Size(92, 23);
            labelTongTien.TabIndex = 6;
            labelTongTien.Text = "Tổng tiền: ";
            // 
            // panel1
            // 
            panel1.BackColor = Color.AliceBlue;
            panel1.Controls.Add(labelLai);
            panel1.Controls.Add(labelDonGia);
            panel1.Controls.Add(labelSoLuong);
            panel1.Controls.Add(labelTenSP);
            panel1.Controls.Add(labelTongTien);
            panel1.Controls.Add(labelTrangThai);
            panel1.Controls.Add(labelNgayTao);
            panel1.Controls.Add(labelTenNV);
            panel1.Controls.Add(labelMaNV);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(1091, 0);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(376, 695);
            panel1.TabIndex = 0;
            // 
            // labelTenSP
            // 
            labelTenSP.AutoSize = true;
            labelTenSP.Font = new Font("Segoe UI Semibold", 12.2F, FontStyle.Bold);
            labelTenSP.Location = new Point(33, 427);
            labelTenSP.Margin = new Padding(2, 0, 2, 0);
            labelTenSP.Name = "labelTenSP";
            labelTenSP.Size = new Size(116, 23);
            labelTenSP.TabIndex = 7;
            labelTenSP.Text = "Tên sản phẩm";
            // 
            // labelSoLuong
            // 
            labelSoLuong.AutoSize = true;
            labelSoLuong.Font = new Font("Segoe UI Semibold", 12.2F, FontStyle.Bold);
            labelSoLuong.Location = new Point(33, 499);
            labelSoLuong.Margin = new Padding(2, 0, 2, 0);
            labelSoLuong.Name = "labelSoLuong";
            labelSoLuong.Size = new Size(79, 23);
            labelSoLuong.TabIndex = 8;
            labelSoLuong.Text = "Số lượng";
            // 
            // labelDonGia
            // 
            labelDonGia.AutoSize = true;
            labelDonGia.Font = new Font("Segoe UI Semibold", 12.2F, FontStyle.Bold);
            labelDonGia.Location = new Point(33, 578);
            labelDonGia.Margin = new Padding(2, 0, 2, 0);
            labelDonGia.Name = "labelDonGia";
            labelDonGia.Size = new Size(70, 23);
            labelDonGia.TabIndex = 9;
            labelDonGia.Text = "Đơn giá";
            // 
            // labelLai
            // 
            labelLai.AutoSize = true;
            labelLai.Font = new Font("Segoe UI Semibold", 12.2F, FontStyle.Bold);
            labelLai.Location = new Point(33, 639);
            labelLai.Margin = new Padding(2, 0, 2, 0);
            labelLai.Name = "labelLai";
            labelLai.Size = new Size(31, 23);
            labelLai.TabIndex = 10;
            labelLai.Text = "Lãi";
            // 
            // FormLichSu
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1467, 695);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(panel1);
            Margin = new Padding(2);
            Name = "FormLichSu";
            Text = "FormLichSu";
            Load += FormLichSu_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPhieu).EndInit();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCt).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private DataGridView dgvPhieu;
        private Label lbDenngay;
        private Label lbTungay;
        private Label label1;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker1;
        private ComboBox comboBox1;
        private DataGridView dgvCt;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand2;
        private Button btnTk;
        private Label labelMaNV;
        private Label labelTenNV;
        private Label labelNgayTao;
        private Label labelTrangThai;
        private Label labelTongTien;
        private Panel panel1;
        private Label label4;
        private ComboBox cbTrangthai;
        private Label label5;
        private ComboBox cbNgayloc;
        private Label labelLai;
        private Label labelDonGia;
        private Label labelSoLuong;
        private Label labelTenSP;
    }
}