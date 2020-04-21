namespace CarWash
{
    partial class frmYeniKart
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
            this.txtDepozitoUcreti = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbDepozitoAlma = new System.Windows.Forms.RadioButton();
            this.rdbDepozitoAl = new System.Windows.Forms.RadioButton();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.btnTamam = new System.Windows.Forms.Button();
            this.listBoxMessage = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDepozitoUcreti
            // 
            this.txtDepozitoUcreti.Location = new System.Drawing.Point(152, 156);
            this.txtDepozitoUcreti.Multiline = true;
            this.txtDepozitoUcreti.Name = "txtDepozitoUcreti";
            this.txtDepozitoUcreti.ReadOnly = true;
            this.txtDepozitoUcreti.Size = new System.Drawing.Size(176, 31);
            this.txtDepozitoUcreti.TabIndex = 1;
            this.txtDepozitoUcreti.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbDepozitoAlma);
            this.groupBox1.Controls.Add(this.rdbDepozitoAl);
            this.groupBox1.Location = new System.Drawing.Point(152, 193);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 142);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // rdbDepozitoAlma
            // 
            this.rdbDepozitoAlma.AutoSize = true;
            this.rdbDepozitoAlma.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(100)))), ((int)(((byte)(173)))));
            this.rdbDepozitoAlma.Location = new System.Drawing.Point(7, 87);
            this.rdbDepozitoAlma.Name = "rdbDepozitoAlma";
            this.rdbDepozitoAlma.Size = new System.Drawing.Size(241, 33);
            this.rdbDepozitoAlma.TabIndex = 1;
            this.rdbDepozitoAlma.TabStop = true;
            this.rdbDepozitoAlma.Text = "Depozito Ücreti Alma";
            this.rdbDepozitoAlma.UseVisualStyleBackColor = true;
            // 
            // rdbDepozitoAl
            // 
            this.rdbDepozitoAl.AutoSize = true;
            this.rdbDepozitoAl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(100)))), ((int)(((byte)(173)))));
            this.rdbDepozitoAl.Location = new System.Drawing.Point(7, 37);
            this.rdbDepozitoAl.Name = "rdbDepozitoAl";
            this.rdbDepozitoAl.Size = new System.Drawing.Size(279, 33);
            this.rdbDepozitoAl.TabIndex = 0;
            this.rdbDepozitoAl.TabStop = true;
            this.rdbDepozitoAl.Text = "Depozito Ücreti Tahsil Et";
            this.rdbDepozitoAl.UseVisualStyleBackColor = true;
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.SystemColors.HotTrack;
            this.textBox5.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox5.ForeColor = System.Drawing.Color.Gold;
            this.textBox5.Location = new System.Drawing.Point(334, 156);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(383, 31);
            this.textBox5.TabIndex = 8;
            this.textBox5.Text = "Depozito Ücreti";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnTamam
            // 
            this.btnTamam.BackColor = System.Drawing.Color.Gold;
            this.btnTamam.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnTamam.FlatAppearance.BorderSize = 0;
            this.btnTamam.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTamam.Location = new System.Drawing.Point(509, 208);
            this.btnTamam.Name = "btnTamam";
            this.btnTamam.Size = new System.Drawing.Size(208, 127);
            this.btnTamam.TabIndex = 8;
            this.btnTamam.Text = "Tamam";
            this.btnTamam.UseVisualStyleBackColor = false;
            this.btnTamam.Click += new System.EventHandler(this.btnTamam_Click);
            // 
            // listBoxMessage
            // 
            this.listBoxMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listBoxMessage.FormattingEnabled = true;
            this.listBoxMessage.ItemHeight = 29;
            this.listBoxMessage.Location = new System.Drawing.Point(0, 466);
            this.listBoxMessage.Name = "listBoxMessage";
            this.listBoxMessage.Size = new System.Drawing.Size(832, 91);
            this.listBoxMessage.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(832, 42);
            this.panel2.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 15.75F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(100)))), ((int)(((byte)(173)))));
            this.label2.Location = new System.Drawing.Point(322, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 29);
            this.label2.TabIndex = 0;
            this.label2.Text = "Yeni Kart Tanımlama";
            // 
            // frmYeniKart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(832, 557);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.listBoxMessage);
            this.Controls.Add(this.btnTamam);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtDepozitoUcreti);
            this.Font = new System.Drawing.Font("Comic Sans MS", 15.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(7);
            this.Name = "frmYeniKart";
            this.Text = "frmParaYukle";
            this.Load += new System.EventHandler(this.frmYeniKart_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtDepozitoUcreti;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbDepozitoAlma;
        private System.Windows.Forms.RadioButton rdbDepozitoAl;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button btnTamam;
        private System.Windows.Forms.ListBox listBoxMessage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
    }
}