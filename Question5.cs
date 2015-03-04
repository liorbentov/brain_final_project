using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    /// <summary>
    /// This class handles the fifth class of the test:
    /// The user has to identify write all of the nouns from q3
    /// </summary>
    public class Question5 : Question<Question5>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Question5()
        {
            this.AnswerScore = 3;
        }

        /// <summary>
        /// This method calculate the questions score according to the user answers
        /// </summary>
        /// <param name="answersToCheck">List. Unordered list of the user answers</param>
        /// <returns>double. The calculated score for the current question</returns>
        public double checkAnswer(List<string> answersToCheck)
        {
            // Runs all over the user answers 
            for (int currAnswerIndex = 0; currAnswerIndex < answersToCheck.Count; currAnswerIndex++)
            {
                bool bIsAnswerFound = false;
                string currAnswer = answersToCheck[currAnswerIndex];

                // Runs all over the showed nouns (because the order of the answer doesn't matter
                for (int correctAnswerIndex = 0;
                        correctAnswerIndex < Question3.Instance.getNounsShowed().Count; 
                        correctAnswerIndex++)
                {
                    // Gets the correct answer
                    string correctAnswer = Question3.Instance.getNounsShowed()[correctAnswerIndex];

                    // Checks if the user wrong
                    if (correctAnswer != currAnswer)
                    {
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
                    }
                    else
                    {
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

            return this.AnswerScore;
        }
    }
}
