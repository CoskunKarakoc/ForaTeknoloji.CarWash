namespace CarWash
{
    partial class frmKasaHareketleri
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKasaHareketleri));
            this.listViewKasaHareketleri = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.KartSeriNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Bakiye = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.YuklenenKontor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Tarih = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dateTimeKasaHareketleri = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listViewKasaHareketleri
            // 
            this.listViewKasaHareketleri.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.KartSeriNo,
            this.Bakiye,
            this.YuklenenKontor,
            this.Tarih});
            this.listViewKasaHareketleri.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listViewKasaHareketleri.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.listViewKasaHareketleri.Location = new System.Drawing.Point(0, 119);
            this.listViewKasaHareketleri.Name = "listViewKasaHareketleri";
            this.listViewKasaHareketleri.Size = new System.Drawing.Size(832, 438);
            this.listViewKasaHareketleri.TabIndex = 0;
            this.listViewKasaHareketleri.UseCompatibleStateImageBehavior = false;
            this.listViewKasaHareketleri.View = System.Windows.Forms.View.Details;
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 71;
            // 
            // KartSeriNo
            // 
            this.KartSeriNo.Text = "Kart Seri No";
            this.KartSeriNo.Width = 134;
            // 
            // Bakiye
            // 
            this.Bakiye.Text = "Bakiye";
            this.Bakiye.Width = 216;
            // 
            // YuklenenKontor
            // 
            this.YuklenenKontor.Text = "Yüklenen Kontor";
            this.YuklenenKontor.Width = 209;
            // 
            // Tarih
            // 
            this.Tarih.Text = "Tarih";
            this.Tarih.Width = 364;
            // 
            // dateTimeKasaHareketleri
            // 
            this.dateTimeKasaHareketleri.CalendarFont = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dateTimeKasaHareketleri.Location = new System.Drawing.Point(12, 68);
            this.dateTimeKasaHareketleri.Name = "dateTimeKasaHareketleri";
            this.dateTimeKasaHareketleri.Size = new System.Drawing.Size(383, 20);
            this.dateTimeKasaHareketleri.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Gold;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(417, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(184, 94);
            this.button2.TabIndex = 16;
            this.button2.Text = "Filtrele";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.SystemColors.HotTrack;
            this.textBox5.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox5.ForeColor = System.Drawing.Color.Gold;
            this.textBox5.Location = new System.Drawing.Point(12, 19);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(383, 31);
            this.textBox5.TabIndex = 17;
            this.textBox5.Text = "Tarihe Göre Filtrelere";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmKasaHareketleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 557);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dateTimeKasaHareketleri);
            this.Controls.Add(this.listViewKasaHareketleri);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmKasaHareketleri";
            this.Text = "frmKasaHareketleri";
            this.Load += new System.EventHandler(this.frmKasaHareketleri_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewKasaHareketleri;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader KartSeriNo;
        private System.Windows.Forms.ColumnHeader Bakiye;
        private System.Windows.Forms.ColumnHeader YuklenenKontor;
        private System.Windows.Forms.ColumnHeader Tarih;
        private System.Windows.Forms.DateTimePicker dateTimeKasaHareketleri;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox5;
    }
}