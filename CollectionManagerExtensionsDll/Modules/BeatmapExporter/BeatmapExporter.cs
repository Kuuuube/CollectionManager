using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CollectionManager.DataTypes;
using CollectionManagerExtensionsDll.Modules.CollectionListGenerator.ListTypes;
using CollectionManagerExtensionsDll.Utils;

namespace CollectionManagerExtensionsDll.Modules.BeatmapExporter
{
    //TODO: optional copying of storyboards and video
    public class BeatmapExporter
    {
        public delegate void UpdateExportMetadataStatus(string status, int preparedFiles);
        public delegate void UpdateExportCopyStatus(string status, int processedFiles);
        
        public Task ExportBeatmaps(IEnumerable<Beatmap> beatmaps, string destinationDirectory, UpdateExportMetadataStatus metadataStatusUpdater, UpdateExportCopyStatus copyStatusUpdater, CancellationToken token)
        {
            if (string.IsNullOrEmpty(destinationDirectory))
            {
                throw new ArgumentException($"{nameof(destinationDirectory)} can't be empty");
            }

            return Task.Run(() =>
            {
                var fileQueue = new ConcurrentQueue<string>();
                var stopFileCopyWorker = new AutoResetEvent(false);

                Task.Run(() => GetFilesToCopy(beatmaps.ToList(), metadataStatusUpdater, fileQueue, stopFileCopyWorker, token), token);

                if (!Directory.Exists(destinationDirectory))
                {
                    Directory.CreateDirectory(destinationDirectory);
                }

                var songsDirectory = BeatmapUtils.OsuSongsDirectory;

                DoCopy(fileQueue, songsDirectory, destinationDirectory, copyStatusUpdater, stopFileCopyWorker, token);
            }, token);
        }

        protected void DoCopy(ConcurrentQueue<string> filesQueue, string songsDirectory, string destinationDirectory,
            UpdateExportCopyStatus statusUpdater, AutoResetEvent stopFileCopyWorker, CancellationToken token)
        {
            var processedCount = 0;

            while (true)
            {
                if (filesQueue.TryDequeue(out var fileLocation))
                {
                    if (string.IsNullOrWhiteSpace(fileLocation))
                    {
                        continue;
                    }

                    var relativeDirectory = Path.GetDirectoryName(fileLocation)?.Replace(songsDirectory, "") ?? string.Empty;
                    var fileName = Path.GetFileName(fileLocation);

                    if (!string.IsNullOrEmpty(relativeDirectory) && !string.IsNullOrEmpty(fileName))
                    {
                        var newDirectory = Path.Combine(destinationDirectory, relativeDirectory);
                        var newLocation = Path.Combine(newDirectory, fileName);
                        Directory.CreateDirectory(newDirectory);
                        if (!File.Exists(newLocation))
                        {
                            File.Copy(fileLocation, newLocation);
                        }
                    }

                    processedCount++;
                    statusUpdater?.Invoke($"Copied {processedCount} files out of {processedCount + filesQueue.Count} in queue", processedCount);
                }

                if (stopFileCopyWorker.WaitOne(1) && filesQueue.IsEmpty)
                {
                    return;
                }

                token.ThrowIfCancellationRequested();
            }
        }
        protected void GetFilesToCopy(IList<Beatmap> beatmaps, UpdateExportMetadataStatus statusUpdater,
            ConcurrentQueue<string> filesQueue, AutoResetEvent stopFileCopyWorker, CancellationToken token)
        {
            var mapSets = CollectionUtils.GetBeatmapSets(beatmaps);
            var fileCount = 0;
            var totalBeatmaps = beatmaps.Count();
            var processedBeatmapsCount = 0;
            foreach (var mapSet in mapSets)
            {
                if (token.IsCancellationRequested)
                {
                    stopFileCopyWorker.Set();
                    token.ThrowIfCancellationRequested();
                }

                foreach (var beatmap in mapSet.Value)
                {
                    var osuFileLocation = beatmap.FullOsuFileLocation();
                    Enqueue(osuFileLocation);
                    Enqueue(beatmap.GetImageLocation());
                    Enqueue(Path.Combine(Path.GetDirectoryName(osuFileLocation), beatmap.Mp3Name));

                    processedBeatmapsCount++;
                }
            }

            void Enqueue(string file)
            {
                if (File.Exists(file))
                {
                    UpdateStatus();
                    filesQueue.Enqueue(file);
                }
            }

            void UpdateStatus()
            {
                fileCount++;
                statusUpdater?.Invoke($"Processed {processedBeatmapsCount} beatmaps. {totalBeatmaps - processedBeatmapsCount} beatmaps left.", fileCount);
            }
        }
    }
}