namespace _8bitVonNeiman.ExternalDevices.LCDDisplay.View
{
    partial class LCDDisplayForm
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
            this.Help = new System.Windows.Forms.Button();
            this.Settings = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.lcdpanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.interruptionVectorLabel = new System.Windows.Forms.Label();
            this.baseAddressLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.scrBinTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.drBinTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.arBinTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.MemoryBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Help
            // 
            this.Help.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Help.Location = new System.Drawing.Point(304, 3);
            this.Help.Name = "Help";
            this.Help.Size = new System.Drawing.Size(109, 26);
            this.Help.TabIndex = 12;
            this.Help.Text = "Помощь";
            this.Help.UseVisualStyleBackColor = true;
            this.Help.Click += new System.EventHandler(this.Help_Click);
            // 
            // Settings
            // 
            this.Settings.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Settings.Location = new System.Drawing.Point(154, 3);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(100, 26);
            this.Settings.TabIndex = 11;
            this.Settings.Text = "Настройки";
            this.Settings.UseVisualStyleBackColor = true;
            this.Settings.Click += new System.EventHandler(this.Settings_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ResetButton.Location = new System.Drawing.Point(15, 3);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(88, 26);
            this.ResetButton.TabIndex = 10;
            this.ResetButton.Text = "Сброс";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // lcdpanel
            // 
            this.lcdpanel.Location = new System.Drawing.Point(14, 35);
            this.lcdpanel.Name = "lcdpanel";
            this.lcdpanel.Size = new System.Drawing.Size(557, 56);
            this.lcdpanel.TabIndex = 9;
            this.lcdpanel.Paint += new System.Windows.Forms.PaintEventHandler(this.lcdpanel_Paint);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.interruptionVectorLabel);
            this.panel1.Controls.Add(this.baseAddressLabel);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(374, 110);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(191, 69);
            this.panel1.TabIndex = 31;
            // 
            // interruptionVectorLabel
            // 
            this.interruptionVectorLabel.AutoSize = true;
            this.interruptionVectorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.interruptionVectorLabel.Location = new System.Drawing.Point(130, 39);
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
            this.baseAddressLabel.Location = new System.Drawing.Point(126, 10);
            this.baseAddressLabel.Name = "baseAddressLabel";
            this.baseAddressLabel.Size = new System.Drawing.Size(27, 20);
            this.baseAddressLabel.TabIndex = 2;
            this.baseAddressLabel.Text = "60";
            this.baseAddressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Вектор прерывания";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Базовый адрес";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(324, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 20);
            this.label1.TabIndex = 37;
            this.label1.Text = "SCR";
            // 
            // scrBinTextBox
            // 
            this.scrBinTextBox.BackColor = System.Drawing.Color.White;
            this.scrBinTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.scrBinTextBox.Location = new System.Drawing.Point(225, 110);
            this.scrBinTextBox.Name = "scrBinTextBox";
            this.scrBinTextBox.ReadOnly = true;
            this.scrBinTextBox.Size = new System.Drawing.Size(93, 26);
            this.scrBinTextBox.TabIndex = 36;
            this.scrBinTextBox.TabStop = false;
            this.scrBinTextBox.Text = "0000 0000";
            this.scrBinTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(201, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 20);
            this.label3.TabIndex = 35;
            this.label3.Text = "2";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(133, 113);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 20);
            this.label10.TabIndex = 34;
            this.label10.Text = "DR";
            // 
            // drBinTextBox
            // 
            this.drBinTextBox.BackColor = System.Drawing.Color.White;
            this.drBinTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.drBinTextBox.Location = new System.Drawing.Point(34, 110);
            this.drBinTextBox.Name = "drBinTextBox";
            this.drBinTextBox.ReadOnly = true;
            this.drBinTextBox.Size = new System.Drawing.Size(93, 26);
            this.drBinTextBox.TabIndex = 33;
            this.drBinTextBox.TabStop = false;
            this.drBinTextBox.Text = "0000 0000";
            this.drBinTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(10, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 20);
            this.label2.TabIndex = 32;
            this.label2.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(133, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 20);
            this.label4.TabIndex = 40;
            this.label4.Text = "AR";
            // 
            // arBinTextBox
            // 
            this.arBinTextBox.BackColor = System.Drawing.Color.White;
            this.arBinTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.arBinTextBox.Location = new System.Drawing.Point(34, 148);
            this.arBinTextBox.Name = "arBinTextBox";
            this.arBinTextBox.ReadOnly = true;
            this.arBinTextBox.Size = new System.Drawing.Size(93, 26);
            this.arBinTextBox.TabIndex = 39;
            this.arBinTextBox.TabStop = false;
            this.arBinTextBox.Text = "0000 0000";
            this.arBinTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(10, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 20);
            this.label5.TabIndex = 38;
            this.label5.Text = "1";
            // 
            // MemoryBtn
            // 
            this.MemoryBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.MemoryBtn.Location = new System.Drawing.Point(462, 4);
            this.MemoryBtn.Name = "MemoryBtn";
            this.MemoryBtn.Size = new System.Drawing.Size(109, 25);
            this.MemoryBtn.TabIndex = 41;
            this.MemoryBtn.Text = "Память";
            this.MemoryBtn.UseVisualStyleBackColor = true;
            this.MemoryBtn.Click += new System.EventHandler(this.MemoryBtn_Click);
            // 
            // LCDDisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 192);
            this.Controls.Add(this.MemoryBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.arBinTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.scrBinTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.drBinTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Help);
            this.Controls.Add(this.Settings);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.lcdpanel);
            this.Name = "LCDDisplayForm";
            this.Text = "LCD-Display";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Help;
        private System.Windows.Forms.Button Settings;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Panel lcdpanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label interruptionVectorLabel;
        private System.Windows.Forms.Label baseAddressLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox scrBinTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox drBinTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox arBinTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button MemoryBtn;
    }
}