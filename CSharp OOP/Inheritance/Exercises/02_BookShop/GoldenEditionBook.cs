namespace _02_BookShop
{
    public class GoldenEditionBook : Book
    {

        public GoldenEditionBook(string author, string title, decimal price): base(author, title, price)
        {
        }

        public override decimal Price
        {
            get => base.Price;
            set
            {
                base.ValidatePrice(value);
                base.price = SetPrice(value);
            }
        }

        private decimal SetPrice(decimal value)
        {
            var price = value * 1.3m;
            return price;
        }
    }
}
