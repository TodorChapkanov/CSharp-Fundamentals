namespace _04_FindEvensOrOdds
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FindEvensOrOdds
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            var startNumber = numbers.Min();

            var command = Console.ReadLine();

            var endNumber = numbers.Max();

            numbers.Clear();

            for (int i = startNumber; i <= endNumber; i++)
            {
                numbers.Add(i);
            }

            Predicate<int> even = n => n % 2 == 0;

            Predicate<int> odd = n => n % 2 != 0;

            var result = new List<int>();

            if (command == "even")
            {
                result = numbers.FindAll(even);
            }
            else
            {
                result = numbers.FindAll(odd);
            }

            Console.WriteLine(string.Join (' ', result));
        }
    }
}
