using System.Drawing;
using System.Windows.Forms;

namespace asd
{
    partial class AvailableTestsForm
    {
        private System.ComponentModel.IContainer components = null;
        private ComboBox comboBoxTests;
        private Button BtnConfirmTest;
        private Label lblChooseTest;

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
            this.comboBoxTests = new System.Windows.Forms.ComboBox();
            this.BtnConfirmTest = new System.Windows.Forms.Button();
            this.lblChooseTest = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxTests
            // 
            this.comboBoxTests.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTests.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold);
            this.comboBoxTests.FormattingEnabled = true;
            this.comboBoxTests.Location = new System.Drawing.Point(181, 41);
            this.comboBoxTests.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxTests.Name = "comboBoxTests";
            this.comboBoxTests.Size = new System.Drawing.Size(236, 31);
            this.comboBoxTests.TabIndex = 0;
            // 
            // BtnConfirmTest
            // 
            this.BtnConfirmTest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.BtnConfirmTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnConfirmTest.Font = new System.Drawing.Font("Comic Sans MS", 14F, System.Drawing.FontStyle.Bold);
            this.BtnConfirmTest.ForeColor = System.Drawing.Color.White;
            this.BtnConfirmTest.Location = new System.Drawing.Point(219, 96);
            this.BtnConfirmTest.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnConfirmTest.Name = "BtnConfirmTest";
            this.BtnConfirmTest.Size = new System.Drawing.Size(159, 41);
            this.BtnConfirmTest.TabIndex = 1;
            this.BtnConfirmTest.Text = "Подтвердить";
            this.BtnConfirmTest.UseVisualStyleBackColor = false;
            this.BtnConfirmTest.Click += new System.EventHandler(this.BtnConfirmTest_Click);
            // 
            // lblChooseTest
            // 
            this.lblChooseTest.AutoSize = true;
            this.lblChooseTest.BackColor = System.Drawing.Color.Transparent;
            this.lblChooseTest.Font = new System.Drawing.Font("Comic Sans MS", 14F, System.Drawing.FontStyle.Bold);
            this.lblChooseTest.ForeColor = System.Drawing.Color.White;
            this.lblChooseTest.Location = new System.Drawing.Point(12, 45);
            this.lblChooseTest.Name = "lblChooseTest";
            this.lblChooseTest.Size = new System.Drawing.Size(157, 27);
            this.lblChooseTest.TabIndex = 2;
            this.lblChooseTest.Text = "Выберите тест:";
            // 
            // AvailableTestsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 162);
            this.Controls.Add(this.lblChooseTest);
            this.Controls.Add(this.BtnConfirmTest);
            this.Controls.Add(this.comboBoxTests);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "AvailableTestsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Доступные тесты";
            this.Load += new System.EventHandler(this.AvailableTestsForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.AvailableTestsForm_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
