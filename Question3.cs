using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    /// <summary>
    /// This class handles the third class of the test:
    /// The user has to memorize three random nouns
    /// </summary>
    public class Question3 : Question<Question3>
    {
        // Variables definition
        private int nNounsShowed;
        private List<string> lstAvailableNouns; // Contains the available nouns (decrease when reveal noun)
        private List<string> lstShowedNouns; // Contains the showed nouns for later use when calculating score
        private Random nounsRandom;

        /// <summary>
        /// Constructor
        /// </summary>
        public Question3()
        {
            // Reset the nouns showed counter, Gets all of the nouns from the csv file
            nNounsShowed = 0;
            lstAvailableNouns = new List<string>(Program.testMistakesDictionary.Keys);
            lstShowedNouns = new List<string>();
            nounsRandom = new Random();
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

            // Add the noun to the showed list for later use in q5
            lstShowedNouns.Add(currNoun);

            // Remove from the availble nouns so this noun will not be available to the user again
            lstAvailableNouns.Remove(currNoun);
            nNounsShowed++;

            return (currNoun);
        }

        /// <summary>
        /// This method returns the number of nouns that have been showed to the user
        /// </summary>
        /// <returns>int. The number of nouns showed</returns>
        public int getNounsNumberShowed()
        {
            return nNounsShowed;
        }

        /// <summary>
        /// This method returns the list of nouns that showed for later use in q5
        /// </summary>
        /// <returns>List. The showed nouns</returns>
        public List<string> getNounsShowed()
        {
            return lstShowedNouns;
        }
    }
}
