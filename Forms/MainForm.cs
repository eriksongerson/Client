using System;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;

using Client.Models;
using Client.Helpers;

using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace Client.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        List<Subject> subjects;
        List<Theme> themes;
        List<Models.Group> groups;

        Subject currentSubject;
        Theme currentTheme;

        public void MainForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = Properties.Settings.Default.IP;

            Request GroupRequest = new Request()
            {
                request = "getGroups",
                client = QuestionHelper.client,
                body = null,
            };

            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                new SocketHelper().DoRequest(GroupRequest, (returned) =>
                {
                    // эта лямбда-функция для того, чтобы после запроса и его обработки выполнилось какое-либо событие
                    // она передаётся дальше
                    groups = returned as List<Models.Group>;
                    this.comboBox1.BeginInvoke((MethodInvoker)(() => comboBox1.Items.Clear()));
                    foreach (Models.Group group in groups)
                    {
                        this.groupsСomboBox.BeginInvoke((MethodInvoker)(() => groupsСomboBox.Items.Add(group)));
                    }
                });
            }).Start();

            Request SubjectsRequest = new Request()
            {
                request = "getSubjects",
                client = QuestionHelper.client,
                body = null,
            };

            // Анонимный поток
            new Thread(() => 
            {
                Thread.CurrentThread.IsBackground = true;
                new SocketHelper().DoRequest(SubjectsRequest, (returned) => {
                    // эта лямбда-функция для того, чтобы после запроса и его обработки выполнилось какое-либо событие
                    // она передаётся дальше
                    subjects = returned as List<Subject>;
                    this.comboBox1.BeginInvoke((MethodInvoker)(() => comboBox1.Items.Clear()));
                    foreach (Subject subject in subjects)
                    {
                        this.comboBox1.BeginInvoke((MethodInvoker)(() => comboBox1.Items.Add(subject)));
                    }
                });
            }).Start(); // Он выполнится и сразу уничтожится. Не нужно контроллировать его жизненный цикл
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentSubject = comboBox1.SelectedItem as Subject;
            QuestionHelper.currentSubject = currentSubject;

            Request request = new Request()
            {
                request = "getThemes",
                client = QuestionHelper.client,
                body = JsonConvert.SerializeObject(currentSubject, Formatting.Indented),
            };

            new Thread(() => 
            {
                Thread.CurrentThread.IsBackground = true;
                new SocketHelper().DoRequest(request, (returned) => {
                    themes = returned as List<Theme>;
                    this.comboBox2.BeginInvoke((MethodInvoker)(() => comboBox2.Items.Clear()));
                    foreach (Theme theme in themes)
                    {
                        this.comboBox2.BeginInvoke((MethodInvoker)(() => comboBox2.Items.Add(theme)));
                    }
                });
            }).Start();
            comboBox2.Enabled = true;
            isFill();
        }

        class discipline
        {
            public Subject subject;
            public Theme theme;
        }

        private void qStartTest_Click(object sender, EventArgs e)
        {
            discipline discipline = new discipline()
            {
                subject = currentSubject,
                theme = currentTheme,
            };

            Request request = new Request()
            {
                request = "getQuestions",
                client = QuestionHelper.client,
                body = JsonConvert.SerializeObject(discipline, Formatting.Indented),
            };

            new Thread(() => {
                Thread.CurrentThread.IsBackground = true;
                new SocketHelper().DoRequest(request, (returned) => {
                    List<Question> questions = returned as List<Question>;
                    QuestionHelper.Questions = questions;

                    // и переходим на форму тестирования
                    TestingForm testingForm = new TestingForm();
                    this.BeginInvoke((MethodInvoker)(() => this.Hide()));
                    if (testingForm.ShowDialog() != DialogResult.OK)
                        try { this.BeginInvoke((MethodInvoker)(() => this.Close())); } catch(InvalidOperationException){}
                });
            }).Start();
        }

        private void qEndApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentTheme = comboBox2.SelectedItem as Theme;
            QuestionHelper.currentTheme = currentTheme;
            isFill();
        }

        private void isFill()
        {
            qStartTest.Enabled = comboBox2.SelectedItem != null && qFamStud.Text != "" && qNameStud.Text != "" && comboBox1.SelectedItem != null && groupsСomboBox.SelectedItem != null;   
        }

        private void qFamStud_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex("^[А-ЯЁ]{1}[а-яё]{0,49}$");
            if (regex.IsMatch(qFamStud.Text))
            {
                QuestionHelper.client.surname = qFamStud.Text;
            }
            isFill();
            FirstCharToUpper(sender as TextBox);
        }

        private void qNameStud_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex("^[А-ЯЁ]{1}[а-яё]{0,49}$");
            if (regex.IsMatch(qNameStud.Text))
            {
                QuestionHelper.client.name = qNameStud.Text;
            }
            isFill();
            FirstCharToUpper(sender as TextBox);
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            string line = textBox1.Text;
            var arr = line.Split('.');
            if (arr.Length != 4)
            {
                MessageBox.Show("Некорректный IP адрес", "Некорректный IP адрес2" ,MessageBoxButtons.OK);
                textBox1.Select();
                return;
            }
            foreach (var item in arr)
            {
                if(Int32.Parse(item) > 256)
                {
                    MessageBox.Show("Некорректный IP адрес", "Некорректный IP адрес2" ,MessageBoxButtons.OK);
                    textBox1.Select();
                    return;
                }
            }

            Properties.Settings.Default.IP = line;
            Properties.Settings.Default.Save();
            SocketHelper.NotificateIpChanged();
        }

        private void groupsСomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            QuestionHelper.client.group = groupsСomboBox.SelectedItem as Models.Group;
            isFill();
        }

        private void CheckKeyPress(object sender, KeyPressEventArgs e)
        {
            string ch = e.KeyChar.ToString();
            Regex regex = new Regex("[А-Яа-я]");
            if (!regex.IsMatch(ch) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
        private void FirstCharToUpper(TextBox textbox)
        {
            if (textbox.Text != "")
            {
                var line = textbox.Text.ToCharArray();
                line[0] = Convert.ToChar(line[0].ToString().ToUpper());
                textbox.Text = new string(line);
                textbox.Select(textbox.Text.Length, 0);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string ch = e.KeyChar.ToString();
            Regex regex = new Regex("[0-9.]");
            if (!regex.IsMatch(ch) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
    }
}