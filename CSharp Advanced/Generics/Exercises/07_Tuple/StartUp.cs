namespace _07_Tuple
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            var citizenParams = Console.ReadLine().Split().ToList();
            
            var address = citizenParams.Last();
            citizenParams.RemoveAt(citizenParams.Count - 1);
            var name = string.Join(" ", citizenParams);
            var citizen = new Tuple<string, string >(name, address);

            var beerDrinkerParams = Console.ReadLine().Split().ToList();
            
            var beer = int.Parse(beerDrinkerParams.Last());
            beerDrinkerParams.RemoveAt(beerDrinkerParams.Count - 1);
            var drinkerName = string.Join(" ", beerDrinkerParams);
            var beerDrinker = new Tuple<string, int>(drinkerName, beer);

            var numbersParams = Console.ReadLine().Split();
            var numberHolder = new Tuple<string, double>(numbersParams[0], double.Parse(numbersParams[1]));

            Console.WriteLine(citizen);
            Console.WriteLine(beerDrinker);
            Console.WriteLine(numberHolder);
        }
    }
}
