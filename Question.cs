using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    /// <summary>
    /// This abstract class determines general question at the mmse test
    /// </summary>
    /// <typeparam name="T">The current question</typeparam>
    public abstract class Question<T>
    where T : Question<T>, new()
    {
        // Holds the singleton instance of the test's question
        private static T _instance = new T();

        // Holds the current question score
        private double m_dAnswerScore = 0;

        // Holds the question time elapsed
        public Stopwatch watch = new Stopwatch();

        public static T Instance
        {
            get
            {
                return _instance;
            }
        }

        /// <summary>
        /// Gets the score for the user answer
        /// </summary>
        public double AnswerScore
        {
            get
            {
                return m_dAnswerScore;
            }
            protected set
            {
                m_dAnswerScore = value;
            }
        }

        /// <summary>
        /// Starts the timer for the current question
        /// </summary>
        public void StartWatch()
        {
            this.watch.Start();
        }

        /// <summary>
        /// Stops the timer for the current question and returns the time elapsed
        /// </summary>
        /// <returns></returns>
        public long StopWatch()
        {
            this.watch.Stop();
            return (this.watch.ElapsedMilliseconds);
        }

        /// <summary>
        /// Resets the current question (for use when starting new test)
        /// </summary>
        public void reset()
        {
            _instance = new T();
        }
    }
}
