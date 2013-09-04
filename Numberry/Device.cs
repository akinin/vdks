using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO.Ports;
using System.Linq;
using System.Text;
using Telerik.WinControls;

namespace Numberry
{
    class Device
    {
        private const byte WriteCommand = 0x2;
        private const byte ReadCommand = 0x1;
        private const byte SerialCommand = 0x3;
        private const byte ServiceModCommand = 0x4;
        private const byte RebootCommand = 0x5;
        [Description("Текущий статус устройства")]
        [DisplayName("Статус")]
        public string Status
        {
            get
            {
                if (Port.IsOpen) return "connected";
                return "disconnected";
            }
        }
        [Description("IMEI GSM-модуля")] 
        [DisplayName("Серийный номер")]
        public string Serial { get; set; }
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

        public byte ReadMem(byte adress)
        {
            byte[] retValue = {0};
            try
            {
                Port.Write(new byte[]{ReadCommand,adress},0,2);
                Port.Read(retValue, 0, 1);
                
            }
            catch (Exception e)
            {
                RadMessageBox.Show(e.Message);
            }
            return retValue[0];
        }

        public void WriteMem(byte adress, byte value)
             {
            try
            {
                Port.Write(new byte[] {WriteCommand, adress, value}, 0, 2);
            }
            catch (Exception e)
            {
                RadMessageBox.Show(e.Message);
            }
        
            }
        public void InitServiceMode()
        {
            try
            {
                Port.Write(new byte[] {ServiceModCommand}, 0, 1);
            }
            catch (Exception e)
            {
                RadMessageBox.Show(e.Message);
            }
        }
        public void ReadSerial()
        {
            string serial = String.Empty;
            try
            {
                Port.Write(new byte[] {SerialCommand}, 0, 1);
                serial = Port.ReadLine();
            }
            catch (Exception e)
            {
                RadMessageBox.Show(e.Message);
            }
            Serial = serial;
        }
        private Device()
        {
            Port = new SerialPort() {BaudRate = 115200, DataBits = 8, Parity = Parity.None, ReadTimeout = 1000};
            Serial = "";
        }
        
    }
}
