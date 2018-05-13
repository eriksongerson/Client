using System;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Generic;

using Client.Helpers;
using Client.Models;
using Newtonsoft.Json;

namespace Client.Forms
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

        private void CheckAnswers()
        {
            singleGroupBox.Visible = false;
            multipleGroupBox.Visible = false;
            fillingGroupBox.Visible = false;

            Models.Type type = CurrentQuestion.Type;
            List<Option> options = CurrentQuestion.Options;

            switch (type)
            {
                case Models.Type.single:
                    {

                        if(singleChoiceFirstOptionRadioButton.Checked && options[0].isRight 
                            || singleChoiceSecondOptionRadioButton.Checked && options[1].isRight
                            || singleChoiceThirdOptionRadioButton.Checked && options[2].isRight
                            || singleChoiceFourthOptionRadioButton.Checked && options[3].isRight)
                            QuestionHelper.RightQuantity++;

                        break;
                    }
                case Models.Type.multiple:
                    {
                        if(multipleChoiceFirstOptionCheckBox.Checked == options[0].isRight
                            && multipleChoiceSecondOptionCheckBox.Checked == options[1].isRight 
                            && multipleChoiceThirdOptionCheckBox.Checked == options[2].isRight
                            && multipleChoiceFourthOptionCheckBox.Checked == options[3].isRight)
                            QuestionHelper.RightQuantity++;

                        break;
                    }
                case Models.Type.filling:
                    {
                        if(fillingOptionTextBox.Text.ToLower() == options[0].option.ToLower())
                            QuestionHelper.RightQuantity++;
                        
                        break;
                    }
            }
        }

        private List<Option> GetChoosenOptions()
        {
            List<Option> choosenOptions = new List<Option>();

            Models.Type type = CurrentQuestion.Type;
            List<Option> options = CurrentQuestion.Options;

            switch (type)
            {
                case Models.Type.single:
                    {
                        if(singleChoiceFirstOptionRadioButton.Checked) choosenOptions.Add(options[0]);
                        if(singleChoiceSecondOptionRadioButton.Checked) choosenOptions.Add(options[1]);
                        if(singleChoiceThirdOptionRadioButton.Checked) choosenOptions.Add(options[2]);
                        if(singleChoiceFourthOptionRadioButton.Checked) choosenOptions.Add(options[3]);

                        break;
                    }
                case Models.Type.multiple:
                    {
                        if(multipleChoiceFirstOptionCheckBox.Checked) choosenOptions.Add(options[0]);
                        if(multipleChoiceSecondOptionCheckBox.Checked) choosenOptions.Add(options[1]);
                        if(multipleChoiceThirdOptionCheckBox.Checked) choosenOptions.Add(options[2]);
                        if(multipleChoiceFourthOptionCheckBox.Checked) choosenOptions.Add(options[3]);

                        break;
                    }
                case Models.Type.filling:
                    {
                        Option option = new Option()
                        {
                            option = fillingOptionTextBox.Text,
                        };
                        choosenOptions.Add(option);

                        break;
                    }
            }

            return choosenOptions;
        }

        private void qNext_Click(object sender, EventArgs e)
        {
            CheckAnswers();
            List<Option> choosen = GetChoosenOptions();

            Answer answer = new Answer()
            {
                question = currentQuestion,
                choosen = choosen,
            };

            QuestionHelper.answers.Add(answer);

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

             CurrentQuestion = QuestionHelper.GetNextQuestion();
        }

        private void TestingForm_Load(object sender, EventArgs e)
        {
            CurrentQuestion = QuestionHelper.GetNextQuestion();

            clientNameLabel.Text = QuestionHelper.client.name;
            clientSurnameLabel.Text = QuestionHelper.client.surname;
        }

        private void ClearAndHide()
        {
            singleChoiceFirstOptionRadioButton.Text = "";
            singleChoiceSecondOptionRadioButton.Text = "";
            singleChoiceThirdOptionRadioButton.Text = "";
            singleChoiceFourthOptionRadioButton.Text = "";

            multipleChoiceFirstOptionCheckBox.Text = "";
            multipleChoiceSecondOptionCheckBox.Text = "";
            multipleChoiceThirdOptionCheckBox.Text = "";
            multipleChoiceFourthOptionCheckBox.Text = "";

            fillingOptionTextBox.Text = "";

            singleGroupBox.Visible = false;
            multipleGroupBox.Visible = false;
            fillingGroupBox.Visible = false;
        }

        void Visual()
        {
            ClearAndHide();

            Models.Type type = CurrentQuestion.Type;
            List<Option> options = CurrentQuestion.Options;

            switch (type)
            {
                case Models.Type.single:
                    {
                        singleGroupBox.Visible = true;

                        singleChoiceFirstOptionRadioButton.Text = options[0];
                        singleChoiceSecondOptionRadioButton.Text = options[1];
                        singleChoiceThirdOptionRadioButton.Text = options[2];
                        singleChoiceFourthOptionRadioButton.Text = options[3];

                        break;
                    }
                case Models.Type.multiple:
                    {
                        multipleGroupBox.Visible = true;
                        
                        multipleChoiceFirstOptionCheckBox.Text = options[0];
                        multipleChoiceSecondOptionCheckBox.Text = options[1];
                        multipleChoiceThirdOptionCheckBox.Text = options[2];
                        multipleChoiceFourthOptionCheckBox.Text = options[3];

                        break;
                    }
                case Models.Type.filling:
                    {
                        fillingGroupBox.Visible = true;

                        break;
                    }
            }

            QuestionField.Text = CurrentQuestion.Name;
            currentQuestionId.Text = $"{QuestionHelper.currentQuestionId}"; 
        }
    }
}