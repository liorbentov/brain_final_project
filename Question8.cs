using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Question8 : Question<Question8>
    {
        int m_nHour;
        int m_nMinutes;

        public int Hour { get { return this.m_nHour; } private set { this.m_nHour = value; } }
        public int Minutes { get { return this.m_nMinutes; } private set { this.m_nMinutes = value; } }

        public Question8()
        {
            this.m_nHour = new Random().Next(0, 11);
            this.m_nMinutes = new Random().Next(0, 59);

            this.AnswerScore = 2;
        }

        public double checkAnswer(int minutes, int hours)
        {
            // If hour and minutes are in place and exact
            if ((hours == this.Hour) && (minutes == this.Minutes))
            {
                this.AnswerScore -= 0;
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
                    // If the places are wrong and there is deviation in one place
                    if (((hours == this.Minutes) && (minutes >= this.Hour - 1) && (minutes <= this.Hour + 1)) ||
                        (((minutes == this.Hour) && (hours >= this.Minutes - 1) && (hours <= this.Minutes + 1))))
                    {
                        this.AnswerScore -= 1;
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
                                    // If minutes are exact
                                    if (minutes == this.Minutes)
                                    {
                                        this.AnswerScore -= 1;
                                    }
                                    else
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
