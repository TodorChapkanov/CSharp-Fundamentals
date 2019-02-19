namespace _01_GenericBoxOfString
{
    using System;
    using System.Collections.Generic;
    

    public class StartUp
    {
        public static void Main()
        {
            
            var lineCount = int.Parse(Console.ReadLine());
            var allResult = new List<string>();
           
            for (int i = 0; i < lineCount; i++)
            {
                var line = Console.ReadLine();
                var result = new Box<string>(line);
                allResult.Add(result.ToString());

            }

            Console.WriteLine(string.Join(Environment.NewLine, allResult));
        }
    }
}
