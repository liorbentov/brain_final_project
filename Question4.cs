using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Question4 : Question<Question4>
    {
        private int nNounsShowed;
        private List<string> lstAvailableNouns;
        private List<string> lstShowedNouns;
        private Random nounsRandom;

        public Question4()
        {
            nNounsShowed = 0;
            lstAvailableNouns = new List<string>(Program.nounsImages.Keys);
            lstShowedNouns = new List<string>();
            nounsRandom = new Random();
            this.AnswerScore = 3;
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

        public Bitmap getNextNounBitmap(string wantedNounBitmap)
        {
            return (Program.nounsImages[wantedNounBitmap]);
        }

        public int getNounsNumberShowed()
        {
            return nNounsShowed;
        }

        public double checkAnswer(List<string> answersToCheck) {
            for (int currAnswerIndex = 0; currAnswerIndex < answersToCheck.Count; currAnswerIndex++)
            {
                string currAnswer = answersToCheck[currAnswerIndex];
                string correctAnswer = lstShowedNouns[currAnswerIndex];

                if (correctAnswer != currAnswer)
                {
                    bool bIsAnswerFound = false;

                    foreach (Mistake currMistake in Program.testMistakesDictionary[correctAnswer])
                    {
                        if (currMistake.input == currAnswer)
                        {
                            this.AnswerScore -= currMistake.toSubtract;
                            bIsAnswerFound = true;
                            break;
                        }
                    }

                    if (!bIsAnswerFound)
                    {
                        this.AnswerScore -= 1;
                    }
                }
            }

            return this.AnswerScore;
        }
    }
}
