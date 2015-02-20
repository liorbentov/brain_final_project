using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    /// <summary>
    /// This struct represent the typos
    /// </summary>
    public struct Mistake
    {
        public string input;
        public double toSubtract;

        /// <summary>
        /// Constructor
        /// </summary>
        public Mistake(string newInput, double newToSubtract) {
            input = newInput;
            toSubtract = newToSubtract;
        }
    }

    /// <summary>
    /// This class represents the Test
    /// </summary>
    [Serializable]
    public class Test
    {
        // Const Members
        public const char CSV_SEPEARATOR = ',';
        private const string DICTIONARY_FILE_NAME = "nouns.csv";
        private const string NOUN_PIC_SUFFIX = ".png";

        // Data Members
        private string m_strUserID;
        private User m_uUser;
        private double m_dScore = 0;
        private double m_dTime = 0;
        private DateTime m_dtDate;
        private QuestionScore[] m_questions = new QuestionScore[7];

        // Getters And Setters
        public string UserID { get { return this.m_strUserID; } set { this.m_strUserID = value; } }
        public double Score { get { return this.m_dScore; } set { this.m_dScore = value; } }
        public double Time { get { return this.m_dTime; } set { this.m_dTime = value; } }
        public DateTime Date { get { return this.m_dtDate; } set { this.m_dtDate = value; } }
        public User User { get { return this.m_uUser; } private set { this.m_uUser = value; } }

        /// <summary>
        /// Constructor
        /// </summary>
        public Test() : this(DateTime.Now, string.Empty, 0, 0){}

        /// <summary>
        /// Constructor
        /// </summary>
        public Test(DateTime date, string userID, double score, double time)
        {
            this.Date = date;
            this.User = new User(userID);
            this.Score = score;
            this.Time = time;

            // InitializeData
            // Check if we already initialized the data
            if (Program.testMistakesDictionary.Count == 0)
            {
                InitializeTestDictionary();
            }

            if (Program.nounsImages.Count == 0)
            {
                LoadNounsImages();
            }
        }

        /// <summary>
        /// This method initialize the test dictionary nouns from csv file (use in questions 3-5)
        /// </summary>
        private void InitializeTestDictionary()
        {
            // File stream and reader definition
            FileStream dictionaryFS = new FileStream(ConfigurationManager.AppSettings.Get("MistakesDictionaryPath") +
                DICTIONARY_FILE_NAME, FileMode.Open, FileAccess.Read);
            StreamReader dictionarySR = new StreamReader(dictionaryFS, Encoding.UTF8);

            // Reads the file until the end
            while (!dictionarySR.EndOfStream)
            {
                // Gets the correct noun
                string[] currLine = dictionarySR.ReadLine().Split(CSV_SEPEARATOR);
                List<Mistake> mistakes = new List<Mistake>();

                // Load all of it's common typos into the dictionary
                for (int lineIndex = 1; lineIndex <= currLine.Length - 1; lineIndex += 2)
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

        // Load all of the nouns images according to the nouns from the csv file
        private void LoadNounsImages()
        {
            // Runs all over the nouns
            foreach (string currNoun in Program.testMistakesDictionary.Keys) {
                // Gets the picture
                Bitmap picToAdd = new Bitmap(Image.FromFile(
                    ConfigurationManager.AppSettings.Get("NounsImagesPath") + 
                        currNoun + NOUN_PIC_SUFFIX));

                // Load it into the Dictionary
                Program.nounsImages.Add(currNoun, picToAdd);
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
            // Calculate score and time
            foreach (QuestionScore curr in this.m_questions)
            {
                this.Score += curr.Score;
                this.Time += curr.Time;
            }

            saveTestToFile();
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
                CSV_SEPEARATOR + User.ID + CSV_SEPEARATOR + Score +
                CSV_SEPEARATOR + Time.ToString().Substring(0, 5);
            
            // Add the questions to the data string
            foreach (QuestionScore current in m_questions)
            {
                strData += (CSV_SEPEARATOR + current.Score.ToString() + 
                    CSV_SEPEARATOR + current.Time.ToString());
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

        public string ID { get { return this.m_strID; } }
        public List<Test> PreviousTest { get { return m_lPreviousTest; } set { m_lPreviousTest = value; } }
        public double ScoreAvearage { get { return m_dScoreAvearage; } set { m_dScoreAvearage = value; } }
        public double TimeAvearage { get { return m_dTimeAvearage; } set { m_dTimeAvearage = value; } }

        public User(string ID)
        {
            this.m_strID = ID;
            this.ScoreAvearage = 0;
            this.TimeAvearage = 0;
            this.PreviousTest = new List<Test>();

            this.getUserTests();
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

            // Read the first line because it is the header
            if (!srReader.EndOfStream)
            {
                srReader.ReadLine();
            }

            // Read the data and differs the data of the current user
            while (!srReader.EndOfStream)
            {
                // Read the next line
                currLine = srReader.ReadLine();
                
                // Check if the row belongs to the current user
                string[] data = currLine.Split(Test.CSV_SEPEARATOR);

                // If so, insert the data to arrays
                if (data[2].Equals(this.m_strID))
                {
                    Test tCurr = new Test();
                    tCurr.Date = convertStringsToDate(data[0], data[1]);
                    tCurr.UserID = data[2];
                    tCurr.Score = double.Parse(data[3]);
                    tCurr.Time = double.Parse(data[4]);

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

        private DateTime convertStringsToDate(string strDate, string strTime)
        {
            return (new DateTime(Int32.Parse(strDate.Split('/')[2]),
                Int32.Parse(strDate.Split('/')[1]),
                Int32.Parse(strDate.Split('/')[0]),
                Int32.Parse(strTime.Split(':')[0]),
                Int32.Parse(strTime.Split(':')[1]), 0));
        }
    }
}
