namespace _05_SliceFile
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;

    public class SliceFile
    {
        private const string inputFilePath = "../../../05. Slice File/SliceMe.mp4";
        private const string outputDirectoryPath = "../../../Output/";
        private static List<string> piecesPaths;
        

        public static void Main()
        {
            Console.WriteLine("How many pieces you want:");
            var pieces = int.Parse(Console.ReadLine());

            piecesPaths = new List<string>();


            if (!Directory.Exists(outputDirectoryPath))
            {
                Directory.CreateDirectory(outputDirectoryPath);
            }

            using (var fr = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read))
            {
                var sizePiece = (int)Math.Ceiling((double)fr.Length/pieces);

                for (int piece = 0; piece  < pieces; piece ++)
                {
                    using (var fw = new FileStream(outputDirectoryPath + $"Part-{piece}.mkv", FileMode.Create))
                    {
                        var buffer = new byte[sizePiece];
                        int read = fr.Read(buffer, 0, buffer.Length);
                        fw.Write(buffer, 0, read);
                        piecesPaths.Add(outputDirectoryPath + $"Part-{piece}.mkv");

                    }
                }
            }

            for (int piece = 0; piece < piecesPaths.Count; piece++)
            {
                using (var reader = new FileStream(piecesPaths[piece], FileMode.Open))
                {
                    using (var writer = new FileStream(outputDirectoryPath + "assembled.mp4",FileMode.Append))
                    {
                        var buffer = new byte[reader.Length];
                        var read = reader.Read(buffer, 0, buffer.Length);
                        writer.Write(buffer, 0, read);
                    }
                }
            }
        }
    }
}
