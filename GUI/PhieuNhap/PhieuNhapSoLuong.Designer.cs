namespace DuAn1_Nhom4.GUI.Nhập_hàng
{
    partial class PhieuNhapSoLuong
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
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnXacNhan;

        private void InitializeComponent()
        {
            txtSoLuong = new TextBox();
            lblTitle = new Label();
            btnXacNhan = new Button();
            SuspendLayout();
            // 
            // txtSoLuong
            // 
            txtSoLuong.BorderStyle = BorderStyle.FixedSingle;
            txtSoLuong.Font = new Font("Segoe UI", 10F);
            txtSoLuong.Location = new Point(15, 54);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(563, 25);
            txtSoLuong.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(12, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(135, 19);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Nhập số lượng mới:";
            // 
            // btnXacNhan
            // 
            btnXacNhan.BackColor = Color.LimeGreen;
            btnXacNhan.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXacNhan.Image = Properties.Resources.icons8_tick_302;
            btnXacNhan.ImageAlign = ContentAlignment.MiddleLeft;
            btnXacNhan.Location = new Point(437, 103);
            btnXacNhan.Name = "btnXacNhan";
            btnXacNhan.Size = new Size(141, 35);
            btnXacNhan.TabIndex = 2;
            btnXacNhan.Text = "Xác nhận";
            btnXacNhan.TextAlign = ContentAlignment.MiddleRight;
            btnXacNhan.UseVisualStyleBackColor = false;
            btnXacNhan.Click += btnXacNhan_Click;
            // 
            // PhieuNhapSoLuong
            // 
            AcceptButton = btnXacNhan;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(602, 150);
            Controls.Add(lblTitle);
            Controls.Add(txtSoLuong);
            Controls.Add(btnXacNhan);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PhieuNhapSoLuong";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Chỉnh sửa số lượng";
            Load += PhieuNhapSoLuong_Load;
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion
    }
}