namespace Client
{
    partial class TestingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.clientSurnameLabel = new System.Windows.Forms.Label();
            this.clientNameLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.q4 = new System.Windows.Forms.RadioButton();
            this.q3 = new System.Windows.Forms.RadioButton();
            this.q2 = new System.Windows.Forms.RadioButton();
            this.q1 = new System.Windows.Forms.RadioButton();
            this.QuestionField = new System.Windows.Forms.Label();
            this.qNext = new System.Windows.Forms.Button();
            this.currentQuestionId = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.groupBox1.Text = "���������� � ��������";
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
            this.groupBox2.Controls.Add(this.q4);
            this.groupBox2.Controls.Add(this.q3);
            this.groupBox2.Controls.Add(this.q2);
            this.groupBox2.Controls.Add(this.q1);
            this.groupBox2.Controls.Add(this.QuestionField);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(20, 113);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox2.Size = new System.Drawing.Size(1015, 303);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "������";
            // 
            // q4
            // 
            this.q4.AutoSize = true;
            this.q4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.q4.Location = new System.Drawing.Point(10, 264);
            this.q4.Margin = new System.Windows.Forms.Padding(5);
            this.q4.Name = "q4";
            this.q4.Size = new System.Drawing.Size(42, 29);
            this.q4.TabIndex = 4;
            this.q4.TabStop = true;
            this.q4.Text = "4";
            this.q4.UseVisualStyleBackColor = true;
            // 
            // q3
            // 
            this.q3.AutoSize = true;
            this.q3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.q3.Location = new System.Drawing.Point(10, 226);
            this.q3.Margin = new System.Windows.Forms.Padding(5);
            this.q3.Name = "q3";
            this.q3.Size = new System.Drawing.Size(42, 29);
            this.q3.TabIndex = 3;
            this.q3.TabStop = true;
            this.q3.Text = "3";
            this.q3.UseVisualStyleBackColor = true;
            // 
            // q2
            // 
            this.q2.AutoSize = true;
            this.q2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.q2.Location = new System.Drawing.Point(10, 188);
            this.q2.Margin = new System.Windows.Forms.Padding(5);
            this.q2.Name = "q2";
            this.q2.Size = new System.Drawing.Size(42, 29);
            this.q2.TabIndex = 2;
            this.q2.TabStop = true;
            this.q2.Text = "2";
            this.q2.UseVisualStyleBackColor = true;
            // 
            // q1
            // 
            this.q1.AutoSize = true;
            this.q1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.q1.Location = new System.Drawing.Point(10, 150);
            this.q1.Margin = new System.Windows.Forms.Padding(5);
            this.q1.Name = "q1";
            this.q1.Size = new System.Drawing.Size(42, 29);
            this.q1.TabIndex = 1;
            this.q1.TabStop = true;
            this.q1.Text = "1";
            this.q1.UseVisualStyleBackColor = true;
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
            // qNext
            // 
            this.qNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.qNext.Location = new System.Drawing.Point(798, 426);
            this.qNext.Margin = new System.Windows.Forms.Padding(5);
            this.qNext.Name = "qNext";
            this.qNext.Size = new System.Drawing.Size(237, 51);
            this.qNext.TabIndex = 3;
            this.qNext.Text = "�����";
            this.qNext.UseVisualStyleBackColor = true;
            this.qNext.Click += new System.EventHandler(this.qNext_Click);
            // 
            // currentQuestionId
            // 
            this.currentQuestionId.AutoSize = true;
            this.currentQuestionId.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.currentQuestionId.Location = new System.Drawing.Point(958, 50);
            this.currentQuestionId.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.currentQuestionId.Name = "currentQuestionId";
            this.currentQuestionId.Size = new System.Drawing.Size(40, 29);
            this.currentQuestionId.TabIndex = 4;
            this.currentQuestionId.Text = "---";
            // 
            // TestingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1046, 488);
            this.Controls.Add(this.currentQuestionId);
            this.Controls.Add(this.qNext);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TestingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "������������";
            this.Load += new System.EventHandler(this.TestingForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.RadioButton q1;
        private System.Windows.Forms.RadioButton q4;
        private System.Windows.Forms.RadioButton q3;
        private System.Windows.Forms.RadioButton q2;
        private System.Windows.Forms.Label currentQuestionId;
    }
}