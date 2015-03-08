using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class User
    {
        enum FileFields
        {
            TestDate,
            TestTime,
            UserID,
            Score,
            Time
        };

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
            FileStream fsTestResults = new FileStream(Test.RESULTS_FILE_NAME, FileMode.OpenOrCreate, FileAccess.Read);
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
                string[] data = currLine.Split(Test.CSV_SEPARATOR);

                // If so, insert the data to arrays
                if (data[(int)FileFields.UserID].Equals(this.m_strID))
                {
                    Test tCurr = new Test();
                    tCurr.Date = convertStringsToDate(data[(int)FileFields.TestDate], data[(int)FileFields.TestTime]);
                    tCurr.UserID = data[(int)FileFields.UserID];
                    tCurr.Score = double.Parse(data[(int)FileFields.Score]);
                    tCurr.Time = double.Parse(data[(int)FileFields.Time]);

                    // Insert the test to the list
                    m_lPreviousTest.Add(tCurr);

                    // Add the score and the time for the average calculation
                    dScores += double.Parse(data[(int)FileFields.Score]);
                    dTime += double.Parse(data[(int)FileFields.Time]);

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
