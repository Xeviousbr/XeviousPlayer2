#region Usings

using System.IO;
using System.Text;

#endregion

namespace FolderView
{
    // Search for subtitles file

    internal class FileSearch
    {
        private class SearchData
        {
            internal bool Found;
            internal string FileName;
            internal StringBuilder FilePath = new StringBuilder(260);

            internal SearchData(string fileName)
            {
                FileName = Path.DirectorySeparatorChar + fileName;
            }
        }

        internal string Find(string fileName, string initialDirectory, int directoryDepth)
        {
            if (string.IsNullOrEmpty(fileName)
                || fileName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0
                || !Directory.Exists(initialDirectory))
                return string.Empty;

            SearchData data = new SearchData(fileName);
            Search(initialDirectory, directoryDepth >= 0 ? directoryDepth : 0, data);
            return data.Found ? data.FilePath.ToString() : string.Empty;
        }

        private void Search(string directory, int depth, SearchData data)
        {
            try
            {
                data.FilePath.Length = 0;
                data.FilePath.Append(directory).Append(data.FileName);
                data.Found = File.Exists(data.FilePath.ToString());

                if (!data.Found && --depth >= 0)
                {
                    string[] directories = Directory.GetDirectories(directory);
                    for (int i = 0; i < directories.Length; i++)
                    {
                        Search(directories[i], depth, data);
                        if (data.Found) return;
                    }
                }
            }
            catch { /* ignore */ }
        }
    }
}
