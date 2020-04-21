using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Entity
{
    public class KasaHareketleri
    {
        public int ID { get; set; }

        public string KartSeriNo { get; set; }

        public int Bakiye { get; set; }

        public int YuklenenKontor { get; set; }

        public DateTime Tarih { get; set; }
    }
}
