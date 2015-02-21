using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    /// <summary>
    /// This class handles the fourth class of the test:
    /// The user has to identify three random pictures of nouns
    /// </summary>
    public class Question4 : Question<Question4>
    {
        // Variables definition
        private int nNounsShowed;
        private List<string> lstAvailableNouns; // Contains the available nouns (decrease when reveal noun)
        private List<string> lstShowedNouns; // Contains the showed nouns for later use when calculating score
        private Random nounsRandom;
        
        /// <summary>
        /// Constructor
        /// </summary>
        public Question4()
        {
            // Reset the nouns showed counter, Gets all of the nouns from the csv file
            nNounsShowed = 0;
            lstAvailableNouns = new List<string>(Program.nounsImages.Keys); 
            lstShowedNouns = new List<string>(); 
            nounsRandom = new Random();
            this.AnswerScore = 3;
        }

        /// <summary>
        /// This method handles noun request from the form.
        /// </summary>
        /// <returns>string. The next random noun</returns>
        public string getNextNoun()
        {
            // Randomize next noun from the nouns list
            nounsRandom = new Random();
            int nextNoun = nounsRandom.Next(0, lstAvailableNouns.Count); 
            string currNoun = lstAvailableNouns[nextNoun];

            // Add the noun to the showed list for later use when calculating score
            // In this case the order is important so using "insert" instead of "add" is important
            lstShowedNouns.Insert(lstShowedNouns.Count, currNoun);

            // Remove from the availble nouns so this noun will not be available to the user again
            lstAvailableNouns.Remove(currNoun);
            nNounsShowed++;

            return (currNoun);
        }

        /// <summary>
        /// This method handles picture request of specific noun
        /// </summary>
        /// <param name="wantedNounBitmap">string. The wanted noun</param>
        /// <returns>bitmap. the wanted noun bitmap</returns>
        public Bitmap getNextNounBitmap(string wantedNounBitmap)
        {
            return (Program.nounsImages[wantedNounBitmap]);
        }

        /// <summary>
        /// This method returns the number of nouns pictures that have been showed to the user
        /// </summary>
        /// <returns>int. The number of nouns showed</returns>
        public int getNounsNumberShowed()
        {
            return nNounsShowed;
        }

        /// <summary>
        /// This method calculate the questions score according to the user answers
        /// </summary>
        /// <param name="answersToCheck">List. Ordered list of the user answers</param>
        /// <returns>double. The calculated score for the current question</returns>
        public double checkAnswer(List<string> answersToCheck) {
            // Runs all over the answers according to the order of the answers and the showed pictures
            for (int currAnswerIndex = 0; currAnswerIndex < answersToCheck.Count; currAnswerIndex++)
            {
                // Gets the current answer and the correct answer
                string currAnswer = answersToCheck[currAnswerIndex];
                string correctAnswer = lstShowedNouns[currAnswerIndex];

                // Checks if the user wrong
                if (correctAnswer != currAnswer)
                {
                    bool bIsAnswerFound = false;

                    // Checks all over the common typos of the correct answer comparing to the user answer
                    foreach (Mistake currMistake in Program.testMistakesDictionary[correctAnswer])
                    {
                        // If the user correct but has typo
                        if (currMistake.input == currAnswer)
                        {
                            // Substracts the relative score
                            this.AnswerScore -= currMistake.toSubtract;
                            bIsAnswerFound = true;
                            break;
                        }
                    }

                    // If no typo found the user totally wrong
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
