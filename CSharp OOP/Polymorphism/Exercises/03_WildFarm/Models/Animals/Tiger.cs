namespace _03_WildFarm.Models.Animals
{
    using _03_WildFarm.Models.Foods;
    using Constants;
    using System;

    public class Tiger : Feline
    {
        public Tiger(string name, double weight,  string livingRegion, string breed)
            : base(name, weight,  livingRegion, breed)
        {
        }

        public override string AskForFood()
        {
            return "ROAR!!!";
        }

        public override void Eat(Food food)
        {
            if (FoodTypeForAnimals.TigerDogAndOwlEatOnly != food.GetType().Name.ToLower())
            {
                throw new ArgumentException(string.Format(Messages.InvalidFood, this.GetType().Name, food.GetType().Name));
            }
            this.Weight += food.Quantity * IncreaseWeightPerFoodUnit.TigerWight;
            base.Eat(food);
        }
    }
}
