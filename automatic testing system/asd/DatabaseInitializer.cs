using System;
using System.IO;
using System.Data.SQLite;
using static System.Net.Mime.MediaTypeNames;

namespace asd
{
    partial class DatabaseInitializer
    {
        // Строка подключения к базе данных
        private static readonly string connectionString = "Data Source=mathTestDB.sqlite;Version=3;";

        // Метод для инициализации базы данных (создание таблиц)
        public static void InitializeDatabase()
        {
            // Проверяем, существует ли файл базы данных. Если нет, создаем новый
            if (!File.Exists("mathTestDB.sqlite"))
            {
                SQLiteConnection.CreateFile("mathTestDB.sqlite");
                Console.WriteLine("База данных создана.");
            }

            // Создаем таблицы в базе данных
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string createStudentsTable = @"
                    CREATE TABLE IF NOT EXISTS Students (
                        StudentID INTEGER PRIMARY KEY AUTOINCREMENT,
                        StudentName TEXT NOT NULL,
                        StudentSurname TEXT NOT NULL
                    );
                ";

                string createTestsTable = @"
                    CREATE TABLE IF NOT EXISTS Tests (
                        TestID INTEGER PRIMARY KEY AUTOINCREMENT,
                        TestName TEXT NOT NULL
                    );
                ";

                string createStudentTestsTable = @"
                    CREATE TABLE IF NOT EXISTS StudentTests (
                        StudentID INTEGER,
                        TestID INTEGER,
                        TestDate DATETIME DEFAULT CURRENT_TIMESTAMP,
                        Score INTEGER,
                        PRIMARY KEY (StudentID, TestID),
                        FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
                        FOREIGN KEY (TestID) REFERENCES Tests(TestID)
                );
                ";


                string createQuestionsTable = @"
                    CREATE TABLE IF NOT EXISTS Questions (
                        QuestionID INTEGER PRIMARY KEY AUTOINCREMENT,
                        TestID INTEGER,
                        QuestionText TEXT NOT NULL,
                        CorrectAnswer TEXT NOT NULL,
                        FOREIGN KEY (TestID) REFERENCES Tests(TestID)
                    );
                ";

            

                string createTestResultsTable = @"
               
                    CREATE TABLE IF NOT EXISTS TestResults (
                    TestResultID INTEGER PRIMARY KEY AUTOINCREMENT,
                    StudentID INTEGER NOT NULL,
                    TestID INTEGER NOT NULL,
                    Score INTEGER NOT NULL,
                    UNIQUE(StudentID, TestID),
                    FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
                    FOREIGN KEY (TestID) REFERENCES Tests(TestID)
                    );    
                ";

                // Выполнение SQL команд для создания таблиц
                ExecuteNonQuery(createStudentsTable, connection);
                ExecuteNonQuery(createTestsTable, connection);
                ExecuteNonQuery(createQuestionsTable, connection);
                ExecuteNonQuery(createTestResultsTable, connection);
                ExecuteNonQuery(createStudentTestsTable, connection);
            }
        }

        // Метод для выполнения SQL-запроса
        private static void ExecuteNonQuery(string query, SQLiteConnection connection)
        {
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}