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
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Net.Sockets;
using System.Threading;

namespace CarWash
{
    public partial class frmAyar : Form
    {

        public SerialCommunationEntity serialCommunationEntity;
        public TcpClient tCPClient;
        string strKomut = "";
        string strKomut2 = "";
        int yikamaSuresi = 0;
        int yikamaKontorMik = 0;
        int kopukSuresi = 0;
        int kopukKontorMik = 0;

        Dictionary<int, string> parityData = new Dictionary<int, string>();

        public frmAyar()
        {
            InitializeComponent();

        }

        private void frmAyar_Load(object sender, EventArgs e)
        {
            var ports = SerialPort.GetPortNames();
            tCPClient = new TcpClient();
            tCPClient.ReceiveBufferSize = 65536;
            tCPClient.SendBufferSize = 65536;
            tCPClient.ReceiveTimeout = 3;
            tCPClient.SendTimeout = 3;
            cmbComPort.DataSource = ports;
            parityData.Add(0, "None");
            parityData.Add(1, "Odd");
            parityData.Add(2, "Even");
            parityData.Add(3, "Mark");
            parityData.Add(4, "Space");
            cmbParity.DataSource = new BindingSource(parityData, null);
            cmbParity.DisplayMember = "Value";
            cmbParity.ValueMember = "Key";
            DBSeriHaberlesmeBind();
        }



