using KozyrevDenis_WpfApplication.ViewModels;
using KozyrevDenis_WpfApplication.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace KozyrevDenis_WpfApplication
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var mw = new ViewMailSender
            {
                DataContext = new ViewModelMailSender()
            };
            mw.Show();
            //mw.ShowDialog();
        }
    }
}
