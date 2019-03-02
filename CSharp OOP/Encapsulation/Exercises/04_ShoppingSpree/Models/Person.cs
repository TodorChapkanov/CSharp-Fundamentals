namespace _04_ShoppingSpree.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Person
    {
        private string name;
        private double budget;
        private List<string> shoppingBag;

        public Person(string name, double budget)
        {
            this.Name = name;
            this.Budget = budget;
            shoppingBag = new List<string>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (value == null || value.Length <= 0 || value == " ")
                {
                    throw new FormatException("Name cannot be empty");
                }
                this.name = value;
                this.name = value;
            }
        }

        public double Budget
        {
            get
            {
                return this.budget;
            }

            set
            {
                if (value < 0)
                {
                    throw new FormatException("Money cannot be negative");
                }
                this.budget = value;
            }
        }
        
        public void Buy(Product product)
        {
            if (product.Price > budget)
            {
                throw new ArgumentException($"{this.name} can't afford {product.Name}");
            }
            shoppingBag.Add(product.Name);
            budget -= product.Price;
            throw new ArgumentException($"{this.name} bought {product.Name}");
        }
        public override string ToString()
        {
            var boughtProducts = this.shoppingBag.Count > 0
                 ? string.Join(", ", this.shoppingBag)
                 : "Nothing bought";

            return $"{this.name} - {boughtProducts}";
        }
    }
}
