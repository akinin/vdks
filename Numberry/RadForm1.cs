using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export.ExcelML;

namespace Numberry
{
    public partial class RadForm1 : Telerik.WinControls.UI.RadForm
    {
       
        private Device _device;
        public RadForm1()
        {
            
            InitializeComponent();
            filterList.ItemSize = new Size(0, 40);
            
            _device = Device.GetInstance();
            this.radPropertyGrid1.SelectedObject = this._device;
            this.radPropertyGrid1.ExpandAllGridItems();
           
        }

        private void filterList_VisualItemCreating(object sender, Telerik.WinControls.UI.ListViewVisualItemCreatingEventArgs e)
        {
            e.VisualItem = new NumberItem();
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            this.filterList.Items.Add("");
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
           
            DialogResult choice = RadMessageBox.Show("Удалить все номера из списка?", "", MessageBoxButtons.YesNo,
                RadMessageIcon.Question);
            if (choice == DialogResult.Yes)
            {
                this.filterList.Items.Clear();
            }
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
             string[] _portlist;
            bool _deviceFound = false;
             _portlist = System.IO.Ports.SerialPort.GetPortNames();
            foreach (string s in _portlist)
            {
                try
                {
                    _device.Port.PortName = s;
                    _device.Port.Open();
                    _device.Port.WriteLine("AB");
                    string answer = _device.Port.ReadLine();
                    if (answer == "BC")
                    {
                        _deviceFound = true;
                        break;
                    }
                    _device.Port.Close();
                }
                catch (Exception)
                {
                    _device.Port.Close();
                }
            }
            if (_deviceFound)
            {
                try
                {
                    _device.Port.Open();
                    _device.InitServiceMode();
                    SetButtonsEnabled(true);
                    _device.ReadSerial();
                    LoadNumbers();
                }
                catch (Exception ex)
                {
                    RadMessageBox.Show(ex.Message);
                    _device.Port.Close();
                }
                
            }
            else
            {
                RadMessageBox.Show("Устройство не обнаружено"," ",MessageBoxButtons.OK,RadMessageIcon.Exclamation);
            }

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

        private void LoadNumbers()
        {
            int filterNumbersCount = _device.ReadMem(0x1);
            int alertNumbersCount = _device.ReadMem(0x2);
            for (int i = 0; i < filterNumbersCount; i++)
            {
                string number = "";
                byte numberStart = (byte)(0x2 + i*10);
                byte numberEnd = (byte) (0x11 + i*10);
                for (byte j = numberStart; j <= numberEnd; j++)
                {
                    number += _device.ReadMem(j).ToString();
                }
                filterList.Items.Add(number);

            }
            for (int i = filterNumbersCount; i < filterNumbersCount+alertNumbersCount; i++)
            {
                string number = "";
                byte numberStart = (byte)(0x2 + i * 10);
                byte numberEnd = (byte)(0x11 + i * 10);
                for (byte j = numberStart; j <= numberEnd; j++)
                {
                    number += _device.ReadMem(j).ToString();
                }
                alertList.Items.Add(number);

            }
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            _device.Port.Close();
            SetButtonsEnabled(false);

        }

        private void buttonWrite_Click(object sender, EventArgs e)
        {
            int filterNumbersCount = filterList.Items.Count;
            int alertNumbersCount = alertList.Items.Count;
            for (int i = 0; i < filterNumbersCount; i++)
            {
                string number = filterList.Items[i].Text;
                byte numberStart = (byte)(0x2 + i * 10);
                byte numberEnd = (byte)(0x11 + i * 10);
                
                int stringPos = 0;
                for (byte j = numberStart; j <= numberEnd; j++)
                {
                    _device.WriteMem(j,byte.Parse(number.Substring(stringPos,1)));
                    stringPos++;
                }
                filterList.Items.Add(number);

            }
            for (int i = filterNumbersCount; i < filterNumbersCount + alertNumbersCount; i++)
            {
                string number = alertList.Items[i-filterNumbersCount].Text;
                byte numberStart = (byte)(0x2 + i * 10);
                byte numberEnd = (byte)(0x11 + i * 10);
                int stringPos = 0;
                for (byte j = numberStart; j <= numberEnd; j++)
                {
                    _device.WriteMem(j, byte.Parse(number.Substring(stringPos, 1)));
                    stringPos++;
                }
                alertList.Items.Add(number);

            }
        }

       
    }
}
