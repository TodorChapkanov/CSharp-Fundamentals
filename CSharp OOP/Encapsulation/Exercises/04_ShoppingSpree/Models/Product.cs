namespace _04_ShoppingSpree.Models
{
    using System;
    
    class Product
    {
        private string name;
        private double price;

        public Product(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value == null || value.Length <=0 || value == " ")
                {
                    throw new FormatException("Name cannot be empty");
                }
                this.name = value;
            }
        }

        public double Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0)
                {
                    throw new FormatException("Money cannot be negative");
                }
                this.price = value;
            }
        }
    }
}
