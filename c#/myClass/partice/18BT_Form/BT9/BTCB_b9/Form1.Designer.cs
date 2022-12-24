namespace BTCB_b9
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbSL = new System.Windows.Forms.TextBox();
            this.tbGia = new System.Windows.Forms.TextBox();
            this.cbTenSach = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbGG = new System.Windows.Forms.TextBox();
            this.rbATM = new System.Windows.Forms.RadioButton();
            this.rbTM = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.btThem = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbTT = new System.Windows.Forms.TextBox();
            this.btTinhtong = new System.Windows.Forms.Button();
            this.btXoa = new System.Windows.Forms.Button();
            this.listSACH = new System.Windows.Forms.ListBox();
            this.btThoat = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbSL);
            this.groupBox1.Controls.Add(this.tbGia);
            this.groupBox1.Controls.Add(this.cbTenSach);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(16, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(331, 175);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chọn sách";
            // 
            // tbSL
            // 
            this.tbSL.Location = new System.Drawing.Point(91, 117);
            this.tbSL.Margin = new System.Windows.Forms.Padding(4);
            this.tbSL.Name = "tbSL";
            this.tbSL.Size = new System.Drawing.Size(160, 22);
            this.tbSL.TabIndex = 5;
            this.tbSL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbSL_KeyPress);
            // 
            // tbGia
            // 
            this.tbGia.Enabled = false;
            this.tbGia.Location = new System.Drawing.Point(91, 75);
            this.tbGia.Margin = new System.Windows.Forms.Padding(4);
            this.tbGia.Name = "tbGia";
            this.tbGia.Size = new System.Drawing.Size(160, 22);
            this.tbGia.TabIndex = 4;
            // 
            // cbTenSach
            // 
            this.cbTenSach.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTenSach.FormattingEnabled = true;
            this.cbTenSach.Location = new System.Drawing.Point(91, 33);
            this.cbTenSach.Margin = new System.Windows.Forms.Padding(4);
            this.cbTenSach.Name = "cbTenSach";
            this.cbTenSach.Size = new System.Drawing.Size(160, 24);
            this.cbTenSach.TabIndex = 3;
            this.cbTenSach.SelectedIndexChanged += new System.EventHandler(this.cbTenSach_SelectedIndexChanged);
            this.cbTenSach.SelectedValueChanged += new System.EventHandler(this.ComboBox1_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 121);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Số lượng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Giá";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên sách";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.tbGG);
            this.groupBox2.Controls.Add(this.rbATM);
            this.groupBox2.Controls.Add(this.rbTM);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(380, 12);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(331, 175);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Phương thức thanh toán";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(235, 98);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 18);
            this.label5.TabIndex = 7;
            this.label5.Text = "%";
            // 
            // tbGG
            // 
            this.tbGG.Enabled = false;
            this.tbGG.Location = new System.Drawing.Point(93, 95);
            this.tbGG.Margin = new System.Windows.Forms.Padding(4);
            this.tbGG.Name = "tbGG";
            this.tbGG.Size = new System.Drawing.Size(132, 22);
            this.tbGG.TabIndex = 6;
            // 
            // rbATM
            // 
            this.rbATM.AutoCheck = false;
            this.rbATM.AutoSize = true;
            this.rbATM.Location = new System.Drawing.Point(203, 34);
            this.rbATM.Margin = new System.Windows.Forms.Padding(4);
            this.rbATM.Name = "rbATM";
            this.rbATM.Size = new System.Drawing.Size(84, 20);
            this.rbATM.TabIndex = 5;
            this.rbATM.TabStop = true;
            this.rbATM.Text = "Thẻ ATM";
            this.rbATM.UseVisualStyleBackColor = true;
            this.rbATM.CheckedChanged += new System.EventHandler(this.rbATM_CheckedChanged);
            this.rbATM.Click += new System.EventHandler(this.RadioButton2_Click);
            // 
            // rbTM
            // 
            this.rbTM.AutoCheck = false;
            this.rbTM.AutoSize = true;
            this.rbTM.Location = new System.Drawing.Point(33, 34);
            this.rbTM.Margin = new System.Windows.Forms.Padding(4);
            this.rbTM.Name = "rbTM";
            this.rbTM.Size = new System.Drawing.Size(80, 20);
            this.rbTM.TabIndex = 4;
            this.rbTM.TabStop = true;
            this.rbTM.Text = "Tiền mặt";
            this.rbTM.UseVisualStyleBackColor = true;
            this.rbTM.CheckedChanged += new System.EventHandler(this.rbTM_CheckedChanged);
            this.rbTM.Click += new System.EventHandler(this.RadioButton1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 100);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Giảm giá";
            // 
            // btThem
            // 
            this.btThem.Location = new System.Drawing.Point(317, 194);
            this.btThem.Margin = new System.Windows.Forms.Padding(4);
            this.btThem.Name = "btThem";
            this.btThem.Size = new System.Drawing.Size(100, 28);
            this.btThem.TabIndex = 2;
            this.btThem.Text = "Thêm";
            this.btThem.UseVisualStyleBackColor = true;
            this.btThem.Click += new System.EventHandler(this.BtThem_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbTT);
            this.groupBox3.Controls.Add(this.btTinhtong);
            this.groupBox3.Controls.Add(this.btXoa);
            this.groupBox3.Controls.Add(this.listSACH);
            this.groupBox3.Location = new System.Drawing.Point(144, 255);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(451, 206);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sách đã mua";
            // 
            // tbTT
            // 
            this.tbTT.Enabled = false;
            this.tbTT.Location = new System.Drawing.Point(281, 161);
            this.tbTT.Margin = new System.Windows.Forms.Padding(4);
            this.tbTT.Name = "tbTT";
            this.tbTT.Size = new System.Drawing.Size(132, 22);
            this.tbTT.TabIndex = 3;
            // 
            // btTinhtong
            // 
            this.btTinhtong.Location = new System.Drawing.Point(145, 159);
            this.btTinhtong.Margin = new System.Windows.Forms.Padding(4);
            this.btTinhtong.Name = "btTinhtong";
            this.btTinhtong.Size = new System.Drawing.Size(128, 28);
            this.btTinhtong.TabIndex = 2;
            this.btTinhtong.Text = "Tính tổng tiền";
            this.btTinhtong.UseVisualStyleBackColor = true;
            this.btTinhtong.Click += new System.EventHandler(this.BtTinhtong_Click);
            // 
            // btXoa
            // 
            this.btXoa.Location = new System.Drawing.Point(24, 159);
            this.btXoa.Margin = new System.Windows.Forms.Padding(4);
            this.btXoa.Name = "btXoa";
            this.btXoa.Size = new System.Drawing.Size(100, 28);
            this.btXoa.TabIndex = 1;
            this.btXoa.Text = "Xóa";
            this.btXoa.UseVisualStyleBackColor = true;
            this.btXoa.Click += new System.EventHandler(this.Button2_Click);
            // 
            // listSACH
            // 
            this.listSACH.FormattingEnabled = true;
            this.listSACH.ItemHeight = 16;
            this.listSACH.Location = new System.Drawing.Point(8, 23);
            this.listSACH.Margin = new System.Windows.Forms.Padding(4);
            this.listSACH.Name = "listSACH";
            this.listSACH.Size = new System.Drawing.Size(433, 116);
            this.listSACH.TabIndex = 0;
            this.listSACH.SelectedIndexChanged += new System.EventHandler(this.listSACH_SelectedIndexChanged);
            // 
            // btThoat
            // 
            this.btThoat.Location = new System.Drawing.Point(611, 432);
            this.btThoat.Margin = new System.Windows.Forms.Padding(4);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(100, 28);
            this.btThoat.TabIndex = 4;
            this.btThoat.Text = "Thoát";
            this.btThoat.UseVisualStyleBackColor = true;
            this.btThoat.Click += new System.EventHandler(this.BtThoat_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 473);
            this.Controls.Add(this.btThoat);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btThem);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Cửa hàng bán sách";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbSL;
        private System.Windows.Forms.TextBox tbGia;
        private System.Windows.Forms.ComboBox cbTenSach;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbGG;
        private System.Windows.Forms.RadioButton rbATM;
        private System.Windows.Forms.RadioButton rbTM;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btThem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbTT;
        private System.Windows.Forms.Button btTinhtong;
        private System.Windows.Forms.Button btXoa;
        private System.Windows.Forms.ListBox listSACH;
        private System.Windows.Forms.Button btThoat;
    }
}

