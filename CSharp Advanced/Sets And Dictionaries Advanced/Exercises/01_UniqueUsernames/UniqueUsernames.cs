namespace _01_UniqueUsernames
{
    using System;
    using System.Collections.Generic;

    public class UniqueUsernames
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            var usernames = new HashSet<string>();

            for (int i = 0; i < number; i++)
            {
                var line = Console.ReadLine();
                usernames.Add(line);
            }

            Console.WriteLine(string.Join(Environment.NewLine, usernames));
        }
    }
}
