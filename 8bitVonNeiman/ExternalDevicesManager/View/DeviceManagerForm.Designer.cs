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
			this.SuspendLayout();
			// 
			// addDeviceButton
			// 
			this.addDeviceButton.Location = new System.Drawing.Point(85, 12);
			this.addDeviceButton.Name = "addDeviceButton";
			this.addDeviceButton.Size = new System.Drawing.Size(149, 23);
			this.addDeviceButton.TabIndex = 0;
			this.addDeviceButton.Text = " Подключить клавиатуру";
			this.addDeviceButton.UseVisualStyleBackColor = true;
			this.addDeviceButton.Click += new System.EventHandler(this.addDeviceButton_Click);
			// 
			// DeviceManagerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(324, 91);
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
	}
}