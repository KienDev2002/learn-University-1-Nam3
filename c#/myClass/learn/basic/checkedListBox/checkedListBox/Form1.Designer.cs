namespace checkedListBox
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
            this.checkListBoxLeft = new System.Windows.Forms.CheckedListBox();
            this.checkListBoxRight = new System.Windows.Forms.CheckedListBox();
            this.btnFromLeftToRight = new System.Windows.Forms.Button();
            this.btnFromRightToLeft = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkListBoxLeft
            // 
            this.checkListBoxLeft.FormattingEnabled = true;
            this.checkListBoxLeft.Location = new System.Drawing.Point(30, 77);
            this.checkListBoxLeft.Name = "checkListBoxLeft";
            this.checkListBoxLeft.Size = new System.Drawing.Size(335, 293);
            this.checkListBoxLeft.TabIndex = 0;
            this.checkListBoxLeft.SelectedIndexChanged += new System.EventHandler(this.checkListBoxLeft_SelectedIndexChanged);
            // 
            // checkListBoxRight
            // 
            this.checkListBoxRight.FormattingEnabled = true;
            this.checkListBoxRight.Location = new System.Drawing.Point(605, 77);
            this.checkListBoxRight.Name = "checkListBoxRight";
            this.checkListBoxRight.Size = new System.Drawing.Size(335, 293);
            this.checkListBoxRight.TabIndex = 1;
            this.checkListBoxRight.SelectedIndexChanged += new System.EventHandler(this.checkListBoxRight_SelectedIndexChanged);
            // 
            // btnFromLeftToRight
            // 
            this.btnFromLeftToRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFromLeftToRight.Location = new System.Drawing.Point(426, 105);
            this.btnFromLeftToRight.Name = "btnFromLeftToRight";
            this.btnFromLeftToRight.Size = new System.Drawing.Size(119, 51);
            this.btnFromLeftToRight.TabIndex = 2;
            this.btnFromLeftToRight.Text = ">";
            this.btnFromLeftToRight.UseVisualStyleBackColor = true;
            this.btnFromLeftToRight.Click += new System.EventHandler(this.btnFromLeftToRight_Click);
            // 
            // btnFromRightToLeft
            // 
            this.btnFromRightToLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFromRightToLeft.Location = new System.Drawing.Point(426, 319);
            this.btnFromRightToLeft.Name = "btnFromRightToLeft";
            this.btnFromRightToLeft.Size = new System.Drawing.Size(119, 51);
            this.btnFromRightToLeft.TabIndex = 4;
            this.btnFromRightToLeft.Text = "<";
            this.btnFromRightToLeft.UseVisualStyleBackColor = true;
            this.btnFromRightToLeft.Click += new System.EventHandler(this.btnFromRightToLeft_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 463);
            this.Controls.Add(this.btnFromRightToLeft);
            this.Controls.Add(this.btnFromLeftToRight);
            this.Controls.Add(this.checkListBoxRight);
            this.Controls.Add(this.checkListBoxLeft);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkListBoxLeft;
        private System.Windows.Forms.CheckedListBox checkListBoxRight;
        private System.Windows.Forms.Button btnFromLeftToRight;
        private System.Windows.Forms.Button btnFromRightToLeft;
    }
}

