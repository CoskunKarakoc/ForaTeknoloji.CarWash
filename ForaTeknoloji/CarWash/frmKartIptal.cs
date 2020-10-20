using CarWash.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SQLite;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarWash
{
    public partial class frmKartIptal : Form
    {
        SerialPort serialPort;
        SeriHaberlesmeAyarlari seriHaberlesmeAyarlari;
        int kontorMiktari = 0;
        int depozitoUcreti = -2;
        int tempKontroMiktari = 0;
        private string Key = "FFFFFFFFFFFF";
        public frmKartIptal()
        {
            InitializeComponent();
            seriHaberlesmeAyarlari = GetSeriHaberlesmeAyarlari();
            depozitoUcreti = seriHaberlesmeAyarlari.DepozitoUcreti;
            if (ReadSettings("Apple").Length > 0)
            {
                Key = ReadSettings("Apple");
            }
        }



        private void frmKartIptal_Load(object sender, EventArgs e)
        {

            listBox1.Items.Clear();
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
                    serialPort.Write("%HR001011A" + Key + "**\r");
                    Thread.Sleep(200);
                    kontorMiktari = int.Parse(serialPort.ReadExisting().Substring(34, 2), System.Globalization.NumberStyles.HexNumber);
                    tempKontroMiktari = kontorMiktari;
                    txtKontorMiktari.Text = kontorMiktari.ToString();

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

        private void button1_Click(object sender, EventArgs e)
        {
            if (rdbKontorGeriVer.Checked == true)
            {
                try
                {
                    if (serialPort.IsOpen == false)
                    {
                        serialPort.Open();
                        serialPort.DiscardOutBuffer();
                        kontorMiktari = 0;
                        string kartPasif = "00";
                        var command = "%HW001011A" + Key + "0011223344556677" + kontorMiktari.ToString("X2") + kartPasif + "00112233445500**\r";
                        serialPort.Write(command);
                        Thread.Sleep(250);
                        var result = serialPort.ReadExisting();
                        if (result.Substring(6, 1) == "O")
                        {
                            listBox1.Items.Add("Kart İptali Gerçekleştirildi...");
                            serialPort.Write("%HR001011A" + Key + "**\r");
                            Thread.Sleep(200);
                            var receiveTemp = int.Parse(serialPort.ReadExisting().Substring(34, 2), System.Globalization.NumberStyles.HexNumber);
                            txtKontorMiktari.Clear();
                            if (rdbDepozitoAl.Checked == true)
                            {
                                DepozitoDusumu();
                                KontorDusumu(tempKontroMiktari);
                            }
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
            else if (rdbKontorGeriVerme.Checked == true)
            {
                try
                {
                    if (serialPort.IsOpen == false)
                    {
                        serialPort.Open();
                        serialPort.DiscardOutBuffer();
                        string kartPasif = "00";
                        var command = "%HW001011A" + Key + "0011223344556677" + kontorMiktari.ToString("X2") + kartPasif + "00112233445500**\r";
                        serialPort.Write(command);
                        Thread.Sleep(250);
                        var result = serialPort.ReadExisting();
                        if (result.Substring(6, 1) == "O")
                        {
                            listBox1.Items.Add("Kart İptali Gerçekleştirildi...");
                            serialPort.Write("%HR001011A" + Key + "**\r");
                            Thread.Sleep(200);
                            var receiveTemp = int.Parse(serialPort.ReadExisting().Substring(34, 2), System.Globalization.NumberStyles.HexNumber);
                            txtKontorMiktari.Clear();
                            if (rdbDepozitoAl.Checked == true)
                            {
                                DepozitoDusumu();
                            }
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
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

        public bool DepozitoDusumu()
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
                    command.Parameters.AddWithValue("@kasaMiktari", (0 - depozitoUcreti));
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

        public bool KontorDusumu(int kontorMiktari)
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
                    command.Parameters.AddWithValue("@kasaMiktari", (-kontorMiktari));
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


        public static string ReadSettings(string key)
        {
            var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var appSettings = (AppSettingsSection)configuration.GetSection("appSettings");
            return appSettings.Settings[key].Value;
        }

    }
}
