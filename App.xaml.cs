using System;
using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Diagnostics;

namespace WpfAppDop2Hw0702Dapper
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        [STAThread]
        public static void Main()
        {
            App app = new App();

            try
            {
                app.Run();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Произошла ошибка при запуске приложения: {ex.Message}");
                MessageBox.Show($"Произошла ошибка при запуске приложения: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}


   