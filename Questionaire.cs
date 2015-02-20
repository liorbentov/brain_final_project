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
using System.Threading;

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
                this.btnQuestion1, this.btnQuestion2, null, 
                this.btnQuestion4, this.btnQuestion5, this.btnQuestion6, 
                this.btnQuestion7, this.btnQuestion8};
        }

        public void runQuestion3Timer(object sender, EventArgs e)
        {
            if (Question3.getInstance().getNounsNumberShowed() == 3)
            {
                GlobalTimer.Tick -= runQuestion3Timer;
                GlobalTimer.Stop();
                this.nounPicture1.Image =
                    Question4.getInstance().getNextNounBitmap(Question4.getInstance().getNextNoun());
                nextQuestion(new QuestionScore());
            }
            else
            {
                lblRandomNouns.Text = Question3.getInstance().getNextNoun();
            }
        }

        public void newTabSelected(object sender, EventArgs e)
        {
            this.timer1.Tick -= newTabSelected;
            this.timer1.Stop();
            foreach (Control c in this.tabControl1.SelectedTab.Controls)
            {
                c.Enabled = true;
            }
        }

        private void question2_Check(object sender, EventArgs e)
        {
            if ((cbCountry.Text != string.Empty) && (cbCity.Text != null) &&
                (cbFloor.Text != string.Empty))
            {
                QuestionScore qs = new QuestionScore(Question2.Instance.checkAnswer(cbCountry.SelectedIndex,
                    cbCity.SelectedIndex, cbFloor.SelectedIndex), 0);
                btnQuestion2.Enabled = false;
                //tabControl1.SelectedTab = tabPage3;
                GlobalTimer.Tick += runQuestion3Timer;
                GlobalTimer.Start();
                lblRandomNouns.Text = Question3.getInstance().getNextNoun();
                nextQuestion(qs);
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
                QuestionScore qs = new QuestionScore(Question1.Instance.checkAnswer(Int32.Parse(cbDay.Text),
                    cbMonth.SelectedIndex, Int32.Parse(cbYear.Text), cbSeason.SelectedIndex), 0);
                btnQuestion1.Enabled = false;
                nextQuestion(qs);
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
            if (this.tabControl1.SelectedIndex != currQuestion - 1)
            {
                this.tabControl1.SelectedIndex = currQuestion - 1;
            }

            //currQuestion = 6;
            this.AcceptButton = this.questionButtons[currQuestion - 1];

            foreach (Control c in this.tabControl1.SelectedTab.Controls)
            {
                c.Enabled = false;
            }

            if (this.tabControl1.SelectedIndex == 7)
            {
                this.analogClock1.setTime(
                    new DateTime(1, 1, 1, Question8.Instance.Hour, Question8.Instance.Minutes, 0));
            }

            this.timer1.Tick += newTabSelected;
            this.timer1.Start();
        }

        private void Questionaire_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void nextQuestion(QuestionScore qsScore)
        {

            this.currTest.saveScore(this.currQuestion, qsScore);
            this.currQuestion++;
            if (this.currQuestion == 5)
            {
                this.currQuestion++;
            }
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
                nextQuestion(new QuestionScore(Question6.Instance.AnswerScore, 0));
            }
        }

        private void btnQuestion8_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                Question8.Instance.checkAnswer(
                    Convert.ToInt32(txtQuestion8Minutes.Value), 
                    Convert.ToInt32(txtQuestion8Hour.Value)).ToString());
            this.Close();
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
                        btnQuestion4.Enabled = false;
                        nextQuestion(new QuestionScore(Question4.getInstance().checkAnswer(answersToCheck), 0));
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
            //if ((this.nounMemoryText1.Text == string.Empty) || 
            //    (this.nounMemoryText2.Text == string.Empty) ||
            //    (this.nounMemoryText3.Text == string.Empty))
            //{
            //    MessageBox.Show("יש למלא את כל השדות לפני שתוכל להמשיך בשאלה");
            //}
            //else
            //{
            //    List<string> answersToCheck = new List<string>();
            //    answersToCheck.Add(this.nounMemoryText1.Text);
            //    answersToCheck.Add(this.nounMemoryText2.Text);
            //    answersToCheck.Add(this.nounMemoryText3.Text);
            //    MessageBox.Show(Question5.getInstance().checkAnswer(answersToCheck).ToString());
            //    btnQuestion4.Enabled = false;
            //    nextQuestion();
            //}
        }

        private void btnQuestion7_Click(object sender, EventArgs e)
        {
            nextQuestion(new QuestionScore(
                Question7.Instance.checkAnswer(
                    Convert.ToInt32(txtQuestion7Minutes.Value),
                    Convert.ToInt32(txtQuestion7Hours.Value)), 0));
        }

        private void Questionaire_Load(object sender, EventArgs e)
        {
            // Select the first tab
            this.tabControl1.SelectedIndex = 0;
        }
    }
}
