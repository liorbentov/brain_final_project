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
    public partial class UserTestLog : Form
    {
        private List<Test> userTests;
        public UserTestLog(List<Test> tests)
        {
            InitializeComponent();
            this.userTests = tests;
        }

        private void UserTestLog_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void BindGrid()
        {
            // Build data table
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Date", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("Score", typeof(double)));
            dt.Columns.Add(new DataColumn("Time", typeof(double)));

            DataRow drNew;

            // Add rows to table
            foreach (Test currTest in this.userTests)
            {
                drNew = dt.NewRow();
                drNew[0] = currTest.Date;
                drNew[1] = currTest.Score;
                drNew[2] = currTest.Time;

                dt.Rows.Add(drNew);
            }

            this.dataGridView1.DataSource = dt;
        }
    }
}
