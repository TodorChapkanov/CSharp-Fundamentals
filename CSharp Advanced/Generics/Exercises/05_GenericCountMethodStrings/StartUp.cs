namespace _05_GenericCountMethodStrings
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var count = int.Parse(Console.ReadLine());
            var allLines = new List<string>();
            for (int i = 0; i < count; i++)
            {
                var line = Console.ReadLine();
                allLines.Add(line);
            }
            var parameter = Console.ReadLine();
            var data = new Data<string>(allLines);

            Console.WriteLine(data.CountString(parameter));
        }
    }
}
