using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
//using MathNet.Numerics;

namespace projekt_gui
{
    public partial class Form1 : Form
    {
        private ComboBox typRozkladu; // Nie jest zakomentowany, bo któraś metoda go wykorzystuje
        //private Chart chart;
        //private ChartArea chartArea;
        //private Series series;

        private ChartArea chartArea;
        private Series series;
        private Chart chart;

        private TextBox textMean;
        private TextBox textStd;
        private TextBox textX;
        private TextBox textY;
        private TextBox textp;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Ustawienie wyglądu okna
            this.Height = 750;
            this.Width = 1100;
            this.Text = "Kalkulator prawdopodobieństwa";

            // Wygenerowanie comboboxa i ustawienie jego właściwości
            //typRozkladu = new ComboBox();
            //typRozkladu.Location = new Point(150, 400);
            //typRozkladu.Size = new Size(150, 20);
            //typRozkladu.DropDownStyle = ComboBoxStyle.DropDownList;
            //typRozkladu.Items.AddRange(new object[] { "Normalny", "Chi-kwadrat" });
            //typRozkladu.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            //this.Controls.Add(typRozkladu);




            // PIERWSZY SPOSÓB
            //Chart testowanie = new Chart();
            //Series series = new Series("klucz");
            //series.ChartType = SeriesChartType.Spline;

            //for (int i = 0; i < 20; i++)
            //{
            //    series.Points.AddXY(i, i * i);
            //}
            //testowanie.Series.Add(series);

            //var area = testowanie.ChartAreas.Add(testowanie.ChartAreas.NextUniqueName());
            //series.ChartArea = area.Name;
            //this.Controls.Add(testowanie);



            // DRUGI SPOSÓB
            // Create an instance of the chart control
            //chart = new Chart();
            //chart.Location = new Point(59, 44);
            //chart.Size = new Size(400, 300);
            //chart.Dock = DockStyle.Fill;

            // Create a new chart area
            //chartArea = new ChartArea();
            //chart.ChartAreas.Add(chartArea);

            // Create a new series
            //series = new Series("MySeries");
            //series.ChartType = SeriesChartType.Line;

            // Add data points to the series
            //int numberOfPoints = 200;
            //for (int i = 0; i < numberOfPoints; i++)
            //{
            //    double x = -1 + i * (2.0 / numberOfPoints);
            //    series.Points.AddXY(x, x + 2);
            //}

            //chart.Series.Add(series);

            // Add the series to the chart area
            //chart.ChartAreas.Add("nazwa?");
            //series.ChartArea = chart.ChartAreas.Add("nazwa").Name;
            //chart.ChartAreas[1].AxisY.LineWidth = 0;
            //chart.ChartAreas["nazwa"].AxisX.MajorGrid.Enabled = false;
            //chart.ChartAreas["nazwa"].AxisX.MinorGrid.Enabled = false;
            //chart.ChartAreas["nazwa"].AxisY.MajorGrid.Enabled = false;
            //chart.ChartAreas["nazwa"].AxisY.MinorGrid.Enabled = false;


            // Add the chart control to the form or container
            //this.Controls.Add(chart);

            //myChart = new Chart();
            //myChart.Location = new Point(30, 30);
            //myChart.Size = new Size(400, 300);
            //myChart.ChartAreas.Add("chartDistributions");

            //Series mySeries = normal();
            //myChart.Enabled = false;
            //myChart.Series.Add(mySeries);
            //myChart.ChartAreas.Add("nierozumiem");

            //mySeries.ChartArea = myChart.ChartAreas.Add("noicotumabyc").Name;

            //myChart.ChartAreas[1].AxisY.LineWidth = 0;

            //myChart.ChartAreas["noicotumabyc"].AxisX.MajorGrid.Enabled = false;
            //myChart.ChartAreas["noicotumabyc"].AxisX.MinorGrid.Enabled = false;
            //myChart.ChartAreas["noicotumabyc"].AxisY.MajorGrid.Enabled = false;
            //myChart.ChartAreas["noicotumabyc"].AxisY.MinorGrid.Enabled = false;


            //this.Controls.Add(myChart);

            //start();

            chartArea = new ChartArea();
            series = new Series();
            chart = new Chart();

            chartArea.Name = "chartPrzestrzen";
            chart.ChartAreas.Add(chartArea);
            chart.Location = new Point(59, 44);
            chart.Name = "wykres";
            series.Name = "wykres1";
            series.BorderWidth = 2;
            series.ChartArea = "chartPrzestrzen";
            series.ChartType = SeriesChartType.Line;
            series.Color = System.Drawing.Color.Violet;
            series.IsVisibleInLegend = false;
            chart.Series.Add(series);
            chart.Size = new Size(300, 300);
            chart.TabIndex = 7;
            chart.Text = "chart";

