namespace _8bitVonNeiman.ExternalDevices.LCDDisplay.View
{
    partial class LCDDisplayMemoryForm
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
            this.memoryDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.memoryDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // memoryDataGridView
            // 
            this.memoryDataGridView.AllowUserToAddRows = false;
            this.memoryDataGridView.AllowUserToDeleteRows = false;
            this.memoryDataGridView.AllowUserToResizeColumns = false;
            this.memoryDataGridView.AllowUserToResizeRows = false;
            this.memoryDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.memoryDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.memoryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.memoryDataGridView.Location = new System.Drawing.Point(12, 12);
            this.memoryDataGridView.Name = "memoryDataGridView";
            this.memoryDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.memoryDataGridView.Size = new System.Drawing.Size(486, 47);
            this.memoryDataGridView.TabIndex = 2;
            this.memoryDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.MemoryDataGridView_CellEndEdit);
            // 
            // LCDDisplayMemoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 71);
            this.Controls.Add(this.memoryDataGridView);
            this.Name = "LCDDisplayMemoryForm";
            this.Text = "LCDDisplayMemoryForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LCDDisplayMemoryForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.memoryDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView memoryDataGridView;
    }
}