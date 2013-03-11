using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
//using vdks.Models;
using vdks.ViewModels;
using vdks.Views;

namespace vdks
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
           
            MainView view = new MainView(); // создали View
            MainViewModel viewModel = new ViewModels.MainViewModel(); // Создали ViewModel
            view.DataContext = viewModel; // положили ViewModel во View в качестве DataContext
            view.Show();
        }
    }
}
