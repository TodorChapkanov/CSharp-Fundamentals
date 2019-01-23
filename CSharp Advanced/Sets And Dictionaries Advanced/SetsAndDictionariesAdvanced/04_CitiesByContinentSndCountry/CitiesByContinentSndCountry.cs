namespace _04_CitiesByContinentSndCountry
{
    using System;
    using System.Collections.Generic;


    public class CitiesByContinentSndCountry
    {
        public static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());

            var cities = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < number; i++)
            {
                var line = Console.ReadLine().
                    Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var continent = line[0];
                var countries = line[1];
                var city = line[2];

                if (!cities.ContainsKey(continent))
                {
                    cities.Add(continent, new Dictionary<string, List<string>>());
                }

                if (!cities[continent].ContainsKey(countries))
                {
                    cities[continent].Add(countries, new List<string>());
                }
                cities[continent][countries].Add(city);
                
            }

            foreach (var continent in cities)
            {
                Console.WriteLine($"{continent.Key}:");
                foreach (var countries in continent.Value)
                {
                    Console.WriteLine($"  {countries.Key} -> {string.Join(", ", countries.Value)}");
                    
                }
            }
        }
    }
}
