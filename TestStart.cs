using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class TestStart : Form
    {
        public TestStart()
        {
            InitializeComponent();
        }

        private void btnStartTest_Click(object sender, EventArgs e)
        {
            // Create new Test
            Test tNew = new Test(DateTime.Now, this.txtUserID.Text, 0, 0);
            
            // Display questions
            Questionaire questionaire = new Questionaire(tNew);
            questionaire.FormClosed += questionaire_FormClosed;
            questionaire.Show();

            this.Hide();
        }

        void questionaire_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.Close();
            this.Show();
        }
    }
}
