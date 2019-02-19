namespace _05_ComparingObjects
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var allPeople = new List<Person>();
            string line;
            while ((line = Console.ReadLine()) != "END")
            {
                var splitedLine = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var name = splitedLine[0];
                var age = int.Parse(splitedLine[1]);
                var town = splitedLine[2];

                var person = new Person(name, age, town);
                allPeople.Add(person);
            }

            var indexOfPerson = int.Parse(Console.ReadLine());
            int IdenticalPeople = 0;
            var nonIdentical = 0;
            var curentPerson = allPeople[indexOfPerson - 1];

            for (int i = 0; i < allPeople.Count; i++)
            {
                var result = curentPerson.CompareTo(allPeople[i]);
                if (result == 0)
                {
                    IdenticalPeople++;
                }
                else
                {
                    nonIdentical++;
                }
            }
            if (IdenticalPeople > 1)
            {
                Console.WriteLine($"{IdenticalPeople} {nonIdentical} {allPeople.Count}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
