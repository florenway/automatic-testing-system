using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace asd
{
    public partial class TeacherPasswordForm : Form
    {
        // Максимальное количество неудачных попыток
        private int _failedAttempts = 0;
        private const int MaxFailedAttempts = 3;

        // Правильный пароль (в реальном проекте использовать хэширование)
        private const string CorrectPassword = "123";

        public TeacherPasswordForm()
        {
            InitializeComponent();
            SetButtonRounded(btnSubmit);
            SetButtonRounded(backButton);
        }

        private void SetButtonRounded(Button button)
        {
            GraphicsPath path = new GraphicsPath();
            int radius = 15;
            path.AddArc(0, 0, radius, radius, 180, 90); // Верхний левый угол
            path.AddArc(button.Width - radius, 0, radius, radius, 270, 90); // Верхний правый угол
            path.AddArc(button.Width - radius, button.Height - radius, radius, radius, 0, 90); // Нижний правый угол
            path.AddArc(0, button.Height - radius, radius, radius, 90, 90); // Нижний левый угол
            path.CloseFigure();
            button.Region = new Region(path);
        }

        private void TeacherPasswordForm_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(
                this.ClientRectangle,
                Color.FromArgb(0, 123, 255), // Светло-синий
                Color.FromArgb(0, 200, 255), // Голубой
                LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == CorrectPassword)
            {
                var teacherDashboard = new TeacherDashboardForm();
                teacherDashboard.Show();
                this.Hide();
            }
            else
            {
                _failedAttempts++;
                MessageBox.Show("Неверный пароль.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (_failedAttempts >= MaxFailedAttempts)
                {
                    MessageBox.Show("Превышено количество попыток. Попробуйте позже.", "Блокировка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnSubmit.Enabled = false;
                }

                txtPassword.Clear();
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
            var roleSelectionForm = new RoleSelectionForm();
            roleSelectionForm.Show();
        }
    }
}