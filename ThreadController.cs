using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Test_OS
{
    class ThreadController
    {

        SocketController socketControl = new SocketController();

        Thread MultiThread = null;

        public ThreadController()
        {
           // MultiThread = new Thread(new ThreadStart(socketControl.MultiSocket));
        }

        public void SetThread()
        {
            
        }

        //public void CommandThread(bool isActive, string message)
        //{
        //    socketControl.InputMessage = message;

        //    if(isActive == true)
        //    {
        //        MultiThread.Start();
        //    }
        //    if(isActive == false)
        //    {
        //        MultiThread.Abort();
        //    }
        //}

        //SocketController socketControl = new SocketController();

        //public ThreadController()
        //{

        //}

        //public void STQThread(bool isActive, string message)
        //{
        //    socketControl.messageForSTQ = message;
        //    Thread STQ_Thread = new Thread(new ThreadStart(socketControl.SQTSocket));

        //    if(isActive == true)
        //    {
        //        STQ_Thread.Start();
        //    }
        //    if(isActive == false)
        //    {
        //        STQ_Thread.Abort();
        //    }
            
        //}

        //public void AnswerThread(bool isActive, string message)
        //{
        //    socketControl.messageForAnswer = message;
        //    Thread AnswerThread = new Thread(new ThreadStart(socketControl.AnswerSocket));

        //    if (isActive == true)
        //    {
        //        AnswerThread.Start();
        //    }
        //    if (isActive == false)
        //    {
        //        AnswerThread.Abort();
        //    }

        //}

        //public void ConnectionThread(bool isActive, string message)
        //{
        //    socketControl.messageForConnect = message;
        //    Thread ConnectionThread = new Thread(new ThreadStart(socketControl.ConnectSocket));

        //    if (isActive == true)
        //    {
        //        ConnectionThread.Start();
        //    }
        //    if (isActive == false)
        //    {
        //        ConnectionThread.Abort();
        //    }
        //}

        //[Serializable]
        //public class NullArgumentException : Exception
        //{
        //    public NullArgumentException() { }
        //    public NullArgumentException(string message) : base(message) { }
        //    public NullArgumentException(string message, Exception inner) : base(message, inner) { }
        //    protected NullArgumentException(
        //      System.Runtime.Serialization.SerializationInfo info,
        //      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        //}

    }
}
