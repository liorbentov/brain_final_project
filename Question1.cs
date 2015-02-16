using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Question1
    {
        private int m_nDay;
        private int m_nMonth;
        private int m_nYear;
        private int m_nSeason;
        private double m_dAnswerScore;
        private static Question1 instance;

        private Question1()
        {
            // Get correct data from configuration
            this.m_nDay = Int32.Parse(ConfigurationManager.AppSettings.Get("Question1Day"));
            this.m_nMonth = Int32.Parse(ConfigurationManager.AppSettings.Get("Question1Month")) - 1;
            this.m_nYear = Int32.Parse(ConfigurationManager.AppSettings.Get("Question1Year"));
            this.m_nSeason = Int32.Parse(ConfigurationManager.AppSettings.Get("Question1Season"));

            // Set the score to the max
            this.m_dAnswerScore = 4;
        }

        public static Question1 getInstance()
        {
            if (instance == null)
            {
                instance = new Question1();
            }

            return instance;
        }

        public double checkAnswer(int nDayAnswer, int nMonthAnswer, int nYearAnswer, int nSeasonAnswer)
        {
            // Day
            if (nDayAnswer != this.m_nDay)
            {
                if ((nDayAnswer == this.m_nDay - 1) || (nDayAnswer == this.m_nDay + 1))
                {
                    this.m_dAnswerScore -= 0.5;
                }
                else
                {
                    this.m_dAnswerScore -= 1;
                }
            }

            // Month
            if (nMonthAnswer != (this.m_nMonth))
            {
                if ((nMonthAnswer == this.m_nMonth - 1) || (nMonthAnswer == this.m_nMonth + 1))
                {
                    this.m_dAnswerScore -= 0.5;
                }
                else
                {
                    this.m_dAnswerScore -= 1;
                }
            }

            // Check Year
            if (nYearAnswer != this.m_nYear)
            {
                if ((nYearAnswer == this.m_nYear - 1) || (nYearAnswer == this.m_nYear + 1))
                {
                    this.m_dAnswerScore -= 0.5;
                }
                else
                {
                    this.m_dAnswerScore -= 1;
                }
            }

            // Check Season
            if (nSeasonAnswer != (this.m_nSeason))
            {
                if ((nSeasonAnswer == this.m_nSeason - 1) || (nSeasonAnswer == this.m_nSeason + 1))
                {
                    this.m_dAnswerScore -= 0.5;
                }
                else
                {
                    this.m_dAnswerScore -= 1;
                }
            }

            return (this.m_dAnswerScore);
        }
    }
}
