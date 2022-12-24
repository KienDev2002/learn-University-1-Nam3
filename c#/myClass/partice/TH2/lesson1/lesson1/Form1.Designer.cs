namespace lesson1
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
            this.rdUsa = new System.Windows.Forms.RadioButton();
            this.rdBra = new System.Windows.Forms.RadioButton();
            this.rdArrgentina = new System.Windows.Forms.RadioButton();
            this.rdItaly = new System.Windows.Forms.RadioButton();
            this.rdTurkey = new System.Windows.Forms.RadioButton();
            this.rdJapan = new System.Windows.Forms.RadioButton();
            this.rdHungary = new System.Windows.Forms.RadioButton();
            this.rdTheUk = new System.Windows.Forms.RadioButton();
            this.rdSpain = new System.Windows.Forms.RadioButton();
            this.rdFance = new System.Windows.Forms.RadioButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdParis = new System.Windows.Forms.RadioButton();
            this.rdoBudapest = new System.Windows.Forms.RadioButton();
            this.rdAnkara = new System.Windows.Forms.RadioButton();
            this.rdoLondon = new System.Windows.Forms.RadioButton();
            this.rdWashington = new System.Windows.Forms.RadioButton();
            this.rdBrazil = new System.Windows.Forms.RadioButton();
            this.rdTokyo = new System.Windows.Forms.RadioButton();
            this.rdMar = new System.Windows.Forms.RadioButton();
            this.rdRome = new System.Windows.Forms.RadioButton();
            this.rdBuenos = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdUsa);
            this.groupBox1.Controls.Add(this.rdBra);
            this.groupBox1.Controls.Add(this.rdArrgentina);
            this.groupBox1.Controls.Add(this.rdItaly);
            this.groupBox1.Controls.Add(this.rdTurkey);
            this.groupBox1.Controls.Add(this.rdJapan);
            this.groupBox1.Controls.Add(this.rdHungary);
            this.groupBox1.Controls.Add(this.rdTheUk);
            this.groupBox1.Controls.Add(this.rdSpain);
            this.groupBox1.Controls.Add(this.rdFance);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(117, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(319, 461);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Country";
            // 
            // rdUsa
            // 
            this.rdUsa.AutoSize = true;
            this.rdUsa.Location = new System.Drawing.Point(50, 409);
            this.rdUsa.Name = "rdUsa";
            this.rdUsa.Size = new System.Drawing.Size(136, 33);
            this.rdUsa.TabIndex = 9;
            this.rdUsa.TabStop = true;
            this.rdUsa.Text = "The USA";
            this.rdUsa.UseVisualStyleBackColor = true;
            this.rdUsa.CheckedChanged += new System.EventHandler(this.rdUsa_CheckedChanged);
            // 
            // rdBra
            // 
            this.rdBra.AutoSize = true;
            this.rdBra.Location = new System.Drawing.Point(50, 370);
            this.rdBra.Name = "rdBra";
            this.rdBra.Size = new System.Drawing.Size(98, 33);
            this.rdBra.TabIndex = 8;
            this.rdBra.TabStop = true;
            this.rdBra.Text = "Brazil";
            this.rdBra.UseVisualStyleBackColor = true;
            this.rdBra.CheckedChanged += new System.EventHandler(this.rdBra_CheckedChanged);
            // 
            // rdArrgentina
            // 
            this.rdArrgentina.AutoSize = true;
            this.rdArrgentina.Location = new System.Drawing.Point(50, 331);
            this.rdArrgentina.Name = "rdArrgentina";
            this.rdArrgentina.Size = new System.Drawing.Size(150, 33);
            this.rdArrgentina.TabIndex = 7;
            this.rdArrgentina.TabStop = true;
            this.rdArrgentina.Text = "Arrgentina";
            this.rdArrgentina.UseVisualStyleBackColor = true;
            this.rdArrgentina.CheckedChanged += new System.EventHandler(this.rdArrgentina_CheckedChanged);
            // 
            // rdItaly
            // 
            this.rdItaly.AutoSize = true;
            this.rdItaly.Location = new System.Drawing.Point(50, 292);
            this.rdItaly.Name = "rdItaly";
            this.rdItaly.Size = new System.Drawing.Size(80, 33);
            this.rdItaly.TabIndex = 6;
            this.rdItaly.TabStop = true;
            this.rdItaly.Text = "Italy";
            this.rdItaly.UseVisualStyleBackColor = true;
            this.rdItaly.CheckedChanged += new System.EventHandler(this.rdItaly_CheckedChanged);
            // 
            // rdTurkey
            // 
            this.rdTurkey.AutoSize = true;
            this.rdTurkey.Location = new System.Drawing.Point(50, 214);
            this.rdTurkey.Name = "rdTurkey";
            this.rdTurkey.Size = new System.Drawing.Size(111, 33);
            this.rdTurkey.TabIndex = 5;
            this.rdTurkey.TabStop = true;
            this.rdTurkey.Text = "Turkey";
            this.rdTurkey.UseVisualStyleBackColor = true;
            this.rdTurkey.CheckedChanged += new System.EventHandler(this.rdTurkey_CheckedChanged);
            // 
            // rdJapan
            // 
            this.rdJapan.AutoSize = true;
            this.rdJapan.Location = new System.Drawing.Point(50, 97);
            this.rdJapan.Name = "rdJapan";
            this.rdJapan.Size = new System.Drawing.Size(103, 33);
            this.rdJapan.TabIndex = 4;
            this.rdJapan.TabStop = true;
            this.rdJapan.Text = "Japan";
            this.rdJapan.UseVisualStyleBackColor = true;
            this.rdJapan.CheckedChanged += new System.EventHandler(this.rdJapan_CheckedChanged);
            // 
            // rdHungary
            // 
            this.rdHungary.AutoSize = true;
            this.rdHungary.Location = new System.Drawing.Point(50, 136);
            this.rdHungary.Name = "rdHungary";
            this.rdHungary.Size = new System.Drawing.Size(129, 33);
            this.rdHungary.TabIndex = 3;
            this.rdHungary.TabStop = true;
            this.rdHungary.Text = "Hungary";
            this.rdHungary.UseVisualStyleBackColor = true;
            this.rdHungary.CheckedChanged += new System.EventHandler(this.rdHungary_CheckedChanged);
            // 
            // rdTheUk
            // 
            this.rdTheUk.AutoSize = true;
            this.rdTheUk.Location = new System.Drawing.Point(50, 253);
            this.rdTheUk.Name = "rdTheUk";
            this.rdTheUk.Size = new System.Drawing.Size(119, 33);
            this.rdTheUk.TabIndex = 2;
            this.rdTheUk.TabStop = true;
            this.rdTheUk.Text = "The UK";
            this.rdTheUk.UseVisualStyleBackColor = true;
            this.rdTheUk.CheckedChanged += new System.EventHandler(this.rdTheUk_CheckedChanged);
            // 
            // rdSpain
            // 
            this.rdSpain.AutoSize = true;
            this.rdSpain.Location = new System.Drawing.Point(50, 175);
            this.rdSpain.Name = "rdSpain";
            this.rdSpain.Size = new System.Drawing.Size(99, 33);
            this.rdSpain.TabIndex = 1;
            this.rdSpain.TabStop = true;
            this.rdSpain.Text = "Spain";
            this.rdSpain.UseVisualStyleBackColor = true;
            this.rdSpain.CheckedChanged += new System.EventHandler(this.rdSpain_CheckedChanged);
            // 
            // rdFance
            // 
            this.rdFance.AutoSize = true;
            this.rdFance.Location = new System.Drawing.Point(50, 58);
            this.rdFance.Name = "rdFance";
            this.rdFance.Size = new System.Drawing.Size(112, 33);
            this.rdFance.TabIndex = 0;
            this.rdFance.TabStop = true;
            this.rdFance.Text = "France";
            this.rdFance.UseVisualStyleBackColor = true;
            this.rdFance.CheckedChanged += new System.EventHandler(this.rdFance_CheckedChanged_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdParis);
            this.groupBox2.Controls.Add(this.rdoBudapest);
            this.groupBox2.Controls.Add(this.rdAnkara);
            this.groupBox2.Controls.Add(this.rdoLondon);
            this.groupBox2.Controls.Add(this.rdWashington);
            this.groupBox2.Controls.Add(this.rdBrazil);
            this.groupBox2.Controls.Add(this.rdTokyo);
            this.groupBox2.Controls.Add(this.rdMar);
            this.groupBox2.Controls.Add(this.rdRome);
            this.groupBox2.Controls.Add(this.rdBuenos);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(631, 45);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(288, 449);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Capital";
            // 
            // rdParis
            // 
            this.rdParis.AutoSize = true;
            this.rdParis.Location = new System.Drawing.Point(50, 409);
            this.rdParis.Name = "rdParis";
            this.rdParis.Size = new System.Drawing.Size(92, 33);
            this.rdParis.TabIndex = 9;
            this.rdParis.TabStop = true;
            this.rdParis.Text = "Paris";
            this.rdParis.UseVisualStyleBackColor = true;
            this.rdParis.CheckedChanged += new System.EventHandler(this.rdParis_CheckedChanged);
            // 
            // rdoBudapest
            // 
            this.rdoBudapest.AutoSize = true;
            this.rdoBudapest.Location = new System.Drawing.Point(50, 370);
            this.rdoBudapest.Name = "rdoBudapest";
            this.rdoBudapest.Size = new System.Drawing.Size(141, 33);
            this.rdoBudapest.TabIndex = 8;
            this.rdoBudapest.TabStop = true;
            this.rdoBudapest.Text = "Budapest";
            this.rdoBudapest.UseVisualStyleBackColor = true;
            this.rdoBudapest.CheckedChanged += new System.EventHandler(this.rdoBudapest_CheckedChanged);
            // 
            // rdAnkara
            // 
            this.rdAnkara.AutoSize = true;
            this.rdAnkara.Location = new System.Drawing.Point(50, 331);
            this.rdAnkara.Name = "rdAnkara";
            this.rdAnkara.Size = new System.Drawing.Size(114, 33);
            this.rdAnkara.TabIndex = 7;
            this.rdAnkara.TabStop = true;
            this.rdAnkara.Text = "Ankara";
            this.rdAnkara.UseVisualStyleBackColor = true;
            this.rdAnkara.CheckedChanged += new System.EventHandler(this.rdAnkara_CheckedChanged);
            // 
            // rdoLondon
            // 
            this.rdoLondon.AutoSize = true;
            this.rdoLondon.Location = new System.Drawing.Point(50, 292);
            this.rdoLondon.Name = "rdoLondon";
            this.rdoLondon.Size = new System.Drawing.Size(118, 33);
            this.rdoLondon.TabIndex = 6;
            this.rdoLondon.TabStop = true;
            this.rdoLondon.Text = "London";
            this.rdoLondon.UseVisualStyleBackColor = true;
            this.rdoLondon.CheckedChanged += new System.EventHandler(this.rdoLondon_CheckedChanged);
            // 
            // rdWashington
            // 
            this.rdWashington.AutoSize = true;
            this.rdWashington.Location = new System.Drawing.Point(50, 214);
            this.rdWashington.Name = "rdWashington";
            this.rdWashington.Size = new System.Drawing.Size(168, 33);
            this.rdWashington.TabIndex = 5;
            this.rdWashington.TabStop = true;
            this.rdWashington.Text = "Washington";
            this.rdWashington.UseVisualStyleBackColor = true;
            this.rdWashington.CheckedChanged += new System.EventHandler(this.rdWashington_CheckedChanged);
            // 
            // rdBrazil
            // 
            this.rdBrazil.AutoSize = true;
            this.rdBrazil.Location = new System.Drawing.Point(50, 97);
            this.rdBrazil.Name = "rdBrazil";
            this.rdBrazil.Size = new System.Drawing.Size(98, 33);
            this.rdBrazil.TabIndex = 4;
            this.rdBrazil.TabStop = true;
            this.rdBrazil.Text = "Brazil";
            this.rdBrazil.UseVisualStyleBackColor = true;
            this.rdBrazil.CheckedChanged += new System.EventHandler(this.rdBrazil_CheckedChanged);
            // 
            // rdTokyo
            // 
            this.rdTokyo.AutoSize = true;
            this.rdTokyo.Location = new System.Drawing.Point(50, 136);
            this.rdTokyo.Name = "rdTokyo";
            this.rdTokyo.Size = new System.Drawing.Size(103, 33);
            this.rdTokyo.TabIndex = 3;
            this.rdTokyo.TabStop = true;
            this.rdTokyo.Text = "Tokyo";
            this.rdTokyo.UseVisualStyleBackColor = true;
            this.rdTokyo.CheckedChanged += new System.EventHandler(this.rdTokyo_CheckedChanged);
            // 
            // rdMar
            // 
            this.rdMar.AutoSize = true;
            this.rdMar.Location = new System.Drawing.Point(50, 253);
            this.rdMar.Name = "rdMar";
            this.rdMar.Size = new System.Drawing.Size(111, 33);
            this.rdMar.TabIndex = 2;
            this.rdMar.TabStop = true;
            this.rdMar.Text = "Madrid";
            this.rdMar.UseVisualStyleBackColor = true;
            this.rdMar.CheckedChanged += new System.EventHandler(this.rdMar_CheckedChanged);
            // 
            // rdRome
            // 
            this.rdRome.AutoSize = true;
            this.rdRome.Location = new System.Drawing.Point(50, 175);
            this.rdRome.Name = "rdRome";
            this.rdRome.Size = new System.Drawing.Size(102, 33);
            this.rdRome.TabIndex = 1;
            this.rdRome.TabStop = true;
            this.rdRome.Text = "Rome";
            this.rdRome.UseVisualStyleBackColor = true;
            this.rdRome.CheckedChanged += new System.EventHandler(this.rdRome_CheckedChanged);
            // 
            // rdBuenos
            // 
            this.rdBuenos.AutoSize = true;
            this.rdBuenos.Location = new System.Drawing.Point(50, 58);
            this.rdBuenos.Name = "rdBuenos";
            this.rdBuenos.Size = new System.Drawing.Size(185, 33);
            this.rdBuenos.TabIndex = 0;
            this.rdBuenos.TabStop = true;
            this.rdBuenos.Text = "Buenos Aires";
            this.rdBuenos.UseVisualStyleBackColor = true;
            this.rdBuenos.CheckedChanged += new System.EventHandler(this.rdBuenos_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(117, 564);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(425, 26);
            this.label1.TabIndex = 11;
            this.label1.Text = "Chúc mừng bạn thủ đô của France là Paris";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(805, 564);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 44);
            this.button1.TabIndex = 12;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 664);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdUsa;
        private System.Windows.Forms.RadioButton rdBra;
        private System.Windows.Forms.RadioButton rdArrgentina;
        private System.Windows.Forms.RadioButton rdItaly;
        private System.Windows.Forms.RadioButton rdTurkey;
        private System.Windows.Forms.RadioButton rdJapan;
        private System.Windows.Forms.RadioButton rdHungary;
        private System.Windows.Forms.RadioButton rdTheUk;
        private System.Windows.Forms.RadioButton rdSpain;
        private System.Windows.Forms.RadioButton rdFance;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdParis;
        private System.Windows.Forms.RadioButton rdoBudapest;
        private System.Windows.Forms.RadioButton rdAnkara;
        private System.Windows.Forms.RadioButton rdoLondon;
        private System.Windows.Forms.RadioButton rdWashington;
        private System.Windows.Forms.RadioButton rdBrazil;
        private System.Windows.Forms.RadioButton rdTokyo;
        private System.Windows.Forms.RadioButton rdMar;
        private System.Windows.Forms.RadioButton rdRome;
        private System.Windows.Forms.RadioButton rdBuenos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}

