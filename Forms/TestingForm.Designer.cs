namespace Client.Forms
{
    partial class TestingForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.clientSurnameLabel = new System.Windows.Forms.Label();
            this.clientNameLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.fillingGroupBox = new System.Windows.Forms.GroupBox();
            this.fillingOptionTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.singleGroupBox = new System.Windows.Forms.GroupBox();
            this.singleChoiceFourthOptionRadioButton = new System.Windows.Forms.RadioButton();
            this.singleChoiceThirdOptionRadioButton = new System.Windows.Forms.RadioButton();
            this.singleChoiceSecondOptionRadioButton = new System.Windows.Forms.RadioButton();
            this.singleChoiceFirstOptionRadioButton = new System.Windows.Forms.RadioButton();
            this.QuestionField = new System.Windows.Forms.Label();
            this.multipleGroupBox = new System.Windows.Forms.GroupBox();
            this.multipleChoiceFourthOptionCheckBox = new System.Windows.Forms.CheckBox();
            this.multipleChoiceThirdOptionCheckBox = new System.Windows.Forms.CheckBox();
            this.multipleChoiceSecondOptionCheckBox = new System.Windows.Forms.CheckBox();
            this.multipleChoiceFirstOptionCheckBox = new System.Windows.Forms.CheckBox();
            this.qNext = new System.Windows.Forms.Button();
            this.currentQuestionId = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.totalQuetionsLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.fillingGroupBox.SuspendLayout();
            this.singleGroupBox.SuspendLayout();
            this.multipleGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.clientSurnameLabel);
            this.groupBox1.Controls.Add(this.clientNameLabel);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(20, 19);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(902, 84);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Информация о студенте";
            // 
            // clientSurnameLabel
            // 
            this.clientSurnameLabel.AutoSize = true;
            this.clientSurnameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clientSurnameLabel.ForeColor = System.Drawing.Color.Red;
            this.clientSurnameLabel.Location = new System.Drawing.Point(467, 35);
            this.clientSurnameLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.clientSurnameLabel.Name = "clientSurnameLabel";
            this.clientSurnameLabel.Size = new System.Drawing.Size(28, 24);
            this.clientSurnameLabel.TabIndex = 1;
            this.clientSurnameLabel.Text = "---";
            // 
            // clientNameLabel
            // 
            this.clientNameLabel.AutoSize = true;
            this.clientNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clientNameLabel.ForeColor = System.Drawing.Color.Red;
            this.clientNameLabel.Location = new System.Drawing.Point(10, 35);
            this.clientNameLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.clientNameLabel.Name = "clientNameLabel";
            this.clientNameLabel.Size = new System.Drawing.Size(28, 24);
            this.clientNameLabel.TabIndex = 0;
            this.clientNameLabel.Text = "---";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.fillingGroupBox);
            this.groupBox2.Controls.Add(this.singleGroupBox);
            this.groupBox2.Controls.Add(this.QuestionField);
            this.groupBox2.Controls.Add(this.multipleGroupBox);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(20, 113);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox2.Size = new System.Drawing.Size(1015, 356);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Вопрос";
            // 
            // fillingGroupBox
            // 
            this.fillingGroupBox.Controls.Add(this.fillingOptionTextBox);
            this.fillingGroupBox.Controls.Add(this.label1);
            this.fillingGroupBox.Location = new System.Drawing.Point(10, 148);
            this.fillingGroupBox.Name = "fillingGroupBox";
            this.fillingGroupBox.Size = new System.Drawing.Size(997, 200);
            this.fillingGroupBox.TabIndex = 3;
            this.fillingGroupBox.TabStop = false;
            this.fillingGroupBox.Text = "Заполнение";
            this.fillingGroupBox.Visible = false;
            // 
            // fillingOptionTextBox
            // 
            this.fillingOptionTextBox.Location = new System.Drawing.Point(5, 104);
            this.fillingOptionTextBox.Name = "fillingOptionTextBox";
            this.fillingOptionTextBox.Size = new System.Drawing.Size(983, 29);
            this.fillingOptionTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(969, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Запишите ответ:";
            // 
            // singleGroupBox
            // 
            this.singleGroupBox.Controls.Add(this.singleChoiceFourthOptionRadioButton);
            this.singleGroupBox.Controls.Add(this.singleChoiceThirdOptionRadioButton);
            this.singleGroupBox.Controls.Add(this.singleChoiceSecondOptionRadioButton);
            this.singleGroupBox.Controls.Add(this.singleChoiceFirstOptionRadioButton);
            this.singleGroupBox.Location = new System.Drawing.Point(10, 148);
            this.singleGroupBox.Name = "singleGroupBox";
            this.singleGroupBox.Size = new System.Drawing.Size(997, 200);
            this.singleGroupBox.TabIndex = 1;
            this.singleGroupBox.TabStop = false;
            this.singleGroupBox.Text = "Одиночный выбор";
            this.singleGroupBox.Visible = false;
            // 
            // singleChoiceFourthOptionRadioButton
            // 
            this.singleChoiceFourthOptionRadioButton.Location = new System.Drawing.Point(17, 155);
            this.singleChoiceFourthOptionRadioButton.Name = "singleChoiceFourthOptionRadioButton";
            this.singleChoiceFourthOptionRadioButton.Size = new System.Drawing.Size(974, 33);
            this.singleChoiceFourthOptionRadioButton.TabIndex = 3;
            this.singleChoiceFourthOptionRadioButton.TabStop = true;
            this.singleChoiceFourthOptionRadioButton.UseVisualStyleBackColor = true;
            // 
            // singleChoiceThirdOptionRadioButton
            // 
            this.singleChoiceThirdOptionRadioButton.Location = new System.Drawing.Point(17, 116);
            this.singleChoiceThirdOptionRadioButton.Name = "singleChoiceThirdOptionRadioButton";
            this.singleChoiceThirdOptionRadioButton.Size = new System.Drawing.Size(974, 33);
            this.singleChoiceThirdOptionRadioButton.TabIndex = 2;
            this.singleChoiceThirdOptionRadioButton.TabStop = true;
            this.singleChoiceThirdOptionRadioButton.UseVisualStyleBackColor = true;
            // 
            // singleChoiceSecondOptionRadioButton
            // 
            this.singleChoiceSecondOptionRadioButton.Location = new System.Drawing.Point(17, 77);
            this.singleChoiceSecondOptionRadioButton.Name = "singleChoiceSecondOptionRadioButton";
            this.singleChoiceSecondOptionRadioButton.Size = new System.Drawing.Size(974, 33);
            this.singleChoiceSecondOptionRadioButton.TabIndex = 1;
            this.singleChoiceSecondOptionRadioButton.TabStop = true;
            this.singleChoiceSecondOptionRadioButton.UseVisualStyleBackColor = true;
            // 
            // singleChoiceFirstOptionRadioButton
            // 
            this.singleChoiceFirstOptionRadioButton.Location = new System.Drawing.Point(17, 38);
            this.singleChoiceFirstOptionRadioButton.Name = "singleChoiceFirstOptionRadioButton";
            this.singleChoiceFirstOptionRadioButton.Size = new System.Drawing.Size(974, 33);
            this.singleChoiceFirstOptionRadioButton.TabIndex = 0;
            this.singleChoiceFirstOptionRadioButton.TabStop = true;
            this.singleChoiceFirstOptionRadioButton.UseVisualStyleBackColor = true;
            // 
            // QuestionField
            // 
            this.QuestionField.BackColor = System.Drawing.Color.IndianRed;
            this.QuestionField.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.QuestionField.Location = new System.Drawing.Point(10, 27);
            this.QuestionField.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.QuestionField.Name = "QuestionField";
            this.QuestionField.Size = new System.Drawing.Size(995, 118);
            this.QuestionField.TabIndex = 0;
            this.QuestionField.Text = "---";
            // 
            // multipleGroupBox
            // 
            this.multipleGroupBox.Controls.Add(this.multipleChoiceFourthOptionCheckBox);
            this.multipleGroupBox.Controls.Add(this.multipleChoiceThirdOptionCheckBox);
            this.multipleGroupBox.Controls.Add(this.multipleChoiceSecondOptionCheckBox);
            this.multipleGroupBox.Controls.Add(this.multipleChoiceFirstOptionCheckBox);
            this.multipleGroupBox.Location = new System.Drawing.Point(10, 148);
            this.multipleGroupBox.Name = "multipleGroupBox";
            this.multipleGroupBox.Size = new System.Drawing.Size(995, 200);
            this.multipleGroupBox.TabIndex = 2;
            this.multipleGroupBox.TabStop = false;
            this.multipleGroupBox.Text = "Множественный выбор";
            this.multipleGroupBox.Visible = false;
            // 
            // multipleChoiceFourthOptionCheckBox
            // 
            this.multipleChoiceFourthOptionCheckBox.Location = new System.Drawing.Point(17, 155);
            this.multipleChoiceFourthOptionCheckBox.Name = "multipleChoiceFourthOptionCheckBox";
            this.multipleChoiceFourthOptionCheckBox.Size = new System.Drawing.Size(974, 33);
            this.multipleChoiceFourthOptionCheckBox.TabIndex = 3;
            this.multipleChoiceFourthOptionCheckBox.Text = "checkBox4";
            this.multipleChoiceFourthOptionCheckBox.UseVisualStyleBackColor = true;
            // 
            // multipleChoiceThirdOptionCheckBox
            // 
            this.multipleChoiceThirdOptionCheckBox.Location = new System.Drawing.Point(17, 116);
            this.multipleChoiceThirdOptionCheckBox.Name = "multipleChoiceThirdOptionCheckBox";
            this.multipleChoiceThirdOptionCheckBox.Size = new System.Drawing.Size(974, 33);
            this.multipleChoiceThirdOptionCheckBox.TabIndex = 2;
            this.multipleChoiceThirdOptionCheckBox.Text = "checkBox3";
            this.multipleChoiceThirdOptionCheckBox.UseVisualStyleBackColor = true;
            // 
            // multipleChoiceSecondOptionCheckBox
            // 
            this.multipleChoiceSecondOptionCheckBox.Location = new System.Drawing.Point(17, 77);
            this.multipleChoiceSecondOptionCheckBox.Name = "multipleChoiceSecondOptionCheckBox";
            this.multipleChoiceSecondOptionCheckBox.Size = new System.Drawing.Size(974, 33);
            this.multipleChoiceSecondOptionCheckBox.TabIndex = 1;
            this.multipleChoiceSecondOptionCheckBox.Text = "checkBox2";
            this.multipleChoiceSecondOptionCheckBox.UseVisualStyleBackColor = true;
            // 
            // multipleChoiceFirstOptionCheckBox
            // 
            this.multipleChoiceFirstOptionCheckBox.Location = new System.Drawing.Point(17, 38);
            this.multipleChoiceFirstOptionCheckBox.Name = "multipleChoiceFirstOptionCheckBox";
            this.multipleChoiceFirstOptionCheckBox.Size = new System.Drawing.Size(974, 33);
            this.multipleChoiceFirstOptionCheckBox.TabIndex = 0;
            this.multipleChoiceFirstOptionCheckBox.Text = "checkBox1";
            this.multipleChoiceFirstOptionCheckBox.UseVisualStyleBackColor = true;
            // 
            // qNext
            // 
            this.qNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.qNext.Location = new System.Drawing.Point(798, 479);
            this.qNext.Margin = new System.Windows.Forms.Padding(5);
            this.qNext.Name = "qNext";
            this.qNext.Size = new System.Drawing.Size(237, 51);
            this.qNext.TabIndex = 3;
            this.qNext.Text = "ДАЛЕЕ";
            this.qNext.UseVisualStyleBackColor = true;
            this.qNext.Click += new System.EventHandler(this.qNext_Click);
            // 
            // currentQuestionId
            // 
            this.currentQuestionId.AutoSize = true;
            this.currentQuestionId.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.currentQuestionId.Location = new System.Drawing.Point(932, 50);
            this.currentQuestionId.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.currentQuestionId.Name = "currentQuestionId";
            this.currentQuestionId.Size = new System.Drawing.Size(40, 29);
            this.currentQuestionId.TabIndex = 4;
            this.currentQuestionId.Text = "---";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(967, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 29);
            this.label2.TabIndex = 5;
            this.label2.Text = "/";
            // 
            // totalQuetionsLabel
            // 
            this.totalQuetionsLabel.AutoSize = true;
            this.totalQuetionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.totalQuetionsLabel.Location = new System.Drawing.Point(982, 50);
            this.totalQuetionsLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.totalQuetionsLabel.Name = "totalQuetionsLabel";
            this.totalQuetionsLabel.Size = new System.Drawing.Size(40, 29);
            this.totalQuetionsLabel.TabIndex = 6;
            this.totalQuetionsLabel.Text = "---";
            // 
            // TestingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1046, 544);
            this.ControlBox = false;
            this.Controls.Add(this.totalQuetionsLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.currentQuestionId);
            this.Controls.Add(this.qNext);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TestingForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Тестирование";
            this.Load += new System.EventHandler(this.TestingForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.fillingGroupBox.ResumeLayout(false);
            this.fillingGroupBox.PerformLayout();
            this.singleGroupBox.ResumeLayout(false);
            this.multipleGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button qNext;
        private System.Windows.Forms.Label clientSurnameLabel;
        private System.Windows.Forms.Label clientNameLabel;
        private System.Windows.Forms.Label QuestionField;
        private System.Windows.Forms.Label currentQuestionId;
        private System.Windows.Forms.GroupBox singleGroupBox;
        private System.Windows.Forms.GroupBox multipleGroupBox;
        private System.Windows.Forms.GroupBox fillingGroupBox;
        private System.Windows.Forms.RadioButton singleChoiceFourthOptionRadioButton;
        private System.Windows.Forms.RadioButton singleChoiceThirdOptionRadioButton;
        private System.Windows.Forms.RadioButton singleChoiceSecondOptionRadioButton;
        private System.Windows.Forms.RadioButton singleChoiceFirstOptionRadioButton;
        private System.Windows.Forms.TextBox fillingOptionTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox multipleChoiceFourthOptionCheckBox;
        private System.Windows.Forms.CheckBox multipleChoiceThirdOptionCheckBox;
        private System.Windows.Forms.CheckBox multipleChoiceSecondOptionCheckBox;
        private System.Windows.Forms.CheckBox multipleChoiceFirstOptionCheckBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label totalQuetionsLabel;
    }
}