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

        

    }
}
