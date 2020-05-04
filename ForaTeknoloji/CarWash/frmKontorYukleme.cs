using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using CarWash.Entity;
using System.Data.OleDb;

namespace CarWash
{
    public partial class frmKontorYukleme : Form
    {
        private const int TL = 1;
        private int Ucret = 0;
        private int kontorMiktari = 0;
        private string serialReceive = "";
        private string kartSeriNo = "";
        SerialPort serialPort;
        SeriHaberlesmeAyarlari seriHaberlesmeAyarlari;
        public frmKontorYukleme()
        {
            InitializeComponent();
            seriHaberlesmeAyarlari = GetSeriHaberlesmeAyarlari();
        }

        private void frmKontorYukleme_Load(object sender, EventArgs e)
        {
           
            try
            {
                serialPort = new SerialPort();
                serialPort.PortName = seriHaberlesmeAyarlari.PortName;
                serialPort.BaudRate = Convert.ToInt32(seriHaberlesmeAyarlari.BaudRate);
                serialPort.DataBits = Convert.ToInt32(seriHaberlesmeAyarlari.DataBit);
                serialPort.Handshake = (Handshake)Convert.ToInt32(seriHaberlesmeAyarlari.HandShake);
                serialPort.Parity = (Parity)Convert.ToInt32(seriHaberlesmeAyarlari.Parity);
                serialPort.WriteTimeout = 1000;
                serialPort.ReadTimeout = 1000;
                if (serialPort.IsOpen == false)
                {
                    serialPort.Open();
                    serialPort.DiscardOutBuffer();
                    serialPort.Write("%HR001011A72A9B526F2CE**\r");
                    Thread.Sleep(200);
                    serialReceive = serialPort.ReadExisting();
                    kontorMiktari = int.Parse(serialReceive.Substring(34, 2), System.Globalization.NumberStyles.HexNumber);
                    txtYukluKontor.Text = kontorMiktari.ToString();
                    kartSeriNo = serialReceive.Substring(10, 8);
                    txtToplamYukleme.Text = ToplamYukleme(kartSeriNo).ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bilgisayar bağlantısını veya kartınızı kontrol ediniz.", "Bağlantı Yok", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                serialPort.Close();
                serialPort.Dispose();
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtKontorMiktari.Clear();
            txtKontorMiktari.Text = "3";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtKontorMiktari.Clear();
            txtKontorMiktari.Text = "6";

        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtKontorMiktari.Clear();
            txtKontorMiktari.Text = "9";

        }

        private void btn10_Click(object sender, EventArgs e)
        {
            txtKontorMiktari.Clear();
            txtKontorMiktari.Text = "10";

        }

        private void btn15_Click(object sender, EventArgs e)
        {
            txtKontorMiktari.Clear();
            txtKontorMiktari.Text = "15";


        }

        private void btn20_Click(object sender, EventArgs e)
        {
            txtKontorMiktari.Clear();
            txtKontorMiktari.Text = "20";

        }

        private void btn25_Click(object sender, EventArgs e)
        {
            txtKontorMiktari.Clear();
            txtKontorMiktari.Text = "25";

        }

        private void btnYukle_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort.IsOpen == false)
                {
                    serialPort.Open();
                    serialPort.DiscardOutBuffer();
                    int bakiye = 0;
                    int kontor = 0;
                    if (int.TryParse(txtYukluKontor.Text, out bakiye) == false)
                        bakiye = 0;
                    if (int.TryParse(txtKontorMiktari.Text, out kontor) == false)
                        kontor = 0;
                    bakiye += kontor;
                    var command = "%HW001011A72A9B526F2CE0011223344556677" + bakiye.ToString("X2") + "0100112233445500**\r";
                    serialPort.Write(command);
                    Thread.Sleep(250);
                    var result = serialPort.ReadExisting();
                    if (result.Substring(6, 1) == "O")
                    {
                        MessageBox.Show("Kontör Yükleme İşlemi Gerçekleştirildi", "Kontör Yükleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        serialPort.Write("%HR001011A72A9B526F2CE**\r");
                        Thread.Sleep(200);
                        var receiveTemp = int.Parse(serialPort.ReadExisting().Substring(34, 2), System.Globalization.NumberStyles.HexNumber);
                        txtYukluKontor.Text = receiveTemp.ToString();
                        txtKontorMiktari.Clear();
                        txtHedefKontor.Clear();
                        txtAlinacakOdeme.Clear();
                        if (!DataTransferObject.AddKasaHareketleri(new KasaHareketleri { Bakiye = (bakiye - kontor), KartSeriNo = kartSeriNo, YuklenenKontor = kontor, Tarih = DateTime.Now }))
                        {
                            MessageBox.Show("Veritabanına ekleme işleminde hata oluştu!");
                        }
                        else
                        {
                            txtToplamYukleme.Clear();
                            txtToplamYukleme.Text = ToplamYukleme(kartSeriNo).ToString();

                            if (!YuklenenKontoruKasayaEkleme(kontor) == true)
                            {
                                MessageBox.Show("Kasaya eklenemedi!");
                            }
                            if (ToplamYukleme(kartSeriNo) >= 1000)
                            {
                                MessageBox.Show("Tebrikler 1000 Kontor Sınırını Aşarak Bizden Hediye Kazandınız!", "Hediye", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bilgisayar bağlantısını veya kartınızı kontrol ediniz.", "Bağlantı Yok", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                serialPort.Close();
                serialPort.Dispose();
            }
        }

        private void txtKontorMiktari_TextChanged(object sender, EventArgs e)
        {
            txtHedefKontor.Text = txtKontorMiktari.Text;
            int.TryParse(txtKontorMiktari.Text, out Ucret);
            txtAlinacakOdeme.Text = String.Format("{0:C2}", (Ucret * TL));
        }

        public SeriHaberlesmeAyarlari GetSeriHaberlesmeAyarlari()
        {
            OleDbDataReader reader;
            OleDbCommand command;
            string strKomut = "";
            using (var connection = new OleDbConnection(DataTransferObject.connectionAdress))
            {
                try
                {
                    connection.Open();
                    strKomut = "SELECT TOP 1 * FROM SeriHaberlesmeAyarlari  ORDER BY ID ASC ";
                    command = new OleDbCommand(strKomut, connection);
                    reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        var entity = new SeriHaberlesmeAyarlari
                        {
                            PortName = reader["PortName"].ToString(),
                            BaudRate = reader["BaudRate"] as int? ?? default(int),
                            DataBit = reader["DataBit"] as int? ?? default(int),
                            Parity = reader["Parity"] as int? ?? default(int),
                            HandShake = reader["Handshake"] as int? ?? default(int)
                        };
                        return entity;
                    }
                    else
                    {
                        return new SeriHaberlesmeAyarlari();
                    }
                }
                catch (Exception)
                {
                    return new SeriHaberlesmeAyarlari();
                }
            }
        }

        public int ToplamYukleme(string KartSeriNo)
        {
            OleDbDataReader reader;
            OleDbCommand command;
            string strKomut = "";
            using (var connection = new OleDbConnection(DataTransferObject.connectionAdress))
            {
                try
                {
                    connection.Open();
                    strKomut = "SELECT YuklenenKontor FROM KasaHareketleri WHERE KartSeriNo='" + KartSeriNo + "'";
                    command = new OleDbCommand(strKomut, connection);
                    reader = command.ExecuteReader();
                    int temp = 0;
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

        public bool YuklenenKontoruKasayaEkleme(int yuklenenKontor)
        {
            OleDbCommand command = new OleDbCommand(); ;
            string strKomut = "";
            using (var connection = new OleDbConnection(DataTransferObject.connectionAdress))
            {
                try
                {
                    connection.Open();
                    strKomut = "INSERT INTO Kasa(KasaMiktari,Tarih) VALUES(@kasaMiktari,@tarih)";
                    command.Connection = connection;
                    command.CommandText = strKomut;
                    command.Parameters.AddWithValue("@kasaMiktari", yuklenenKontor);
                    command.Parameters.AddWithValue("@tarih", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
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
