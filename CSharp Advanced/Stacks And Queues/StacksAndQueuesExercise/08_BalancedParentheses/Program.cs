namespace _08_BalancedParentheses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var openingParentheses = new Stack<char>();
           
            if (input.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                return;
            }
            for (int i = 0; i < input.Length; i++)
            
            {
                var symbol = input[i];
                if (symbol == '[' || symbol == '{' || symbol == '(')
                {
                    openingParentheses.Push(symbol);
                }
                else if (symbol == ']' || symbol == '}' || symbol == ')')
                {
                    if (symbol == ')')
                    {
                        symbol = (char)(')' - 1);
                    }
                    else
                    {
                        symbol = (char)(symbol - 2);
                    }
                    var curentParentheses = openingParentheses.Pop();

                    if (curentParentheses != symbol)
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
            }
            Console.WriteLine("YES");
            
        }
        
    }
}