            Label labelMean = addLabel("mean: ", 500, 100);
            Label labelStd = addLabel("std: ", 500, 200);
            Label prob1 = addLabel("P{", 63, 407, 48, 31);
            Label prob2 = addLabel("≤ x ≤", 163, 410, 80, 31);
            Label prob3 = addLabel("} =", 295, 410, 53, 31);
            prob1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            prob2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            prob3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            this.Controls.Add(labelMean);
            this.Controls.Add(labelStd);
            this.Controls.Add(prob1);
            this.Controls.Add(prob2);
            this.Controls.Add(prob3);

            textMean = addTextBox("mean", 540, 95);
            textStd = addTextBox("std", 540, 195);
            // Dodaj domyślne wartości
            textMean.Text = "0";
            textStd.Text = "1";

            textX = addTextBox("lowerBoundX", 107, 407);
            textY = addTextBox("upperBoundY", 239, 407);
            textp = addTextBox("p", 341, 407);

            textX.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textY.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textp.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textX.Size = new System.Drawing.Size(50, 38);
            textY.Size = new System.Drawing.Size(50, 38);
            textp.Size = new System.Drawing.Size(70, 38);
            textp.ReadOnly = true;

            // Domyślne wartości
            textX.Text = "1.6";
            textY.Text = "9";
            textp.Text = "0.05";

            this.Controls.Add(textMean);
            this.Controls.Add(textStd);
            this.Controls.Add(textX);
            this.Controls.Add(textY);
            this.Controls.Add(textp);

            Button buttonOK = addButton("ok_button", "OK", 540, 300);
            buttonOK.Click += new EventHandler(btn_click);

            this.Controls.Add(buttonOK);

            int numberOfPoints = 200;
            for (int i = 0; i < numberOfPoints; i++)
            {
                double x = -1 + i * (10.5 / numberOfPoints);
                series.Points.AddXY(x, Math.Exp(- x * x / (2 * 1 * 1)) / (Math.Sqrt(2 * Math.PI)));
            }

            //chart.ChartAreas[0].AxisX.Maximum = 1;
            //chart.ChartAreas[0].AxisX.Minimum = -1;
            //chart.ChartAreas[0].AxisY.Maximum = 1;
            chart.ChartAreas[0].AxisY.Minimum = -0.01;

            chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

            this.Controls.Add(chart);
        }

        Label addLabel(string text, int x, int y, int width=35, int height=13)
        {
            Label label = new Label();
            label.AutoSize = true;
            label.Height = 50;
            label.Width = 20;
            label.Text = text;
            label.Location = new Point(x, y);
            label.Size = new Size(40, 13);

            return label;
        }

        TextBox addTextBox(string name, int x, int y)
        {
            TextBox textBox = new TextBox();
            textBox.Location = new Point(x, y);
            textBox.Name = name;
            textBox.Width = 100;
            textBox.Height = 50;

            return textBox;
        }

        Button addButton(string name, string text, int x, int y)
        {
            Button button = new Button();
            button.Location = new Point(x, y);
            button.Name = name;
            button.Text = text;

            return button;
        }

        private void btn_click(object sender, EventArgs e)
        {
            //MessageBox.Show("OK!");
            double m = Double.Parse(textMean.Text);
            double std = Double.Parse(textStd.Text);
            //MessageBox.Show($"a {a}, b {b}");

            // Wykres
            //chart.Series.Remove(series);
            //this.Controls.Remove(chart);
            chart.Series["wykres1"].Points.Clear();
            double a = double.Parse(textX.Text);
            double b = double.Parse(textY.Text);
            int numberOfPoints = 200;
            for (int i = 0; i < numberOfPoints; i++)
            {
                double x = a - .01 + i * ((b - a + 0.5) / numberOfPoints);
                series.Points.AddXY(x, Math.Exp(-(x - m) * (x - m) / (2 * std * std)) / (Math.Sqrt(2 * Math.PI * std * std)));
            }

            double pole = metodaTrapezow(double.Parse(textX.Text), double.Parse(textY.Text), m, std);
            textp.Text = $"{pole:f2}";
            chart.ChartAreas[0].AxisX.Maximum = b + .01;
            chart.ChartAreas[0].AxisX.Minimum = a - .01;
            //this.Controls.Add(chart);
        }

