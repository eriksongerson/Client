using System;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Client.Models;
using Client.Helpers;
namespace Client.Forms {
    // ������� ����� 
    public partial class MainForm : Form {
        // ����������� �����
        public MainForm() => InitializeComponent();
        // ������ ���������
        List<Subject> subjects;
        // ������ ���
        List<Theme> themes;
        // ������ �����
        List<Models.Group> groups;
        // ��������� �������
        Subject currentSubject;
        // ��������� ����
        Theme currentTheme;
        // ������� ���������� ��� �������� �����
        public void MainForm_Load(object sender, EventArgs e) {
            // ������� IP ������ ������� �� ��������
            textBox1.Text = Properties.Settings.Default.IP;
            // ������ �����
            Request GroupRequest = new Request() {
                request = "getGroups",
                client = QuestionHelper.client,
                body = null,
            };
            // �������� ������� � �������
            new Thread(() => {
                Thread.CurrentThread.IsBackground = true;
                new SocketHelper().DoRequest(GroupRequest, (returned) => {
                    // ��������� ������
                    groups = returned as List<Models.Group>;
                    // ������� ���������� ������
                    this.groups�omboBox.BeginInvoke((MethodInvoker)(() => groups�omboBox.Items.Clear()));
                    // � ��������� ���
                    foreach (Models.Group group in groups) {
                        this.groups�omboBox.BeginInvoke((MethodInvoker)(() => groups�omboBox.Items.Add(group)));
                    }
                });
            }).Start();
            // ������ ���������
            Request SubjectsRequest = new Request() {
                request = "getSubjects",
                client = QuestionHelper.client,
                body = null,
            };
            // �������� ������� � �������
            new Thread(() => {
                Thread.CurrentThread.IsBackground = true;
                new SocketHelper().DoRequest(SubjectsRequest, (returned) => {
                    // ��� ������-������� ��� ����, ����� ����� ������� � ��� ��������� ����������� �����-���� �������
                    // ��� ��������� ������
                    subjects = returned as List<Subject>;
                    // ������� ����������� ������
                    this.comboBox1.BeginInvoke((MethodInvoker)(() => comboBox1.Items.Clear()));
                    // ���������� 
                    foreach (Subject subject in subjects) {
                        this.comboBox1.BeginInvoke((MethodInvoker)(() => comboBox1.Items.Add(subject)));
                    }
                });
            }).Start(); // �� ���������� � ����� �����������. �� ����� ��������������� ��� ��������� ����
        }
        // ��� ������ ��������
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            // ��������� ������� ��������� � ����������
            currentSubject = comboBox1.SelectedItem as Subject;
            // ��������� ������� � ����������� �����
            QuestionHelper.currentSubject = currentSubject;
            // ������ �� ��������� ���
            Request request = new Request() {
                request = "getThemes",
                client = QuestionHelper.client,
                body = JsonConvert.SerializeObject(currentSubject, Formatting.Indented),
            };
            // �������� ������� � �������
            new Thread(() => {
                Thread.CurrentThread.IsBackground = true;
                new SocketHelper().DoRequest(request, (returned) => {
                    // ��������� ��� �� ������
                    themes = returned as List<Theme>;
                    // ������� ����������� ������
                    this.comboBox2.BeginInvoke((MethodInvoker)(() => comboBox2.Items.Clear()));
                    // ����������
                    foreach (Theme theme in themes) {
                        this.comboBox2.BeginInvoke((MethodInvoker)(() => comboBox2.Items.Add(theme)));
                    }
                });
            }).Start();
            // ��������� ����������� ������
            comboBox2.Enabled = true;
            // �������� �� ������������� �����
            isFill();
        }
        // �����, ����������� ������� � ����
        class discipline {
            public Subject subject;
            public Theme theme;
        }
        // ������ ������ �����
        private void qStartTest_Click(object sender, EventArgs e)
        {
            // ���������� �������� � ���� � ������ ������
            discipline discipline = new discipline() {
                subject = currentSubject,
                theme = currentTheme,
            };
            // �������� ������� �� ��������� ������ �������
            Request request = new Request() {
                request = "getQuestions",
                client = QuestionHelper.client,
                // ����������� ������� � ���� �������
                body = JsonConvert.SerializeObject(discipline, Formatting.Indented),
            };
            // �������� ������� � �������
            new Thread(() => {
                Thread.CurrentThread.IsBackground = true;
                new SocketHelper().DoRequest(request, (returned) => {
                    // ��������� ������ ��������
                    List<Question> questions = returned as List<Question>;
                    // ���������� ������ �������� � ����������� �����
                    QuestionHelper.Questions = questions;
                    // � ��������� �� ����� ������������
                    TestingForm testingForm = new TestingForm();
                    this.BeginInvoke((MethodInvoker)(() => this.Hide()));
                    if (testingForm.ShowDialog() != DialogResult.OK)
                        try { this.BeginInvoke((MethodInvoker)(() => this.Close())); } catch(InvalidOperationException){}
                });
            }).Start();
        }
        // ������ ������ �� ���������
        private void qEndApp_Click(object sender, EventArgs e) => Application.Exit();
        // ��������� ������� ������ ����
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) {
            // ��������� ���� � ����������� �����
            currentTheme = comboBox2.SelectedItem as Theme;
            QuestionHelper.currentTheme = currentTheme;
            // � ��������� ���� �� �������������
            isFill();
        }
        // �������� ����� �� �������������
        private void isFill() {
            qStartTest.Enabled = comboBox2.SelectedItem != null && qFamStud.Text != ""
                && qNameStud.Text != "" && comboBox1.SelectedItem != null 
                && groups�omboBox.SelectedItem != null;   
        }
        // ������� ��������� ������� � ��������� ����
        private void qFamStud_TextChanged(object sender, EventArgs e) {
            Regex regex = new Regex("^[�-ߨ]{1}[�-��]{0,49}$");
            if (regex.IsMatch(qFamStud.Text)) {
                QuestionHelper.client.surname = qFamStud.Text;
            }
            // � �������� ������������� �����
            isFill();
            FirstCharToUpper(sender as TextBox);
        }
        // ������� ��������� ����� � ��������� ���� 
        private void qNameStud_TextChanged(object sender, EventArgs e) {
            Regex regex = new Regex("^[�-ߨ]{1}[�-��]{0,49}$");
            if (regex.IsMatch(qNameStud.Text)) {
                QuestionHelper.client.name = qNameStud.Text;
            }
            // � �������� ������������� �����
            isFill();
            FirstCharToUpper(sender as TextBox);
        }
        // ����� ���� ��������� ������������ 
        // � ������������ ������������� �� ������ �������
        private void textBox1_Leave(object sender, EventArgs e) {
            // ������� ��������� ��������� IP-�����
            string line = textBox1.Text;
            var arr = line.Split('.');
            if (arr.Length != 4) {
                MessageBox.Show("������������ IP �����", "������������ IP �����2" ,MessageBoxButtons.OK);
                textBox1.Select();
                return;
            }
            foreach (var item in arr) {
                if(Int32.Parse(item) > 256) {
                    MessageBox.Show("������������ IP �����", "������������ IP �����2" ,MessageBoxButtons.OK);
                    textBox1.Select();
                    return;
                }
            }
            // � ����� ��������� ���
            Properties.Settings.Default.IP = line;
            Properties.Settings.Default.Save();
            SocketHelper.NotificateIpChanged();
        }
        // ����� ������ ������, ��������� ����� � ����������� �����
        private void groups�omboBox_SelectedIndexChanged(object sender, EventArgs e) {
            QuestionHelper.client.group = groups�omboBox.SelectedItem as Models.Group;
            isFill();
        }
        // ��������� ���� ���� � ����������� ���������
        private void CheckKeyPress(object sender, KeyPressEventArgs e) {
            string ch = e.KeyChar.ToString();
            Regex regex = new Regex("[�-��-�]");
            if (!regex.IsMatch(ch) && e.KeyChar != 8) {
                e.Handled = true;
            }
        }
        // �������� ������ ������ ������ ������� ������
        private void FirstCharToUpper(TextBox textbox) {
            if (textbox.Text != "") {
                var line = textbox.Text.ToCharArray();
                line[0] = Convert.ToChar(line[0].ToString().ToUpper());
                textbox.Text = new string(line);
                textbox.Select(textbox.Text.Length, 0);
            }
        }
        // � ��������� ���� ����� ip-������ ����� ������� ������ ����� � �������
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) {
            string ch = e.KeyChar.ToString();
            Regex regex = new Regex("[0-9.]");
            if (!regex.IsMatch(ch) && e.KeyChar != 8) {
                e.Handled = true;
            }
        }
    }
}