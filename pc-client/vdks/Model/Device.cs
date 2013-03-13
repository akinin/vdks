using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace vdks.Model
{
    class Device
    {
        public uint Serial{get;set;}
        public SerialPort COM{get;set;}
        public Device()
        {
            COM = new SerialPort() { BaudRate = 9600, PortName = "noDevice", DataBits = 8, WriteTimeout = 1000, ReadTimeout = 1000 };
            Serial = 0;
        }
        public void Connect()
        {
            var availablePorts = System.IO.Ports.SerialPort.GetPortNames();
            for (int i = 0; i < availablePorts.Length; i++)
            {
                COM.PortName = availablePorts[i];
                COM.Open();
                COM.Write(Messages.Handshake, 0, 1);
                             
                byte answer = 0;
                try
                {
                    answer = (byte)COM.ReadByte();
                }
                catch (TimeoutException)
                {
                    
                }
                finally
                {
                    COM.Close();
                }

                if (answer == Messages.Handshake[1])
                {
                    var serial = new byte[2];
                    COM.Open();
                    COM.Write(Messages.ReadCommand(Messages.SerialOffset), 0, Messages.ReadCommand(Messages.SerialOffset).Length);
                    serial[0] = (byte)COM.ReadByte();
                    COM.Write(Messages.ReadCommand((byte)(Messages.SerialOffset + 1)), 0, Messages.ReadCommand(Messages.SerialOffset).Length);
                    serial[1] = (byte)COM.ReadByte();
                    COM.Close();
                    Serial = BitConverter.ToUInt16(serial,0);

                    break;

                }
                else
                {
                    COM.PortName = "noDevice";
                }
            }

        }
        public byte ReadByte(byte offset)
        {
            if(COM.PortName != "noDevice")
            {
                COM.Open();
                COM.Write(Messages.ReadCommand(offset), 0, Messages.ReadCommand(offset).Length);
                
                try
                {
                    return (byte)COM.ReadByte();
                }
                catch (TimeoutException ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                    return 0;
                }
                finally
                {
                    COM.Close();
                    
                }
                
            }
            return 0;
        }
        public bool WriteByte(byte offset, byte valueToWrite )
        {
            if (COM.PortName != "noDevice")
            {
                COM.Open();
                COM.Write(Messages.WriteCommand(offset, valueToWrite), 0, Messages.WriteCommand(offset, valueToWrite).Length);

                try
                {
                    if ((byte)COM.ReadByte() == 0) return true;
                    else return false;
                }
                catch (TimeoutException ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                    return false;
                }
                finally
                {
                    COM.Close();

                }

            }
            return false;
        }
    }
}