        private double metodaTrapezow(double a, double b, double m, double std)
        {
            int n = 1000;
            double sum = 0;
            double length = (b - a) / Convert.ToDouble(n);
            for (int i = 1; i < n; i++)
            {
                double x = a + i * length;
                sum += 2 * (Math.Exp(-Math.Pow((x - m), 2)/ (2 * std * std)) / (std * Math.Sqrt(2 * Math.PI)));
            }
            sum += Math.Exp(-Math.Pow((a - m), 2) / (2 * std * std)) / (std * Math.Sqrt(2 * Math.PI)) + Math.Exp(-Math.Pow((b - m), 2) / (2 * std * std)) / (std * Math.Sqrt(2 * Math.PI));
            sum *= length / 2;
            return sum;
        }

        Series normal(double mean = 0, double std = 1)
        {
            Series series = new Series();
            series.ChartType = SeriesChartType.Line;

            // Add data points to the series
            int numberOfPoints = 200;
            for (int i = 0; i < numberOfPoints; i++)
            {
                double x = -1 + i * (2.0 / numberOfPoints);
                series.Points.AddXY(x, Math.Exp(-(x - mean) * (x - mean) / (2 * std * std)) / (Math.Sqrt(2 * Math.PI * std * std)));
            }

            return series;
        }

        // Metoda, która wczytuje cały interfejs oprócz charta
        private void loadWindow(string distributionType)
        {

        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedOption = typRozkladu.SelectedItem.ToString();

            //Console.WriteLine("Selected option: " + selectedOption);
            //MessageBox.Show(selectedOption);

            switch (selectedOption)
            {
                case "Normalny":
                    rozkladNormalny();
                    break;
                case "Chi-kwadrat":
                    rozkladChiKwadrat();
                    break;
                default:
                    rozkladNormalny();
                    break;
            }
                    
        }

        // Rozkład normalny
        private void rozkladNormalny(double mean = 0, double standardDeviation = 1)
        {
            //chart.Series.Remove(series);
            //this.Controls.Remove(chart);
            chart.Series["series"].Points.Clear();

            double m = mean;
            double std = standardDeviation;

            //series = new Series();
            //series.ChartType = SeriesChartType.Line;

            // Add data points to the series
            int numberOfPoints = 200;
            for (int i = 0; i < numberOfPoints; i++)
            {
                double x = -1 + i * (2.0 / numberOfPoints);
                series.Points.AddXY(x, Math.Exp(-(x - m) * (x - m) / (2 * std * std)) / (Math.Sqrt(2 * Math.PI * std * std)));
            }

            chart.Series.Add(series);
            //myChart.ChartAreas.Add("chartNormal");

            //series.ChartArea = chart.ChartAreas.Add("noicotumabyc").Name;

            chart.ChartAreas[1].AxisY.LineWidth = 0;

            chart.ChartAreas["nazwa"].AxisX.MajorGrid.Enabled = false;
            chart.ChartAreas["nazwa"].AxisX.MinorGrid.Enabled = false;
            chart.ChartAreas["nazwa"].AxisY.MajorGrid.Enabled = false;
            chart.ChartAreas["nazwa"].AxisY.MinorGrid.Enabled = false;


            this.Controls.Add(chart);
            
        }

        // Rozkład chi-kwadrat
        private void rozkladChiKwadrat(double degreesOfFreedom=5)
        {
            chart.Series.Remove(series);
            this.Controls.Remove(chart);

            double df = degreesOfFreedom;
            series = new Series();
            series.ChartType = SeriesChartType.Line;

            // Dodaj punkty do series
            int numberOfPoints = 200;
            for (int i = 0; i < numberOfPoints; i++)
            {
                double x = -1 + i * (2.0 / numberOfPoints);
                if (x < 0)
                {
                    series.Points.AddXY(x, 0);
                }
                else
                {
                    series.Points.AddXY(x, (Math.Pow(x,df / 2 - 1) * Math.Exp(- x / 2)) / (Math.Pow(2, df / 2) * 1));
                }
            }

            chart.Series.Add(series);
            //myChart.ChartAreas.Add("chartChiSquared");

            //series.ChartArea = chart.ChartAreas.Add("innanazwa").Name;

            chart.ChartAreas[1].AxisY.LineWidth = 0;

            chart.ChartAreas["nazwa"].AxisX.MajorGrid.Enabled = false;
            chart.ChartAreas["nazwa"].AxisX.MinorGrid.Enabled = false;
            chart.ChartAreas["nazwa"].AxisY.MajorGrid.Enabled = false;
            chart.ChartAreas["nazwa"].AxisY.MinorGrid.Enabled = false;


            this.Controls.Add(chart);
        }
    }
}
