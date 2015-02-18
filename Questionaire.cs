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
                this.btnQuestion1, this.btnQuestion2, this.button3, this.button4, this.btnQuestion8, this.btnQuestion6};
        }

        public void runQuestion3Timer(object sender, EventArgs e)
        {
            if (Question3.getInstance().getNounsNumberShowed() == 3)
            {
                GlobalTimer.Tick -= runQuestion3Timer;
                GlobalTimer.Stop();
                this.nounPicture1.Image =
                    Question4.getInstance().getNextNounBitmap(Question4.getInstance().getNextNoun());
                nextQuestion();
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
                btnQuestion2.Enabled = false;
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
                btnQuestion1.Enabled = false;
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

        private void GlobalTimer_Tick(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            switch (Question4.getInstance().getNounsNumberShowed()) 
            {
                case (1) :
                {
                    if (this.nounPictureText1.Text != string.Empty) {
                        nounPicture1.Visible = false;
                        nounPictureText1.Visible = false;
                        nounPicture2.Image = 
                            Question4.getInstance().getNextNounBitmap(
                                Question4.getInstance().getNextNoun());
                        nounPicture2.Visible = true;
                        nounPictureText2.Visible = true;
                        nounPictureText2.Focus();
                    }
                    else
                    {
                        MessageBox.Show("יש למלא את תשובה שתוכל להמשיך בשאלה");
                    }
                    break;
                }
                case (2) :
                {
                    if (this.nounPictureText1.Text != string.Empty) {
                        nounPicture2.Visible = false;
                        nounPictureText2.Visible = false;
                        nounPicture3.Image = 
                            Question4.getInstance().getNextNounBitmap(
                                Question4.getInstance().getNextNoun());
                        nounPicture3.Visible = true;
                        nounPictureText3.Visible = true;
                        nounPictureText3.Focus();
                    }
                    else
                    {
                        MessageBox.Show("יש למלא את תשובה שתוכל להמשיך בשאלה");
                    }
                    break;
                }
                case (3) :
                {
                    if (this.nounPictureText3.Text != string.Empty) {
                        List<string> answersToCheck = new List<string>();
                        answersToCheck.Insert(0, this.nounPictureText1.Text);
                        answersToCheck.Insert(1, this.nounPictureText2.Text);
                        answersToCheck.Insert(2, this.nounPictureText3.Text);
                        MessageBox.Show(Question4.getInstance().checkAnswer(answersToCheck).ToString());
                        button3.Enabled = false;
                        nextQuestion();
                    }
                    else 
                    {
                        MessageBox.Show("יש למלא את תשובה שתוכל להמשיך בשאלה");
                    }
                    break;
                }
            };
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if ((this.nounMemoryText1.Text == string.Empty) || 
                (this.nounMemoryText2.Text == string.Empty) ||
                (this.nounMemoryText3.Text == string.Empty))
            {
                MessageBox.Show("יש למלא את כל השדות לפני שתוכל להמשיך בשאלה");
            }
            else
            {
                List<string> answersToCheck = new List<string>();
                answersToCheck.Add(this.nounMemoryText1.Text);
                answersToCheck.Add(this.nounMemoryText2.Text);
                answersToCheck.Add(this.nounMemoryText3.Text);
                MessageBox.Show(Question5.getInstance().checkAnswer(answersToCheck).ToString());
                button3.Enabled = false;
                nextQuestion();
            }
        }
    }
}
