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
       public const string NumbersPropertyName = "Numbers";
       private ObservableCollection<PhoneNumber> _numbers;
       public ObservableCollection<PhoneNumber> Numbers
       {
           get
           {
               return _numbers;
           }

           set
           {
               if (_numbers == value)
               {
                   return;
               }

               RaisePropertyChanging(NumbersPropertyName);
               _numbers = value;
               RaisePropertyChanged(NumbersPropertyName);
           }
       }
       //TODO: отправка данных
       /// <summary>
       /// The <see cref="SelectedNumber" /> property's name.
       /// </summary>
       public const string SelectedNumberPropertyName = "SelectedNumber";

       private PhoneNumber _selectedNumber;

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
       /// <summary>
       /// The <see cref="Device" /> property's name.
       /// </summary>
       public const string DevicePropertyName = "Device";

       private Device _device;

       /// <summary>
       /// Sets and gets the Device property.
       /// Changes to that property's value raise the PropertyChanged event. 
       /// </summary>
       public Device Device
       {
           get
           {
               return _device;
           }

           set
           {
               if (_device == value)
               {
                   return;
               }

               RaisePropertyChanging(DevicePropertyName);
               _device = value;
               RaisePropertyChanged(DevicePropertyName);
           }
       }
        public MainViewModel()
        {
            _numbers = new ObservableCollection<PhoneNumber>(/*numberlist*/);
            FindDeviceCommand = new RelayCommand(FindDevice);
            WriteDataCommand = new RelayCommand(WriteData);
            _device = new Device();
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
            //TODO: Убрать все в Async
            DeviceStatus = "Выполняется поиск устройства";
            Device.Connect();
            if (Device.COM.PortName != "noDevice")
            {
                DeviceStatus = "Устройство подключено на " + Device.COM.PortName;
                RaisePropertyChanged(DevicePropertyName);
                var numberCount = Device.ReadByte(0);
                var currentNumber = new byte[10];
                DeviceStatus = "Загрузка номеров...";
                Numbers.Clear();
                
                for (var i = 0; i < numberCount; i++)
                    {
                        var offset = (byte)(Messages.FirstNumberOffset + i * 10);
                        for (var j = 0; j < 10; j++)
                        {
                            currentNumber[j] = Device.ReadByte((byte)(offset+j));
                        }
                        Numbers.Add(new PhoneNumber(currentNumber));
                    }
                DeviceStatus = "Устройство подключено на " + Device.COM.PortName;
                
            }
            else DeviceStatus = "не подключено";
            

        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}