using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static GraphicMaker.Math32.Math32;

namespace GraphicMaker
{
    public partial class Form1 : Form
    {
        private static List<double> dataX = new List<double>();
        private static List<double> dataY = new List<double>();
        private static int numberOfPoints;

        public Form1()
        {
            InitializeComponent();
        }

        private double GetEpsilon()
        {
            double epsilon;
            if (Double.TryParse(textBox1.Text, out epsilon) == false)
            {
                return -1; // все значения подходят
            }
            return epsilon;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            chart1.Series[0].ToolTip = "X = #VALX, Y = #VALY";
            chart1.Series[1].ToolTip = "X = #VALX, Y = #VALY";

            chart1.ChartAreas[0].AxisX.ScaleView.Zoom(0,10);
            chart1.ChartAreas[0].CursorX.IsUserEnabled = true;
            chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart1.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;

            chart1.ChartAreas[0].AxisY.ScaleView.Zoom(0, 10);
            chart1.ChartAreas[0].CursorY.IsUserEnabled = true;
            chart1.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            chart1.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            chart1.ChartAreas[0].AxisY.ScrollBar.IsPositionedInside = true;
        }

        private void AddFromFile()
        {
            StreamReader stringReader = new StreamReader(openFileDialog1.FileName);
            int i = 0;
            string line = "";
            string tmp = "";
            while ((line = stringReader.ReadLine()) != null)
            {
                foreach (char space in line)
                {
                    if (space == ' ')
                    {
                        dataX.Add(Double.Parse(tmp));
                        tmp = "";
                        i++;
                        numberOfPoints++;
                        continue;
                    }
                    tmp += line[i];
                    i++;
                }
                dataY.Add(Double.Parse(tmp));
                tmp = "";
                i = 0;
            }
        }

        private double GetMin(double[] point)
        {
            double min = point[0];
            for (int i = 1; i < numberOfPoints; i++)
            {
                if (point[i] < min)
                {
                    min = point[i];
                }
            }
            return min;
        }
        private double GetMax(double[] point)
        {
            double max = point[0];
            for (int i = 1; i < numberOfPoints; i++)
            {
                if (point[i] > max)
                {
                    max = point[i];
                }
                
            }
            return max;
        }
        private void AddToDataGridView(double[] pointX, double[] pointY)
        {
            dataGridView1.ColumnCount = 2;
            dataGridView1.RowCount = 1;
            string[] rowXY = { "X", "Y" };
            dataGridView1.Rows.Add(rowXY);
            for (int i = 0; i < numberOfPoints; i++)
            {
                string[] row = { pointX[i].ToString(), pointY[i].ToString() };
                dataGridView1.Rows.Add(row);
            }
        }

        private void ChartClean()
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
        }
        private void AddToChart()
        {
            unsafe
            {
                double[] tempPointX = new double[numberOfPoints];
                double[] tempPointY = new double[numberOfPoints];
                fixed (double* pointX = &tempPointX[0])
                {
                    fixed (double* pointY = &tempPointY[0])
                    {
                        int i = 0;
                        foreach (double X in dataX)
                        {
                            pointX[i] = X;
                            i++;
                        }
                        i = 0;
                        foreach (double Y in dataY)
                        {
                            pointY[i] = Y;
                            i++;
                        }
                        AddToDataGridView(tempPointX, tempPointY);
                        ChartClean();
                        if (find_factor(pointX, pointY, numberOfPoints, GetEpsilon()))
                        {
                            double min = GetMin(tempPointX);
                            double max = GetMax(tempPointX);

                            chart1.Series[0].Points.AddXY(min, f(min));
                            chart1.Series[0].Points.AddXY(max, f(max));
                        }
                        for (i = 0; i < numberOfPoints; i++)
                        {
                            chart1.Series[1].Points.AddXY(tempPointX[i], tempPointY[i]);
                        }
                        label3.Text = "y = " + String.Format("{0:##0.00000}", get_tlit_angle()) + " * x + ( " + String.Format("{0:##0.00000}", get_factor_b()) + " )";
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                AddFromFile();
                AddToChart();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double x, y;
            if (Double.TryParse(textBox2.Text, out x) != false && Double.TryParse(textBox3.Text, out y) != false)
            {
                dataX.Add(x);
                dataY.Add(y);
                numberOfPoints++;
                AddToChart();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0 && dataX.Count != 0)
            {
                int selRowNum = dataGridView1.SelectedCells[0].RowIndex;
                if (selRowNum > 0)
                {
                    dataX.RemoveAt(selRowNum - 1);
                    dataY.RemoveAt(selRowNum - 1);
                    dataGridView1.Rows.RemoveAt(selRowNum);
                    numberOfPoints--;
                    AddToChart();
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            double opticalDensity;
            if (Double.TryParse(textBox4.Text, out opticalDensity))
            {
                label5.Text = String.Format("{0:##0.00}", (opticalDensity - get_factor_b()) / get_tlit_angle());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddToChart();
        }
    }
}
