namespace Client.Forms
{
    partial class MainForm
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
            this.qEndApp = new System.Windows.Forms.Button();
            this.qFamStud = new System.Windows.Forms.TextBox();
            this.qStartTest = new System.Windows.Forms.Button();
            this.qNameStud = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groups—omboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // qEndApp
            // 
            this.qEndApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.qEndApp.Location = new System.Drawing.Point(12, 272);
            this.qEndApp.Margin = new System.Windows.Forms.Padding(6);
            this.qEndApp.Name = "qEndApp";
            this.qEndApp.Size = new System.Drawing.Size(179, 39);
            this.qEndApp.TabIndex = 0;
            this.qEndApp.Text = "¬˚ıÓ‰";
            this.qEndApp.UseVisualStyleBackColor = true;
            this.qEndApp.Click += new System.EventHandler(this.qEndApp_Click);
            // 
            // qFamStud
            // 
            this.qFamStud.BackColor = System.Drawing.SystemColors.Window;
            this.qFamStud.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.qFamStud.Location = new System.Drawing.Point(120, 24);
            this.qFamStud.Margin = new System.Windows.Forms.Padding(6);
            this.qFamStud.MaxLength = 25;
            this.qFamStud.Name = "qFamStud";
            this.qFamStud.Size = new System.Drawing.Size(423, 29);
            this.qFamStud.TabIndex = 1;
            this.qFamStud.TextChanged += new System.EventHandler(this.qFamStud_TextChanged);
            // 
            // qStartTest
            // 
            this.qStartTest.Enabled = false;
            this.qStartTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.qStartTest.Location = new System.Drawing.Point(392, 272);
            this.qStartTest.Margin = new System.Windows.Forms.Padding(6);
            this.qStartTest.Name = "qStartTest";
            this.qStartTest.Size = new System.Drawing.Size(179, 39);
            this.qStartTest.TabIndex = 2;
            this.qStartTest.Text = "Õ‡˜‡Ú¸ ÚÂÒÚ";
            this.qStartTest.UseVisualStyleBackColor = true;
            this.qStartTest.Click += new System.EventHandler(this.qStartTest_Click);
            // 
            // qNameStud
            // 
            this.qNameStud.BackColor = System.Drawing.SystemColors.Window;
            this.qNameStud.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.qNameStud.Location = new System.Drawing.Point(120, 65);
            this.qNameStud.Margin = new System.Windows.Forms.Padding(6);
            this.qNameStud.MaxLength = 15;
            this.qNameStud.Name = "qNameStud";
            this.qNameStud.Size = new System.Drawing.Size(423, 29);
            this.qNameStud.TabIndex = 3;
            this.qNameStud.TextChanged += new System.EventHandler(this.qNameStud_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox1.Controls.Add(this.groups—omboBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.qFamStud);
            this.groupBox1.Controls.Add(this.qNameStud);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(12, 77);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox1.Size = new System.Drawing.Size(559, 151);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // groups—omboBox
            // 
            this.groups—omboBox.DisplayMember = "name";
            this.groups—omboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.groups—omboBox.FormattingEnabled = true;
            this.groups—omboBox.Location = new System.Drawing.Point(121, 109);
            this.groups—omboBox.Name = "groups—omboBox";
            this.groups—omboBox.Size = new System.Drawing.Size(422, 28);
            this.groups—omboBox.TabIndex = 17;
            this.groups—omboBox.ValueMember = "id";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(9, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 27);
            this.label6.TabIndex = 16;
            this.label6.Text = "√ÛÔÔ‡";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(9, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 27);
            this.label3.TabIndex = 14;
            this.label3.Text = "»Ïˇ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(9, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 28);
            this.label2.TabIndex = 14;
            this.label2.Text = "‘‡ÏËÎËˇ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.Window;
            this.comboBox1.DisplayMember = "name";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(132, 9);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(439, 28);
            this.comboBox1.TabIndex = 10;
            this.comboBox1.ValueMember = "id";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.BackColor = System.Drawing.SystemColors.Window;
            this.comboBox2.DisplayMember = "name";
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.Enabled = false;
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(132, 43);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(439, 28);
            this.comboBox2.TabIndex = 11;
            this.comboBox2.ValueMember = "id";
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 28);
            this.label1.TabIndex = 12;
            this.label1.Text = "œÂ‰ÏÂÚ:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 28);
            this.label4.TabIndex = 13;
            this.label4.Text = "“ÂÏ‡:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 237);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(164, 26);
            this.label5.TabIndex = 14;
            this.label5.Text = "IP-‡‰ÂÒ ÒÂ‚Â‡:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(186, 237);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(385, 26);
            this.textBox1.TabIndex = 15;
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(589, 326);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.qStartTest);
            this.Controls.Add(this.qEndApp);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "œÓ„‡ÏÏ‡ ÚÂÒÚËÓ‚‡ÌËˇ ÒÚÛ‰ÂÌÚÓ‚";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button qEndApp;
        private System.Windows.Forms.TextBox qFamStud;
        private System.Windows.Forms.Button qStartTest;
        private System.Windows.Forms.TextBox qNameStud;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.ComboBox groups—omboBox;
    }
}

