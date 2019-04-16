using System;

namespace StorageMaster.Models.Products
{
    public abstract class Product
    {
        private double price;
        private double weight;

        public Product(double price, double weight)
        {
            this.Price = price;
            this.Weight = weight;
        }
        
        public double Price
        {
            get => price;
            set
            {
                if (value <= 0)
                {
                    throw new InvalidOperationException("Price cannot be negative!");
                }
                this.price = value;
            }
        }

        public double Weight
        {
            get => this.weight;
            private set => this.weight = value;
        }
    }
}
