using _03_WildFarm.Models.Foods;

namespace _03_WildFarm.Models.Animals
{
   public abstract class Bird: Animal
    {
        private double wingSize;

        public Bird(string name, double weight, double wingSize)
            :base(name, weight)
        {
            this.WingSize = wingSize;
        }

        public double WingSize
        {
            get { return this.wingSize; }
            set { this.wingSize = value; }
        }

        public override string AskForFood()
        {
            return string.Empty;
        }
        

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}
