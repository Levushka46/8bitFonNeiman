namespace _8bitVonNeiman.ExternalDevices.GraphicDisplay.View
{
    partial class GraphicDisplayForm
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
            this.Screen = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.crBinTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.arLBinTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.drBinTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DrawButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.interruptionVectorLabel = new System.Windows.Forms.Label();
            this.baseAddressLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.arHBinTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.PaletteButton = new System.Windows.Forms.Button();
            this.VideomemoryButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.HelpButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Screen)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Screen
            // 
            this.Screen.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Screen.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Screen.Location = new System.Drawing.Point(12, 40);
            this.Screen.Name = "Screen";
            this.Screen.Size = new System.Drawing.Size(512, 256);
            this.Screen.TabIndex = 0;
            this.Screen.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(250, 308);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 20);
            this.label5.TabIndex = 34;
            this.label5.Text = "AR";
            // 
            // crBinTextBox
            // 
            this.crBinTextBox.BackColor = System.Drawing.Color.White;
            this.crBinTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.crBinTextBox.Location = new System.Drawing.Point(155, 375);
            this.crBinTextBox.Name = "crBinTextBox";
            this.crBinTextBox.ReadOnly = true;
            this.crBinTextBox.Size = new System.Drawing.Size(93, 26);
            this.crBinTextBox.TabIndex = 33;
            this.crBinTextBox.TabStop = false;
            this.crBinTextBox.Text = "00000000";
            this.crBinTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(250, 378);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 20);
            this.label6.TabIndex = 32;
            this.label6.Text = "CR";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(135, 343);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 20);
            this.label3.TabIndex = 31;
            this.label3.Text = "2";
            // 
            // arLBinTextBox
            // 
            this.arLBinTextBox.BackColor = System.Drawing.Color.White;
            this.arLBinTextBox.CausesValidation = false;
            this.arLBinTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.arLBinTextBox.Location = new System.Drawing.Point(155, 305);
            this.arLBinTextBox.Name = "arLBinTextBox";
            this.arLBinTextBox.ReadOnly = true;
            this.arLBinTextBox.Size = new System.Drawing.Size(93, 26);
            this.arLBinTextBox.TabIndex = 30;
            this.arLBinTextBox.TabStop = false;
            this.arLBinTextBox.Text = "00000000";
            this.arLBinTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(135, 308);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 20);
            this.label1.TabIndex = 29;
            this.label1.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(250, 343);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 20);
            this.label4.TabIndex = 28;
            this.label4.Text = "DR";
            // 
            // drBinTextBox
            // 
            this.drBinTextBox.BackColor = System.Drawing.Color.White;
            this.drBinTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.drBinTextBox.Location = new System.Drawing.Point(155, 340);
            this.drBinTextBox.Name = "drBinTextBox";
            this.drBinTextBox.ReadOnly = true;
            this.drBinTextBox.Size = new System.Drawing.Size(93, 26);
            this.drBinTextBox.TabIndex = 27;
            this.drBinTextBox.TabStop = false;
            this.drBinTextBox.Text = "00000000";
            this.drBinTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(10, 308);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 20);
            this.label2.TabIndex = 26;
            this.label2.Text = "1";
            // 
            // DrawButton
            // 
            this.DrawButton.Location = new System.Drawing.Point(12, 11);
            this.DrawButton.Name = "DrawButton";
            this.DrawButton.Size = new System.Drawing.Size(84, 23);
            this.DrawButton.TabIndex = 36;
            this.DrawButton.Text = "Нарисовать";
            this.DrawButton.UseVisualStyleBackColor = true;
            this.DrawButton.Click += new System.EventHandler(this.DrawButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.interruptionVectorLabel);
            this.panel1.Controls.Add(this.baseAddressLabel);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(312, 302);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(212, 87);
            this.panel1.TabIndex = 37;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(145, 61);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 20);
            this.label11.TabIndex = 5;
            this.label11.Text = "128*64";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 66);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(141, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Разрешение изображения";
            // 
            // interruptionVectorLabel
            // 
            this.interruptionVectorLabel.AutoSize = true;
            this.interruptionVectorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.interruptionVectorLabel.Location = new System.Drawing.Point(129, 37);
            this.interruptionVectorLabel.Name = "interruptionVectorLabel";
            this.interruptionVectorLabel.Size = new System.Drawing.Size(15, 20);
            this.interruptionVectorLabel.TabIndex = 3;
            this.interruptionVectorLabel.Text = "–";
            this.interruptionVectorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // baseAddressLabel
            // 
            this.baseAddressLabel.AutoSize = true;
            this.baseAddressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.baseAddressLabel.Location = new System.Drawing.Point(126, 12);
            this.baseAddressLabel.Name = "baseAddressLabel";
            this.baseAddressLabel.Size = new System.Drawing.Size(43, 20);
            this.baseAddressLabel.TabIndex = 2;
            this.baseAddressLabel.Text = "0x50";
            this.baseAddressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Вектор прерывания";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Базовый адрес";
            // 
            // arHBinTextBox
            // 
            this.arHBinTextBox.BackColor = System.Drawing.Color.White;
            this.arHBinTextBox.CausesValidation = false;
            this.arHBinTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.arHBinTextBox.Location = new System.Drawing.Point(30, 305);
            this.arHBinTextBox.Name = "arHBinTextBox";
            this.arHBinTextBox.ReadOnly = true;
            this.arHBinTextBox.Size = new System.Drawing.Size(93, 26);
            this.arHBinTextBox.TabIndex = 41;
            this.arHBinTextBox.TabStop = false;
            this.arHBinTextBox.Text = "00000000";
            this.arHBinTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(135, 378);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(18, 20);
            this.label9.TabIndex = 42;
            this.label9.Text = "3";
            // 
            // PaletteButton
            // 
            this.PaletteButton.Location = new System.Drawing.Point(192, 11);
            this.PaletteButton.Name = "PaletteButton";
            this.PaletteButton.Size = new System.Drawing.Size(84, 23);
            this.PaletteButton.TabIndex = 43;
            this.PaletteButton.Text = "Палитра";
            this.PaletteButton.UseVisualStyleBackColor = true;
            this.PaletteButton.Click += new System.EventHandler(this.PaletteButton_Click);
            // 
            // VideomemoryButton
            // 
            this.VideomemoryButton.Location = new System.Drawing.Point(102, 11);
            this.VideomemoryButton.Name = "VideomemoryButton";
            this.VideomemoryButton.Size = new System.Drawing.Size(84, 23);
            this.VideomemoryButton.TabIndex = 45;
            this.VideomemoryButton.Text = "Видеопамять";
            this.VideomemoryButton.UseVisualStyleBackColor = true;
            this.VideomemoryButton.Click += new System.EventHandler(this.VideomemoryButton_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(282, 11);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(84, 23);
            this.ResetButton.TabIndex = 46;
            this.ResetButton.Text = "Сброс";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // HelpButton
            // 
            this.HelpButton.Location = new System.Drawing.Point(372, 11);
            this.HelpButton.Name = "HelpButton";
            this.HelpButton.Size = new System.Drawing.Size(84, 23);
            this.HelpButton.TabIndex = 47;
            this.HelpButton.Text = "Помощь";
            this.HelpButton.UseVisualStyleBackColor = true;
            this.HelpButton.Click += new System.EventHandler(this.HelpButton_Click);
            // 
            // GraphicDisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 405);
            this.Controls.Add(this.HelpButton);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.VideomemoryButton);
            this.Controls.Add(this.PaletteButton);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.arHBinTextBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DrawButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.crBinTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.arLBinTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.drBinTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Screen);
            this.Name = "GraphicDisplayForm";
            this.Text = "Графический дисплей";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GraphicDisplayForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.Screen)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Screen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox crBinTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox arLBinTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox drBinTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button DrawButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label interruptionVectorLabel;
        private System.Windows.Forms.Label baseAddressLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox arHBinTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button PaletteButton;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button VideomemoryButton;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Button HelpButton;
    }
}