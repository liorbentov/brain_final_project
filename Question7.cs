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
        private string m_strSentence;

        public int Hour { get { return this.m_nHours; } private set { this.m_nHours = value; } }
        public int Minutes { get { return this.m_nMinutes; } private set { this.m_nMinutes = value; } }
        public string Sentence { get { return this.m_strSentence; } private set { this.m_strSentence = value; } }

        /// <summary>
        /// Constructor
        /// </summary>
        public Question7()
        {
            // Get correct data from configuration
            this.Minutes = Int32.Parse(ConfigurationManager.AppSettings.Get("Question7Minutes"));
            this.Hour = Int32.Parse(ConfigurationManager.AppSettings.Get("Question7Hours"));
            this.Sentence = ConfigurationManager.AppSettings.Get("Question7Sentence");

            // Set the score to the max
            this.AnswerScore = 3;
        }

        /// <summary>
        /// This method calculate the questions score according to the user answers
        /// </summary>
        /// <param name="minutes">Minutes that the user entered</param>
        /// <param name="hours">Hours that the user entered</param>
        /// <returns>double. The calculated score for the current question</returns>
        public double checkAnswer(int minutes, int hours)
        {
            // If hour and minutes are in place and exact
            if ((hours == this.Hour) && (minutes == this.Minutes))
            {
                this.AnswerScore -= 0;
            }
            else
            {
                // If the hour is not in the AM-PM correct mode
                if (((hours + 12) % 24 == this.Hour) && (minutes == this.Minutes))
                {
                    this.AnswerScore -= 1;
                }
                else
                {
                    // If the data is exact but the places are wrong
                    if ((hours == this.Minutes) && (minutes == this.Hour))
                    {
                        this.AnswerScore -= 0.5;
                    }
                    else
                    {
                        // If the hour is not in the AM-PM correct mode
                        if (((hours + 12) % 24 == this.Minutes) && (minutes == this.Hour))
                        {
                            this.AnswerScore -= 1.5;
                        }
                        else
                        {
                            // If the places are wrong and there is deviation in one place
                            if (((hours == this.Minutes) && (minutes >= this.Hour - 1) && (minutes <= this.Hour + 1)) ||
                                (((minutes == this.Hour) && (hours >= this.Minutes - 1) && (hours <= this.Minutes + 1))))
                            {
                                this.AnswerScore -= 1;
                            }
                            else
                            {

                                // If the places are wrong and there is deviation in one place and the AM-PM mode is wrong
                                if ((((hours + 12) % 24 == this.Minutes) && (minutes >= this.Hour - 1) && (minutes <= this.Hour + 1)) ||
                                    (((minutes == this.Hour) && ((hours + 12) % 24 >= this.Minutes - 1) && ((hours + 12) % 24 <= this.Minutes + 1))))
                                {
                                    this.AnswerScore -= 2;
                                }
                                else
                                {
                                    // If the places are wrong and there is deviation in two places
                                    if ((minutes >= this.Hour - 1) && (minutes <= this.Hour + 1) &&
                                        (hours >= this.Minutes - 1) && (hours <= this.Minutes + 1))
                                    {
                                        this.AnswerScore -= 1.5;
                                    }
                                    else
                                    {
                                        // If the places are wrong and there is deviation in two places and the AM-PM mode is wrong
                                        if ((minutes >= this.Hour - 1) && (minutes <= this.Hour + 1) &&
                                            ((hours + 12) % 24 >= this.Minutes - 1) && ((hours + 12) % 24 <= this.Minutes + 1))
                                        {
                                            this.AnswerScore -= 1.5;
                                        }
                                        else
                                        {
                                            // If the hour is exact
                                            if (hours == this.Hour)
                                            {
                                                // If there is deviation in the minutes
                                                if ((minutes >= this.Minutes - 1) && (minutes <= this.Minutes + 1))
                                                {
                                                    this.AnswerScore -= 0.5;
                                                }
                                                else
                                                {
                                                    this.AnswerScore -= 1;
                                                }
                                            }
                                            else
                                            {
                                                // If the hour is exact and AM-PM mode is wrong
                                                if ((hours + 12) % 24 == this.Hour)
                                                {
                                                    // If there is deviation in the minutes
                                                    if ((minutes >= this.Minutes - 1) && (minutes <= this.Minutes + 1))
                                                    {
                                                        this.AnswerScore -= 1.5;
                                                    }
                                                    else
                                                    {
                                                        this.AnswerScore -= 2;
                                                    }
                                                }
                                                else
                                                {
                                                    // If hour with deviation of 1
                                                    if ((hours >= this.Hour - 1) && (hours <= this.Hour + 1))
                                                    {
                                                        // If minutes are exact
                                                        if (minutes == this.Minutes)
                                                        {
                                                            this.AnswerScore -= 0.5;
                                                        }
                                                        else
                                                        {
                                                            // If there is deviation in the minutes
                                                            if ((minutes >= this.Minutes - 1) && (minutes <= this.Minutes + 1))
                                                            {
                                                                this.AnswerScore -= 1;
                                                            }
                                                            else
                                                            {
                                                                this.AnswerScore -= 1.5;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        // If hour with deviation of 1 and AM-PM mode is wrong
                                                        if (((hours + 12) % 24 >= this.Hour - 1) && ((hours + 12) % 24 <= this.Hour + 1))
                                                        {
                                                            // If minutes are exact
                                                            if (minutes == this.Minutes)
                                                            {
                                                                this.AnswerScore -= 1.5;
                                                            }
                                                            else
                                                            {
                                                                // If there is deviation in the minutes
                                                                if ((minutes >= this.Minutes - 1) && (minutes <= this.Minutes + 1))
                                                                {
                                                                    this.AnswerScore -= 2;
                                                                }
                                                                else
                                                                {
                                                                    this.AnswerScore -= 2.5;
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            // If minutes are exact
                                                            if (minutes == this.Minutes)
                                                            {
                                                                this.AnswerScore -= 2;
                                                            }
                                                            else
                                                            {
                                                                // If there is deviation in the minutes
                                                                if ((minutes >= this.Minutes - 1) && (minutes <= this.Minutes + 1))
                                                                {
                                                                    this.AnswerScore -= 2.5;
                                                                }
                                                                else
                                                                {
                                                                    this.AnswerScore -= 3;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return this.AnswerScore;
        }
    }
}
