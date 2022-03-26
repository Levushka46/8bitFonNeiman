namespace _8bitVonNeiman.ExternalDevices.LCDDisplay.View
{
    partial class LCDDisplaySettingsForm
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
            this.bgColorPanel = new System.Windows.Forms.Panel();
            this.bgColorPreviewPanel = new System.Windows.Forms.Panel();
            this.bgColorBTextBox = new System.Windows.Forms.TextBox();
            this.bgColorBLabel = new System.Windows.Forms.Label();
            this.bgColorGTextBox = new System.Windows.Forms.TextBox();
            this.bgColorGLabel = new System.Windows.Forms.Label();
            this.bgColorRTextBox = new System.Windows.Forms.TextBox();
            this.bgColorRLabel = new System.Windows.Forms.Label();
            this.bgColorATextBox = new System.Windows.Forms.TextBox();
            this.bgColorALabel = new System.Windows.Forms.Label();
            this.bgColorLabel = new System.Windows.Forms.Label();
            this.applyButton = new System.Windows.Forms.Button();
            this.restoreDefaultsButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.symbolColorPreviewPanel = new System.Windows.Forms.Panel();
            this.symbolColorBTextBox = new System.Windows.Forms.TextBox();
            this.symbolColorBLabel = new System.Windows.Forms.Label();
            this.symbolColorGTextBox = new System.Windows.Forms.TextBox();
            this.symbolColorGLabel = new System.Windows.Forms.Label();
            this.symbolColorRTextBox = new System.Windows.Forms.TextBox();
            this.symbolColorRLabel = new System.Windows.Forms.Label();
            this.symbolColorATextBox = new System.Windows.Forms.TextBox();
            this.symbolColorALabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.bgColorPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bgColorPanel
            // 
            this.bgColorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bgColorPanel.Controls.Add(this.bgColorPreviewPanel);
            this.bgColorPanel.Controls.Add(this.bgColorBTextBox);
            this.bgColorPanel.Controls.Add(this.bgColorBLabel);
            this.bgColorPanel.Controls.Add(this.bgColorGTextBox);
            this.bgColorPanel.Controls.Add(this.bgColorGLabel);
            this.bgColorPanel.Controls.Add(this.bgColorRTextBox);
            this.bgColorPanel.Controls.Add(this.bgColorRLabel);
            this.bgColorPanel.Controls.Add(this.bgColorATextBox);
            this.bgColorPanel.Controls.Add(this.bgColorALabel);
            this.bgColorPanel.Controls.Add(this.bgColorLabel);
            this.bgColorPanel.Location = new System.Drawing.Point(40, 12);
            this.bgColorPanel.Name = "bgColorPanel";
            this.bgColorPanel.Size = new System.Drawing.Size(162, 87);
            this.bgColorPanel.TabIndex = 0;
            // 
            // bgColorPreviewPanel
            // 
            this.bgColorPreviewPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bgColorPreviewPanel.Location = new System.Drawing.Point(120, 52);
            this.bgColorPreviewPanel.Name = "bgColorPreviewPanel";
            this.bgColorPreviewPanel.Size = new System.Drawing.Size(20, 20);
            this.bgColorPreviewPanel.TabIndex = 9;
            // 
            // bgColorBTextBox
            // 
            this.bgColorBTextBox.Location = new System.Drawing.Point(94, 52);
            this.bgColorBTextBox.MaxLength = 2;
            this.bgColorBTextBox.Name = "bgColorBTextBox";
            this.bgColorBTextBox.Size = new System.Drawing.Size(20, 20);
            this.bgColorBTextBox.TabIndex = 8;
            this.bgColorBTextBox.Text = "FF";
            this.bgColorBTextBox.TextChanged += new System.EventHandler(this.bgColorTextBox_TextChanged);
            // 
            // bgColorBLabel
            // 
            this.bgColorBLabel.AutoSize = true;
            this.bgColorBLabel.Location = new System.Drawing.Point(97, 36);
            this.bgColorBLabel.Name = "bgColorBLabel";
            this.bgColorBLabel.Size = new System.Drawing.Size(14, 13);
            this.bgColorBLabel.TabIndex = 7;
            this.bgColorBLabel.Text = "B";
            // 
            // bgColorGTextBox
            // 
            this.bgColorGTextBox.Location = new System.Drawing.Point(68, 52);
            this.bgColorGTextBox.MaxLength = 2;
            this.bgColorGTextBox.Name = "bgColorGTextBox";
            this.bgColorGTextBox.Size = new System.Drawing.Size(20, 20);
            this.bgColorGTextBox.TabIndex = 6;
            this.bgColorGTextBox.Text = "FF";
            this.bgColorGTextBox.TextChanged += new System.EventHandler(this.bgColorTextBox_TextChanged);
            // 
            // bgColorGLabel
            // 
            this.bgColorGLabel.AutoSize = true;
            this.bgColorGLabel.Location = new System.Drawing.Point(71, 36);
            this.bgColorGLabel.Name = "bgColorGLabel";
            this.bgColorGLabel.Size = new System.Drawing.Size(15, 13);
            this.bgColorGLabel.TabIndex = 5;
            this.bgColorGLabel.Text = "G";
            // 
            // bgColorRTextBox
            // 
            this.bgColorRTextBox.Location = new System.Drawing.Point(42, 52);
            this.bgColorRTextBox.MaxLength = 2;
            this.bgColorRTextBox.Name = "bgColorRTextBox";
            this.bgColorRTextBox.Size = new System.Drawing.Size(20, 20);
            this.bgColorRTextBox.TabIndex = 4;
            this.bgColorRTextBox.Text = "FF";
            this.bgColorRTextBox.TextChanged += new System.EventHandler(this.bgColorTextBox_TextChanged);
            // 
            // bgColorRLabel
            // 
            this.bgColorRLabel.AutoSize = true;
            this.bgColorRLabel.Location = new System.Drawing.Point(45, 36);
            this.bgColorRLabel.Name = "bgColorRLabel";
            this.bgColorRLabel.Size = new System.Drawing.Size(15, 13);
            this.bgColorRLabel.TabIndex = 3;
            this.bgColorRLabel.Text = "R";
            // 
            // bgColorATextBox
            // 
            this.bgColorATextBox.Location = new System.Drawing.Point(16, 52);
            this.bgColorATextBox.MaxLength = 2;
            this.bgColorATextBox.Name = "bgColorATextBox";
            this.bgColorATextBox.Size = new System.Drawing.Size(20, 20);
            this.bgColorATextBox.TabIndex = 2;
            this.bgColorATextBox.Text = "FF";
            this.bgColorATextBox.TextChanged += new System.EventHandler(this.bgColorTextBox_TextChanged);
            // 
            // bgColorALabel
            // 
            this.bgColorALabel.AutoSize = true;
            this.bgColorALabel.Location = new System.Drawing.Point(19, 36);
            this.bgColorALabel.Name = "bgColorALabel";
            this.bgColorALabel.Size = new System.Drawing.Size(14, 13);
            this.bgColorALabel.TabIndex = 1;
            this.bgColorALabel.Text = "A";
            // 
            // bgColorLabel
            // 
            this.bgColorLabel.AutoSize = true;
            this.bgColorLabel.Location = new System.Drawing.Point(49, 7);
            this.bgColorLabel.Name = "bgColorLabel";
            this.bgColorLabel.Size = new System.Drawing.Size(61, 13);
            this.bgColorLabel.TabIndex = 0;
            this.bgColorLabel.Text = "Цвет фона";
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(83, 198);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 1;
            this.applyButton.Text = "Применить";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // restoreDefaultsButton
            // 
            this.restoreDefaultsButton.Location = new System.Drawing.Point(12, 227);
            this.restoreDefaultsButton.Name = "restoreDefaultsButton";
            this.restoreDefaultsButton.Size = new System.Drawing.Size(220, 23);
            this.restoreDefaultsButton.TabIndex = 2;
            this.restoreDefaultsButton.Text = "Восстановить параметры по умолчанию";
            this.restoreDefaultsButton.UseVisualStyleBackColor = true;
            this.restoreDefaultsButton.Click += new System.EventHandler(this.restoreDefaultsButton_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.symbolColorPreviewPanel);
            this.panel1.Controls.Add(this.symbolColorBTextBox);
            this.panel1.Controls.Add(this.symbolColorBLabel);
            this.panel1.Controls.Add(this.symbolColorGTextBox);
            this.panel1.Controls.Add(this.symbolColorGLabel);
            this.panel1.Controls.Add(this.symbolColorRTextBox);
            this.panel1.Controls.Add(this.symbolColorRLabel);
            this.panel1.Controls.Add(this.symbolColorATextBox);
            this.panel1.Controls.Add(this.symbolColorALabel);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(40, 105);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(162, 87);
            this.panel1.TabIndex = 10;
            // 
            // symbolColorPreviewPanel
            // 
            this.symbolColorPreviewPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.symbolColorPreviewPanel.Location = new System.Drawing.Point(120, 52);
            this.symbolColorPreviewPanel.Name = "symbolColorPreviewPanel";
            this.symbolColorPreviewPanel.Size = new System.Drawing.Size(20, 20);
            this.symbolColorPreviewPanel.TabIndex = 9;
            // 
            // symbolColorBTextBox
            // 
            this.symbolColorBTextBox.Location = new System.Drawing.Point(94, 52);
            this.symbolColorBTextBox.MaxLength = 2;
            this.symbolColorBTextBox.Name = "symbolColorBTextBox";
            this.symbolColorBTextBox.Size = new System.Drawing.Size(20, 20);
            this.symbolColorBTextBox.TabIndex = 8;
            this.symbolColorBTextBox.Text = "FF";
            this.symbolColorBTextBox.TextChanged += new System.EventHandler(this.symbolColorTextBox_TextChanged);
            // 
            // symbolColorBLabel
            // 
            this.symbolColorBLabel.AutoSize = true;
            this.symbolColorBLabel.Location = new System.Drawing.Point(97, 36);
            this.symbolColorBLabel.Name = "symbolColorBLabel";
            this.symbolColorBLabel.Size = new System.Drawing.Size(14, 13);
            this.symbolColorBLabel.TabIndex = 7;
            this.symbolColorBLabel.Text = "B";
            // 
            // symbolColorGTextBox
            // 
            this.symbolColorGTextBox.Location = new System.Drawing.Point(68, 52);
            this.symbolColorGTextBox.MaxLength = 2;
            this.symbolColorGTextBox.Name = "symbolColorGTextBox";
            this.symbolColorGTextBox.Size = new System.Drawing.Size(20, 20);
            this.symbolColorGTextBox.TabIndex = 6;
            this.symbolColorGTextBox.Text = "FF";
            this.symbolColorGTextBox.TextChanged += new System.EventHandler(this.symbolColorTextBox_TextChanged);
            // 
            // symbolColorGLabel
            // 
            this.symbolColorGLabel.AutoSize = true;
            this.symbolColorGLabel.Location = new System.Drawing.Point(71, 36);
            this.symbolColorGLabel.Name = "symbolColorGLabel";
            this.symbolColorGLabel.Size = new System.Drawing.Size(15, 13);
            this.symbolColorGLabel.TabIndex = 5;
            this.symbolColorGLabel.Text = "G";
            // 
            // symbolColorRTextBox
            // 
            this.symbolColorRTextBox.Location = new System.Drawing.Point(42, 52);
            this.symbolColorRTextBox.MaxLength = 2;
            this.symbolColorRTextBox.Name = "symbolColorRTextBox";
            this.symbolColorRTextBox.Size = new System.Drawing.Size(20, 20);
            this.symbolColorRTextBox.TabIndex = 4;
            this.symbolColorRTextBox.Text = "FF";
            this.symbolColorRTextBox.TextChanged += new System.EventHandler(this.symbolColorTextBox_TextChanged);
            // 
            // symbolColorRLabel
            // 
            this.symbolColorRLabel.AutoSize = true;
            this.symbolColorRLabel.Location = new System.Drawing.Point(45, 36);
            this.symbolColorRLabel.Name = "symbolColorRLabel";
            this.symbolColorRLabel.Size = new System.Drawing.Size(15, 13);
            this.symbolColorRLabel.TabIndex = 3;
            this.symbolColorRLabel.Text = "R";
            // 
            // symbolColorATextBox
            // 
            this.symbolColorATextBox.Location = new System.Drawing.Point(16, 52);
            this.symbolColorATextBox.MaxLength = 2;
            this.symbolColorATextBox.Name = "symbolColorATextBox";
            this.symbolColorATextBox.Size = new System.Drawing.Size(20, 20);
            this.symbolColorATextBox.TabIndex = 2;
            this.symbolColorATextBox.Text = "FF";
            this.symbolColorATextBox.TextChanged += new System.EventHandler(this.symbolColorTextBox_TextChanged);
            // 
            // symbolColorALabel
            // 
            this.symbolColorALabel.AutoSize = true;
            this.symbolColorALabel.Location = new System.Drawing.Point(19, 36);
            this.symbolColorALabel.Name = "symbolColorALabel";
            this.symbolColorALabel.Size = new System.Drawing.Size(14, 13);
            this.symbolColorALabel.TabIndex = 1;
            this.symbolColorALabel.Text = "A";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Цвет символа";
            // 
            // LCDDisplaySettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 261);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.restoreDefaultsButton);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.bgColorPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LCDDisplaySettingsForm";
            this.Text = "Настройки";
            this.bgColorPanel.ResumeLayout(false);
            this.bgColorPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel bgColorPanel;
        private System.Windows.Forms.Panel bgColorPreviewPanel;
        private System.Windows.Forms.TextBox bgColorBTextBox;
        private System.Windows.Forms.Label bgColorBLabel;
        private System.Windows.Forms.TextBox bgColorGTextBox;
        private System.Windows.Forms.Label bgColorGLabel;
        private System.Windows.Forms.TextBox bgColorRTextBox;
        private System.Windows.Forms.Label bgColorRLabel;
        private System.Windows.Forms.TextBox bgColorATextBox;
        private System.Windows.Forms.Label bgColorALabel;
        private System.Windows.Forms.Label bgColorLabel;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Button restoreDefaultsButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel symbolColorPreviewPanel;
        private System.Windows.Forms.TextBox symbolColorBTextBox;
        private System.Windows.Forms.Label symbolColorBLabel;
        private System.Windows.Forms.TextBox symbolColorGTextBox;
        private System.Windows.Forms.Label symbolColorGLabel;
        private System.Windows.Forms.TextBox symbolColorRTextBox;
        private System.Windows.Forms.Label symbolColorRLabel;
        private System.Windows.Forms.TextBox symbolColorATextBox;
        private System.Windows.Forms.Label symbolColorALabel;
        private System.Windows.Forms.Label label5;
    }
}