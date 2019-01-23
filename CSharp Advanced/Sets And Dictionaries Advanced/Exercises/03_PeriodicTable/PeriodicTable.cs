namespace _03_PeriodicTable
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PeriodicTable
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());

            var compounds = new HashSet<string>();

            for (int i = 0; i < number; i++)
            {
                var line = Console.ReadLine().Split();
                foreach (var item in line)
                {
                    compounds.Add(item);
                }
            }
            Console.WriteLine(string.Join(' ', compounds.OrderBy(c => c)));
        }
    }
}
