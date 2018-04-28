using System;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

using Client.Models;
using Client.Helpers;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace Client
{
    public partial class MainForm : Form
    {

        //Client client = new Client();

        private int port = 12345;
        private static string InputMessage = "";

        public MainForm()
        {
            InitializeComponent();
        }

        List<Subject> subjects;
        List<Theme> themes;
        public void MainForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = Properties.Settings.Default.ServerIP;

            Request request = new Request()
            {
                request = "getSubjects",
                client = new Models.Client()
                {
                    ip = SocketHelper.GetLocalIPAddress(),
                    surname = qFamStud.Text,
                    name = qNameStud.Text,
                },
                body = null,
            };

            // Анонимный поток
            new Thread(() => 
            {
                SocketHelper.DoRequest(request, (returned) => {
                    // эта лямбда-функция для того, чтобы после запроса и его обработки выполнилось какое-либо событие
                    // она передаётся дальше
                    subjects = returned as List<Subject>;
                    foreach (Subject subject in subjects)
                    {
                        this.comboBox1.BeginInvoke((MethodInvoker)(() => comboBox1.Items.Add(subject.Name)));
                    }
                });
            }).Start(); // Он выполнится и сразу уничтожится. Не нужно контроллировать его жизненный цикл
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Request request = new Request()
            {
                request = "getThemes",
                client = new Models.Client()
                {
                    ip = SocketHelper.GetLocalIPAddress(),
                    surname = qFamStud.Text,
                    name = qNameStud.Text,
                },
                body = JsonConvert.SerializeObject($"{comboBox1.Text}", Formatting.Indented),
            };

            new Thread(() => 
            {
                SocketHelper.DoRequest(request, (returned) => {
                    themes = returned as List<Theme>;
                    foreach (Theme theme in themes)
                    {
                        this.comboBox2.BeginInvoke((MethodInvoker)(() => comboBox2.Items.Add(theme.Name)));
                    }
                });
            }).Start();
            comboBox2.Enabled = true;
            isFill();
        }

        private void qStartTest_Click(object sender, EventArgs e)
        {
            Request request = new Request()
            {
                request = "getQuestions",
                client = new Models.Client()
                {
                    ip = SocketHelper.GetLocalIPAddress(),
                    surname = qFamStud.Text,
                    name = qNameStud.Text,
                },
                body = JsonConvert.SerializeObject(new List<string>(){comboBox1.Text, comboBox2.Text}, Formatting.Indented),
            };

            new Thread(() => {
                SocketHelper.DoRequest(request, (returned) => {
                    List<Question> questions = returned as List<Question>;
                    QuestionHelper.questions = questions;

                    // и переходим на форму тестирования
                    TestingForm testingForm = new TestingForm();
                    this.Hide();
                    if (testingForm.ShowDialog() != DialogResult.OK)
                        this.Close();
                });
            }).Start();
        }

        private void qEndApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            isFill();
        }

        private void isFill()
        {
            if (comboBox2.SelectedItem != null && qFamStud.Text != "" && qNameStud.Text != "" && comboBox1.SelectedItem != null)
            {
                qStartTest.Enabled = true;
            }
            else
            {
                qStartTest.Enabled = false;
            }
        }

        private void qFamStud_TextChanged(object sender, EventArgs e)
        {
            isFill();
        }

        private void qNameStud_TextChanged(object sender, EventArgs e)
        {
            isFill();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Properties.Settings.Default.ServerIP = textBox1.Text;
            //Properties.Settings.Default.Save();
        }
    }
}