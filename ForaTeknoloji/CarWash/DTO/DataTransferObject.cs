using CarWash.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace CarWash
{
    public class DataTransferObject
    {
        public static string connectionAdress = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Environment.CurrentDirectory + "\\DB\\OtoYikama.accdb;Persist Security Info=False;";

        public static List<Kasa> GetListKasa()
        {
            object tLockObj = new object();
            OleDbCommand command = new OleDbCommand();
            OleDbDataReader reader;
            List<Kasa> KasaList = new List<Kasa>();
            string queryString = "";
            lock (tLockObj)
            {

                using (var connection = new OleDbConnection(connectionAdress))
                {
                    try
                    {
                        connection.Open();
                        queryString = "SELECT * FROM Kasa";
                        command.CommandText = queryString;
                        command.Connection = connection;
                        reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            var kasa = new Kasa
                            {
                                ID = reader["ID"] as int? ?? default(int),
                                KasaMiktari = reader["KasaMiktari"] as int? ?? default(int),
                                KontorBirimFiyati = reader["KontorBirimFiyati"] as int? ?? default(int),
                                Tarih = reader["Tarih"] as DateTime? ?? default(DateTime)
                            };
                            KasaList.Add(kasa);
                        }
                    }
                    catch (Exception)
                    {
                        return new List<Kasa>();
                    }
                    finally
                    {
                        connection.Close();
                        connection.Dispose();
                    }
                    return KasaList;
                }
            }
        }

        public static bool AddKasa(Kasa kasa)
        {
            object tLockObj = new object();
            OleDbCommand command = new OleDbCommand();
            string queryString = "";
            int rowsCount = 0;
            lock (tLockObj)
            {
                using (var conncection = new OleDbConnection(connectionAdress))
                {
                    try
                    {
                        conncection.Open();
                        queryString = "INSERT INTO Kasa(KasaMiktari,KontorBirimFiyati,Tarih) VALUES(" + kasa.KasaMiktari + "," + kasa.KontorBirimFiyati + ",'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                        command.CommandText = queryString;
                        command.Connection = conncection;
                        //command.Parameters.AddWithValue("@kasaMiktari", kasa.KasaMiktari);
                        //command.Parameters.AddWithValue("@kontorBirimFiyati", kasa.KontorBirimFiyati);
                        //command.Parameters.AddWithValue("@Tarih", kasa.Tarih);
                        rowsCount = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        string result = ex.Message;
                        rowsCount = 0;
                    }
                    finally
                    {
                        conncection.Close();
                        conncection.Dispose();
                    }
                    if (rowsCount > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public static bool DeleteKasa(int id)
        {
            object tLockObj = new object();
            OleDbCommand command = new OleDbCommand();
            string queryString = "";
            int rowsCount = 0;
            lock (tLockObj)
            {
                using (var connection = new OleDbConnection(connectionAdress))
                {
                    try
                    {
                        connection.Open();
                        queryString = "DELETE FROM Kasa WHERE ID=@id";
                        command.Connection = connection;
                        command.CommandText = queryString;
                        command.Parameters.AddWithValue("@id", id);
                        rowsCount = command.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        rowsCount = 0;
                    }
                    finally
                    {
                        connection.Close();
                        connection.Dispose();
                    }
                    if (rowsCount > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public static bool UpdateKasa(Kasa kasa)
        {
            object tLockObj = new object();
            OleDbCommand command = new OleDbCommand();
            string queryString = "";
            int rowsCount = 0;
            lock (tLockObj)
            {
                using (var connection = new OleDbConnection(connectionAdress))
                {
                    try
                    {
                        connection.Open();
                        queryString = "UPDATE Kasa SET(KasaMiktari=@kasaMiktari,KontorBirimFiyati=@kontorBirimFiyati,Tarih=@tarih) WHERE ID=@id";
                        command.Connection = connection;
                        command.CommandText = queryString;
                        command.Parameters.AddWithValue("@kasaMiktari", kasa.KasaMiktari);
                        command.Parameters.AddWithValue("@KontorBirimFiyati", kasa.KontorBirimFiyati);
                        command.Parameters.AddWithValue("@tarih", kasa.Tarih);
                        command.Parameters.AddWithValue("@id", kasa.ID);
                        rowsCount = command.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        rowsCount = 0;
                    }
                    finally
                    {
                        connection.Close();
                        connection.Dispose();
                    }
                    if (rowsCount > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
        }


        public static List<KasaHareketleri> GetListKasaHareketleri(string Tarih1, string Tarih2)
        {
            object tLockObj = new object();
            OleDbCommand command = new OleDbCommand();
            OleDbDataReader reader;
            List<KasaHareketleri> KasaList = new List<KasaHareketleri>();
            string queryString = "";
            lock (tLockObj)
            {

                using (var connection = new OleDbConnection(connectionAdress))
                {
                    try
                    {
                        connection.Open();
                        if (Tarih1 == null || Tarih1 == "")
                            queryString = "SELECT * FROM KasaHareketleri ORDER BY ID DESC";
                        else
                        {
                            var t1 = Tarih1;
                            var t2 = Tarih2;
                            queryString = "SELECT * FROM KasaHareketleri WHERE Tarih >= #" + t1 + "# AND Tarih <= #" + t2 + "#  ORDER BY ID DESC";

                        }
                        command.CommandText = queryString;
                        command.Connection = connection;
                        reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            var kasa = new KasaHareketleri
                            {
                                ID = reader["ID"] as int? ?? default(int),
                                Bakiye = reader["Bakiye"] as int? ?? default(int),
                                KartSeriNo = reader["KartSeriNo"].ToString(),
                                Tarih = reader["Tarih"] as DateTime? ?? default(DateTime),
                                YuklenenKontor = reader["YuklenenKontor"] as int? ?? default(int)
                            };
                            KasaList.Add(kasa);
                        }
                    }
                    catch (Exception ex)
                    {
                        string temp = ex.Message;
                        return null;
                    }
                    finally
                    {
                        connection.Close();
                        connection.Dispose();
                    }
                    return KasaList;
                }
            }
        }

        public static bool AddKasaHareketleri(KasaHareketleri kasaHareketleri)
        {
            object tLockObj = new object();
            OleDbCommand command = new OleDbCommand();
            string queryString = "";
            int rowsCount = 0;
            lock (tLockObj)
            {
                using (var conncection = new OleDbConnection(connectionAdress))
                {
                    try
                    {
                        conncection.Open();
                        queryString = "INSERT INTO KasaHareketleri(Bakiye,KartSeriNo,Tarih,YuklenenKontor) VALUES(@bakiye,@kartSeriNo,@Tarih,@yuklenenKontor)";
                        command.CommandText = queryString;
                        command.Connection = conncection;
                        command.Parameters.AddWithValue("@bakiye", kasaHareketleri.Bakiye);
                        command.Parameters.AddWithValue("@kartSeriNo", kasaHareketleri.KartSeriNo);
                        command.Parameters.AddWithValue("@Tarih", kasaHareketleri.Tarih.ToString("yyyy-MM-dd HH:mm:ss"));
                        command.Parameters.AddWithValue("@yuklenenKontor", kasaHareketleri.YuklenenKontor);
                        rowsCount = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        string result = ex.Message;
                        rowsCount = 0;
                    }
                    finally
                    {
                        conncection.Close();
                        conncection.Dispose();
                    }
                    if (rowsCount > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public static bool DeleteKasaHareketleri(int id)
        {
            object tLockObj = new object();
            OleDbCommand command = new OleDbCommand();
            string queryString = "";
            int rowsCount = 0;
            lock (tLockObj)
            {
                using (var connection = new OleDbConnection(connectionAdress))
                {
                    try
                    {
                        connection.Open();
                        queryString = "DELETE FROM KasaHareketleri WHERE ID=@id";
                        command.Connection = connection;
                        command.CommandText = queryString;
                        command.Parameters.AddWithValue("@id", id);
                        rowsCount = command.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        rowsCount = 0;
                    }
                    finally
                    {
                        connection.Close();
                        connection.Dispose();
                    }
                    if (rowsCount > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public static bool UpdateKasaHareketleri(KasaHareketleri kasaHareketleri)
        {
            object tLockObj = new object();
            OleDbCommand command = new OleDbCommand();
            string queryString = "";
            int rowsCount = 0;
            lock (tLockObj)
            {
                using (var connection = new OleDbConnection(connectionAdress))
                {
                    try
                    {
                        connection.Open();
                        queryString = "UPDATE KasaHareketleri SET(Bakiye=@bakiye,KartSeriNo=@kartSeriNo,Tarih=@tarih,YuklenenKontor=@yuklenenKontor) WHERE ID=@id";
                        command.Connection = connection;
                        command.CommandText = queryString;
                        command.Parameters.AddWithValue("@bakiye", kasaHareketleri.Bakiye);
                        command.Parameters.AddWithValue("@kartSeriNo", kasaHareketleri.KartSeriNo);
                        command.Parameters.AddWithValue("@yuklenenKontor", kasaHareketleri.YuklenenKontor);
                        command.Parameters.AddWithValue("@tarih", kasaHareketleri.Tarih);
                        command.Parameters.AddWithValue("@id", kasaHareketleri.ID);
                        rowsCount = command.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        rowsCount = 0;
                    }
                    finally
                    {
                        connection.Close();
                        connection.Dispose();
                    }
                    if (rowsCount > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
        }



        public static SeriHaberlesmeAyarlari GetSeriHaberlesmeAyari()
        {
            object tLockObj = new object();
            OleDbCommand command = new OleDbCommand();
            OleDbDataReader reader;
            string queryString = "";
            lock (tLockObj)
            {

                using (var connection = new OleDbConnection(connectionAdress))
                {
                    try
                    {
                        connection.Open();
                        queryString = "SELECT * FROM SeriHabelesmeAyarlari";
                        command.CommandText = queryString;
                        command.Connection = connection;
                        reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            var serihaberlesme = new SeriHaberlesmeAyarlari
                            {
                                BaudRate = reader["BaudRate"] as int? ?? default(int),
                                DataBit = reader["DataBit"] as int? ?? default(int),
                                Parity = reader["Parity"] as int? ?? default(int),
                                HandShake = reader["Handshake"] as int? ?? default(int),
                                PortName = reader["PortName"].ToString(),
                                DepozitoUcreti = reader["DepozitoUcreti"] as int? ?? default(int)
                            };
                            return serihaberlesme;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                    finally
                    {
                        connection.Close();
                        connection.Dispose();
                    }
                }
            }
        }

        public static bool AddSeriHaberlesmeAyarlari(SeriHaberlesmeAyarlari seriHaberlesmeAyarlari)
        {
            object tLockObj = new object();
            OleDbCommand command = new OleDbCommand();
            string queryString = "";
            int rowsCount = 0;
            lock (tLockObj)
            {
                using (var conncection = new OleDbConnection(connectionAdress))
                {
                    try
                    {
                        conncection.Open();
                        queryString = "INSERT INTO SeriHaberlesmeAyarlari(BaudRate,DataBit,Parity,Handshake,PortName) VALUES(@baudRate,@dataBit,@parity,@handshake,@portName)";
                        command.CommandText = queryString;
                        command.Connection = conncection;
                        command.Parameters.AddWithValue("@baudRate", seriHaberlesmeAyarlari.BaudRate);
                        command.Parameters.AddWithValue("@dataBit", seriHaberlesmeAyarlari.DataBit);
                        command.Parameters.AddWithValue("@parity", seriHaberlesmeAyarlari.Parity);
                        command.Parameters.AddWithValue("@handshake", seriHaberlesmeAyarlari.HandShake);
                        command.Parameters.AddWithValue("@portName", seriHaberlesmeAyarlari.PortName);
                        rowsCount = command.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        rowsCount = 0;
                    }
                    finally
                    {
                        conncection.Close();
                        conncection.Dispose();
                    }
                    if (rowsCount > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public static bool DeleteSeriHaberlesmeAyari(int id)
        {
            object tLockObj = new object();
            OleDbCommand command = new OleDbCommand();
            string queryString = "";
            int rowsCount = 0;
            lock (tLockObj)
            {
                using (var connection = new OleDbConnection(connectionAdress))
                {
                    try
                    {
                        connection.Open();
                        queryString = "DELETE FROM SeriHaberlesmeAyarlari WHERE ID=@id";
                        command.Connection = connection;
                        command.CommandText = queryString;
                        command.Parameters.AddWithValue("@id", id);
                        rowsCount = command.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        rowsCount = 0;
                    }
                    finally
                    {
                        connection.Close();
                        connection.Dispose();
                    }
                    if (rowsCount > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public static bool UpdateSeriHaberlesmeAyarlari(SeriHaberlesmeAyarlari seriHaberlesmeAyarlari)
        {
            object tLockObj = new object();
            OleDbCommand command = new OleDbCommand();
            string queryString = "";
            int rowsCount = 0;
            lock (tLockObj)
            {
                using (var connection = new OleDbConnection(connectionAdress))
                {
                    try
                    {
                        connection.Open();
                        queryString = "UPDATE SeriHaberlesmeAyarlari SET(BaudRate=@baudRate,DataBit=@dataBit,Parity=@parity,Handshake=@handshake,PortName=@portName) WHERE ID=@id";
                        command.Connection = connection;
                        command.CommandText = queryString;
                        command.Parameters.AddWithValue("@baudRate", seriHaberlesmeAyarlari.BaudRate);
                        command.Parameters.AddWithValue("@dataBit", seriHaberlesmeAyarlari.DataBit);
                        command.Parameters.AddWithValue("@parity", seriHaberlesmeAyarlari.Parity);
                        command.Parameters.AddWithValue("@handshake", seriHaberlesmeAyarlari.HandShake);
                        command.Parameters.AddWithValue("@portName", seriHaberlesmeAyarlari.PortName);
                        command.Parameters.AddWithValue("@id", seriHaberlesmeAyarlari.ID);
                        rowsCount = command.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        rowsCount = 0;
                    }
                    finally
                    {
                        connection.Close();
                        connection.Dispose();
                    }
                    if (rowsCount > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
        }



        public static PanelAyarlari GetPanelAyarlari()
        {
            object tLockObj = new object();
            OleDbCommand command = new OleDbCommand();
            OleDbDataReader reader;
            string queryString = "";
            lock (tLockObj)
            {

                using (var connection = new OleDbConnection(connectionAdress))
                {
                    try
                    {
                        connection.Open();
                        queryString = "SELECT * FROM PanelAyarlari";
                        command.CommandText = queryString;
                        command.Connection = connection;
                        reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            var panelAyarlari = new PanelAyarlari
                            {
                                CihazID = reader["CihazID"] as int? ?? default(int),
                                ID = reader["ID"] as int? ?? default(int),
                                IPAdresi = reader["IPAdresi"].ToString(),
                                KontorDusumMiktari = reader["KontorDusumMiktari"] as int? ?? default(int),
                                KopukSuresi = reader["KopukSuresi"] as int? ?? default(int),
                                PortNumarasi = reader["PortNumarasi"] as int? ?? default(int),
                                YikamaSuresi = reader["YikamaSuresi"] as int? ?? default(int)
                            };
                            return panelAyarlari;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                    finally
                    {
                        connection.Close();
                        connection.Dispose();
                    }
                }
            }
        }

        public static bool AddPanelAyarlari(PanelAyarlari panelAyarlari)
        {
            object tLockObj = new object();
            OleDbCommand command = new OleDbCommand();
            string queryString = "";
            int rowsCount = 0;
            lock (tLockObj)
            {
                using (var conncection = new OleDbConnection(connectionAdress))
                {
                    try
                    {
                        conncection.Open();
                        queryString = "INSERT INTO PanelAyarlari(CihazID,ID,KontorDusumMiktari,KopukSuresi,YikamaSuresi,PortNumarasi,IPAdresi) VALUES(@cihazID,@id,@kontorDusumMiktari,@kopukSuresi,@yikamaSuresi,@portNumarasi,@ipAdresi)";
                        command.CommandText = queryString;
                        command.Connection = conncection;
                        command.Parameters.AddWithValue("@cihazID", panelAyarlari.CihazID);
                        command.Parameters.AddWithValue("@id", panelAyarlari.ID);
                        command.Parameters.AddWithValue("@kontorDusumMiktari", panelAyarlari.KontorDusumMiktari);
                        command.Parameters.AddWithValue("@yikamaSuresi", panelAyarlari.YikamaSuresi);
                        command.Parameters.AddWithValue("@portNumarasi", panelAyarlari.PortNumarasi);
                        command.Parameters.AddWithValue("@ipAdresi", panelAyarlari.IPAdresi);
                        rowsCount = command.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        rowsCount = 0;
                    }
                    finally
                    {
                        conncection.Close();
                        conncection.Dispose();
                    }
                    if (rowsCount > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public static bool DeletePanelAyarlari(int id)
        {
            object tLockObj = new object();
            OleDbCommand command = new OleDbCommand();
            string queryString = "";
            int rowsCount = 0;
            lock (tLockObj)
            {
                using (var connection = new OleDbConnection(connectionAdress))
                {
                    try
                    {
                        connection.Open();
                        queryString = "DELETE FROM PanelAyarlari WHERE ID=@id";
                        command.Connection = connection;
                        command.CommandText = queryString;
                        command.Parameters.AddWithValue("@id", id);
                        rowsCount = command.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        rowsCount = 0;
                    }
                    finally
                    {
                        connection.Close();
                        connection.Dispose();
                    }
                    if (rowsCount > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public static bool UpdatePanelAyarlari(PanelAyarlari panelAyarlari)
        {
            object tLockObj = new object();
            OleDbCommand command = new OleDbCommand();
            string queryString = "";
            int rowsCount = 0;
            lock (tLockObj)
            {
                using (var connection = new OleDbConnection(connectionAdress))
                {
                    try
                    {
                        connection.Open();
                        queryString = "UPDATE PanelAyarlari SET(CihazID=@cihazID,ID=@id,IPAdresi=@ipAdresi,KontorDusumMiktari=@kontorDusumMiktari,KopukSuresi=@kopukSuresi,PortNumarasi=@portNumarasi,YikamaSuresi=@yikamaSuresi) WHERE ID=@id";
                        command.Connection = connection;
                        command.CommandText = queryString;
                        command.Parameters.AddWithValue("@cihazID", panelAyarlari.CihazID);
                        command.Parameters.AddWithValue("@id", panelAyarlari.ID);
                        command.Parameters.AddWithValue("@kontorDusumMiktari", panelAyarlari.KontorDusumMiktari);
                        command.Parameters.AddWithValue("@kopukSuresi", panelAyarlari.KopukSuresi);
                        command.Parameters.AddWithValue("@yikamaSuresi", panelAyarlari.YikamaSuresi);
                        command.Parameters.AddWithValue("@ipAdresi", panelAyarlari.IPAdresi);
                        command.Parameters.AddWithValue("@portNumarasi", panelAyarlari.PortNumarasi);

                        rowsCount = command.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        rowsCount = 0;
                    }
                    finally
                    {
                        connection.Close();
                        connection.Dispose();
                    }
                    if (rowsCount > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
        }



    }
}
