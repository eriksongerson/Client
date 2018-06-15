using System;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Generic;
using Newtonsoft.Json;
using Client.Helpers;
using Client.Models;
namespace Client.Forms {
    // Класс формы тестирования
    public partial class TestingForm : Form {
        // Переменная текущего вопроса
        private Question currentQuestion;
        Question CurrentQuestion {
            // Когда текущий вопрос меняется, запрашиваем новый
            set {
                currentQuestion = value;
                // А когда вопросы заканчиваются - переходим на форму завершения
                if(currentQuestion == null) {
                    FinishTestingForm FinishTest = new FinishTestingForm();
                    Hide();
                    if (FinishTest.ShowDialog() != DialogResult.OK)
                        Close();
                } else {
                    // а когда вопросы есть - перерисовываем форму
                    Visual();
                }
            } get {
                return currentQuestion;
            }
        }
        // Конструктор формы:
        public TestingForm() => InitializeComponent();
        // Функция проверки ответа
        private void CheckAnswers() {
            singleGroupBox.Visible = false;
            multipleGroupBox.Visible = false;
            fillingGroupBox.Visible = false;
            Models.Type type = CurrentQuestion.Type;
            List<Option> options = CurrentQuestion.Options;
            switch (type) {
                case Models.Type.single: {
                        // Если отвеченный вариант ответа правильный
                        if(singleChoiceFirstOptionRadioButton.Checked && options[0].isRight 
                            || singleChoiceSecondOptionRadioButton.Checked && options[1].isRight
                            || singleChoiceThirdOptionRadioButton.Checked && options[2].isRight
                            || singleChoiceFourthOptionRadioButton.Checked && options[3].isRight)
                            // Прибавляем количество правильно твеченных вопросов
                            QuestionHelper.RightQuantity++;
                        break;
                    }
                case Models.Type.multiple: {
                        // тоже самое, что и чуть выше
                        if(multipleChoiceFirstOptionCheckBox.Checked == options[0].isRight
                            && multipleChoiceSecondOptionCheckBox.Checked == options[1].isRight 
                            && multipleChoiceThirdOptionCheckBox.Checked == options[2].isRight
                            && multipleChoiceFourthOptionCheckBox.Checked == options[3].isRight)
                            QuestionHelper.RightQuantity++;
                        break;
                    }
                case Models.Type.filling: {
                        // И также
                        if(fillingOptionTextBox.Text.ToLower() == options[0].option.ToLower())
                            QuestionHelper.RightQuantity++;
                        break;
                    }
            }
        }
        // Получаем выбранные варианты ответа
        private List<Option> GetChoosenOptions() {
            List<Option> choosenOptions = new List<Option>();
            Models.Type type = CurrentQuestion.Type;
            List<Option> options = CurrentQuestion.Options;
            switch (type) {
                case Models.Type.single:{
                        // Если вариант ответа отмечен - добавляем в список
                        if(singleChoiceFirstOptionRadioButton.Checked) choosenOptions.Add(options[0]);
                        if(singleChoiceSecondOptionRadioButton.Checked) choosenOptions.Add(options[1]);
                        if(singleChoiceThirdOptionRadioButton.Checked) choosenOptions.Add(options[2]);
                        if(singleChoiceFourthOptionRadioButton.Checked) choosenOptions.Add(options[3]);
                        break;
                    }
                case Models.Type.multiple: {
                        // Если вариант ответа отмечен - добавляем в список
                        if (multipleChoiceFirstOptionCheckBox.Checked) choosenOptions.Add(options[0]);
                        if(multipleChoiceSecondOptionCheckBox.Checked) choosenOptions.Add(options[1]);
                        if(multipleChoiceThirdOptionCheckBox.Checked) choosenOptions.Add(options[2]);
                        if(multipleChoiceFourthOptionCheckBox.Checked) choosenOptions.Add(options[3]);
                        break;
                    }
                case Models.Type.filling: {
                        // Здесь создаём новый объект, и добавляем его, т.к. он единственный 
                        Option option = new Option() {
                            option = fillingOptionTextBox.Text,
                        };
                        choosenOptions.Add(option);
                        break;
                    }
            }
            return choosenOptions;
        }
        // Обработка нажатия кнопки перехода к следующему вопросу
        private void qNext_Click(object sender, EventArgs e) {
            // Проверяем вопросы
            CheckAnswers();
            List<Option> choosen = GetChoosenOptions();
            // Создаём объект ответа на вопрос
            Answer answer = new Answer() {
                question = currentQuestion,
                choosen = choosen,
            };
            // И добавляем в список ответов на вопрос
            QuestionHelper.answers.Add(answer);
            // Создаём запрос, который говорит серверу, что вот
            // Мы ответили на вопрос, сохрани ответ
            Request request = new Request() {
                request = "answer",
                client = QuestionHelper.client,
                body = JsonConvert.SerializeObject(answer, Formatting.Indented),
            };
            // и отправляем запрос
            new Thread(() => {
                Thread.CurrentThread.IsBackground = true;
                new SocketHelper().DoRequest(request, null);
            }).Start(); 
            // И получаем новый вопрос 
            CurrentQuestion = QuestionHelper.GetNextQuestion();
        }
        // при загрузке формы
        private void TestingForm_Load(object sender, EventArgs e) {
            // Получаем вопрос
            CurrentQuestion = QuestionHelper.GetNextQuestion();
            QuestionHelper.isTesting = true;
            // И заполняем имя и фамилию студента в верхнем блоке
            clientNameLabel.Text = QuestionHelper.client.name;
            clientSurnameLabel.Text = QuestionHelper.client.surname;
            totalQuetionsLabel.Text = $"{ QuestionHelper.TotalQuestions }";
        }
        // Функция очистки и скрытия элементов
        private void ClearAndHide() {
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
        // Функция перерисовки формы
        void Visual() {
            // Чистим форму
            ClearAndHide();
            Models.Type type = CurrentQuestion.Type;
            List<Option> options = CurrentQuestion.Options;
            // И в соответствии с типом заполняем варианты ответа
            switch (type) {
                case Models.Type.single: {
                        singleGroupBox.Visible = true;
                        singleChoiceFirstOptionRadioButton.Text = options[0];
                        singleChoiceSecondOptionRadioButton.Text = options[1];
                        singleChoiceThirdOptionRadioButton.Text = options[2];
                        singleChoiceFourthOptionRadioButton.Text = options[3];
                        break;
                    }
                case Models.Type.multiple: {
                        multipleGroupBox.Visible = true;
                        multipleChoiceFirstOptionCheckBox.Text = options[0];
                        multipleChoiceSecondOptionCheckBox.Text = options[1];
                        multipleChoiceThirdOptionCheckBox.Text = options[2];
                        multipleChoiceFourthOptionCheckBox.Text = options[3];
                        break;
                    }
                case Models.Type.filling: {
                        fillingGroupBox.Visible = true;
                        break;
                    }
            }
            // Заполняем поле вопроса
            QuestionField.Text = CurrentQuestion.Name;
            // Ставим номер текущего вопроса
            currentQuestionId.Text = $"{ QuestionHelper.currentQuestionId + 1 }";
        }
    }
}