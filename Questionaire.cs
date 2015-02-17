using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace FinalProject
{
    public partial class Questionaire : Form
    {
        Test currTest;
        int currQuestion = 0;
        Button[] questionButtons;

        public Questionaire(Test test)
        {
            InitializeComponent();
            currTest = test;
            currQuestion = 1;

            // Set buttons
            this.questionButtons = new Button[] { 
                this.button1, this.button2, this.button3, this.button4, this.btnQuestion8, this.btnQuestion6};
        }

        public void runQuestion3Timer(object sender, EventArgs e)
        {
            if (Question3.getInstance().getNounsNumberShowed() == 3)
            {
                tabControl1.SelectedTab = tabPage4;
                GlobalTimer.Tick -= runQuestion3Timer;
                GlobalTimer.Stop();
            }
            else
            {
                lblRandomNouns.Text = Question3.getInstance().getNextNoun();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((cbCountry.Text != string.Empty) && (cbCity.Text != null) &&
                (cbFloor.Text != string.Empty))
            {
                MessageBox.Show(Question2.Instance.checkAnswer(cbCountry.SelectedIndex,
                    cbCity.SelectedIndex, cbFloor.SelectedIndex).ToString());
                button2.Enabled = false;
                //tabControl1.SelectedTab = tabPage3;
                GlobalTimer.Tick += runQuestion3Timer;
                GlobalTimer.Start();
                lblRandomNouns.Text = Question3.getInstance().getNextNoun();
                nextQuestion();
            }
            else
            {
                MessageBox.Show("יש למלא את כל השדות לפני שתוכל להמשיך בשאלה");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Check if all the controls are full
            if ((cbDay.Text != string.Empty) && (cbMonth.Text != string.Empty) &&
                (cbYear.Text != string.Empty) && (cbSeason.Text != string.Empty))
            {
                MessageBox.Show(Question1.Instance.checkAnswer(Int32.Parse(cbDay.Text),
                    cbMonth.SelectedIndex, Int32.Parse(cbYear.Text), cbSeason.SelectedIndex).ToString());
                button1.Enabled = false;
                nextQuestion();
            }
            else
            {
                MessageBox.Show("יש למלא את כל השדות לפני שתוכל להמשיך בשאלה");
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (this.tabControl1.SelectedIndex != currQuestion - 1)
            //{
            //    this.tabControl1.SelectedIndex = currQuestion - 1;
            //}
            //currQuestion = 6;
            //this.AcceptButton = this.questionButtons[currQuestion - 1];

            if (this.tabControl1.SelectedIndex == 7)
            {
                this.analogClock1.setTime(
                    new DateTime(1, 1, 1, Question8.Instance.Hour, Question8.Instance.Minutes, 0));
            }
        }

        private void Questionaire_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void nextQuestion()
        {
            this.currQuestion++;
            tabControl1.SelectedIndex = this.currQuestion - 1;
        }

        private void btnQuestion6_Click(object sender, EventArgs e)
        {
            if (Question6.Instance.TimeSubstracted < 4)
            {
                if (this.txtQuestion6.Text != string.Empty)
                {
                    Question6.Instance.checkAnswer(Int32.Parse(this.txtQuestion6.Text));
                    lbl100.Text = this.txtQuestion6.Text;
                    this.txtQuestion6.Clear();

                    // Check if it's the last time
                    if (Question6.Instance.TimeSubstracted == 4)
                    {
                        this.btnQuestion6.Text = "החסר והמשך";

                        // Set button alignment
                        this.btnQuestion6.Location =
                            new Point((this.tabPage6.Size.Width -
                        this.btnQuestion6.Size.Width) / 2, this.btnQuestion6.Location.Y);
                    }

                    // Set the cursor in the text box
                    this.txtQuestion6.Focus();
                }
                else
                {
                    MessageBox.Show("Test");
                }
            }
            else
            {
                MessageBox.Show(Question6.Instance.AnswerScore.ToString());
                nextQuestion();
            }
        }

        private void btnQuestion8_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                Question8.Instance.checkAnswer(
                    Convert.ToInt32(txtQuestion8Minutes.Value), 
                    Convert.ToInt32(txtQuestion8Hour.Value)).ToString());
        }
    }
}
