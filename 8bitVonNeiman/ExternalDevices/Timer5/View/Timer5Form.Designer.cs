namespace _8bitVonNeiman.ExternalDevices.Timer5.View {
    partial class Timer5Form {
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
            this.captureButton = new System.Windows.Forms.Button();
            this.interruptionVectorLabel = new System.Windows.Forms.Label();
            this.baseAddressLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.resetButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.tscrLTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tscrHTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ocrLTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ocrHTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tcntLTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tcntHTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.icrLTextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.icrHTextBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.outputPinTextBox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // captureButton
            // 
            this.captureButton.Location = new System.Drawing.Point(37, 297);
            this.captureButton.Name = "captureButton";
            this.captureButton.Size = new System.Drawing.Size(75, 23);
            this.captureButton.TabIndex = 58;
            this.captureButton.Text = "Захват";
            this.captureButton.UseVisualStyleBackColor = true;
            this.captureButton.Click += new System.EventHandler(this.captureButton_Click);
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
            this.baseAddressLabel.Text = "10";
            this.baseAddressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Вектор прерывания";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Базовый адрес";
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(37, 343);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 57;
            this.resetButton.Text = "Сброс";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.interruptionVectorLabel);
            this.panel1.Controls.Add(this.baseAddressLabel);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Location = new System.Drawing.Point(139, 297);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(191, 69);
            this.panel1.TabIndex = 56;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(143, 191);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 20);
            this.label6.TabIndex = 55;
            this.label6.Text = "6";
            // 
            // tscrLTextBox
            // 
            this.tscrLTextBox.BackColor = System.Drawing.Color.White;
            this.tscrLTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tscrLTextBox.Location = new System.Drawing.Point(167, 188);
            this.tscrLTextBox.Name = "tscrLTextBox";
            this.tscrLTextBox.ReadOnly = true;
            this.tscrLTextBox.Size = new System.Drawing.Size(93, 26);
            this.tscrLTextBox.TabIndex = 54;
            this.tscrLTextBox.TabStop = false;
            this.tscrLTextBox.Text = "0000 0000";
            this.tscrLTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(281, 191);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 20);
            this.label7.TabIndex = 53;
            this.label7.Text = "TSCR";
            // 
            // tscrHTextBox
            // 
            this.tscrHTextBox.BackColor = System.Drawing.Color.White;
            this.tscrHTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tscrHTextBox.Location = new System.Drawing.Point(37, 188);
            this.tscrHTextBox.Name = "tscrHTextBox";
            this.tscrHTextBox.ReadOnly = true;
            this.tscrHTextBox.Size = new System.Drawing.Size(93, 26);
            this.tscrHTextBox.TabIndex = 52;
            this.tscrHTextBox.TabStop = false;
            this.tscrHTextBox.Text = "0000 0000";
            this.tscrHTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(13, 191);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 20);
            this.label8.TabIndex = 51;
            this.label8.Text = "7";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(143, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 20);
            this.label3.TabIndex = 50;
            this.label3.Text = "2";
            // 
            // ocrLTextBox
            // 
            this.ocrLTextBox.BackColor = System.Drawing.Color.White;
            this.ocrLTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ocrLTextBox.Location = new System.Drawing.Point(167, 78);
            this.ocrLTextBox.Name = "ocrLTextBox";
            this.ocrLTextBox.ReadOnly = true;
            this.ocrLTextBox.Size = new System.Drawing.Size(93, 26);
            this.ocrLTextBox.TabIndex = 49;
            this.ocrLTextBox.TabStop = false;
            this.ocrLTextBox.Text = "0000 0000";
            this.ocrLTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(281, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 20);
            this.label4.TabIndex = 48;
            this.label4.Text = "OCR";
            // 
            // ocrHTextBox
            // 
            this.ocrHTextBox.BackColor = System.Drawing.Color.White;
            this.ocrHTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ocrHTextBox.Location = new System.Drawing.Point(37, 78);
            this.ocrHTextBox.Name = "ocrHTextBox";
            this.ocrHTextBox.ReadOnly = true;
            this.ocrHTextBox.Size = new System.Drawing.Size(93, 26);
            this.ocrHTextBox.TabIndex = 47;
            this.ocrHTextBox.TabStop = false;
            this.ocrHTextBox.Text = "0000 0000";
            this.ocrHTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(13, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 20);
            this.label5.TabIndex = 46;
            this.label5.Text = "3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(143, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 20);
            this.label1.TabIndex = 45;
            this.label1.Text = "0";
            // 
            // tcntLTextBox
            // 
            this.tcntLTextBox.BackColor = System.Drawing.Color.White;
            this.tcntLTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tcntLTextBox.Location = new System.Drawing.Point(167, 23);
            this.tcntLTextBox.Name = "tcntLTextBox";
            this.tcntLTextBox.ReadOnly = true;
            this.tcntLTextBox.Size = new System.Drawing.Size(93, 26);
            this.tcntLTextBox.TabIndex = 44;
            this.tcntLTextBox.TabStop = false;
            this.tcntLTextBox.Text = "0000 0000";
            this.tcntLTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(281, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 20);
            this.label10.TabIndex = 43;
            this.label10.Text = "TCNT";
            // 
            // tcntHTextBox
            // 
            this.tcntHTextBox.BackColor = System.Drawing.Color.White;
            this.tcntHTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tcntHTextBox.Location = new System.Drawing.Point(37, 23);
            this.tcntHTextBox.Name = "tcntHTextBox";
            this.tcntHTextBox.ReadOnly = true;
            this.tcntHTextBox.Size = new System.Drawing.Size(93, 26);
            this.tcntHTextBox.TabIndex = 42;
            this.tcntHTextBox.TabStop = false;
            this.tcntHTextBox.Text = "0000 0000";
            this.tcntHTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(13, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 20);
            this.label2.TabIndex = 41;
            this.label2.Text = "1";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(143, 136);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(18, 20);
            this.label12.TabIndex = 63;
            this.label12.Text = "4";
            // 
            // icrLTextBox
            // 
            this.icrLTextBox.BackColor = System.Drawing.Color.White;
            this.icrLTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.icrLTextBox.Location = new System.Drawing.Point(167, 133);
            this.icrLTextBox.Name = "icrLTextBox";
            this.icrLTextBox.ReadOnly = true;
            this.icrLTextBox.Size = new System.Drawing.Size(93, 26);
            this.icrLTextBox.TabIndex = 62;
            this.icrLTextBox.TabStop = false;
            this.icrLTextBox.Text = "0000 0000";
            this.icrLTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(281, 136);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(37, 20);
            this.label13.TabIndex = 61;
            this.label13.Text = "ICR";
            // 
            // icrHTextBox
            // 
            this.icrHTextBox.BackColor = System.Drawing.Color.White;
            this.icrHTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.icrHTextBox.Location = new System.Drawing.Point(37, 133);
            this.icrHTextBox.Name = "icrHTextBox";
            this.icrHTextBox.ReadOnly = true;
            this.icrHTextBox.Size = new System.Drawing.Size(93, 26);
            this.icrHTextBox.TabIndex = 60;
            this.icrHTextBox.TabStop = false;
            this.icrHTextBox.Text = "0000 0000";
            this.icrHTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(13, 136);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(18, 20);
            this.label14.TabIndex = 59;
            this.label14.Text = "5";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.Location = new System.Drawing.Point(54, 246);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(141, 20);
            this.label15.TabIndex = 64;
            this.label15.Text = "Выходной сигнал";
            // 
            // outputPinTextBox
            // 
            this.outputPinTextBox.BackColor = System.Drawing.Color.White;
            this.outputPinTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.outputPinTextBox.Location = new System.Drawing.Point(201, 243);
            this.outputPinTextBox.Name = "outputPinTextBox";
            this.outputPinTextBox.ReadOnly = true;
            this.outputPinTextBox.Size = new System.Drawing.Size(93, 26);
            this.outputPinTextBox.TabIndex = 65;
            this.outputPinTextBox.TabStop = false;
            this.outputPinTextBox.Text = "0";
            this.outputPinTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Timer5Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 384);
            this.Controls.Add(this.outputPinTextBox);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.icrLTextBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.icrHTextBox);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.captureButton);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tscrLTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tscrHTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ocrLTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ocrHTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tcntLTextBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tcntHTextBox);
            this.Controls.Add(this.label2);
            this.Name = "Timer5Form";
            this.Text = "Таймер 5";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Timer5Form_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button captureButton;
        private System.Windows.Forms.Label interruptionVectorLabel;
        private System.Windows.Forms.Label baseAddressLabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tscrLTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tscrHTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ocrLTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ocrHTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tcntLTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tcntHTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox icrLTextBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox icrHTextBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox outputPinTextBox;
    }
}