using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class Test
    {
        private string m_strUserID;
        private double m_dScore;
        private double m_dTime;
        private DateTime m_dtDate;
        private QuestionScore[] m_questions = new QuestionScore[7];
        private Form1 questionsForm;


        public string UserID { get { return this.m_strUserID; } set { this.m_strUserID = value; } }
        public double Score { get { return this.m_dScore; } set { this.m_dScore = value; } }
        public double Time { get { return this.m_dTime; } set { this.m_dTime = value; } }
        public DateTime Date { get { return this.m_dtDate; } set { this.m_dtDate = value; } }

        public Test()
        {
            this.Date = DateTime.Now;
            questionsForm = new Form1();
        }

        public void startTest()
        {
            this.questionsForm.Show();
        }

        public void saveScore(int index, QuestionScore score)
        {
            this.m_questions[index] = score;
        }
    }

    struct QuestionScore
    {
        public double Score;
        public double Time;
    }

    class User
    {
        private string m_strID;
        private List<Test> previousTest;
    }
}
