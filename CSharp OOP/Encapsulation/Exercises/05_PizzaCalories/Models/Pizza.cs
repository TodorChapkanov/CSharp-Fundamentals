using _05_PizzaCalories.Models;
using System;
using System.Collections.Generic;

namespace _05_PizzaCalolies.Models
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.dough = dough;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value) ||
                    value.Length > 15 ||
                    value.Length <=0 ||
                    value == " ")
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }

        public void AddTopping(Topping toping)
        {
            if (this.toppings.Count >= 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            this.toppings.Add(toping);
        }
        
        public override string ToString()
        {
            var totalCalories = this.GetTotalCalories();
            return $"{this.name} - {totalCalories:f2} Calories.";
        }

        public double GetTotalCalories()
        {
            var calories = this.dough.CalculateCalories() + GetToppingCalories(this.toppings);
            return calories;
        }

        private double GetToppingCalories(List<Topping> toppings)
        {
            var sum = 0.0;
            foreach (var topping in toppings)
            {
                sum += topping.CalculateCalories();
            }

            return sum;
        }
    }
}
