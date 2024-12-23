using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System;

namespace asd
{
    public partial class StudentResultsForm : Form
    {
        // Строка подключения к базе данных
        private readonly string connectionString = "Data Source=mathTestDB.sqlite;Version=3;";

        public StudentResultsForm()
        {
            InitializeComponent();
        }

        // Обработчик события загрузки формы
        private void StudentResultsForm_Load(object sender, EventArgs e)
        {
            // Загрузить и показать результаты студента
            LoadStudentResults();
        }

        // Метод для загрузки результатов студента
        private void LoadStudentResults()
        {
            try
            {
                // Получаем результаты студента из базы данных
                DataTable resultsTable = GetStudentResultsFromDatabase();

                // Привязка данных к DataGridView
                dataGridViewResults.DataSource = resultsTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке результатов: {ex.Message}");
            }
        }

        // Метод для получения результатов студента из базы данных
        private DataTable GetStudentResultsFromDatabase()
        {
            DataTable resultsTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // SQL-запрос для получения результатов (предполагается наличие таблицы Results)
                string query = "SELECT TestName, Score FROM Results WHERE StudentID = @StudentID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Параметр для запроса (например, студент с ID 1, замените на актуальное ID)
                    command.Parameters.AddWithValue("@StudentID", 1);  // Замените на актуальное StudentID

                    // Заполнение DataTable результатами запроса
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        resultsTable.Load(reader);
                    }
                }
            }

            return resultsTable;
        }
    }
}
