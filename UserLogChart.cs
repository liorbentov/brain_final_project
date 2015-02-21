using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class UserLogChart : Form
    {
        private List<Test> userTests;
        public UserLogChart(List<Test> tests)
        {
            InitializeComponent();
            this.userTests = tests;

            this.chart1.ChartAreas.Clear();

            // Add chart area for score
            this.chart1.ChartAreas.Add("Scores");

            // Add chart area for time
            this.chart1.ChartAreas.Add("Times");

            this.chart1.Series.Add("ציוני מבחנים").ChartArea = "Scores";
            this.chart1.Series.Add("זמני מבחנים").ChartArea = "Times";

            this.chart1.Legends.Add("ציוני מבחנים");
            this.chart1.Series[0].Legend = "ציוני מבחנים";

            int index = 0;


            
            // Add points
            foreach (Test currTest in userTests)
            {
                this.chart1.Series[0].Points.Add(currTest.Score);
                this.chart1.Series[0].Points[index].AxisLabel = currTest.Date.ToShortDateString();
                this.chart1.Series[1].Points.Add(currTest.Time);
                this.chart1.Series[1].Points[index++].AxisLabel = currTest.Date.ToShortDateString();
            }
        }
    }
}
