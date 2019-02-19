namespace _06_GenericCountMethodDoubles
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());
            var allLines = new List<double>();
            for (int i = 0; i < count; i++)
            {
                var line = double.Parse(Console.ReadLine());
                allLines.Add(line);
            }
            var parameter = double.Parse(Console.ReadLine());
            var data = new Data<double>(allLines);

            Console.WriteLine(data.CountString(parameter));
        }
    }
}
