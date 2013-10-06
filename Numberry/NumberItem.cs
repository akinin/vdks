using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Layouts;
using Telerik.WinControls.UI;

namespace Numberry
{
    public class NumberItem : SimpleListViewVisualItem
    {
        private StackLayoutPanel stackLayout;
        private RadLabelElement labelPrefix;
        private RadMaskedEditBoxElement textBoxNumber;

        public NumberItem(string text)
        {
            this.Data.Text = text;
        }

        public NumberItem()
        {
            
        }

        protected override void CreateChildElements()
        {
            base.CreateChildElements();
            this.stackLayout = new StackLayoutPanel();
            this.stackLayout.Orientation = Orientation.Horizontal;
            this.stackLayout.EqualChildrenWidth = false;
           
            this.labelPrefix = new RadLabelElement();
            this.labelPrefix.Text = "+7";
            this.labelPrefix.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stackLayout.Children.Add(this.labelPrefix);

            this.textBoxNumber = new RadMaskedEditBoxElement();
            this.textBoxNumber.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxNumber.MinSize = new Size(200,0);
            this.textBoxNumber.TextChanged += textBoxNumber_TextChanged;
            this.textBoxNumber.MaskType = MaskType.Standard;
            this.textBoxNumber.MouseUp += textBoxNumber_MouseUp;
            this.textBoxNumber.Border.Visibility = ElementVisibility.Hidden;
            this.textBoxNumber.TextRenderingHint = TextRenderingHint.SystemDefault;
            this.textBoxNumber.Mask = "(000) 000-0000";
            this.textBoxNumber.Text = "";
            this.stackLayout.Children.Add(this.textBoxNumber);


            this.Children.Add(this.stackLayout);
        }

       void textBoxNumber_MouseUp(object sender, MouseEventArgs e)
       {
           var _textbox = sender as RadMaskedEditBoxElement;
           _textbox.TextBoxItem.SelectAll();
           
       }


       void textBoxNumber_TextChanged(object sender, EventArgs e)
       {
           if (Data != null)
           {
               
               this.Data.Text = this.textBoxNumber.TextBoxItem.Text.Replace(" ","").Replace("(","").Replace(")","").Replace(" ","").Replace("-","").Replace("_","");
              
           }
       }

        protected override void SynchronizeProperties()
        {
            base.SynchronizeProperties();

            this.Text = "";
            this.textBoxNumber.Text = this.Data.Text;
        }

        protected override Type ThemeEffectiveType
        {
            get
            {
                return typeof(SimpleListViewVisualItem); //так надо
            }
        }
        
    }
}
