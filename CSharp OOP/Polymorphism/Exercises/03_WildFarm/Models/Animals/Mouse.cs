namespace _03_WildFarm.Models.Animals
{
    using _03_WildFarm.Models.Foods;
    using Constants;
    using System;
    using System.Linq;

    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight,livingRegion)
        {
        }

        public override string AskForFood()
        {
            return "Squeak";
        }

        public override void Eat(Food food)
        {
            if (!FoodTypeForAnimals.MiceEatOnly.Contains(food.GetType().Name.ToLower()))
            {
                throw new ArgumentException(string.Format(Messages.InvalidFood, this.GetType().Name, food.GetType().Name));
            }
            this.Weight += food.Quantity * IncreaseWeightPerFoodUnit.MouseWeight;
            base.Eat(food);
        }
    }
}
