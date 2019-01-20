namespace _02_StackSum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StackSum
    {
        public static void Main()
        {
            
            var input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var numbers = new Stack<int>(input);

            var command = ReadFromConsole();

            while (command[0] != "end")
            {
                for (int i = 1; i < command.Length; i++)
                {
                    var number = int.Parse(command[i]);
                    if (command[0] == "add")
                    {
                        numbers.Push(number);
                    }
                    else
                    {
                        if (number <= numbers.Count())
                        {
                            for (int r = 0; r < number; r++)
                            {
                                numbers.Pop();
                            }
                        }
                    }
                }
                
                command = ReadFromConsole();
            }
            var sum = numbers.Sum();
            Console.WriteLine($"Sum: {sum}");
        }

        private static string[] ReadFromConsole()
        {
             var command = Console.ReadLine()
                .ToLower()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            return command;
        }
    }
}
