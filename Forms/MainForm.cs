using System;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Client.Models;
using Client.Helpers;
namespace Client.Forms {
    // Главная форма 
    public partial class MainForm : Form {
        // Конструктор формы
        public MainForm() => InitializeComponent();
        // Список предметов
        List<Subject> subjects;
        // Список тем
        List<Theme> themes;
        // Список групп
        List<Models.Group> groups;
        // Выбранный предмет
        Subject currentSubject;
        // Выбранная тема
        Theme currentTheme;
        // Функция вызываемая при загрузке формы
        public void MainForm_Load(object sender, EventArgs e) {
            // Выборка IP адреса сервера из настроек
            textBox1.Text = Properties.Settings.Default.IP;
            // Запрос групп
            Request GroupRequest = new Request() {
                request = "getGroups",
                client = QuestionHelper.client,
                body = null,
            };
            // Отправка запроса к серверу
            new Thread(() => {
                Thread.CurrentThread.IsBackground = true;
                new SocketHelper().DoRequest(GroupRequest, (returned) => {
                    // Получение группы
                    groups = returned as List<Models.Group>;
                    // Очищаем выпадающий список
                    this.groupsСomboBox.BeginInvoke((MethodInvoker)(() => groupsСomboBox.Items.Clear()));
                    // И заполняем его
                    foreach (Models.Group group in groups) {
                        this.groupsСomboBox.BeginInvoke((MethodInvoker)(() => groupsСomboBox.Items.Add(group)));
                    }
                });
            }).Start();
            // Запрос предметов
            Request SubjectsRequest = new Request() {
                request = "getSubjects",
                client = QuestionHelper.client,
                body = null,
            };
            // Отправка запроса к серверу
            new Thread(() => {
                Thread.CurrentThread.IsBackground = true;
                new SocketHelper().DoRequest(SubjectsRequest, (returned) => {
                    // эта лямбда-функция для того, чтобы после запроса и его обработки выполнилось какое-либо событие
                    // она передаётся дальше
                    subjects = returned as List<Subject>;
                    // Очистка выпадающего списка
                    this.comboBox1.BeginInvoke((MethodInvoker)(() => comboBox1.Items.Clear()));
                    // Заполнение 
                    foreach (Subject subject in subjects) {
                        this.comboBox1.BeginInvoke((MethodInvoker)(() => comboBox1.Items.Add(subject)));
                    }
                });
            }).Start(); // Он выполнится и сразу уничтожится. Не нужно контроллировать его жизненный цикл
        }
        // При выборе предмета
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            // Выбранный предмет сохраняем в переменную
            currentSubject = comboBox1.SelectedItem as Subject;
            // Сохраняем предмет в управляющий класс
            QuestionHelper.currentSubject = currentSubject;
            // Запрос на получение тем
            Request request = new Request() {
                request = "getThemes",
                client = QuestionHelper.client,
                body = JsonConvert.SerializeObject(currentSubject, Formatting.Indented),
            };
            // Отправка запроса к серверу
            new Thread(() => {
                Thread.CurrentThread.IsBackground = true;
                new SocketHelper().DoRequest(request, (returned) => {
                    // Получение тем из ответа
                    themes = returned as List<Theme>;
                    // Очистка выпадающего списка
                    this.comboBox2.BeginInvoke((MethodInvoker)(() => comboBox2.Items.Clear()));
                    // Заполнение
                    foreach (Theme theme in themes) {
                        this.comboBox2.BeginInvoke((MethodInvoker)(() => comboBox2.Items.Add(theme)));
                    }
                });
            }).Start();
            // Активация выпадающего списка
            comboBox2.Enabled = true;
            // Проверка на заполненность полей
            isFill();
        }
        // Класс, сохраняющий предмет и тему
        class discipline {
            public Subject subject;
            public Theme theme;
        }
        // Кнопка начала теста
        private void qStartTest_Click(object sender, EventArgs e)
        {
            // Сохранение предмета и тему в объект класса
            discipline discipline = new discipline() {
                subject = currentSubject,
                theme = currentTheme,
            };
            // Создание запроса на получение списка вопроса
            Request request = new Request() {
                request = "getQuestions",
                client = QuestionHelper.client,
                // конвертация объекта в тело запроса
                body = JsonConvert.SerializeObject(discipline, Formatting.Indented),
            };
            // Отправка запроса к серверу
            new Thread(() => {
                Thread.CurrentThread.IsBackground = true;
                new SocketHelper().DoRequest(request, (returned) => {
                    // получение списка вопросов
                    List<Question> questions = returned as List<Question>;
                    // Сохранение списка вопросов в управляющий класс
                    QuestionHelper.Questions = questions;
                    // и переходим на форму тестирования
                    TestingForm testingForm = new TestingForm();
                    this.BeginInvoke((MethodInvoker)(() => this.Hide()));
                    if (testingForm.ShowDialog() != DialogResult.OK)
                        try { this.BeginInvoke((MethodInvoker)(() => this.Close())); } catch(InvalidOperationException){}
                });
            }).Start();
        }
        // кнопка выхода из программы
        private void qEndApp_Click(object sender, EventArgs e) => Application.Exit();
        // Обработка события выбора темы
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) {
            // Сохраняем тему в управляющий класс
            currentTheme = comboBox2.SelectedItem as Theme;
            QuestionHelper.currentTheme = currentTheme;
            // И проверяем поля на заполненность
            isFill();
        }
        // проверка полей на заполненность
        private void isFill() {
            qStartTest.Enabled = comboBox2.SelectedItem != null && qFamStud.Text != ""
                && qNameStud.Text != "" && comboBox1.SelectedItem != null 
                && groupsСomboBox.SelectedItem != null;   
        }
        // Событие изменения фамилии в текстовом поле
        private void qFamStud_TextChanged(object sender, EventArgs e) {
            Regex regex = new Regex("^[А-ЯЁ]{1}[а-яё]{0,49}$");
            if (regex.IsMatch(qFamStud.Text)) {
                QuestionHelper.client.surname = qFamStud.Text;
            }
            // И проверка заполненности полей
            isFill();
            FirstCharToUpper(sender as TextBox);
        }
        // Событие изменения имени в текстовом поле 
        private void qNameStud_TextChanged(object sender, EventArgs e) {
            Regex regex = new Regex("^[А-ЯЁ]{1}[а-яё]{0,49}$");
            if (regex.IsMatch(qNameStud.Text)) {
                QuestionHelper.client.name = qNameStud.Text;
            }
            // И проверка заполненности полей
            isFill();
            FirstCharToUpper(sender as TextBox);
        }
        // Когда поле заполнено окончательно 
        // и пользователь переключается на другой элемент
        private void textBox1_Leave(object sender, EventArgs e) {
            // Сначала проверяем введенный IP-адрес
            string line = textBox1.Text;
            var arr = line.Split('.');
            if (arr.Length != 4) {
                MessageBox.Show("Некорректный IP адрес", "Некорректный IP адрес2" ,MessageBoxButtons.OK);
                textBox1.Select();
                return;
            }
            foreach (var item in arr) {
                if(Int32.Parse(item) > 256) {
                    MessageBox.Show("Некорректный IP адрес", "Некорректный IP адрес2" ,MessageBoxButtons.OK);
                    textBox1.Select();
                    return;
                }
            }
            // А затем сохраняем его
            Properties.Settings.Default.IP = line;
            Properties.Settings.Default.Save();
            SocketHelper.NotificateIpChanged();
        }
        // После выбора группы, сохраняем выбор в управляющий класс
        private void groupsСomboBox_SelectedIndexChanged(object sender, EventArgs e) {
            QuestionHelper.client.group = groupsСomboBox.SelectedItem as Models.Group;
            isFill();
        }
        // Блокируем ввод цифр и иностранной раскладки
        private void CheckKeyPress(object sender, KeyPressEventArgs e) {
            string ch = e.KeyChar.ToString();
            Regex regex = new Regex("[А-Яа-я]");
            if (!regex.IsMatch(ch) && e.KeyChar != 8) {
                e.Handled = true;
            }
        }
        // Насильно делаем первый символ большой буквой
        private void FirstCharToUpper(TextBox textbox) {
            if (textbox.Text != "") {
                var line = textbox.Text.ToCharArray();
                line[0] = Convert.ToChar(line[0].ToString().ToUpper());
                textbox.Text = new string(line);
                textbox.Select(textbox.Text.Length, 0);
            }
        }
        // В текстовое поле ввода ip-адреса можно вводить только цифры с точками
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) {
            string ch = e.KeyChar.ToString();
            Regex regex = new Regex("[0-9.]");
            if (!regex.IsMatch(ch) && e.KeyChar != 8) {
                e.Handled = true;
            }
        }
    }
}