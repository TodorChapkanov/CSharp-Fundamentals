namespace _02_SetsOfElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SetsOfElements
    {
        public static void Main()
        {
            var countOfSets = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            var firstSet = new HashSet<int>();
            var secondSet = new HashSet<int>();

            var firstSetCount = countOfSets[0];
            var secondSetCount = countOfSets[1];
            var sum = firstSetCount + secondSetCount;

            for (int i = 0; i < sum; i++)
            {
                var line = int.Parse(Console.ReadLine());
                if (i < firstSetCount)
                {
                    firstSet.Add(line);
                }
                else
                {
                    secondSet.Add(line);
                }
            }
            firstSet.IntersectWith(secondSet);
            Console.WriteLine(string.Join(' ', firstSet));
        }
    }
}
