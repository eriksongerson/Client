using System;
using System.Windows.Forms;
using System.Threading;

using Newtonsoft.Json;
using Client.Helpers;
using Client.Models;

namespace Client.Forms
{
    public partial class FinishTestingForm : Form
    {

        class disciplineWithMark
        {
            public Subject subject;
            public Theme theme;
            public int mark;
        }
        
        public enum Mark : int
        {
            Perfect = 5,
            Good = 4,
            Normal = 3,
            Bad = 2
        }

        public Mark GetMark(double Percent)
        {
            Mark mark = Mark.Bad;

            if (Percent >= 0.5 && Percent < 0.75)
                mark = Mark.Normal;
            if (Percent >= 0.75 && Percent < 0.875)
                mark = Mark.Good;
            if (Percent >= 0.875 && Percent <= 100)
                mark = Mark.Perfect;

            return mark;
        }

        public FinishTestingForm()
        {
            InitializeComponent();
        }

        private void qExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FinishTestingForm_Load(object sender, EventArgs e)
        {
            QuestionHelper.isTesting = false;

            qF.Text = QuestionHelper.client.surname;
            qN.Text = QuestionHelper.client.name;
            qResult.Text = QuestionHelper.RightQuantity.ToString();
            

            double Percent = (double)QuestionHelper.RightQuantity / (double)QuestionHelper.TotalQuestions;
            Mark mark = GetMark(Percent);

            label5.Text = $"{Percent * 100}%";
            label4.Text = $"{(int)mark}";

            disciplineWithMark disciplineWithMark = new disciplineWithMark()
            {
                subject = QuestionHelper.currentSubject,
                theme = QuestionHelper.currentTheme,
                mark = (int)mark,
            };

            Request request = new Request()
            {
                request = "done",
                client = QuestionHelper.client,
                body = JsonConvert.SerializeObject(disciplineWithMark),
            };

            new Thread(() => {
                Thread.CurrentThread.IsBackground = true;
                new SocketHelper().DoRequest(request, null);
            }).Start();

            if(QuestionHelper.RightQuantity == QuestionHelper.TotalQuestions)
            {
                mistakesButton.Enabled = false;
            }
        }

        private void mistakesButton_Click(object sender, EventArgs e)
        {
            MistakesForm mistakesForm = new MistakesForm();
            mistakesForm.ShowDialog();
        }
    }
}