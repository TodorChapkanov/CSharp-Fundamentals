namespace _03_SimpleCalculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;


    public class SimpleCalculator
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var numbers = new Stack<string>(input.Reverse());

            var sum = int.Parse(numbers.Pop()); ;

            while (numbers.Any())
            {
                if (numbers.Pop() == "+")
                {
                    sum += int.Parse(numbers.Pop());
                }
                else
                {
                    sum -= int.Parse(numbers.Pop());
                }
            }
            Console.WriteLine(sum);
        }
    }
}
