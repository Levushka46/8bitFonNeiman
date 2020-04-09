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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.graph1Chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.graph2Chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.frequency1TrackBar = new System.Windows.Forms.TrackBar();
            this.frequency2TrackBar = new System.Windows.Forms.TrackBar();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.frequency1Label = new System.Windows.Forms.Label();
            this.frequency2Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.graph1Chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.graph2Chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frequency1TrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frequency2TrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // graph1Chart
            // 
            chartArea5.Name = "ChartArea1";
            this.graph1Chart.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.graph1Chart.Legends.Add(legend5);
            this.graph1Chart.Location = new System.Drawing.Point(12, 12);
            this.graph1Chart.Name = "graph1Chart";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.graph1Chart.Series.Add(series5);
            this.graph1Chart.Size = new System.Drawing.Size(700, 100);
            this.graph1Chart.TabIndex = 0;
            this.graph1Chart.Text = "chart1";
            // 
            // graph2Chart
            // 
            chartArea6.Name = "ChartArea1";
            this.graph2Chart.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.graph2Chart.Legends.Add(legend6);
            this.graph2Chart.Location = new System.Drawing.Point(12, 193);
            this.graph2Chart.Name = "graph2Chart";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.graph2Chart.Series.Add(series6);
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(637, 118);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Старт";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(637, 299);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Старт";
            this.button2.UseVisualStyleBackColor = true;
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
            // OscillographForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 450);
            this.Controls.Add(this.frequency2Label);
            this.Controls.Add(this.frequency1Label);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label frequency1Label;
        private System.Windows.Forms.Label frequency2Label;
    }
}