namespace SoftUniRestaurant.Models.Drinks
{
    public class Water : Drink
    {
        private const decimal WaterPrice = 1.50m;
        private decimal waterPrice => WaterPrice;
        public Water(string name, int servingSize, string brand) : base(name, servingSize, WaterPrice, brand)
        {
        }
    }
}
