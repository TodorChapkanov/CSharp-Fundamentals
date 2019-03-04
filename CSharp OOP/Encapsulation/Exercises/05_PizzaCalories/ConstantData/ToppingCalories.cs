namespace _05_PizzaCalolies.ConstantData
{
    using System.Collections.Generic;

    internal class ToppingCalories
    {
        public static readonly double GramTopping = 2;
        public static readonly Dictionary<string, double> ToppingType = new Dictionary<string, double>()
        {
            {"meat",1.2 },
            {"veggies", 0.8 },
            {"cheese", 1.1},
            {"sauce", 0.9}
        };
    }
}
