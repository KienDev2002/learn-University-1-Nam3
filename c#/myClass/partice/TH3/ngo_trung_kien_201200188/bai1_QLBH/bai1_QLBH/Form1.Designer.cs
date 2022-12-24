namespace bai1_QLBH
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
            this.gbIFKH = new System.Windows.Forms.GroupBox();
            this.cbTGG = new System.Windows.Forms.ComboBox();
            this.dtmNG = new System.Windows.Forms.DateTimePicker();
            this.tbSTG = new System.Windows.Forms.TextBox();
            this.tbDC = new System.Windows.Forms.TextBox();
            this.tbHoTenKH = new System.Windows.Forms.TextBox();
            this.tbMaKH = new System.Windows.Forms.TextBox();
            this.btnNewAdd = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lbTGG = new System.Windows.Forms.Label();
            this.lbNG = new System.Windows.Forms.Label();
            this.lbSTG = new System.Windows.Forms.Label();
            this.lbDC = new System.Windows.Forms.Label();
            this.lbHTKH = new System.Windows.Forms.Label();
            this.lbMKH = new System.Windows.Forms.Label();
            this.gbLoaiTK = new System.Windows.Forms.GroupBox();
            this.rdPhatLoc = new System.Windows.Forms.RadioButton();
            this.rdThuong = new System.Windows.Forms.RadioButton();
            this.gbDSKH = new System.Windows.Forms.GroupBox();
            this.lbDSKH = new System.Windows.Forms.ListBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.gbIFKH.SuspendLayout();
            this.gbLoaiTK.SuspendLayout();
            this.gbDSKH.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbIFKH
            // 
            this.gbIFKH.Controls.Add(this.cbTGG);
            this.gbIFKH.Controls.Add(this.dtmNG);
            this.gbIFKH.Controls.Add(this.tbSTG);
            this.gbIFKH.Controls.Add(this.tbDC);
            this.gbIFKH.Controls.Add(this.tbHoTenKH);
            this.gbIFKH.Controls.Add(this.tbMaKH);
            this.gbIFKH.Controls.Add(this.btnNewAdd);
            this.gbIFKH.Controls.Add(this.btnAdd);
            this.gbIFKH.Controls.Add(this.lbTGG);
            this.gbIFKH.Controls.Add(this.lbNG);
            this.gbIFKH.Controls.Add(this.lbSTG);
            this.gbIFKH.Controls.Add(this.lbDC);
            this.gbIFKH.Controls.Add(this.lbHTKH);
            this.gbIFKH.Controls.Add(this.lbMKH);
            this.gbIFKH.Controls.Add(this.gbLoaiTK);
            this.gbIFKH.Location = new System.Drawing.Point(14, 26);
            this.gbIFKH.Name = "gbIFKH";
            this.gbIFKH.Size = new System.Drawing.Size(548, 528);
            this.gbIFKH.TabIndex = 0;
            this.gbIFKH.TabStop = false;
            this.gbIFKH.Text = "Nhập thông tin khách hàng";
            // 
            // cbTGG
            // 
            this.cbTGG.FormattingEnabled = true;
            this.cbTGG.Location = new System.Drawing.Point(150, 262);
            this.cbTGG.Name = "cbTGG";
            this.cbTGG.Size = new System.Drawing.Size(299, 24);
            this.cbTGG.TabIndex = 14;
            // 
            // dtmNG
            // 
            this.dtmNG.Location = new System.Drawing.Point(150, 220);
            this.dtmNG.Name = "dtmNG";
            this.dtmNG.Size = new System.Drawing.Size(299, 22);
            this.dtmNG.TabIndex = 13;
            // 
            // tbSTG
            // 
            this.tbSTG.Location = new System.Drawing.Point(150, 180);
            this.tbSTG.Name = "tbSTG";
            this.tbSTG.Size = new System.Drawing.Size(299, 22);
            this.tbSTG.TabIndex = 12;
            // 
            // tbDC
            // 
            this.tbDC.Location = new System.Drawing.Point(150, 143);
            this.tbDC.Name = "tbDC";
            this.tbDC.Size = new System.Drawing.Size(299, 22);
            this.tbDC.TabIndex = 11;
            // 
            // tbHoTenKH
            // 
            this.tbHoTenKH.Location = new System.Drawing.Point(150, 96);
            this.tbHoTenKH.Name = "tbHoTenKH";
            this.tbHoTenKH.Size = new System.Drawing.Size(299, 22);
            this.tbHoTenKH.TabIndex = 10;
            // 
            // tbMaKH
            // 
            this.tbMaKH.Location = new System.Drawing.Point(150, 47);
            this.tbMaKH.Name = "tbMaKH";
            this.tbMaKH.Size = new System.Drawing.Size(299, 22);
            this.tbMaKH.TabIndex = 9;
            this.tbMaKH.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbMaKH_KeyPress);
            // 
            // btnNewAdd
            // 
            this.btnNewAdd.Location = new System.Drawing.Point(410, 463);
            this.btnNewAdd.Name = "btnNewAdd";
            this.btnNewAdd.Size = new System.Drawing.Size(117, 23);
            this.btnNewAdd.TabIndex = 8;
            this.btnNewAdd.Text = "Thêm mới";
            this.btnNewAdd.UseVisualStyleBackColor = true;
            this.btnNewAdd.Click += new System.EventHandler(this.btnNewAdd_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(49, 463);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(183, 23);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Thêm vào danh sách";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lbTGG
            // 
            this.lbTGG.AutoSize = true;
            this.lbTGG.Location = new System.Drawing.Point(46, 266);
            this.lbTGG.Name = "lbTGG";
            this.lbTGG.Size = new System.Drawing.Size(84, 16);
            this.lbTGG.TabIndex = 6;
            this.lbTGG.Text = "Thời gian gửi";
            // 
            // lbNG
            // 
            this.lbNG.AutoSize = true;
            this.lbNG.Location = new System.Drawing.Point(46, 225);
            this.lbNG.Name = "lbNG";
            this.lbNG.Size = new System.Drawing.Size(61, 16);
            this.lbNG.TabIndex = 5;
            this.lbNG.Text = "Ngày gửi";
            // 
            // lbSTG
            // 
            this.lbSTG.AutoSize = true;
            this.lbSTG.Location = new System.Drawing.Point(46, 183);
            this.lbSTG.Name = "lbSTG";
            this.lbSTG.Size = new System.Drawing.Size(69, 16);
            this.lbSTG.TabIndex = 4;
            this.lbSTG.Text = "Số tiền gửi";
            // 
            // lbDC
            // 
            this.lbDC.AutoSize = true;
            this.lbDC.Location = new System.Drawing.Point(46, 146);
            this.lbDC.Name = "lbDC";
            this.lbDC.Size = new System.Drawing.Size(47, 16);
            this.lbDC.TabIndex = 3;
            this.lbDC.Text = "Địa chỉ";
            // 
            // lbHTKH
            // 
            this.lbHTKH.AutoSize = true;
            this.lbHTKH.Location = new System.Drawing.Point(46, 99);
            this.lbHTKH.Name = "lbHTKH";
            this.lbHTKH.Size = new System.Drawing.Size(67, 16);
            this.lbHTKH.TabIndex = 2;
            this.lbHTKH.Text = "Họ tên KH";
            // 
            // lbMKH
            // 
            this.lbMKH.AutoSize = true;
            this.lbMKH.Location = new System.Drawing.Point(46, 53);
            this.lbMKH.Name = "lbMKH";
            this.lbMKH.Size = new System.Drawing.Size(44, 16);
            this.lbMKH.TabIndex = 1;
            this.lbMKH.Text = "MaKH";
            // 
            // gbLoaiTK
            // 
            this.gbLoaiTK.Controls.Add(this.rdPhatLoc);
            this.gbLoaiTK.Controls.Add(this.rdThuong);
            this.gbLoaiTK.Location = new System.Drawing.Point(49, 325);
            this.gbLoaiTK.Name = "gbLoaiTK";
            this.gbLoaiTK.Size = new System.Drawing.Size(436, 102);
            this.gbLoaiTK.TabIndex = 0;
            this.gbLoaiTK.TabStop = false;
            this.gbLoaiTK.Text = "Loại tiết kiệm";
            // 
            // rdPhatLoc
            // 
            this.rdPhatLoc.AutoSize = true;
            this.rdPhatLoc.Location = new System.Drawing.Point(263, 36);
            this.rdPhatLoc.Name = "rdPhatLoc";
            this.rdPhatLoc.Size = new System.Drawing.Size(76, 20);
            this.rdPhatLoc.TabIndex = 1;
            this.rdPhatLoc.TabStop = true;
            this.rdPhatLoc.Text = "Phát lộc";
            this.rdPhatLoc.UseVisualStyleBackColor = true;
            // 
            // rdThuong
            // 
            this.rdThuong.AutoSize = true;
            this.rdThuong.Location = new System.Drawing.Point(68, 36);
            this.rdThuong.Name = "rdThuong";
            this.rdThuong.Size = new System.Drawing.Size(74, 20);
            this.rdThuong.TabIndex = 0;
            this.rdThuong.TabStop = true;
            this.rdThuong.Text = "Thường";
            this.rdThuong.UseVisualStyleBackColor = true;
            // 
            // gbDSKH
            // 
            this.gbDSKH.Controls.Add(this.lbDSKH);
            this.gbDSKH.Location = new System.Drawing.Point(616, 64);
            this.gbDSKH.Name = "gbDSKH";
            this.gbDSKH.Size = new System.Drawing.Size(818, 353);
            this.gbDSKH.TabIndex = 1;
            this.gbDSKH.TabStop = false;
            this.gbDSKH.Text = "Danh sách khách hàng";
            // 
            // lbDSKH
            // 
            this.lbDSKH.FormattingEnabled = true;
            this.lbDSKH.ItemHeight = 16;
            this.lbDSKH.Location = new System.Drawing.Point(15, 23);
            this.lbDSKH.Name = "lbDSKH";
            this.lbDSKH.Size = new System.Drawing.Size(754, 308);
            this.lbDSKH.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(1099, 520);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(115, 23);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(1278, 520);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(107, 23);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1532, 731);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.gbDSKH);
            this.Controls.Add(this.gbIFKH);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbIFKH.ResumeLayout(false);
            this.gbIFKH.PerformLayout();
            this.gbLoaiTK.ResumeLayout(false);
            this.gbLoaiTK.PerformLayout();
            this.gbDSKH.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbIFKH;
        private System.Windows.Forms.Button btnNewAdd;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lbTGG;
        private System.Windows.Forms.Label lbNG;
        private System.Windows.Forms.Label lbSTG;
        private System.Windows.Forms.Label lbDC;
        private System.Windows.Forms.Label lbHTKH;
        private System.Windows.Forms.Label lbMKH;
        private System.Windows.Forms.GroupBox gbLoaiTK;
        private System.Windows.Forms.RadioButton rdPhatLoc;
        private System.Windows.Forms.RadioButton rdThuong;
        private System.Windows.Forms.GroupBox gbDSKH;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox tbMaKH;
        private System.Windows.Forms.ComboBox cbTGG;
        private System.Windows.Forms.DateTimePicker dtmNG;
        private System.Windows.Forms.TextBox tbSTG;
        private System.Windows.Forms.TextBox tbDC;
        private System.Windows.Forms.TextBox tbHoTenKH;
        private System.Windows.Forms.ListBox lbDSKH;
    }
}

