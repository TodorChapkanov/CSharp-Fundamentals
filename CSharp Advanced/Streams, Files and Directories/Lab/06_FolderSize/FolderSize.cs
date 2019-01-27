namespace _06_FolderSize
{
    using System;
    using System.IO;


    public class FolderSize
    {
        private const string inputPath = @"..\..\..\TestFolder";
        private const string outputPath = @"..\..\..\TestFolder\Output.txt";
        public static void Main()
        {
            var files = Directory.GetFiles(inputPath);

            double sizeInBytes = 0.00;

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                sizeInBytes += fileInfo.Length;
            }

            var sizeInMb = sizeInBytes / 1024 / 1024;
            File.WriteAllText(outputPath, sizeInMb.ToString());
        }
    }
}
