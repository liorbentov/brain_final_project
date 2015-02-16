using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public struct Mistake
    {
        public string input;
        public double toSubtract;
    }

    public class Question3
    {
        private int m_nCity;
        private int m_nCountry;
        private int m_nFloor;
        private double m_dAnswerScore;
        private static Question3 instance;

        private Question3()
        {
            this.m_nCity = Int32.Parse(ConfigurationManager.AppSettings.Get("Question1City")) - 1;
            this.m_nCountry = Int32.Parse(ConfigurationManager.AppSettings.Get("Question1Month")) - 1;
            this.m_nFloor = Int32.Parse(ConfigurationManager.AppSettings.Get("Question1Floor")) - 1;
            this.m_dAnswerScore = 3;

            // Get all 10 and their possible mistakes from file to dictionary;
        }

        public static Question3 getInstance()
        {
            if (instance == null)
            {
                instance = new Question3();
            }

            return instance;
        }

        public double checkAnswer(int nCityAnswer, int nCountryAnswer, int nFloorAnswer)
        {
            // City
            if (nCityAnswer != this.m_nCity)
            {
                if ((nCityAnswer == this.m_nCity - 1) || (nCityAnswer == this.m_nCity + 1))
                {
                    this.m_dAnswerScore -= 0.5;
                }
                else
                {
                    this.m_dAnswerScore -= 1;
                }
            }

            // Country
            if (nCountryAnswer != (this.m_nCountry))
            {
                if ((nCountryAnswer == this.m_nCountry - 1) || (nCountryAnswer == this.m_nCountry + 1))
                {
                    this.m_dAnswerScore -= 0.5;
                }
                else
                {
                    this.m_dAnswerScore -= 1;
                }
            }

            // Check Floor
            if (nFloorAnswer != this.m_nFloor)
            {
                if ((nFloorAnswer == this.m_nFloor - 1) || (nFloorAnswer == this.m_nFloor + 1))
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
