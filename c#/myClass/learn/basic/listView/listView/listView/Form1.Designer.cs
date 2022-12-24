namespace listView
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Mã 01",
            "Giày",
            "1000"}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "Mã 02",
            "Áo",
            "100"}, -1);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "Mã 03",
            "Quần",
            "400"}, -1);
            this.txtMaH = new System.Windows.Forms.TextBox();
            this.txtSL = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.lvDS = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.llMH = new System.Windows.Forms.Label();
            this.txtTenH = new System.Windows.Forms.TextBox();
            this.lbTH = new System.Windows.Forms.Label();
            this.lbSL = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtMaH
            // 
            this.txtMaH.Location = new System.Drawing.Point(773, 64);
            this.txtMaH.Name = "txtMaH";
            this.txtMaH.Size = new System.Drawing.Size(232, 22);
            this.txtMaH.TabIndex = 0;
            // 
            // txtSL
            // 
            this.txtSL.Location = new System.Drawing.Point(773, 210);
            this.txtSL.Name = "txtSL";
            this.txtSL.Size = new System.Drawing.Size(232, 22);
            this.txtSL.TabIndex = 2;
            this.txtSL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSL_KeyPress);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(829, 284);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(113, 41);
            this.btnThem.TabIndex = 3;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(829, 472);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(113, 41);
            this.btnXoa.TabIndex = 4;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(829, 385);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(113, 41);
            this.btnSua.TabIndex = 5;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // lvDS
            // 
            this.lvDS.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvDS.FullRowSelect = true;
            this.lvDS.GridLines = true;
            this.lvDS.HideSelection = false;
            this.lvDS.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3});
            this.lvDS.Location = new System.Drawing.Point(12, 12);
            this.lvDS.Name = "lvDS";
            this.lvDS.Size = new System.Drawing.Size(637, 501);
            this.lvDS.TabIndex = 6;
            this.lvDS.UseCompatibleStateImageBehavior = false;
            this.lvDS.View = System.Windows.Forms.View.Details;
            this.lvDS.SelectedIndexChanged += new System.EventHandler(this.lvDS_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã hàng";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên hàng";
            this.columnHeader2.Width = 250;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Số lượng";
            this.columnHeader3.Width = 150;
            // 
            // llMH
            // 
            this.llMH.AutoSize = true;
            this.llMH.Location = new System.Drawing.Point(655, 67);
            this.llMH.Name = "llMH";
            this.llMH.Size = new System.Drawing.Size(59, 16);
            this.llMH.TabIndex = 7;
            this.llMH.Text = "Mã hàng";
            // 
            // txtTenH
            // 
            this.txtTenH.Location = new System.Drawing.Point(773, 133);
            this.txtTenH.Name = "txtTenH";
            this.txtTenH.Size = new System.Drawing.Size(232, 22);
            this.txtTenH.TabIndex = 1;
            // 
            // lbTH
            // 
            this.lbTH.AutoSize = true;
            this.lbTH.Location = new System.Drawing.Point(655, 139);
            this.lbTH.Name = "lbTH";
            this.lbTH.Size = new System.Drawing.Size(64, 16);
            this.lbTH.TabIndex = 8;
            this.lbTH.Text = "Tên hàng";
            // 
            // lbSL
            // 
            this.lbSL.AutoSize = true;
            this.lbSL.Location = new System.Drawing.Point(655, 216);
            this.lbSL.Name = "lbSL";
            this.lbSL.Size = new System.Drawing.Size(60, 16);
            this.lbSL.TabIndex = 9;
            this.lbSL.Text = "Số lượng";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 521);
            this.Controls.Add(this.lbSL);
            this.Controls.Add(this.lbTH);
            this.Controls.Add(this.llMH);
            this.Controls.Add(this.lvDS);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtSL);
            this.Controls.Add(this.txtTenH);
            this.Controls.Add(this.txtMaH);
            this.Name = "Form1";
            this.Text = "ListView";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMaH;
        private System.Windows.Forms.TextBox txtSL;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.ListView lvDS;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label llMH;
        private System.Windows.Forms.TextBox txtTenH;
        private System.Windows.Forms.Label lbTH;
        private System.Windows.Forms.Label lbSL;
    }
}

