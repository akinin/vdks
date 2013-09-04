using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Numberry
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            RadMessageLocalizationProvider.CurrentProvider = new RadMessageBoxLocalizationProvider();
            RadMessageBox.SetThemeName("Windows8");
            Application.Run(new RadForm1());
        }
    }
}
