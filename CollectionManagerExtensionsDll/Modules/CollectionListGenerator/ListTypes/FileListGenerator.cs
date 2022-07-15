using System.Collections.Generic;
using System.Text;
using CollectionManager.DataTypes;
using CollectionManagerExtensionsDll.Utils;
using System.Diagnostics;

namespace CollectionManagerExtensionsDll.Modules.CollectionListGenerator.ListTypes
{
    internal class FileListGenerator : IListGenerator
    {
        internal string Lb = "\r\n";
        private StringBuilder _stringBuilder = new StringBuilder();

        public string GetListHeader(Collections collections)
        {
            return "";
        }


        public string GetCollectionBody(ICollection collection, Dictionary<int, Beatmaps> mapSets, int collectionNumber)
        {
            _stringBuilder.Clear();

            _stringBuilder.AppendFormat("{0}{1}{0}{0}", Lb, string.Format("Collection {0}: {1}", collectionNumber, collection.Name));
            //collection content(beatmaps)

            foreach (var mapSet in mapSets)
            {
                GetMapSetList(mapSet.Key, mapSet.Value, ref _stringBuilder);
            }

            return _stringBuilder.ToString();
        }

        public string GetListFooter(Collections collections)
        {
            return "";
        }

        public void StartGenerating()
        {
            _stringBuilder.Clear();
        }

        public void EndGenerating()
        {
            _stringBuilder.Clear();
        }

        private void GetMapSetList(int mapSetId, Beatmaps beatmaps, ref StringBuilder sb)
        {

            if (mapSetId == -1)
            {
                /*foreach (var map in beatmaps)
                {
                    if (map.MapId > 0)
                    {
                        var DirectoryLocation = ((BeatmapExtension)map).BeatmapDirectory();
                        var osuFileLocation = ((BeatmapExtension)map).FullOsuFileLocation();
                        var audioFileLocation = ((BeatmapExtension)map).FullAudioFileLocation();
                        var imageLocation = ((BeatmapExtension)map).GetImageLocation();

                        sb.AppendFormat("\r\n\"{0}\"", DirectoryLocation);
                            sb.AppendFormat("\r\n    \"{0}\" \"{1}\" \"{2}\"", osuFileLocation, audioFileLocation, imageLocation);
                        if (!string.IsNullOrWhiteSpace(map.DiffName))
                            sb.AppendFormat(" [{0}]{1}", map.DiffName, Lb);
                    }
                    else
                    {
                        sb.AppendFormat("No data - {0}{1}", map.Md5, Lb);
                    }
                }*/
            }
            else
            {
                var DirectoryLocation = ((BeatmapExtension)beatmaps[0]).BeatmapDirectory();
                var osuFileLocation = ((BeatmapExtension)beatmaps[0]).FullOsuFileLocation();
                var audioFileLocation = ((BeatmapExtension)beatmaps[0]).FullAudioFileLocation();
                var imageLocation = ((BeatmapExtension)beatmaps[0]).GetImageLocation();

                sb.AppendFormat("\r\n\"{0}\"", DirectoryLocation);
                foreach (var map in beatmaps)
                {
                    sb.AppendFormat("\r\n    \"{0}\" \"{1}\" \"{2}\"", osuFileLocation, audioFileLocation, imageLocation);
                }
                sb.Append(Lb);
            }
        }
    }
}