namespace _06_StrategyPattern
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var personsByNameLenght = new SortedSet<Person>(new NameCompare());
            var personsByAge = new SortedSet<Person>(new AgeCompare());

            var count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                var line = Console.ReadLine().Split();
                var name = line[0];
                var age = int.Parse(line[1]);
                var person = new Person(name, age);
                personsByNameLenght.Add(person);
                personsByAge.Add(person);
            }
            Console.WriteLine(string.Join(Environment.NewLine, personsByNameLenght));
            Console.WriteLine(string.Join(Environment.NewLine, personsByAge));
        }

       
    }
}
