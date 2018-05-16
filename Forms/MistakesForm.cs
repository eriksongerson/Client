using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Client.Helpers;
using Client.Models;

namespace Client.Forms
{
    public partial class MistakesForm : Form
    {

        public class AnswerVisualization : GroupBox
        {
            Answer Answer;

            Label questionLabel;
            Label firstOptionLabel;
            Label secondOptionLabel;
            Label thirdOptionLabel;
            Label fourthOptionLabel;

            Label fillingOptionLabel;
            Label yourFillingOptionAnswerLabel;

            public AnswerVisualization(Answer answer) : base()
            {
                this.Answer = answer;

                this.Text = "";
                questionLabel.Text = Answer.question.Name;

                var options = Answer.question.Options;

                switch (Answer.question.Type)
                {
                    case Models.Type.single:
                    case Models.Type.multiple:

                        firstOptionLabel.Text = options[0].option;
                        secondOptionLabel.Text = options[1].option;
                        thirdOptionLabel.Text = options[2].option;
                        fourthOptionLabel.Text = options[3].option;

                        break;
                    case Models.Type.filling:
                        fillingOptionLabel.Text = options[0].option;
                        break;
                }
            }
        }

        public MistakesForm()
        {
            InitializeComponent();
        }

        private void MistakesForm_Load(object sender, EventArgs e)
        {
            List<Answer> answers = QuestionHelper.answers;
            List<Answer> wrongAnswers = GetWrongAnswers(answers);

            foreach (var item in wrongAnswers)
            {
                AnswerVisualization answerVisualization = new AnswerVisualization(item);
                flowLayoutPanel1.Controls.Add(answerVisualization);
            }

        }

        private List<Answer> GetWrongAnswers(List<Answer> answers)
        {
            List<Answer> wrongAnswers = new List<Answer>();

            foreach (Answer answer in answers)
            {
                switch (answer.question.Type)
                {
                    case Models.Type.single:
                        {
                            foreach (Option option in answer.question.Options)
                            {
                                if(option == answer.choosen[0])
                                {
                                    wrongAnswers.Add(answer);
                                    break;
                                }
                            }
                            break;
                        }
                    case Models.Type.multiple:
                        {
                            if(!answer.choosen.Equals(answer.question.Options)){
                                wrongAnswers.Add(answer);
                                break;
                            }
                            break;
                        }
                    case Models.Type.filling:
                        {
                            if(answer.choosen[0].option.ToLower().TrimEnd().TrimStart() == answer.question.Options[0].option.ToLower().TrimEnd().TrimStart())
                            {
                                wrongAnswers.Add(answer);
                                break;
                            }
                            break;
                        }
                }
            }

            return wrongAnswers;
        }

    }
}
