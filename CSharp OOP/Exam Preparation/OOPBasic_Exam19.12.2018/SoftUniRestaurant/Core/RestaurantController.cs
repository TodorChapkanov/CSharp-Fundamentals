using SoftUniRestaurant.Models.Drinks.Contracts;
using SoftUniRestaurant.Models.Factories;
using SoftUniRestaurant.Models.Foods.Contracts;
using SoftUniRestaurant.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniRestaurant.Core
{
    public class RestaurantController
    {
       // private IFoodFactory foodFactory;
       // private IDrinkFactory drinkFactory;
        //private ITableFactory tableFactory;

        private IList<IFood> menu;
        private IList<IDrink> drinks;
        private IList<ITable> tables;
        private decimal income;

        public RestaurantController()//IFoodFactory foodFactory,IDrinkFactory drinkFactory, ITableFactory tableFactory)
        {
           // this.foodFactory = foodFactory;
           // this.drinkFactory = drinkFactory;
           // this.tableFactory = tableFactory;

            this.menu = new List<IFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();

        }

        public string AddFood(string type, string name, decimal price)
        {
            var food = FoodFactory.CreateFood(type, name, price);

           

            this.menu.Add(food);
            return $"Added {food.Name} ({food.GetType().Name}) with price {food.Price:f2} to the pool";
        }

        public string AddDrink(string type, string name, int servingSize, string brand)
        {
            var drink = DrinkFactory.CreateDrink(type, name, servingSize, brand);

           
            
            this.drinks.Add(drink);
            return $"Added {drink.Name} ({drink.Brand}) to the drink pool";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
          var table = TableFactory.CreateTable(type, tableNumber, capacity);

           

            this.tables.Add(table);
            return $"Added table number {table.TableNumber} in the restaurant";
        }

        public string ReserveTable(int numberOfPeople)
        {
            var table = this.tables
                .FirstOrDefault(t => t.Capacity >= numberOfPeople
                && t.IsReserved == false);

            if (table == null)
            {
                return $"No available table for { numberOfPeople} people";
            }

            table.IsReserved = true;
            table.NumberOfPeople = numberOfPeople;
            return $"Table {table.TableNumber} has been reserved for {table.NumberOfPeople} people";

           
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            var food = this.menu.FirstOrDefault(f => f.Name == foodName);
            if (table == null)
            {
                return $"Could not find table with {tableNumber}";
            }

            if (food == null)
            {
                return $"No {foodName} in the menu";
            }
            table.OrderFood(food);
            return $"Table {tableNumber} ordered {foodName}";
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            var drink = this.drinks.FirstOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);
            if (table == null)
            {
                return $"Could not find table with {tableNumber}";
            }

            if (drink == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }
            table.OrderDrink(drink);
            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string LeaveTable(int tableNumber)
        {
            var builder = new StringBuilder();
            var table = this.tables.First(t => t.TableNumber == tableNumber);
            builder.AppendLine($"Table: {tableNumber}");
            builder.Append($"Bill: {table.GetBill()}");

            this.income += table.GetBill();
            table.Clear();
            return builder.ToString();
        }

        public string GetFreeTablesInfo()
        {
            var builder = new StringBuilder();
            this.tables
                .Where(t => t.IsReserved == false)
                .ToList()
                .ForEach(t => builder.AppendLine(t.GetFreeTableInfo()));

            return builder.ToString().TrimEnd();
        }

        public string GetOccupiedTablesInfo()
        {
            var builder = new StringBuilder();
            this.tables
                .Where(t => t.IsReserved == true)
                .ToList()
                .ForEach(t => builder.AppendLine(t.GetOccupiedTableInfo()));

            return builder.ToString().TrimEnd();
        }

        public string GetSummary()
        {
            return $"Total income: {this.income:f2}lv";
        }
    }
}
