namespace _03_GenericSwapMethodStrings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var lineCount = int.Parse(Console.ReadLine());
            var list = new List<string>();

            for (int i = 0; i < lineCount; i++)
            {
                var input = Console.ReadLine();
                list.Add(input);
            }
            var result = new Box<string>(list);

            var indexToSwap = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var firstIndex = indexToSwap[0];
            var secondIndex = indexToSwap[1];
            result.Swap(firstIndex, secondIndex);

            Console.Write(result);

        }
    }
}
