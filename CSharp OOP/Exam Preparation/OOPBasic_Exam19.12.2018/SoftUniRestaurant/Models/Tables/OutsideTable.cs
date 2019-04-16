namespace SoftUniRestaurant.Models.Tables
{
    public class OutsideTable : Table
    {
        private const decimal InitialPricePerPerson = 3.50m;
        private decimal initialPricePerPerson => InitialPricePerPerson;

        public OutsideTable(int tableNumber, int capacity) 
            : base(tableNumber, capacity, InitialPricePerPerson)
        {
        }
    }
}
