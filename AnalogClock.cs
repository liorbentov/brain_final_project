using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class AnalogClock : UserControl
    {
        const float PI = 3.141592654F;

        DateTime dateTime;

        float fRadius, fCenterX, fCenterY, fCenterCircleRadius, fHourLength;
        float fMinLength, fSecLength, fHourThickness, fMinThickness, fSecThickness;
        bool bDraw5MinuteTicks = true;
        bool bDraw1MinuteTicks = true;
        float fTicksThickness = 2;

        Color secColor = Color.Black;
        Color circleColor = Color.Black;
        Color ticksColor = Color.Red;

        public AnalogClock()
        {
            InitializeComponent();
            
        }


        private void AnalogClock_Load(object sender, EventArgs e)
        {
            dateTime = DateTime.Now;
            this.AnalogClock_Resize(sender, e);
        }

        private void DrawLine(float fThickness, float fLength, Color color, float fRadians,
                              System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(color, fThickness),
                fCenterX - (float)(fLength / 9 * System.Math.Sin(fRadians)),
                fCenterY + (float)(fLength / 9 * System.Math.Cos(fRadians)),
                fCenterX + (float)(fLength * System.Math.Sin(fRadians)),
                fCenterY - (float)(fLength * System.Math.Cos(fRadians)));
        }

        private void DrawPolygon(float fThickness, float fLength, Color color, float fRadians,
            PaintEventArgs e)
        {

            PointF A = new PointF((float)(fCenterX + fThickness * 2 * Math.Sin(fRadians + PI / 2)),
                (float)(fCenterY - fThickness * 2 * Math.Cos(fRadians + PI / 2)));
            PointF B = new PointF((float)(fCenterX + fThickness * 2 * Math.Sin(fRadians - PI / 2)),
                (float)(fCenterY - fThickness * 2 * Math.Cos(fRadians - PI / 2)));
            PointF C = new PointF((float)(fCenterX + fLength * Math.Sin(fRadians)),
                (float)(fCenterY - fLength * Math.Cos(fRadians)));
            PointF D = new PointF((float)(fCenterX - fThickness * 4 * Math.Sin(fRadians)),
                (float)(fCenterY + fThickness * 4 * Math.Cos(fRadians)));
            PointF[] points = { A, D, B, C };
            e.Graphics.FillPolygon(new SolidBrush(color), points);
        }

        private void AnalogClock_Paint(object sender, PaintEventArgs e)
        {
            float fRadHr = (dateTime.Hour % 12 + dateTime.Minute / 60F) * 30 * PI / 180;
            float fRadMin = (dateTime.Minute) * 6 * PI / 180;
            float fRadSec = (dateTime.Second) * 6 * PI / 180;

            DrawPolygon(this.fHourThickness,
                  this.fHourLength, this.HourHandColor, fRadHr, e);
            DrawPolygon(this.fMinThickness,
                  this.fMinLength, this.MinuteHandColor, fRadMin, e);
            DrawLine(this.fSecThickness,
                  this.fSecLength, this.SecondHandColor, fRadSec, e);


            for (int i = 0; i < 60; i++)
            {
                if (this.bDraw5MinuteTicks == true && i % 5 == 0)
                // Draw 5 minute ticks
                {
                    e.Graphics.DrawLine(new Pen(ticksColor, fTicksThickness),
                      fCenterX +
                      (float)(this.fRadius / 1.50F * Math.Sin(i * 6 * PI / 180)),
                      fCenterY -
                      (float)(this.fRadius / 1.50F * Math.Cos(i * 6 * PI / 180)),
                      fCenterX +
                      (float)(this.fRadius / 1.65F * Math.Sin(i * 6 * PI / 180)),
                      fCenterY -
                      (float)(this.fRadius / 1.65F * Math.Cos(i * 6 * PI / 180)));
                }
                else if (this.bDraw1MinuteTicks == true) // draw 1 minute ticks
                {
                    e.Graphics.DrawLine(new Pen(ticksColor, fTicksThickness),
                      fCenterX +
                      (float)(this.fRadius / 1.50F * Math.Sin(i * 6 * PI / 180)),
                      fCenterY -
                      (float)(this.fRadius / 1.50F * Math.Cos(i * 6 * PI / 180)),
                      fCenterX +
                      (float)(this.fRadius / 1.55F * Math.Sin(i * 6 * PI / 180)),
                      fCenterY -
                      (float)(this.fRadius / 1.55F * Math.Cos(i * 6 * PI / 180)));
                }
            }

            //draw circle at center
            e.Graphics.FillEllipse(new SolidBrush(circleColor),
                       fCenterX - fCenterCircleRadius / 2,
                       fCenterY - fCenterCircleRadius / 2,
                       fCenterCircleRadius, fCenterCircleRadius);
        }



        private void AnalogClock_Resize(object sender, EventArgs e)
        {
            this.Width = this.Height;
            this.fRadius = this.Height / 2;
            this.fCenterX = this.ClientSize.Width / 2;
            this.fCenterY = this.ClientSize.Height / 2;
            this.fHourLength = (float)this.Height / 3 / 1.85F;
            this.fMinLength = (float)this.Height / 3 / 1.20F;
            this.fSecLength = (float)this.Height / 3 / 1.15F;
            this.fHourThickness = (float)this.Height / 100;
            this.fMinThickness = (float)this.Height / 150;
            this.fSecThickness = (float)this.Height / 200;
            this.fCenterCircleRadius = this.Height / 50;
            timer1.Start();

        }
        public Color HourHandColor
        {
            get { return Color.Blue; }
        }

        public Color MinuteHandColor
        {
            get { return Color.Green; }
        }

        public Color SecondHandColor
        {
            get { return Color.Red; }
            set
            {
                this.secColor = value;
                this.circleColor = value;
            }
        }

        public Color TicksColor
        {
            get { return this.ticksColor; }
            set { this.ticksColor = value; }
        }

        public bool Draw1MinuteTicks
        {
            get { return this.bDraw1MinuteTicks; }
            set { this.bDraw1MinuteTicks = value; }
        }

        public bool Draw5MinuteTicks
        {
            get { return this.bDraw5MinuteTicks; }
            set { this.bDraw5MinuteTicks = value; }
        }

        public void setTime(DateTime dtToSet)
        {
            this.dateTime = dtToSet;
            this.Refresh();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //this.dateTime = DateTime.Now;
            this.dateTime = this.dateTime.AddSeconds(1);
            this.Refresh();
        }

        public void Start()
        {
            timer1.Enabled = true;
            this.Refresh();
        }

        public void Stop()
        {
            timer1.Enabled = false;
        }


    }
}
