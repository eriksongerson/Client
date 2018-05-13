using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Client.Helpers;
using Client.Models;

namespace Client.Forms
{
    public partial class MistakesForm : Form
    {
        public MistakesForm()
        {
            InitializeComponent();
        }

        private void MistakesForm_Load(object sender, EventArgs e)
        {
            List<Answer> answers = QuestionHelper.answers;
            List<Answer> wrongAnswers = GetWrongAnswers(answers);

            

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
