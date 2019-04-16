using SoftUniRestaurant.Models.Drinks.Contracts;
using SoftUniRestaurant.Utils;

namespace SoftUniRestaurant.Models.Drinks
{
    public abstract class Drink : IDrink
    {
        private string name;
        private int servingSize;
        private decimal price;
        private string brand;

        public Drink(string name, int servingSize, decimal price, string brand)
        {
            Name = name;
            ServingSize = servingSize;
            Price = price;
            Brand = brand;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                ValidationMethods.ValidateStringForNullOrWhiteSpace(value, "Name cannot be null or white space!");
                this.name = value;
            }
        }

        public int ServingSize
        { get => this.servingSize;
           private set
            {
                ValidationMethods.ValidateInputNumberIsEqualOrLessThanZero(value, "Serving size cannot be less or equal to zero");
                this.servingSize = value;
            }
        }

        public decimal Price
        {
            get => this.price;
            private set
            {
                ValidationMethods.ValidateInputNumberIsEqualOrLessThanZero(value, "Price cannot be less or equal to zero");
                this.price = value;
            }
        }

        public string Brand
        {
            get => this.brand;
             private set
            {
                ValidationMethods.ValidateStringForNullOrWhiteSpace(value, "Brand cannot be null or white space!");
                this.brand = value;
            }
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Brand} - {this.ServingSize}ml - {this.Price:f2}lv";
        }
    }
}
