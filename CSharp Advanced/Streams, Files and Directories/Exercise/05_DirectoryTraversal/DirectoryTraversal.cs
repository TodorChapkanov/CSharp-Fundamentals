namespace _05_DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class DirectoryTraversal
    {
        
        public static void Main(string[] args)
        {
            var desctopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var output = desctopPath + "/report.txt";
            
            var directory = Console.ReadLine();

            
            var allFiles = new Dictionary<string, List<FileInfo>>();

            var folder = Directory.GetFiles(directory);
            foreach (var file in folder)
            {
                var currentFileInfo = new FileInfo(file);

                var extension = currentFileInfo.Extension;
                var size = currentFileInfo.Length;

                if (!allFiles.ContainsKey(extension))
                {
                    allFiles[extension] = new List<FileInfo>();
                }

                allFiles[extension].Add(currentFileInfo);
            }

            using (var writer = new StreamWriter(output))
            {
                foreach (var file in allFiles
                    .OrderByDescending(f => f.Value.Count)
                    .ThenBy(f => f.Key))
                {
                    writer.WriteLine(file.Key);

                    foreach (var info in file.Value)
                    {
                        var fileName = info.Name;
                        var size = (double)info.Length / 1024;

                        writer.WriteLine($"--{fileName} - {size:f3}kb");
                    }
                }
            }


        }
    }
}
