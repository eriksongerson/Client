namespace Client.Forms
{
    partial class SpinnerView
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
            this.spinnerPictureBox = new System.Windows.Forms.PictureBox();
            this.titleLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.spinnerPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // spinnerPictureBox
            // 
            this.spinnerPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spinnerPictureBox.BackgroundImage = global::Client.Properties.Resources.spinnerFirstFrame;
            this.spinnerPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.spinnerPictureBox.Location = new System.Drawing.Point(206, 0);
            this.spinnerPictureBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.spinnerPictureBox.Name = "spinnerPictureBox";
            this.spinnerPictureBox.Size = new System.Drawing.Size(98, 100);
            this.spinnerPictureBox.TabIndex = 0;
            this.spinnerPictureBox.TabStop = false;
            // 
            // titleLabel
            // 
            this.titleLabel.Location = new System.Drawing.Point(12, 105);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(488, 49);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "Надпись";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SpinnerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(512, 163);
            this.ControlBox = false;
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.spinnerPictureBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SpinnerView";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SpinnerView";
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.Load += new System.EventHandler(this.SpinnerView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spinnerPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox spinnerPictureBox;
        private System.Windows.Forms.Label titleLabel;
    }
}