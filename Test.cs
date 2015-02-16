using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public struct Mistake
    {
        public string input;
        public double toSubtract;

        public Mistake(string newInput, double newToSubtract) {
            input = newInput;
            toSubtract = newToSubtract;
        }
    }

    /// <summary>
    /// This class represents the Test
    /// </summary>
    class Test
    {

        private const char CSV_SEPEARATOR = ',';
        private const string DICTIONARY_FILE_NAME = "nouns.csv";

        private string m_strUserID;
        private double m_dScore;
        private double m_dTime;
        private DateTime m_dtDate;
        private QuestionScore[] m_questions = new QuestionScore[7];


        public string UserID { get { return this.m_strUserID; } set { this.m_strUserID = value; } }
        public double Score { get { return this.m_dScore; } set { this.m_dScore = value; } }
        public double Time { get { return this.m_dTime; } set { this.m_dTime = value; } }
        public DateTime Date { get { return this.m_dtDate; } set { this.m_dtDate = value; } }

        /// <summary>
        /// Constructor
        /// </summary>
        public Test()
        {
            this.Date = DateTime.Now;
            InitializeTestDictionary();
        }

        private void InitializeTestDictionary()
        {
            FileStream dictionaryFS = new FileStream(ConfigurationManager.AppSettings.Get("MistakesDictionaryPath") +
                DICTIONARY_FILE_NAME, FileMode.Open, FileAccess.Read);
            StreamReader dictionarySR = new StreamReader(dictionaryFS, Encoding.UTF8);
            while (!dictionarySR.EndOfStream)
            {
                string[] currLine = dictionarySR.ReadLine().Split(CSV_SEPEARATOR);
                List<Mistake> mistakes = new List<Mistake>();

                for (int lineIndex = 1; lineIndex <= currLine.Length - 1; lineIndex+=2)
                {
                    if (currLine[lineIndex] != string.Empty)
                    {
                        Mistake mistakeToAdd = new Mistake(currLine[lineIndex], double.Parse(currLine[lineIndex + 1]));
                        mistakes.Add(mistakeToAdd);
                    }
                    else
                    {
                        break;
                    }
                }
                Program.testMistakesDictionary.Add(currLine[0], mistakes);
            }
        }

        /// <summary>
        /// Start the test (Questionaire)
        /// </summary>
        public void startTest()
        {
        }

        /// <summary>
        /// Save the current question score
        /// </summary>
        /// <param name="index">Question Index (1-7)</param>
        /// <param name="score">Question Score</param>
        public void saveScore(int index, QuestionScore score)
        {
            this.m_questions[index - 1] = score;
        }

        /// <summary>
        /// Save the test results to file
        /// </summary>
        private void saveTestToFile()
        {
            // Set the data to one line
            string strData = Date.ToShortDateString() +
                CSV_SEPEARATOR + Date.ToShortTimeString() +
                CSV_SEPEARATOR + UserID + CSV_SEPEARATOR + Score +
                CSV_SEPEARATOR + Time;
            

            // Open file of tests

            // Write the line in the file

            // Close the file
        }
    }

    struct QuestionScore
    {
        public double Score;
        public double Time;
    }

    class User
    {
        private string m_strID;
        private List<Test> previousTest;
    }
}
