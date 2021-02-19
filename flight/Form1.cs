using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Simulation;
namespace flight
{
    public partial class Form1 : Form
    {
        private bool isClickPause = false;
        private Engine _simulationObject = null;
        private double _x = 0;
        private double _y = 0;
        private double _x0 = 0;
        private double _y0 = 0;
        private double _g = 10;
        private double _gY = -10;
        private double _gX = 0;
        private double _time = 0;
        private double _v0 = 0;
        private double _angle = 0;
        private double _dt = 0.05;

        public Form1()
        {
            InitializeComponent();
            label4.Text = $"Time: {_time}";
            chart1.Series[0].Points.Clear();
            numericUpDown1.Value = 0;
            numericUpDown3.Value = 0;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            double y0 = (double)HeightNumericUpDown.Value;
            double v0 = (double)SpeedNumericUpDown.Value;
            double angle = (double)AngleNumericUpDown.Value % 90;
            double _g = (double)gNumericUpDown1.Value;
            _dt = (double)numericUpDown5.Value / 50;
            StartGame(y0,v0, angle, _g);
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            if (isClickPause == true)
            {
                PauseButton.Text = "Pause";
                isClickPause = false;
                timer1.Start();
            }
            else
            {
                PauseButton.Text = "Continue";
                isClickPause = true;
                timer1.Stop();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = $"Time: {_time += _dt}";
            Point currentPoint = _simulationObject.GetNextPoint();
            chart1.Series[0].Points.AddXY(currentPoint.X, currentPoint.Y);
            if (currentPoint.Y< 0)
            {
                StopGame();
            }
        }

        private void StartGame(double y0, double v0, double angle, double g)
        {
            if (timer1.Enabled)
                return;
            _gY = -_g;
            chart1.Series[0].Points.Clear();
            _simulationObject = new Engine(new Point(_x0, y0), v0, _dt, _gX, _gY, angle);
            _x = _x0;
            _y = y0;
            double maxH = _y + Calculations.GetMaxHeight(v0, angle, g) + 1;
            double maxLength = _x + Calculations.GetMaxLengthOfFlight(v0, angle, g,_y0) + 1;
            chart1.ChartAreas[0].AxisX.Maximum = maxLength;
            chart1.ChartAreas[0].AxisY.Maximum = maxH;
            numericUpDown2.Value = (int)maxLength;
            numericUpDown4.Value = (int)maxH;
            chart1.Series[0].Points.AddXY(_x, _y);
            timer1.Start();
        }

        private void StopGame()
        {
            if (!timer1.Enabled)
                return;
            _time = 0;
            timer1.Stop();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.Minimum = (double)numericUpDown1.Value; 
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.Maximum = (double)numericUpDown2.Value;
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisY.Minimum = (double)numericUpDown3.Value;
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisY.Maximum = (double)numericUpDown4.Value;
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            _dt = (double)numericUpDown5.Value / 50;
        }
    }
}
