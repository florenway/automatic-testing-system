using System;
using System.Configuration;

using System.Data.SQLite;
using System.Windows.Forms;

namespace asd
{
    class Program
    {
        [STAThread] // Атрибут для правильной работы Windows Forms
        static void Main()
        {
            DatabaseInitializer.InitializeDatabase();

            // Получаем строку подключения из App.config
            string connectionString = "Data Source=mathTestDB.sqlite;Version=3;";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                try
                {
                    // Открываем соединение с базой данных
                    conn.Open();
                    Console.WriteLine("Соединение с базой данных успешно установлено.");

                    // Пример выполнения SQL-запроса
                    string query = "SELECT FirstName, LastName FROM Students";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string firstName = reader["FirstName"].ToString();
                                string lastName = reader["LastName"].ToString();
                                Console.WriteLine($"Имя: {firstName}, Фамилия: {lastName}");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка подключения или выполнения запроса: " + ex.Message);
                }
            }

            // После завершения работы с базой данных, запускаем форму выбора роли
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Запуск формы выбора роли
            Application.Run(new RoleSelectionForm());
        }
    }
}
