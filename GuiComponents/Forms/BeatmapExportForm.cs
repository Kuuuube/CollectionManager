using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GuiComponents.Interfaces;

namespace GuiComponents.Forms
{
    public partial class BeatmapExportForm : BaseForm, IBeatmapExportForm
    {
        private int _processedFiles;
        private string _currentFile;
        private CancellationTokenSource _token;
        private string _metadataStatus;
        private string _copyStatus;

        public BeatmapExportForm()
        {
            InitializeComponent();
        }


        public int TotalFiles { get; set; }

        public int ProcessedFiles
        {
            get => _processedFiles;
            set
            {
                _processedFiles = value;
                UpdateProgress();
            }
        }

        public string MetadataStatus
        {
            get => _metadataStatus;
            set
            {
                _metadataStatus = value;
                try
                {
                    this.BeginInvoke((MethodInvoker) (() => { this.metadataStatusLabel.Text = value; }));
                }
                catch (InvalidOperationException) { }
            }
        }

        public string CopyStatus
        {
            get => _copyStatus;
            set
            {
                _copyStatus = value;
                try
                {
                    this.BeginInvoke((MethodInvoker) (() => { this.copyStatusLabel.Text = value; }));
                }
                catch (InvalidOperationException) { }
            }
        }

        private void UpdateProgress()
        {
            try
            {
                this.BeginInvoke((MethodInvoker) (() =>
                {
                    progressBar1.Value = (int) (((double) ProcessedFiles / (double) TotalFiles) * 100);
                }));
            }
            catch (InvalidOperationException) { }
        }

        public void Show(CancellationTokenSource token)
        {
            _token = token;
            Show();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            _token.Cancel();
            this.Close();
        }
    }
}
