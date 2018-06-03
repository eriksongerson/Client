using System;
using System.Threading;
using System.Windows.Forms;

using Client.Forms;
using Client.Helpers;
using Client.Models;

namespace Client
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //SpinnerView spinnerView = new SpinnerView("������� ���������� � ��������. ��������...");
            //spinnerView.ShowDialog();
            // ������ ���������� � �������
            Request request = new Request()
            {
                request = "connect",
                client = QuestionHelper.client,
                body = null,
            };
            // ������ ����� ��� �������
            new Thread(() => 
            {
                // ������ ��� ��������, ����� �� �� ����� �� �������� ���������
                Thread.CurrentThread.IsBackground = true;
                // ���������� ������
                // � ������ ���������� isConnected � ������ SocketHelper = true
                // ���������� foo ������������ ��� ��������
                new SocketHelper().DoRequest(request, (foo) => { SocketHelper.IsConnected = true; });
            }).Start();

            // ���������� ������ ���������
            Application.Run(new MainForm());

            // ��� ������ �� ��������� ����� �������� ������� �� ����������:
            if (SocketHelper.IsConnected) { 
                request = new Request()
                {
                    request = "disconnect",
                    client = QuestionHelper.client,
                    body = null,
                };
                // � ���������� ������. ��� ���������, � ������� ������.
                // ��� ����� ��� ����, ����� ������ ����� ������� ����������� � ���, ��� ������ �����������
                new SocketHelper().DoRequest(request, (foo) => SocketHelper.IsConnected = false);
            }
        }
    }
}