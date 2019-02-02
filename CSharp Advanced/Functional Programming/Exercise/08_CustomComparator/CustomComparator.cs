namespace _08_CustomComparator
{
    using System;
    using System.Linq;

    public class CustomComparator
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Func<int, int, int> sortFunc = (x, y) => (x % 2 == 0 && y % 2 != 0) ? -1 :
             (x % 2 != 0 && y % 2 == 0) ? 1 : x.CompareTo(y);
            Action<int[]> print = x => Console.WriteLine(string.Join(' ', x));

            Array.Sort(numbers, new Comparison<int>(sortFunc));

            print(numbers);
        }
    }
}
