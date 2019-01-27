namespace _02_LineNumbers
{
    using System;
    using System.IO;

    public class LineNumbers
    {
        static void Main()
        {
            var count = 1;

            using (var sr = new StreamReader("02. Line Numbers/input.txt"))
            {
                using (var sw = new StreamWriter("Output.txt"))
                {
                    while (true)
                    {
                        var line = sr.ReadLine();

                        if (line == null)
                        {
                            break;
                        }

                        line = $"{count}. {line}";

                        sw.WriteLine(line);
                        count++;
                    }
                }
            }
        }
    }
}
