namespace lesson2
{
    partial class Form1
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
            this.lbhoten = new System.Windows.Forms.Label();
            this.txthoten = new System.Windows.Forms.TextBox();
            this.lbdt = new System.Windows.Forms.Label();
            this.txtdt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbMatHang = new System.Windows.Forms.ListBox();
            this.lbMua = new System.Windows.Forms.ListBox();
            this.grthanhtoan = new System.Windows.Forms.GroupBox();
            this.rdthe = new System.Windows.Forms.RadioButton();
            this.rdSec = new System.Windows.Forms.RadioButton();
            this.rdTienMat = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbEmail = new System.Windows.Forms.CheckBox();
            this.cbFax = new System.Windows.Forms.CheckBox();
            this.cbDT = new System.Windows.Forms.CheckBox();
            this.btnDongY = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.grthanhtoan.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbhoten
            // 
            this.lbhoten.AutoSize = true;
            this.lbhoten.Location = new System.Drawing.Point(53, 38);
            this.lbhoten.Name = "lbhoten";
            this.lbhoten.Size = new System.Drawing.Size(46, 16);
            this.lbhoten.TabIndex = 0;
            this.lbhoten.Text = "Họ tên";
            this.lbhoten.Click += new System.EventHandler(this.label1_Click);
            // 
            // txthoten
            // 
            this.txthoten.Location = new System.Drawing.Point(154, 35);
            this.txthoten.Name = "txthoten";
            this.txthoten.Size = new System.Drawing.Size(220, 22);
            this.txthoten.TabIndex = 1;
            // 
            // lbdt
            // 
            this.lbdt.AutoSize = true;
            this.lbdt.Location = new System.Drawing.Point(481, 38);
            this.lbdt.Name = "lbdt";
            this.lbdt.Size = new System.Drawing.Size(66, 16);
            this.lbdt.TabIndex = 2;
            this.lbdt.Text = "Điện thoại";
            // 
            // txtdt
            // 
            this.txtdt.Location = new System.Drawing.Point(559, 35);
            this.txtdt.Name = "txtdt";
            this.txtdt.Size = new System.Drawing.Size(220, 22);
            this.txtdt.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Danh sách mặc hàng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(481, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Hàng đặt mua";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // lbMatHang
            // 
            this.lbMatHang.FormattingEnabled = true;
            this.lbMatHang.ItemHeight = 16;
            this.lbMatHang.Location = new System.Drawing.Point(34, 142);
            this.lbMatHang.Name = "lbMatHang";
            this.lbMatHang.Size = new System.Drawing.Size(361, 212);
            this.lbMatHang.TabIndex = 8;
            this.lbMatHang.SelectedIndexChanged += new System.EventHandler(this.lbMatHang_SelectedIndexChanged);
            this.lbMatHang.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbMatHang_MouseDoubleClick);
            this.lbMatHang.MouseEnter += new System.EventHandler(this.lbMatHang_MouseEnter);
            // 
            // lbMua
            // 
            this.lbMua.FormattingEnabled = true;
            this.lbMua.ItemHeight = 16;
            this.lbMua.Location = new System.Drawing.Point(484, 142);
            this.lbMua.Name = "lbMua";
            this.lbMua.Size = new System.Drawing.Size(361, 212);
            this.lbMua.TabIndex = 9;
            this.lbMua.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbMua_MouseDoubleClick);
            // 
            // grthanhtoan
            // 
            this.grthanhtoan.Controls.Add(this.rdthe);
            this.grthanhtoan.Controls.Add(this.rdSec);
            this.grthanhtoan.Controls.Add(this.rdTienMat);
            this.grthanhtoan.Location = new System.Drawing.Point(45, 392);
            this.grthanhtoan.Name = "grthanhtoan";
            this.grthanhtoan.Size = new System.Drawing.Size(338, 202);
            this.grthanhtoan.TabIndex = 10;
            this.grthanhtoan.TabStop = false;
            this.grthanhtoan.Text = "Phương thức thanh toán";
            // 
            // rdthe
            // 
            this.rdthe.AutoSize = true;
            this.rdthe.Location = new System.Drawing.Point(55, 140);
            this.rdthe.Name = "rdthe";
            this.rdthe.Size = new System.Drawing.Size(101, 20);
            this.rdthe.TabIndex = 2;
            this.rdthe.TabStop = true;
            this.rdthe.Text = "Thẻ tín dụng";
            this.rdthe.UseVisualStyleBackColor = true;
            // 
            // rdSec
            // 
            this.rdSec.AutoSize = true;
            this.rdSec.Location = new System.Drawing.Point(55, 96);
            this.rdSec.Name = "rdSec";
            this.rdSec.Size = new System.Drawing.Size(52, 20);
            this.rdSec.TabIndex = 1;
            this.rdSec.TabStop = true;
            this.rdSec.Text = "Sec";
            this.rdSec.UseVisualStyleBackColor = true;
            // 
            // rdTienMat
            // 
            this.rdTienMat.AutoSize = true;
            this.rdTienMat.Location = new System.Drawing.Point(55, 51);
            this.rdTienMat.Name = "rdTienMat";
            this.rdTienMat.Size = new System.Drawing.Size(80, 20);
            this.rdTienMat.TabIndex = 0;
            this.rdTienMat.TabStop = true;
            this.rdTienMat.Text = "Tiền mặt";
            this.rdTienMat.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbEmail);
            this.groupBox2.Controls.Add(this.cbFax);
            this.groupBox2.Controls.Add(this.cbDT);
            this.groupBox2.Location = new System.Drawing.Point(484, 396);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(338, 202);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hình thức liên lạc";
            // 
            // cbEmail
            // 
            this.cbEmail.AutoSize = true;
            this.cbEmail.Location = new System.Drawing.Point(77, 137);
            this.cbEmail.Name = "cbEmail";
            this.cbEmail.Size = new System.Drawing.Size(63, 20);
            this.cbEmail.TabIndex = 2;
            this.cbEmail.Text = "Email";
            this.cbEmail.UseVisualStyleBackColor = true;
            // 
            // cbFax
            // 
            this.cbFax.AutoSize = true;
            this.cbFax.Location = new System.Drawing.Point(76, 93);
            this.cbFax.Name = "cbFax";
            this.cbFax.Size = new System.Drawing.Size(51, 20);
            this.cbFax.TabIndex = 1;
            this.cbFax.Text = "Fax";
            this.cbFax.UseVisualStyleBackColor = true;
            // 
            // cbDT
            // 
            this.cbDT.AutoSize = true;
            this.cbDT.Location = new System.Drawing.Point(75, 48);
            this.cbDT.Name = "cbDT";
            this.cbDT.Size = new System.Drawing.Size(88, 20);
            this.cbDT.TabIndex = 0;
            this.cbDT.Text = "Điện thoại";
            this.cbDT.UseVisualStyleBackColor = true;
            // 
            // btnDongY
            // 
            this.btnDongY.Location = new System.Drawing.Point(128, 629);
            this.btnDongY.Name = "btnDongY";
            this.btnDongY.Size = new System.Drawing.Size(86, 36);
            this.btnDongY.TabIndex = 12;
            this.btnDongY.Text = "Đồng ý";
            this.btnDongY.UseVisualStyleBackColor = true;
            this.btnDongY.Click += new System.EventHandler(this.btnDongY_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(544, 629);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(89, 36);
            this.btnThoat.TabIndex = 14;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 677);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnDongY);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grthanhtoan);
            this.Controls.Add(this.lbMua);
            this.Controls.Add(this.lbMatHang);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtdt);
            this.Controls.Add(this.lbdt);
            this.Controls.Add(this.txthoten);
            this.Controls.Add(this.lbhoten);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grthanhtoan.ResumeLayout(false);
            this.grthanhtoan.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbhoten;
        private System.Windows.Forms.TextBox txthoten;
        private System.Windows.Forms.Label lbdt;
        private System.Windows.Forms.TextBox txtdt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lbMatHang;
        private System.Windows.Forms.ListBox lbMua;
        private System.Windows.Forms.GroupBox grthanhtoan;
        private System.Windows.Forms.RadioButton rdthe;
        private System.Windows.Forms.RadioButton rdSec;
        private System.Windows.Forms.RadioButton rdTienMat;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbEmail;
        private System.Windows.Forms.CheckBox cbFax;
        private System.Windows.Forms.CheckBox cbDT;
        private System.Windows.Forms.Button btnDongY;
        private System.Windows.Forms.Button btnThoat;
    }
}

