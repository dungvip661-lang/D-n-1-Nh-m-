namespace DuAn1_Nhom4.GUI
{
    partial class QuenMatKhauF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuenMatKhauF));
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            lbQuenMatKhau = new Label();
            label1 = new Label();
            label2 = new Label();
            txtEmail = new TextBox();
            txtOTP = new TextBox();
            lbOTP = new Label();
            txtMkmoi = new TextBox();
            lbMkmoi = new Label();
            txtMkxacNhan = new TextBox();
            lbMkxacNhan = new Label();
            btnXacnhan = new Button();
            btnEmail = new Button();
            btnOTP = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(313, 306);
            panel1.TabIndex = 15;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(165, 223, 225);
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(313, 306);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // lbQuenMatKhau
            // 
            lbQuenMatKhau.AutoSize = true;
            lbQuenMatKhau.BackColor = Color.Transparent;
            lbQuenMatKhau.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbQuenMatKhau.Location = new Point(595, 309);
            lbQuenMatKhau.Name = "lbQuenMatKhau";
            lbQuenMatKhau.Size = new Size(111, 19);
            lbQuenMatKhau.TabIndex = 14;
            lbQuenMatKhau.Text = "Quên mật khẩu?";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Historic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(457, 22);
            label1.Name = "label1";
            label1.Size = new Size(197, 32);
            label1.TabIndex = 16;
            label1.Text = "Quên mật khẩu";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            label2.Location = new Point(405, 86);
            label2.Name = "label2";
            label2.Size = new Size(43, 19);
            label2.TabIndex = 17;
            label2.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Location = new Point(468, 82);
            txtEmail.Margin = new Padding(3, 2, 3, 2);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(205, 23);
            txtEmail.TabIndex = 18;
            // 
            // txtOTP
            // 
            txtOTP.BorderStyle = BorderStyle.FixedSingle;
            txtOTP.Location = new Point(468, 122);
            txtOTP.Margin = new Padding(3, 2, 3, 2);
            txtOTP.Name = "txtOTP";
            txtOTP.Size = new Size(205, 23);
            txtOTP.TabIndex = 20;
            txtOTP.Visible = false;
            // 
            // lbOTP
            // 
            lbOTP.AutoSize = true;
            lbOTP.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lbOTP.Location = new Point(388, 130);
            lbOTP.Name = "lbOTP";
            lbOTP.Size = new Size(59, 19);
            lbOTP.TabIndex = 19;
            lbOTP.Text = "Mã OTP";
            lbOTP.Visible = false;
            // 
            // txtMkmoi
            // 
            txtMkmoi.BorderStyle = BorderStyle.FixedSingle;
            txtMkmoi.Location = new Point(468, 164);
            txtMkmoi.Margin = new Padding(3, 2, 3, 2);
            txtMkmoi.Name = "txtMkmoi";
            txtMkmoi.Size = new Size(205, 23);
            txtMkmoi.TabIndex = 22;
            txtMkmoi.Visible = false;
            // 
            // lbMkmoi
            // 
            lbMkmoi.AutoSize = true;
            lbMkmoi.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lbMkmoi.Location = new Point(353, 169);
            lbMkmoi.Name = "lbMkmoi";
            lbMkmoi.Size = new Size(97, 19);
            lbMkmoi.TabIndex = 21;
            lbMkmoi.Text = "Mật khẩu mới";
            lbMkmoi.Visible = false;
            // 
            // txtMkxacNhan
            // 
            txtMkxacNhan.BorderStyle = BorderStyle.FixedSingle;
            txtMkxacNhan.Location = new Point(468, 205);
            txtMkxacNhan.Margin = new Padding(3, 2, 3, 2);
            txtMkxacNhan.Name = "txtMkxacNhan";
            txtMkxacNhan.Size = new Size(205, 23);
            txtMkxacNhan.TabIndex = 24;
            txtMkxacNhan.Visible = false;
            // 
            // lbMkxacNhan
            // 
            lbMkxacNhan.AutoSize = true;
            lbMkxacNhan.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lbMkxacNhan.Location = new Point(323, 208);
            lbMkxacNhan.Name = "lbMkxacNhan";
            lbMkxacNhan.Size = new Size(129, 19);
            lbMkxacNhan.TabIndex = 23;
            lbMkxacNhan.Text = "Xác nhận mật khẩu";
            lbMkxacNhan.Visible = false;
            // 
            // btnXacnhan
            // 
            btnXacnhan.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXacnhan.Location = new Point(633, 249);
            btnXacnhan.Margin = new Padding(3, 2, 3, 2);
            btnXacnhan.Name = "btnXacnhan";
            btnXacnhan.Size = new Size(91, 26);
            btnXacnhan.TabIndex = 25;
            btnXacnhan.Text = "Xác nhận";
            btnXacnhan.UseVisualStyleBackColor = true;
            btnXacnhan.Visible = false;
            btnXacnhan.Click += btnXacnhan_Click;
            // 
            // btnEmail
            // 
            btnEmail.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEmail.Location = new Point(686, 81);
            btnEmail.Margin = new Padding(3, 2, 3, 2);
            btnEmail.Name = "btnEmail";
            btnEmail.Size = new Size(63, 37);
            btnEmail.TabIndex = 26;
            btnEmail.Text = "Gửi";
            btnEmail.UseVisualStyleBackColor = true;
            btnEmail.Click += btnEmail_Click;
            // 
            // btnOTP
            // 
            btnOTP.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOTP.Location = new Point(686, 122);
            btnOTP.Margin = new Padding(3, 2, 3, 2);
            btnOTP.Name = "btnOTP";
            btnOTP.Size = new Size(63, 37);
            btnOTP.TabIndex = 27;
            btnOTP.Text = "OK";
            btnOTP.UseVisualStyleBackColor = true;
            btnOTP.Visible = false;
            btnOTP.Click += btnOTP_Click;
            // 
            // QuenMatKhauF
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(760, 306);
            Controls.Add(btnOTP);
            Controls.Add(btnEmail);
            Controls.Add(btnXacnhan);
            Controls.Add(txtMkxacNhan);
            Controls.Add(lbMkxacNhan);
            Controls.Add(txtMkmoi);
            Controls.Add(lbMkmoi);
            Controls.Add(txtOTP);
            Controls.Add(lbOTP);
            Controls.Add(txtEmail);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(lbQuenMatKhau);
            Margin = new Padding(3, 2, 3, 2);
            Name = "QuenMatKhauF";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quên mật khẩu";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Label lbQuenMatKhau;
        private Label label1;
        private Label label2;
        private TextBox txtEmail;
        private TextBox txtOTP;
        private Label lbOTP;
        private TextBox txtMkmoi;
        private Label lbMkmoi;
        private TextBox txtMkxacNhan;
        private Label lbMkxacNhan;
        private Button btnXacnhan;
        private Button btnEmail;
        private Button btnOTP;
    }
}