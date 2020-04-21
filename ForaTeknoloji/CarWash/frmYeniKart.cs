using CarWash.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarWash
{
    public partial class frmYeniKart : Form
    {
        SerialPort serialPort;
        SeriHaberlesmeAyarlari seriHaberlesmeAyarlari;
        string kartSeriNo;
        int depozitoUcreti = 1;
        public frmYeniKart()
        {
            InitializeComponent();
            seriHaberlesmeAyarlari = GetSeriHaberlesmeAyarlari();

            depozitoUcreti = seriHaberlesmeAyarlari.DepozitoUcreti;
        }

        private void frmYeniKart_Load(object sender, EventArgs e)
        {
            txtDepozitoUcreti.Text = seriHaberlesmeAyarlari.DepozitoUcreti.ToString();
            serialPort = new SerialPort();
            serialPort.PortName = seriHaberlesmeAyarlari.PortName;
            serialPort.BaudRate = Convert.ToInt32(seriHaberlesmeAyarlari.BaudRate);
            serialPort.DataBits = Convert.ToInt32(seriHaberlesmeAyarlari.DataBit);
            serialPort.Handshake = (Handshake)Convert.ToInt32(seriHaberlesmeAyarlari.HandShake);
            serialPort.Parity = (Parity)Convert.ToInt32(seriHaberlesmeAyarlari.Parity);
            serialPort.WriteTimeout = 1000;
            serialPort.ReadTimeout = 1000;
            depozitoUcreti = int.Parse(txtDepozitoUcreti.Text);
            try
            {
                if (serialPort.IsOpen == false)
                {
                    serialPort.Open();
                    serialPort.DiscardOutBuffer();
                    serialPort.Write("%HR001011A72A9B526F2CE**\r");
                    Thread.Sleep(200);
                    var receive = serialPort.ReadExisting();
                    kartSeriNo = receive.Substring(10, 8);
                    var receiveTemp = int.Parse(receive.Substring(34, 2), System.Globalization.NumberStyles.HexNumber);
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

        private void btnTamam_Click(object sender, EventArgs e)
        {
            if (rdbDepozitoAl.Checked == true)
            {
                try
                {
                    if (serialPort.IsOpen == false)
                    {
                        serialPort.Open();
                        serialPort.DiscardOutBuffer();
                        var kontorMiktari = 0;
                        string kartAktif = "01";
                        var command = "%HW001011A72A9B526F2CE0011223344556677" + kontorMiktari.ToString("X2") + kartAktif + "00112233445500**\r";
                        serialPort.Write(command);
                        Thread.Sleep(250);
                        var result = serialPort.ReadExisting();
                        if (result.Substring(6, 1) == "O")
                        {
                            serialPort.Write("%HR001011A72A9B526F2CE**\r");
                            Thread.Sleep(200);
                            var receiveTemp = int.Parse(serialPort.ReadExisting().Substring(34, 2), System.Globalization.NumberStyles.HexNumber);
                            DepozitoEkle();
                            ClearKartHareketleri(kartSeriNo);
                            MessageBox.Show("Kart Başarılı Şekilde Oluşturuldu!");
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Bilgisayar bağlantınızı veya kartınızı kontrol ediniz.", "Bağlantı Yok", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    serialPort.Close();
                    serialPort.Dispose();
                }
            }
            else
            {
                try
                {
                    if (serialPort.IsOpen == false)
                    {
                        serialPort.Open();
                        serialPort.DiscardOutBuffer();
                        var kontorMiktari = 0;
                        string kartAktif = "01";
                        var command = "%HW001011A72A9B526F2CE0011223344556677" + kontorMiktari.ToString("X2") + kartAktif + "00112233445500**\r";
                        serialPort.Write(command);
                        Thread.Sleep(250);
                        var result = serialPort.ReadExisting();
                        if (result.Substring(6, 1) == "O")
                        {
                            serialPort.Write("%HR001011A72A9B526F2CE**\r");
                            Thread.Sleep(200);
                            var receiveTemp = int.Parse(serialPort.ReadExisting().Substring(34, 2), System.Globalization.NumberStyles.HexNumber);
                            ClearKartHareketleri(kartSeriNo);
                            MessageBox.Show("Kart Başarılı Şekilde Oluşturuldu!");
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Bilgisayar bağlantınızı veya kartınızı kontrol ediniz.", "Bağlantı Yok", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    serialPort.Close();
                    serialPort.Dispose();
                }
            }
        }
        public bool DepozitoEkle()
        {
            OleDbCommand command = new OleDbCommand();
            string strKomut = "";
            using (var connection = new OleDbConnection(DataTransferObject.connectionAdress))
            {
                try
                {
                    connection.Open();
                    strKomut = "INSERT INTO Kasa(KasaMiktari,Tarih) VALUES(@kasaMiktari,@tarih)";
                    command.Connection = connection;
                    command.CommandText = strKomut;
                    command.Parameters.AddWithValue("@kasaMiktari", depozitoUcreti);
                    command.Parameters.AddWithValue("@tarih", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    int rowCount = command.ExecuteNonQuery();
                    if (rowCount > 0)
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

        public bool ClearKartHareketleri(string kartSeriNo)
        {
            OleDbCommand command;
            string strKomut = "";
            using (var connection = new OleDbConnection(DataTransferObject.connectionAdress))
            {
                try
                {
                    connection.Open();
                    strKomut = "DELETE FROM KasaHareketleri WHERE KartSeriNo='" + kartSeriNo + "'";
                    command = new OleDbCommand(strKomut, connection);
                    int rowsCount = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    string temp = ex.Message;
                    return false;
                }
                return true;
            }
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
                            HandShake = reader["Handshake"] as int? ?? default(int),
                            DepozitoUcreti = reader["DepozitoUcreti"] as int? ?? default(int)
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
    }
}
