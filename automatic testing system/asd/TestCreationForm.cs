using System;
using System.Data.SQLite;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace asd
{
    public partial class TestCreationForm : Form
    {
        private readonly string connectionString = "Data Source=mathTestDB.sqlite;Version=3;";

        public TestCreationForm()
        {
            InitializeComponent();
            SetButtonRounded(btnAddQuestion);
            SetButtonRounded(btnViewTests);
            StyleTextBox(txtQuestion);
            StyleTextBox(txtAnswer);
            StyleTextBox(txtTestName);
        }

        private void BtnAddQuestion_Click(object sender, EventArgs e)
        {
            // Добавление вопроса (логика без изменений)
            var question = txtQuestion.Text;
            var answer = txtAnswer.Text;
            var testName = txtTestName.Text;

            if (string.IsNullOrEmpty(question) || string.IsNullOrEmpty(answer) || string.IsNullOrEmpty(testName))
            {
                MessageBox.Show("Все поля должны быть заполнены.");
                return;
            }

            try
            {
                int testID = GetOrCreateTestIDByName(testName);
                AddQuestionToDatabase(testID, question, answer);
                MessageBox.Show("Вопрос добавлен!");

                txtQuestion.Clear();
                txtAnswer.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении вопроса: {ex.Message}");
            }
        }

        private void BtnViewTests_Click(object sender, EventArgs e)
        {
            var viewTestsForm = new ViewTestsForm();
            viewTestsForm.Show();
            this.Hide();
        }

        private void SetButtonRounded(Button button)
        {
            GraphicsPath path = new GraphicsPath();
            int radius = 20;

            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(button.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(button.Width - radius, button.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, button.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();

            button.Region = new Region(path);
        }

        private void StyleTextBox(TextBox textBox)
        {
            textBox.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            textBox.BackColor = Color.White;
            textBox.BorderStyle = BorderStyle.FixedSingle;
        }

        private int GetOrCreateTestIDByName(string testName)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT TestID FROM Tests WHERE TestName = @TestName LIMIT 1";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TestName", testName);
                    var result = command.ExecuteScalar();

                    if (result == null)
                    {
                        return CreateTest(testName, connection);
                    }

                    return Convert.ToInt32(result);
                }
            }
        }

        private int CreateTest(string testName, SQLiteConnection connection)
        {
            string query = "INSERT INTO Tests (TestName) VALUES (@TestName)";
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TestName", testName);
                command.ExecuteNonQuery();
            }

            string getLastTestIDQuery = "SELECT last_insert_rowid()";
            using (SQLiteCommand command = new SQLiteCommand(getLastTestIDQuery, connection))
            {
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        private void AddQuestionToDatabase(int testID, string question, string answer)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Questions (TestID, QuestionText, CorrectAnswer) VALUES (@TestID, @QuestionText, @CorrectAnswer)";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TestID", testID);
                    command.Parameters.AddWithValue("@QuestionText", question);
                    command.Parameters.AddWithValue("@CorrectAnswer", answer);
                    command.ExecuteNonQuery();
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(
                this.ClientRectangle,
                Color.FromArgb(0, 123, 255),
                Color.FromArgb(0, 200, 255),
                LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }
    }
}
