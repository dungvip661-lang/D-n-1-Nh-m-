namespace DuAn1_Nhom4.GUI.Hóa_đơn
{
    partial class KhachHangF
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            btnXacNhan = new Button();
            txtTk = new TextBox();
            label2 = new Label();
            dtgKH = new DataGridView();
            tabPage2 = new TabPage();
            btnLamMoi = new Button();
            btnThem = new Button();
            label6 = new Label();
            txtDiachi = new TextBox();
            label5 = new Label();
            txtEmail = new TextBox();
            label4 = new Label();
            txtSdt = new TextBox();
            label3 = new Label();
            txtTen = new TextBox();
            label1 = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgKH).BeginInit();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Margin = new Padding(3, 2, 3, 2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1198, 341);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.AliceBlue;
            tabPage1.Controls.Add(btnXacNhan);
            tabPage1.Controls.Add(txtTk);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(dtgKH);
            tabPage1.Location = new Point(4, 28);
            tabPage1.Margin = new Padding(3, 2, 3, 2);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 2, 3, 2);
            tabPage1.Size = new Size(1190, 309);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Danh sách khách hàng";
            // 
            // btnXacNhan
            // 
            btnXacNhan.BackColor = Color.LimeGreen;
            btnXacNhan.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXacNhan.Image = Properties.Resources.icons8_tick_302;
            btnXacNhan.ImageAlign = ContentAlignment.MiddleLeft;
            btnXacNhan.Location = new Point(469, 28);
            btnXacNhan.Margin = new Padding(3, 2, 3, 2);
            btnXacNhan.Name = "btnXacNhan";
            btnXacNhan.Size = new Size(118, 33);
            btnXacNhan.TabIndex = 8;
            btnXacNhan.Text = "OK";
            btnXacNhan.UseVisualStyleBackColor = false;
            btnXacNhan.Click += btnXacNhan_Click;
            // 
            // txtTk
            // 
            txtTk.BorderStyle = BorderStyle.FixedSingle;
            txtTk.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            txtTk.Location = new Point(170, 28);
            txtTk.Margin = new Padding(3, 2, 3, 2);
            txtTk.Multiline = true;
            txtTk.Name = "txtTk";
            txtTk.Size = new Size(267, 33);
            txtTk.TabIndex = 7;
            txtTk.TextChanged += txtTk_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label2.Location = new Point(40, 35);
            label2.Name = "label2";
            label2.Size = new Size(93, 19);
            label2.TabIndex = 6;
            label2.Text = "Số điện thoại";
            // 
            // dtgKH
            // 
            dtgKH.AllowUserToAddRows = false;
            dtgKH.AllowUserToDeleteRows = false;
            dtgKH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgKH.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgKH.Dock = DockStyle.Bottom;
            dtgKH.Location = new Point(3, 107);
            dtgKH.Margin = new Padding(3, 2, 3, 2);
            dtgKH.MultiSelect = false;
            dtgKH.Name = "dtgKH";
            dtgKH.ReadOnly = true;
            dtgKH.RowHeadersWidth = 51;
            dtgKH.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgKH.Size = new Size(1184, 200);
            dtgKH.TabIndex = 5;
            dtgKH.CellContentClick += dtgKH_CellContentClick;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.AliceBlue;
            tabPage2.Controls.Add(btnLamMoi);
            tabPage2.Controls.Add(btnThem);
            tabPage2.Controls.Add(label6);
            tabPage2.Controls.Add(txtDiachi);
            tabPage2.Controls.Add(label5);
            tabPage2.Controls.Add(txtEmail);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(txtSdt);
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(txtTen);
            tabPage2.Controls.Add(label1);
            tabPage2.Location = new Point(4, 28);
            tabPage2.Margin = new Padding(3, 2, 3, 2);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 2, 3, 2);
            tabPage2.Size = new Size(1190, 309);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Thêm khách hàng";
            tabPage2.Click += tabPage2_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.Turquoise;
            btnLamMoi.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            btnLamMoi.Image = Properties.Resources.icons8_replace_30;
            btnLamMoi.ImageAlign = ContentAlignment.MiddleLeft;
            btnLamMoi.Location = new Point(390, 222);
            btnLamMoi.Margin = new Padding(3, 2, 3, 2);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(172, 36);
            btnLamMoi.TabIndex = 10;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.LimeGreen;
            btnThem.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            btnThem.Image = Properties.Resources.icons8_add_user_male_30;
            btnThem.ImageAlign = ContentAlignment.MiddleLeft;
            btnThem.Location = new Point(158, 222);
            btnThem.Margin = new Padding(3, 2, 3, 2);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(172, 36);
            btnThem.TabIndex = 9;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(207, 26);
            label6.Name = "label6";
            label6.Size = new Size(247, 25);
            label6.TabIndex = 8;
            label6.Text = "Nhập thông tin khách hàng";
            // 
            // txtDiachi
            // 
            txtDiachi.BorderStyle = BorderStyle.FixedSingle;
            txtDiachi.Location = new Point(467, 166);
            txtDiachi.Margin = new Padding(3, 2, 3, 2);
            txtDiachi.Name = "txtDiachi";
            txtDiachi.Size = new Size(195, 26);
            txtDiachi.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label5.Location = new Point(390, 166);
            label5.Name = "label5";
            label5.Size = new Size(53, 19);
            label5.TabIndex = 6;
            label5.Text = "Địa chỉ";
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Location = new Point(134, 162);
            txtEmail.Margin = new Padding(3, 2, 3, 2);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(195, 26);
            txtEmail.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label4.Location = new Point(59, 166);
            label4.Name = "label4";
            label4.Size = new Size(43, 19);
            label4.TabIndex = 4;
            label4.Text = "Email";
            // 
            // txtSdt
            // 
            txtSdt.BorderStyle = BorderStyle.FixedSingle;
            txtSdt.Location = new Point(467, 98);
            txtSdt.Margin = new Padding(3, 2, 3, 2);
            txtSdt.Name = "txtSdt";
            txtSdt.Size = new Size(195, 26);
            txtSdt.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label3.Location = new Point(354, 98);
            label3.Name = "label3";
            label3.Size = new Size(93, 19);
            label3.TabIndex = 2;
            label3.Text = "Số điện thoại";
            // 
            // txtTen
            // 
            txtTen.BorderStyle = BorderStyle.FixedSingle;
            txtTen.Location = new Point(134, 94);
            txtTen.Margin = new Padding(3, 2, 3, 2);
            txtTen.Name = "txtTen";
            txtTen.Size = new Size(195, 26);
            txtTen.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label1.Location = new Point(14, 94);
            label1.Name = "label1";
            label1.Size = new Size(107, 19);
            label1.TabIndex = 0;
            label1.Text = "Tên khách hàng";
            // 
            // KhachHangF
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1198, 341);
            Controls.Add(tabControl1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "KhachHangF";
            StartPosition = FormStartPosition.CenterScreen;
            Text = " Khách hàng";
            Load += KhachHangF_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgKH).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button btnXacNhan;
        private TextBox txtTk;
        private Label label2;
        private DataGridView dtgKH;
        private TextBox txtTen;
        private Label label1;
        private Label label6;
        private TextBox txtDiachi;
        private Label label5;
        private TextBox txtEmail;
        private Label label4;
        private TextBox txtSdt;
        private Label label3;
        private Button btnLamMoi;
        private Button btnThem;
    }
}