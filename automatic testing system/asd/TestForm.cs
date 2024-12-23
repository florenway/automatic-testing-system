using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;

namespace asd
{
    public partial class TestForm : Form
    {
        private readonly int StudentId;
        private readonly int TestId;
        private readonly string TestName;  // Добавлено свойство для хранения имени теста

        private int correctAnswers = 0;
        private readonly int totalQuestions;
        private int currentQuestionIndex = 0;
        private readonly List<Question> questions;
        private readonly string connectionString = "Data Source=mathTestDB.sqlite;Version=3;";

        public TestForm(int studentId, int testId, string testName)
        {
            InitializeComponent();

            this.StudentId = studentId;  // Установка идентификатора студента
            this.TestId = testId;        // Установка идентификатора теста
            this.TestName = testName;    // Установка имени теста

            // Установка имени теста в заголовок формы
            this.Text = $"Тест: {testName}";

            // Загружаем вопросы для конкретного теста
            questions = GetQuestionsFromDatabase(testId);
            totalQuestions = questions.Count;

            if (totalQuestions > 0)
            {
                LoadNextQuestion(); // Загружаем первый вопрос
            }
            else
            {
                MessageBox.Show("В этом тесте нет вопросов.");
                this.Close(); // Закрываем форму, если нет вопросов
            }
        }

        private void BtnNextQuestion_Click(object sender, EventArgs e)
        {
            // Логика перехода к следующему вопросу
            LoadNextQuestion();
        }

        private void BtnSubmitAnswer_Click(object sender, EventArgs e)
        {
            string studentAnswer = txtAnswer.Text;  // Ответ студента
            string correctAnswer = GetCorrectAnswerForCurrentQuestion();  // Получаем правильный ответ для текущего вопроса

            if (studentAnswer.Equals(correctAnswer, StringComparison.OrdinalIgnoreCase))
            {
                correctAnswers++;  // Увеличиваем количество правильных ответов
            }

            // Проверяем, есть ли ещё вопросы
            if (currentQuestionIndex < totalQuestions)
            {
                LoadNextQuestion(); // Переход к следующему вопросу
            }
            else
            {
                // Если вопросов больше нет, завершаем тест
                BtnFinishTest_Click(sender, e);
            }
        }


        private void BtnFinishTest_Click(object sender, EventArgs e)
        {
            try
            {
                SaveTestResultToDatabase(correctAnswers); // Сохраняем результат теста в базу данных

                MessageBox.Show($"Тест завершен! Ваш результат: {correctAnswers}/{totalQuestions}"); // Показываем результат

                // Переход к RoleSelectionForm
                var roleSelectionForm = new RoleSelectionForm(); // Предполагается, что эта форма уже существует
                roleSelectionForm.Show();

                this.Close(); // Закрываем текущую форму
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении результата теста: {ex.Message}");
            }
        }


        private void SaveTestResultToDatabase(int score)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    using (var transaction = connection.BeginTransaction())
                    {
                        string query = @"
                    INSERT INTO TestResults (StudentID, TestID, Score)
                    VALUES (@StudentID, @TestID, @Score)
                    ON CONFLICT(StudentID, TestID)
                    DO UPDATE SET Score = excluded.Score";

                        using (SQLiteCommand command = new SQLiteCommand(query, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@StudentID", this.StudentId);
                            command.Parameters.AddWithValue("@TestID", this.TestId);
                            command.Parameters.AddWithValue("@Score", score);

                            command.ExecuteNonQuery();
                        }

                        transaction.Commit(); // Подтверждаем изменения
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении результата: {ex.Message}");
                throw;
            }
        }


        private void LoadNextQuestion()
        {
            if (currentQuestionIndex < totalQuestions)
            {
                lblQuestion.Text = questions[currentQuestionIndex].Text;  // Отображаем следующий вопрос
                txtAnswer.Clear();  // Очищаем поле ввода для нового ответа
                currentQuestionIndex++;
            }
        }


        private string GetCorrectAnswerForCurrentQuestion()
        {
            return questions[currentQuestionIndex - 1].CorrectAnswer;  // Возвращаем правильный ответ
        }

        private List<Question> GetQuestionsFromDatabase(int testId)
        {
            List<Question> questions = new List<Question>();

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT QuestionText, CorrectAnswer FROM Questions WHERE TestID = @TestID";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TestID", testId);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            questions.Add(new Question
                            {
                                Text = reader.GetString(0),
                                CorrectAnswer = reader.GetString(1)
                            });
                        }
                    }
                }

                return questions;
            }
        }
    }

    public class Question
    {
        public string Text { get; set; }
        public string CorrectAnswer { get; set; }
    }
}
