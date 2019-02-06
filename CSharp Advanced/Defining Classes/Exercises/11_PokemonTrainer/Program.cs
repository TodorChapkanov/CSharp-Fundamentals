
using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var allTrainers = new List<Trainer>();
        string line;
        while ((line = Console.ReadLine()) != "Tournament")
        {
            var splitedLine = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var trainerName = splitedLine[0];
            var pokemonName = splitedLine[1];
            var pokemonElement = splitedLine[2];
            var pokemonHealth = int.Parse(splitedLine[3]);


            var pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
            var trainer = new Trainer(trainerName, pokemon);

            if (allTrainers.Any(a => a.Name == trainerName))
            {
                var curentTrainer = allTrainers.FirstOrDefault(c => c.Name == trainerName);
                var curentIndex = allTrainers.IndexOf(curentTrainer);
                allTrainers[curentIndex].AddPokemon(pokemon);
            }
            else
            {

                allTrainers.Add(trainer);
            }

        }

        while ((line = Console.ReadLine()) != "End")
        {

            foreach (var item in allTrainers)
            {

                if (item.Pokemons.Any(e => e.element == line))
                {
                    item.AddBadges();
                }

                else
                {
                    item.ReduceHealth();
                }
            }
        }

        foreach (var item in allTrainers.OrderByDescending(b => b.Badges))
        {
            Console.WriteLine($"{item.Name} {item.Badges} {item.Pokemons.Count}");
        }
    }
}
