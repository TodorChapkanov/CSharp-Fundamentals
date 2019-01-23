namespace _01_CountSameValuesInArray
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CountSameValuesInArray
    {
        public static void Main()
        {
            var nubers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            var numbersCount = new Dictionary<double, int>();

            foreach (var number in nubers)
            {
                if (!numbersCount.ContainsKey(number))
                {
                    numbersCount.Add(number, 0);
                }
                numbersCount[number]++;
            }

            foreach (var kvp in numbersCount)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }
        }
    }
}
