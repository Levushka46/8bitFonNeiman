namespace _8bitVonNeiman.ExternalDevicesManager.View {
	partial class DeviceManagerForm {
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
            this.addDeviceButton = new System.Windows.Forms.Button();
            this.addDisplayButton = new System.Windows.Forms.Button();
            this.addTimer2Button = new System.Windows.Forms.Button();
            this.addTimer5Button = new System.Windows.Forms.Button();
            this.addOscillographButton = new System.Windows.Forms.Button();
            this.addKeypadAndIndicationButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addDeviceButton
            // 
            this.addDeviceButton.Location = new System.Drawing.Point(85, 10);
            this.addDeviceButton.Name = "addDeviceButton";
            this.addDeviceButton.Size = new System.Drawing.Size(149, 23);
            this.addDeviceButton.TabIndex = 0;
            this.addDeviceButton.Text = "Клавиатура";
            this.addDeviceButton.UseVisualStyleBackColor = true;
            this.addDeviceButton.Click += new System.EventHandler(this.addDeviceButton_Click);
            // 
            // addDisplayButton
            // 
            this.addDisplayButton.Location = new System.Drawing.Point(85, 40);
            this.addDisplayButton.Name = "addDisplayButton";
            this.addDisplayButton.Size = new System.Drawing.Size(149, 24);
            this.addDisplayButton.TabIndex = 1;
            this.addDisplayButton.Text = "Дисплей";
            this.addDisplayButton.UseVisualStyleBackColor = true;
            this.addDisplayButton.Click += new System.EventHandler(this.addDisplayButton_Click);
            // 
            // addTimer2Button
            // 
            this.addTimer2Button.Location = new System.Drawing.Point(85, 70);
            this.addTimer2Button.Name = "addTimer2Button";
            this.addTimer2Button.Size = new System.Drawing.Size(149, 24);
            this.addTimer2Button.TabIndex = 2;
            this.addTimer2Button.Text = "Таймер 2";
            this.addTimer2Button.UseVisualStyleBackColor = true;
            this.addTimer2Button.Click += new System.EventHandler(this.addTimer2Button_Click);
            // 
            // addTimer5Button
            // 
            this.addTimer5Button.Location = new System.Drawing.Point(85, 100);
            this.addTimer5Button.Name = "addTimer5Button";
            this.addTimer5Button.Size = new System.Drawing.Size(149, 24);
            this.addTimer5Button.TabIndex = 3;
            this.addTimer5Button.Text = "Таймер 5";
            this.addTimer5Button.UseVisualStyleBackColor = true;
            this.addTimer5Button.Click += new System.EventHandler(this.addTimer5Button_Click);
            // 
            // addOscillographButton
            // 
            this.addOscillographButton.Location = new System.Drawing.Point(85, 130);
            this.addOscillographButton.Name = "addOscillographButton";
            this.addOscillographButton.Size = new System.Drawing.Size(149, 24);
            this.addOscillographButton.TabIndex = 4;
            this.addOscillographButton.Text = "Осциллограф";
            this.addOscillographButton.UseVisualStyleBackColor = true;
            this.addOscillographButton.Click += new System.EventHandler(this.addOscillographButton_Click);
            // 
            // addKeypadAndIndicationButton
            // 
            this.addKeypadAndIndicationButton.Location = new System.Drawing.Point(85, 160);
            this.addKeypadAndIndicationButton.Name = "addKeypadAndIndicationButton";
            this.addKeypadAndIndicationButton.Size = new System.Drawing.Size(149, 24);
            this.addKeypadAndIndicationButton.TabIndex = 5;
            this.addKeypadAndIndicationButton.Text = "Клав. и Индикация";
            this.addKeypadAndIndicationButton.UseVisualStyleBackColor = true;
            this.addKeypadAndIndicationButton.Click += new System.EventHandler(this.addKeypadAndIndicationButton_Click);
            // 
            // DeviceManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 195);
            this.Controls.Add(this.addKeypadAndIndicationButton);
            this.Controls.Add(this.addOscillographButton);
            this.Controls.Add(this.addTimer5Button);
            this.Controls.Add(this.addTimer2Button);
            this.Controls.Add(this.addDisplayButton);
            this.Controls.Add(this.addDeviceButton);
            this.Location = new System.Drawing.Point(0, 200);
            this.Name = "DeviceManagerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Диспетчер внешних устройств";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DeviceManagerForm_FormClosed);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button addDeviceButton;
        private System.Windows.Forms.Button addDisplayButton;
        private System.Windows.Forms.Button addTimer2Button;
        private System.Windows.Forms.Button addTimer5Button;
        private System.Windows.Forms.Button addOscillographButton;
        private System.Windows.Forms.Button addKeypadAndIndicationButton;
    }
}