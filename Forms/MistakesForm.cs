using System;
using System.Collections.Generic;
using System.Drawing;
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

                this.questionLabel = new Label();
                this.firstOptionLabel = new Label();
                this.secondOptionLabel = new Label();
                this.thirdOptionLabel = new Label();
                this.fourthOptionLabel = new Label();
                this.fillingOptionLabel = new Label();
                this.yourFillingOptionAnswerLabel = new Label();

                this.Controls.Add(questionLabel);
                this.Controls.Add(firstOptionLabel);
                this.Controls.Add(secondOptionLabel);
                this.Controls.Add(thirdOptionLabel);
                this.Controls.Add(fourthOptionLabel);
                this.Controls.Add(fillingOptionLabel);
                this.Controls.Add(yourFillingOptionAnswerLabel);

                //this.ParentChanged += new EventHandler((sender, e) => {
                //    this.Width = this.Parent.ClientSize.Width;
                //});

                this.Width = 816;

                // Настройка внутренних элементов:
                #region settingElements

                // Ширина:
                questionLabel.Width =
                    firstOptionLabel.Width =
                    secondOptionLabel.Width =
                    thirdOptionLabel.Width =
                    fourthOptionLabel.Width =
                    fillingOptionLabel.Width =
                    yourFillingOptionAnswerLabel.Width = 800;

                // Высота:
                this.Height = 272;
                questionLabel.Height = 93;
                firstOptionLabel.Height = 
                    secondOptionLabel.Height = 
                    thirdOptionLabel.Height = 
                    fourthOptionLabel.Height = 
                    fillingOptionLabel.Height = 
                    yourFillingOptionAnswerLabel.Height = 34;

                // Положение:
                questionLabel.Location = new Point(12, 32);
                firstOptionLabel.Location = new Point(12, 125);
                secondOptionLabel.Location = new Point(12, 159);
                thirdOptionLabel.Location = new Point(12, 193);
                fourthOptionLabel.Location = new Point(12, 227);
                fillingOptionLabel.Location = new Point(12, 125);
                yourFillingOptionAnswerLabel.Location = new Point(12, 159);

                // Видимость: 
                questionLabel.Visible = false;
                firstOptionLabel.Visible = false;
                secondOptionLabel.Visible = false;
                thirdOptionLabel.Visible = false;
                fourthOptionLabel.Visible = false;
                fillingOptionLabel.Visible = false;
                yourFillingOptionAnswerLabel.Visible = false;
                
                #endregion

                this.Text = "";
                questionLabel.Visible = true;
                questionLabel.Text = Answer.question.Name;
                var options = Answer.question.Options;

                switch (Answer.question.Type)
                {
                    case Models.Type.single:
                    case Models.Type.multiple:

                        firstOptionLabel.Visible = true;
                        firstOptionLabel.Text = options[0].option;
                        if(options[0].isRight) firstOptionLabel.ForeColor = Color.Green;
                        secondOptionLabel.Visible = true;
                        secondOptionLabel.Text = options[1].option;
                        if(options[1].isRight) secondOptionLabel.ForeColor = Color.Green;
                        thirdOptionLabel.Visible = true;
                        thirdOptionLabel.Text = options[2].option;
                        if(options[2].isRight) thirdOptionLabel.ForeColor = Color.Green;
                        fourthOptionLabel.Visible = true;
                        fourthOptionLabel.Text = options[3].option;
                        if(options[3].isRight) fourthOptionLabel.ForeColor = Color.Green;

                        foreach (var item in answer.choosen)
                        {
                            if(item.Equals(options[0]) && !options[0].isRight) firstOptionLabel.ForeColor = Color.Red;
                            if(item.Equals(options[1]) && !options[1].isRight) secondOptionLabel.ForeColor = Color.Red;
                            if(item.Equals(options[2]) && !options[2].isRight) thirdOptionLabel.ForeColor = Color.Red;
                            if(item.Equals(options[3]) && !options[3].isRight) fourthOptionLabel.ForeColor = Color.Red;
                        }

                        break;
                    case Models.Type.filling:
                        fillingOptionLabel.Visible = true;
                        fillingOptionLabel.Text = options[0].option;
                        yourFillingOptionAnswerLabel.Visible = true;
                        yourFillingOptionAnswerLabel.Text = answer.choosen[0].option;
                        if (options[0].option != answer.choosen[0].option)
                        {
                            yourFillingOptionAnswerLabel.ForeColor = Color.Red;
                            fillingOptionLabel.ForeColor = Color.Green;
                        }
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
            //List<Answer> wrongAnswers = GetWrongAnswers(answers);

            foreach (var item in answers)
            {
                AnswerVisualization answerVisualization = new AnswerVisualization(item);
                flowLayoutPanel1.Controls.Add(answerVisualization);
            }
        }

        //private List<Answer> GetWrongAnswers(List<Answer> answers)
        //{
        //    List<Answer> wrongAnswers = new List<Answer>();

        //    foreach (Answer answer in answers)
        //    {
        //        switch (answer.question.Type)
        //        {
        //            case Models.Type.single:
        //                {
        //                    foreach (Option option in answer.question.Options)
        //                    {
        //                        if(option == answer.choosen[0])
        //                        {
        //                            wrongAnswers.Add(answer);
        //                            break;
        //                        }
        //                    }
        //                    break;
        //                }
        //            case Models.Type.multiple:
        //                {
        //                    if(!answer.choosen.Equals(answer.question.Options)){
        //                        wrongAnswers.Add(answer);
        //                        break;
        //                    }
        //                    break;
        //                }
        //            case Models.Type.filling:
        //                {
        //                    if(answer.choosen[0].option.ToLower().TrimEnd().TrimStart() == answer.question.Options[0].option.ToLower().TrimEnd().TrimStart())
        //                    {
        //                        wrongAnswers.Add(answer);
        //                        break;
        //                    }
        //                    break;
        //                }
        //        }
        //    }

        //    return wrongAnswers;
        //}
    }
}
