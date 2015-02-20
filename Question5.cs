using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Question5 : Question<Question4>
    {
        private static Question5 instance;

        public Question5()
        {
            this.AnswerScore = 3;
        }

        public static Question5 getInstance()
        {
            if (instance == null)
            {
                instance = new Question5();
            }

            return instance;
        }

        public double checkAnswer(List<string> answersToCheck)
        {
            for (int currAnswerIndex = 0; currAnswerIndex < answersToCheck.Count; currAnswerIndex++)
            {
                bool bIsAnswerFound = false;
                string currAnswer = answersToCheck[currAnswerIndex];

                for (int correctAnswerIndex = 0; 
                        correctAnswerIndex < Question3.getInstance().getNounsShowed().Count; 
                        correctAnswerIndex++)
                {
                    string correctAnswer = Question3.getInstance().getNounsShowed()[correctAnswerIndex];

                    if (correctAnswer != currAnswer)
                    {
                        foreach (Mistake currMistake in Program.testMistakesDictionary[correctAnswer])
                        {
                            if (currMistake.input == currAnswer)
                            {
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

                if (!bIsAnswerFound)
                {
                    this.AnswerScore -= 1;
                }
            }

            return this.AnswerScore;
        }
    }
}
