using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace Numberry
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var ports = SerialPort.GetPortNames();
            
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            alertList.Items.Add("+79214065172");
            alertList.Items.Add("+79214065170");
            alertList.Items.Add("+79214065174");
            alertList.Items.Add("+79214065175");
            alertList.Items.Add("+79214065171");
            alertList.Items.Add("+79214065177");
            filterList.Items.Add("+79112804262");
            filterList.Items.Add("+79112804263");
            filterList.Items.Add("+79112804265");
            filterList.Items.Add("+79112804267");
        }

        private void buttonFilterAdd_Click(object sender, EventArgs e)
        {
            filterList.Items.Add("000-000-0000");
        }

        private void filterList_DoubleClick(object sender, EventArgs e)
        {

            var _listbox = sender as RadListView;
            if (_listbox.SelectedItem != null)
            {
                _listbox.BeginEdit();
            }
        }

        
    }
}
