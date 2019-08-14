using System.Threading;

namespace GuiComponents.Interfaces
{
    public interface IBeatmapExportForm : IForm
    {
        int TotalFiles { get; set; }
        int ProcessedFiles { get; set; }
        string MetadataStatus { get; set; }
        string CopyStatus { get; set; }
        void Show(CancellationTokenSource token);
    }
}