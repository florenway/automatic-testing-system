using System;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace asd
{
    public partial class ViewTestsForm : Form
    {
        private readonly string connectionString = "Data Source=mathTestDB.sqlite;Version=3;";

        public ViewTestsForm()
        {
            InitializeComponent();
            StyleListBox(listBoxTests);
            StyleListBox(listBoxQuestions);
            StyleListBox(listBoxAnswers);
            StyleButton(backButton);
            LoadTests();
        }

        private void LoadTests()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT TestID, TestName FROM Tests";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        listBoxTests.Items.Clear();
                        while (reader.Read())
                        {
                            listBoxTests.Items.Add(new TestItem
                            {
                                TestID = Convert.ToInt32(reader["TestID"]),
                                TestName = reader["TestName"].ToString()
                            });
                        }
                    }
                }
            }
        }

        private void ListBoxTests_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxTests.SelectedItem != null)
            {
                var selectedTest = (TestItem)listBoxTests.SelectedItem;
                LoadQuestionsAndAnswers(selectedTest.TestID);
            }
        }

        private void LoadQuestionsAndAnswers(int testId)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT QuestionText, CorrectAnswer FROM Questions WHERE TestID = @TestID";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TestID", testId);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        listBoxQuestions.Items.Clear();
                        listBoxAnswers.Items.Clear();

                        while (reader.Read())
                        {
                            string question = reader["QuestionText"].ToString();
                            string answer = reader["CorrectAnswer"].ToString();

                            listBoxQuestions.Items.Add(question);
                            listBoxAnswers.Items.Add(answer);
                        }
                    }
                }
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
            TestCreationForm testCreationForm = new TestCreationForm();
            testCreationForm.Show();
        }

        private void StyleListBox(ListBox listBox)
        {
            listBox.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            listBox.BackColor = Color.White;
            listBox.BorderStyle = BorderStyle.FixedSingle;
        }

        private void StyleButton(Button button)
        {
            button.Font = new Font("Comic Sans MS", 14F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            button.BackColor = Color.FromArgb(0, 123, 255);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.ForeColor = Color.White;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(
                this.ClientRectangle,
                Color.FromArgb(0, 123, 255),  // Светло-синий
                Color.FromArgb(0, 200, 255), // Голубой
                LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }
    }

    public class TestItem
    {
        public int TestID { get; set; }
        public string TestName { get; set; }

        public override string ToString()
        {
            return TestName;
        }
    }
}