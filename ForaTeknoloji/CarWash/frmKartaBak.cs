using CarWash.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace CarWash
{
    public partial class frmKartaBak : Form
    {

        SerialPort serialPort;
        SeriHaberlesmeAyarlari seriHaberlesmeAyarlari;
        public frmKartaBak()
        {
            InitializeComponent();
            seriHaberlesmeAyarlari = GetSeriHaberlesmeAyarlari();
        }

        private void frmKartaBak_Load(object sender, EventArgs e)
        {
            serialPort = new SerialPort();
            serialPort.PortName = seriHaberlesmeAyarlari.PortName;
            serialPort.BaudRate = Convert.ToInt32(seriHaberlesmeAyarlari.BaudRate);
            serialPort.DataBits = Convert.ToInt32(seriHaberlesmeAyarlari.DataBit);
            serialPort.Handshake = (Handshake)Convert.ToInt32(seriHaberlesmeAyarlari.HandShake);
            serialPort.Parity = (Parity)Convert.ToInt32(seriHaberlesmeAyarlari.Parity);
            serialPort.WriteTimeout = 1000;
            serialPort.ReadTimeout = 1000;
            try
            {
                if (serialPort.IsOpen == false)
                {
                    serialPort.Open();
                    listBoxMessage.Items.Add("Kart Okuyucu Bağlantısı Sağlandı!");
                    serialPort.DiscardOutBuffer();
                    serialPort.Write("%HR001011A72A9B526F2CE**\r"); //FFFFFFFFFFFF Varsayılan değeri
                    Thread.Sleep(200);
                    var receive = serialPort.ReadExisting();
                    var receiveTemp = int.Parse(receive.Substring(34, 2), System.Globalization.NumberStyles.HexNumber);
                    txtYukluKontor.Text = receiveTemp.ToString();
                    txtToplamYukleme.Text = ToplamYukleme(receive.Substring(10, 8)).ToString();
                    if (ToplamYukleme(receive.Substring(10, 8)) >= 1000)
                    {
                        MessageBox.Show("Tebrikler 1000 Kontor Sınırını Aşarak Bizden Hediye Kazandınız!", "Hediye", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void button1_Click(object sender, EventArgs e)
        {
            frmKartIptal frmKartIptal = new frmKartIptal();
            frmKartIptal.Show();
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
                    int temp = 0;
                    strKomut = "SELECT YuklenenKontor FROM KasaHareketleri WHERE KartSeriNo='" + KartSeriNo + "'";
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

    }
}
