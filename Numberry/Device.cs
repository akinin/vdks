using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace Numberry
{
    class Device
    {
        [Description("Текущий статус устройства")] 
        [DisplayName("Статус")]
        public string Status { get; set; }
        [Description("IMEI GSM-модуля")] 
        [DisplayName("Серийный номер")]
        public int Serial { get; set; }
        [Description("Последовательынй порт, к которому подключено устройство")] 
        [DisplayName("COM-Порт")]
        public SerialPort Port { get; set; }
        
        private static Device _instance;

        static public Device GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Device();
            }
            return _instance;

        }

        private Device()
        {
            Status = "disconnected";
            Port = new SerialPort() {BaudRate = 115200, PortName = "COM1", DataBits = 8, Parity = Parity.None};
            Serial = 0;
        }
        
    }
}
