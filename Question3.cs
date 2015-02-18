using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public class Question3
    {
        private int nNounsShowed;
        private List<string> lstAvailableNouns;
        private List<string> lstShowedNouns;
        private Random nounsRandom;
        private static Question3 instance;

        private Question3()
        {
            nNounsShowed = 0;
            lstAvailableNouns = new List<string>(Program.testMistakesDictionary.Keys);
            lstShowedNouns = new List<string>();
            nounsRandom = new Random();
        }

        public static Question3 getInstance()
        {
            if (instance == null)
            {
                instance = new Question3();
            }

            return instance;
        }

        public string getNextNoun()
        {
            int nextNoun = nounsRandom.Next(0, lstAvailableNouns.Count);
            string currNoun = lstAvailableNouns[nextNoun];
            lstShowedNouns.Insert(lstShowedNouns.Count, currNoun);
            lstAvailableNouns.Remove(currNoun);
            nNounsShowed++;
            return (currNoun);
        }

        public int getNounsNumberShowed()
        {
            return nNounsShowed;
        }

        public List<string> getNounsShowed()
        {
            return lstShowedNouns;
        }

        public double checkAnswer(int nCountryAnswer, int nCityAnswer, int nFloorAnswer)
        {
            return 0;
        }
    }
}
