using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace _8bitVonNeiman.ExternalDevices.Oscillograph.View
{
	public partial class OscillographForm : Form
	{
		private readonly IOscillographFormOutput _output;
		public OscillographForm(IOscillographFormOutput output)
		{
			_output = output;
			InitializeComponent();
			SetInitialSettings(graph1Chart, Color.Blue, frequency1TrackBar, frequency1Numeric, 1000);
			SetInitialSettings(graph2Chart, Color.Green, frequency2TrackBar, frequency2Numeric, 1000);
		}

		private const int ScrollingPoints = 20;//количество точек до скрола
		public List<int> Сhannel1 = new List<int>(); //значения первого канала
		public List<int> Channel2 = new List<int>(); //значения второго канала

		//первоначальные настройки компонентов
		public void SetInitialSettings(Chart chart, Color color, TrackBar trackBar, NumericUpDown Numeric, int frequency)
		{
			//граф
			chart.Series[0].ChartType = SeriesChartType.StepLine;   //тип графа
			chart.Series[0].BorderWidth = 2;                        //толщина
			chart.Series[0].Color = color;                          //цвет
																	//ось У
			chart.ChartAreas[0].AxisY.ScaleView.Zoom(-1, 1.5);      //границы отображение У
			chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;    //отключена сетка У
			chart.ChartAreas[0].AxisY.Interval = 1;                 //интервал делений У
			chart.ChartAreas[0].AxisY.IntervalOffset = 1;           //смещение  по У, что бы не видеть -1
																	//ось Х
			chart.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dot; //сетка Х
			chart.ChartAreas[0].AxisX.Interval = 1;                                 //интервал делений X
																					//скролл
			chart.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = false;         //скрол над цифрами
			chart.ChartAreas[0].AxisX.ScaleView.Size = ScrollingPoints;             //размер скрола
			chart.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;    //только полоса
			chart.ChartAreas[0].AxisX.ScrollBar.BackColor = Color.DarkGray;         //цвета
			chart.ChartAreas[0].AxisX.ScrollBar.ButtonColor = Color.DimGray;        //цвета

			//частота
			trackBar.TickFrequency = 50;            //деления
			trackBar.Minimum = 100;                 //минимум
			trackBar.Maximum = 1000;                //максимум
			trackBar.Value = frequency;             //начальная частота
			Numeric.Minimum = trackBar.Minimum;
			Numeric.Maximum = trackBar.Maximum;
			Numeric.Value = frequency;
		}

		private void OscillographForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			_output.FormClosed(); //закрытие формы методом интерфейса
		}
		//настройка частоты
		private void frequency1TrackBar_Scroll(object sender, EventArgs e)
		{
			timer1.Interval = frequency1TrackBar.Value;
			frequency1Numeric.Value = frequency1TrackBar.Value;
		}
		private void frequency2TrackBar_Scroll(object sender, EventArgs e)
		{
			timer2.Interval = frequency2TrackBar.Value;
			frequency2Numeric.Value = frequency2TrackBar.Value;
		}
		private void numericUpDown1_ValueChanged(object sender, EventArgs e)
		{
			frequency1TrackBar.Value = (int)frequency1Numeric.Value;
			timer1.Interval = frequency1TrackBar.Value;
		}
		private void numericUpDown2_ValueChanged(object sender, EventArgs e)
		{
			frequency2TrackBar.Value = (int)frequency2Numeric.Value;
			timer2.Interval = frequency2TrackBar.Value;
		}
		//включение каналов
		private void button1Start_Click(object sender, EventArgs e)
		{
			if (timer1.Enabled)
			{
				timer1.Stop();
				button1Start.Text = "Старт";
			}
			else
			{
				timer1.Start();
				button1Start.Text = "Стоп";
			}
		}
		private void button2Start_Click(object sender, EventArgs e)
		{
			if (timer2.Enabled)
			{
				timer2.Stop();
				button2Start.Text = "Старт";
			}
			else
			{
				timer2.Start();
				button2Start.Text = "Стоп";
			}
		}
		//очистка каналов
		private void ClearButton1_Click(object sender, EventArgs e)
		{
			Сhannel1.Clear();
			graph1Chart.Series[0].Points.Clear();
		}
		private void ClearButton2_Click(object sender, EventArgs e)
		{
			Channel2.Clear();
			graph2Chart.Series[0].Points.Clear();
		}

		//вывод значений
		private void timer1_Tick(object sender, EventArgs e)
		{
			Сhannel1.Add((OutPin.outputPinValueTimer5) ? 1 : 0);
			//начать скролл при выходе за границу
			graph1Chart.Series[0].Points.AddXY(Сhannel1.Count, Сhannel1.Last());
			if (Сhannel1.Count > graph1Chart.ChartAreas[0].AxisX.ScaleView.Size)
			{
				graph1Chart.ChartAreas[0].AxisX.ScaleView.Scroll(Сhannel1.Count);//скролл
			}

		}
		private void timer2_Tick(object sender, EventArgs e)
		{
			Channel2.Add((OutPin.outputPinValueTimer5) ? 1 : 0);
			//начать скролл при выходе за границу
			graph2Chart.Series[0].Points.AddXY(Channel2.Count, Channel2.Last());
			if (Channel2.Count > graph2Chart.ChartAreas[0].AxisX.ScaleView.Size)
			{
				graph2Chart.ChartAreas[0].AxisX.ScaleView.Scroll(Channel2.Count);//скролл
			}
		}
	}
}
