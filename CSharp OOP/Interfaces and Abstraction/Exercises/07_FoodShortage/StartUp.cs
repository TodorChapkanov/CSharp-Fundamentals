namespace _07_FoodShortage
{
    using _07_FoodShortage.Contrcts;
    using _07_FoodShortage.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
       public static void Main()
        {
            var buyers = new List<IBuyer>();
            
            var lineCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < lineCount; i++)
            {
                var line = Console.ReadLine().Split();
                IBuyer buyer = null;

                if (line.Length > 3)
                {
                    var citizenName = line[0];
                    var citizenAge = int.Parse(line[1]);
                    var citizenId = line[2];
                    var citizenBirthdate = line[3];
                    buyer = new Citizen(citizenName, citizenAge, citizenId, citizenBirthdate);
                }

                else if (line.Length == 3)
                {
                    var rebelName = line[0];
                    var rebelAge = int.Parse(line[1]);
                    var rebelGroup = line[2];
                    buyer = new Rebel(rebelName, rebelAge, rebelGroup);
                }

                if (buyer != null)
                {
                    buyers.Add(buyer);
                }
            }
            var input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                if (buyers.Any(b => b.Name == input))
                {
                    var currentBuyer = buyers.First(b => b.Name == input);

                    currentBuyer.BuyFood();
                }
            }

            var totalFood = buyers.Sum(b => b.Food);

            Console.WriteLine(totalFood);
        }
    }
}
