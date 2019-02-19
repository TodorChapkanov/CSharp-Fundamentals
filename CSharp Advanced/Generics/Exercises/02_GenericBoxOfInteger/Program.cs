namespace _02_GenericBoxOfInteger
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            var lineCount = int.Parse(Console.ReadLine());
            var allResult = new List<string>();

            for (int i = 0; i < lineCount; i++)
            {
                var line = int.Parse(Console.ReadLine());
                var result = new Box<int>(line);
                allResult.Add(result.ToString());

            }

            Console.WriteLine(string.Join(Environment.NewLine, allResult));
        }
    }
}
