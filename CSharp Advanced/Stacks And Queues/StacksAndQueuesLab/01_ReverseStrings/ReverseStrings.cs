namespace _01_ReverseStrings
{
    using System;
    using System.Collections.Generic;


    public class ReverseStrings
    {
        public static void Main()
        {
            var symbols = new Stack<char>();

            var input = Console.ReadLine();

            foreach (var symbol in input)
            {
                symbols.Push(symbol);
            }

            while (symbols.Count != 0)
            {
                Console.Write(symbols.Pop());
            }
            Console.WriteLine();
        }
    }
}
