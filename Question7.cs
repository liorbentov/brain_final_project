using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class Question7 : Question<Question7>
    {
        private int m_nMinutes;
        private int m_nHours;

        public Question7()
        {
            // Get correct data from configuration
            this.m_nMinutes = Int32.Parse(ConfigurationManager.AppSettings.Get("Questio7Minutes"));
            this.m_nHours = Int32.Parse(ConfigurationManager.AppSettings.Get("Question7Hours"));

            // Set the score to the max
            this.AnswerScore = 3;
        }

        public double checkAnswer(int minutes, int hours)
        {
            // Check hours
            if (hours == this.m_nHours)
            {
                this.AnswerScore -= 0;
            }
            else
            {
                if (hours < this.m_nHours + 2 && hours > this.m_nHours - 2)
                {
                    this.AnswerScore -= 0.2;
                }
            }

            // Check minutes
            if (minutes == this.m_nMinutes)
            {
                this.AnswerScore += 1;
            }
            else
            {
                if (minutes < this.m_nMinutes + 2 && minutes > this.m_nMinutes - 2)
                {
                    this.AnswerScore += 0.8;
                }
            }

            // Check if the user replace the minutes and the hours places
            if (this.m_nHours == minutes && this.m_nMinutes == hours)
            {
                this.AnswerScore += 0.5;
            }
            else
            {
                if (hours < this.m_nMinutes + 2 && hours > this.m_nMinutes - 2 &&
                    (hours > this.m_nMinutes + 2 && hours < this.m_nMinutes - 2))
                {
                    this.AnswerScore += 0.2;
                }
                else
                {

                }
                    
            }

            return this.AnswerScore;
        }
    }
}
