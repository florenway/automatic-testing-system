using System;
using System.Drawing;
using System.Windows.Forms;

namespace asd
{
    partial class RoleSelectionForm
    {
        private System.ComponentModel.IContainer components = null;
        private Button BtnTeacher;
        private Button BtnStudent;
        private Label label1;

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
            this.BtnTeacher = new System.Windows.Forms.Button();
            this.BtnStudent = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnTeacher
            // 
            this.BtnTeacher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.BtnTeacher.FlatAppearance.BorderSize = 0;
            this.BtnTeacher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnTeacher.Font = new System.Drawing.Font("Comic Sans MS", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.BtnTeacher.ForeColor = System.Drawing.Color.White;
            this.BtnTeacher.Location = new System.Drawing.Point(103, 173);
            this.BtnTeacher.Name = "BtnTeacher";
            this.BtnTeacher.Size = new System.Drawing.Size(171, 69);
            this.BtnTeacher.TabIndex = 0;
            this.BtnTeacher.Text = "Учитель";
            this.BtnTeacher.UseVisualStyleBackColor = false;
            this.BtnTeacher.Click += new System.EventHandler(this.BtnTeacher_Click);
            this.BtnTeacher.MouseEnter += new System.EventHandler(this.BtnTeacher_MouseEnter);
            this.BtnTeacher.MouseLeave += new System.EventHandler(this.BtnTeacher_MouseLeave);
            // 
            // BtnStudent
            // 
            this.BtnStudent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.BtnStudent.FlatAppearance.BorderSize = 0;
            this.BtnStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnStudent.Font = new System.Drawing.Font("Comic Sans MS", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.BtnStudent.ForeColor = System.Drawing.Color.White;
            this.BtnStudent.Location = new System.Drawing.Point(383, 173);
            this.BtnStudent.Name = "BtnStudent";
            this.BtnStudent.Size = new System.Drawing.Size(171, 69);
            this.BtnStudent.TabIndex = 1;
            this.BtnStudent.Text = "Студент";
            this.BtnStudent.UseVisualStyleBackColor = false;
            this.BtnStudent.Click += new System.EventHandler(this.BtnStudent_Click);
            this.BtnStudent.MouseEnter += new System.EventHandler(this.BtnStudent_MouseEnter);
            this.BtnStudent.MouseLeave += new System.EventHandler(this.BtnStudent_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(156, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(357, 45);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выберите свою роль";
            // 
            // RoleSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 303);
            this.Controls.Add(this.BtnTeacher);
            this.Controls.Add(this.BtnStudent);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "RoleSelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выбор роли";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.RoleSelectionForm_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
