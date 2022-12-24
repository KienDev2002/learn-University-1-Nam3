namespace htcolor
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
            this.btnColor = new System.Windows.Forms.Button();
            this.lbMaunen = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.rdMauxanh = new System.Windows.Forms.RadioButton();
            this.rdMaudo = new System.Windows.Forms.RadioButton();
            this.rdMauvang = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(146, 206);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(100, 33);
            this.btnColor.TabIndex = 0;
            this.btnColor.Text = "Màu nền";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // lbMaunen
            // 
            this.lbMaunen.AutoSize = true;
            this.lbMaunen.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbMaunen.Location = new System.Drawing.Point(190, 73);
            this.lbMaunen.Name = "lbMaunen";
            this.lbMaunen.Size = new System.Drawing.Size(344, 29);
            this.lbMaunen.TabIndex = 1;
            this.lbMaunen.Text = "Nhóm 1: Bắc, Hiệp, Kiên, Quốc";
            this.lbMaunen.Click += new System.EventHandler(this.lbMaunen_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(615, 348);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(100, 33);
            this.btnThoat.TabIndex = 3;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // rdMauxanh
            // 
            this.rdMauxanh.AutoSize = true;
            this.rdMauxanh.BackColor = System.Drawing.Color.Green;
            this.rdMauxanh.Location = new System.Drawing.Point(146, 348);
            this.rdMauxanh.Name = "rdMauxanh";
            this.rdMauxanh.Size = new System.Drawing.Size(85, 20);
            this.rdMauxanh.TabIndex = 4;
            this.rdMauxanh.Text = "Màu xanh";
            this.rdMauxanh.UseVisualStyleBackColor = false;
            this.rdMauxanh.CheckedChanged += new System.EventHandler(this.rdMauxanh_CheckedChanged);
            // 
            // rdMaudo
            // 
            this.rdMaudo.AutoSize = true;
            this.rdMaudo.BackColor = System.Drawing.Color.Red;
            this.rdMaudo.Location = new System.Drawing.Point(146, 266);
            this.rdMaudo.Name = "rdMaudo";
            this.rdMaudo.Size = new System.Drawing.Size(73, 20);
            this.rdMaudo.TabIndex = 5;
            this.rdMaudo.Text = "Màu đỏ";
            this.rdMaudo.UseVisualStyleBackColor = false;
            this.rdMaudo.CheckedChanged += new System.EventHandler(this.rdMaudo_CheckedChanged);
            // 
            // rdMauvang
            // 
            this.rdMauvang.AutoSize = true;
            this.rdMauvang.BackColor = System.Drawing.Color.Yellow;
            this.rdMauvang.Location = new System.Drawing.Point(144, 305);
            this.rdMauvang.Name = "rdMauvang";
            this.rdMauvang.Size = new System.Drawing.Size(87, 20);
            this.rdMauvang.TabIndex = 6;
            this.rdMauvang.Text = "Màu vàng";
            this.rdMauvang.UseVisualStyleBackColor = false;
            this.rdMauvang.CheckedChanged += new System.EventHandler(this.rdMauvang_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rdMauvang);
            this.Controls.Add(this.rdMaudo);
            this.Controls.Add(this.rdMauxanh);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.lbMaunen);
            this.Controls.Add(this.btnColor);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Label lbMaunen;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.RadioButton rdMauxanh;
        private System.Windows.Forms.RadioButton rdMaudo;
        private System.Windows.Forms.RadioButton rdMauvang;
    }
}

