using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class Question6 : Question<Question6>
    {
        int m_nInitialNumber;
        int m_nTimesSubstracted;

        public int TimeSubstracted { get { return (m_nTimesSubstracted); } set { m_nTimesSubstracted = value; } }
       
        /// <summary>
        /// Constructor
        /// </summary>
        public Question6()
        {
            this.m_nInitialNumber = 100;
            this.m_nTimesSubstracted = 0;
            this.AnswerScore = 5;
        }

        /// <summary>
        /// This method calculate the questions score according to the user answers
        /// </summary>
        /// <param name="nNumberToCheck">The number after user substraction</param>
        /// <returns>double. The calculated score for the current question</returns>
        public double checkAnswer(int nNumberToCheck)
        {
            // Check if the difference is 7
            if (m_nInitialNumber - nNumberToCheck != 7)
            {
                // Check if the difference between 5 and 9
                if ((m_nInitialNumber - nNumberToCheck >= 5) &&
                    (m_nInitialNumber - nNumberToCheck <= 9))
                {
                    this.AnswerScore -= 0.5;
                }
                else
                {
                    // Else, no point for this stage
                    this.AnswerScore -= 1;
                }
            }
            
            // Sets the number to substract from
            this.m_nInitialNumber = nNumberToCheck;
            this.TimeSubstracted++;

            return this.AnswerScore;
        }
    }
}
