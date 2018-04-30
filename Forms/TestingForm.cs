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
using Client.Models;
using Newtonsoft.Json;

namespace Client
{
    public partial class TestingForm : Form
    {

        //TODO: 0-23="2"  24-31="3"  32-40="4"  41-46="5";
        //TODO: InactiveCaptionText;

        int Number = 0;
        Thread WT = null;

        private Question currentQuestion;
        Question CurrentQuestion
        {
            set
            {
                currentQuestion = value;
                if(currentQuestion == null)
                {
                    FinishTestingForm FinishTest = new FinishTestingForm();
                    Hide();
                    if (FinishTest.ShowDialog() != DialogResult.OK)
                        Close();
                }
                else
                {
                    Visual();
                }
            }
            get
            {
                return currentQuestion;
            }
        }

        private static bool isAnswerSent = false;
        private static string message = null;

        public TestingForm()
        {
            InitializeComponent();
        }

        private void qNext_Click(object sender, EventArgs e)
        {

            CurrentQuestion = QuestionHelper.GetNextQuestion();

            int Choosen = 0;

            if (q1.Checked) Choosen = 1;
            if (q2.Checked) Choosen = 2;
            if (q3.Checked) Choosen = 3;
            if (q4.Checked) Choosen = 4;

            Answer answer = new Answer()
            {
                question = currentQuestion,
                choosen = Choosen,
            };

            Request request = new Request()
            {
                request = "answer",
                client = QuestionHelper.client,
                body = JsonConvert.SerializeObject(answer, Formatting.Indented),
            };

            new Thread(() => 
            {
                SocketHelper.DoRequest(request, null);
            }).Start(); 

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

            CurrentQuestion = QuestionHelper.GetNextQuestion();

            //qN.Text = Client.Get_StudentName();
            //qF.Text = Client.Get_StudentSurname();
            //Number = Client.Get_TotalQuestions();
        }

        void Visual()
        {
                q1.Checked = false;
                q2.Checked = false;
                q3.Checked = false;
                q4.Checked = false;

                qQ.Text = CurrentQuestion.Name;
                q1.Text = CurrentQuestion.FirstOption;
                q2.Text = CurrentQuestion.SecondOption;
                q3.Text = CurrentQuestion.ThirdOption;
                q4.Text = CurrentQuestion.FourthOption;
                qNum.Text = Convert.ToString(Number + 1); 
        }
    }
}