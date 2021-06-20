namespace _8bitVonNeiman.ExternalDevices.GraphicDisplay.Videomemory.View
{
    partial class VideomemoryForm
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
            this.VideoMemoryDataGridView = new System.Windows.Forms.DataGridView();
            this.ClearVideoMemory = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.SaveAsButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.VideoMemoryDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // VideoMemoryDataGridView
            // 
            this.VideoMemoryDataGridView.AllowUserToAddRows = false;
            this.VideoMemoryDataGridView.AllowUserToDeleteRows = false;
            this.VideoMemoryDataGridView.AllowUserToResizeColumns = false;
            this.VideoMemoryDataGridView.AllowUserToResizeRows = false;
            this.VideoMemoryDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.VideoMemoryDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.VideoMemoryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.VideoMemoryDataGridView.Location = new System.Drawing.Point(12, 42);
            this.VideoMemoryDataGridView.Name = "VideoMemoryDataGridView";
            this.VideoMemoryDataGridView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.VideoMemoryDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.VideoMemoryDataGridView.Size = new System.Drawing.Size(480, 346);
            this.VideoMemoryDataGridView.TabIndex = 36;
            this.VideoMemoryDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.VideomemoryDataGridView_CellEndEdit);
            // 
            // ClearVideoMemory
            // 
            this.ClearVideoMemory.Location = new System.Drawing.Point(283, 13);
            this.ClearVideoMemory.Name = "ClearVideoMemory";
            this.ClearVideoMemory.Size = new System.Drawing.Size(106, 23);
            this.ClearVideoMemory.TabIndex = 48;
            this.ClearVideoMemory.Text = "Очистить память";
            this.ClearVideoMemory.UseVisualStyleBackColor = true;
            this.ClearVideoMemory.Click += new System.EventHandler(this.ClearVideomemory_Click);
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(202, 13);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(75, 23);
            this.LoadButton.TabIndex = 47;
            this.LoadButton.Text = "Загрузить";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // SaveAsButton
            // 
            this.SaveAsButton.Location = new System.Drawing.Point(93, 12);
            this.SaveAsButton.Name = "SaveAsButton";
            this.SaveAsButton.Size = new System.Drawing.Size(103, 23);
            this.SaveAsButton.TabIndex = 46;
            this.SaveAsButton.Text = "Сохранить как";
            this.SaveAsButton.UseVisualStyleBackColor = true;
            this.SaveAsButton.Click += new System.EventHandler(this.SaveAsButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(12, 12);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 45;
            this.SaveButton.Text = "Сохранить";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // VideomemoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 389);
            this.Controls.Add(this.ClearVideoMemory);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.SaveAsButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.VideoMemoryDataGridView);
            this.Name = "VideomemoryForm";
            this.Text = "Видеопамять";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.VideomemoryForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.VideoMemoryDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView VideoMemoryDataGridView;
        private System.Windows.Forms.Button ClearVideoMemory;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.Button SaveAsButton;
        private System.Windows.Forms.Button SaveButton;
    }
}