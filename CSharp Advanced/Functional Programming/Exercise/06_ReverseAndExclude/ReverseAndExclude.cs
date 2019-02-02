namespace _06_ReverseAndExclude
{
    using System;
    using System.Linq;

    public class ReverseAndExclude
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Reverse()
                .ToList();

            var number = int.Parse(Console.ReadLine());

            Func<int,bool> predicate = n => n % number != 0;

            input.Where(predicate).ToList().ForEach(n =>Console.Write(n + " "));
            Console.WriteLine();
        }
    }
}
