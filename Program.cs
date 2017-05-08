using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Test_OS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if(Client.Get_IP() == "" || Client.Get_PCname() == "")
            {
                Application.Run(new ChangeIP());
                Application.Run(new MainForm());
            }
            else
            {
                Application.Run(new MainForm());
            }

            if (MainForm.FirstThread.IsAlive) 
                MainForm.FirstThread.Abort();
            if(MainForm.SecondThread.IsAlive)
                MainForm.SecondThread.Abort();
            if(MainForm.ThirdThread.IsAlive)
                MainForm.ThirdThread.Abort();
            if(MainForm.FourthThread.IsAlive)
                MainForm.FourthThread.Abort();

            while (MainForm.FirstThread.IsAlive || MainForm.SecondThread.IsAlive || MainForm.ThirdThread.IsAlive || MainForm.FourthThread.IsAlive) ;

            Environment.Exit(1);
        }
    }
}