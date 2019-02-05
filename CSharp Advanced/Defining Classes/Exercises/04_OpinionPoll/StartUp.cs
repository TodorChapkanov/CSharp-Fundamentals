namespace _04_OpinionPoll
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var membersCount = int.Parse(Console.ReadLine());

            var people = new List<Person>();

            for (int i = 0; i < membersCount; i++)
            {
                var input = Console.ReadLine()
                    .Split();

                var name = input[0];
                var age = int.Parse(input[1]);
                var person = new Person(name,age);

                people.Add(person);

                
            }
            foreach (var curentPerson in people.OrderBy(n => n.Name))
            {
                if (curentPerson.Age > 30)
                {
                    Console.WriteLine($"{curentPerson.Name} - {curentPerson.Age}");
                }

            }
        }
    }
}
