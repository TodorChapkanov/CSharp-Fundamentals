namespace _09_ListOfPredicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ListOfPredicates
    {
        public static void Main()
        {
            var range = int.Parse(Console.ReadLine());

            var dividers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            Func<int, int, bool> divideFunc = (x,y) => x % y ==0;
            Action<List<int>> print = n => Console.WriteLine(string.Join(' ', n));
           
            var numbers = new List<int>();
            
            for (int i = 1; i <= range; i++)
            {
                var isDivisable = true;
                foreach (var divider in dividers)
                {
                    if (!divideFunc(i,divider))
                    {
                        isDivisable = false;
                        break;
                    }

                }
                if (isDivisable)
                {
                    numbers.Add(i);
                }
            }
            print(numbers);
        }
    }
}
