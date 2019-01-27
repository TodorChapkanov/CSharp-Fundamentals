namespace _03_WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class WordCount
    {
        public static void Main()
        {
            var wordsFrequency = new Dictionary<string, int>();

            var wordsToCount = new HashSet<string>();
            var pattern = @"[A-Za-z']+";

            using (var sr = new StreamReader("03. Word Count/words.txt"))
            {
                var line = sr.ReadLine().Split();
                wordsToCount.UnionWith(line);
            }

            using (var sr = new StreamReader("03. Word Count/text.txt"))
            {
                while (true)
                {
                    var line = sr.ReadLine();

                    if (line == null)
                    {
                        break;
                    }
                    var matches = Regex.Matches(line, pattern);

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
            using (var sw = new StreamWriter("OutputFile.txt"))
            {
                foreach (var word in wordsFrequency.OrderByDescending(v => v.Value))
                {
                    sw.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}
