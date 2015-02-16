﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace FinalProject
{
    public partial class Questionaire : Form
    {
        public Questionaire()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((cbCountry.Text != string.Empty) && (cbCity.Text != null) &&
                (cbFloor.Text != string.Empty))
            {
                MessageBox.Show(Question2.Instance.checkAnswer(cbCountry.SelectedIndex,
                    cbCity.SelectedIndex, cbFloor.SelectedIndex).ToString());
                button1.Enabled = false;
                tabControl1.SelectedTab = tabPage2;
            }
            //Configuration conf = ConfigurationSettings.AppSettings.Get("Question1Day")
            MessageBox.Show(ConfigurationManager.AppSettings.Get("Question1Day"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Check if all the controls are full
            if ((cbDay.Text != string.Empty) && (cbMonth.Text != string.Empty) &&
                (cbYear.Text != string.Empty) && (cbSeason.Text != string.Empty))
            {
                MessageBox.Show(Question1.Instance.checkAnswer(Int32.Parse(cbDay.Text),
                    cbMonth.SelectedIndex, Int32.Parse(cbYear.Text), cbSeason.SelectedIndex).ToString());
                button1.Enabled = false;
                tabControl1.SelectedTab = tabPage2;
            }
            else
            {
                MessageBox.Show("יש למלא את כל השדות לפני שתוכל להמשיך בשאלה");
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}