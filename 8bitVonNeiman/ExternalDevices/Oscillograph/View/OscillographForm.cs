using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _8bitVonNeiman.Common;
using System.Windows.Forms.DataVisualization.Charting;
//using _8bitVonNeiman.ExternalDevices.Timer5;

namespace _8bitVonNeiman.ExternalDevices.Oscillograph.View
{
	public partial class OscillographForm : Form
	{
		// ТУТ ТОЛЬКО ТО ЧТО ОТНОСИТСЯ К ГРАФИЧЕСКОМУ ИНТЕРФЕЙСУ!!!!!
		private readonly IOscillographFormOutput _output;
		public OscillographForm(IOscillographFormOutput output)
		{
			_output = output;
			InitializeComponent();
			SetInitialSettings(graph1Chart, Color.Blue, frequency1TrackBar, frequency1Label, 1000);
			SetInitialSettings(graph2Chart, Color.Green, frequency2TrackBar, frequency2Label, 1000);
		}

		private const int ScrollingPoints = 20;//количество точек до скрола
		//public int Pin;
		//private bool Pin = false;
		/*
		public Chart GetChart1 { get { return graph1Chart; } }
		public TrackBar GetTrackBar1 { get { return frequency1TrackBar; } }
		public Label GetLabel1 { get { return frequency1Label; } }
		public Chart GetChart2 { get { return graph2Chart; } }
		public TrackBar GetTrackBar2 { get { return frequency2TrackBar; } }
		public Label GetLabel2 { get { return frequency2Label; } }
		*/
		public void SetInitialSettings(Chart chart, Color color, TrackBar trackBar, Label label, int frequency)
		{
			//граф
			chart.Series[0].ChartType = SeriesChartType.StepLine;   //тип графа
			chart.Series[0].BorderWidth = 2;                        //толщина
			chart.Series[0].Color = color;                          //цвет
			//ось У
			chart.ChartAreas[0].AxisY.ScaleView.Zoom(-1, 1.5);      //границы отображение У
			chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;    //отключена сетка У
			chart.ChartAreas[0].AxisY.Interval = 1;					//интервал делений У
			chart.ChartAreas[0].AxisY.IntervalOffset = 1;			//смещение  по У, что бы не видеть -1
			//ось Х
			chart.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dot;	//сетка Х
			chart.ChartAreas[0].AxisX.Interval = 1;									//интервал делений X
			//скролл
			chart.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = false;			//скрол над цифрами
			chart.ChartAreas[0].AxisX.ScaleView.Size = ScrollingPoints;				//размер скрола
			chart.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;	//только полоса
			chart.ChartAreas[0].AxisX.ScrollBar.BackColor = Color.DarkGray;			//цвета
			chart.ChartAreas[0].AxisX.ScrollBar.ButtonColor = Color.DimGray;		//цвета

			//частота
			trackBar.TickFrequency = 100;			//деления
			trackBar.Minimum = 100;					//минимум
			trackBar.Maximum = 1000;				//максимум
			trackBar.Value = frequency;				//начальная частота
			label.Text = trackBar.Value.ToString();
		}
		

		private void OscillographForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			_output.FormClosed(); //закрытие формы методом интерфейса

		}

		private void frequency1TrackBar_Scroll(object sender, EventArgs e)//возможно нужно будет их в интерфейс и следовательно в  контроллер
		{
			timer1.Interval = frequency1TrackBar.Value;
			frequency1Label.Text = frequency1TrackBar.Value.ToString();
		}

		private void frequency2TrackBar_Scroll(object sender, EventArgs e)
		{
			timer2.Interval = frequency2TrackBar.Value;
			frequency2Label.Text = frequency2TrackBar.Value.ToString();
		}

		public List<int> values = new List<int>();
		public List<int> values2 = new List<int>();
		//Random rnd = new Random(DateTime.Now.Millisecond);

		private void button1Start_Click(object sender, EventArgs e)
		{
			//_output.Button1StartClicked();
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

		int Y = 0;
		private void timer1_Tick(object sender, EventArgs e)
		{
			//values.Add(rnd.Next(0, 2));
			//textBox1.Text = test.Out.ToString();
			values.Add((OutPin.outputPinValueTimer5)?1:0);
			//graph1Chart.Series[0].Points.AddXY(values.Count, values.Last()); //хранить значение в графе!!!!!
			graph1Chart.Series[0].Points.AddXY(Y++, (OutPin.outputPinValueTimer5) ? 1 : 0);
			//graph2Chart.Series[0].Points.AddXY(values.Count, values.Last());
			if (/*values.Count*/Y > graph1Chart.ChartAreas[0].AxisX.ScaleView.Size)//начать скролл при выходе за границу
			{
				graph1Chart.ChartAreas[0].AxisX.ScaleView.Scroll(/*values.Count*/Y);//скролл
				//graph2Chart.ChartAreas[0].AxisX.ScaleView.Scroll(values.Count);//скролл
			}

		}

		private void timer2_Tick(object sender, EventArgs e)
		{
			values2.Add((OutPin.outputPinValueTimer5) ? 1 : 0);
			graph2Chart.Series[0].Points.AddXY(values.Count, values.Last());
			if (values2.Count > graph2Chart.ChartAreas[0].AxisX.ScaleView.Size)//начать скролл при выходе за границу
			{
				graph2Chart.ChartAreas[0].AxisX.ScaleView.Scroll(values.Count);//скролл
			}
		}	
	}
}
