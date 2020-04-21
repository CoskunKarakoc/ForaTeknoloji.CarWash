using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarWash
{
    public partial class frmKasaKapatma : Form
    {
        public frmKasaKapatma()
        {
            InitializeComponent();
        }

        private void frmKasaKapatma_Load(object sender, EventArgs e)
        {
            txtKasaKaydi.Text = Kasa().ToString();
            txtGercekTutar.Text = Kasa().ToString();
            txtFazlaAcik.Text = "0";
            txtKasadaKalanTutar.Text = Kasa().ToString();

        }



        public int Kasa()
        {
            OleDbDataReader reader;
            OleDbCommand command;
            string strKomut = "";
            using (var connection = new OleDbConnection(DataTransferObject.connectionAdress))
            {
                try
                {
                    connection.Open();
                    int temp = 0;
                    strKomut = "SELECT KasaMiktari FROM Kasa";
                    command = new OleDbCommand(strKomut, connection);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        temp += reader[0] as int? ?? default(int);
                    }

                    return temp;
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rdbKasaKapat.Checked == true)
            {
                if (KasaKapat() == true)
                {
                    MessageBox.Show("Kasa sıfırlandı!", "Kasa Kapatma", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                txtKasadaKalanTutar.Text = Kasa().ToString();
                txtKasaKaydi.Text = Kasa().ToString();
                txtGercekTutar.Text = Kasa().ToString();
            }
            else
            {
                KasaDuzenle();
                txtKasadaKalanTutar.Text = Kasa().ToString();
                txtKasaKaydi.Text = Kasa().ToString();
                txtGercekTutar.Text = Kasa().ToString();
            }
        }



        private void txtGercekTutar_TextChanged(object sender, EventArgs e)
        {
            int gercekTutar = 0;
            int.TryParse(txtGercekTutar.Text, out gercekTutar);
            int result = Kasa() - gercekTutar;
            if (result >= 0)
            {
                txtFazlaAcik.Text = String.Format("{0:C2}", (result)) + " Fazla(+)";
            }
            else
            {
                txtFazlaAcik.Text = String.Format("{0:C2}", (result)) + " Açık(-)";
            }


        }

        public bool KasaDuzenle()
        {
            OleDbDataReader reader;
            OleDbCommand command = new OleDbCommand();
            OleDbCommand command2 = new OleDbCommand();
            string strKomut = "";
            string strKomut2 = "";
            using (var connection = new OleDbConnection(DataTransferObject.connectionAdress))
            {
                try
                {
                    connection.Open();
                    strKomut = "DELETE FROM Kasa";
                    command = new OleDbCommand(strKomut, connection);
                    int rowsCount = command.ExecuteNonQuery();
                    strKomut2 = "INSERT INTO Kasa(KasaMiktari,Tarih) VALUES(@kasaMiktari,@tarih)";
                    command2.Connection = connection;
                    command2.CommandText = strKomut2;
                    command2.Parameters.AddWithValue("@kasaMiktari", int.Parse(txtGercekTutar.Text));
                    command2.Parameters.AddWithValue("@tarih", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    int rowsCount2 = command2.ExecuteNonQuery();
                    if (rowsCount2 > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
            }


        }


        public bool KasaKapat()
        {
            OleDbDataReader reader;
            OleDbCommand command = new OleDbCommand();
            OleDbCommand command2 = new OleDbCommand();
            string strKomut = "";
            string strKomut2 = "";
            using (var connection = new OleDbConnection(DataTransferObject.connectionAdress))
            {
                try
                {
                    connection.Open();
                    strKomut = "DELETE FROM Kasa";
                    command = new OleDbCommand(strKomut, connection);
                    int rowsCount = command.ExecuteNonQuery();
                    if (rowsCount > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }



    }
}
