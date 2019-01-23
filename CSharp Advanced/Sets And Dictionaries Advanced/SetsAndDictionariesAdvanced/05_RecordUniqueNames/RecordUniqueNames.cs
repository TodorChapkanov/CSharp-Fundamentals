namespace _05_RecordUniqueNames
{
    using System;
    using System.Collections.Generic;

    public class RecordUniqueNames
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());

            var names = new HashSet<string>();

            for (int i = 0; i < number; i++)
            {
                var line = Console.ReadLine();
                names.Add(line);
            }
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
