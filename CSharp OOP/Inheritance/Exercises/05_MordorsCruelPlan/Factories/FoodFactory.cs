namespace _05_Mordor_sCruelPlan.Factories
{
    using Models.Foods;

    class FoodFactory
    {
        public Food CreateFood(string food)
        {
            switch (food.ToLower())
            {
                case "apple":
                    return new Apple();

                case "cram":
                    return new Cram();

                case "honeycake":
                    return new HoneyCake();

                case "lembas":
                    return new Lembas();

                case "melon":
                    return new Melon();

                case "mushrooms":
                    return new Mushrooms();
                    
                default:
                    return new DifferentFood();
            }
        }
    }
}
