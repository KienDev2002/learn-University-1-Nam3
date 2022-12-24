namespace font_ex
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
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.grOne = new System.Windows.Forms.GroupBox();
            this.frTwo = new System.Windows.Forms.GroupBox();
            this.grThree = new System.Windows.Forms.GroupBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.cbFont = new System.Windows.Forms.ComboBox();
            this.lbFont = new System.Windows.Forms.Label();
            this.cbDam = new System.Windows.Forms.CheckBox();
            this.rdXanh = new System.Windows.Forms.RadioButton();
            this.lbSize = new System.Windows.Forms.Label();
            this.cbSize = new System.Windows.Forms.ComboBox();
            this.cbNghieng = new System.Windows.Forms.CheckBox();
            this.cbGachChan = new System.Windows.Forms.CheckBox();
            this.rdDo = new System.Windows.Forms.RadioButton();
            this.rdHong = new System.Windows.Forms.RadioButton();
            this.btnChonFont = new System.Windows.Forms.Button();
            this.grOne.SuspendLayout();
            this.frTwo.SuspendLayout();
            this.grThree.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTitle
            // 
            this.txtTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.Location = new System.Drawing.Point(175, 25);
            this.txtTitle.Multiline = true;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(702, 76);
            this.txtTitle.TabIndex = 0;
            // 
            // grOne
            // 
            this.grOne.Controls.Add(this.cbSize);
            this.grOne.Controls.Add(this.lbSize);
            this.grOne.Controls.Add(this.lbFont);
            this.grOne.Controls.Add(this.cbFont);
            this.grOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grOne.Location = new System.Drawing.Point(87, 107);
            this.grOne.Name = "grOne";
            this.grOne.Size = new System.Drawing.Size(845, 89);
            this.grOne.TabIndex = 1;
            this.grOne.TabStop = false;
            this.grOne.Text = "Kiểu chữ";
            // 
            // frTwo
            // 
            this.frTwo.Controls.Add(this.cbGachChan);
            this.frTwo.Controls.Add(this.cbNghieng);
            this.frTwo.Controls.Add(this.cbDam);
            this.frTwo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frTwo.Location = new System.Drawing.Point(87, 232);
            this.frTwo.Name = "frTwo";
            this.frTwo.Size = new System.Drawing.Size(845, 89);
            this.frTwo.TabIndex = 2;
            this.frTwo.TabStop = false;
            this.frTwo.Text = "Hiệu ứng";
            // 
            // grThree
            // 
            this.grThree.Controls.Add(this.rdHong);
            this.grThree.Controls.Add(this.rdDo);
            this.grThree.Controls.Add(this.rdXanh);
            this.grThree.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grThree.Location = new System.Drawing.Point(87, 351);
            this.grThree.Name = "grThree";
            this.grThree.Size = new System.Drawing.Size(845, 89);
            this.grThree.TabIndex = 2;
            this.grThree.TabStop = false;
            this.grThree.Text = "Màu chữ";
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.LimeGreen;
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnXoa.Location = new System.Drawing.Point(135, 485);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(130, 35);
            this.btnXoa.TabIndex = 3;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnThoat.Location = new System.Drawing.Point(782, 485);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(115, 35);
            this.btnThoat.TabIndex = 4;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // cbFont
            // 
            this.cbFont.FormattingEnabled = true;
            this.cbFont.Location = new System.Drawing.Point(115, 33);
            this.cbFont.Name = "cbFont";
            this.cbFont.Size = new System.Drawing.Size(277, 33);
            this.cbFont.TabIndex = 0;
            this.cbFont.SelectedIndexChanged += new System.EventHandler(this.cbFont_SelectedIndexChanged);
            // 
            // lbFont
            // 
            this.lbFont.AutoSize = true;
            this.lbFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFont.Location = new System.Drawing.Point(45, 37);
            this.lbFont.Name = "lbFont";
            this.lbFont.Size = new System.Drawing.Size(51, 25);
            this.lbFont.TabIndex = 1;
            this.lbFont.Text = "Font";
            // 
            // cbDam
            // 
            this.cbDam.AutoSize = true;
            this.cbDam.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDam.Location = new System.Drawing.Point(48, 37);
            this.cbDam.Name = "cbDam";
            this.cbDam.Size = new System.Drawing.Size(75, 29);
            this.cbDam.TabIndex = 0;
            this.cbDam.Text = "Đậm";
            this.cbDam.UseVisualStyleBackColor = true;
            this.cbDam.CheckedChanged += new System.EventHandler(this.cbDam_CheckedChanged);
            // 
            // rdXanh
            // 
            this.rdXanh.AutoSize = true;
            this.rdXanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdXanh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.rdXanh.Location = new System.Drawing.Point(48, 41);
            this.rdXanh.Name = "rdXanh";
            this.rdXanh.Size = new System.Drawing.Size(97, 29);
            this.rdXanh.TabIndex = 0;
            this.rdXanh.TabStop = true;
            this.rdXanh.Text = "Xanh lá";
            this.rdXanh.UseVisualStyleBackColor = true;
            this.rdXanh.CheckedChanged += new System.EventHandler(this.rdXanh_CheckedChanged);
            // 
            // lbSize
            // 
            this.lbSize.AutoSize = true;
            this.lbSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSize.Location = new System.Drawing.Point(459, 37);
            this.lbSize.Name = "lbSize";
            this.lbSize.Size = new System.Drawing.Size(51, 25);
            this.lbSize.TabIndex = 2;
            this.lbSize.Text = "Size";
            // 
            // cbSize
            // 
            this.cbSize.FormattingEnabled = true;
            this.cbSize.Location = new System.Drawing.Point(539, 34);
            this.cbSize.Name = "cbSize";
            this.cbSize.Size = new System.Drawing.Size(271, 33);
            this.cbSize.TabIndex = 3;
            this.cbSize.SelectedIndexChanged += new System.EventHandler(this.cbSize_SelectedIndexChanged);
            // 
            // cbNghieng
            // 
            this.cbNghieng.AutoSize = true;
            this.cbNghieng.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNghieng.Location = new System.Drawing.Point(397, 37);
            this.cbNghieng.Name = "cbNghieng";
            this.cbNghieng.Size = new System.Drawing.Size(104, 29);
            this.cbNghieng.TabIndex = 1;
            this.cbNghieng.Text = "Nghiêng";
            this.cbNghieng.UseVisualStyleBackColor = true;
            this.cbNghieng.CheckedChanged += new System.EventHandler(this.cbNghieng_CheckedChanged);
            // 
            // cbGachChan
            // 
            this.cbGachChan.AutoSize = true;
            this.cbGachChan.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbGachChan.Location = new System.Drawing.Point(714, 37);
            this.cbGachChan.Name = "cbGachChan";
            this.cbGachChan.Size = new System.Drawing.Size(126, 29);
            this.cbGachChan.TabIndex = 2;
            this.cbGachChan.Text = "Gạch chân";
            this.cbGachChan.UseVisualStyleBackColor = true;
            this.cbGachChan.CheckedChanged += new System.EventHandler(this.cbGachChan_CheckedChanged);
            // 
            // rdDo
            // 
            this.rdDo.AutoSize = true;
            this.rdDo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdDo.ForeColor = System.Drawing.Color.Red;
            this.rdDo.Location = new System.Drawing.Point(397, 41);
            this.rdDo.Name = "rdDo";
            this.rdDo.Size = new System.Drawing.Size(55, 29);
            this.rdDo.TabIndex = 1;
            this.rdDo.TabStop = true;
            this.rdDo.Text = "Đỏ";
            this.rdDo.UseVisualStyleBackColor = true;
            this.rdDo.CheckedChanged += new System.EventHandler(this.rdDo_CheckedChanged);
            // 
            // rdHong
            // 
            this.rdHong.AutoSize = true;
            this.rdHong.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdHong.ForeColor = System.Drawing.Color.Fuchsia;
            this.rdHong.Location = new System.Drawing.Point(714, 41);
            this.rdHong.Name = "rdHong";
            this.rdHong.Size = new System.Drawing.Size(77, 29);
            this.rdHong.TabIndex = 2;
            this.rdHong.TabStop = true;
            this.rdHong.Text = "Hồng";
            this.rdHong.UseVisualStyleBackColor = true;
            this.rdHong.CheckedChanged += new System.EventHandler(this.rdHong_CheckedChanged);
            // 
            // btnChonFont
            // 
            this.btnChonFont.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnChonFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChonFont.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnChonFont.Location = new System.Drawing.Point(458, 485);
            this.btnChonFont.Name = "btnChonFont";
            this.btnChonFont.Size = new System.Drawing.Size(130, 35);
            this.btnChonFont.TabIndex = 5;
            this.btnChonFont.Text = "Chọn Font";
            this.btnChonFont.UseVisualStyleBackColor = false;
            this.btnChonFont.Click += new System.EventHandler(this.btnChonFont_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1048, 547);
            this.Controls.Add(this.btnChonFont);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.frTwo);
            this.Controls.Add(this.grThree);
            this.Controls.Add(this.grOne);
            this.Controls.Add(this.txtTitle);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grOne.ResumeLayout(false);
            this.grOne.PerformLayout();
            this.frTwo.ResumeLayout(false);
            this.frTwo.PerformLayout();
            this.grThree.ResumeLayout(false);
            this.grThree.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.GroupBox grOne;
        private System.Windows.Forms.ComboBox cbSize;
        private System.Windows.Forms.Label lbSize;
        private System.Windows.Forms.Label lbFont;
        private System.Windows.Forms.ComboBox cbFont;
        private System.Windows.Forms.GroupBox frTwo;
        private System.Windows.Forms.CheckBox cbGachChan;
        private System.Windows.Forms.CheckBox cbNghieng;
        private System.Windows.Forms.CheckBox cbDam;
        private System.Windows.Forms.GroupBox grThree;
        private System.Windows.Forms.RadioButton rdHong;
        private System.Windows.Forms.RadioButton rdDo;
        private System.Windows.Forms.RadioButton rdXanh;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnChonFont;
    }
}

