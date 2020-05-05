using CarWash.Entity;
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
    public partial class frmKasaHareketleri : Form
    {
        public frmKasaHareketleri()
        {
            InitializeComponent();
        }

        private void frmKasaHareketleri_Load(object sender, EventArgs e)
        {
            foreach (var kasaHareketleri in DataTransferObject.GetListKasaHareketleri(null, null))
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = kasaHareketleri.ID.ToString();
                listViewItem.SubItems.Add(kasaHareketleri.KartSeriNo.ToString());
                listViewItem.SubItems.Add(kasaHareketleri.Bakiye.ToString());
                listViewItem.SubItems.Add(kasaHareketleri.YuklenenKontor.ToString());
                listViewItem.SubItems.Add(kasaHareketleri.Tarih.ToString());
                listViewKasaHareketleri.Items.Add(listViewItem);
            }
        }

        public List<KasaHareketleri> KasaHareketListesi()
        {
            OleDbDataReader reader;
            OleDbCommand command = new OleDbCommand();
            List<KasaHareketleri> kasaHareketleri = new List<KasaHareketleri>();
            string strKomut = "";
            using (var connection = new OleDbConnection(DataTransferObject.connectionAdress))
            {
                try
                {
                    connection.Open();
                    strKomut = "SELECT * FROM KasaHareketleri";
                    command = new OleDbCommand(strKomut, connection);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var kasaHareket = new KasaHareketleri
                        {
                            ID = reader["ID"] as int? ?? default(int),
                            KartSeriNo = reader["KartSeriNo"].ToString(),
                            Bakiye = reader["Bakiye"] as int? ?? default(int),
                            YuklenenKontor = reader["YuklenenKontor"] as int? ?? default(int),
                            Tarih = reader["Tarih"] as DateTime? ?? default(DateTime)
                        };
                        kasaHareketleri.Add(kasaHareket);
                    }
                    return kasaHareketleri;

                }
                catch (Exception)
                {

                    return new List<KasaHareketleri>();
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listViewKasaHareketleri.Items.Clear();
            var tarih1 = dateTimeKasaHareketleriBaslangic.Value.ToString("dd-MM-yyyy");
            var tarih2 = dateTimeKasaHareketleriBitis.Value.ToString("dd-MM-yyyy");
            foreach (var kasaHareketleri in DataTransferObject.GetListKasaHareketleri(tarih1, tarih2))
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = kasaHareketleri.ID.ToString();
                listViewItem.SubItems.Add(kasaHareketleri.KartSeriNo.ToString());
                listViewItem.SubItems.Add(kasaHareketleri.Bakiye.ToString());
                listViewItem.SubItems.Add(kasaHareketleri.YuklenenKontor.ToString());
                listViewItem.SubItems.Add(kasaHareketleri.Tarih.ToString());
                listViewKasaHareketleri.Items.Add(listViewItem);
            }
        }
    }
}
