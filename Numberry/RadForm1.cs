using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export.ExcelML;

namespace Numberry
{
    public partial class RadForm1 : Telerik.WinControls.UI.RadForm
    {
        private ManualResetEventSlim dataRecievedEvent;
        public RadForm1()
        {
            InitializeComponent();
            filterList.ItemSize = new Size(0, 40);
            alertList.ItemSize = new Size(0, 40);
            dataRecievedEvent = new ManualResetEventSlim(false);
        }

        private void List_VisualItemCreating(object sender, Telerik.WinControls.UI.ListViewVisualItemCreatingEventArgs e)
        {
           e.VisualItem = new NumberItem();
        }

        private void buttonFilterAdd_Click(object sender, EventArgs e)
        {
            this.filterList.Items.Add("");
        }

        private void buttonFilterClear_Click(object sender, EventArgs e)
        {
           
            DialogResult choice = RadMessageBox.Show("Удалить все номера из списка?", "", MessageBoxButtons.YesNo,
                RadMessageIcon.Question);
            if (choice == DialogResult.Yes)
            {
                this.filterList.Items.Clear();
            }
        }

        private void buttonAlertAdd_Click(object sender, EventArgs e)
        {
            this.alertList.Items.Add("");
        }

        private void buttonAlertClear_Click(object sender, EventArgs e)
        {
            DialogResult choice = RadMessageBox.Show("Удалить все номера из списка?", "", MessageBoxButtons.YesNo,
              RadMessageIcon.Question);
            if (choice == DialogResult.Yes)
            {
                this.alertList.Items.Clear();
            }
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if(Com.Serial.IsOpen) Com.Serial.Close();
             SetButtonsEnabled(false);
             string[] _portlist;
             bool _deviceFound = false;
             _portlist = System.IO.Ports.SerialPort.GetPortNames();
             foreach (string s in _portlist)
             {
                 try
                 {
                     Com.Serial.PortName = s;
                     Com.Serial.DataReceived += Serial_DataReceived;
                     Com.Serial.Open();
                     dataRecievedEvent.Wait(3000);
                     if (!dataRecievedEvent.IsSet) throw new Exception("no answer");
                     if (Com.Serial.ReadByte() != Com.EchoCode) throw new Exception("unsupported device"); ;
                     Com.Serial.Write(new byte[]{Com.EchoReply},0,1);
                     _deviceFound = true;
                     dataRecievedEvent.Reset();
                     Com.Serial.DataReceived -= Serial_DataReceived;
                 }
                 catch (Exception)
                 {
                     Com.Serial.Close();
                 }
                 
             }
             if (_deviceFound)
             {

                 try
                 {
                     SetButtonsEnabled(true);
                     LoadNumbers();
                     MessageBox.Show(Com.ReadSerial());
                 }
                 catch (Exception exception)
                 {
                     RadMessageBox.Show(exception.Message, "", MessageBoxButtons.OK, RadMessageIcon.Error); ;
                 }
             }
             else
             {
                 RadMessageBox.Show("Устройство не обнаружено", " ", MessageBoxButtons.OK, RadMessageIcon.Exclamation);
             }

        }

        void Serial_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            dataRecievedEvent.Set();
        }

        private void SetButtonsEnabled(bool state)
        {
            buttonDisconnect.Enabled = state;
            buttonWrite.Enabled = state;
            buttonFilterAdd.Enabled = state;
            buttonFilterClear.Enabled = state;
            buttonAlertAdd.Enabled = state;
            buttonAlertClear.Enabled = state;
        }
        
        private void LoadNumbers()
        {
            try
            {
                byte memOffset = 0;
                int filterNumbersCount = Com.ReadMem(memOffset++);
                int alertNumbersCount = Com.ReadMem(memOffset++);
                
                filterList.Items.Clear();
                alertList.Items.Clear();
                for (int i = 0; i < filterNumbersCount; i++)
                {
                    string number = "";
                    for (int j = 0; j < Com.NumberLength; j++)
                    {
                        number += Com.ReadMem(memOffset++).ToString();
                    }
                    filterList.Items.Add(number);
                }
                for (int i = 0; i < alertNumbersCount; i++)
                {
                    string number = "";
                    for (int j = 0; j < Com.NumberLength; j++)
                    {
                        number += Com.ReadMem(memOffset++).ToString();
                    }
                    alertList.Items.Add(number);
                }

                
            }
            catch (Exception exception)
            {
                RadMessageBox.Show(exception.Message, "", MessageBoxButtons.OK, RadMessageIcon.Error); ;
            }
            
           
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            DialogResult choice = RadMessageBox.Show("Отключить устройство?", "", MessageBoxButtons.YesNo,
              RadMessageIcon.Question);
            if (choice == DialogResult.No) return;
            Com.ResetDevice();
            SetButtonsEnabled(false);
            Com.Serial.Close();
        }

        private void buttonWrite_Click(object sender, EventArgs e)
        {
            try
            {
                byte memOffset = 0;
                Com.WriteMem(memOffset++, (byte) filterList.Items.Count);
                Com.WriteMem(memOffset++, (byte) alertList.Items.Count);
                foreach (var item in filterList.Items)
                {
                    for (int i = 0; i < item.Text.Length; i++)
                    {
                        Com.WriteMem(memOffset++, byte.Parse(item.Text.Substring(i, 1)));
                    }
                }
                foreach (var item in alertList.Items)
                {
                    for (int i = 0; i < item.Text.Length; i++)
                    {
                        Com.WriteMem(memOffset++, byte.Parse(item.Text.Substring(i, 1)));
                    }
                }
                RadMessageBox.Show("Запись ОК", "", MessageBoxButtons.OK, RadMessageIcon.Info);
                LoadNumbers();

            }
            catch (Exception exception)
            {
                RadMessageBox.Show(exception.Message,"", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

       
    }
}
