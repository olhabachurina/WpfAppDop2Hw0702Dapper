using Dapper;
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
using WpfAppDop2Hw0702Dapper.Models;

namespace WpfAppDop2Hw0702Dapper
{
    /// <summary>
    /// Interaction logic for PuzzleList.xaml
    /// </summary>
    public partial class PuzzleList : Window
    {
        public PuzzleList()
        {
            InitializeComponent();
            LoadPuzzles();
        }
        private void LoadPuzzles()
        {
            string connectionString = GetConnectionString(); 

            // SQL-запрос для выборки загадок из базы данных
            string sql = "SELECT * FROM Puzzles";

            // Создание подключения к базе данных
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Выполнение запроса к базе данных с использованием Dapper
                List<Puzzle> puzzles = connection.Query<Puzzle>(sql).AsList();

                // Отображение загадок в ListView
                listViewPuzzles.ItemsSource = puzzles;
            }
        }

        
            private static string GetConnectionString()
            {
                var builder = new ConfigurationBuilder();



                builder.SetBasePath(Directory.GetCurrentDirectory());



                builder.AddJsonFile("appsettings.json");



                var config = builder.Build();



                return config.GetConnectionString("DefaultConnection");
            }
        }
    }

