using System;
using System.Windows.Forms;
using System.Threading;
using Newtonsoft.Json;
using Client.Helpers;
using Client.Models;
namespace Client.Forms {
    // Форма окончания тестирования
    public partial class FinishTestingForm : Form {
        // Необходимый класс для сохранения предмета, темы и оценки
        class disciplineWithMark {
            public Subject subject;
            public Theme theme;
            public int mark;
        }
        // Перечисление оценок
        public enum Mark : int {
            Perfect = 5,
            Good = 4,
            Normal = 3,
            Bad = 2
        }
        // Функция выдачи оценок
        public Mark GetMark(double Percent) {
            Mark mark = Mark.Bad;
            if (Percent >= 0.5 && Percent < 0.75)
                mark = Mark.Normal;
            if (Percent >= 0.75 && Percent < 0.875)
                mark = Mark.Good;
            if (Percent >= 0.875 && Percent <= 100)
                mark = Mark.Perfect;
            return mark;
        }
        // Конструктор
        public FinishTestingForm() => InitializeComponent();
        // кнопка выхода из программы
        private void qExit_Click(object sender, EventArgs e) => Application.Exit();
        // Событие при загрузке формы
        private void FinishTestingForm_Load(object sender, EventArgs e) {
            QuestionHelper.isTesting = false;
            // Заполняем форму
            qF.Text = QuestionHelper.client.surname;
            qN.Text = QuestionHelper.client.name;
            qResult.Text = QuestionHelper.RightQuantity.ToString();
            // Берем процентное соотнощение правильно 
            // отвеченных вопросов к общему количеству вопросов
            double Percent = (double)QuestionHelper.RightQuantity / (double)QuestionHelper.TotalQuestions;
            // Получаем оценку
            Mark mark = GetMark(Percent);
            // И выдаём это на форме
            label5.Text = $"{Percent * 100}%";
            label4.Text = $"{(int)mark}";
            // Затем создаём объект дисциплины с оценкой
            disciplineWithMark disciplineWithMark = new disciplineWithMark() {
                subject = QuestionHelper.currentSubject,
                theme = QuestionHelper.currentTheme,
                mark = (int)mark,
            };
            // Создаём из этого объекта запрос
            Request request = new Request() {
                request = "done",
                client = QuestionHelper.client,
                body = JsonConvert.SerializeObject(disciplineWithMark),
            };
            // И отправляем запрос на сервер
            new Thread(() => {
                Thread.CurrentThread.IsBackground = true;
                new SocketHelper().DoRequest(request, null);
            }).Start();
            // Если мы всё ответили без единой ошибки, значит, переход на форму ошибок не нужен
            if(QuestionHelper.RightQuantity == QuestionHelper.TotalQuestions)
                mistakesButton.Enabled = false;
        }
        // Кнопка перехода на форму ошибок
        private void mistakesButton_Click(object sender, EventArgs e) {
            MistakesForm mistakesForm = new MistakesForm();
            mistakesForm.ShowDialog();
        }
    }
}