        public void DBSeriHaberlesmeBind()
        {
            string _portName = "";
            int _baudRate = 0;
            int _dataBit = 0;
            int _parity = 0;
            int _handshake = 0;
            int _depozitoUcreti = 0;
            using (var connection = new OleDbConnection(DataTransferObject.connectionAdress))
            {
                try
                {
                    connection.Open();

                    strKomut = "SELECT TOP 1 * FROM SeriHaberlesmeAyarlari  ORDER BY ID ASC";
                    var command = new OleDbCommand(strKomut, connection);
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        _portName = reader["PortName"].ToString();
                        _baudRate = reader["BaudRate"] as int? ?? default(int);
                        _dataBit = reader["DataBit"] as int? ?? default(int);
                        _parity = reader["Parity"] as int? ?? default(int);
                        _handshake = reader["HandShake"] as int? ?? default(int);
                        _depozitoUcreti = reader["DepozitoUcreti"] as int? ?? default(int);
                        int portIndex = cmbComPort.FindString(_portName);
                        cmbComPort.SelectedIndex = portIndex;

                        int baudIndex = cmbBaudRate.FindString(_baudRate.ToString());
                        cmbBaudRate.SelectedIndex = baudIndex;

                        int dataBitsIndex = cmbDataBit.FindString(_dataBit.ToString());
                        cmbDataBit.SelectedIndex = dataBitsIndex;

                        txtDepozitoUcreti.Text = _depozitoUcreti.ToString();

                        if (_parity.ToString() == "0")
                        {
                            int parityIndex = cmbParity.FindString("None");
                            cmbParity.SelectedIndex = parityIndex;
                        }
                        else if (_parity.ToString() == "1")
                        {
                            int parityIndex = cmbParity.FindString("Odd");
                            cmbParity.SelectedIndex = parityIndex;
                        }
                        else if (_parity.ToString() == "2")
                        {
                            int parityIndex = cmbParity.FindString("Even");
                            cmbParity.SelectedIndex = parityIndex;
                        }
                        else if (_parity.ToString() == "3")
                        {
                            int parityIndex = cmbParity.FindString("Mark");
                            cmbParity.SelectedIndex = parityIndex;
                        }
                        else if (_parity.ToString() == "4")
                        {
                            int parityIndex = cmbParity.FindString("Space");
                            cmbParity.SelectedIndex = parityIndex;
                        }


                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public void UpdateSeriHaberlesmeAyari()
        {
            strKomut2 = "UPDATE SeriHaberlesmeAyarlari SET PortName='" + cmbComPort.Text + "',BaudRate=" + Convert.ToInt32(cmbBaudRate.Text) + ",DataBit=" + Convert.ToInt32(cmbDataBit.Text) + ",Parity=" + ((KeyValuePair<int, string>)cmbParity.SelectedItem).Key + ",Handshake=" + 0 + "";
            using (var connection = new OleDbConnection(DataTransferObject.connectionAdress))
            {
                connection.Open();
                using (var command2 = new OleDbCommand(strKomut2, connection))
                {
                    int result = command2.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Ayarlar Kaydedildi!");
                        DBSeriHaberlesmeBind();
                    }
                }
            }

        }

        private void btnTCPBaglan_Click(object sender, EventArgs e)
        {

            try
            {

                if (tCPClient != null && tCPClient.Client != null)
                {
                    if (tCPClient.Connected == true)
                    {
                        btnTCPBaglan.BackColor = Color.Green;
                    }
                    else
                    {

                        var IPAdres = txtIP1.Text + "." + txtIP2.Text + "." + txtIP3.Text + "." + txtIP4.Text;
                        tCPClient.Connect(IPAdres, int.Parse(txtPort.Text));
                        if (tCPClient.Connected == true)
                        {
                            btnTCPBaglan.BackColor = Color.Green;
                        }
                    }
                }
                else
                {
                    tCPClient = new TcpClient();
                    tCPClient.ReceiveBufferSize = 65536;
                    tCPClient.SendBufferSize = 65536;
                    tCPClient.ReceiveTimeout = 3;
                    tCPClient.SendTimeout = 3;
                    if (tCPClient.Connected == true)
                    {
                        btnTCPBaglan.BackColor = Color.Green;
                    }
                    else
                    {

                        var IPAdres = txtIP1.Text + "." + txtIP2.Text + "." + txtIP3.Text + "." + txtIP4.Text;
                        tCPClient.Connect(IPAdres, int.Parse(txtPort.Text));
                        if (tCPClient.Connected == true)
                        {
                            btnTCPBaglan.BackColor = Color.Green;
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Cihaz ile bağlantı sağlanamadı!", "Bağlantı Yok", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            object tLockObj = new object();
            lock (tLockObj)
            {
                using (var connection = new OleDbConnection(DataTransferObject.connectionAdress))
                {
                    try
                    {
                        connection.OpenAsync();
                        strKomut = "SELECT * FROM SeriHaberlesmeAyarlari";
                        using (var command = new OleDbCommand(strKomut, connection))
                        {
                            var reader = command.ExecuteReader();
                            if (reader.Read())
                            {
                                strKomut2 = "UPDATE SeriHaberlesmeAyarlari SET PortName='" + cmbComPort.Text + "',BaudRate=" + Convert.ToInt32(cmbBaudRate.Text) + ",DataBit=" + Convert.ToInt32(cmbDataBit.Text) + ",Parity=" + ((KeyValuePair<int, string>)cmbParity.SelectedItem).Key + ",Handshake=" + 0 + ", DepozitoUcreti=" + Convert.ToInt32(txtDepozitoUcreti.Text);
                                using (var command2 = new OleDbCommand(strKomut2, connection))
                                {
                                    int result = command2.ExecuteNonQuery();
                                    if (result > 0)
                                    {
                                        MessageBox.Show("Ayarlar Kaydedildi!", "Seri Port Ayarları", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        DBSeriHaberlesmeBind();
                                    }
                                }
                            }
                            else
                            {
                                strKomut2 = "INSERT INTO SeriHaberlesmeAyarlari(PortName,BaudRate,DataBit,Parity,Handshake,DepozitoUcreti) VALUES('" + cmbComPort.SelectedValue.ToString() + "'," + Convert.ToInt32(cmbBaudRate.Text) + "," + Convert.ToInt32(cmbDataBit.Text) + "," + ((KeyValuePair<int, string>)cmbParity.SelectedItem).Key + "," + 0 + "," + Convert.ToInt32(txtDepozitoUcreti.Text) + ")";
                                using (var command2 = new OleDbCommand(strKomut2, connection))
                                {
                                    int result = command2.ExecuteNonQuery();
                                    if (result > 0)
                                    {
                                        MessageBox.Show("Ayarlar Kaydedildi!");
                                        DBSeriHaberlesmeBind();
                                    }
                                }
                            }
                        }

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("İşlem sırasında hata ile karşılaşıldı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void btnTCPKes_Click(object sender, EventArgs e)
        {
            tCPClient.Close();
            tCPClient.Dispose();
            btnTCPBaglan.BackColor = Color.Gold;
        }

        private void btnTCPAyarGonder_Click(object sender, EventArgs e)
        {
            SendCommand(tCPClient);
            Thread.Sleep(100);
            if (ReceiveCommand(tCPClient) == true)
            {
                MessageBox.Show("Ayarlar Gönderildi", "Panel Ayarları", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ayarlar Gönderilemedi", "Panel Ayarları", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        public void SendCommand(TcpClient TClient)
        {
            StringBuilder TSndStr = new StringBuilder();
            byte[] TSndBytes = new byte[1024];
            kopukSuresi = Convert.ToInt32(numericKopukSuresi.Value);
            kopukKontorMik = Convert.ToInt32(numericKopukKontor.Value);
            yikamaSuresi = Convert.ToInt32(numericYikamaSuresi.Value);
            yikamaKontorMik = Convert.ToInt32(numericYikamaKontor.Value);
            TSndStr.Append("%QW");
            TSndStr.Append("001");
            TSndStr.Append(yikamaKontorMik.ToString("D3"));
            TSndStr.Append(yikamaSuresi.ToString("D3"));
            TSndStr.Append(kopukKontorMik.ToString("D3"));
            TSndStr.Append(kopukSuresi.ToString("D3"));
            TSndStr.Append("001");
            TSndStr.Append("001");
            TSndStr.Append("**\r");
            try
            {

                var netStream = TClient.GetStream();
                if (netStream.CanWrite)
                {
                    TSndBytes = Encoding.ASCII.GetBytes(TSndStr.ToString());
                    netStream.Write(TSndBytes, 0, TSndBytes.Length);
                }
                else
                {
                    MessageBox.Show("Ayarlar gönderilirken bir hata oluştu!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ayarlar gönderilirken bir hata oluştu!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public bool ReceiveCommand(TcpClient TClient)
        {
            ushort TSize = 1024;
            byte[] RcvBuffer = new byte[TSize];
            string TRcvData = null;

            try
            {
                if (TClient.Available > 0)
                {
                    TClient.GetStream().Read(RcvBuffer, 0, RcvBuffer.Length);
                    TRcvData = Encoding.ASCII.GetString(RcvBuffer);
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

        private void button2_Click(object sender, EventArgs e)
        {
            SendCommandReadSettings(tCPClient);
            Thread.Sleep(100);
            ReceiveCommandReadSettings(tCPClient);
        }

        public void SendCommandReadSettings(TcpClient TClient)
        {
            StringBuilder TSndStr = new StringBuilder();
            byte[] TSndBytes = new byte[1024];
            kopukSuresi = Convert.ToInt32(numericKopukSuresi.Value);
            kopukKontorMik = Convert.ToInt32(numericKopukKontor.Value);
            yikamaSuresi = Convert.ToInt32(numericYikamaSuresi.Value);
            yikamaKontorMik = Convert.ToInt32(numericYikamaKontor.Value);
            TSndStr.Append("%QR");
            TSndStr.Append("001");
            TSndStr.Append("**\r");
            try
            {

                var netStream = TClient.GetStream();
                if (netStream.CanWrite)
                {
                    TSndBytes = Encoding.ASCII.GetBytes(TSndStr.ToString());
                    netStream.Write(TSndBytes, 0, TSndBytes.Length);
                }
                else
                {
                    MessageBox.Show("Ayarlar gönderilirken bir hata oluştu!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ayarlar gönderilirken bir hata oluştu!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void ReceiveCommandReadSettings(TcpClient TClient)
        {
            ushort TSize = 1024;
            byte[] RcvBuffer = new byte[TSize];
            string TRcvData = null;
            int kopukSuresi = 0;
            int kopukKartMik = 0;
            int yikamaSuresi = 0;
            int yikamaKartMik = 0;
            try
            {
                if (TClient.Available > 0)
                {
                    TClient.GetStream().Read(RcvBuffer, 0, RcvBuffer.Length);
                    TRcvData = Encoding.ASCII.GetString(RcvBuffer);
                    int.TryParse(TRcvData.Substring(6, 3), out yikamaKartMik);
                    int.TryParse(TRcvData.Substring(9, 3), out yikamaSuresi);
                    int.TryParse(TRcvData.Substring(12, 3), out kopukKartMik);
                    int.TryParse(TRcvData.Substring(15, 3), out kopukSuresi);
                    numericKopukKontor.Value = kopukKartMik;
                    numericKopukSuresi.Value = kopukSuresi;
                    numericYikamaKontor.Value = yikamaKartMik;
                    numericYikamaSuresi.Value = yikamaSuresi;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Ayarlar Okunamadı", "Bağlantı Yok", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmAyar_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
