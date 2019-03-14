namespace _03_WildFarm.Factories
{
    using _03_WildFarm.Models.Foods;
    using System;

    public  class FoodFactory
    {
        public static Food CreateFood(string type, int quantity)
        {
            switch (type.ToLower())
            {
                case "meat":
                    return new Meat(quantity);

                case "fruit":
                    return new Fruit(quantity);

                case "vegetable":
                    return new Vegetable(quantity);

                case "seeds":
                    return new Seeds(quantity);
                default:
                    throw new ArgumentException("Invalid Food");
            }
        }
    }
}
