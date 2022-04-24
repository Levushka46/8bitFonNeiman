namespace _8bitVonNeiman.ExternalDevices.SerialController.View
{
    partial class SerialControllerForm
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
            this.label4 = new System.Windows.Forms.Label();
            this.scrBinTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.drBinTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.interruptionVectorLabel = new System.Windows.Forms.Label();
            this.baseAddressLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(134, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 20);
            this.label4.TabIndex = 49;
            this.label4.Text = "SCR";
            // 
            // scrBinTextBox
            // 
            this.scrBinTextBox.BackColor = System.Drawing.Color.White;
            this.scrBinTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.scrBinTextBox.Location = new System.Drawing.Point(35, 50);
            this.scrBinTextBox.Name = "scrBinTextBox";
            this.scrBinTextBox.ReadOnly = true;
            this.scrBinTextBox.Size = new System.Drawing.Size(93, 26);
            this.scrBinTextBox.TabIndex = 48;
            this.scrBinTextBox.TabStop = false;
            this.scrBinTextBox.Text = "0000 0000";
            this.scrBinTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(11, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 20);
            this.label5.TabIndex = 47;
            this.label5.Text = "1";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(134, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 20);
            this.label10.TabIndex = 43;
            this.label10.Text = "DR";
            // 
            // drBinTextBox
            // 
            this.drBinTextBox.BackColor = System.Drawing.Color.White;
            this.drBinTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.drBinTextBox.Location = new System.Drawing.Point(35, 12);
            this.drBinTextBox.Name = "drBinTextBox";
            this.drBinTextBox.ReadOnly = true;
            this.drBinTextBox.Size = new System.Drawing.Size(93, 26);
            this.drBinTextBox.TabIndex = 42;
            this.drBinTextBox.TabStop = false;
            this.drBinTextBox.Text = "0000 0000";
            this.drBinTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(11, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 20);
            this.label2.TabIndex = 41;
            this.label2.Text = "0";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.interruptionVectorLabel);
            this.panel1.Controls.Add(this.baseAddressLabel);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(198, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(191, 69);
            this.panel1.TabIndex = 50;
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
            this.baseAddressLabel.Text = "00";
            this.baseAddressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 39);
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
            // SerialControllerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 86);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.scrBinTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.drBinTextBox);
            this.Controls.Add(this.label2);
            this.Name = "SerialControllerForm";
            this.Text = "SerialController";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SerialControllerForm_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox scrBinTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox drBinTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label interruptionVectorLabel;
        private System.Windows.Forms.Label baseAddressLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}