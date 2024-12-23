using System;
using System.Windows.Forms;

namespace asd
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    public partial class RoleSelectionForm : Form
    {
        public RoleSelectionForm()
        {
            InitializeComponent();
            SetButtonRounded(BtnTeacher);
            SetButtonRounded(BtnStudent);
        }

        private void RoleSelectionForm_Paint(object sender, PaintEventArgs e)
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

        private void BtnTeacher_MouseEnter(object sender, EventArgs e)
        {
            BtnTeacher.BackColor = Color.FromArgb(0, 100, 230); // Затемнение цвета
        }

        private void BtnTeacher_MouseLeave(object sender, EventArgs e)
        {
            BtnTeacher.BackColor = Color.FromArgb(0, 123, 255); // Возврат цвета
        }

        private void BtnStudent_MouseEnter(object sender, EventArgs e)
        {
            BtnStudent.BackColor = Color.FromArgb(0, 100, 230); // Затемнение цвета
        }

        private void BtnStudent_MouseLeave(object sender, EventArgs e)
        {
            BtnStudent.BackColor = Color.FromArgb(0, 123, 255); // Возврат цвета
        }

        private void BtnTeacher_Click(object sender, EventArgs e)
        {
            var existingForm = Application.OpenForms["TeacherPasswordForm"];
            if (existingForm == null)
            {
                var teacherForm = new TeacherPasswordForm();
                teacherForm.Show();
            }
            this.Hide();
        }

        private void BtnStudent_Click(object sender, EventArgs e)
        {
            var existingForm = Application.OpenForms["StudentForm"];
            if (existingForm == null)
            {
                var studentForm = new StudentForm();
                studentForm.Show();
            }
            this.Hide();
        }
    }
}
