namespace _03_WildFarm.Models.Animals
{
    using _03_WildFarm.Models.Foods;
    using Constants;
    using System;
    using System.Linq;

    public class Cat : Feline
    {
        public Cat(string name, double weight,string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override string AskForFood()
        {
            return "Meow";
        }

        public override void Eat(Food food)
        {
            if (!FoodTypeForAnimals.CatEatOnly.Contains(food.GetType().Name.ToLower()))
            {
                throw new ArgumentException(string.Format(Messages.InvalidFood, this.GetType().Name, food.GetType().Name));
            }
            this.Weight += food.Quantity * IncreaseWeightPerFoodUnit.CatWeight;
            base.Eat(food);
        }
    }
}
