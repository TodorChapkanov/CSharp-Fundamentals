namespace _05_AppliedArithmetics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AppliedArithmetics
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            Func<int, int> selectFunc = f => f + 0;

            List<int> newNumbers = input;

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                else if (command == "print")
                {
                    Console.WriteLine(string.Join(' ', newNumbers));
                    continue;
                }

                if (command == "add")
                {
                    selectFunc = f => f + 1;
                }

                else if (command == "multiply")
                {
                    selectFunc = f => f * 2;
                }

                else if (command == "subtract")
                {
                    selectFunc = f => f - 1;
                }

                newNumbers = newNumbers.Select(selectFunc).ToList();
            }
        }
    }

}
