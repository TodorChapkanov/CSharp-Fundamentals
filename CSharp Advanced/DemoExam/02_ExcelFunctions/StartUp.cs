namespace _02_ExcelFunctions
{
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            var lineCount = int.Parse(Console.ReadLine());
            var table = new string[lineCount][];

            for (int i = 0; i < lineCount; i++)
            {
                var line = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                table[i] = line;
            }

            var command = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (command[0] == "hide")
            {
                var index = GetIndex(table, command[1]);
                
                for (int r = 0; r < table.Length; r++)
                {
                    Console.WriteLine(string.Join(" | ", table[r].Where((x,i) => i != index).ToArray()));
                }
            }

            if (command[0] == "sort")
            {
                var index = GetIndex(table, command[1]);
                Console.WriteLine(string.Join(" | ", table[0]));
                foreach (var item in table.TakeLast(table.Length - 1).OrderBy(x => x[index]))
                {
                    Console.WriteLine(string.Join(" | ", item));
                }
            }

            if (command[0] == "filter")
            {
                var index = GetIndex(table, command[1]);
                Console.WriteLine(string.Join(" | ", table[0]));
                for (int i = 0; i < table.Length; i++)
                {
                    if (table[i][index] == command[2])
                    {
                        Console.WriteLine(string.Join(" | ", table[i]));
                    }
                }
               
            }
        }

        public static int GetIndex(string[][] table, string command)
        {
            var index = 0;
            for (int i = 0; i < table[0].Length; i++)
            {
                if (table[0][i] == command)
                {
                    index = i;
                }
            }
            return index;
        }
    }
}
