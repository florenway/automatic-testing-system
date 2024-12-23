using System;

namespace asd
{
    partial class TestForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblQuestion;  // Для отображения вопроса
        private System.Windows.Forms.TextBox txtAnswer;  // Для ввода ответа
        private System.Windows.Forms.Button btnSubmitAnswer; // Кнопка для отправки ответа
        private System.Windows.Forms.Button btnNextQuestion; // Кнопка для следующего вопроса
        private System.Windows.Forms.Button btnFinishTest; // Кнопка для завершения теста

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblQuestion = new System.Windows.Forms.Label();
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.btnSubmitAnswer = new System.Windows.Forms.Button();
            this.btnNextQuestion = new System.Windows.Forms.Button();
            this.btnFinishTest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestion.Location = new System.Drawing.Point(64, 50);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(300, 20);
            this.lblQuestion.TabIndex = 0;
            this.lblQuestion.Text = "Здесь будет отображаться вопрос";
            // 
            // txtAnswer
            // 
            this.txtAnswer.Location = new System.Drawing.Point(64, 100);
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.Size = new System.Drawing.Size(400, 20);
            this.txtAnswer.TabIndex = 1;
            
            // 
            // btnSubmitAnswer
            // 
            this.btnSubmitAnswer.Location = new System.Drawing.Point(64, 150);
            this.btnSubmitAnswer.Name = "btnSubmitAnswer";
            this.btnSubmitAnswer.Size = new System.Drawing.Size(120, 40);
            this.btnSubmitAnswer.TabIndex = 2;
            this.btnSubmitAnswer.Text = "Ответить";
            this.btnSubmitAnswer.UseVisualStyleBackColor = true;
            this.btnSubmitAnswer.Click += new System.EventHandler(this.BtnSubmitAnswer_Click);
            // 
            // btnNextQuestion
            // 
            this.btnNextQuestion.Location = new System.Drawing.Point(200, 150);
            this.btnNextQuestion.Name = "btnNextQuestion";
            this.btnNextQuestion.Size = new System.Drawing.Size(120, 40);
            this.btnNextQuestion.TabIndex = 3;
            this.btnNextQuestion.Text = "Следующий";
            this.btnNextQuestion.UseVisualStyleBackColor = true;
            this.btnNextQuestion.Click += new System.EventHandler(this.BtnNextQuestion_Click);
            // 
            // btnFinishTest
            // 
            this.btnFinishTest.Location = new System.Drawing.Point(340, 150);
            this.btnFinishTest.Name = "btnFinishTest";
            this.btnFinishTest.Size = new System.Drawing.Size(120, 40);
            this.btnFinishTest.TabIndex = 4;
            this.btnFinishTest.Text = "Завершить";
            this.btnFinishTest.UseVisualStyleBackColor = true;
            this.btnFinishTest.Click += new System.EventHandler(this.BtnFinishTest_Click);
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 250);
            this.Controls.Add(this.btnFinishTest);
            this.Controls.Add(this.btnNextQuestion);
            this.Controls.Add(this.btnSubmitAnswer);
            this.Controls.Add(this.txtAnswer);
            this.Controls.Add(this.lblQuestion);
            this.Name = "TestForm";
            this.Text = "Тестирование";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
