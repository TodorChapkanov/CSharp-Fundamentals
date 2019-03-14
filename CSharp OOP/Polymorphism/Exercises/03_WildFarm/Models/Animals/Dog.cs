namespace _03_WildFarm.Models.Animals
{
    using _03_WildFarm.Models.Foods;
    using Constants;
    using System;

    class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override string AskForFood()
        {
            return "Woof!";
        }

        public override void Eat(Food food)
        {
            if (FoodTypeForAnimals.TigerDogAndOwlEatOnly != food.GetType().Name.ToLower())
            {
                throw new ArgumentException(string.Format(Messages.InvalidFood, this.GetType().Name, food.GetType().Name));
            }
            this.Weight += food.Quantity * IncreaseWeightPerFoodUnit.DogWeight;
            base.Eat(food);
        }
    }
}
