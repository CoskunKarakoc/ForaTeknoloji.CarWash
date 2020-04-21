using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Entity
{
    public class SerialCommunationEntity
    {
        private SerialPort _serialPorts;
        public SerialCommunationEntity(string comPort, int baudRate, int dataBits)
        {
            _serialPorts = new SerialPort();
            _serialPorts.PortName = comPort;
            _serialPorts.BaudRate = baudRate;
            _serialPorts.DataBits = dataBits;
            _serialPorts.WriteTimeout = 100;
            _serialPorts.ReadTimeout = 100;
            _serialPorts.Parity = Parity.Odd;
            _serialPorts.Handshake = Handshake.None;
            _serialPorts.StopBits = StopBits.One;
        }

        public SerialPort SerialPorts
        {
            get
            {
                return _serialPorts;
            }
            set
            {
                _serialPorts = value;
            }
        }



    }
}
