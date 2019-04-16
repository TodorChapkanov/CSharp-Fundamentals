namespace SoftUniRestaurant.Models.Drinks
{
    public class FuzzyDrink : Drink
    {
        private const decimal FuzzyDrinkPrice = 2.50m;
        private decimal fuzzyDrinkPrice => FuzzyDrinkPrice;
        public FuzzyDrink(string name, int servingSize, string brand) 
            : base(name, servingSize, FuzzyDrinkPrice, brand)
        {
        }
    }
}
