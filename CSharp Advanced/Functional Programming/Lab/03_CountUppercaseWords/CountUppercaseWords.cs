namespace _03_CountUppercaseWords
{
    using System;
    using System.Linq;

    public class CountUppercaseWords
    {
        public static void Main(string[] args)
           => Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(n => char.IsUpper(n[0]))
                .ToList()
                .ForEach(s => Console.WriteLine(s));
    }
}
