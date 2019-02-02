namespace _05_FilterByAge
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FilterByAge
    {
        public class People
        {
            public string Name { get; set; }

            public int Age { get; set; }
        }
        public static void Main()
        {
            var people = new List<People>();
            var count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                var curentPerson = Console.ReadLine().
                    Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                var person = new People
                {
                    Name = curentPerson[0],
                    Age = int.Parse(curentPerson[1])
                };
                people.Add(person);
            }
            var condition = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            

            Func<People, bool> filterPredicate;

            if (condition == "older")
            {
                filterPredicate = p => p.Age >= age;
            }
            else
            {
                filterPredicate = p => p.Age < age;
            }
            var format = Console.ReadLine();

            Func<People, string> printFormat;

            if (format == "name age")
            {
                printFormat = p => $"{p.Name} - {p.Age}";
            }
            else if (format == "name")
            {
                printFormat = p => $"{p.Name}";
            }
            else
            {
                printFormat = p => $"{p.Age}";
            }

            people
                .Where(filterPredicate)
                .Select(printFormat)
                .ToList()
                .ForEach(p =>Console.WriteLine(p));

        }
    }
}
