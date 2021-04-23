namespace _8bitVonNeiman.ExternalDevices.Oscillograph.View
{
    partial class OscillographForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.graph1Chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.graph2Chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.frequency1TrackBar = new System.Windows.Forms.TrackBar();
            this.frequency2TrackBar = new System.Windows.Forms.TrackBar();
            this.button1Start = new System.Windows.Forms.Button();
            this.button2Start = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.frequency1Numeric = new System.Windows.Forms.NumericUpDown();
            this.frequency2Numeric = new System.Windows.Forms.NumericUpDown();
            this.ClearButton1 = new System.Windows.Forms.Button();
            this.ClearButton2 = new System.Windows.Forms.Button();
            this.Channel1comboBox = new System.Windows.Forms.ComboBox();
            this.Channel2comboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.graph1Chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.graph2Chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frequency1TrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frequency2TrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frequency1Numeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frequency2Numeric)).BeginInit();
            this.SuspendLayout();
            // 
            // graph1Chart
            // 
            chartArea3.Name = "ChartArea1";
            this.graph1Chart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.graph1Chart.Legends.Add(legend3);
            this.graph1Chart.Location = new System.Drawing.Point(12, 12);
            this.graph1Chart.Name = "graph1Chart";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Канал 1";
            this.graph1Chart.Series.Add(series3);
            this.graph1Chart.Size = new System.Drawing.Size(700, 100);
            this.graph1Chart.TabIndex = 0;
            this.graph1Chart.Text = "chart1";
            // 
            // graph2Chart
            // 
            chartArea4.Name = "ChartArea1";
            this.graph2Chart.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.graph2Chart.Legends.Add(legend4);
            this.graph2Chart.Location = new System.Drawing.Point(12, 193);
            this.graph2Chart.Name = "graph2Chart";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Канал 2";
            this.graph2Chart.Series.Add(series4);
            this.graph2Chart.Size = new System.Drawing.Size(700, 100);
            this.graph2Chart.TabIndex = 1;
            this.graph2Chart.Text = "chart1";
            // 
            // frequency1TrackBar
            // 
            this.frequency1TrackBar.Location = new System.Drawing.Point(12, 144);
            this.frequency1TrackBar.Name = "frequency1TrackBar";
            this.frequency1TrackBar.Size = new System.Drawing.Size(563, 45);
            this.frequency1TrackBar.TabIndex = 2;
            this.frequency1TrackBar.Scroll += new System.EventHandler(this.frequency1TrackBar_Scroll);
            // 
            // frequency2TrackBar
            // 
            this.frequency2TrackBar.Location = new System.Drawing.Point(12, 325);
            this.frequency2TrackBar.Name = "frequency2TrackBar";
            this.frequency2TrackBar.Size = new System.Drawing.Size(563, 45);
            this.frequency2TrackBar.TabIndex = 3;
            this.frequency2TrackBar.Scroll += new System.EventHandler(this.frequency2TrackBar_Scroll);
            // 
            // button1Start
            // 
            this.button1Start.Location = new System.Drawing.Point(637, 118);
            this.button1Start.Name = "button1Start";
            this.button1Start.Size = new System.Drawing.Size(75, 23);
            this.button1Start.TabIndex = 4;
            this.button1Start.Text = "Старт";
            this.button1Start.UseVisualStyleBackColor = true;
            this.button1Start.Click += new System.EventHandler(this.button1Start_Click);
            // 
            // button2Start
            // 
            this.button2Start.Location = new System.Drawing.Point(637, 299);
            this.button2Start.Name = "button2Start";
            this.button2Start.Size = new System.Drawing.Size(75, 23);
            this.button2Start.TabIndex = 5;
            this.button2Start.Text = "Старт";
            this.button2Start.UseVisualStyleBackColor = true;
            this.button2Start.Click += new System.EventHandler(this.button2Start_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // frequency1Numeric
            // 
            this.frequency1Numeric.Location = new System.Drawing.Point(16, 118);
            this.frequency1Numeric.Name = "frequency1Numeric";
            this.frequency1Numeric.Size = new System.Drawing.Size(73, 20);
            this.frequency1Numeric.TabIndex = 28;
            this.frequency1Numeric.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // frequency2Numeric
            // 
            this.frequency2Numeric.Location = new System.Drawing.Point(12, 299);
            this.frequency2Numeric.Name = "frequency2Numeric";
            this.frequency2Numeric.Size = new System.Drawing.Size(73, 20);
            this.frequency2Numeric.TabIndex = 29;
            this.frequency2Numeric.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // ClearButton1
            // 
            this.ClearButton1.Location = new System.Drawing.Point(637, 147);
            this.ClearButton1.Name = "ClearButton1";
            this.ClearButton1.Size = new System.Drawing.Size(75, 23);
            this.ClearButton1.TabIndex = 30;
            this.ClearButton1.Text = "Очистка";
            this.ClearButton1.UseVisualStyleBackColor = true;
            this.ClearButton1.Click += new System.EventHandler(this.ClearButton1_Click);
            // 
            // ClearButton2
            // 
            this.ClearButton2.Location = new System.Drawing.Point(637, 328);
            this.ClearButton2.Name = "ClearButton2";
            this.ClearButton2.Size = new System.Drawing.Size(75, 23);
            this.ClearButton2.TabIndex = 31;
            this.ClearButton2.Text = "Очистка";
            this.ClearButton2.UseVisualStyleBackColor = true;
            this.ClearButton2.Click += new System.EventHandler(this.ClearButton2_Click);
            // 
            // Channel1comboBox
            // 
            this.Channel1comboBox.FormattingEnabled = true;
            this.Channel1comboBox.Location = new System.Drawing.Point(95, 117);
            this.Channel1comboBox.Name = "Channel1comboBox";
            this.Channel1comboBox.Size = new System.Drawing.Size(150, 21);
            this.Channel1comboBox.TabIndex = 32;
            // 
            // Channel2comboBox
            // 
            this.Channel2comboBox.FormattingEnabled = true;
            this.Channel2comboBox.Location = new System.Drawing.Point(95, 298);
            this.Channel2comboBox.Name = "Channel2comboBox";
            this.Channel2comboBox.Size = new System.Drawing.Size(150, 21);
            this.Channel2comboBox.TabIndex = 33;
            // 
            // OscillographForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 376);
            this.Controls.Add(this.Channel2comboBox);
            this.Controls.Add(this.Channel1comboBox);
            this.Controls.Add(this.ClearButton2);
            this.Controls.Add(this.ClearButton1);
            this.Controls.Add(this.frequency2Numeric);
            this.Controls.Add(this.frequency1Numeric);
            this.Controls.Add(this.button2Start);
            this.Controls.Add(this.button1Start);
            this.Controls.Add(this.frequency2TrackBar);
            this.Controls.Add(this.frequency1TrackBar);
            this.Controls.Add(this.graph2Chart);
            this.Controls.Add(this.graph1Chart);
            this.Name = "OscillographForm";
            this.Text = "Осциллограф";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OscillographForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.graph1Chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.graph2Chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frequency1TrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frequency2TrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frequency1Numeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frequency2Numeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart graph1Chart;
        private System.Windows.Forms.DataVisualization.Charting.Chart graph2Chart;
        private System.Windows.Forms.TrackBar frequency2TrackBar;
        private System.Windows.Forms.Button button1Start;
        private System.Windows.Forms.Button button2Start;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.TrackBar frequency1TrackBar;
        private System.Windows.Forms.NumericUpDown frequency1Numeric;
        private System.Windows.Forms.NumericUpDown frequency2Numeric;
        private System.Windows.Forms.Button ClearButton1;
        private System.Windows.Forms.Button ClearButton2;
        private System.Windows.Forms.ComboBox Channel1comboBox;
        private System.Windows.Forms.ComboBox Channel2comboBox;
    }
}