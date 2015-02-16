using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public abstract class Question<T>
    where T : Question<T>, new()
    {
        private static T _instance = new T();
        private double m_dAnswerScore = 0;

        public static T Instance
        {
            get
            {
                return _instance;
            }
        }

        protected double AnswerScore
        {
            get
            {
                return m_dAnswerScore;
            }
            set
            {
                m_dAnswerScore = value;
            }
        }
    }
}
