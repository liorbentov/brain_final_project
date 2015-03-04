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
            if (!tNew.isOver())
            {
                this.Close();
            }
            else
            {
                this.Show();
                pNewTest.Visible = false;
                pResults.Visible = true;

                // Calculate this test's results
                tNew.endTest();
                this.lblScore.Text = tNew.Score.ToString();
                this.lblTime.Text = tNew.Time.ToString();

                // Get user's previous tests
                tNew.User.getUserTests();

                // Check if there are previous test
                if (tNew.User.PreviousTest.Count == 0)
                {
                    this.pTestResults.Location = new Point(54, 40);
                    this.pAvg.Visible = false;
                }
                else
                {
                    this.pTestResults.Location = new Point(101, 49);
                    this.pAvg.Visible = true;

                    // Set the avg and the diff
                    this.lblScoreAvg.Text = setStringForResult(tNew.User.ScoreAvearage.ToString());
                    this.lblTimeAvg.Text = setStringForResult(tNew.User.TimeAvearage.ToString());
                    this.lblScoreDiff.Text = setStringForResult((tNew.Score - tNew.User.ScoreAvearage).ToString());
                    this.lblTimeDiff.Text = setStringForResult((tNew.Time - tNew.User.TimeAvearage).ToString());

                    // Set diff color
                    if ((tNew.Score - tNew.User.ScoreAvearage) < 0)
                    {
                        this.lblScoreDiff.ForeColor = Color.Red;
                    }
                    else
                    {
                        if (tNew.Score == tNew.User.ScoreAvearage)
                        {
                            this.lblScoreDiff.ForeColor = Color.Blue;
                        }
                        else
                        {
                            this.lblScoreDiff.ForeColor = Color.Green;
                        }
                    }

                    if ((tNew.Time - tNew.User.TimeAvearage) > 0)
                    {
                        this.lblTimeDiff.ForeColor = Color.Red;
                    }
                    else
                    {
                        if (tNew.Time == tNew.User.TimeAvearage)
                        {
                            this.lblTimeDiff.ForeColor = Color.Blue;
                        }
                        else
                        {
                            this.lblTimeDiff.ForeColor = Color.Green;
                        }
                    }
                }

                // Save results
                tNew.saveTestToFile();
            }
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            tNew.User.getUserTests();
            new UserTestLog(tNew.User.PreviousTest).Show();
            new UserLogChart(tNew.User.PreviousTest).Show();
        }

        private void btnNewTest_Click(object sender, EventArgs e)
        {
            btnStartTest_Click(sender, e);
        }

        private string setStringForResult(string strToShow)
        {
            if (strToShow.Length > 6)
            {
                return (strToShow.Remove(6));
            }
                
            return (strToShow);
        }
    }
}
