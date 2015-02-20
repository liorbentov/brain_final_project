using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Question5 : Question<Question4>
    {

        public Question5()
        {
            this.AnswerScore = 3;
        }

        public double checkAnswer(List<string> answersToCheck)
        {
            for (int currAnswerIndex = 0; currAnswerIndex < answersToCheck.Count; currAnswerIndex++)
            {
                bool bIsAnswerFound = false;
                string currAnswer = answersToCheck[currAnswerIndex];

                for (int correctAnswerIndex = 0;
                        correctAnswerIndex < Question3.Instance.getNounsShowed().Count; 
                        correctAnswerIndex++)
                {
                    string correctAnswer = Question3.Instance.getNounsShowed()[correctAnswerIndex];

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
