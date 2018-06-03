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

            //SpinnerView spinnerView = new SpinnerView("Попытка соединения с сервером. Ожидайте...");
            //spinnerView.ShowDialog();
            // Запрос соединения к серверу
            Request request = new Request()
            {
                request = "connect",
                client = QuestionHelper.client,
                body = null,
            };
            // Создаём поток для запроса
            new Thread(() => 
            {
                // Делаем его дочерним, чтобы он не влиял на закрытие программы
                Thread.CurrentThread.IsBackground = true;
                // Отправляем запрос
                // И делаем переменную isConnected в классе SocketHelper = true
                // Переменная foo используется для заглушки
                new SocketHelper().DoRequest(request, (foo) => { SocketHelper.IsConnected = true; });
            }).Start();

            // Продолжаем работу программы
            Application.Run(new MainForm());

            // При выходе из программы нужно сообщить серверу об отключении:
            if (SocketHelper.IsConnected) { 
                request = new Request()
                {
                    request = "disconnect",
                    client = QuestionHelper.client,
                    body = null,
                };
                // И отправляем запрос. Уже синхронно, в главном потоке.
                // Это нужно для того, чтобы сервер точно получил уведомление о том, что клиент отключается
                new SocketHelper().DoRequest(request, (foo) => SocketHelper.IsConnected = false);
            }
        }
    }
}