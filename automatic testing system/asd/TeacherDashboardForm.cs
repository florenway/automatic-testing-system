using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace asd
{
    public partial class TeacherDashboardForm : Form
    {
        private const int BorderRadius = 20; // Радиус закругления кнопок

        public TeacherDashboardForm()
        {
            InitializeComponent();

            // Закругляем кнопки
            SetButtonRounded(btnCreateTest);
            SetButtonRounded(btnViewResults);
        }

        private void SetButtonRounded(Button button)
        {
            GraphicsPath path = new GraphicsPath();
            int radius = BorderRadius;

            path.AddArc(0, 0, radius, radius, 180, 90); // Верхний левый угол
            path.AddArc(button.Width - radius, 0, radius, radius, 270, 90); // Верхний правый угол
            path.AddArc(button.Width - radius, button.Height - radius, radius, radius, 0, 90); // Нижний правый угол
            path.AddArc(0, button.Height - radius, radius, radius, 90, 90); // Нижний левый угол
            path.CloseFigure();

            button.Region = new Region(path); // Применяем закруглённую область к кнопке
        }

        private void TeacherDashboardForm_Paint(object sender, PaintEventArgs e)
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

        private void BtnCreateTest_Click(object sender, EventArgs e)
        {
            // Открытие формы для создания теста
            var testCreationForm = new TestCreationForm();
            testCreationForm.Show();
            this.Hide();
        }

        private void BtnViewResults_Click(object sender, EventArgs e)
        {
            // Открытие формы для просмотра результатов
            var resultsForm = new TestResultsForm();
            resultsForm.Show();
            this.Hide();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            var result = MessageBox.Show(
                "Вы уверены, что хотите выйти?",
                "Закрытие формы",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true; // Отменяем закрытие формы
            }

            base.OnFormClosing(e);
        }
    }
}