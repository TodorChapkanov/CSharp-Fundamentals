namespace _07_FoodShortage.Models
{
    using _07_FoodShortage.Contrcts;


    class Citizen  : Person, IBuyer
    {
        public Citizen(string name, int age, string id, string birthdate)
           : base(name, age)
        {
            this.Id = id;
            this.Birthdate = birthdate;
            this.Food = 0;
        }

        public string Id { get; set; }

        public string Birthdate { get; set; }

        public int Food { get; private set; }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
