﻿namespace _01_SortEvenNumbers
{
    using System;
    using System.Linq;

    public class SortEvenNumbers
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                 .Split(',')
                 .Select(int.Parse)
             .Where(n => n % 2 == 0)
             .OrderBy(n => n)
             .ToArray();

            Console.WriteLine(string.Join(", ", numbers));
         }


    }
}
