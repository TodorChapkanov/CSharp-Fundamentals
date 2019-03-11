namespace _06_BirthdayCelebrations
{
    using _06_BirthdayCelebrations.Contracts;
    using _06_BirthdayCelebrations.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var allData = new List<IBirth>();

            var line = string.Empty;
            while ((line = Console.ReadLine()) != "End")
            {
                var tokens = line.Split();
                IBirth entity = null;

                if (tokens.Contains("Citizen"))
                {
                    var citizenName = tokens[1];
                    var citizenAge = int.Parse(tokens[2]);
                    var citizenId = tokens[3];
                    var citizenBirthdate = tokens[4];

                    entity = new Citizen(citizenId, citizenName, citizenAge, citizenBirthdate);
                }

                else if (tokens.Contains("Pet"))
                {
                    var petName = tokens[1];
                    var petBirthdate = tokens[2];

                    entity = new Pet(petName, petBirthdate);
                }

                if (entity != null)
                {
                    allData.Add(entity);
                }
            }

            var birthYear = Console.ReadLine();

            allData.Where(y => y.Birthdate.EndsWith(birthYear))
                .ToList()
                .ForEach(b => Console.WriteLine(b.Birthdate));
        }
    }
}
