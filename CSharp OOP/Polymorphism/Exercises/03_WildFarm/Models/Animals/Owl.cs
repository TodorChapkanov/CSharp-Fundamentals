namespace _03_WildFarm.Models.Animals
{
    using _03_WildFarm.Models.Foods;
    using Constants;
    using System;

    class Owl : Bird
    {
        public Owl(string name, double weight,  double wingSize)
            :base(name, weight, wingSize)
        {
        }

        public override string AskForFood()
        {
            return "Hoot Hoot";
        }

        public override void Eat(Food food)
        {
            if (FoodTypeForAnimals.TigerDogAndOwlEatOnly != food.GetType().Name.ToLower())
            {
                throw new ArgumentException(string.Format(Messages.InvalidFood, this.GetType().Name, food.GetType().Name));
            }
            this.Weight += food.Quantity * IncreaseWeightPerFoodUnit.OwlWeight;
            base.Eat(food);
        }
    }
}
