using Microsoft.VisualBasic.CompilerServices;
using SoftUniRestaurant.Models.Foods.Contracts;
using SoftUniRestaurant.Utils;
using System;

namespace SoftUniRestaurant.Models.Foods
{
    public abstract class Food : IFood
    {
        private const string InvalidName = "Name cannot be null or white space!";
        private const string InvalidServingSize = "Serving size cannot be less or equal to zero";
        private const string InvalidPrice = "Price cannot be less or equal to zero!";

        private string name;
        private int servingSize;
        private decimal price;

        public Food(string name, int servingSize, decimal price)
        {
            Name = name;
            ServingSize = servingSize;
            Price = price;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                ValidationMethods.ValidateStringForNullOrWhiteSpace(value, InvalidName);
                this.name = value;
            }
        }

        public int ServingSize
        {
            get => this.servingSize;
            private set
            {
                ValidationMethods.ValidateInputNumberIsEqualOrLessThanZero(value, InvalidServingSize);
                this.servingSize = value;
            }
        }

        public decimal Price
        {
            get => this.price;
            private set
            {
                ValidationMethods.ValidateInputNumberIsEqualOrLessThanZero(value, InvalidPrice);
                this.price = value;
            }
        }

        public override string ToString()
        {
            return $"{this.Name}: {this.ServingSize}g - {this.Price:f2}";
        }
    }
}
