using System;
//using System.Collections.Generic;
using System.ComponentModel;
//using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Test_OS
{
    public partial class FinishTestingForm : Form
    {

        //Client client = new Client();

        public FinishTestingForm()
        {
            InitializeComponent();
        }

        private void qExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FinishTestingForm_Load(object sender, EventArgs e)
        {
            qF.Text = Client.Get_StudentSurname();
            qN.Text = Client.Get_StudentName();
            qResult.Text = Convert.ToString(Client.Get_RightQuantity());

            if (Client.Get_RightQuantity() <= 23)
            {
                label4.Text = "2";
            }
            
            if (Client.Get_RightQuantity() >= 24 && Client.Get_RightQuantity() <= 31)
            {
                label4.Text = "3";
            }
            
            if (Client.Get_RightQuantity() >= 32 && Client.Get_RightQuantity() <= 40)
            {
                label4.Text = "4";
            }
            
            if (Client.Get_RightQuantity() >= 41 && Client.Get_RightQuantity() <= 46)
            {
                label4.Text = "5";
            }
        }
    }
}