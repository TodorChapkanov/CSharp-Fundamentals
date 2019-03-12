namespace _05_Mordor_sCruelPlan
{
    using Models.Foods;
    using Factories;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var foodsToEat = Console.ReadLine().Split();

            var foodFactory = new FoodFactory();

            var allFood = new List<Food>();
            Food currentFood = null;
            foreach (var food in foodsToEat)
            {
               currentFood = foodFactory.CreateFood(food);
                allFood.Add(currentFood);
            }
            

            var totalPoints = allFood.Sum(c => c.Happiness);
            var moodFactory = new MoodFactory();
            var mood = moodFactory.CreateMode(totalPoints);

            Console.WriteLine(totalPoints);
            Console.WriteLine(mood.Name);
        }
    }
}
