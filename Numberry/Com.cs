using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using Telerik.WinControls;

namespace Numberry
{
    static public class Com
    {
        public static byte EchoCode = 0xAB;
        public static byte EchoReply = 0xBC;
        public static byte ReadCode = 0x1;
        public static byte WriteCode = 0x2;
        public static byte SerialCode = 0x3;
        public static byte ResetCode = 0x4;
        public static int SerialSize = 11;
        public static int NumberLength = 10;

        public static SerialPort Serial = new SerialPort() { BaudRate = 9600, ReadTimeout = 1000, DtrEnable = true };


        static public byte ReadMem(byte adress)
        {
            byte[] retValue = { 0 };
            try
            {
                Serial.Write(new byte[] { ReadCode, adress }, 0, 2);
                Serial.Read(retValue, 0, 1);

            }
            catch (Exception e)
            {
                RadMessageBox.Show(e.Message);
            }
            return retValue[0];
        }

        static public void WriteMem(byte adress, byte value)
        {
            try
            {
                Serial.Write(new byte[] { WriteCode, adress, value }, 0, 3);
            }
            catch (Exception e)
            {
                RadMessageBox.Show(e.Message);
            }

        }

        static public string ReadSerial()
        {
            try
            {
                Serial.Write(new byte[] { SerialCode }, 0, 1);
                byte[] buffer = new byte[SerialSize];
                Thread.Sleep(300);
                Serial.Read(buffer, 0, SerialSize);
                return BitConverter.ToString(buffer);
            }
            catch (Exception e)
            {
                RadMessageBox.Show(e.Message);
                return String.Empty;
            }
        }

        static public void ResetDevice()
        {
            try
            {
                Serial.Write(new byte[] { ResetCode }, 0, 1);
            }
            catch (Exception e)
            {
                RadMessageBox.Show(e.Message);
            }
        }

    }
}
