namespace LogOrganizer
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class DirectoryManager
    {
        private readonly List<string> allDirectoryPaths;

        public DirectoryManager()
        {
            this.allDirectoryPaths = new List<string>();
        }

        public IEnumerable<string> GetChildDirectories(string path)
        {
            if (!this.allDirectoryPaths.Contains(path))
            {
                if (!this.IsDirectoryADate(path))
                {
                    this.allDirectoryPaths.Add(path);
                }
            }

            var rootDirectoryPaths = Directory.GetDirectories(path).AsEnumerable();

            foreach (var directory in rootDirectoryPaths)
            {
                if (!this.IsDirectoryADate(directory))
                {
                    this.allDirectoryPaths.Add(directory);
                }

                this.GetChildDirectories(directory);
            }

            return this.allDirectoryPaths;
        }

        private bool IsDirectoryADate(string directory)
        {
            var directoryInfo = new DirectoryInfo(directory);
            return Regex.IsMatch(directoryInfo.Name, "(\\d{4})(-)(\\d{2})");
        }
    }
}