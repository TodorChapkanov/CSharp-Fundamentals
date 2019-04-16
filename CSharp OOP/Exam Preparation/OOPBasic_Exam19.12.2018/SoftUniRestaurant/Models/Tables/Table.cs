using SoftUniRestaurant.Models.Drinks.Contracts;
using SoftUniRestaurant.Models.Foods.Contracts;
using SoftUniRestaurant.Models.Tables.Contracts;
using SoftUniRestaurant.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniRestaurant.Models.Tables
{
    public abstract class Table : ITable
    {
        private const string InvalidCountOfPeople = "Capacity has to be greater than 0";
        private const string InvalidNumberOfPeople = "Cannot place zero or less people!";

        private readonly IList<IFood> foodOrders;
        private readonly IList<IDrink> drinkOrders;
        private int capacity;
        private int numberOfPeople;

        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
            this.IsReserved = false;
            this.foodOrders = new List<IFood>();
            this.drinkOrders = new List<IDrink>();
        }

        public int TableNumber { get; private set; }

        public int Capacity
        {
            get => this.capacity;
            private set
            {
                ValidationMethods.ValidateInputNumberIsLessThanZero(value, InvalidCountOfPeople);
                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get => this.numberOfPeople;
            set
            {
                ValidationMethods.ValidateInputNumberIsEqualOrLessThanZero(value, InvalidNumberOfPeople);
                this.numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get; private set; }

        public bool IsReserved { get; set; }

        public decimal Price => this.CalculatePriceForAllPeople();
       

        public decimal GetBill()
        {
            var result = CalculateBill();

            return result;
        }

        public void Clear()
        {
            this.foodOrders.Clear();
            this.drinkOrders.Clear();
            this.numberOfPeople = 0;
        }

        public string GetFreeTableInfo()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"Table: {this.TableNumber}");
            builder.AppendLine($"Type: {this.GetType().Name}");
            builder.AppendLine($"Capacity: {this.Capacity}");
            builder.Append($"Price per Person: {this.PricePerPerson}");

            return builder.ToString();
        }

        public string GetOccupiedTableInfo()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"Table: {this.TableNumber}");
            builder.AppendLine($"Type: {this.GetType().Name}");
            builder.AppendLine($"Number of people: {this.NumberOfPeople}");
            var numberOfFoods = this.foodOrders.Any() ? this.foodOrders.Count.ToString() : "None";
            builder.AppendLine($"Food orders: {numberOfFoods}");

            foreach (var food in foodOrders)
            {
                builder.AppendLine(food.ToString());
            }

            var numberOfDrinks = this.drinkOrders.Any() ? this.drinkOrders.Count.ToString() : "None";
            builder.AppendLine($"Drink orders: {numberOfDrinks}");

            foreach (var drink in drinkOrders)
            {
                builder.AppendLine(drink.ToString());
            }

            return builder.ToString().TrimEnd();
        }

        public void OrderDrink(IDrink drink)
        {
            this.drinkOrders.Add(drink);
        }

        public void OrderFood(IFood food)
        {
            this.foodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            this.NumberOfPeople = numberOfPeople;
            this.IsReserved = true;
        }

        private decimal CalculatePriceForAllPeople()
        {
            var result = (decimal)this.NumberOfPeople * (decimal)this.PricePerPerson;
            return result;
        }

        private decimal CalculateBill()
        {
            var result = this.foodOrders
                .Sum(f => f.Price) 
                + this.drinkOrders.Sum(d => d.Price) 
                + this.Price;

            return result;
        }
    }
}
