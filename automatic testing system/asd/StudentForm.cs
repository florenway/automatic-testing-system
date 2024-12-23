using System;
using System.Data.SQLite;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace asd
{
    public partial class StudentForm : Form
    {
        // Строка подключения к базе данных для студента
        private readonly string connectionString = "Data Source=mathTestDB.sqlite;Version=3;";

        public StudentForm()
        {
            InitializeComponent();
            SetButtonRounded(BtnSave);
            SetButtonRounded(backButton);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string studentName = txtName.Text;
            string studentSurname = txtSurname.Text;

            if (string.IsNullOrEmpty(studentName) || string.IsNullOrEmpty(studentSurname))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            try
            {
                // Проверка, существует ли уже студент с таким именем и фамилией
                int studentId = GetOrCreateStudentId(studentName, studentSurname);

                // Уведомление о сохранении
                MessageBox.Show("Данные успешно сохранены!");

                // Переход к форме AvailableTestsForm с передачей studentId
                var availableTestsForm = new AvailableTestsForm(studentId);
                availableTestsForm.Show();  // Показываем форму выбора тестов
                this.Hide();  // Скрываем текущую форму (StudentForm)
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}");
            }
        }

        private void StudentForm_Paint(object sender, PaintEventArgs e)
        {
            // Градиентный фон
            using (LinearGradientBrush brush = new LinearGradientBrush(
                this.ClientRectangle,
                Color.FromArgb(0, 123, 255),  // Светло-синий
                Color.FromArgb(0, 200, 255), // Голубой
                LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void SetButtonRounded(Button button)
        {
            GraphicsPath path = new GraphicsPath();
            int radius = 20; // Радиус закругления
            path.StartFigure();
            path.AddArc(0, 0, radius, radius, 180, 90); // Верхний левый угол
            path.AddArc(button.Width - radius, 0, radius, radius, 270, 90); // Верхний правый угол
            path.AddArc(button.Width - radius, button.Height - radius, radius, radius, 0, 90); // Нижний правый угол
            path.AddArc(0, button.Height - radius, radius, radius, 90, 90); // Нижний левый угол
            path.CloseFigure();
            button.Region = new Region(path);
        }

        // Метод для получения StudentID, если студент уже существует, или добавления нового
        private int GetOrCreateStudentId(string studentName, string studentSurname)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // SQL-запрос для проверки существования студента
                string query = "SELECT StudentID FROM Students WHERE StudentName = @StudentName AND StudentSurname = @StudentSurname LIMIT 1";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentName", studentName);
                    command.Parameters.AddWithValue("@StudentSurname", studentSurname);

                    var result = command.ExecuteScalar();

                    // Если студент найден, возвращаем его ID
                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                    else
                    {
                        // Если студента нет, добавляем нового и возвращаем его ID
                        return SaveStudentData(studentName, studentSurname);
                    }
                }
            }
        }

        // Метод для сохранения данных студента и получения ID
        private int SaveStudentData(string studentName, string studentSurname)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // SQL-запрос для добавления студента
                string query = "INSERT INTO Students (StudentName, StudentSurname) VALUES (@StudentName, @StudentSurname); SELECT last_insert_rowid();";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentName", studentName);
                    command.Parameters.AddWithValue("@StudentSurname", studentSurname);

                    // Выполняем запрос и получаем ID последней вставленной строки
                    int studentId = Convert.ToInt32(command.ExecuteScalar());
                    return studentId;
                }
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();  // Скрыть текущую форму

            RoleSelectionForm roleSelectionForm = new RoleSelectionForm();
            roleSelectionForm.Show();
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {

        }
    }
}