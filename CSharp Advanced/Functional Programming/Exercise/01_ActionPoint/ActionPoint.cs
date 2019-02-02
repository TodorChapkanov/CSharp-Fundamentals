namespace _01_ActionPoint
{
    using System;
    using System.Linq;

    public class ActionPoint
    {
        public static void Main()
        {
            Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(n => Console.WriteLine(n));
        }
    }
}
