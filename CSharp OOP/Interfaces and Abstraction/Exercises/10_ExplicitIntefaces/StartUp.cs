namespace _10_ExplicitIntefaces
{
    using _10_ExplicitIntefaces.Contracts;
    using _10_ExplicitIntefaces.Models;
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var line = string.Empty;
            while ((line = Console.ReadLine()) != "End")
            {
                var tokens = line.Split();
                var citizenName = tokens[0];
                var citizenCountry = tokens[1];
                var citizenAge = int.Parse(tokens[2]);

                var citizen = new Citizen(citizenName, citizenCountry, citizenAge);

                Console.WriteLine(((IPerson)citizen).GetName());
                Console.WriteLine(((IResident)citizen).GetName());
            }
        }
    }
}
