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
        GroupBox[] panels;

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

            // Set question panels
            this.panels = new GroupBox[] { this.gbQuestion1, this.gbQuestion2, this.gbQuestion3, 
                this.gbQuestion4, this.gbQuestion5, this.gbQuestion6, this.gbQuestion7,
                this.gbQuestion8};
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
            foreach (Control c in this.panels[this.currQuestion - 1].Controls)
            {
                c.Enabled = true;
            }
        }

        private void question2_Check(object sender, EventArgs e)
        {
            if ((cbCountry.Text != string.Empty) && (cbCity.Text != null) &&
                (cbFloor.Text != string.Empty))
            {
                Question2.Instance.StopWatch();
                QuestionScore qs = new QuestionScore(Question2.Instance.checkAnswer(cbCountry.SelectedIndex,
                    cbCity.SelectedIndex, cbFloor.SelectedIndex),
                    (Question2.Instance.watch.ElapsedMilliseconds - timer1.Interval));
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

        private void question1_Check(object sender, EventArgs e)
        {
            // Check if all the controls are full
            if ((cbDay.Text != string.Empty) && (cbMonth.Text != string.Empty) &&
                (cbYear.Text != string.Empty) && (cbSeason.Text != string.Empty))
            {
                Question1.Instance.StopWatch();
                QuestionScore qs = new QuestionScore(Question1.Instance.checkAnswer(Int32.Parse(cbDay.Text),
                    cbMonth.SelectedIndex, Int32.Parse(cbYear.Text), cbSeason.SelectedIndex),
                    (Question1.Instance.watch.ElapsedMilliseconds - timer1.Interval));
                btnQuestion1.Enabled = false;

                nextQuestion(qs);
            }
            else
            {
                MessageBox.Show("יש למלא את כל השדות לפני שתוכל להמשיך בשאלה");
            }
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
            // Save the question results
            qsScore.Time /= 1000;
            this.currTest.saveScore(this.currQuestion, qsScore);

            if (this.currQuestion == 8)
            {
                this.Close();
            }
            else
            {
                // Disable the last question
                panels[this.currQuestion - 1].Visible = false;

                // Procede to next question
                this.currQuestion++;
                tabControl1.SelectedIndex = this.currQuestion - 1;
                panels[this.currQuestion - 1].Visible = true;
            }
        }

        private void question6_Check(object sender, EventArgs e)
        {
            if (Question6.Instance.TimeSubstracted < 4)
            {
                Question6.Instance.checkAnswer(Int32.Parse(this.txtQuestion6.Text));
                lbl100.Text = this.txtQuestion6.Text;

                // Check if it's the last time
                if (Question6.Instance.TimeSubstracted == 4)
                {
                    this.btnQuestion6.Text = "החסר והמשך";
                }

                // Set the cursor in the text box
                this.txtQuestion6.Select();
                this.txtQuestion6.Select(0, this.txtQuestion6.Text.Length);
            }
            else
            {
                Question6.Instance.StopWatch();
                nextQuestion(new QuestionScore(Question6.Instance.AnswerScore, 
                    Question6.Instance.watch.ElapsedMilliseconds - 
                    timer1.Interval));
            }
        }

        private void question8_Check(object sender, EventArgs e)
        {
            Question8.Instance.StopWatch();
            nextQuestion(
                new QuestionScore(
                    Question8.Instance.checkAnswer(
                    Convert.ToInt32(txtQuestion8Minutes.Value),
                    Convert.ToInt32(txtQuestion8Hour.Value)),
                    Question8.Instance.watch.ElapsedMilliseconds -
                    timer1.Interval));
            this.Close();
        }

        private void GlobalTimer_Tick(object sender, EventArgs e)
        {

        }

        private void question4_Check(object sender, EventArgs e)
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
                        Question4.Instance.StopWatch();
                        nextQuestion(new QuestionScore(
                            Question4.getInstance().checkAnswer(answersToCheck), 
                            Question4.Instance.watch.ElapsedMilliseconds - timer1.Interval));
                    }
                    else 
                    {
                        MessageBox.Show("יש למלא את תשובה שתוכל להמשיך בשאלה");
                    }
                    break;
                }
            };
        }

        private void question5_Check(object sender, EventArgs e)
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
                Question5.Instance.StopWatch();
                nextQuestion(new QuestionScore(
                    Question5.getInstance().checkAnswer(answersToCheck), 
                    Question5.Instance.watch.ElapsedMilliseconds - timer1.Interval));
            }
        }

        private void question7_Check(object sender, EventArgs e)
        {
            Question7.Instance.StopWatch();
            nextQuestion(new QuestionScore(
                Question7.Instance.checkAnswer(
                    Convert.ToInt32(txtQuestion7Minutes.Value),
                    Convert.ToInt32(txtQuestion7Hours.Value)), 
                Question7.Instance.watch.ElapsedMilliseconds - timer1.Interval));
        }

        private void Questionaire_Load(object sender, EventArgs e)
        {
            // Select the first tab
            this.tabControl1.SelectedIndex = 0;
        }

        private void visibleChange(GroupBox gb)
        {
            if (gb.Visible)
            {
                this.AcceptButton = this.questionButtons[currQuestion - 1];

                foreach (Control c in gb.Controls)
                {
                    c.Enabled = false;
                }

                this.timer1.Tick += newTabSelected;
                this.timer1.Start();
            }        
        }

        private void gbQuestion1_VisibleChanged(object sender, EventArgs e)
        {
            visibleChange(gbQuestion1);
            Question1.Instance.StartWatch();
        }

        private void gbQuestion2_VisibleChanged(object sender, EventArgs e)
        {
            visibleChange(gbQuestion2);
            Question2.Instance.StartWatch();
        }

        private void gbQuestion4_VisibleChanged(object sender, EventArgs e)
        {
            visibleChange(gbQuestion4);
            this.nounPictureText1.SelectAll();
            Question4.Instance.StartWatch();
        }

        private void gbQuestion5_VisibleChanged(object sender, EventArgs e)
        {
            visibleChange(gbQuestion5);
            this.nounMemoryText1.Select();
            this.nounMemoryText1.SelectAll();
            Question5.Instance.StartWatch();
        }

        private void gbQuestion6_VisibleChanged(object sender, EventArgs e)
        {
            visibleChange(gbQuestion6);
            this.txtQuestion6.Select();
            this.txtQuestion6.Select(0, 1);
            Question6.Instance.StartWatch();
        }

        private void gbQuestion7_VisibleChanged(object sender, EventArgs e)
        {
            visibleChange(gbQuestion7);
            Question7.Instance.StartWatch();
        }

        private void gbQuestion8_VisibleChanged(object sender, EventArgs e)
        {
            visibleChange(gbQuestion8);
            Question8.Instance.StartWatch();
        }
    }
}
