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
    public class Test
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

        public Test(DateTime date, string userID, double score, double time)
        {
            this.Date = date;
            this.UserID = userID;
            this.Score = score;
            this.Time = time;

            InitializeTestDictionary();
        }

        /// <summary>
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

        public void endTest()
        {
            // Get Avarage for score
            // Get Avarage for time
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
            
            // Add the questions to the data string
            foreach (QuestionScore current in m_questions)
            {
                strData += (CSV_SEPEARATOR +current.Score + CSV_SEPEARATOR + current.Time);
            }

            // Write the line in the file
            using (StreamWriter w = File.AppendText(@"../../TestsResults.csv"))
            {
                w.WriteLine(strData);
            }
        }
    }

    public struct QuestionScore
    {
        public double Score, Time;

        public QuestionScore(double score, double time)
        {
            Score = score;
            Time = time;
        }
    }

    public class User
    {
        private string m_strID;
        private List<Test> m_lPreviousTest;
        private double m_dScoreAvearage;
        private double m_dTimeAvearage;

        public List<Test> PreviousTest { get { return m_lPreviousTest; } set { m_lPreviousTest = value; } }
        public double ScoreAvearage { get { return m_dScoreAvearage; } set { m_dScoreAvearage = value; } }
        public double TimeAvearage { get { return m_dTimeAvearage; } set { m_dTimeAvearage = value; } }

        public User(string ID)
        {
            this.m_strID = ID;
            this.ScoreAvearage = 0;
            this.TimeAvearage = 0;
            this.PreviousTest = new List<Test>();
        }

        public void getUserTests()
        {
            string currLine;
            int nTestCounter = 0;
            double dScores = 0;
            double dTime = 0;

            // Clear list
            this.PreviousTest.Clear();

            // Open file
            FileStream fsTestResults = new FileStream(@"../../TestsResults.csv", FileMode.Open, FileAccess.Read);
            StreamReader srReader = new StreamReader(fsTestResults);

            // Read the data and differs the data of the current user
            while (!srReader.EndOfStream)
            {
                // Read the next line
                currLine = srReader.ReadLine();
                
                // Check if the row belongs to the current user
                string[] data = currLine.Split(';');

                // If so, insert the data to arrays
                if (data[2].Equals(this.m_strID))
                {
                    // Set the date for the test object
                    DateTime dt = Convert.ToDateTime(data[0]+" "+data[1]);

                    Test tCurr = new Test(dt, data[2], double.Parse(data[3]), double.Parse((data[4]))); 

                    // Insert the test to the list
                    m_lPreviousTest.Add(tCurr);

                    // Add the score and the time for the average calculation
                    dScores += double.Parse(data[3]);
                    dTime += double.Parse(data[4]);

                    nTestCounter++;
                }
            }

            // Close file
            srReader.Close();
            fsTestResults.Close();

            // Calc Average
            m_dScoreAvearage = dScores / nTestCounter;
            m_dTimeAvearage = dTime / nTestCounter;
        }
    }
}
