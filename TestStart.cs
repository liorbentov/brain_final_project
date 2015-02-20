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
        private Test tNew;
        public TestStart()
        {
            InitializeComponent();
        }

        private void btnStartTest_Click(object sender, EventArgs e)
        {
            // Create new Test
            tNew = new Test(DateTime.Now, this.txtUserID.Text, 0, 0);
            
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
            pNewTest.Visible = false;
            pResults.Visible = true;

            tNew.endTest();
            this.lblScore.Text = tNew.Score.ToString();
            this.lblTime.Text = tNew.Time.ToString();

            tNew.User.getUserTests();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            new UserTestLog(tNew.User.PreviousTest).Show();
        }
    }
}
