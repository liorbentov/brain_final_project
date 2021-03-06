﻿namespace FinalProject
{
    partial class TestStartFinish
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label6 = new System.Windows.Forms.Label();
            this.btnStartTest = new System.Windows.Forms.Button();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pNewTest = new System.Windows.Forms.Panel();
            this.pResults = new System.Windows.Forms.Panel();
            this.pAvg = new System.Windows.Forms.Panel();
            this.lblTimeDiff = new System.Windows.Forms.Label();
            this.lblScoreDiff = new System.Windows.Forms.Label();
            this.lblTimeAvg = new System.Windows.Forms.Label();
            this.lblScoreAvg = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pTestResults = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnHistory = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNewTest = new System.Windows.Forms.Button();
            this.btnHistoryNew = new System.Windows.Forms.Button();
            this.pNewTest.SuspendLayout();
            this.pResults.SuspendLayout();
            this.pAvg.SuspendLayout();
            this.pTestResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label6.Location = new System.Drawing.Point(49, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 19);
            this.label6.TabIndex = 12;
            this.label6.Text = "מבחן MMSE";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnStartTest
            // 
            this.btnStartTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartTest.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnStartTest.Location = new System.Drawing.Point(62, 125);
            this.btnStartTest.Name = "btnStartTest";
            this.btnStartTest.Size = new System.Drawing.Size(75, 23);
            this.btnStartTest.TabIndex = 13;
            this.btnStartTest.Text = "התחל";
            this.btnStartTest.UseVisualStyleBackColor = true;
            this.btnStartTest.Click += new System.EventHandler(this.btnStartTest_Click);
            // 
            // txtUserID
            // 
            this.txtUserID.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtUserID.Location = new System.Drawing.Point(51, 100);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(100, 21);
            this.txtUserID.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(69, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "הכנס ת.ז";
            // 
            // pNewTest
            // 
            this.pNewTest.Controls.Add(this.btnHistoryNew);
            this.pNewTest.Controls.Add(this.label6);
            this.pNewTest.Controls.Add(this.label1);
            this.pNewTest.Controls.Add(this.btnStartTest);
            this.pNewTest.Controls.Add(this.txtUserID);
            this.pNewTest.Location = new System.Drawing.Point(43, 12);
            this.pNewTest.Name = "pNewTest";
            this.pNewTest.Size = new System.Drawing.Size(200, 181);
            this.pNewTest.TabIndex = 16;
            // 
            // pResults
            // 
            this.pResults.Controls.Add(this.pAvg);
            this.pResults.Controls.Add(this.pTestResults);
            this.pResults.Controls.Add(this.btnHistory);
            this.pResults.Controls.Add(this.label2);
            this.pResults.Controls.Add(this.btnNewTest);
            this.pResults.Location = new System.Drawing.Point(43, 12);
            this.pResults.Name = "pResults";
            this.pResults.Size = new System.Drawing.Size(200, 162);
            this.pResults.TabIndex = 17;
            this.pResults.Visible = false;
            // 
            // pAvg
            // 
            this.pAvg.Controls.Add(this.lblTimeDiff);
            this.pAvg.Controls.Add(this.lblScoreDiff);
            this.pAvg.Controls.Add(this.lblTimeAvg);
            this.pAvg.Controls.Add(this.lblScoreAvg);
            this.pAvg.Controls.Add(this.label7);
            this.pAvg.Controls.Add(this.label5);
            this.pAvg.Location = new System.Drawing.Point(0, 35);
            this.pAvg.Name = "pAvg";
            this.pAvg.Size = new System.Drawing.Size(100, 68);
            this.pAvg.TabIndex = 21;
            // 
            // lblTimeDiff
            // 
            this.lblTimeDiff.AutoSize = true;
            this.lblTimeDiff.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblTimeDiff.Location = new System.Drawing.Point(11, 48);
            this.lblTimeDiff.Name = "lblTimeDiff";
            this.lblTimeDiff.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTimeDiff.Size = new System.Drawing.Size(25, 13);
            this.lblTimeDiff.TabIndex = 23;
            this.lblTimeDiff.Text = "XXX";
            this.lblTimeDiff.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblScoreDiff
            // 
            this.lblScoreDiff.AutoSize = true;
            this.lblScoreDiff.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblScoreDiff.Location = new System.Drawing.Point(11, 26);
            this.lblScoreDiff.Name = "lblScoreDiff";
            this.lblScoreDiff.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblScoreDiff.Size = new System.Drawing.Size(25, 13);
            this.lblScoreDiff.TabIndex = 22;
            this.lblScoreDiff.Text = "XXX";
            this.lblScoreDiff.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTimeAvg
            // 
            this.lblTimeAvg.AutoSize = true;
            this.lblTimeAvg.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblTimeAvg.Location = new System.Drawing.Point(62, 48);
            this.lblTimeAvg.Name = "lblTimeAvg";
            this.lblTimeAvg.Size = new System.Drawing.Size(25, 13);
            this.lblTimeAvg.TabIndex = 20;
            this.lblTimeAvg.Text = "XXX";
            // 
            // lblScoreAvg
            // 
            this.lblScoreAvg.AutoSize = true;
            this.lblScoreAvg.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblScoreAvg.Location = new System.Drawing.Point(62, 26);
            this.lblScoreAvg.Name = "lblScoreAvg";
            this.lblScoreAvg.Size = new System.Drawing.Size(25, 13);
            this.lblScoreAvg.TabIndex = 20;
            this.lblScoreAvg.Text = "XXX";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label7.Location = new System.Drawing.Point(7, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "פער";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label5.Location = new System.Drawing.Point(55, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "ממוצע";
            // 
            // pTestResults
            // 
            this.pTestResults.BackColor = System.Drawing.Color.Transparent;
            this.pTestResults.Controls.Add(this.label8);
            this.pTestResults.Controls.Add(this.lblTime);
            this.pTestResults.Controls.Add(this.lblScore);
            this.pTestResults.Controls.Add(this.label4);
            this.pTestResults.Controls.Add(this.label3);
            this.pTestResults.Location = new System.Drawing.Point(101, 49);
            this.pTestResults.Name = "pTestResults";
            this.pTestResults.Size = new System.Drawing.Size(92, 53);
            this.pTestResults.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label8.Location = new System.Drawing.Point(32, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "23/";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblTime.Location = new System.Drawing.Point(6, 34);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(25, 13);
            this.lblTime.TabIndex = 19;
            this.lblTime.Text = "XXX";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblScore.Location = new System.Drawing.Point(5, 12);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(25, 13);
            this.lblScore.TabIndex = 18;
            this.lblScore.Text = "XXX";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.Location = new System.Drawing.Point(62, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "זמן";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(61, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "ציון";
            // 
            // btnHistory
            // 
            this.btnHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHistory.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnHistory.Location = new System.Drawing.Point(43, 132);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(116, 23);
            this.btnHistory.TabIndex = 17;
            this.btnHistory.Text = "ראה היסטוריה";
            this.btnHistory.UseVisualStyleBackColor = true;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(69, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 19);
            this.label2.TabIndex = 12;
            this.label2.Text = "תוצאות";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnNewTest
            // 
            this.btnNewTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewTest.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnNewTest.Location = new System.Drawing.Point(43, 103);
            this.btnNewTest.Name = "btnNewTest";
            this.btnNewTest.Size = new System.Drawing.Size(116, 23);
            this.btnNewTest.TabIndex = 13;
            this.btnNewTest.Text = "התחל מבחן חדש";
            this.btnNewTest.UseVisualStyleBackColor = true;
            this.btnNewTest.Click += new System.EventHandler(this.btnNewTest_Click);
            // 
            // btnHistoryNew
            // 
            this.btnHistoryNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHistoryNew.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnHistoryNew.Location = new System.Drawing.Point(42, 154);
            this.btnHistoryNew.Name = "btnHistoryNew";
            this.btnHistoryNew.Size = new System.Drawing.Size(116, 23);
            this.btnHistoryNew.TabIndex = 18;
            this.btnHistoryNew.Text = "ראה היסטוריה";
            this.btnHistoryNew.UseVisualStyleBackColor = true;
            this.btnHistoryNew.Click += new System.EventHandler(this.btnHistoryNew_Click);
            // 
            // TestStartFinish
            // 
            this.AcceptButton = this.btnStartTest;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 212);
            this.Controls.Add(this.pResults);
            this.Controls.Add(this.pNewTest);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TestStartFinish";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MMSE";
            this.pNewTest.ResumeLayout(false);
            this.pNewTest.PerformLayout();
            this.pResults.ResumeLayout(false);
            this.pResults.PerformLayout();
            this.pAvg.ResumeLayout(false);
            this.pAvg.PerformLayout();
            this.pTestResults.ResumeLayout(false);
            this.pTestResults.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnStartTest;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pNewTest;
        private System.Windows.Forms.Panel pResults;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnNewTest;
        private System.Windows.Forms.Button btnHistory;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Panel pAvg;
        private System.Windows.Forms.Label lblTimeDiff;
        private System.Windows.Forms.Label lblScoreDiff;
        private System.Windows.Forms.Label lblTimeAvg;
        private System.Windows.Forms.Label lblScoreAvg;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pTestResults;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnHistoryNew;
    }
}