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
            this.baseAddrDisplay = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.irqDisplay = new System.Windows.Forms.TextBox();
            this.baseAddrDevice = new System.Windows.Forms.TextBox();
            this.baseAddrKeypadAndIndication = new System.Windows.Forms.TextBox();
            this.baseAddrOscillograph = new System.Windows.Forms.TextBox();
            this.baseAddrTimer2 = new System.Windows.Forms.TextBox();
            this.baseAddrTimer5 = new System.Windows.Forms.TextBox();
            this.irqDevice = new System.Windows.Forms.TextBox();
            this.irqKeypadAndIndication = new System.Windows.Forms.TextBox();
            this.irqOscillograph = new System.Windows.Forms.TextBox();
            this.irqTimer2 = new System.Windows.Forms.TextBox();
            this.irqTimer5 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.irqGraphicDisplay = new System.Windows.Forms.TextBox();
            this.baseAddrGraphicDisplay = new System.Windows.Forms.TextBox();
            this.addGraphicDisplayButton = new System.Windows.Forms.Button();
            this.addLCDDisplayButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.irqLCDDisplay = new System.Windows.Forms.TextBox();
            this.baseAddrLCDDisplay = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // addDeviceButton
            // 
            this.addDeviceButton.Location = new System.Drawing.Point(10, 90);
            this.addDeviceButton.Name = "addDeviceButton";
            this.addDeviceButton.Size = new System.Drawing.Size(149, 23);
            this.addDeviceButton.TabIndex = 0;
            this.addDeviceButton.Text = "Клавиатура";
            this.addDeviceButton.UseVisualStyleBackColor = true;
            this.addDeviceButton.Click += new System.EventHandler(this.addDeviceButton_Click);
            // 
            // addDisplayButton
            // 
            this.addDisplayButton.Location = new System.Drawing.Point(10, 30);
            this.addDisplayButton.Name = "addDisplayButton";
            this.addDisplayButton.Size = new System.Drawing.Size(149, 24);
            this.addDisplayButton.TabIndex = 1;
            this.addDisplayButton.Text = "Дисплей";
            this.addDisplayButton.UseVisualStyleBackColor = true;
            this.addDisplayButton.Click += new System.EventHandler(this.addDisplayButton_Click);
            // 
            // addTimer2Button
            // 
            this.addTimer2Button.Location = new System.Drawing.Point(10, 180);
            this.addTimer2Button.Name = "addTimer2Button";
            this.addTimer2Button.Size = new System.Drawing.Size(149, 24);
            this.addTimer2Button.TabIndex = 2;
            this.addTimer2Button.Text = "Таймер 2";
            this.addTimer2Button.UseVisualStyleBackColor = true;
            this.addTimer2Button.Click += new System.EventHandler(this.addTimer2Button_Click);
            // 
            // addTimer5Button
            // 
            this.addTimer5Button.Location = new System.Drawing.Point(10, 210);
            this.addTimer5Button.Name = "addTimer5Button";
            this.addTimer5Button.Size = new System.Drawing.Size(149, 24);
            this.addTimer5Button.TabIndex = 3;
            this.addTimer5Button.Text = "Таймер 5";
            this.addTimer5Button.UseVisualStyleBackColor = true;
            this.addTimer5Button.Click += new System.EventHandler(this.addTimer5Button_Click);
            // 
            // addOscillographButton
            // 
            this.addOscillographButton.Location = new System.Drawing.Point(10, 150);
            this.addOscillographButton.Name = "addOscillographButton";
            this.addOscillographButton.Size = new System.Drawing.Size(149, 24);
            this.addOscillographButton.TabIndex = 4;
            this.addOscillographButton.Text = "Осциллограф";
            this.addOscillographButton.UseVisualStyleBackColor = true;
            this.addOscillographButton.Click += new System.EventHandler(this.addOscillographButton_Click);
            // 
            // addKeypadAndIndicationButton
            // 
            this.addKeypadAndIndicationButton.Location = new System.Drawing.Point(10, 120);
            this.addKeypadAndIndicationButton.Name = "addKeypadAndIndicationButton";
            this.addKeypadAndIndicationButton.Size = new System.Drawing.Size(149, 24);
            this.addKeypadAndIndicationButton.TabIndex = 5;
            this.addKeypadAndIndicationButton.Text = "Клав. и Индикация";
            this.addKeypadAndIndicationButton.UseVisualStyleBackColor = true;
            this.addKeypadAndIndicationButton.Click += new System.EventHandler(this.addKeypadAndIndicationButton_Click);
            // 
            // baseAddrDisplay
            // 
            this.baseAddrDisplay.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.baseAddrDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.baseAddrDisplay.Location = new System.Drawing.Point(185, 30);
            this.baseAddrDisplay.MaxLength = 1;
            this.baseAddrDisplay.Name = "baseAddrDisplay";
            this.baseAddrDisplay.Size = new System.Drawing.Size(24, 22);
            this.baseAddrDisplay.TabIndex = 6;
            this.baseAddrDisplay.Text = "1";
            this.baseAddrDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.baseAddrDisplay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsValid);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(167, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 26);
            this.label1.TabIndex = 7;
            this.label1.Text = "   Базовый\r\nадрес (HEX)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Внешнее устройство";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(241, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 26);
            this.label3.TabIndex = 9;
            this.label3.Text = "    Вектор\r\nпрерывания";
            // 
            // irqDisplay
            // 
            this.irqDisplay.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.irqDisplay.Enabled = false;
            this.irqDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.irqDisplay.Location = new System.Drawing.Point(260, 30);
            this.irqDisplay.MaxLength = 1;
            this.irqDisplay.Name = "irqDisplay";
            this.irqDisplay.Size = new System.Drawing.Size(24, 22);
            this.irqDisplay.TabIndex = 10;
            this.irqDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // baseAddrDevice
            // 
            this.baseAddrDevice.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.baseAddrDevice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.baseAddrDevice.Location = new System.Drawing.Point(185, 90);
            this.baseAddrDevice.MaxLength = 1;
            this.baseAddrDevice.Name = "baseAddrDevice";
            this.baseAddrDevice.Size = new System.Drawing.Size(24, 22);
            this.baseAddrDevice.TabIndex = 11;
            this.baseAddrDevice.Text = "0";
            this.baseAddrDevice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.baseAddrDevice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsValid);
            // 
            // baseAddrKeypadAndIndication
            // 
            this.baseAddrKeypadAndIndication.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.baseAddrKeypadAndIndication.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.baseAddrKeypadAndIndication.Location = new System.Drawing.Point(185, 120);
            this.baseAddrKeypadAndIndication.MaxLength = 1;
            this.baseAddrKeypadAndIndication.Name = "baseAddrKeypadAndIndication";
            this.baseAddrKeypadAndIndication.Size = new System.Drawing.Size(24, 22);
            this.baseAddrKeypadAndIndication.TabIndex = 12;
            this.baseAddrKeypadAndIndication.Text = "4";
            this.baseAddrKeypadAndIndication.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.baseAddrKeypadAndIndication.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsValid);
            // 
            // baseAddrOscillograph
            // 
            this.baseAddrOscillograph.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.baseAddrOscillograph.Enabled = false;
            this.baseAddrOscillograph.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.baseAddrOscillograph.Location = new System.Drawing.Point(185, 150);
            this.baseAddrOscillograph.MaxLength = 1;
            this.baseAddrOscillograph.Name = "baseAddrOscillograph";
            this.baseAddrOscillograph.Size = new System.Drawing.Size(24, 22);
            this.baseAddrOscillograph.TabIndex = 13;
            this.baseAddrOscillograph.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // baseAddrTimer2
            // 
            this.baseAddrTimer2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.baseAddrTimer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.baseAddrTimer2.Location = new System.Drawing.Point(185, 180);
            this.baseAddrTimer2.MaxLength = 1;
            this.baseAddrTimer2.Name = "baseAddrTimer2";
            this.baseAddrTimer2.Size = new System.Drawing.Size(24, 22);
            this.baseAddrTimer2.TabIndex = 14;
            this.baseAddrTimer2.Text = "2";
            this.baseAddrTimer2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.baseAddrTimer2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsValid);
            // 
            // baseAddrTimer5
            // 
            this.baseAddrTimer5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.baseAddrTimer5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.baseAddrTimer5.Location = new System.Drawing.Point(185, 210);
            this.baseAddrTimer5.MaxLength = 1;
            this.baseAddrTimer5.Name = "baseAddrTimer5";
            this.baseAddrTimer5.Size = new System.Drawing.Size(24, 22);
            this.baseAddrTimer5.TabIndex = 15;
            this.baseAddrTimer5.Text = "3";
            this.baseAddrTimer5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.baseAddrTimer5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsValid);
            // 
            // irqDevice
            // 
            this.irqDevice.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.irqDevice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.irqDevice.Location = new System.Drawing.Point(260, 90);
            this.irqDevice.MaxLength = 1;
            this.irqDevice.Name = "irqDevice";
            this.irqDevice.Size = new System.Drawing.Size(24, 22);
            this.irqDevice.TabIndex = 16;
            this.irqDevice.Text = "1";
            this.irqDevice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.irqDevice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsValid);
            // 
            // irqKeypadAndIndication
            // 
            this.irqKeypadAndIndication.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.irqKeypadAndIndication.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.irqKeypadAndIndication.Location = new System.Drawing.Point(260, 120);
            this.irqKeypadAndIndication.MaxLength = 1;
            this.irqKeypadAndIndication.Name = "irqKeypadAndIndication";
            this.irqKeypadAndIndication.Size = new System.Drawing.Size(24, 22);
            this.irqKeypadAndIndication.TabIndex = 17;
            this.irqKeypadAndIndication.Text = "4";
            this.irqKeypadAndIndication.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.irqKeypadAndIndication.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsValid);
            // 
            // irqOscillograph
            // 
            this.irqOscillograph.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.irqOscillograph.Enabled = false;
            this.irqOscillograph.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.irqOscillograph.Location = new System.Drawing.Point(260, 150);
            this.irqOscillograph.MaxLength = 1;
            this.irqOscillograph.Name = "irqOscillograph";
            this.irqOscillograph.Size = new System.Drawing.Size(24, 22);
            this.irqOscillograph.TabIndex = 18;
            this.irqOscillograph.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // irqTimer2
            // 
            this.irqTimer2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.irqTimer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.irqTimer2.Location = new System.Drawing.Point(260, 180);
            this.irqTimer2.MaxLength = 1;
            this.irqTimer2.Name = "irqTimer2";
            this.irqTimer2.Size = new System.Drawing.Size(24, 22);
            this.irqTimer2.TabIndex = 19;
            this.irqTimer2.Text = "2";
            this.irqTimer2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.irqTimer2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsValid);
            // 
            // irqTimer5
            // 
            this.irqTimer5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.irqTimer5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.irqTimer5.Location = new System.Drawing.Point(260, 210);
            this.irqTimer5.MaxLength = 1;
            this.irqTimer5.Name = "irqTimer5";
            this.irqTimer5.Size = new System.Drawing.Size(24, 22);
            this.irqTimer5.TabIndex = 20;
            this.irqTimer5.Text = "3";
            this.irqTimer5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.irqTimer5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsValid);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(209, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 16);
            this.label10.TabIndex = 21;
            this.label10.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(209, 93);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(15, 16);
            this.label12.TabIndex = 22;
            this.label12.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(209, 123);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(15, 16);
            this.label13.TabIndex = 23;
            this.label13.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(209, 153);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(15, 16);
            this.label14.TabIndex = 24;
            this.label14.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.Location = new System.Drawing.Point(209, 183);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(15, 16);
            this.label15.TabIndex = 25;
            this.label15.Text = "0";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.Location = new System.Drawing.Point(209, 213);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(15, 16);
            this.label16.TabIndex = 26;
            this.label16.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(209, 63);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(15, 16);
            this.label11.TabIndex = 30;
            this.label11.Text = "0";
            // 
            // irqGraphicDisplay
            // 
            this.irqGraphicDisplay.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.irqGraphicDisplay.Enabled = false;
            this.irqGraphicDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.irqGraphicDisplay.Location = new System.Drawing.Point(260, 60);
            this.irqGraphicDisplay.MaxLength = 1;
            this.irqGraphicDisplay.Name = "irqGraphicDisplay";
            this.irqGraphicDisplay.Size = new System.Drawing.Size(24, 22);
            this.irqGraphicDisplay.TabIndex = 29;
            this.irqGraphicDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.irqGraphicDisplay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsValid);
            // 
            // baseAddrGraphicDisplay
            // 
            this.baseAddrGraphicDisplay.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.baseAddrGraphicDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.baseAddrGraphicDisplay.Location = new System.Drawing.Point(185, 60);
            this.baseAddrGraphicDisplay.MaxLength = 1;
            this.baseAddrGraphicDisplay.Name = "baseAddrGraphicDisplay";
            this.baseAddrGraphicDisplay.Size = new System.Drawing.Size(24, 22);
            this.baseAddrGraphicDisplay.TabIndex = 28;
            this.baseAddrGraphicDisplay.Text = "5";
            this.baseAddrGraphicDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.baseAddrGraphicDisplay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IsValid);
            // 
            // addGraphicDisplayButton
            // 
            this.addGraphicDisplayButton.Location = new System.Drawing.Point(10, 60);
            this.addGraphicDisplayButton.Name = "addGraphicDisplayButton";
            this.addGraphicDisplayButton.Size = new System.Drawing.Size(149, 24);
            this.addGraphicDisplayButton.TabIndex = 27;
            this.addGraphicDisplayButton.Text = "Графический дисплей";
            this.addGraphicDisplayButton.UseVisualStyleBackColor = true;
            this.addGraphicDisplayButton.Click += new System.EventHandler(this.addGraphicDisplayButton_Click);
            // 
            // addLCDDisplayButton
            // 
            this.addLCDDisplayButton.Location = new System.Drawing.Point(10, 240);
            this.addLCDDisplayButton.Name = "addLCDDisplayButton";
            this.addLCDDisplayButton.Size = new System.Drawing.Size(149, 23);
            this.addLCDDisplayButton.TabIndex = 31;
            this.addLCDDisplayButton.Text = "LCD-Display";
            this.addLCDDisplayButton.UseVisualStyleBackColor = true;
            this.addLCDDisplayButton.Click += new System.EventHandler(this.AddLCDDisplayButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(209, 245);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 16);
            this.label4.TabIndex = 34;
            this.label4.Text = "0";
            // 
            // irqLCDDisplay
            // 
            this.irqLCDDisplay.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.irqLCDDisplay.Enabled = false;
            this.irqLCDDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.irqLCDDisplay.Location = new System.Drawing.Point(260, 242);
            this.irqLCDDisplay.MaxLength = 1;
            this.irqLCDDisplay.Name = "irqLCDDisplay";
            this.irqLCDDisplay.Size = new System.Drawing.Size(24, 22);
            this.irqLCDDisplay.TabIndex = 33;
            this.irqLCDDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // baseAddrLCDDisplay
            // 
            this.baseAddrLCDDisplay.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.baseAddrLCDDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.baseAddrLCDDisplay.Location = new System.Drawing.Point(185, 242);
            this.baseAddrLCDDisplay.MaxLength = 1;
            this.baseAddrLCDDisplay.Name = "baseAddrLCDDisplay";
            this.baseAddrLCDDisplay.Size = new System.Drawing.Size(24, 22);
            this.baseAddrLCDDisplay.TabIndex = 32;
            this.baseAddrLCDDisplay.Text = "6";
            this.baseAddrLCDDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DeviceManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 276);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.irqLCDDisplay);
            this.Controls.Add(this.baseAddrLCDDisplay);
            this.Controls.Add(this.addLCDDisplayButton);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.irqGraphicDisplay);
            this.Controls.Add(this.baseAddrGraphicDisplay);
            this.Controls.Add(this.addGraphicDisplayButton);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.irqTimer5);
            this.Controls.Add(this.irqTimer2);
            this.Controls.Add(this.irqOscillograph);
            this.Controls.Add(this.irqKeypadAndIndication);
            this.Controls.Add(this.irqDevice);
            this.Controls.Add(this.baseAddrTimer5);
            this.Controls.Add(this.baseAddrTimer2);
            this.Controls.Add(this.baseAddrOscillograph);
            this.Controls.Add(this.baseAddrKeypadAndIndication);
            this.Controls.Add(this.baseAddrDevice);
            this.Controls.Add(this.irqDisplay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.baseAddrDisplay);
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
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button addDeviceButton;
        private System.Windows.Forms.Button addDisplayButton;
        private System.Windows.Forms.Button addTimer2Button;
        private System.Windows.Forms.Button addTimer5Button;
        private System.Windows.Forms.Button addOscillographButton;
        private System.Windows.Forms.Button addKeypadAndIndicationButton;
        private System.Windows.Forms.TextBox baseAddrDisplay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox irqDisplay;
        private System.Windows.Forms.TextBox baseAddrDevice;
        private System.Windows.Forms.TextBox baseAddrKeypadAndIndication;
        private System.Windows.Forms.TextBox baseAddrOscillograph;
        private System.Windows.Forms.TextBox baseAddrTimer2;
        private System.Windows.Forms.TextBox baseAddrTimer5;
        private System.Windows.Forms.TextBox irqDevice;
        private System.Windows.Forms.TextBox irqKeypadAndIndication;
        private System.Windows.Forms.TextBox irqOscillograph;
        private System.Windows.Forms.TextBox irqTimer2;
        private System.Windows.Forms.TextBox irqTimer5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox irqGraphicDisplay;
        private System.Windows.Forms.TextBox baseAddrGraphicDisplay;
        private System.Windows.Forms.Button addGraphicDisplayButton;
        private System.Windows.Forms.Button addLCDDisplayButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox irqLCDDisplay;
        private System.Windows.Forms.TextBox baseAddrLCDDisplay;
    }
}