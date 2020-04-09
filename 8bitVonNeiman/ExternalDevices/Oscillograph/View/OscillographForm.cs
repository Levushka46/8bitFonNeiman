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
        }

        public Chart GetChart1 { get { return graph1Chart; } }
        public TrackBar GetTrackBar1 { get { return frequency1TrackBar; } }
        public Label GetLabel1 { get { return frequency1Label; } }
        public Chart GetChart2 { get { return graph2Chart; } }
        public TrackBar GetTrackBar2 { get { return frequency2TrackBar; } }
        public Label GetLabel2 { get { return frequency2Label; } }

        public void SetInitialSettings(Chart chart, Color color, int ScrollingPoints, TrackBar trackBar, Label label, int frequency)
        {
            //граф
            chart.Series[0].ChartType = SeriesChartType.StepLine;//тип графа
            chart.Series[0].BorderWidth = 2; //толщина
            chart.Series[0].Color = color; //цвет
            //ось У
            chart.ChartAreas[0].AxisY.ScaleView.Zoom(-1, 1.5);//границы отображение У
            chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;//отключена сетка У
            chart.ChartAreas[0].AxisY.Interval = 1; //интервал делений У
            chart.ChartAreas[0].AxisY.IntervalOffset = 1; //смещение  по У, что бы не видеть -1
            //ось Х
            chart.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dot;//сетка Х
            chart.ChartAreas[0].AxisX.Interval = 1; //интервал делений X
            //скролл
            chart.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = false;//скрол над цифрами
            chart.ChartAreas[0].AxisX.ScaleView.Size = ScrollingPoints;//размер скрола
            chart.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;//только полоса
            chart.ChartAreas[0].AxisX.ScrollBar.BackColor = Color.DarkGray; //цвета
            chart.ChartAreas[0].AxisX.ScrollBar.ButtonColor = Color.DimGray; //цвета

            //частота
            trackBar.TickFrequency = 10;
            trackBar.Minimum = 10;
            trackBar.Maximum = 100;
            trackBar.Value = 20;
            label.Text = trackBar.Value.ToString();
        }

        private void OscillographForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _output.FormClosed(); //закрытие формы методом интерфейса
        }

        private void frequency1TrackBar_Scroll(object sender, EventArgs e)//возможно нужно будет их в интерфейс и следовательнов  контроллер
        {
            //timer1.Interval = frequency1TrackBar.Value;
            frequency1Label.Text = frequency1TrackBar.Value.ToString();
        }

        private void frequency2TrackBar_Scroll(object sender, EventArgs e)
        {
            //timer2.Interval = frequency2TrackBar.Value;
            frequency2Label.Text = frequency2TrackBar.Value.ToString();
        }
    }
}
