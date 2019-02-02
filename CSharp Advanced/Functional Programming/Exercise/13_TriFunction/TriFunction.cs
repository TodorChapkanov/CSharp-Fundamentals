namespace _13_TriFunction
{
    using System;
    using System.Linq;

    public class TriFunction
    {
        public static void Main()
        {
            var symbolsSum = int.Parse(Console.ReadLine());
            var input = Console.ReadLine().Split();
            Func<string, int, bool> func = (x, y) => x.Sum(c => Convert.ToInt32(c)) >= y;

            var name = input.Where(x => func(x,symbolsSum)).FirstOrDefault();
            Console.WriteLine(name);

        }
    }
}
