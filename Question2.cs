using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    /// <summary>
    /// This class handles the second class of the test:
    /// The user has to insert the current location
    /// </summary>
    public class Question2 : Question<Question2>
    {
        // Variable definition
        private int m_nCity;
        private int m_nCountry;
        private int m_nFloor;

        /// <summary>
        /// Constructor
        /// </summary>
        public Question2()
        {
            // Get correct data from configuration
            this.m_nCountry = Int32.Parse(ConfigurationManager.AppSettings.Get("Question2Country"));
            this.m_nCity = Int32.Parse(ConfigurationManager.AppSettings.Get("Question2City"));
            this.m_nFloor = Int32.Parse(ConfigurationManager.AppSettings.Get("Question2Floor"));

            // Set the score to the max
            this.AnswerScore = 3;
        }

        /// <summary>
        /// This method calculate the questions score according to the user answers
        /// </summary>
        /// <param name="nCountryAnswer">int. the user answer for the current country</param>
        /// <param name="nCityAnswer">int. the user answer for the current city</param>
        /// <param name="nFloorAnswer">int. the user answer for the current floor</param>
        /// <returns>double. The calculated score for the current question</returns>
        public double checkAnswer(int nCountryAnswer, int nCityAnswer, int nFloorAnswer)
        {
            // City
            if (nCityAnswer != this.m_nCity)
            {
                // Checks city before/after the currrent
                if ((nCityAnswer == this.m_nCity - 1) || (nCityAnswer == this.m_nCity + 1))
                {
                    this.AnswerScore -= 0.5;
                }
                else
                {
                    this.AnswerScore -= 1;
                }
            }

            // Country
            if (nCountryAnswer != (this.m_nCountry))
            {
                // Checks country before/after the currrent
                if ((nCountryAnswer == this.m_nCountry - 1) || (nCountryAnswer == this.m_nCountry + 1))
                {
                    this.AnswerScore -= 0.5;
                }
                else
                {
                    this.AnswerScore -= 1;
                }
            }

            // Check Floor
            if (nFloorAnswer != this.m_nFloor)
            {
                // Checks floor before/after the currrent
                if ((nFloorAnswer == this.m_nFloor - 1) || (nFloorAnswer == this.m_nFloor + 1))
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
