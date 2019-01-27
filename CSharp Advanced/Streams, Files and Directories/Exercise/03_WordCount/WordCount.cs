namespace _03_WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class WordCount
    {
        private const string wordsPath = @"../../../words.txt";
        private const string textPath = @"../../../text.txt";
        private const string expectedResultPath = @"../../../ExpectedResult.txt";
        private const string outputPath = @"../../../ActualResult.txt";
        private const string wordPattern = @"[A-Za-z']+";


        public static void Main()
        {
            var wordsFrequency = new Dictionary<string, int>();
            var wordsToCount = new HashSet<string>();
            
            using (var sr = new StreamReader(wordsPath))
            {
                var line = sr.ReadLine().Split();
                wordsToCount.UnionWith(line);
            }

            using (var sr = new StreamReader(textPath))
            {
                while (true)
                {
                    var line = sr.ReadLine();

                    if (line == null)
                    {
                        break;
                    }
                    var matches = Regex.Matches(line, wordPattern);

                    foreach (var match in matches)

                    {
                        var curentWord = match.ToString().ToLower();
                        if (wordsToCount.Contains(curentWord))
                        {
                            if (!wordsFrequency.ContainsKey(curentWord))
                            {
                                wordsFrequency.Add(curentWord, 0);
                            }
                            wordsFrequency[curentWord]++;
                        }
                    }
                }

            }
            using (var sr = new StreamReader(expectedResultPath))
            {
                using (var sw = new StreamWriter(outputPath))
                {
                    var isSame = true;
                    foreach (var word in wordsFrequency.OrderByDescending(v => v.Value))
                    {
                        var line = $"{word.Key} - {word.Value}";
                        var expectedLine = sr.ReadLine();
                        
                        if (line.CompareTo(expectedLine) !=0)
                        {
                            isSame = false;
                        }

                        sw.WriteLine($"{word.Key} - {word.Value}");
                    }
                    if (isSame)
                    {
                        Console.WriteLine("The Actual Result and the Expected Result are same!!!");
                    }
                }
            }
        }
    }
}

