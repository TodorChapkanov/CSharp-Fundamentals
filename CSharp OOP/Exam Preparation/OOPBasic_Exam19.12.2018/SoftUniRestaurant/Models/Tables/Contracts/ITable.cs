using SoftUniRestaurant.Models.Drinks.Contracts;
using SoftUniRestaurant.Models.Foods.Contracts;

namespace SoftUniRestaurant.Models.Tables.Contracts
{
    public interface ITable
    {
        int TableNumber{ get; }

        int Capacity { get; }

        int NumberOfPeople { get; set; }

        decimal PricePerPerson { get; }

        bool IsReserved { get; set; }

        void Reserve(int numberOfPeople);

        string GetOccupiedTableInfo();

        void OrderFood(IFood food);

        void OrderDrink(IDrink drink);

        decimal GetBill();

        void Clear();

       string GetFreeTableInfo();
    }
}
