namespace _03_WildFarm.Constants
{
    using System.Collections.Generic;

    public class FoodTypeForAnimals
    {
        public static IReadOnlyCollection<string> CatEatOnly = new List<string>() { "vegetable", "meat" };

        public static IReadOnlyCollection<string> MiceEatOnly = new List<string>() { "vegetable", "fruit" };

        public static readonly string TigerDogAndOwlEatOnly = "meat";
        
    }
}
