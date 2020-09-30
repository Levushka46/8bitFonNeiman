namespace _8bitVonNeiman.ExternalDevices.KeypadAndIndication.View
{
    partial class KeypadAndIndicationForm
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
            this.sevenSegment1 = new DmitryBrant.CustomControls.SevenSegment();
            this.button1 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sevenSegment2 = new DmitryBrant.CustomControls.SevenSegment();
            this.sevenSegment3 = new DmitryBrant.CustomControls.SevenSegment();
            this.sevenSegment4 = new DmitryBrant.CustomControls.SevenSegment();
            this.sevenSegment5 = new DmitryBrant.CustomControls.SevenSegment();
            this.sevenSegment6 = new DmitryBrant.CustomControls.SevenSegment();
            this.sevenSegment7 = new DmitryBrant.CustomControls.SevenSegment();
            this.sevenSegment8 = new DmitryBrant.CustomControls.SevenSegment();
            this.panel1 = new System.Windows.Forms.Panel();
            this.interruptionVectorLabel = new System.Windows.Forms.Label();
            this.baseAddressLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.resetButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.crBinTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.symBinTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.addrBinTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.srBinTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.videoMemBinTextBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sevenSegment1
            // 
            this.sevenSegment1.ColonOn = false;
            this.sevenSegment1.ColonShow = false;
            this.sevenSegment1.ColorBackground = System.Drawing.Color.DarkGray;
            this.sevenSegment1.ColorDark = System.Drawing.Color.DimGray;
            this.sevenSegment1.ColorLight = System.Drawing.Color.Red;
            this.sevenSegment1.CustomPattern = 0;
            this.sevenSegment1.DecimalOn = false;
            this.sevenSegment1.DecimalShow = true;
            this.sevenSegment1.ElementWidth = 10;
            this.sevenSegment1.ItalicFactor = -0.1F;
            this.sevenSegment1.Location = new System.Drawing.Point(12, 46);
            this.sevenSegment1.Name = "sevenSegment1";
            this.sevenSegment1.Padding = new System.Windows.Forms.Padding(8, 4, 4, 4);
            this.sevenSegment1.Size = new System.Drawing.Size(50, 74);
            this.sevenSegment1.TabIndex = 6;
            this.sevenSegment1.TabStop = false;
            this.sevenSegment1.Value = null;
            this.sevenSegment1.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 126);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(93, 126);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 22);
            this.numericUpDown1.TabIndex = 12;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(468, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.settingToolStripMenuItem.Text = "Настройки";
            this.settingToolStripMenuItem.Click += new System.EventHandler(this.settingToolStripMenuItem_Click);
            // 
            // sevenSegment2
            // 
            this.sevenSegment2.ColonOn = false;
            this.sevenSegment2.ColonShow = false;
            this.sevenSegment2.ColorBackground = System.Drawing.Color.DarkGray;
            this.sevenSegment2.ColorDark = System.Drawing.Color.DimGray;
            this.sevenSegment2.ColorLight = System.Drawing.Color.Red;
            this.sevenSegment2.CustomPattern = 0;
            this.sevenSegment2.DecimalOn = false;
            this.sevenSegment2.DecimalShow = true;
            this.sevenSegment2.ElementWidth = 10;
            this.sevenSegment2.ItalicFactor = -0.1F;
            this.sevenSegment2.Location = new System.Drawing.Point(68, 46);
            this.sevenSegment2.Name = "sevenSegment2";
            this.sevenSegment2.Padding = new System.Windows.Forms.Padding(8, 4, 4, 4);
            this.sevenSegment2.Size = new System.Drawing.Size(50, 74);
            this.sevenSegment2.TabIndex = 14;
            this.sevenSegment2.TabStop = false;
            this.sevenSegment2.Value = null;
            this.sevenSegment2.Visible = false;
            // 
            // sevenSegment3
            // 
            this.sevenSegment3.ColonOn = false;
            this.sevenSegment3.ColonShow = false;
            this.sevenSegment3.ColorBackground = System.Drawing.Color.DarkGray;
            this.sevenSegment3.ColorDark = System.Drawing.Color.DimGray;
            this.sevenSegment3.ColorLight = System.Drawing.Color.Red;
            this.sevenSegment3.CustomPattern = 0;
            this.sevenSegment3.DecimalOn = false;
            this.sevenSegment3.DecimalShow = true;
            this.sevenSegment3.ElementWidth = 10;
            this.sevenSegment3.ItalicFactor = -0.1F;
            this.sevenSegment3.Location = new System.Drawing.Point(124, 46);
            this.sevenSegment3.Name = "sevenSegment3";
            this.sevenSegment3.Padding = new System.Windows.Forms.Padding(8, 4, 4, 4);
            this.sevenSegment3.Size = new System.Drawing.Size(50, 74);
            this.sevenSegment3.TabIndex = 15;
            this.sevenSegment3.TabStop = false;
            this.sevenSegment3.Value = null;
            this.sevenSegment3.Visible = false;
            // 
            // sevenSegment4
            // 
            this.sevenSegment4.ColonOn = false;
            this.sevenSegment4.ColonShow = false;
            this.sevenSegment4.ColorBackground = System.Drawing.Color.DarkGray;
            this.sevenSegment4.ColorDark = System.Drawing.Color.DimGray;
            this.sevenSegment4.ColorLight = System.Drawing.Color.Red;
            this.sevenSegment4.CustomPattern = 0;
            this.sevenSegment4.DecimalOn = false;
            this.sevenSegment4.DecimalShow = true;
            this.sevenSegment4.ElementWidth = 10;
            this.sevenSegment4.ItalicFactor = -0.1F;
            this.sevenSegment4.Location = new System.Drawing.Point(180, 46);
            this.sevenSegment4.Name = "sevenSegment4";
            this.sevenSegment4.Padding = new System.Windows.Forms.Padding(8, 4, 4, 4);
            this.sevenSegment4.Size = new System.Drawing.Size(50, 74);
            this.sevenSegment4.TabIndex = 16;
            this.sevenSegment4.TabStop = false;
            this.sevenSegment4.Value = null;
            this.sevenSegment4.Visible = false;
            // 
            // sevenSegment5
            // 
            this.sevenSegment5.ColonOn = false;
            this.sevenSegment5.ColonShow = false;
            this.sevenSegment5.ColorBackground = System.Drawing.Color.DarkGray;
            this.sevenSegment5.ColorDark = System.Drawing.Color.DimGray;
            this.sevenSegment5.ColorLight = System.Drawing.Color.Red;
            this.sevenSegment5.CustomPattern = 0;
            this.sevenSegment5.DecimalOn = false;
            this.sevenSegment5.DecimalShow = true;
            this.sevenSegment5.ElementWidth = 10;
            this.sevenSegment5.ItalicFactor = -0.1F;
            this.sevenSegment5.Location = new System.Drawing.Point(236, 46);
            this.sevenSegment5.Name = "sevenSegment5";
            this.sevenSegment5.Padding = new System.Windows.Forms.Padding(8, 4, 4, 4);
            this.sevenSegment5.Size = new System.Drawing.Size(50, 74);
            this.sevenSegment5.TabIndex = 17;
            this.sevenSegment5.TabStop = false;
            this.sevenSegment5.Value = null;
            this.sevenSegment5.Visible = false;
            // 
            // sevenSegment6
            // 
            this.sevenSegment6.ColonOn = false;
            this.sevenSegment6.ColonShow = false;
            this.sevenSegment6.ColorBackground = System.Drawing.Color.DarkGray;
            this.sevenSegment6.ColorDark = System.Drawing.Color.DimGray;
            this.sevenSegment6.ColorLight = System.Drawing.Color.Red;
            this.sevenSegment6.CustomPattern = 0;
            this.sevenSegment6.DecimalOn = false;
            this.sevenSegment6.DecimalShow = true;
            this.sevenSegment6.ElementWidth = 10;
            this.sevenSegment6.ItalicFactor = -0.1F;
            this.sevenSegment6.Location = new System.Drawing.Point(292, 46);
            this.sevenSegment6.Name = "sevenSegment6";
            this.sevenSegment6.Padding = new System.Windows.Forms.Padding(8, 4, 4, 4);
            this.sevenSegment6.Size = new System.Drawing.Size(50, 74);
            this.sevenSegment6.TabIndex = 18;
            this.sevenSegment6.TabStop = false;
            this.sevenSegment6.Value = null;
            this.sevenSegment6.Visible = false;
            // 
            // sevenSegment7
            // 
            this.sevenSegment7.ColonOn = false;
            this.sevenSegment7.ColonShow = false;
            this.sevenSegment7.ColorBackground = System.Drawing.Color.DarkGray;
            this.sevenSegment7.ColorDark = System.Drawing.Color.DimGray;
            this.sevenSegment7.ColorLight = System.Drawing.Color.Red;
            this.sevenSegment7.CustomPattern = 0;
            this.sevenSegment7.DecimalOn = false;
            this.sevenSegment7.DecimalShow = true;
            this.sevenSegment7.ElementWidth = 10;
            this.sevenSegment7.ItalicFactor = -0.1F;
            this.sevenSegment7.Location = new System.Drawing.Point(348, 46);
            this.sevenSegment7.Name = "sevenSegment7";
            this.sevenSegment7.Padding = new System.Windows.Forms.Padding(8, 4, 4, 4);
            this.sevenSegment7.Size = new System.Drawing.Size(50, 74);
            this.sevenSegment7.TabIndex = 19;
            this.sevenSegment7.TabStop = false;
            this.sevenSegment7.Value = null;
            this.sevenSegment7.Visible = false;
            // 
            // sevenSegment8
            // 
            this.sevenSegment8.ColonOn = false;
            this.sevenSegment8.ColonShow = false;
            this.sevenSegment8.ColorBackground = System.Drawing.Color.DarkGray;
            this.sevenSegment8.ColorDark = System.Drawing.Color.DimGray;
            this.sevenSegment8.ColorLight = System.Drawing.Color.Red;
            this.sevenSegment8.CustomPattern = 0;
            this.sevenSegment8.DecimalOn = false;
            this.sevenSegment8.DecimalShow = true;
            this.sevenSegment8.ElementWidth = 10;
            this.sevenSegment8.ItalicFactor = -0.1F;
            this.sevenSegment8.Location = new System.Drawing.Point(404, 46);
            this.sevenSegment8.Name = "sevenSegment8";
            this.sevenSegment8.Padding = new System.Windows.Forms.Padding(8, 4, 4, 4);
            this.sevenSegment8.Size = new System.Drawing.Size(50, 74);
            this.sevenSegment8.TabIndex = 20;
            this.sevenSegment8.TabStop = false;
            this.sevenSegment8.Value = null;
            this.sevenSegment8.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.interruptionVectorLabel);
            this.panel1.Controls.Add(this.baseAddressLabel);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(173, 268);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(191, 69);
            this.panel1.TabIndex = 41;
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Вектор прерывания";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Базовый адрес";
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(289, 352);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 40;
            this.resetButton.Text = "Сброс";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(141, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 20);
            this.label4.TabIndex = 39;
            this.label4.Text = "CR";
            // 
            // crBinTextBox
            // 
            this.crBinTextBox.BackColor = System.Drawing.Color.White;
            this.crBinTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.crBinTextBox.Location = new System.Drawing.Point(42, 233);
            this.crBinTextBox.Name = "crBinTextBox";
            this.crBinTextBox.ReadOnly = true;
            this.crBinTextBox.Size = new System.Drawing.Size(93, 26);
            this.crBinTextBox.TabIndex = 38;
            this.crBinTextBox.TabStop = false;
            this.crBinTextBox.Text = "0000 0000";
            this.crBinTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(18, 236);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 20);
            this.label5.TabIndex = 37;
            this.label5.Text = "2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(332, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 20);
            this.label1.TabIndex = 36;
            this.label1.Text = "Sym";
            // 
            // symBinTextBox
            // 
            this.symBinTextBox.BackColor = System.Drawing.Color.White;
            this.symBinTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.symBinTextBox.Location = new System.Drawing.Point(233, 201);
            this.symBinTextBox.Name = "symBinTextBox";
            this.symBinTextBox.ReadOnly = true;
            this.symBinTextBox.Size = new System.Drawing.Size(93, 26);
            this.symBinTextBox.TabIndex = 35;
            this.symBinTextBox.TabStop = false;
            this.symBinTextBox.Text = "0000 0000";
            this.symBinTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(209, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 20);
            this.label3.TabIndex = 34;
            this.label3.Text = "1";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(141, 204);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 20);
            this.label10.TabIndex = 33;
            this.label10.Text = "Addr";
            // 
            // addrBinTextBox
            // 
            this.addrBinTextBox.BackColor = System.Drawing.Color.White;
            this.addrBinTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addrBinTextBox.Location = new System.Drawing.Point(42, 201);
            this.addrBinTextBox.Name = "addrBinTextBox";
            this.addrBinTextBox.ReadOnly = true;
            this.addrBinTextBox.Size = new System.Drawing.Size(93, 26);
            this.addrBinTextBox.TabIndex = 32;
            this.addrBinTextBox.TabStop = false;
            this.addrBinTextBox.Text = "0000 0000";
            this.addrBinTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(18, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 20);
            this.label2.TabIndex = 31;
            this.label2.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(332, 236);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 20);
            this.label6.TabIndex = 45;
            this.label6.Text = "SR";
            // 
            // srBinTextBox
            // 
            this.srBinTextBox.BackColor = System.Drawing.Color.White;
            this.srBinTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.srBinTextBox.Location = new System.Drawing.Point(233, 233);
            this.srBinTextBox.Name = "srBinTextBox";
            this.srBinTextBox.ReadOnly = true;
            this.srBinTextBox.Size = new System.Drawing.Size(93, 26);
            this.srBinTextBox.TabIndex = 44;
            this.srBinTextBox.TabStop = false;
            this.srBinTextBox.Text = "0000 0000";
            this.srBinTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(209, 236);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(18, 20);
            this.label9.TabIndex = 43;
            this.label9.Text = "3";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(18, 268);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(18, 20);
            this.label11.TabIndex = 46;
            this.label11.Text = "4";
            // 
            // videoMemBinTextBox
            // 
            this.videoMemBinTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.videoMemBinTextBox.Location = new System.Drawing.Point(42, 270);
            this.videoMemBinTextBox.Name = "videoMemBinTextBox";
            this.videoMemBinTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.videoMemBinTextBox.Size = new System.Drawing.Size(93, 168);
            this.videoMemBinTextBox.TabIndex = 47;
            this.videoMemBinTextBox.Text = "0000 0000\n0000 0000\n0000 0000\n0000 0000\n0000 0000\n0000 0000\n0000 0000\n0000 0000";
            // 
            // KeypadAndIndicationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 450);
            this.Controls.Add(this.videoMemBinTextBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.srBinTextBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.crBinTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.symBinTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.addrBinTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sevenSegment8);
            this.Controls.Add(this.sevenSegment7);
            this.Controls.Add(this.sevenSegment6);
            this.Controls.Add(this.sevenSegment5);
            this.Controls.Add(this.sevenSegment4);
            this.Controls.Add(this.sevenSegment3);
            this.Controls.Add(this.sevenSegment2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.sevenSegment1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "KeypadAndIndicationForm";
            this.Text = "Семисегментный индикатор";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DmitryBrant.CustomControls.SevenSegment sevenSegment1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private DmitryBrant.CustomControls.SevenSegment sevenSegment2;
        private DmitryBrant.CustomControls.SevenSegment sevenSegment3;
        private DmitryBrant.CustomControls.SevenSegment sevenSegment4;
        private DmitryBrant.CustomControls.SevenSegment sevenSegment5;
        private DmitryBrant.CustomControls.SevenSegment sevenSegment6;
        private DmitryBrant.CustomControls.SevenSegment sevenSegment7;
        private DmitryBrant.CustomControls.SevenSegment sevenSegment8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label interruptionVectorLabel;
        private System.Windows.Forms.Label baseAddressLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox crBinTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox symBinTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox addrBinTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox srBinTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RichTextBox videoMemBinTextBox;
    }
}