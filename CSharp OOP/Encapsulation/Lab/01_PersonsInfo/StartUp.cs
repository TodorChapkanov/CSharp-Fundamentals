namespace _01_PersonsInfo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var lineCount = int.Parse(Console.ReadLine());
            var people = new List<Person>();
            for (int i = 0; i < lineCount; i++)
            {
                var line = Console.ReadLine().Split();
                var firstName = line[0];
                var lastName = line[1];
                var age = int.Parse(line[2]);

                var person = new Person(firstName, lastName, age);

                people.Add(person);
            }
            people.OrderBy(p => p.FirstName)
                .ThenBy(p => p.Age)
                .ToList()
                .ForEach(p => Console.WriteLine(p));
        }
    }
}
