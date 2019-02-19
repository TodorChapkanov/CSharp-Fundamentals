namespace _04_GenericSwapMethodIntegers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var lineCount = int.Parse(Console.ReadLine());
            var list = new List<int>();

            for (int i = 0; i < lineCount; i++)
            {
                int intiger;
                var input = int.TryParse(Console.ReadLine(), out intiger);
                list.Add(intiger);
            }
            var result = new Box<int>(list);

            var indexToSwap = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var firstIndex = indexToSwap[0];
            var secondIndex = indexToSwap[1];
            result.Swap(firstIndex, secondIndex);

            Console.Write(result);
        }
    }
}
