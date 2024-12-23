using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace asd
{
    public partial class TestResultsForm : Form
    {
        private readonly string connectionString = "Data Source=mathTestDB.sqlite;Version=3;";

        public TestResultsForm()
        {
            InitializeComponent();
            SetButtonRounded(btnLoadResults);
            SetButtonRounded(btnBack);
            StyleDataGridView(dataGridViewResults);
        }

        private void TestResultsForm_Load(object sender, EventArgs e)
        {
            LoadTestResults();
        }

        private void BtnLoadResults_Click(object sender, EventArgs e)
        {
            try
            {
                LoadTestResults();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке результатов: {ex.Message}");
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            var teacherDashboardForm = new TeacherDashboardForm(); // Или другая форма, куда вы хотите вернуться
            teacherDashboardForm.Show();
            this.Close();
        }

        private void LoadTestResults()
        {
            try
            {
                DataTable testResultsTable = GetTestResultsFromDatabase();
                ConfigureDataGridView(testResultsTable); // Настраиваем отображение
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке результатов: {ex.Message}");
            }
        }

        private DataTable GetTestResultsFromDatabase()
        {
            DataTable resultsTable = new DataTable();

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = @"
                SELECT 
                    Students.StudentName AS 'Имя',
                    Students.StudentSurname AS 'Фамилия',
                    Tests.TestName AS 'Название теста',
                    TestResults.Score AS 'Баллы'
                FROM TestResults
                JOIN Students ON TestResults.StudentID = Students.StudentID
                JOIN Tests ON TestResults.TestID = Tests.TestID";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        resultsTable.Load(reader);
                    }
                }
            }

            return resultsTable;
        }

        private void ConfigureDataGridView(DataTable table)
        {
            dataGridViewResults.DataSource = table;

            // Устанавливаем ширину столбцов и стили
            dataGridViewResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridViewResults.Columns["Имя"].HeaderText = "Имя студента";
            dataGridViewResults.Columns["Фамилия"].HeaderText = "Фамилия студента";
            dataGridViewResults.Columns["Название теста"].HeaderText = "Название теста";
            dataGridViewResults.Columns["Баллы"].HeaderText = "Набранные баллы";

            dataGridViewResults.Columns["Баллы"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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

        private void StyleDataGridView(DataGridView grid)
        {
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point);
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 123, 255);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.DefaultCellStyle.Font = new Font("Comic Sans MS", 10F, FontStyle.Italic, GraphicsUnit.Point);
            grid.DefaultCellStyle.ForeColor = Color.Black;
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 123, 255);
            grid.DefaultCellStyle.SelectionForeColor = Color.White;
            grid.BorderStyle = BorderStyle.None;
            grid.BackgroundColor = Color.White;
            grid.GridColor = Color.LightGray;
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
