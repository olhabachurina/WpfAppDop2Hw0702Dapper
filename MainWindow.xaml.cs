using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace WpfAppDop2Hw0702Dapper
{
    public partial class MainWindow : Window
    {
        private string connectionString;

        public MainWindow()
        {
            InitializeComponent();
            connectionString = GetConnectionString();
        }

        private static string GetConnectionString()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            return config.GetConnectionString("DefaultConnection");
        }

        private void PuzzleList_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("PuzzleList button clicked");
            var puzzleListWindow = new PuzzleList();
            puzzleListWindow.Show();
        }

        private void AddPuzzle_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("AddPuzzle button clicked");
            var addPuzzleWindow = new AddPuzzle();
            addPuzzleWindow.Show();
        }

        private void Statistics_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Debug.WriteLine("Statistics button clicked");

                // Создаем экземпляр StatisticsWindow
                var statisticsWindow = new StatisticsWindow();

                // Добавляем точку останова
                System.Diagnostics.Debugger.Break();

                // Показываем окно
                statisticsWindow.Show();
            }
            catch (Exception ex)
            {
                // Обработка исключений
                Debug.WriteLine($"Произошла ошибка при отображении окна статистики: {ex.Message}");
                MessageBox.Show($"Произошла ошибка при отображении окна статистики: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}