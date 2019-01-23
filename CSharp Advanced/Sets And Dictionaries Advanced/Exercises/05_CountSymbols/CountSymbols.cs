namespace _05_CountSymbols
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CountSymbols
    {
        public static void Main()
        {
            var line = Console.ReadLine();

            var symbols = new Dictionary<char, int>();

            foreach (var symbol in line)
            {
                if (!symbols.ContainsKey(symbol))
                {
                    symbols.Add(symbol, 0);
                }
                symbols[symbol]++;

            }
            foreach (var item in symbols.OrderBy(s => s.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
