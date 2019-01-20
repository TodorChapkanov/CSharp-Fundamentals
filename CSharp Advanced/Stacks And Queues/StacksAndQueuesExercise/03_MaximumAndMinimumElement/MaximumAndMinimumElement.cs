namespace _03_MaximumAndMinimumElement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MaximumAndMinimumElement
    {
        public static void Main()
        {
            var count = int.Parse(Console.ReadLine());

            var numbers = new Stack<int>();


            for (int i = 0; i < count; i++)
            {
                var command = Console.ReadLine().
                    Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var operation = command[0];

                if (operation == 1)
                {
                    var numbersToPush = command[1];
                    numbers.Push(numbersToPush);
                }
                else if (operation == 2 && numbers.Count > 0)
                {
                    numbers.Pop();
                }
                else if (operation == 3)
                {
                    if (numbers.Count > 0)
                    {
                        var maxNumber = GetMaxNumber(numbers);
                        Console.WriteLine(maxNumber);
                    }
                    
                    
                }
                else if (operation == 4)
                {
                    if (numbers.Count > 0)
                    {
                        var minNumber = GetMinNumber(numbers);
                        Console.WriteLine(minNumber);
                    }
                    
                }
            }
            if (numbers.Count > 0)
            {
                Console.WriteLine(string.Join(", ", numbers));
            }
            
        }

        private static int GetMinNumber(Stack<int> numbers)
        {
            var minNumber = numbers.ToList().Min();
            return minNumber;
        }

        private static int GetMaxNumber(Stack<int> numbers)
        {
            var maxNumber = numbers.ToList().Max();
            return maxNumber;
            
        }

    }
}
