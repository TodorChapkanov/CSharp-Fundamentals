﻿namespace _04_Team
{
    using System;
    using System.Collections.Generic;

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
                var salary = decimal.Parse(line[3]);

                try
                {
                    var person = new Person(firstName, lastName, age, salary);
                    people.Add(person);
                }

                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            
            var team = new Team("SoftUni");

            foreach (var player in people)
            {
                team.AddPlayer(player);
            }

            Console.WriteLine(team);
        }
    }
}
