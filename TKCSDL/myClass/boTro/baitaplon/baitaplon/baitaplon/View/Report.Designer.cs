namespace baitaplon.View
{
    partial class Report
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Report));
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.playerListReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matchResultInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listOfThreePlayersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.cbSelect = new System.Windows.Forms.ComboBox();
            this.lbCBSelect = new System.Windows.Forms.Label();
            this.picBoxBody = new System.Windows.Forms.PictureBox();
            this.menuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxBody)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.Color.PaleTurquoise;
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playerListReportToolStripMenuItem,
            this.matchResultInformationToolStripMenuItem,
            this.listOfThreePlayersToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Padding = new System.Windows.Forms.Padding(14, 3, 0, 3);
            this.menuStrip2.Size = new System.Drawing.Size(1184, 37);
            this.menuStrip2.TabIndex = 4;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // playerListReportToolStripMenuItem
            // 
            this.playerListReportToolStripMenuItem.BackColor = System.Drawing.Color.IndianRed;
            this.playerListReportToolStripMenuItem.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerListReportToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.playerListReportToolStripMenuItem.Name = "playerListReportToolStripMenuItem";
            this.playerListReportToolStripMenuItem.Size = new System.Drawing.Size(135, 31);
            this.playerListReportToolStripMenuItem.Text = "Player list";
            this.playerListReportToolStripMenuItem.Click += new System.EventHandler(this.playerListReportToolStripMenuItem_Click);
            // 
            // matchResultInformationToolStripMenuItem
            // 
            this.matchResultInformationToolStripMenuItem.BackColor = System.Drawing.Color.IndianRed;
            this.matchResultInformationToolStripMenuItem.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matchResultInformationToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.matchResultInformationToolStripMenuItem.Margin = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.matchResultInformationToolStripMenuItem.Name = "matchResultInformationToolStripMenuItem";
            this.matchResultInformationToolStripMenuItem.Size = new System.Drawing.Size(165, 31);
            this.matchResultInformationToolStripMenuItem.Text = "Match result";
            this.matchResultInformationToolStripMenuItem.Click += new System.EventHandler(this.matchResultInformationToolStripMenuItem_Click);
            // 
            // listOfThreePlayersToolStripMenuItem
            // 
            this.listOfThreePlayersToolStripMenuItem.BackColor = System.Drawing.Color.IndianRed;
            this.listOfThreePlayersToolStripMenuItem.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listOfThreePlayersToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.listOfThreePlayersToolStripMenuItem.Margin = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.listOfThreePlayersToolStripMenuItem.Name = "listOfThreePlayersToolStripMenuItem";
            this.listOfThreePlayersToolStripMenuItem.Size = new System.Drawing.Size(217, 31);
            this.listOfThreePlayersToolStripMenuItem.Text = "Top three players";
            this.listOfThreePlayersToolStripMenuItem.Click += new System.EventHandler(this.listOfThreePlayersToolStripMenuItem_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(0, 37);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1184, 668);
            this.reportViewer1.TabIndex = 5;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // cbSelect
            // 
            this.cbSelect.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbSelect.FormattingEnabled = true;
            this.cbSelect.Location = new System.Drawing.Point(885, 120);
            this.cbSelect.Name = "cbSelect";
            this.cbSelect.Size = new System.Drawing.Size(271, 35);
            this.cbSelect.TabIndex = 6;
            this.cbSelect.SelectedIndexChanged += new System.EventHandler(this.cbSelect_SelectedIndexChanged);
            // 
            // lbCBSelect
            // 
            this.lbCBSelect.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbCBSelect.AutoSize = true;
            this.lbCBSelect.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.lbCBSelect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.lbCBSelect.Location = new System.Drawing.Point(959, 86);
            this.lbCBSelect.Name = "lbCBSelect";
            this.lbCBSelect.Size = new System.Drawing.Size(125, 22);
            this.lbCBSelect.TabIndex = 7;
            this.lbCBSelect.Text = "Mã đội bóng";
            // 
            // picBoxBody
            // 
            this.picBoxBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBoxBody.Image = ((System.Drawing.Image)(resources.GetObject("picBoxBody.Image")));
            this.picBoxBody.Location = new System.Drawing.Point(0, 37);
            this.picBoxBody.Name = "picBoxBody";
            this.picBoxBody.Size = new System.Drawing.Size(1184, 668);
            this.picBoxBody.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxBody.TabIndex = 8;
            this.picBoxBody.TabStop = false;
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1184, 705);
            this.Controls.Add(this.picBoxBody);
            this.Controls.Add(this.lbCBSelect);
            this.Controls.Add(this.cbSelect);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.menuStrip2);
            this.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Report";
            this.Text = "báo cáo";
            this.Load += new System.EventHandler(this.Report_Load);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxBody)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem playerListReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem matchResultInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listOfThreePlayersToolStripMenuItem;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.ComboBox cbSelect;
        private System.Windows.Forms.Label lbCBSelect;
        private System.Windows.Forms.PictureBox picBoxBody;
    }
}