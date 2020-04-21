using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Entity
{
    public class PanelAyarlari
    {
        public int ID { get; set; }

        public int CihazID { get; set; }

        public string IPAdresi { get; set; }

        public int PortNumarasi { get; set; }

        public int KontorDusumMiktari { get; set; }

        public int KopukSuresi { get; set; }

        public int YikamaSuresi { get; set; }
    }
}
