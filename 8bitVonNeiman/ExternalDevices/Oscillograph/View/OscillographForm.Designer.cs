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
            this.frequency1Label = new System.Windows.Forms.Label();
            this.frequency2Label = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.graph1Chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.graph2Chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frequency1TrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frequency2TrackBar)).BeginInit();
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
            series3.Name = "Series1";
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
            series4.Name = "Series1";
            this.graph2Chart.Series.Add(series4);
            this.graph2Chart.Size = new System.Drawing.Size(700, 100);
            this.graph2Chart.TabIndex = 1;
            this.graph2Chart.Text = "chart1";
            // 
            // frequency1TrackBar
            // 
            this.frequency1TrackBar.Location = new System.Drawing.Point(12, 144);
            this.frequency1TrackBar.Name = "frequency1TrackBar";
            this.frequency1TrackBar.Size = new System.Drawing.Size(232, 45);
            this.frequency1TrackBar.TabIndex = 2;
            this.frequency1TrackBar.Scroll += new System.EventHandler(this.frequency1TrackBar_Scroll);
            // 
            // frequency2TrackBar
            // 
            this.frequency2TrackBar.Location = new System.Drawing.Point(12, 325);
            this.frequency2TrackBar.Name = "frequency2TrackBar";
            this.frequency2TrackBar.Size = new System.Drawing.Size(232, 45);
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
            // frequency1Label
            // 
            this.frequency1Label.AutoSize = true;
            this.frequency1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.frequency1Label.Location = new System.Drawing.Point(12, 118);
            this.frequency1Label.Name = "frequency1Label";
            this.frequency1Label.Size = new System.Drawing.Size(18, 20);
            this.frequency1Label.TabIndex = 26;
            this.frequency1Label.Text = "0";
            // 
            // frequency2Label
            // 
            this.frequency2Label.AutoSize = true;
            this.frequency2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.frequency2Label.Location = new System.Drawing.Point(12, 296);
            this.frequency2Label.Name = "frequency2Label";
            this.frequency2Label.Size = new System.Drawing.Size(18, 20);
            this.frequency2Label.TabIndex = 27;
            this.frequency2Label.Text = "0";
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
            // OscillographForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 450);
            this.Controls.Add(this.frequency2Label);
            this.Controls.Add(this.frequency1Label);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart graph1Chart;
        private System.Windows.Forms.DataVisualization.Charting.Chart graph2Chart;
        private System.Windows.Forms.TrackBar frequency1TrackBar;
        private System.Windows.Forms.TrackBar frequency2TrackBar;
        private System.Windows.Forms.Button button1Start;
        private System.Windows.Forms.Button button2Start;
        private System.Windows.Forms.Label frequency1Label;
        private System.Windows.Forms.Label frequency2Label;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
    }
}