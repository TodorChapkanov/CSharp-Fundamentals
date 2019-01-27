namespace _01_EvenLines
{
    using System;
    using System.IO;
    using System.Linq;

    public class EvenLines
    {
        private const string inputPath = @"../../../text.txt";
        private const string outputPath = @"../../../Output.txt";
        public static void Main()
        {
            var couner = 0;
            var chars = new char[] { '-', ',', '.', '!', '?' };

            using (var streamReader = new StreamReader(inputPath))
            {
                using (var streamWriter = new StreamWriter(outputPath))
                {
                    while (true)
                    {
                        var line = streamReader.ReadLine();

                        if (line == null)
                        {
                            break;
                        }

                        if (couner % 2 == 0)
                        {
                            foreach (var symbol in chars)
                            {
                                if (line.Contains(symbol))
                                {
                                  line =  line.Replace(symbol, '@');
                                }
                            }

                            var spliterdLine = line.Split();

                           spliterdLine =  spliterdLine.Reverse().ToArray();
                            streamWriter.WriteLine(string.Join(' ', spliterdLine));
                        }
                        couner++;
                    }
                }
            }
        }
        
    }

}
