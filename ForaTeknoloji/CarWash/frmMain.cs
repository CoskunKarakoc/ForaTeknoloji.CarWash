using CarWash.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarWash
{
    public partial class frmMain : Form
    {
        private bool _dragging = false;
        private Point _offset;
        private Point _start_point = new Point(0, 0);
        public frmMain()
        {

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            panel2.BackColor = Color.FromArgb(1, 100, 173);
            sidePanel.BackColor = Color.FromArgb(1, 100, 173);
            sidePanel.Hide();
            this.Opacity = 0.90;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            frmKartaBak frmBakiye = new frmKartaBak();
            frmBakiye.TopLevel = false;
            frmBakiye.AutoScroll = true;
            panel4.Controls.Add(frmBakiye);
            frmBakiye.Show();
            sidePanel.Height = button1.Height;
            sidePanel.Top = button1.Top;
            sidePanel.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            frmYeniKart frmParaYukle = new frmYeniKart();
            frmParaYukle.TopLevel = false;
            frmParaYukle.AutoScroll = true;
            panel4.Controls.Add(frmParaYukle);
            frmParaYukle.Show();
            sidePanel.Height = button2.Height;
            sidePanel.Top = button2.Top;
            sidePanel.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            frmKasaKapatma frmKasaKapatma = new frmKasaKapatma();
            frmKasaKapatma.TopLevel = false;
            frmKasaKapatma.AutoScroll = true;
            panel4.Controls.Add(frmKasaKapatma);
            frmKasaKapatma.Show();
            sidePanel.Height = button3.Height;
            sidePanel.Top = button3.Top;
            sidePanel.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            frmKontorYukleme frmKontorYukleme = new frmKontorYukleme();
            frmKontorYukleme.TopLevel = false;
            frmKontorYukleme.AutoScroll = true;
            panel4.Controls.Add(frmKontorYukleme);
            frmKontorYukleme.Show();
            sidePanel.Height = button4.Height;
            sidePanel.Top = button4.Top;
            sidePanel.Show();

        }
        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.White;
            button1.BackColor = Color.Transparent;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.ForeColor = Color.White;
            button2.BackColor = Color.Transparent;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.ForeColor = Color.White;
            button3.BackColor = Color.Transparent;
        }

        private void button4_MouseMove(object sender, MouseEventArgs e)
        {
            button4.ForeColor = Color.FromArgb(1, 100, 173);
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.ForeColor = Color.White;
            button4.BackColor = Color.Transparent;
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.ForeColor = Color.FromArgb(1, 100, 173);
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            button2.ForeColor = Color.FromArgb(1, 100, 173);
        }

        private void button3_MouseMove(object sender, MouseEventArgs e)
        {
            button3.ForeColor = Color.FromArgb(1, 100, 173);
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;  // _dragging is your variable flag
            _start_point = new Point(e.X, e.Y);
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            frmAyar frmAyar = new frmAyar();
            frmAyar.TopLevel = false;
            frmAyar.AutoScroll = true;
            panel4.Controls.Add(frmAyar);
            frmAyar.Show();
            sidePanel.Hide();
        }

        private void btnKasaHareketleri_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            frmKasaHareketleri frmKasaHareketleri = new frmKasaHareketleri();
            frmKasaHareketleri.TopLevel = false;
            frmKasaHareketleri.AutoScroll = true;
            panel4.Controls.Add(frmKasaHareketleri);
            frmKasaHareketleri.Show();
            sidePanel.Height = btnKasaHareketleri.Height;
            sidePanel.Top = btnKasaHareketleri.Top;
            sidePanel.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            sidePanel.Hide();
            panel4.Controls.Add(pictureBox2);
        }

        private void btnKasaHareketleri_MouseMove(object sender, MouseEventArgs e)
        {
            btnKasaHareketleri.ForeColor = Color.FromArgb(1, 100, 173);
        }

        private void btnKasaHareketleri_MouseLeave(object sender, EventArgs e)
        {
            btnKasaHareketleri.ForeColor = Color.White;
            btnKasaHareketleri.BackColor = Color.Transparent;
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.ForeColor = Color.FromArgb(1, 100, 173);
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.White;
            label1.BackColor = Color.Transparent;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
