using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Question2 : Question<Question2>
    {
        private int m_nCity;
        private int m_nCountry;
        private int m_nFloor;

        public Question2()
        {
            // Get correct data from configuration
            this.m_nCountry = Int32.Parse(ConfigurationManager.AppSettings.Get("Question2Country")) - 1;
            this.m_nCity = Int32.Parse(ConfigurationManager.AppSettings.Get("Question2City")) - 1;
            this.m_nFloor = Int32.Parse(ConfigurationManager.AppSettings.Get("Question2Floor")) - 1;

            // Set the score to the max
            this.AnswerScore = 3;
        }

        public double checkAnswer(int nCityAnswer, int nCountryAnswer, int nFloorAnswer)
        {
            // City
            if (nCityAnswer != this.m_nCity)
            {
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
