namespace bai12
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
            this.lbNhap = new System.Windows.Forms.Label();
            this.tbNhap = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btXoa = new System.Windows.Forms.Button();
            this.btThem = new System.Windows.Forms.Button();
            this.btTangdv = new System.Windows.Forms.Button();
            this.btChon = new System.Windows.Forms.Button();
            this.btThoat = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnKtra = new System.Windows.Forms.Button();
            this.lbSnt = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbNhap
            // 
            this.lbNhap.Location = new System.Drawing.Point(26, 38);
            this.lbNhap.Name = "lbNhap";
            this.lbNhap.Size = new System.Drawing.Size(100, 14);
            this.lbNhap.TabIndex = 0;
            this.lbNhap.Text = "Nhập 1 số:";
            // 
            // tbNhap
            // 
            this.tbNhap.Location = new System.Drawing.Point(132, 38);
            this.tbNhap.Multiline = true;
            this.tbNhap.Name = "tbNhap";
            this.tbNhap.Size = new System.Drawing.Size(129, 21);
            this.tbNhap.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Controls.Add(this.btXoa);
            this.groupBox1.Location = new System.Drawing.Point(275, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(189, 280);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dãy số";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 17;
            this.listBox1.Location = new System.Drawing.Point(10, 23);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox1.Size = new System.Drawing.Size(167, 191);
            this.listBox1.TabIndex = 0;
            // 
            // btXoa
            // 
            this.btXoa.Location = new System.Drawing.Point(40, 241);
            this.btXoa.Name = "btXoa";
            this.btXoa.Size = new System.Drawing.Size(107, 31);
            this.btXoa.TabIndex = 6;
            this.btXoa.Text = "Xóa";
            this.btXoa.UseVisualStyleBackColor = true;
            this.btXoa.Click += new System.EventHandler(this.BtXoa_Click);
            // 
            // btThem
            // 
            this.btThem.Location = new System.Drawing.Point(89, 90);
            this.btThem.Name = "btThem";
            this.btThem.Size = new System.Drawing.Size(107, 31);
            this.btThem.TabIndex = 3;
            this.btThem.Text = "Thêm";
            this.btThem.UseVisualStyleBackColor = true;
            this.btThem.Click += new System.EventHandler(this.BtThem_Click);
            // 
            // btTangdv
            // 
            this.btTangdv.Location = new System.Drawing.Point(89, 145);
            this.btTangdv.Name = "btTangdv";
            this.btTangdv.Size = new System.Drawing.Size(107, 31);
            this.btTangdv.TabIndex = 4;
            this.btTangdv.Text = "Tăng mỗi số lên 3";
            this.btTangdv.UseVisualStyleBackColor = true;
            this.btTangdv.Click += new System.EventHandler(this.BtTangdv_Click);
            // 
            // btChon
            // 
            this.btChon.Location = new System.Drawing.Point(89, 200);
            this.btChon.Name = "btChon";
            this.btChon.Size = new System.Drawing.Size(107, 31);
            this.btChon.TabIndex = 5;
            this.btChon.Text = "Chọn số chẵn đầu";
            this.btChon.UseVisualStyleBackColor = true;
            this.btChon.Click += new System.EventHandler(this.BtChon_Click);
            // 
            // btThoat
            // 
            this.btThoat.Location = new System.Drawing.Point(316, 300);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(107, 31);
            this.btThoat.TabIndex = 7;
            this.btThoat.Text = "Thoát";
            this.btThoat.UseVisualStyleBackColor = true;
            this.btThoat.Click += new System.EventHandler(this.BtThoat_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbSnt);
            this.groupBox2.Controls.Add(this.btnKtra);
            this.groupBox2.Location = new System.Drawing.Point(21, 274);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(240, 189);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Kiểm tra số nguyên tố";
            // 
            // btnKtra
            // 
            this.btnKtra.Location = new System.Drawing.Point(24, 38);
            this.btnKtra.Name = "btnKtra";
            this.btnKtra.Size = new System.Drawing.Size(107, 31);
            this.btnKtra.TabIndex = 9;
            this.btnKtra.Text = "Kiểm tra";
            this.btnKtra.UseVisualStyleBackColor = true;
            this.btnKtra.Click += new System.EventHandler(this.btnKtra_Click);
            // 
            // lbSnt
            // 
            this.lbSnt.Location = new System.Drawing.Point(56, 107);
            this.lbSnt.Name = "lbSnt";
            this.lbSnt.Size = new System.Drawing.Size(150, 57);
            this.lbSnt.TabIndex = 10;
            this.lbSnt.Text = "Nhập 1 số:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 494);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btThoat);
            this.Controls.Add(this.btChon);
            this.Controls.Add(this.btTangdv);
            this.Controls.Add(this.btThem);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbNhap);
            this.Controls.Add(this.lbNhap);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.Text = "Làm việc trên dãy số";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbNhap;
        private System.Windows.Forms.TextBox tbNhap;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btXoa;
        private System.Windows.Forms.Button btThem;
        private System.Windows.Forms.Button btTangdv;
        private System.Windows.Forms.Button btChon;
        private System.Windows.Forms.Button btThoat;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbSnt;
        private System.Windows.Forms.Button btnKtra;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

