namespace _01_BasicStackOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BasicStackOperations
    {
        public static void Main()
        {
            

            var commands = GetInput();
            var input = GetInput();

            var numbers = new Stack<int>();

            var pushCount = commands[0];
            var popCount = commands[1];
            var numberToLook = commands[2];

            PushNumbers(numbers, input, pushCount);

            PopNumbers(numbers,popCount);
            
            if (numbers.Count == 0)
            {
                Console.WriteLine(numbers.Count);
            }
            else if (numbers.Contains(numberToLook))
            {
                Console.WriteLine("true");
            }
            else
            {
                var smallestNumber = int.MaxValue;
                while (numbers.Any())
                {
                    var curentNumber = numbers.Pop();
                    if (curentNumber < smallestNumber)
                    {
                        smallestNumber = curentNumber;
                    }
                }
                Console.WriteLine(smallestNumber);
            }
        }

        private static void PopNumbers(Stack<int> numbers, int popCount)
        {
            for (int r = 0; r < popCount; r++)
            {
                numbers.Pop();
            }
        }

        private static void PushNumbers(Stack<int> numbers,int[] input, int pushCount)
        {
            for (int i = 0; i < pushCount; i++)
            {
                numbers.Push(input[i]);
            }
        }

        private static int[] GetInput()
        {
            var commands = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            return commands;
        }
    }
}
