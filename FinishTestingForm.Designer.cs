namespace Test_OS
{
    partial class FinishTestingForm
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
            this.qExit = new System.Windows.Forms.Button();
            this.qResult = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.qF = new System.Windows.Forms.Label();
            this.qN = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // qExit
            // 
            this.qExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.qExit.Location = new System.Drawing.Point(323, 261);
            this.qExit.Margin = new System.Windows.Forms.Padding(6);
            this.qExit.Name = "qExit";
            this.qExit.Size = new System.Drawing.Size(186, 56);
            this.qExit.TabIndex = 0;
            this.qExit.Text = "ВЫХОД";
            this.qExit.UseVisualStyleBackColor = true;
            this.qExit.Click += new System.EventHandler(this.qExit_Click);
            // 
            // qResult
            // 
            this.qResult.AutoSize = true;
            this.qResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.qResult.ForeColor = System.Drawing.Color.Black;
            this.qResult.Location = new System.Drawing.Point(453, 136);
            this.qResult.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.qResult.Name = "qResult";
            this.qResult.Size = new System.Drawing.Size(40, 29);
            this.qResult.TabIndex = 1;
            this.qResult.Text = "---";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(10, 106);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(431, 66);
            this.label1.TabIndex = 2;
            this.label1.Text = "Тестирование закончено. Количество правильных ответов:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.qF);
            this.groupBox1.Controls.Add(this.qN);
            this.groupBox1.Location = new System.Drawing.Point(15, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox1.Size = new System.Drawing.Size(500, 85);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Информация о студенте";
            // 
            // qF
            // 
            this.qF.AutoSize = true;
            this.qF.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.qF.ForeColor = System.Drawing.Color.Red;
            this.qF.Location = new System.Drawing.Point(245, 35);
            this.qF.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.qF.Name = "qF";
            this.qF.Size = new System.Drawing.Size(28, 24);
            this.qF.TabIndex = 1;
            this.qF.Text = "---";
            // 
            // qN
            // 
            this.qN.AutoSize = true;
            this.qN.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.qN.ForeColor = System.Drawing.Color.Red;
            this.qN.Location = new System.Drawing.Point(12, 35);
            this.qN.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.qN.Name = "qN";
            this.qN.Size = new System.Drawing.Size(28, 24);
            this.qN.TabIndex = 0;
            this.qN.Text = "---";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(15, 184);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(500, 42);
            this.label2.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(26, 248);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 29);
            this.label3.TabIndex = 5;
            this.label3.Text = "ОЦЕНКА:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(182, 243);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 36);
            this.label4.TabIndex = 6;
            this.label4.Text = "---";
            // 
            // FinishTestingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(524, 331);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.qResult);
            this.Controls.Add(this.qExit);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FinishTestingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Результаты тестирования";
            this.Load += new System.EventHandler(this.FinishTestingForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button qExit;
        private System.Windows.Forms.Label qResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label qF;
        private System.Windows.Forms.Label qN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}