using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    /// <summary>
    /// This class handles the first class of the test:
    /// The user has to insert the current date
    /// </summary>
    public class Question1 : Question<Question1>
    {
        // Variables defintion
        private int m_nDay;
        private int m_nMonth;
        private int m_nYear;
        private int m_nSeason;

        /// <summary>
        /// Constructor
        /// </summary>
        public Question1()
        {
            // Get correct data from configuration
            this.m_nDay = Int32.Parse(ConfigurationManager.AppSettings.Get("Question1Day"));
            this.m_nMonth = Int32.Parse(ConfigurationManager.AppSettings.Get("Question1Month")) - 1;
            this.m_nYear = Int32.Parse(ConfigurationManager.AppSettings.Get("Question1Year"));
            this.m_nSeason = Int32.Parse(ConfigurationManager.AppSettings.Get("Question1Season"));

            // Set the score to the max
            this.AnswerScore = 4;
        }

        /// <summary>
        /// This method calculate the questions score according to the user answers
        /// </summary>
        /// <param name="nDayAnswer">int. the user answer for the current day</param>
        /// <param name="nMonthAnswer">int. the user answer for the current month</param>
        /// <param name="nYearAnswer">int. the user answer for the current year</param>
        /// <param name="nSeasonAnswer">int. the user answer for the current season</param>
        /// <returns>double. The calculated score for the current question</returns>
        public double checkAnswer(int nDayAnswer, int nMonthAnswer, int nYearAnswer, int nSeasonAnswer)
        {
            // Day
            if (nDayAnswer != this.m_nDay)
            {
                // Checks day before/after the currrent
                if ((nDayAnswer == this.m_nDay - 1) || (nDayAnswer == this.m_nDay + 1))
                {
                    this.AnswerScore -= 0.5;
                }
                else
                {
                    this.AnswerScore -= 1;
                }
            }

            // Month
            if (nMonthAnswer != (this.m_nMonth))
            {
                // Checks month before/after the currrent
                if ((nMonthAnswer == this.m_nMonth - 1) || (nMonthAnswer == this.m_nMonth + 1))
                {
                    this.AnswerScore -= 0.5;
                }
                else
                {
                    this.AnswerScore -= 1;
                }
            }

            // Year
            if (nYearAnswer != this.m_nYear)
            {
                // Checks year before/after the currrent
                if ((nYearAnswer == this.m_nYear - 1) || (nYearAnswer == this.m_nYear + 1))
                {
                    this.AnswerScore -= 0.5;
                }
                else
                {
                    this.AnswerScore -= 1;
                }
            }

            // Season
            if (nSeasonAnswer != (this.m_nSeason))
            {
                // Checks season before/after the currrent
                if ((nSeasonAnswer == this.m_nSeason - 1) || (nSeasonAnswer == this.m_nSeason + 1))
                {
                    this.AnswerScore -= 0.5;
                }
                else
                {
                    this.AnswerScore -= 1;
                }
            }

            return (this.AnswerScore);
        }
    }
}
