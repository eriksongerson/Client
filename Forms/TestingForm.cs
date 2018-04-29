using System;
//using System.Collections.Generic;
using System.ComponentModel;
//using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

using Client.Helpers;

namespace Client
{
    public partial class TestingForm : Form
    {

        //Õ¿ƒŒ: 0-23="2"  24-31="3"  32-40="4"  41-46="5";
        //Õ¿ƒŒ: InactiveCaptionText;

        int Number = 0;
        Thread WT = null;

        private static bool isAnswerSent = false;
        private static string message = null;

        public TestingForm()
        {
            InitializeComponent();
        }

        private void qNext_Click(object sender, EventArgs e)
        {
            //Number--;
            //Visual();
            //int Vibor=0;
            
            //if (q1.Checked == true) { Vibor = 1; };
            //if (q2.Checked == true) { Vibor = 2; };
            //if (q3.Checked == true) { Vibor = 3; };
            //if (q4.Checked == true) { Vibor = 4; };

            //if (Vibor == Convert.ToInt32(QuestionHelper.Questions[Number+1]))
            //{
            //    Client.Set_RightQuantity(Client.Get_RightQuantity() + 1);
            //}

            //message = Client.Get_IP() + ":" + Client.Get_PCname() + ":" + "Answer:" + Convert.ToString(Client.Get_TotalQuestions() - Number) + ":" + Client.Get_TotalQuestions() + ":" + (Vibor == Convert.ToInt32(Client.Questions[Number + 1, 6]));
            //isAnswerSent = true;

            //if (Number == -1)
            //{
            //    WT.Abort();
            //    while (WT.IsAlive) ;
            //    FinishTestingForm FinishTest = new FinishTestingForm();
            //    this.Hide();
            //    FinishTest.Show();
            //}

            //Visual();
            
        }

        private void TestingForm_Load(object sender, EventArgs e)
        {
            //q1.Checked = false;
            //q2.Checked = false;
            //q3.Checked = false;
            //q4.Checked = false;
            //Visual();
            //qN.Text = Client.Get_StudentName();
            //qF.Text = Client.Get_StudentSurname();
            //Number = Client.Get_TotalQuestions();
        }

        void Visual()
        {
            //try
            //{
            //    qQ.Text = Client.Questions[Number, 1].ToString();
            //    q1.Text = Client.Questions[Number, 2].ToString();
            //    q2.Text = Client.Questions[Number, 3].ToString();
            //    q3.Text = Client.Questions[Number, 4].ToString();
            //    q4.Text = Client.Questions[Number, 5].ToString();
            //    qNum.Text = Convert.ToString(Number+1);
            //}
            //catch { }            
        }
    }
}