using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Entity
{
    public class SeriHaberlesmeAyarlari
    {
        public int ID { get; set; }

        public string PortName { get; set; }

        public int BaudRate { get; set; }

        public int DataBit { get; set; }

        public int Parity { get; set; }

        public int HandShake { get; set; }

        public int DepozitoUcreti { get; set; }

    }
}
