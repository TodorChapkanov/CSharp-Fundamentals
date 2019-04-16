namespace SoftUniRestaurant.Models.Foods
{
    public class MainCourse : Food
    {
        private const int InitialServingSize = 500;
        private int initialServingSize => InitialServingSize;
        public MainCourse(string name, decimal price) : base(name, InitialServingSize, price)
        {
        }
    }
}
