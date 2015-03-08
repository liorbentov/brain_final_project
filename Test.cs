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
        public const char CSV_SEPARATOR = ',';
        public const string RESULTS_FILE_NAME = "TestResults.csv";
        private const string DICTIONARY_FILE_NAME = "nouns.csv";
        private const string NOUN_PIC_SUFFIX = ".png";
        private const int NUMBER_OF_QUESTIONS = 7;

        // Data Members
        private string m_strUserID;
        private User m_uUser;
        private double m_dScore = 0;
        private double m_dTime = 0;
        private DateTime m_dtDate;
        private List<QuestionScore> m_questions = new List<QuestionScore>();

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
                string[] currLine = dictionarySR.ReadLine().Split(CSV_SEPARATOR);
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

        public bool isOver()
        {
            return (this.m_questions.Count == NUMBER_OF_QUESTIONS);
        }

        public void endTest()
        {
            // Calculate score and time
            foreach (QuestionScore curr in this.m_questions)
            {
                this.Score += curr.Score;
                this.Time += curr.Time;
            }
        }

        /// <summary>
        /// Save the current question score
        /// </summary>
        /// <param name="index">Question Index (1-8)</param>
        /// <param name="score">Question Score</param>
        public void saveScore(int index, QuestionScore score)
        {
            // Ignore index == 3 because it's not really a question
            if (index != 3)
            {
                if (index < 3)
                {
                    this.m_questions.Insert(index - 1, score);
                }
                else
                {
                    this.m_questions.Insert(index - 2, score);
                }
            }
        }

        /// <summary>
        /// Save the test results to file
        /// </summary>
        public void saveTestToFile()
        {
            // Set the data to one line
            string strData = Date.ToShortDateString() +
                CSV_SEPARATOR + Date.ToShortTimeString() +
                CSV_SEPARATOR + User.ID + CSV_SEPARATOR + Score +
                CSV_SEPARATOR + Time.ToString().Substring(0, 5);
            
            // Add the questions to the data string
            foreach (QuestionScore current in m_questions)
            {
                strData += (CSV_SEPARATOR + current.Score.ToString() + 
                    CSV_SEPARATOR + current.Time.ToString());
            }

            // Write the line in the file
            using (StreamWriter w = File.AppendText(RESULTS_FILE_NAME))
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
}
