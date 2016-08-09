namespace LogOrganizer
{
    using System;
    using System.IO;

    public class FileOrganizer
    {
        private readonly string path;

        public FileOrganizer(string path)
        {
            this.path = path;
        }

        public void OrganizeFiles()
        {
            var files = Directory.GetFiles(this.path);
            foreach (var file in files)
            {
                var modDate = File.GetLastWriteTime(file);
                var fileInfo = new FileInfo(file);

                var dateDirectoryName = $"{this.path}\\{modDate.Year}-{this.FormatMonth(modDate.Month)}";
                if (!Directory.Exists(dateDirectoryName))
                {
                    Directory.CreateDirectory(dateDirectoryName);
                    Console.WriteLine($"Created {dateDirectoryName}");
                }

                Console.WriteLine(modDate.ToShortDateString());

                try
                {
                    if (modDate.ToShortDateString() != DateTime.Now.ToShortDateString())
                    {
                        File.Move(file, $"{dateDirectoryName}\\{fileInfo.Name}");
                    }
                }
                catch (IOException ex)
                {
                    if (!ex.Message.Contains("is being used by another process"))
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine($"Moved {file}");
            }
        }

        private string FormatMonth(int month)
        {
            if (month < 10)
            {
                return $"0{month}";
            }

            return month.ToString();
        }
    }
}