namespace _05_PizzaCalories
{
    using _05_PizzaCalolies.Models;
    using _05_PizzaCalories.Models;
    using System;

    public class StartUp
    {
        public static void Main()
        {
          
            try
            {
                var pizzaArguments = Console.ReadLine().Split();
                var pizzaName = pizzaArguments[1];

                var doughArguments = Console.ReadLine().Split();
                var doughType = doughArguments[1];
                var bakingTechnique = doughArguments[2];
                var weight = double.Parse(doughArguments[3]);
                var dough = new Dough(doughType, bakingTechnique, weight);

                var pizza = new Pizza(pizzaName, dough);
                
                string toppingArgument;
                while ((toppingArgument = Console.ReadLine()) != "END")
                {
                    var arguments = toppingArgument.Split();
                    var toppingName = arguments[1];
                    var toppingWeight = double.Parse(arguments[2]);
                    var topping = new Topping(toppingName, toppingWeight);

                    pizza.AddTopping(topping);

                }

                Console.WriteLine(pizza);
            }
            catch (ArgumentException ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
