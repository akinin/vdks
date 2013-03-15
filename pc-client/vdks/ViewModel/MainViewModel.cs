using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
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
        public RelayCommand WriteDataCommand { get; private set; }
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
            WriteDataCommand = new RelayCommand(WriteData,IsConnected);
            _device = new Device();
        }
        private void WriteData()
        {
            if (System.Windows.MessageBox.Show("Данные будут записаны на устройство", "Записать данные?", System.Windows.MessageBoxButton.OKCancel) == System.Windows.MessageBoxResult.OK)
            {
                foreach (var phoneNumber in Numbers)
                {
                    phoneNumber.IsSaved = false;
                }
                var bWorkerWriter = new BackgroundWorker();
                bWorkerWriter.DoWork += bWorkerWriter_DoWork;
              
                bWorkerWriter.RunWorkerAsync(Numbers);
            }

        }

       
        void bWorkerWriter_DoWork(object sender, DoWorkEventArgs e)
        {//TODO: тесты тесты и еще раз тесты
            var numbers = (ObservableCollection<PhoneNumber>) e.Argument;
             Application.Current.Dispatcher.BeginInvoke(new Action(() => DeviceStatus = "Запись в память устройства..."));
            var bytesToWrite = numbers.Count*10;
            var bytesWasWritten = 0;
            Device.WriteByte(Messages.NumberCountOffset, (byte)numbers.Count);
            var serial = BitConverter.GetBytes(Device.Serial);
            Device.WriteByte(Messages.SerialOffset, serial[0]);
            Device.WriteByte((byte)(Messages.SerialOffset + 1), serial[1]);
            for (var i= 0; i < numbers.Count; i++)
            {
                var phoneNumber = numbers[i];
                
                var sendArray = phoneNumber.NumberArray;
                for (var j = 0; j < sendArray.Length; j++)
                {
                    if (!Device.WriteByte((byte)(Messages.FirstNumberOffset+i*10+j), sendArray[j]))
                    {
                        MessageBox.Show("Данные не были записаны \n или были записаны неверно", "Ошибка",
                                        MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    bytesWasWritten++;
                    Application.Current.Dispatcher.BeginInvoke(new Action(() => DeviceStatus = "Запись в память устройства... (" + (i+1).ToString() + "/" + numbers.Count.ToString() + ") " + Math.Round((double)bytesWasWritten / bytesToWrite * 100).ToString() + "%"));
                }
                Debug.Assert(i < 3);
                var iOldValue = i; //Фиксит баг с задержкой диспатчера
                Application.Current.Dispatcher.BeginInvoke(new Action(() => Numbers[iOldValue].IsSaved = true));
            }
            Application.Current.Dispatcher.BeginInvoke(new Action(() => DeviceStatus =  "Устройство подключено на " + Device.COM.PortName));
        }
        #region Поиск устройства "Async"
        private void FindDevice()
        {
            
            DeviceStatus = "Выполняется поиск устройства";
            var bWorkerConnect = new BackgroundWorker();
            bWorkerConnect.DoWork += bWorkerConnect_DoWork;
         
            bWorkerConnect.RunWorkerAsync();
        }


        private void bWorkerConnect_DoWork(object sender, DoWorkEventArgs e)
        {
            Device.Connect();
            if (Device.COM.PortName != "noDevice")
            {
                Application.Current.Dispatcher.BeginInvoke(new Action(() => Numbers.Clear()));
                Application.Current.Dispatcher.BeginInvoke(new Action(() => DeviceStatus = "Устройство подключено на " + Device.COM.PortName));
                Application.Current.Dispatcher.BeginInvoke(new Action(() => RaisePropertyChanged(DevicePropertyName)));


                var numberCount = Device.ReadByte(0);
                var currentNumber = new byte[10];
                var bytesToRead = numberCount*10;
                var bytesWasRead = 0;
                for (var i = 0; i < numberCount; i++)
                {
                    
                    //((BackgroundWorker)sender).ReportProgress(i);
                    var offset = (byte)(Messages.FirstNumberOffset + i * 10);
                    for (var j = 0; j < 10; j++)
                    {
                        currentNumber[j] = Device.ReadByte((byte)(offset + j));
                        bytesWasRead++;
                        Application.Current.Dispatcher.BeginInvoke(new Action(() => DeviceStatus = "Загрузка номеров...(" + i.ToString() +"/" + numberCount.ToString() + ") " + Math.Round((double)(bytesWasRead) / bytesToRead * 100).ToString() + "%"));
                    }
                    var currentNumberOldValue = new byte[10];
                    currentNumber.CopyTo(currentNumberOldValue,0);
                    Application.Current.Dispatcher.BeginInvoke(new Action(() => Numbers.Add(new PhoneNumber(currentNumberOldValue))));
                }

                Application.Current.Dispatcher.BeginInvoke(new Action(() => DeviceStatus = "Устройство подключено на " + Device.COM.PortName));
            }
            else Application.Current.Dispatcher.BeginInvoke(new Action(() => DeviceStatus = "не подключено"));
        }
        #endregion

        private bool IsConnected()
        {
            return Device.COM.PortName != "noDevice";
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}