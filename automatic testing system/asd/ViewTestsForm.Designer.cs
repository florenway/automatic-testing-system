using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace asd
{
    partial class ViewTestsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox listBoxTests;
        private System.Windows.Forms.ListBox listBoxQuestions;
        private System.Windows.Forms.ListBox listBoxAnswers;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void ViewTestsForm_Paint(object sender, PaintEventArgs e)
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
        private void InitializeComponent()
        {
            this.listBoxTests = new System.Windows.Forms.ListBox();
            this.listBoxQuestions = new System.Windows.Forms.ListBox();
            this.listBoxAnswers = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxTests
            // 
            this.listBoxTests.Location = new System.Drawing.Point(83, 45);
            this.listBoxTests.Name = "listBoxTests";
            this.listBoxTests.Size = new System.Drawing.Size(360, 160);
            this.listBoxTests.TabIndex = 0;
            this.listBoxTests.SelectedIndexChanged += new System.EventHandler(this.ListBoxTests_SelectedIndexChanged);
            // 
            // listBoxQuestions
            // 
            this.listBoxQuestions.Location = new System.Drawing.Point(12, 250);
            this.listBoxQuestions.Name = "listBoxQuestions";
            this.listBoxQuestions.Size = new System.Drawing.Size(238, 160);
            this.listBoxQuestions.TabIndex = 1;
            // 
            // listBoxAnswers
            // 
            this.listBoxAnswers.Location = new System.Drawing.Point(282, 250);
            this.listBoxAnswers.Name = "listBoxAnswers";
            this.listBoxAnswers.Size = new System.Drawing.Size(225, 160);
            this.listBoxAnswers.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(85, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 27);
            this.label1.TabIndex = 3;
            this.label1.Text = "Вопросы:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(342, 220);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 27);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ответы:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(178, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 27);
            this.label3.TabIndex = 5;
            this.label3.Text = "Список тестов";
            // 
            // backButton
            // 
            this.backButton.FlatAppearance.BorderSize = 0;
            this.backButton.Location = new System.Drawing.Point(216, 434);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(100, 40);
            this.backButton.TabIndex = 6;
            this.backButton.Text = "Назад";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // ViewTestsForm
            // 
            this.ClientSize = new System.Drawing.Size(519, 500);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxAnswers);
            this.Controls.Add(this.listBoxQuestions);
            this.Controls.Add(this.listBoxTests);
            this.Name = "ViewTestsForm";
            this.Text = "Просмотр тестов";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ViewTestsForm_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button backButton;
    }
}
