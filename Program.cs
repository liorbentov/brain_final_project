using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    static class Program
    {
        public static Dictionary<string, List<Mistake>> testMistakesDictionary = new Dictionary<string, List<Mistake>>();
        public static Dictionary<string, Bitmap> nounsImages = new Dictionary<string, Bitmap>();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TestStart());
        }
    }
}
