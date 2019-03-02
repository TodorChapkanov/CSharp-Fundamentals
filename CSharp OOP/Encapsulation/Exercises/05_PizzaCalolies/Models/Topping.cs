namespace _05_PizzaCalolies.Models
{
    using _05_PizzaCalolies.ConstantData;
    using System;

   public class Topping
    {
        private string name;
        private double weight;

        public Topping(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        protected string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (!ToppingCalories.ToppingType.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                this.name = value;
            }
        }

        protected double Weight
        {
            get
            {
                return this.weight;
            }

            set
            {
                if (value > 50 || value <= 0 )
                {
                    throw new ArgumentException($"{this.name} weight should be in the range[1..50].");
                }

                this.weight = value;
            }
           
        }

        public double CalculateCalories()
        {
            var result = (this.weight * ToppingCalories.GramTopping) * ToppingCalories.ToppingType[this.name.ToLower()];
            return result;
        }
    }
}
