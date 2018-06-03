using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Client.Forms
{
    public partial class SpinnerView : Form
    {
        string title = null;
        public SpinnerView()
        {
            InitializeComponent();
        }
        public SpinnerView(string title)
        {
            InitializeComponent();
            this.title = title;
        }

        private void SpinnerView_Load(object sender, EventArgs e)
        {
            titleLabel.Text = title != null ? title : "";
            new Thread(()=>{
                Thread.CurrentThread.IsBackground = true;
                int position = 0;
                while (true)
                {
                    switch (position)
                    {
                        case 0: {
                                spinnerPictureBox.BackgroundImage = Properties.Resources.spinnerFirstFrame;
                                position++;
                                break;
                            }
                        case 1:
                            {
                                spinnerPictureBox.BackgroundImage = Properties.Resources.spinnerSecondFrame;
                                position++;
                                break;
                            }
                        case 2:
                            {
                                spinnerPictureBox.BackgroundImage = Properties.Resources.spinnerThirdFrame;
                                position++;
                                break;
                            }
                        case 3:
                            {
                                spinnerPictureBox.BackgroundImage = Properties.Resources.spinnerFourthFrame;
                                position++;
                                break;
                            }
                        case 4:
                            {
                                spinnerPictureBox.BackgroundImage = Properties.Resources.spinnerFifthFrame;
                                position++;
                                break;
                            }
                        case 5:
                            {
                                spinnerPictureBox.BackgroundImage = Properties.Resources.spinnerSixthFrame;
                                position++;
                                break;
                            }
                        case 6:
                            {
                                spinnerPictureBox.BackgroundImage = Properties.Resources.spinnerSeventhFrame;
                                position++;
                                break;
                            }
                        case 7:
                            {
                                spinnerPictureBox.BackgroundImage = Properties.Resources.spinnerEighthFrame;
                                position++;
                                break;
                            }
                    }
                    if(position == 8) position = 0;
                    Thread.Sleep(100);
                }
            }).Start();
        }
    }
}
