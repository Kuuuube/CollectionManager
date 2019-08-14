namespace GuiComponents.Forms
{
    partial class BeatmapExportForm
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.cancelButton = new System.Windows.Forms.Button();
            this.metadataStatusLabel = new System.Windows.Forms.Label();
            this.copyStatusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 46);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(407, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(178, 72);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // metadataStatusLabel
            // 
            this.metadataStatusLabel.AutoSize = true;
            this.metadataStatusLabel.Location = new System.Drawing.Point(12, 9);
            this.metadataStatusLabel.Name = "metadataStatusLabel";
            this.metadataStatusLabel.Size = new System.Drawing.Size(108, 13);
            this.metadataStatusLabel.TabIndex = 2;
            this.metadataStatusLabel.Text = "Metadata status label";
            // 
            // copyStatusLabel
            // 
            this.copyStatusLabel.AutoSize = true;
            this.copyStatusLabel.Location = new System.Drawing.Point(12, 27);
            this.copyStatusLabel.Name = "copyStatusLabel";
            this.copyStatusLabel.Size = new System.Drawing.Size(86, 13);
            this.copyStatusLabel.TabIndex = 3;
            this.copyStatusLabel.Text = "copy status label";
            // 
            // BeatmapExportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 106);
            this.Controls.Add(this.copyStatusLabel);
            this.Controls.Add(this.metadataStatusLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.progressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "BeatmapExportForm";
            this.Text = "Collection Manager - Beatmap Export";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label metadataStatusLabel;
        private System.Windows.Forms.Label copyStatusLabel;
    }
}