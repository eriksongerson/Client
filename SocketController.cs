using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace Test_OS
{
    class SocketController
    {

        //public string messageForSTQ = "";
        //public string messageForConnect = "";
        //public string messageForAnswer = "";

        //private int portForConnect = 8192;
        //private int portForQuestion = 8193;
        //private int portForAnswers = 8194;

        //public string InputMessage = "";

        //private int port = 12345;

        public SocketController()
        {

        }

        //public void MultiSocket()
        //{
        //    Client client = new Client();
        //    m:
        //    string message = InputMessage;
        //    try
        //    {
        //        client.Set_IP();
        //        string IP = client.Get_IP();
                
        //        IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(IP), port);

        //        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        //        socket.Connect(ipPoint);

        //        byte[] data = Encoding.Unicode.GetBytes(message);

        //        socket.Send(data);

        //        data = new byte[256];
        //        StringBuilder builder = new StringBuilder();
        //        int bytes = 0;

        //        do
        //        {
        //            bytes = socket.Receive(data, data.Length, 0);
        //            builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
        //        }
        //        while (socket.Available > 0);

        //        socket.Shutdown(SocketShutdown.Both);
        //        socket.Close();

        //        client.MessageHandler(builder.ToString());

        //    }
        //    catch (Exception ex)
        //    {
        //        goto m;
        //    }

        //}

        //public void ConnectSocket()
        //{
        //    Client client = new Client();
        //    m:
        //    string message = messageForConnect;
        //    try
        //    {
        //        client.Set_IP();

        //        IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(client.Get_IP()), portForConnect);

        //        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        //        socket.Connect(ipPoint);

        //        byte[] data = Encoding.Unicode.GetBytes(message);

        //        socket.Send(data);

        //        data = new byte[256];
        //        StringBuilder builder = new StringBuilder();
        //        int bytes = 0;

        //        do
        //        {
        //            bytes = socket.Receive(data, data.Length, 0);
        //            builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
        //        }
        //        while (socket.Available > 0);

        //        socket.Shutdown(SocketShutdown.Both);
        //        socket.Close();

        //        client.MessageHandler("ConnectSocket", builder.ToString());

        //    }
        //    catch (Exception)
        //    {
        //        goto m;
        //    }
        //}

        //public void SQTSocket()
        //{
        //    Client client = new Client();
        //    m:
        //    string message = messageForSTQ;
        //    try
        //    {
        //        client.Set_IP();

        //        IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(client.Get_IP()), portForQuestion);

        //        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        //        socket.Connect(ipPoint);

        //        byte[] data = Encoding.Unicode.GetBytes(message);

        //        socket.Send(data);

        //        data = new byte[256];
        //        StringBuilder builder = new StringBuilder();
        //        int bytes = 0;

        //        do
        //        {
        //            bytes = socket.Receive(data, data.Length, 0);
        //            builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
        //        }
        //        while (socket.Available > 0);

        //        socket.Shutdown(SocketShutdown.Both);
        //        socket.Close();

        //        string[] Line = message.Split(':');

        //        client.MessageHandler("STQSocket", builder.ToString(), Line[0]);

        //    }
        //    catch (Exception)
        //    {
        //        goto m;
        //    }
        //}

        ////Сокет, который после каждого ответа кидает серверу информацию о том, 
        ////что ответ решён, и нужно это отобразить на главной форме сервера.
        //public void AnswerSocket()
        //{
        //    Client client = new Client();
        //    m:
        //    string message = messageForAnswer;
        //    try
        //    {

        //        client.Set_IP();

        //        IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(client.Get_IP()), portForAnswers);

        //        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        //        socket.Connect(ipPoint);

        //        byte[] data = Encoding.Unicode.GetBytes(message);

        //        socket.Send(data);

        //        data = new byte[256];
        //        StringBuilder builder = new StringBuilder();
        //        int bytes = 0;

        //        do
        //        {
        //            bytes = socket.Receive(data, data.Length, 0);
        //            builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
        //        }
        //        while (socket.Available > 0);

        //        socket.Shutdown(SocketShutdown.Both);
        //        socket.Close();

        //        client.MessageHandler("AnswerSocket",builder.ToString());

        //    }
        //    catch (Exception)
        //    {
        //        goto m;
        //    }
        //}
    }
}
