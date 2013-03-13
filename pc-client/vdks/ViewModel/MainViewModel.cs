using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using vdks.Model;
using System.Collections.ObjectModel;


namespace vdks.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
       public RelayCommand WriteDataCommand{get; private set;}
       public RelayCommand FindDeviceCommand { get; private set; }
       private ObservableCollection<PhoneNumber> _numbers;
       public ObservableCollection<PhoneNumber> Numbers {
            get { return _numbers; }
            set { _numbers = value; RaisePropertyChanged(()=>Numbers); }
        }
       //TODO: подключение по SerialPort, смена статуса соединения, получение данных, валидация в таблице, отправка данных
       /// <summary>
       /// The <see cref="SelectedNumber" /> property's name.
       /// </summary>
       public const string SelectedNumberPropertyName = "SelectedNumber";

       private PhoneNumber _selectedNumber = null;

       /// <summary>
       /// Sets and gets the SelectedNumber property.
       /// Changes to that property's value raise the PropertyChanged event. 
       /// </summary>
       public PhoneNumber SelectedNumber
       {
           get
           {
               return _selectedNumber;
           }

           set
           {
               if (_selectedNumber == value)
               {
                   return;
               }

               RaisePropertyChanging(SelectedNumberPropertyName);
               _selectedNumber = value;
               RaisePropertyChanged(SelectedNumberPropertyName);
           }
       }
       /// <summary>
       /// The <see cref="DeviceStatus" /> property's name.
       /// </summary>
       public const string DeviceStatusPropertyName = "DeviceStatus";

       private string _deviceStatus = "не подключено";

       /// <summary>
       /// Sets and gets the DeviceStatus property.
       /// Changes to that property's value raise the PropertyChanged event. 
       /// </summary>
       public string DeviceStatus
       {
           get
           {
               return _deviceStatus;
           }

           set
           {
               if (_deviceStatus == value)
               {
                   return;
               }

               RaisePropertyChanging(DeviceStatusPropertyName);
               _deviceStatus = value;
               RaisePropertyChanged(DeviceStatusPropertyName);
           }
       }
        public MainViewModel()
        {
         //  var numberlist = new List<PhoneNumber>(); 
           //     numberlist.Add(new PhoneNumber(new byte[]{9,2,1,1,2,3,1,2,1,2}));
           //     numberlist.Add(new PhoneNumber(new byte[] { 9, 2, 1, 1, 2, 3, 1, 2, 1, 3 }));
            //    numberlist.Add(new PhoneNumber(new byte[] { 9, 2, 1, 1, 2, 3, 1, 2, 1, 4 }));
            
            
            _numbers = new ObservableCollection<PhoneNumber>(/*numberlist*/);
            FindDeviceCommand = new RelayCommand(FindDevice);
            WriteDataCommand = new RelayCommand(WriteData);
            

        }
        private void WriteData()
        {
            if (System.Windows.MessageBox.Show("Данные будут записаны на устройство", "Записать данные?",System.Windows.MessageBoxButton.OKCancel) == System.Windows.MessageBoxResult.OK)
            {
                System.Windows.MessageBox.Show("DATA WRITTEN");
            }
           
        }
        private void FindDevice()
        {
            System.Windows.MessageBox.Show("DeviceFound");
            
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}