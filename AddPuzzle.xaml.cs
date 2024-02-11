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
    /// <summary>
    /// Interaction logic for AddPuzzle.xaml
    /// </summary>
    public partial class AddPuzzle : Window
    {
        private string connectionString;

        public AddPuzzle()
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

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            // Собираем данные из полей формы
            string puzzleText = txtPuzzleText.Text;
            string puzzleAnswer = txtPuzzleAnswer.Text;
            int difficultyLevel = cmbDifficultyLevel.SelectedIndex + 1; // Предполагая, что индекс начинается с 0

            // Создаем соединение с базой данных
            using (var connection = new SqlConnection(connectionString))
            {
                // Открываем соединение
                connection.Open();

                // Выполняем запрос к базе данных для вставки новой записи
                string query = "INSERT INTO Puzzles (PuzzleText, PuzzleAnswer, DifficultyLevel) VALUES (@PuzzleText, @PuzzleAnswer, @DifficultyLevel)";
                connection.Execute(query, new { PuzzleText = puzzleText, PuzzleAnswer = puzzleAnswer, DifficultyLevel = difficultyLevel });
            }

            // Закрываем окно после добавления
            this.Close();
        }
    }
}