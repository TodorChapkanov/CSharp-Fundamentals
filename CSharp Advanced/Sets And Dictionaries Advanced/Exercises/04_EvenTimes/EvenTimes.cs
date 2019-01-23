namespace _04_EvenTimes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class EvenTimes
    {
        public static void Main()
        {
            var input = int.Parse(Console.ReadLine());

            var evenTimeNumbers = new Dictionary<int, int>();

            for (int i = 0; i < input; i++)
            {
                var line = int.Parse(Console.ReadLine());

                if (!evenTimeNumbers.ContainsKey(line))
                {
                    evenTimeNumbers.Add(line, 0);
                }
                evenTimeNumbers[line]++;
            }

            var number = evenTimeNumbers.First(n => n.Value % 2 == 0).Key;
            Console.WriteLine(number);
        }
    }
}

