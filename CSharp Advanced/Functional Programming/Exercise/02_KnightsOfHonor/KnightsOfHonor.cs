namespace _02_KnightsOfHonor
{
    using System;
    using System.Linq;

    public class KnightsOfHonor
    {
        public static void Main()
        {
            Console.ReadLine()
                .Split()
                .ToList()
                .ForEach(k => Console.WriteLine($"Sir {k}"));
        }
    }
}
