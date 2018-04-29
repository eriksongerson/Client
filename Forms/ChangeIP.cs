using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Client
{
    public partial class ChangeIP : Form
    {

        public ChangeIP()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //StreamWriter sw = new StreamWriter("settings.client");

            //sw.WriteLine("IPADDR=" + textBox1.Text );
            //sw.WriteLine("PCNAME=" + textBox2.Text );
            //sw.Close();

            //Client.Set_IP();
            //Client.Set_PCname();

            //this.Close();
        }

        private void ChangeIP_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    StreamReader sr = new StreamReader("settings.client");
            //    string Line = sr.ReadLine();
            //    string[] arr = Line.Split('=');
            //    string IP = arr[1];
            //    textBox1.Text = IP;
            //    Line = sr.ReadLine();
            //    arr = Line.Split('=');
            //    string PCname = arr[1];
            //    textBox2.Text = PCname;
            //    sr.Close();
            //}
            //catch (Exception)
            //{

            //}
        }
    }
}
