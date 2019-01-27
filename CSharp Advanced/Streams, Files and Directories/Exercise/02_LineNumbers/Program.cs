namespace _02_LineNumbers
{
    using System;
    using System.IO;

    public class Program
    {
        private const string inputPath = @"../../../Text.txt";
        private const string outputPath = @"../../../Output.txt";
        public static void Main()
        {
            var count = 1;
            

            using (var sr = new StreamReader(inputPath))
            {
                using (var sw = new StreamWriter(outputPath))
                {
                    while (true)
                    {
                        var line = sr.ReadLine();
                        var charCount = 0;
                        var letterCount = 0;

                        if (line == null)
                        {
                            break;
                        }

                        foreach (var symbol in line)
                        {
                            if (char.IsPunctuation(symbol))
                            {
                                charCount++;
                            }
                            else if (symbol != ' ' && !char.IsPunctuation(symbol))
                            {
                                letterCount++;
                            }
                           
                        }

                        line = $"{count}: {line}.({letterCount})({charCount})";

                        sw.WriteLine(line);
                        count++;
                    }
                }
            }
        }
    }
}
