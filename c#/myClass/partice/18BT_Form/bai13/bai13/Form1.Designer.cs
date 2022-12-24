namespace bai13
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtNhapSo = new System.Windows.Forms.TextBox();
            this.btnNhapDay = new System.Windows.Forms.Button();
            this.lbDaySo = new System.Windows.Forms.Label();
            this.btnTimSoDuongNN = new System.Windows.Forms.Button();
            this.lbSoDuongNN = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNhapSoK = new System.Windows.Forms.TextBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.btnLamLai = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập số phần tử";
            // 
            // txtNhapSo
            // 
            this.txtNhapSo.Location = new System.Drawing.Point(190, 60);
            this.txtNhapSo.Name = "txtNhapSo";
            this.txtNhapSo.Size = new System.Drawing.Size(207, 22);
            this.txtNhapSo.TabIndex = 1;
            this.txtNhapSo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNhapSo_KeyPress);
            // 
            // btnNhapDay
            // 
            this.btnNhapDay.Location = new System.Drawing.Point(603, 43);
            this.btnNhapDay.Name = "btnNhapDay";
            this.btnNhapDay.Size = new System.Drawing.Size(120, 44);
            this.btnNhapDay.TabIndex = 2;
            this.btnNhapDay.Text = "Nhập dãy";
            this.btnNhapDay.UseVisualStyleBackColor = true;
            this.btnNhapDay.Click += new System.EventHandler(this.btnNhapDay_Click);
            // 
            // lbDaySo
            // 
            this.lbDaySo.AutoSize = true;
            this.lbDaySo.Location = new System.Drawing.Point(68, 127);
            this.lbDaySo.Name = "lbDaySo";
            this.lbDaySo.Size = new System.Drawing.Size(160, 20);
            this.lbDaySo.TabIndex = 3;
            this.lbDaySo.Text = "Dãy số vừa nhập là: ";
            // 
            // btnTimSoDuongNN
            // 
            this.btnTimSoDuongNN.Location = new System.Drawing.Point(56, 170);
            this.btnTimSoDuongNN.Name = "btnTimSoDuongNN";
            this.btnTimSoDuongNN.Size = new System.Drawing.Size(292, 44);
            this.btnTimSoDuongNN.TabIndex = 4;
            this.btnTimSoDuongNN.Text = "Tìm số dương nhỏ nhất";
            this.btnTimSoDuongNN.UseVisualStyleBackColor = true;
            this.btnTimSoDuongNN.Click += new System.EventHandler(this.btnTimSoDuongNN_Click);
            // 
            // lbSoDuongNN
            // 
            this.lbSoDuongNN.AutoSize = true;
            this.lbSoDuongNN.Location = new System.Drawing.Point(68, 247);
            this.lbSoDuongNN.Name = "lbSoDuongNN";
            this.lbSoDuongNN.Size = new System.Drawing.Size(173, 20);
            this.lbSoDuongNN.TabIndex = 5;
            this.lbSoDuongNN.Text = "Số dương nhỏ nhất là: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(68, 313);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nhập 1 số K";
            // 
            // txtNhapSoK
            // 
            this.txtNhapSoK.Location = new System.Drawing.Point(190, 307);
            this.txtNhapSoK.Name = "txtNhapSoK";
            this.txtNhapSoK.Size = new System.Drawing.Size(207, 22);
            this.txtNhapSoK.TabIndex = 7;
            this.txtNhapSoK.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNhapSoK_KeyPress);
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(592, 285);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(120, 44);
            this.btnTim.TabIndex = 8;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // btnLamLai
            // 
            this.btnLamLai.Location = new System.Drawing.Point(401, 365);
            this.btnLamLai.Name = "btnLamLai";
            this.btnLamLai.Size = new System.Drawing.Size(120, 44);
            this.btnLamLai.TabIndex = 9;
            this.btnLamLai.Text = "làm lại";
            this.btnLamLai.UseVisualStyleBackColor = true;
            this.btnLamLai.Click += new System.EventHandler(this.btnLamLai_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(592, 365);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(120, 44);
            this.btnThoat.TabIndex = 10;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnLamLai);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.txtNhapSoK);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbSoDuongNN);
            this.Controls.Add(this.btnTimSoDuongNN);
            this.Controls.Add(this.lbDaySo);
            this.Controls.Add(this.btnNhapDay);
            this.Controls.Add(this.txtNhapSo);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNhapSo;
        private System.Windows.Forms.Button btnNhapDay;
        private System.Windows.Forms.Label lbDaySo;
        private System.Windows.Forms.Button btnTimSoDuongNN;
        private System.Windows.Forms.Label lbSoDuongNN;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNhapSoK;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.Button btnLamLai;
        private System.Windows.Forms.Button btnThoat;
    }
}

