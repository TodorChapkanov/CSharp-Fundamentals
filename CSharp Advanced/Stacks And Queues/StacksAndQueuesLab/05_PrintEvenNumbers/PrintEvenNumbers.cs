namespace _05_PrintEvenNumbers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;


    public class PrintEvenNumbers
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var evenNumbers = new Queue<int>(input.Where(n => n % 2 == 0));

            while (evenNumbers.Any())
            {
                Console.Write($"{evenNumbers.Dequeue()} ");
            }
            Console.WriteLine();
        }
    }
}
