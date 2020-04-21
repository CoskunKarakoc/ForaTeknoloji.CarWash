namespace CarWash
{
    partial class frmKartIptal
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbKontorGeriVerme = new System.Windows.Forms.RadioButton();
            this.rdbKontorGeriVer = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtKontorMiktari = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbDepozitoAlma = new System.Windows.Forms.RadioButton();
            this.rdbDepozitoAl = new System.Windows.Forms.RadioButton();
            this.btnIptal = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(796, 116);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(151, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(535, 77);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kontör Geri Alım";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbKontorGeriVerme);
            this.groupBox1.Controls.Add(this.rdbKontorGeriVer);
            this.groupBox1.Location = new System.Drawing.Point(74, 337);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(264, 137);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // rdbKontorGeriVerme
            // 
            this.rdbKontorGeriVerme.AutoSize = true;
            this.rdbKontorGeriVerme.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rdbKontorGeriVerme.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.rdbKontorGeriVerme.Location = new System.Drawing.Point(28, 81);
            this.rdbKontorGeriVerme.Name = "rdbKontorGeriVerme";
            this.rdbKontorGeriVerme.Size = new System.Drawing.Size(229, 23);
            this.rdbKontorGeriVerme.TabIndex = 3;
            this.rdbKontorGeriVerme.TabStop = true;
            this.rdbKontorGeriVerme.Text = "Kontör Ücretini Geri Verme";
            this.rdbKontorGeriVerme.UseVisualStyleBackColor = true;
            // 
            // rdbKontorGeriVer
            // 
            this.rdbKontorGeriVer.AutoSize = true;
            this.rdbKontorGeriVer.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rdbKontorGeriVer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.rdbKontorGeriVer.Location = new System.Drawing.Point(28, 44);
            this.rdbKontorGeriVer.Name = "rdbKontorGeriVer";
            this.rdbKontorGeriVer.Size = new System.Drawing.Size(203, 23);
            this.rdbKontorGeriVer.TabIndex = 2;
            this.rdbKontorGeriVer.TabStop = true;
            this.rdbKontorGeriVer.Text = "Kontör Ücretini Geri Ver";
            this.rdbKontorGeriVer.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button1.Location = new System.Drawing.Point(390, 205);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(181, 126);
            this.button1.TabIndex = 4;
            this.button1.Text = "Tamam";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.listBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 23;
            this.listBox1.Location = new System.Drawing.Point(390, 351);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(381, 119);
            this.listBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textBox2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox2.ForeColor = System.Drawing.Color.White;
            this.textBox2.Location = new System.Drawing.Point(390, 155);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(381, 31);
            this.textBox2.TabIndex = 18;
            this.textBox2.Text = "Yüklü Kontör";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtKontorMiktari
            // 
            this.txtKontorMiktari.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtKontorMiktari.Location = new System.Drawing.Point(74, 155);
            this.txtKontorMiktari.Multiline = true;
            this.txtKontorMiktari.Name = "txtKontorMiktari";
            this.txtKontorMiktari.ReadOnly = true;
            this.txtKontorMiktari.Size = new System.Drawing.Size(257, 31);
            this.txtKontorMiktari.TabIndex = 19;
            this.txtKontorMiktari.Text = "0";
            this.txtKontorMiktari.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbDepozitoAlma);
            this.groupBox2.Controls.Add(this.rdbDepozitoAl);
            this.groupBox2.Location = new System.Drawing.Point(74, 205);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(257, 126);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            // 
            // rdbDepozitoAlma
            // 
            this.rdbDepozitoAlma.AutoSize = true;
            this.rdbDepozitoAlma.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rdbDepozitoAlma.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.rdbDepozitoAlma.Location = new System.Drawing.Point(28, 76);
            this.rdbDepozitoAlma.Name = "rdbDepozitoAlma";
            this.rdbDepozitoAlma.Size = new System.Drawing.Size(188, 23);
            this.rdbDepozitoAlma.TabIndex = 1;
            this.rdbDepozitoAlma.TabStop = true;
            this.rdbDepozitoAlma.Text = "Depozito Ücreti Alma";
            this.rdbDepozitoAlma.UseVisualStyleBackColor = true;
            // 
            // rdbDepozitoAl
            // 
            this.rdbDepozitoAl.AutoSize = true;
            this.rdbDepozitoAl.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rdbDepozitoAl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.rdbDepozitoAl.Location = new System.Drawing.Point(28, 38);
            this.rdbDepozitoAl.Name = "rdbDepozitoAl";
            this.rdbDepozitoAl.Size = new System.Drawing.Size(203, 23);
            this.rdbDepozitoAl.TabIndex = 0;
            this.rdbDepozitoAl.TabStop = true;
            this.rdbDepozitoAl.Text = "Depozito Ücreti Tahsil Et";
            this.rdbDepozitoAl.UseVisualStyleBackColor = true;
            // 
            // btnIptal
            // 
            this.btnIptal.BackColor = System.Drawing.Color.White;
            this.btnIptal.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnIptal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnIptal.Location = new System.Drawing.Point(590, 205);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(181, 126);
            this.btnIptal.TabIndex = 21;
            this.btnIptal.Text = "Kapat";
            this.btnIptal.UseVisualStyleBackColor = false;
            this.btnIptal.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmKartIptal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 494);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtKontorMiktari);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmKartIptal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmKartIptal";
            this.Load += new System.EventHandler(this.frmKartIptal_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtKontorMiktari;
        private System.Windows.Forms.RadioButton rdbKontorGeriVerme;
        private System.Windows.Forms.RadioButton rdbKontorGeriVer;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbDepozitoAlma;
        private System.Windows.Forms.RadioButton rdbDepozitoAl;
        private System.Windows.Forms.Button btnIptal;
    }
}