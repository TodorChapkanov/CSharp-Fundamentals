namespace SoftUniRestaurant.Models.Foods
{
    public class Soup : Food
    {
        private const int InitialServingSize = 245;
        private int initialServingSize => InitialServingSize;
        public Soup(string name, decimal price) : base(name, InitialServingSize, price)
        {
        }
    }
}
