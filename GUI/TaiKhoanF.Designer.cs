namespace DuAn1_Nhom4.GUI
{
    partial class TaiKhoanF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaiKhoanF));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label9 = new Label();
            label10 = new Label();
            groupBox1 = new GroupBox();
            txtChucVu = new TextBox();
            txtEmail = new TextBox();
            txtSDT = new TextBox();
            txtHoTen = new TextBox();
            txtMa = new TextBox();
            groupBox2 = new GroupBox();
            picEyeConfirm = new PictureBox();
            pictureBoxeyeOld = new PictureBox();
            picEyeNew = new PictureBox();
            label13 = new Label();
            label11 = new Label();
            lbcapchar = new Label();
            btnLuuMK = new Button();
            txtMaXacNhan = new TextBox();
            label7 = new Label();
            txtXacNhan = new TextBox();
            label8 = new Label();
            txtMKMoi = new TextBox();
            label6 = new Label();
            txtMkCu = new TextBox();
            txtTenDangNhap = new TextBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picEyeConfirm).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxeyeOld).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picEyeNew).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            label1.Location = new Point(168, 85);
            label1.Name = "label1";
            label1.Size = new Size(55, 20);
            label1.TabIndex = 0;
            label1.Text = "Họ tên";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            label2.Location = new Point(168, 33);
            label2.Name = "label2";
            label2.Size = new Size(103, 20);
            label2.TabIndex = 1;
            label2.Text = "Mã nhân viên";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            label3.Location = new Point(168, 136);
            label3.Name = "label3";
            label3.Size = new Size(99, 20);
            label3.TabIndex = 2;
            label3.Text = "Số điện thoại";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            label4.Location = new Point(168, 202);
            label4.Name = "label4";
            label4.Size = new Size(46, 20);
            label4.TabIndex = 5;
            label4.Text = "Email";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            label5.Location = new Point(168, 266);
            label5.Name = "label5";
            label5.Size = new Size(64, 20);
            label5.TabIndex = 6;
            label5.Text = "Chức vụ";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            label9.Location = new Point(168, 41);
            label9.Name = "label9";
            label9.Size = new Size(111, 20);
            label9.TabIndex = 8;
            label9.Text = "Tên đăng nhập";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            label10.Location = new Point(168, 108);
            label10.Name = "label10";
            label10.Size = new Size(94, 20);
            label10.TabIndex = 7;
            label10.Text = "Mật khẩu cũ";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.AliceBlue;
            groupBox1.Controls.Add(txtChucVu);
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Controls.Add(txtSDT);
            groupBox1.Controls.Add(txtHoTen);
            groupBox1.Controls.Add(txtMa);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label5);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(0, 0);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(1467, 324);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin cá nhân";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // txtChucVu
            // 
            txtChucVu.BorderStyle = BorderStyle.FixedSingle;
            txtChucVu.Font = new Font("Segoe UI", 10.8F);
            txtChucVu.Location = new Point(310, 259);
            txtChucVu.Margin = new Padding(3, 2, 3, 2);
            txtChucVu.Name = "txtChucVu";
            txtChucVu.ReadOnly = true;
            txtChucVu.Size = new Size(400, 27);
            txtChucVu.TabIndex = 12;
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 10.8F);
            txtEmail.Location = new Point(310, 202);
            txtEmail.Margin = new Padding(3, 2, 3, 2);
            txtEmail.Name = "txtEmail";
            txtEmail.ReadOnly = true;
            txtEmail.Size = new Size(400, 27);
            txtEmail.TabIndex = 10;
            // 
            // txtSDT
            // 
            txtSDT.BorderStyle = BorderStyle.FixedSingle;
            txtSDT.Font = new Font("Segoe UI", 10.8F);
            txtSDT.Location = new Point(310, 136);
            txtSDT.Margin = new Padding(3, 2, 3, 2);
            txtSDT.Name = "txtSDT";
            txtSDT.ReadOnly = true;
            txtSDT.Size = new Size(400, 27);
            txtSDT.TabIndex = 9;
            // 
            // txtHoTen
            // 
            txtHoTen.BorderStyle = BorderStyle.FixedSingle;
            txtHoTen.Font = new Font("Segoe UI", 10.8F);
            txtHoTen.Location = new Point(310, 85);
            txtHoTen.Margin = new Padding(3, 2, 3, 2);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.ReadOnly = true;
            txtHoTen.Size = new Size(400, 27);
            txtHoTen.TabIndex = 8;
            // 
            // txtMa
            // 
            txtMa.BorderStyle = BorderStyle.FixedSingle;
            txtMa.Font = new Font("Segoe UI", 10.8F);
            txtMa.Location = new Point(310, 33);
            txtMa.Margin = new Padding(3, 2, 3, 2);
            txtMa.Name = "txtMa";
            txtMa.ReadOnly = true;
            txtMa.Size = new Size(400, 27);
            txtMa.TabIndex = 7;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.AliceBlue;
            groupBox2.Controls.Add(picEyeConfirm);
            groupBox2.Controls.Add(pictureBoxeyeOld);
            groupBox2.Controls.Add(picEyeNew);
            groupBox2.Controls.Add(label13);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(lbcapchar);
            groupBox2.Controls.Add(btnLuuMK);
            groupBox2.Controls.Add(txtMaXacNhan);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(txtXacNhan);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(txtMKMoi);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(txtMkCu);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(txtTenDangNhap);
            groupBox2.Controls.Add(label9);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(0, 324);
            groupBox2.Margin = new Padding(3, 2, 3, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 2, 3, 2);
            groupBox2.Size = new Size(1467, 347);
            groupBox2.TabIndex = 11;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông tin tài khoản";
            // 
            // picEyeConfirm
            // 
            picEyeConfirm.Cursor = Cursors.Hand;
            picEyeConfirm.Location = new Point(748, 225);
            picEyeConfirm.Margin = new Padding(3, 2, 3, 2);
            picEyeConfirm.Name = "picEyeConfirm";
            picEyeConfirm.Size = new Size(29, 23);
            picEyeConfirm.SizeMode = PictureBoxSizeMode.Zoom;
            picEyeConfirm.TabIndex = 25;
            picEyeConfirm.TabStop = false;
            picEyeConfirm.Click += picEyeConfirm_Click;
            // 
            // pictureBoxeyeOld
            // 
            pictureBoxeyeOld.Cursor = Cursors.Hand;
            pictureBoxeyeOld.Location = new Point(748, 104);
            pictureBoxeyeOld.Margin = new Padding(3, 2, 3, 2);
            pictureBoxeyeOld.Name = "pictureBoxeyeOld";
            pictureBoxeyeOld.Size = new Size(29, 23);
            pictureBoxeyeOld.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxeyeOld.TabIndex = 24;
            pictureBoxeyeOld.TabStop = false;
            pictureBoxeyeOld.Click += pictureBoxeyeOld_Click;
            // 
            // picEyeNew
            // 
            picEyeNew.Cursor = Cursors.Hand;
            picEyeNew.Location = new Point(748, 163);
            picEyeNew.Margin = new Padding(3, 2, 3, 2);
            picEyeNew.Name = "picEyeNew";
            picEyeNew.Size = new Size(29, 23);
            picEyeNew.SizeMode = PictureBoxSizeMode.Zoom;
            picEyeNew.TabIndex = 23;
            picEyeNew.TabStop = false;
            picEyeNew.Click += picEyeNew_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI Semibold", 9.2F, FontStyle.Bold);
            label13.Location = new Point(795, 41);
            label13.Name = "label13";
            label13.Size = new Size(420, 153);
            label13.TabIndex = 22;
            label13.Text = resources.GetString("label13.Text");
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(520, 286);
            label11.Name = "label11";
            label11.Size = new Size(94, 20);
            label11.TabIndex = 21;
            label11.Text = "Mã capchar:";
            // 
            // lbcapchar
            // 
            lbcapchar.AutoSize = true;
            lbcapchar.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbcapchar.ForeColor = Color.Red;
            lbcapchar.Location = new Point(620, 286);
            lbcapchar.Name = "lbcapchar";
            lbcapchar.Size = new Size(69, 25);
            lbcapchar.TabIndex = 20;
            lbcapchar.Text = "label11";
            // 
            // btnLuuMK
            // 
            btnLuuMK.Font = new Font("Segoe UI Semibold", 12.2F, FontStyle.Bold);
            btnLuuMK.Image = Properties.Resources.icons8_download_from_the_cloud_30;
            btnLuuMK.ImageAlign = ContentAlignment.MiddleLeft;
            btnLuuMK.Location = new Point(530, 358);
            btnLuuMK.Margin = new Padding(3, 2, 3, 2);
            btnLuuMK.Name = "btnLuuMK";
            btnLuuMK.Size = new Size(247, 38);
            btnLuuMK.TabIndex = 19;
            btnLuuMK.Text = "Lưu thay đổi";
            btnLuuMK.UseVisualStyleBackColor = true;
            btnLuuMK.Click += btnLuuMK_Click;
            // 
            // txtMaXacNhan
            // 
            txtMaXacNhan.BorderStyle = BorderStyle.FixedSingle;
            txtMaXacNhan.Font = new Font("Segoe UI", 10.8F);
            txtMaXacNhan.Location = new Point(310, 284);
            txtMaXacNhan.Margin = new Padding(3, 2, 3, 2);
            txtMaXacNhan.Name = "txtMaXacNhan";
            txtMaXacNhan.Size = new Size(162, 27);
            txtMaXacNhan.TabIndex = 18;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            label7.Location = new Point(168, 293);
            label7.Name = "label7";
            label7.Size = new Size(80, 20);
            label7.TabIndex = 17;
            label7.Text = "Nhập mã: ";
            // 
            // txtXacNhan
            // 
            txtXacNhan.BorderStyle = BorderStyle.FixedSingle;
            txtXacNhan.Font = new Font("Segoe UI", 10.8F);
            txtXacNhan.Location = new Point(310, 226);
            txtXacNhan.Margin = new Padding(3, 2, 3, 2);
            txtXacNhan.Name = "txtXacNhan";
            txtXacNhan.Size = new Size(400, 27);
            txtXacNhan.TabIndex = 16;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            label8.Location = new Point(168, 228);
            label8.Name = "label8";
            label8.Size = new Size(140, 20);
            label8.TabIndex = 15;
            label8.Text = "Xác nhận mật khẩu";
            // 
            // txtMKMoi
            // 
            txtMKMoi.BorderStyle = BorderStyle.FixedSingle;
            txtMKMoi.Font = new Font("Segoe UI", 10.8F);
            txtMKMoi.Location = new Point(310, 163);
            txtMKMoi.Margin = new Padding(3, 2, 3, 2);
            txtMKMoi.Name = "txtMKMoi";
            txtMKMoi.Size = new Size(400, 27);
            txtMKMoi.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            label6.Location = new Point(168, 170);
            label6.Name = "label6";
            label6.Size = new Size(104, 20);
            label6.TabIndex = 13;
            label6.Text = "Mật khẩu mới";
            // 
            // txtMkCu
            // 
            txtMkCu.BorderStyle = BorderStyle.FixedSingle;
            txtMkCu.Font = new Font("Segoe UI", 10.8F);
            txtMkCu.Location = new Point(310, 104);
            txtMkCu.Margin = new Padding(3, 2, 3, 2);
            txtMkCu.Name = "txtMkCu";
            txtMkCu.Size = new Size(400, 27);
            txtMkCu.TabIndex = 12;
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.BorderStyle = BorderStyle.FixedSingle;
            txtTenDangNhap.Font = new Font("Segoe UI", 10.8F);
            txtTenDangNhap.Location = new Point(310, 39);
            txtTenDangNhap.Margin = new Padding(3, 2, 3, 2);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.ReadOnly = true;
            txtTenDangNhap.Size = new Size(400, 27);
            txtTenDangNhap.TabIndex = 11;
            // 
            // TaiKhoanF
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1467, 671);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "TaiKhoanF";
            Text = "TaiKhoanF";
            Load += TaiKhoanF_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picEyeConfirm).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxeyeOld).EndInit();
            ((System.ComponentModel.ISupportInitialize)picEyeNew).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label9;
        private Label label10;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private TextBox txtChucVu;
        private TextBox txtTenDangNhap;
        private TextBox txtEmail;
        private TextBox txtSDT;
        private TextBox txtHoTen;
        private TextBox txtMa;
        private TextBox txtMkCu;
        private Button btnLuuMK;
        private TextBox txtMaXacNhan;
        private Label label7;
        private TextBox txtXacNhan;
        private Label label8;
        private TextBox txtMKMoi;
        private Label label6;
        private Label lbcapchar;
        private Label label11;
        private Label label13;
        private PictureBox picEyeNew;
        private PictureBox picEyeConfirm;
        private PictureBox pictureBoxeyeOld;
    }
}