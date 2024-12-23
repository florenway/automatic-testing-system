using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace asd
{
    public partial class AvailableTestsForm : Form
    {
        private readonly string connectionString = "Data Source=mathTestDB.sqlite;Version=3;";
        private readonly int studentId;

        public AvailableTestsForm(int studentId)
        {
            InitializeComponent();
            this.studentId = studentId;
            SetButtonRounded(BtnConfirmTest);
        }

        private void AvailableTestsForm_Load(object sender, EventArgs e)
        {
            LoadAvailableTests();
        }

        private void LoadAvailableTests()
        {
            try
            {
                DataTable testsTable = GetAvailableTestsFromDatabase();
                Console.WriteLine($"Найдено тестов: {testsTable.Rows.Count}");

                if (testsTable.Rows.Count == 0)
                {
                    MessageBox.Show("Тесты не найдены.");
                    return;
                }

                comboBoxTests.DataSource = testsTable;
                comboBoxTests.DisplayMember = "TestName";
                comboBoxTests.ValueMember = "TestID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке тестов: {ex.Message}");
            }
        }

        private void AvailableTestsForm_Paint(object sender, PaintEventArgs e)
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

        private void SetButtonRounded(Button button)
        {
            GraphicsPath path = new GraphicsPath();
            int radius = 20;
            path.StartFigure();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(button.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(button.Width - radius, button.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, button.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();
            button.Region = new Region(path);
        }

        private DataTable GetAvailableTestsFromDatabase()
        {
            DataTable testsTable = new DataTable();

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT TestID, TestName FROM Tests";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        testsTable.Load(reader);
                        Console.WriteLine($"Запрос выполнен. Количество записей: {testsTable.Rows.Count}");
                    }
                }
            }

            return testsTable;
        }

        private void BtnConfirmTest_Click(object sender, EventArgs e)
        {
            if (comboBoxTests.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите тест.");
                return;
            }

            try
            {
                var selectedTest = (DataRowView)comboBoxTests.SelectedItem;
                int testId = Convert.ToInt32(selectedTest["TestID"]);
                string testName = selectedTest["TestName"].ToString();

                if (!IsTestAssignedToStudent(studentId, testId))
                {
                    AddStudentTest(studentId, testId);
                }

                var testForm = new TestForm(studentId, testId, testName);
                testForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении теста: {ex.Message}");
            }
        }

        private bool IsTestAssignedToStudent(int studentId, int testId)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM StudentTests WHERE StudentID = @StudentID AND TestID = @TestID";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentID", studentId);
                    command.Parameters.AddWithValue("@TestID", testId);

                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        private void AddStudentTest(int studentId, int testId)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO StudentTests (StudentID, TestID) VALUES (@StudentID, @TestID)";
                    using (SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@StudentID", studentId);
                        insertCommand.Parameters.AddWithValue("@TestID", testId);

                        insertCommand.ExecuteNonQuery();
                        MessageBox.Show("Тест успешно выбран.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении теста: {ex.Message}");
            }
        }
    }
}
