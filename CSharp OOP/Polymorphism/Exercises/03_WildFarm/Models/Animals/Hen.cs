namespace _03_WildFarm.Models.Animals
{
    using _03_WildFarm.Models.Foods;
    using Constants;

    class Hen : Bird
    {
        public Hen(string name, double weight,  double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override string AskForFood()
        {
            return "Cluck";
        }

        public override void Eat(Food food)
        {
            this.Weight += food.Quantity * IncreaseWeightPerFoodUnit.HenWeight;
            base.Eat(food);
        }
    }
}
