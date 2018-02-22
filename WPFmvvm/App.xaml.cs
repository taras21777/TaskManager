﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using WPFmvvm.ViewModel;

namespace WPFmvvm
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
          
            MainWindow view = new MainWindow(); // создали View
            TaskVM viewModel = new ViewModel.TaskVM(); // Создали ViewModel
           
            view.DataContext = viewModel; // положили ViewModel во View в качестве DataContext
            view.Show();
        }
    }
}
