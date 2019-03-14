using _03_WildFarm.Models.Foods;

namespace _03_WildFarm.Models.Animals
{
   public abstract class Animal
    {
        private string name;
        private double weight;
        private int foodEaten;

        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = foodEaten;
        }

        public int FoodEaten
        {
            get { return this.foodEaten; }
            set { this.foodEaten = value; }
        }
        
        public double Weight
        {
            get { return this.weight; }
            set { this.weight = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public abstract string AskForFood();

        public virtual void Eat(Food food)
        {
            this.FoodEaten += food.Quantity;
        }
    }
}
