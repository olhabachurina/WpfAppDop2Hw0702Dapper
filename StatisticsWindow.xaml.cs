using Microsoft.Data.SqlClient;
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
using System.Windows.Shapes;
using Dapper;
namespace WpfAppDop2Hw0702Dapper
{
    public partial class StatisticsWindow : Window
    {
        private string connectionString;

        public StatisticsWindow()
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

        private void SomeDatabaseOperation()
        {
            // Пример использования Dapper для выполнения запроса к базе данных
            using (var connection = new SqlConnection(connectionString))
            {
                // Открываем соединение
                connection.Open();

                // Выполняем запрос к базе данных
                var result = connection.Query("SELECT * FROM SomeTable");

                // Обрабатываем результат запроса
                foreach (var item in result)
                {
                    // Делаем что-то с данными из базы данных
                }
            }
        }
    }
}