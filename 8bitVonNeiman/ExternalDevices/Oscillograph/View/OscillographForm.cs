using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
            GetListConnectedDevices();
		}

		private const int ScrollingPoints = 20;//количество точек до скрола
        private List<int> _сhannel1 = new List<int>(); //значения первого канала
        private List<int> _channel2 = new List<int>(); //значения второго канала
		private Dictionary<string, IDeviceInput> _listConnectDevices = new Dictionary<string, IDeviceInput>();

        //первоначальные настройки компонентов
		private void SetInitialSettings(Chart chart, Color color, TrackBar trackBar, NumericUpDown numeric, int frequency)
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
			numeric.Minimum = trackBar.Minimum;
			numeric.Maximum = trackBar.Maximum;
			numeric.Value = frequency;
        }

        private void GetListConnectedDevices()
        {
            try
            {
                foreach (var d in _output.ConnectedDevices)
                {
                    _listConnectDevices.Add("Таймер 5 - 0x" + Convert.ToString(d.BaseAddress, 16), d);
                }
                foreach (var d in _listConnectDevices)
                {
                    Channel1comboBox.Items.Add(d.Key);
                    Channel2comboBox.Items.Add(d.Key);
				}
            }
            catch { MessageBox.Show("Обнаружены устройства с одинаковыми адресами!\nОпределение списка устройств невозможно!"); }
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
			_сhannel1.Clear();
			graph1Chart.Series[0].Points.Clear();
		}
		private void ClearButton2_Click(object sender, EventArgs e)
		{
			_channel2.Clear();
			graph2Chart.Series[0].Points.Clear();
		}

		//вывод значений
		private void timer1_Tick(object sender, EventArgs e)
		{
            try
            {
                _сhannel1.Add(_listConnectDevices[Channel1comboBox.Text].OutputPinValue ? 1 : 0);
                //начать скролл при выходе за границу
                graph1Chart.Series[0].Points.AddXY(_сhannel1.Count, _сhannel1.Last());
                if (_сhannel1.Count > graph1Chart.ChartAreas[0].AxisX.ScaleView.Size)
                {
                    graph1Chart.ChartAreas[0].AxisX.ScaleView.Scroll(_сhannel1.Count); //скролл
                }
            }
			catch
            {
                button1Start_Click(sender, e);
                MessageBox.Show("Не обнаружен источник данных Канала 1!");
            }
		}
		private void timer2_Tick(object sender, EventArgs e)
		{
            try
            {
				_channel2.Add(_listConnectDevices[Channel2comboBox.Text].OutputPinValue ? 1 : 0);
			    //начать скролл при выходе за границу
			    graph2Chart.Series[0].Points.AddXY(_channel2.Count, _channel2.Last());
			    if (_channel2.Count > graph2Chart.ChartAreas[0].AxisX.ScaleView.Size)
			    {
				    graph2Chart.ChartAreas[0].AxisX.ScaleView.Scroll(_channel2.Count);//скролл
			    }
            }
            catch
            {
                button2Start_Click(sender, e);
                MessageBox.Show("Не обнаружен источник данных Канала 2!");
            }
		}
    }
}
