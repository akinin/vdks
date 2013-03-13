using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight;
using vdks.ViewModel;
using System.Collections.ObjectModel;

namespace vdks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Closing += (s, e) => ViewModelLocator.Cleanup();
        }

        private void DataGrid_LoadingRow(object sender, System.Windows.Controls.DataGridRowEventArgs e)
        {
            if (!e.Row.IsNewItem && e.Row.Item != null)
            {
                e.Row.Header = (e.Row.GetIndex() + 1).ToString();
            }
            else
            {
                e.Row.Header = ">";
            }
        }

        private void DataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
            
        }

       //TODO: обновление при удалении строки(итема)
    }
}