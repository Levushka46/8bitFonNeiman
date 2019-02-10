namespace _8bitVonNeiman.ExternalDevices.Display.View {
    partial class DisplayForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.displayTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.drBinTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.crBinTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.arBinTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.interruptionVectorLabel = new System.Windows.Forms.Label();
            this.baseAddressLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.resetButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // displayTextBox
            // 
            this.displayTextBox.Enabled = false;
            this.displayTextBox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.displayTextBox.Location = new System.Drawing.Point(12, 12);
            this.displayTextBox.Multiline = true;
            this.displayTextBox.Name = "displayTextBox";
            this.displayTextBox.ReadOnly = true;
            this.displayTextBox.Size = new System.Drawing.Size(170, 151);
            this.displayTextBox.TabIndex = 0;
            this.displayTextBox.Text = "                \r\n                \r\n                \r\n                \r\n         " +
    "       \r\n                \r\n                \r\n                ";
            this.displayTextBox.WordWrap = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(136, 172);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 20);
            this.label10.TabIndex = 22;
            this.label10.Text = "DR";
            // 
            // drBinTextBox
            // 
            this.drBinTextBox.BackColor = System.Drawing.Color.White;
            this.drBinTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.drBinTextBox.Location = new System.Drawing.Point(37, 169);
            this.drBinTextBox.Name = "drBinTextBox";
            this.drBinTextBox.ReadOnly = true;
            this.drBinTextBox.Size = new System.Drawing.Size(93, 26);
            this.drBinTextBox.TabIndex = 21;
            this.drBinTextBox.TabStop = false;
            this.drBinTextBox.Text = "0000 0000";
            this.drBinTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(13, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(327, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 20);
            this.label1.TabIndex = 25;
            this.label1.Text = "CR";
            // 
            // crBinTextBox
            // 
            this.crBinTextBox.BackColor = System.Drawing.Color.White;
            this.crBinTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.crBinTextBox.Location = new System.Drawing.Point(228, 169);
            this.crBinTextBox.Name = "crBinTextBox";
            this.crBinTextBox.ReadOnly = true;
            this.crBinTextBox.Size = new System.Drawing.Size(93, 26);
            this.crBinTextBox.TabIndex = 24;
            this.crBinTextBox.TabStop = false;
            this.crBinTextBox.Text = "0000 0000";
            this.crBinTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(204, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 20);
            this.label3.TabIndex = 23;
            this.label3.Text = "1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(136, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 20);
            this.label4.TabIndex = 28;
            this.label4.Text = "AR";
            // 
            // arBinTextBox
            // 
            this.arBinTextBox.BackColor = System.Drawing.Color.White;
            this.arBinTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.arBinTextBox.Location = new System.Drawing.Point(37, 201);
            this.arBinTextBox.Name = "arBinTextBox";
            this.arBinTextBox.ReadOnly = true;
            this.arBinTextBox.Size = new System.Drawing.Size(93, 26);
            this.arBinTextBox.TabIndex = 27;
            this.arBinTextBox.TabStop = false;
            this.arBinTextBox.Text = "0000 0000";
            this.arBinTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(13, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 20);
            this.label5.TabIndex = 26;
            this.label5.Text = "2";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.interruptionVectorLabel);
            this.panel1.Controls.Add(this.baseAddressLabel);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(213, 236);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(191, 69);
            this.panel1.TabIndex = 30;
            // 
            // interruptionVectorLabel
            // 
            this.interruptionVectorLabel.AutoSize = true;
            this.interruptionVectorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.interruptionVectorLabel.Location = new System.Drawing.Point(126, 39);
            this.interruptionVectorLabel.Name = "interruptionVectorLabel";
            this.interruptionVectorLabel.Size = new System.Drawing.Size(18, 20);
            this.interruptionVectorLabel.TabIndex = 3;
            this.interruptionVectorLabel.Text = "0";
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
            this.baseAddressLabel.Text = "10";
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
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(228, 204);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 29;
            this.resetButton.Text = "Сброс";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // DisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 321);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.arBinTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.crBinTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.drBinTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.displayTextBox);
            this.Name = "DisplayForm";
            this.Text = "Дисплей";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DisplayForm_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox displayTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox drBinTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox crBinTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox arBinTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label interruptionVectorLabel;
        private System.Windows.Forms.Label baseAddressLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button resetButton;
    }
}